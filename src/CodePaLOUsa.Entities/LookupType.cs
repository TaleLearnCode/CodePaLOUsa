using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Base class for lookup types within the application.
	/// </summary>
	public abstract class LookupType
	{

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// A <see cref="string"/> representing the identifier for the lookup type.
		/// </value>
		[JsonPropertyName("id")]
		public string Id { get; }

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>
		/// A <see cref="string"/> representing the name.
		/// </value>
		[JsonPropertyName("name")]
		public string Name { get; }

		/// <summary>
		/// Gets the sort order.
		/// </summary>
		/// <value>
		/// A <see cref="int"/> representing the sort order of the item within the complete list.
		/// </value>
		[JsonPropertyName("sortOrder")]
		public int SortOrder { get; }

	}

}