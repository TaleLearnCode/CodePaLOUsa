using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Abstract base class for sorted lookup types.
	/// </summary>
	/// <seealso cref="Vertex" />
	public abstract class SortedLookupType : Vertex
	{

		/// <summary>
		/// Gets the sort order.
		/// </summary>
		/// <value>
		/// A <see cref="int"/> representing the sort order of the item within the complete list.
		/// </value>
		[GraphProperty("sortOrder", Description = "The sort order of the vertex in relation to the other vertices with the same label")]
		public int SortOrder { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SortedLookupType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the lookup value amongst the other lookup values of the same type.</param>
		public SortedLookupType(string eventId, string name, int sortOrder, string id = "") : base(eventId, name, id)
		{
			SortOrder = sortOrder;
		}

	}

}