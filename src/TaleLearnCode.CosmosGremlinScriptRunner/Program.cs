using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaleLearnCode.CosmosGremlinORM;

namespace TaleLearnCode.CosmosGremlinScriptRunner
{

	class Program
	{

		static void Main(string[] args)
		{

			// TODO: Take in the script path as an argument

			string scriptPath = default;
			Console.WriteLine("Specify which script file to execute:");
			Console.WriteLine("\t1. Schema documentation");
			var input = Console.ReadKey(true);
			switch (input.Key)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1:
					scriptPath = @"D:\Repros\TaleLearnCode\CodePaLOUsa\src\Gremlin Scripts\Schema.gremlin";
					break;
				default:
					Console.WriteLine("Invalid option selected");
					Environment.Exit(0);
					break;

			}

			string line;
			int statementCount = 0;

			//var file = new StreamReader(@"D:\Repros\TaleLearnCode\CodePaLOUsa\src\Gremlin Scripts\Schema.gremlin");
			var file = new StreamReader(scriptPath);

			List<string> statements = new List<string>();
			while ((line = file.ReadLine()) != null)
				if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("--"))
					statements.Add(line);

			if (statements.Any())
			{
				statementCount = statements.Count;
				ProgressBarOptions progressBarOptions = new ProgressBarOptions
				{
					ProgressCharacter = '─',
					ProgressBarOnBottom = true
				};
				using var progressBar = new ProgressBar(statements.Count, "Executing Script File", progressBarOptions);
				int counter = 0;
				foreach (var statement in statements)
				{
					var results = GremlinQuery.Execute(statement, Settings.Endpoint, Settings.AuthKey, Settings.Database, Settings.Graph);
					if (results.StatusCode != 200)
						throw new Exception($"Status Code {results.StatusCode} returned");
					counter++;
					progressBar.Tick($"Statement {counter} of {statementCount}");
				}
			}

			Console.WriteLine($"Executed {statementCount} Gremlin commands");

		}

	}

}