using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a tag for sessions and such.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("tag", Description = "A tag for sessions and such.")]
	public class Tag : Vertex
	{

		/// <summary>
		/// Gets or sets the Sessionize identifier for the Tag.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the identifier of the Tag within Sessionize.
		/// </value>
		[GraphProperty("sessionizeId", Description = "The Sessionize identifier for the Tag.")]
		public string SessionizeId { get; set; }

		/// <summary>Initializes a new instance of the <see cref="Tag" /> class.</summary>
		/// <param name="eventId">Identifier of the event (used as the partition key)</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="sessionizeId">Identifier of the tag within Sessionize.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public Tag(string eventId, string name, string sessionizeId = "", string id = "") : base(eventId, name, id)
		{
			SessionizeId = string.IsNullOrWhiteSpace(sessionizeId) ? string.Empty : sessionizeId;
		}

	}

}