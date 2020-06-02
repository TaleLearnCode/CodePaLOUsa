using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Provides information about an event day.
	/// </summary>
	public class EventDay
	{

		/// <summary>
		/// Gets or sets the identifier of the document.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the document identifier.
		/// </value>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the date of the event day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> representing the date of the event day.
		/// </value>
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the start time offset.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the time offset for the start of the day.
		/// </value>
		/// <remarks>The offset is the number of minutes since midnight of the <see cref="Date"/>.</remarks>
		[JsonPropertyName("startTimeOffset")]
		public int StartTimeOffset { get; set; }

		/// <summary>
		/// Gets the start time of the day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> that represents the start of the day.
		/// </value>
		[JsonPropertyName("startTime")]
		public DateTime StartTime { get; }

		/// <summary>
		/// Gets or sets the end time offset.
		/// </summary>
		/// <value>
		/// A <c>int</c> representing the time offset for the end of the day.
		/// </value>
		/// <remarks>The offset is the number of minutes since midnight of the <see cref="Date"/>.</remarks>
		[JsonPropertyName("endTimeOffset")]
		public int EndTimeOffset { get; set; }

		/// <summary>
		/// Gets the end time of the day.
		/// </summary>
		/// <value>
		/// A <c>DateTime</c> that represents the end of the day.
		/// </value>
		[JsonPropertyName("endTime")]
		public DateTime EndTime { get; }

		/// <summary>
		/// Gets or sets the title for the day.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the title for the day.
		/// </value>
		[JsonPropertyName("title")]
		public string Title { get; set; }

	}

}