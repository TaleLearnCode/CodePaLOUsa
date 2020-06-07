using System;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Abstract base class for vertices.
	/// </summary>
	public abstract class Vertex
	{

		/// <summary>
		/// Gets or sets the identifier of the document.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the document identifier.
		/// </value>
		[GraphProperty("id", Description = "Identifier of the document.")]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the event.  Serves as the partition key.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the event identifier.
		/// </value>
		[GraphProperty("eventId", Description = "Identifier of the event the vertex is associated with. Serves as the partition key.")]
		public string EventId { get; set; }

		/// <summary>
		/// Gets or sets the name of the vertex object.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the vertex object name.
		/// </value>
		[GraphProperty("name", Description = "The name of the vertex object.")]
		public string Name { get; set; }

		/// <summary>Initializes a new instance of the <see cref="Vertex" /> class.</summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		protected Vertex(string eventId, string name, string id = "")
		{
			Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
			EventId = eventId;
			Name = name;
		}

	}
}