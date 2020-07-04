using System;

namespace TaleLearnCode.CosmosGremlinORM
{

	public abstract class Vertex
	{

		/// <summary>
		/// Gets or sets the identifier of the vertex.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the vertex identifier within Cosmos.
		/// </value>
		[GraphProperty("id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// Gets or sets the label of the vertex.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the vertex label.
		/// </value>
		/// <remarks>The vertex label defines the type of object being stored.</remarks>
		public string Label { get; set; }

		/// <summary>
		/// Gets or sets the partition key for the vertex.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the name of the property withing the vertex used as the partition key.
		/// </value>
		public string PartitionKey { get; set; }

	}

}