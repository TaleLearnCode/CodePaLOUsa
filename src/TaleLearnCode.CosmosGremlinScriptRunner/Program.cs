using System;
using System.IO;
using TaleLearnCode.CosmosGremlinORM;

namespace TaleLearnCode.CosmosGremlinScriptRunner
{

	class Program
	{

		static void Main(string[] args)
		{

			// TODO: Add a prompt for the script file to run
			// TODO: Show a progress bar of the execution

			string line;
			int executionCounter = 0;

			Console.WriteLine("Opening the script file...");
			var file = new StreamReader(@"D:\Repros\TaleLearnCode\CodePaLOUsa\src\CodePaLOUsa.Entities\Gremlin Scripts\Schema.gremlin");
			Console.WriteLine("Executing the script file...");
			while ((line = file.ReadLine()) != null)
			{
				if (!string.IsNullOrWhiteSpace(line) && !(line.StartsWith("--")))
				{
					var results = GremlinQuery.Execute(line, Settings.Endpoint, Settings.AuthKey, Settings.Database, Settings.Graph);
					if (results.StatusCode != 200)
						throw new Exception($"Status Code {results.StatusCode} returned");
					executionCounter++;
					Console.Write(".");
				}
			}

			Console.WriteLine($"Executed {executionCounter} Gremlin commands");

		}

	}

}