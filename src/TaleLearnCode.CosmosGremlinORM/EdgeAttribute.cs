using System;

namespace TaleLearnCode.CosmosGremlinORM
{

	[AttributeUsage(AttributeTargets.Property)]
	public class EdgeAttribute : Attribute
	{

		/// <summary>
		/// Gets or sets the type of the origin vertex.
		/// </summary>
		/// <value>
		/// A <see cref="Type"/> representing the edge origin vertex.
		/// </value>
		public Type Origin { get; set; }

		//		
		/// <summary>
		/// Gets or sets the type of the destination vertex.
		/// </summary>
		/// <value>
		/// A <see cref="Type"/> representing the edge destination vertex.
		/// </value>
		public Type Destination { get; set; }

		/// <summary>
		/// Gets or sets the name of the edge label.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the edge label name.
		/// </value>
		public string Label { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EdgeAttribute"/> class.
		/// </summary>
		/// <param name="origin">Type of the edge origin vertex.</param>
		/// <param name="destination">Type of the edge destination vertex.</param>
		/// <param name="label">The label of the edge..</param>
		public EdgeAttribute(Type origin, Type destination, string label)
		{
			Origin = origin;
			Destination = destination;
			Label = label;
		}

	}

}