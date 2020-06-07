using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Defines the level of a session.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	[Vertex("sessionLevel", Description = "Defines the level of a session.")]
	public class SessionLevel : SessionizeSortedLookupType
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionLevel"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the room among the other rooms.</param>
		public SessionLevel(string eventId, string name, int sortOrder, string id = "", string sessionizeId = "") : base(eventId, name, sortOrder, id, sessionizeId) { }

	}

}