using CodePaLOUsa.GraphBuilder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaleLearnCode.CosmosGremlinORM;

namespace Validation
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var graphFacade = new GraphFacade(Settings.Endpoint, Settings.AuthKey, Settings.Database, Settings.Graph);
			//string query = "g.V().hasLabel('room').has('eventId', 10)";
			string query = "g.V().hasLabel('room').has('eventId', 'schemaDefinition')";
			var results = await graphFacade.QueryAsync(query);

			if (results.Count > 0)
			{
				//Console.WriteLine("\tResult:");
				//foreach (var result in results)
				//{
				//	// The vertex results are formed as Dictionaries with a nested dictionary for their properties
				//	string output = JsonSerializer.Serialize(result);
				//	Console.WriteLine($"\t{output}");
				//	Console.ReadLine();
				//}
				//Console.WriteLine();




				if (results.Any())
				{
					foreach (var result in results)
					{
						foreach (var r in result)
						{
							if (r.Key == "properties")
							{

								foreach (var v in r.Value)
								{

									//[{"id":"13a7c61f-51d5-4452-968d-1f0d56de7ddb","value":13468}]

									//[{"id":"e5a1dcc6-aef9-4ec5-a037-fd493a550830","value":"sessionizeId:false:"},{"id":"32589f62-972d-4ee3-8a45-09d17afb139e","value":"sortOrder:false:The sort order of the vertex in relation to the other vertices with the same label"},{"id":"3dd66414-cde8-40e2-b6e2-873ebfba5fc5","value":"id:false:Identifier of the document."},{"id":"c3f6b4c4-4cde-4bc6-a755-e91f7d96853b","value":"eventId:false:Identifier of the event the vertex is associated with. Serves as the partition key."},{"id":"7ab77eeb-1aed-423d-bf48-f0a9f937c9bc","value":"name:false:The name of the vertex object."}]

									Console.WriteLine(JsonSerializer.Serialize(v.Value));



									////Console.WriteLine(JsonSerializer.Serialize(v.Value));

									//if (v.Key == "name")
									//{

									//	//var rootobjects = JsonSerializer.Deserialize<Rootobject[]>(JsonSerializer.Serialize(v.Value));

									//	//Console.WriteLine(rootobjects[0].Property1[0].value);

									//	//                              if (DynamicObject.TryConvert(v, out var bar))
									//	//                              {

									//	//                              }

									//	//Console.WriteLine(JsonSerializer.Serialize(v.Value));
									//	//var x = JsonSerializer.Deserialize(v.Value[0]);
									//	//Console.WriteLine(x);



									//	//GraphProperty[] graphProperty = JsonSerializer.Deserialize(JsonSerializer.Serialize(v.Value));
									//	////GraphProperty[] graphProperty = JsonSerializer.Deserialize(v.Value);
									//	//Console.WriteLine(graphProperty[0].Value);
									//	Console.ReadLine();
									//}



									Console.ReadLine();


								}


								//var foo = await JsonSerializer.Deserialize<IEnumerable<Properties>>(r.Value);

								//System.Console.WriteLine(foo.Name);

								//foreach (var v in r.Value)
								//{

								//	//Console.WriteLine(v.Key);
								//	//Console.WriteLine(v.Value);

								//	if (v.Key == "name")
								//	{
								//		//var myValue = JsonSerializer.Serialize(v.Value);
								//		GraphProperty serializedValue = JsonSerializer.Deserialize(v.Value);
								//		Console.WriteLine(serializedValue.Value);

								//	}


								//}
							}
						}

						//var x = result.Where(k => k.Key == "properties");
						//foreach (var y in x.ToList())
						//{
						//	Console.WriteLine(y);
						//}

						Console.ReadLine();
					}
				}
			}
		}
	}

	//public partial class Root
	//{
	//	[JsonPropertyName("id")]
	//	public Guid Id { get; set; }

	//	[JsonPropertyName("label")]
	//	public string Label { get; set; }

	//	[JsonPropertyName("type")]
	//	public string Type { get; set; }

	//	[JsonPropertyName("properties")]
	//	public Properties Properties { get; set; }
	//}

	//public partial class Properties
	//{
	//	[JsonPropertyName("sessionizeId")]
	//	public GraphProperty[] SessionizeId { get; set; }

	//	[JsonPropertyName("sortOrder")]
	//	public EventId[] SortOrder { get; set; }

	//	[JsonPropertyName("eventId")]
	//	public EventId[] EventId { get; set; }

	//	[JsonPropertyName("name")]
	//	public GraphProperty[] Name { get; set; }
	//}

	//public partial class EventId
	//{
	//	[JsonPropertyName("id")]
	//	public string Id { get; set; }

	//	[JsonPropertyName("value")]
	//	public long Value { get; set; }
	//}

	//public partial class Name
	//{
	//	[JsonPropertyName("id")]
	//	public Guid Id { get; set; }

	//	[JsonPropertyName("value")]
	//	public string Value { get; set; }
	//}


	public class GraphProperty
	{
		public GraphPropertyValue[] Value { get; set; }
	}


	public partial class GraphPropertyValue
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("value")]
		public string Value { get; set; }
	}





	public class Rootobject
	{
		public Class1[] Property1 { get; set; }
	}

	public class Class1
	{
		public string id { get; set; }
		public string value { get; set; }
	}


}