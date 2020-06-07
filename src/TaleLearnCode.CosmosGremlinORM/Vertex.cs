using System;
using System.Globalization;
using System.Text;

namespace TaleLearnCode.CosmosGremlinORM
{
	public abstract class Vertex
	{

		/// <summary>
		/// Gets or sets the identifier of the vertex document.
		/// </summary>
		/// <value>
		/// A <c>string</c> representing the vertex document identifier.
		/// </value>
		[GraphProperty("id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		// TODO: Add a construct for handling the partition key
		// TODO: Add back nullable checks

		public static string Save<T>(T objectToSave)
		{
			return GetAddVertexGremlin<T>(objectToSave);
		}

		public static string GetAddVertexGremlin<T>(T testValue)
		{
			VertexAttribute vertexAttribute = (VertexAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(VertexAttribute));

			if (vertexAttribute != default)
			{
				var gremlin = new StringBuilder($"g.addV('{(vertexAttribute != null && (!string.IsNullOrWhiteSpace(vertexAttribute.Label)) ? vertexAttribute.Label : typeof(T).Name)}')");

				foreach (var property in typeof(T).GetProperties())
				{
					if (property.GetValue(testValue) != default && IsValidType(property.PropertyType))
					{
						string key = property.Name;
						var propertyAttibutes = property.GetCustomAttributes(true);
						if (propertyAttibutes.Length > 0)
							foreach (var propertyAttribute in propertyAttibutes)
							{
								if (propertyAttribute.GetType() == typeof(GraphPropertyAttribute))
								{
									var graphPropertyAttribute = (GraphPropertyAttribute)Attribute.GetCustomAttribute(property, typeof(GraphPropertyAttribute), true);
									key = (string.IsNullOrWhiteSpace(graphPropertyAttribute.Key)) ? CasedString(property.Name, vertexAttribute.PropertyNamingPolicy) : graphPropertyAttribute.Key;
								}
							}

						if (property.PropertyType == typeof(bool))
							gremlin.Append($".property('{key}', {property.GetValue(testValue).ToString().ToLower(CultureInfo.InvariantCulture)})");
						else
						{
							var isNumeric = CheckAndGetNumber(property.GetValue(testValue));
							if (isNumeric.Item1)
								gremlin.Append($".property('{key}', {isNumeric.Item2})");
							else
								gremlin.Append($".property('{key}', '{property.GetValue(testValue)}')");
						}

					}
				}

				return gremlin.ToString();

			}

			return string.Empty;
		}

		public static string CasedString(string input, PropertyNamingPolicy propertyNamingPolicy)
		{
			if (!string.IsNullOrWhiteSpace(input))
				switch (propertyNamingPolicy)
				{
					case PropertyNamingPolicy.CamelCase:
						input = char.ToLower(input[0], CultureInfo.InvariantCulture) + input.Substring(1);
						break;
					case PropertyNamingPolicy.PascalCase:
						input = char.ToUpper(input[0], CultureInfo.InvariantCulture) + input.Substring(1);
						break;
					default:
						break;
				}
			return input;
		}

		private static Tuple<bool, string> CheckAndGetNumber(object testValue)
		{

			var returnValue = new Tuple<bool, string>(false, string.Empty);
			bool isFloat = float.TryParse(testValue.ToString(), out var floatNumber);
			if (isFloat)
			{
				bool isLong = long.TryParse(testValue.ToString(), out var longNumber);
				if (isLong)
					returnValue = new Tuple<bool, string>(true, longNumber.ToString());
				else
					returnValue = new Tuple<bool, string>(true, floatNumber.ToString());
			}

			bool isDecimal = decimal.TryParse(testValue.ToString(), out var decimalNumber);
			if (isDecimal)
				returnValue = new Tuple<bool, string>(true, decimalNumber.ToString());

			return returnValue;

		}

		private static bool IsValidType(Type type)
		{
			// TODO: Look at a better of figuring out what is a valid type
			if (type.IsPrimitive)
				return true;
			else if (type == typeof(string))
				return true;
			else if (type == typeof(DateTime))
				return true;
			else if (type == typeof(Uri))
				return true;
			else
				return false;
		}

	}

}