using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a type of session.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	[Vertex("sessionType", Description = "Represents a type of session.")]
	public class SessionType : SessionizeSortedLookupType
	{

		// TODO: Add a way to split a session length into multiple parts (full-day workshop into 2 segments)

		/// <summary>
		/// Gets or sets the length of the session.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the session length in minutes.
		/// </value>
		[GraphProperty("sessionLength", Description = "The length of sessions within the session type.")]
		public int SessionLength { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether sessions of this type are shown on schedule.
		/// </summary>
		/// <value>
		///   <c>true</c> if sessions are shown on schedule; otherwise, <c>false</c>.
		/// </value>
		[GraphProperty("showOnSchedule", Description = "Flag indicating whether sessions of this type are displayed on the schedule.")]
		public bool ShowOnSchedule { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the room among the other rooms.</param>
		public SessionType(string eventId, string name, int sortOrder, string id = "", string sessionizeId = "") : base(eventId, name, sortOrder, id, sessionizeId) { }

	}

}