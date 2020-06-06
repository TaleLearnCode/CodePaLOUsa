using CodePaLOUsa.Entities;
using System;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.GraphBuilder
{

	class Program
	{

		static void Main(string[] args)
		{

			Console.WriteLine("Press key to start building the database...");
			Console.ReadKey();

			PopulateSessionLevels();

		}

		private static void SaveVertex<T>(T vertex)
		{
			ExecuteGremlin(TaleLearnCode.CosmosGremlinORM.Vertex.Save<T>(vertex));
		}

		private static void ExecuteGremlin(string statement)
		{
			var results = GremlinQuery.Execute(statement, Settings.Endpoint, Settings.AuthKey, Settings.Database, Settings.Graph);
			if (results.StatusCode != 200)
				throw new Exception($"Status Code {results.StatusCode} returned");
		}



		private static void PopulateSessionLevels()
		{
			ExecuteGremlin("g.V().hasLabel('sessionLevel').has('eventId', 10).Drop()");
			SaveVertex(new SessionLevel("10", "Beginner", 1));
			SaveVertex(new SessionLevel("10", "Intermediate", 2));
			SaveVertex(new SessionLevel("10", "Advanced", 3));
		}

	}

}