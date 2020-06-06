﻿using TaleLearnCode.CosmosGremlinORM;

namespace CodePaLOUsa.Entities
{

	/// <summary>
	/// Represents a "room" where a session is presented.
	/// </summary>
	/// <seealso cref="SortedLookupType" />
	[Vertex("Room")]
	public class Room : SortedLookupType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Room"/> class.
		/// </summary>
		/// <param name="eventId">Identifier of the event (used as the partition key).</param>
		/// <param name="name">The name of the vertex subject.</param>
		/// <param name="id">The identifier of the vertex document.</param>
		/// <param name="sortOrder">The sort of the room among the other rooms.</param>
		public Room(string eventId, string name, int sortOrder, string id = "") : base(eventId, name, sortOrder, id)
		{
			SortOrder = sortOrder;
		}
	}

}