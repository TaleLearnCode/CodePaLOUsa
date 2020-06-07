using ShellProgressBar;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using TaleLearnCode.CosmosGremlinORM;

namespace DocumentGraphSchema
{
	class Program
	{
		static void Main(string[] args)
		{

			// TODO: Convert these to input parameters
			string partitionKey = "eventId";
			string partitionKeyValue = "schemaDefinition";
			string assemblyFilePath = @"D:\Repros\TaleLearnCode\CodePaLOUsa\src\CodePaLOUsa.Entities\bin\Debug\netstandard2.0\CodePaLOUsa.Entities.dll";

			Console.WriteLine("Dropping the existing schema documentation...");
			ExecuteGremlin($"g.V().has('{partitionKey}', '{partitionKeyValue}').Drop()");

			Assembly assembly = Assembly.LoadFrom(assemblyFilePath);

			ProgressBarOptions progressBarOptions = new ProgressBarOptions
			{
				ProgressCharacter = '─',
				ProgressBarOnBottom = true
			};
			int assemblyTypeCount = assembly.GetTypes().Count();
			int typeCounter = 1;
			using var progressBar = new ProgressBar(assemblyTypeCount, ProgressBarMessage(typeCounter, assemblyTypeCount), progressBarOptions);

			foreach (Type type in assembly.GetTypes())
			{
				VertexAttribute vertexAttribute = (VertexAttribute)Attribute.GetCustomAttribute(type, typeof(VertexAttribute));
				if (vertexAttribute != default)
				{
					StringBuilder schemaDefinition = new StringBuilder($"g.addV('{vertexAttribute.Label}').property('{partitionKey}', '{partitionKeyValue}').property('name', '{vertexAttribute.Label}').property('description', '{vertexAttribute.Description}').property('softDelete', {vertexAttribute.SoftDelete.ToString().ToLower(CultureInfo.InvariantCulture)})");

					foreach (var property in type.GetProperties())
					{
						string key = property.Name;
						string description = string.Empty;
						bool isRequired = false;
						var propertyAttributes = property.GetCustomAttributes(true);
						if (propertyAttributes.Any())
						{
							foreach (var propertyAttribute in propertyAttributes)
							{
								if (propertyAttribute.GetType() == typeof(GraphPropertyAttribute))
								{
									var graphPropertyAttribute = (GraphPropertyAttribute)Attribute.GetCustomAttribute(property, typeof(GraphPropertyAttribute), true);
									bool includeInGraph = graphPropertyAttribute.IncludeInGraph;
									if (includeInGraph)
									{
										key = string.IsNullOrWhiteSpace(graphPropertyAttribute.Key) ? Vertex.CasedString(property.Name, vertexAttribute.PropertyNamingPolicy) : graphPropertyAttribute.Key;
										description = graphPropertyAttribute.Description;
										isRequired = graphPropertyAttribute.IsRequired;
									}
								}
							}
						}

						schemaDefinition.Append($".property('properties', '{key}:{isRequired.ToString().ToLower(CultureInfo.InvariantCulture)}:{description}')");

					}


					ExecuteGremlin(schemaDefinition.ToString());

				}
				typeCounter++;
				progressBar.Tick(ProgressBarMessage(typeCounter, assemblyTypeCount));
			}

		}

		private static string ProgressBarMessage(int typeCounter, int assemblyTypeCount)
		{
			return $"Documentation schema ─ type {typeCounter} of {assemblyTypeCount}";
		}

		private static void ExecuteGremlin(string statement)
		{
			var results = GremlinQuery.Execute(statement, Settings.Endpoint, Settings.AuthKey, Settings.Database, Settings.Graph);
			if (results.StatusCode != 200)
				throw new Exception($"Status Code {results.StatusCode} returned");
		}
	}
}
