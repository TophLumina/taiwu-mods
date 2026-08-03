using System;

namespace GameData.Common.Algorithm;

public interface IAStarPos<T> : IEquatable<T> where T : IAStarPos<T>
{
	int GetManhattanDistance(T other);
}
