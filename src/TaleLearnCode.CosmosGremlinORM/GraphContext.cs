using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TaleLearnCode.CosmosGremlinORM.Exceptions;


namespace TaleLearnCode.CosmosGremlinORM
{
	public class GraphContext
	{

		Dictionary<string, TrackedVertex> changeTracker = new Dictionary<string, TrackedVertex>();

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

		//public virtual VertexEntry<TVertex> Add<TVertex>(TVertex vertex)
		//{

		//}

		public virtual void Add(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			changeTracker.Add(vertex.Id, new TrackedVertex(vertex, VertexState.Added));
		}

		public virtual void Update(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			if (changeTracker.ContainsKey(vertex.Id))
			{
				changeTracker[vertex.Id].Vertex = vertex;
				changeTracker[vertex.Id].State = VertexState.Modified;
			}
			else
				throw new VertexNotInChangeTrackerException();
		}

		public virtual void Delete(Vertex vertex)
		{
			if (vertex is null) throw new ArgumentNullException(nameof(vertex));
			if (changeTracker.ContainsKey(vertex.Id))
			{
				changeTracker[vertex.Id].State = VertexState.Deleted;
			}
			else
			{
				changeTracker.Add(vertex.Id, new TrackedVertex(vertex, VertexState.Deleted));
			}
		}

		public virtual async Task<List<TVertex>> Query<TVertex>(string gremlinQuery)
		{

			if (string.IsNullOrWhiteSpace(gremlinQuery)) return null;
			var resultSet = await GraphFacade.QueryAsync(gremlinQuery).ConfigureAwait(true);

			List<TVertex> returnValue = new List<TVertex>();
			if (resultSet.Count > 0)
				foreach (var result in resultSet)
				{
					var resultObject = JsonSerializer.Deserialize<TVertex>(result);
					if (resultObject is Vertex)
						changeTracker.Add(((Vertex)resultObject).Id, resultObject);
				}


			return returnValue;

		}

	}

}