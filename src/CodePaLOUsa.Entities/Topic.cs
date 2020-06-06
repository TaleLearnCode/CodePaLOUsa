using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Defines the overall topic covered by a session.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("Topic")]
	public class Topic : Vertex
	{

		/// <summary>Initializes a new instance of the <see cref="Topic" /> class.</summary>
		/// <param name="eventId">Identifier of the event (used as the partition key)</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public Topic(string eventId, string name, string id) : base(eventId, name, id)
		{
		}

	}

}