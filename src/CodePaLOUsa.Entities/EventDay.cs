using System;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Provides information about an event day.
	/// </summary>
	/// <seealso cref="Vertex" />
	[Vertex("eventDay", Description = "Provides information \"about\" an event day.")]
	public class EventDay : Vertex
	{

		/// <summary>
		/// Gets or sets the date of the event day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> representing the date of the event day.
		/// </value>
		[GraphProperty("name", Description = "The date of the event day.")]
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the start time offset.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the time offset for the start of the day.
		/// </value>
		/// <remarks>The offset is the number of minutes since midnight of the <see cref="Date"/>.</remarks>
		[GraphProperty("startTimeOffset", Description = "The start time of the day represented by the number of minutes past midnight of the event day date.")]
		public int StartTimeOffset { get; set; }

		/// <summary>
		/// Gets the start time of the day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> that represents the start of the day.
		/// </value>
		[GraphProperty("startTime", IncludeInGraph = false)]
		public DateTime StartTime { get { return Date.Date.AddMinutes(StartTimeOffset); } }

		/// <summary>
		/// Gets or sets the end time offset.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the time offset for the end of the day.
		/// </value>
		/// <remarks>The offset is the number of minutes since midnight of the <see cref="Date"/>.</remarks>
		[GraphProperty("endTimeOffset", Description = "The end time of the day represented by the number of minutes past midnight of the event day.")]
		public int EndTimeOffset { get; set; }

		/// <summary>
		/// Gets the end time of the day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> that represents the end of the day.
		/// </value>
		[GraphProperty("endTime", IncludeInGraph = false)]
		public DateTime EndTime { get { return Date.Date.AddMinutes(EndTimeOffset); } }

		/// <summary>
		/// Initializes a new instance of the <see cref="EventDay"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		public EventDay(string eventId, string name, string id = "") : base(eventId, name, id) { }

	}

}