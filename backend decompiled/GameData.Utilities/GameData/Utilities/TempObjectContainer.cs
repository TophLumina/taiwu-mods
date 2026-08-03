using System;

namespace GameData.Utilities;

public class TempObjectContainer<T> : TempObjectContainerBase<T> where T : class, new()
{
	private readonly Action<T> _reset;

	public TempObjectContainer(Action<T> reset = null)
		: base(new T())
	{
		_reset = reset;
	}

	public TempObjectContainer(T obj, Action<T> reset = null)
		: base(obj)
	{
		_reset = reset;
	}

	protected override void Reset(T obj)
	{
		_reset?.Invoke(obj);
	}

	protected override T GetFallbackObject()
	{
		return new T();
	}
}
