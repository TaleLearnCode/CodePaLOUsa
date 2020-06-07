using System;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a speaker at an event.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("speaker", Description = "A speaker at an event.")]
	public class Speaker : Vertex
	{

		/// <summary>
		/// Gets or sets the speaker's first name.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the first name of the speaker.
		/// </value>
		[GraphProperty("firstName", Description = "The first name of the speaker.")]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the speaker's last name.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the last name of the speaker.
		/// </value>
		[GraphProperty("lastName", Description = "The last name of the speaker.")]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the biography of the speaker.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the speaker's biography.
		/// </value>
		[GraphProperty("biography", Description = "The biography for the speaker.")]
		public string Biography { get; set; }

		/// <summary>
		/// Gets or sets the tagline for speaker.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the speaker's tagline.
		/// </value>
		[GraphProperty("tagline", Description = "The tagline for the speaker.")]
		public string Tagline { get; set; }

		/// <summary>
		/// Gets or sets the URI for the speaker's photo.
		/// </summary>
		/// <value>
		/// A <see cref="Uri"/> representing the URI to the speaker's photo.
		/// </value>
		[GraphProperty("photo", Description = "The URI for the speaker photo.")]
		public Uri Photo { get; set; }

		/// <summary>
		/// Gets or sets the links associated with the speaker.
		/// </summary>
		/// <value>
		/// A <see cref="Links"/> representing the links associated with the speaker.
		/// </value>
		public Links Links { get; set; }

		/// <summary>Initializes a new instance of the <see cref="Speaker" /> class.</summary>
		/// <param name="firstName">The first name of the speaker.</param>
		/// <param name="lastName">The last name of the speaker.</param>
		/// <param name="biography">The biography of the speaker.</param>
		/// <param name="tagline">The speaker's tagline.</param>
		/// <param name="photo">The link to the speaker's photo.</param>
		/// <param name="links">The links associated with the speaker.</param>
		public Speaker(string eventId, string name, string firstName, string lastName, string biography, string tagline, Uri photo, Links links, string id = "") : base(eventId, name, id)
		{
			FirstName = firstName;
			LastName = lastName;
			Biography = biography;
			Tagline = tagline;
			Photo = photo;
			Links = links;
		}

	}

}