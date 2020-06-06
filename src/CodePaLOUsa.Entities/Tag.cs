using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a tag for sessions and such.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("Tag")]
	public class Tag : Vertex
	{

		/// <summary>Initializes a new instance of the <see cref="Tag" /> class.</summary>
		/// <param name="eventId">Identifier of the event (used as the partition key)</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public Tag(string eventId, string name, string id) : base(eventId, name, id)
		{
		}

	}

}