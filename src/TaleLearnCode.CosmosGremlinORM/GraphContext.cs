using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaleLearnCode.CosmosGremlinORM.Exceptions;


namespace TaleLearnCode.CosmosGremlinORM
{
	public class GraphContext
	{

		Dictionary<string, TrackedVertex> _changeTracker = new Dictionary<string, TrackedVertex>();

		public GraphFacade GraphFacade { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GraphContext"/> class.
		/// </summary>
		/// <param name="endpoint">The Cosmos DB account endpoint.</param>
		/// <param name="authKey">The Cosmos DB account authentication key.</param>
		/// <param name="databaseName">Name of the database.</param>
		/// <param name="graphName">Name of the graph.</param>
		public GraphContext(string endpoint, string authKey, string databaseName, string graphName)
		{
			GraphFacade = new GraphFacade(endpoint, authKey, databaseName, graphName);
		}

		public virtual void Add(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			_changeTracker.Add(vertex.Id, new TrackedVertex(vertex, VertexState.Added));
		}

		public virtual void Update(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			if (_changeTracker.ContainsKey(vertex.Id))
			{
				_changeTracker[vertex.Id].Vertex = vertex;
				_changeTracker[vertex.Id].State = VertexState.Modified;
			}
			else
				throw new VertexNotInChangeTrackerException();
		}

		public virtual void Delete(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			if (_changeTracker.ContainsKey(vertex.Id))
			{
				_changeTracker[vertex.Id].State = VertexState.Deleted;
			}
			else
			{
				_changeTracker.Add(vertex.Id, new TrackedVertex(vertex, VertexState.Deleted));
			}
		}

		//public virtual async Task<List<object>> Query(string gremlinQuery)
		//{

		//	if (string.IsNullOrWhiteSpace(gremlinQuery)) return null;
		//	var resultSet = await GraphFacade.QueryAsync(gremlinQuery).ConfigureAwait(true);

		//	List<object> returnValue = new List<object>();
		//	if (resultSet.Count > 0)
		//		foreach (var result in resultSet)
		//		{
		//			string output = JsonSerializer.Serialize(result);
		//			//Console.WriteLine(output);

		//			var array = output.Split('{');
		//			Console.WriteLine(array.Length);


		//			//var resultObject = JsonSerializer.Deserialize<TVertex>(result);
		//			//if (resultObject is Vertex)
		//			//	_changeTracker.Add(((Vertex)resultObject).Id, resultObject);
		//			//returnValue.Add(resultObject);
		//		}

		//	return returnValue;

		//}

		public virtual async Task<List<TVertex>> Query<TVertex>(string gremlinQuery)
		{

			if (string.IsNullOrWhiteSpace(gremlinQuery)) throw new ArgumentNullException(nameof(gremlinQuery));
			var resultSet = await GraphFacade.QueryAsync(gremlinQuery).ConfigureAwait(true);


			List<TVertex> returnValue = new List<TVertex>();



			return returnValue;

		}

	}

}