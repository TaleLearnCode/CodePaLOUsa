using System;
using System.Collections.Generic;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents the details of an event.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("Event")]
	public class EventDetail : Vertex
	{

		/// <summary>
		/// Gets or sets the "about" information for the event.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the about information for the event.
		/// </value>
		[GraphProperty("about")]
		public string About { get; set; }

		/// <summary>
		/// Gets or sets the date the event starts.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> representing the date the event starts.
		/// </value>
		[GraphProperty("startDate")]
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the date the event ends.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> representing the date the event ends.
		/// </value>
		[GraphProperty("endDate")]
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the schedule has been released.
		/// </summary>
		/// <value>
		///   <c>true</c> if the schedule has been released; otherwise, <c>false</c>.
		/// </value>
		[GraphProperty("scheduleReleased")]
		public bool ScheduleReleased { get; set; }

		/// <summary>
		/// Gets or sets the URL of the registration site.
		/// </summary>
		/// <value>
		/// A <see cref="Uri"/> representing the registration site URL.
		/// </value>
		[GraphProperty("registrationSiteUrl")]
		public Uri RegistrationSiteUrl { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this event is the current event for the organization.
		/// </summary>
		/// <value>
		///   <c>true</c> if this event is the current event for the organization; otherwise, <c>false</c>.
		/// </value>
		[GraphProperty("isCurrentEvent")]
		public bool IsCurrentEvent { get; set; }

		/// <summary>
		/// Gets the collection of EventDays for the event.
		/// </summary>
		/// <value>
		/// A <see cref="List{EventDay}"/> representing the event days for the event.
		/// </value>
		[GraphProperty("eventDays", IncludeInGraph = false)]
		public List<EventDay> EventDays { get; } = new List<EventDay>();

		/// <summary>
		/// Initializes a new instance of the <see cref="EventDetail"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="about">The "about" information for the event.</param>
		/// <param name="registrationSiteUrl">The URL of the registration site.</param>
		public EventDetail(string eventId, string name, string about, Uri registrationSiteUrl, string id = "") : base(eventId, name, id)
		{
			About = about;
			RegistrationSiteUrl = registrationSiteUrl;
		}

	}

}