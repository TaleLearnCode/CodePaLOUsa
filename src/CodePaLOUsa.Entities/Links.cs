using System;
using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents the set of links associated with a vertex.
	/// </summary>
	public class Links
	{

		private string? _twitter;
		private string? _linkedIn;
		private string? _blog;
		private string? _companyWebsite;
		private string? _facebook;
		private string? _instagram;
		private string? _twitch;

		/// <summary>
		/// Gets or sets the URL for the speaker's Twitter profile.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's Twitter profile.
		/// </value>
		[GraphProperty("twitter", Description = "The URl for the speaker Twitter profile.")]
		public string? Twitter
		{
			get { return _twitter; }
			set { _twitter = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL for the speaker's LinkedIn profile.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's LinkedIn profile.
		/// </value>
		[GraphProperty("linkedIn", Description = "The URL for the speaker LinkedIn profile.")]
		public string? LinkedIn
		{
			get { return _linkedIn; }
			set { _linkedIn = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL for the speaker's blog.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's blog.
		/// </value>
		[GraphProperty("blog", Description = "The URL for the speaker blog.")]
		public string? Blog
		{
			get { return _blog; }
			set { _blog = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL to the website of the speaker's company.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the of the website of the speaker's company.
		/// </value>
		[GraphProperty("companyWebsite", Description = "The URl to the website of the speakers company.")]
		public string? CompanyWebsite
		{
			get { return _companyWebsite; }
			set { _companyWebsite = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL for the speaker's Facebook profile.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's Facebook profile.
		/// </value>
		[GraphProperty("facebook", Description = "The URL for the speaker Facebook profile.")]
		public string? Facebook
		{
			get { return _facebook; }
			set { _facebook = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL for the speaker's Instagram profile.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's Instagram profile.
		/// </value>
		[GraphProperty("instagram", Description = "The URL for the speaker Instagram profile.")]
		public string? Instagram
		{
			get { return _instagram; }
			set { _instagram = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Gets or sets the URL for the speaker's Twitch profile.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the URL to the speaker's Twitch profile.
		/// </value>
		[GraphProperty("twitch", Description = "The URL for the speaker Twitch channel.")]
		public string? Twitch
		{
			get { return _twitch; }
			set { _twitch = ValidateLinkPriorToSetting(value); }
		}

		/// <summary>
		/// Facilitates validating a link prior to setting.
		/// </summary>
		/// <param name="value">The link value to validate.</param>
		/// <returns>A <c>string</c> representing the validated link.</returns>
		/// <exception cref="ArgumentException">Thrown if the link <paramref name="value"/> is not a valid link.</exception>
		private static string? ValidateLinkPriorToSetting(string? value)
		{
			if (Uri.TryCreate(value, UriKind.Absolute, out Uri? createdUri))
				return createdUri.ToString();
			else
				throw new ArgumentException("Invalid URI specified");
		}

	}

}