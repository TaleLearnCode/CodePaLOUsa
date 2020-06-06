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
			PopulateRooms();
			PopulateSessionTypes();
			PopulateTopics();
			PopulateTags();

		}

		private static void PopulateSessionLevels()
		{
			Console.WriteLine("PopulateSessionLevels");
			ExecuteGremlin("g.V().hasLabel('sessionLevel').has('eventId', 10).Drop()");
			SaveVertex(new SessionLevel("10", "Introductory and overview", 1, "45508"));
			SaveVertex(new SessionLevel("10", "Intermediate", 2, "45509"));
			SaveVertex(new SessionLevel("10", "Advanced", 3, "45510"));
			SaveVertex(new SessionLevel("10", "Expert", 4, "45511"));
		}

		private static void PopulateRooms()
		{
			Console.WriteLine("PopulateRooms");
			ExecuteGremlin("g.V().hasLabel('room').has('eventId', 10).Drop()");
			SaveVertex(new Room("10", "MainStage", 0, "13468"));
			SaveVertex(new Room("10", "Breakout Room A", 1, "13469"));
			SaveVertex(new Room("10", "Breakout Room B", 1, "13470"));
			SaveVertex(new Room("10", "Breakout Room C", 1, "13471"));
			SaveVertex(new Room("10", "Breakout Room D", 1, "13472"));
			SaveVertex(new Room("10", "Breakout Room E", 1, "13473"));
			SaveVertex(new Room("10", "Breakout Room F", 1, "13474"));
			SaveVertex(new Room("10", "Breakout Room G", 1, "13475"));
			SaveVertex(new Room("10", "Breakout Room H", 1, "13476"));
			SaveVertex(new Room("10", "Breakout Room I", 1, "13477"));
			SaveVertex(new Room("10", "Breakout Room J", 1, "13478"));
			SaveVertex(new Room("10", "Breakout Room K", 1, "13479"));
			SaveVertex(new Room("10", "Breakout Room L", 1, "13909"));
		}

		private static void PopulateSessionTypes()
		{
			Console.WriteLine("PopulateSessionTypes");
			ExecuteGremlin("g.V().hasLabel('sessionType').has('eventId', 10).Drop()");
			SaveVertex(new SessionType("10", "Session", 1, "45498") { SessionLength = 60, ShowOnSchedule = true });
			SaveVertex(new SessionType("10", "Half-Day Workshop", 1, "45499") { SessionLength = 180, ShowOnSchedule = true });
			SaveVertex(new SessionType("10", "Full-Day Workshop", 1, "45500") { SessionLength = 360, ShowOnSchedule = true });
		}

		private static void PopulateTopics()
		{
			Console.WriteLine("PopulateTopics");
			ExecuteGremlin("g.V().hasLabel('topic').has('eventId', 10).Drop()");
			SaveVertex(new Topic("10", "Application Development", 1, "45501"));
			SaveVertex(new Topic("10", "Cloud/Infrastructure", 1, "45502"));
			SaveVertex(new Topic("10", "DevOps", 1, "45904"));
			SaveVertex(new Topic("10", "Project Management", 1, "45503"));
			SaveVertex(new Topic("10", "Requirements", 1, "45504"));
			SaveVertex(new Topic("10", "Quality Assurance", 1, "45905"));
			SaveVertex(new Topic("10", "Soft Skills", 1, "45505"));
			SaveVertex(new Topic("10", "User Experience", 1, "45507"));
		}

		private static void PopulateTags()
		{
			Console.WriteLine("PopulateTags");
			ExecuteGremlin("g.V().hasLabel('tag').has('eventId', 10).Drop()");
			SaveVertex(new Tag("10", ".NET", "45512"));
			SaveVertex(new Tag("10", "Accessibility", "45513"));
			SaveVertex(new Tag("10", "Agile", "45514"));
			SaveVertex(new Tag("10", "Android", "45515"));
			SaveVertex(new Tag("10", "Architecture", "45516"));
			SaveVertex(new Tag("10", "AWS", "45517"));
			SaveVertex(new Tag("10", "Azure", "45518"));
			SaveVertex(new Tag("10", "Big Data", "45519"));
			SaveVertex(new Tag("10", "Blazor", "45520"));
			SaveVertex(new Tag("10", "C++", "45521"));
			SaveVertex(new Tag("10", "Cloud", "45522"));
			SaveVertex(new Tag("10", "Concurrency", "45523"));
			SaveVertex(new Tag("10", "Container", "45524"));
			SaveVertex(new Tag("10", "Continuous Delivery", "45525"));
			SaveVertex(new Tag("10", "Cross-Platform", "45526"));
			SaveVertex(new Tag("10", "Database", "45527"));
			SaveVertex(new Tag("10", "Design (UI/UX/CSS)", "45528"));
			SaveVertex(new Tag("10", "Development Practices", "45529"));
			SaveVertex(new Tag("10", "DevOps", "45530"));
			SaveVertex(new Tag("10", "Docker", "45531"));
			SaveVertex(new Tag("10", "Fun", "45532"));
			SaveVertex(new Tag("10", "Functional Programming", "45533"));
			SaveVertex(new Tag("10", "Gaming", "45534"));
			SaveVertex(new Tag("10", "Google", "45535"));
			SaveVertex(new Tag("10", "Google Cloud", "45536"));
			SaveVertex(new Tag("10", "Hardware", "45537"));
			SaveVertex(new Tag("10", "iOS", "45538"));
			SaveVertex(new Tag("10", "IoT", "45539"));
			SaveVertex(new Tag("10", "Java", "45540"));
			SaveVertex(new Tag("10", "JavaScript", "45541"));
			SaveVertex(new Tag("10", "Kotlin", "45542"));
			SaveVertex(new Tag("10", "Kubernetes", "45543"));
			SaveVertex(new Tag("10", "Machine Learning", "45544"));
			SaveVertex(new Tag("10", "Microservices", "45545"));
			SaveVertex(new Tag("10", "Microsoft", "45546"));
			SaveVertex(new Tag("10", "Mobile", "45547"));
			SaveVertex(new Tag("10", "NoSQL", "45548"));
			SaveVertex(new Tag("10", "Other", "45549"));
			SaveVertex(new Tag("10", "People", "45550"));
			SaveVertex(new Tag("10", "Performance", "45551"));
			SaveVertex(new Tag("10", "PHP", "45552"));
			SaveVertex(new Tag("10", "Project Management", "45553"));
			SaveVertex(new Tag("10", "Python", "45554"));
			SaveVertex(new Tag("10", "Quality Assurance", "45555"));
			SaveVertex(new Tag("10", "Requirements", "45556"));
			SaveVertex(new Tag("10", "Ruby/Rails", "45557"));
			SaveVertex(new Tag("10", "Scala", "45558"));
			SaveVertex(new Tag("10", "Security", "45559"));
			SaveVertex(new Tag("10", "Serverless", "45560"));
			SaveVertex(new Tag("10", "Soft Skills", "45561"));
			SaveVertex(new Tag("10", "SQL", "45562"));
			SaveVertex(new Tag("10", "Testing", "45563"));
			SaveVertex(new Tag("10", "Tools", "45564"));
			SaveVertex(new Tag("10", "UI", "45565"));
			SaveVertex(new Tag("10", "UX", "45566"));
			SaveVertex(new Tag("10", "VR", "45567"));
			SaveVertex(new Tag("10", "Web", "45568"));
			SaveVertex(new Tag("10", "Web Assembly", "45569"));
			SaveVertex(new Tag("10", "Web Services", "45570"));
			SaveVertex(new Tag("10", "Windows", "45571"));
			SaveVertex(new Tag("10", "Work Skills", "45572"));
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




	}

}