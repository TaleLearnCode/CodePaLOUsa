using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a session within the event.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("Session")]
	public class Session : Vertex
	{

		/// <summary>
		/// Gets or sets the shortened name of the session.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the short version of the session name.
		/// </value>
		[GraphProperty("shortName")]
		public string? ShortName { get; set; }

		/// <summary>
		/// Gets or sets the description of the session (abstract).
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the session description.
		/// </value>
		[GraphProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the short description of the session.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the shortened version of the session description.
		/// </value>
		[GraphProperty("shortDescription")]
		public string? ShortDescription { get; set; }

		/// <summary>
		/// Gets or sets the prerequisites for the session.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the items required prior to attending the session.
		/// </value>
		[GraphProperty("prerequisites")]
		public string? Prerequisites { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Session"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key)</param>
		/// <param name="name">The name of the vertex subject.</param>
		public Session(string eventId, string name, string description) : base(eventId, name)
		{
			Description = description;
		}

		/// <summary>Initializes a new instance of the <see cref="Session" /> class.</summary>
		/// <param name="eventId">Identifier of the event (used as the partition key)</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		protected Session(string eventId, string name, string description, string id) : base(eventId, name, id)
		{
			Description = description;
		}

	}

}