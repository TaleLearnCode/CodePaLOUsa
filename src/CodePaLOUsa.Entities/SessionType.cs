using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a type of session.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	public class SessionType : SortedLookupType
	{

		/// <summary>
		/// Gets or sets the length of the session.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the session length in minutes.
		/// </value>
		[GraphProperty("sessionLength")]
		public int SessionLength { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether sessions of this type are shown on schedule.
		/// </summary>
		/// <value>
		///   <c>true</c> if sessions are shown on schedule; otherwise, <c>false</c>.
		/// </value>
		[GraphProperty("showOnSchedule")]
		public bool ShowOnSchedule { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the room among the other rooms.</param>
		public SessionType(string eventId, string name, int sortOrder, string id = "") : base(eventId, name, sortOrder, id)
		{
			SortOrder = sortOrder;
		}

	}

}