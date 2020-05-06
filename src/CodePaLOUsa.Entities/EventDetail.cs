using System;
using System.Collections.Generic;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents the details of an event.
	/// </summary>
	public class EventDetail
	{

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the name of the event.
		/// </value>
		public string Name { get; set; }

		public string Tagline { get; set; }

		public string About { get; set; }

		public string LocationName { get; set; }

		public string LocationAddressId { get; set; }

		public PostalAddress Location { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public List<EventDay> EventDays { get; } = new List<EventDay>();

		public bool ScheduleReleased { get; set; }

		public Uri RegistrationSiteUrl { get; set; }

		public bool IsCurrentEvent { get; set; }

	}

}