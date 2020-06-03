using Gremlin.Net.Driver.Exceptions;
using System;

namespace TaleLearnCode.CosmosGremlinORM
{

	public class QueryExecutionException : Exception
	{

		/// <summary>
		/// Gets or sets the status code of the query execution.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the status of the query execution.
		/// </value>
		public int StatusCode { get; set; }

		/// <summary>
		/// Gets or sets the Cosmos DB request charge of the query.
		/// </summary>
		/// <value>
		/// A <c>decimal</c> representing the request charge of the query within Cosmos DB.
		/// </value>
		public decimal RequestCharge { get; set; }

		/// <summary>
		/// Gets or sets the number of milliseconds to wait before trying the query again.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the wait time before retrying the query.
		/// </value>
		public decimal RetryAfterMs { get; set; }

		public QueryExecutionException(ResponseException responseException) : base(responseException.Message, responseException)
		{
			StatusCode = Convert.ToInt32(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-status-code"));
			RequestCharge = Convert.ToDecimal(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-total-request-charge"));
			RetryAfterMs = Convert.ToDecimal(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-retry-after-ms"));
		}

	}

}