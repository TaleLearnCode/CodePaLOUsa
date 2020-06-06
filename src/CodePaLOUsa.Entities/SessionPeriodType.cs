using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Defines the type a session period is.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	[Vertex("SessionPeriodType")]
	public class SessionPeriodType : SortedLookupType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SessionPeriodType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the room among the other rooms.</param>
		public SessionPeriodType(string eventId, string name, int sortOrder, string id = "") : base(eventId, name, sortOrder, id)
		{
			SortOrder = sortOrder;
		}
	}

}