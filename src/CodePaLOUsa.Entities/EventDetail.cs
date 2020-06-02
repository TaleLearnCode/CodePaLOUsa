using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents the details of an event.
	/// </summary>
	public class EventDetail
	{

		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the name of the event.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the tagline for the event.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the event tagline.
		/// </value>
		public string Tagline { get; set; }

		/// <summary>
		/// Gets or sets the "about" information for the event.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the about information for the event.
		/// </value>
		public string About { get; set; }

		/// <summary>
		/// Gets or sets the name of the primary location where the event is taking place.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the primary location for the event.
		/// </value>
		public string LocationName { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the document representing the address of the primary location.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the primary address document identifier.
		/// </value>
		public string LocationAddressId { get; set; }

		/// <summary>
		/// Gets or sets the postal address for the event primary location.
		/// </summary>
		/// <value>
		/// A <see cref="PostalAddress"/> representing the event primary location.
		/// </value>
		public PostalAddress Location { get; set; }

		/// <summary>
		/// Gets or sets the start date for the event.
		/// </summary>
		/// <value>
		/// A <see cref="DateTime"/> representing the start date for the event.
		/// </value>
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public List<EventDay> EventDays { get; } = new List<EventDay>();

		public bool ScheduleReleased { get; set; }

		public Uri RegistrationSiteUrl { get; set; }

		public bool IsCurrentEvent { get; set; }

	}

}