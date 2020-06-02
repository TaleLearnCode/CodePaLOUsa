using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a postal address.
	/// </summary>
	public class PostalAddress
	{

		/// <summary>
		/// Gets or sets the identifier of the postal address.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the identifier of the document storing the postal address.
		/// </value>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the address type identifier.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the identifier of the type of address represented.
		/// </value>
		[JsonPropertyName("addressTypeId")]
		public string AddressTypeId { get; set; }

		/// <summary>
		/// Gets or sets the type of the address.
		/// </summary>
		/// <value>
		/// A <see cref="AddressType"/> representing the type of address.
		/// </value>
		[JsonPropertyName("addressType")]
		public AddressType AddressType { get; set; }

		/// <summary>
		/// Gets or sets the first line of the street address.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the first line of the street address.
		/// </value>
		[JsonPropertyName("addressLine1")]
		public string AddressLine1 { get; set; }

		/// <summary>
		/// Gets or sets the second line of the street address.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the second line of the street address.
		/// </value>		[JsonPropertyName("addressLine2")] 
		public string AddressLine2 { get; set; }

		/// <summary>
		/// Gets or sets the city where the address is located.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the city where the address is located.
		/// </value>
		[JsonPropertyName("city")]
		public string City { get; set; }

		/// <summary>
		/// Gets or sets the country division where the address is located.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the country division where the address is located.
		/// </value>
		[JsonPropertyName("countryDivision")]
		public string CountryDivision { get; set; }

		/// <summary>
		/// Gets or sets the country where the address is located.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the country where the address is located.
		/// </value>
		[JsonPropertyName("country")]
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the postal code for the address.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the address postal code.
		/// </value>
		[JsonPropertyName("postalCode")]
		public string PostalCode { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance is deleted.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
		/// </value>
		[JsonPropertyName("isDeleted")]
		public bool IsDeleted { get; }

	}

}