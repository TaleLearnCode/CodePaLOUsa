using Gremlin.Net.Driver.Exceptions;
using System;
using System.Globalization;

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

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryExecutionException"/> class.
		/// </summary>
		public QueryExecutionException() : base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryExecutionException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public QueryExecutionException(string? message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryExecutionException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
		public QueryExecutionException(string? message, Exception? innerException) : base(message, innerException) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryExecutionException"/> class.
		/// </summary>
		/// <param name="responseException">The response exception.</param>
		/// <exception cref="System.ArgumentNullException">responseException</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "It can be assumed that there will always be an instantiated ResponseException passed in.")]
		public QueryExecutionException(ResponseException responseException) : base(responseException.Message, responseException)
		{
			if (responseException is null) throw new ArgumentNullException(nameof(responseException));
			StatusCode = Convert.ToInt32(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-status-code"), NumberFormatInfo.InvariantInfo);
			RequestCharge = Convert.ToDecimal(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-total-request-charge"), NumberFormatInfo.InvariantInfo);
			RetryAfterMs = Convert.ToDecimal(GremlinQuery.GetValueAsString(responseException.StatusAttributes, "x-ms-retry-after-ms"), NumberFormatInfo.InvariantInfo);
		}

	}

}
