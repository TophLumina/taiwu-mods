using System;

namespace GameData.ActionPlanning.State;

public interface IStateKey<T> : IEquatable<T>
{
	bool IsSubStateOf(T other);
}
