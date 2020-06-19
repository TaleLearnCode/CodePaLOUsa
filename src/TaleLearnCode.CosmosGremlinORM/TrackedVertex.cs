using System;
using System.Linq;

namespace TaleLearnCode.CosmosGremlinORM
{
	public class TrackedVertex
	{

		private VertexState _vertexState;
		private Vertex _vertex;

		private static readonly int _maxVertexState = Enum.GetValues(typeof(VertexState)).Cast<int>().Max();

		public VertexState State
		{
			get => _vertexState;
			set
			{
				if (value < 0 || (int)value > _maxVertexState)
				{
					throw new ArgumentException(ResourceStrings.InvalidEnumValue(nameof(value), typeof(VertexState)));
				}
				_vertexState = value;
			}
		}

		public Vertex Vertex
		{
			get => _vertex;
			set
			{
				if (value is null) throw new ArgumentNullException(nameof(value));
				if (!value.Equals(_vertex))
				{
					_vertex = value;
					_vertexState = VertexState.Modified;
				}
			}
		}

		internal TrackedVertex(Vertex vertex, VertexState vertexState)
		{
			_vertex = vertex;
			_vertexState = vertexState;
		}

	}
}