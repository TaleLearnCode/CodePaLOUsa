using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a period in which sessions are scheduled.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("sessionPeriod", Description = "Represents a period in which sessions are scheduled.")]
	public class SessionPeriod : Vertex
	{

		/// <summary>
		/// Gets or sets the number of minutes past midnight the session period begins.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the number of minutes past midnight the session period begins.
		/// </value>
		[GraphProperty("startTimeOffset", Description = "The number of minutes past midnight the session period begins.")]
		public int StartTimeOffset { get; set; }

		/// <summary>
		/// Gets or sets the duration of the session period.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the number of minutes the session period runs.
		/// </value>
		[GraphProperty("duration", Description = "The number of minutes the session period runs.")]
		public int Duration { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionPeriod"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public SessionPeriod(string eventId, string name, string id = "") : base(eventId, name, id) { }

	}

}