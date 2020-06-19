namespace TaleLearnCode.CosmosGremlinORM
{
	public static class ResourceStrings
	{

		// TODO: Update logic to use resource manager

		public static string InvalidEnumValue(object argumentName, object enumType)
		{
			return string.Format("The value provided for argument '{0}' must be a valid value of enum type '{1}'.", nameof(argumentName), nameof(enumType));
		}

		public static string VertexNotInChagneTrackerException() => "Vertex is not in the change tracker; unable to continue.";


	}

}