using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Exceptions;
using Gremlin.Net.Structure.IO.GraphSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaleLearnCode.CosmosGremlinORM
{
	public static class GremlinQuery
	{

		public static QueryResults Execute(string query, string gremlinEndpoint, string gremlinKey, string database, string graph, int port = 443)
		{
			var gremlinServer = new GremlinServer(gremlinEndpoint, port,
																				enableSsl: true,
																				username: $"/dbs/{database}/colls/{graph}",
																				password: gremlinKey);
			return Execute(query, gremlinServer);
		}

		public static QueryResults Execute(string query, GremlinServer gremlinServer)
		{
			using var gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType);
			return new QueryResults(SubmitRequest(gremlinClient, query).Result);
		}

		private static Task<ResultSet<dynamic>> SubmitRequest(GremlinClient gremlinClient, string query)
		{
			try
			{
				return gremlinClient.SubmitAsync<dynamic>(query);
			}
			catch (ResponseException ex)
			{
				throw new QueryExecutionException(ex);
			}
		}

		public static string GetValueAsString(IReadOnlyDictionary<string, object> dictionary, string key)
		{
			if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
			return JsonConvert.SerializeObject(GetValueOrDefault(dictionary, key));
		}

		private static object? GetValueOrDefault(IReadOnlyDictionary<string, object> dictionary, string key)
		{
			if (dictionary.ContainsKey(key))
			{
				return dictionary[key];
			}

			return null;
		}

	}
}
