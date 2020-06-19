using System;
using System.Reflection;

namespace TaleLearnCode.CosmosGremlinORM
{

	/// <summary>
	/// Represent a vertex property being tracked by a <see cref="GraphContext"/>.
	/// </summary>
	public class PropertyEntry
	{

		private object _propertyValue;

		/// <summary>
		/// Gets the name of the property being tracked.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the name of the property being tracked.
		/// </value>
		public string PropertyName { get; }

		/// <summary>
		/// Gets or sets the value of the property being tracked.
		/// </summary>
		/// <value>
		/// An <c>object</c> representing the value of the property tracked.
		/// </value>
		public object PropertyValue
		{
			get => _propertyValue;
			set
			{
				if (value != _propertyValue)
				{
					_propertyValue = value;
					IsChanged = true;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the property value being tracked has been changed.
		/// </summary>
		/// <value>
		///   <c>true</c> if property value being tracked has been changed; otherwise, <c>false</c>.
		/// </value>
		public bool IsChanged { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyEntry"/> class.
		/// </summary>
		/// <param name="propertyInfo">The <see cref="PropertyInfo"/> of the property to be tracked.</param>
		/// <param name="vertex">A representation of the vertex being tracked..</param>
		/// <exception cref="ArgumentNullException">propertyInfo</exception>
		public PropertyEntry(PropertyInfo propertyInfo, object vertex)
		{
			if (propertyInfo is null) throw new ArgumentNullException(nameof(propertyInfo));
			PropertyName = propertyInfo.Name;
			PropertyValue = propertyInfo.GetValue(vertex);
		}

	}

}