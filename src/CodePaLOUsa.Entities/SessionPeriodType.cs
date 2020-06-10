using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Defines the type a session period is.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	[Vertex("sessionPeriodType", Description = "Defines the type a session period is.")]
	public class SessionPeriodType : Vertex
	{

		/// <summary>
		/// Gets or sets a value indicating whether to include the session period type in a selection list.
		/// </summary>
		/// <value>
		///   <c>true</c> if the session period type should be included in selection lists; otherwise, <c>false</c>.
		/// </value>
		public bool IncludeInSelectionList { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionPeriodType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public SessionPeriodType(string eventId, string name, string id = "") : base(eventId, name, id)
		{

		}
	}

}