using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{
	public abstract class SessionizeSortedLookupType : SortedLookupType
	{

		/// <summary>
		/// Gets or sets the Sessionize identifier for the lookup type.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the identifier for the lookup type within Sessionize.
		/// </value>
		[GraphProperty("sessionizeId")]
		public string SessionizeId { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionizeSortedLookupType"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="sortOrder">The sort of the lookup value amongst the other lookup values of the same type.</param>
		/// <param name="sessionizeId">Identifier of the lookup type within Sessionize.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public SessionizeSortedLookupType(string eventId, string name, int sortOrder, string sessionizeId = "", string id = "") : base(eventId, name, sortOrder, id)
		{
			SessionizeId = string.IsNullOrWhiteSpace(sessionizeId) ? string.Empty : sessionizeId;
		}

	}
}
