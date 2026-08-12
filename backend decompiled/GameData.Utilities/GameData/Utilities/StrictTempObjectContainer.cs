using System;

namespace GameData.Utilities;

public class StrictTempObjectContainer<T> : TempObjectContainerBase<T> where T : class
{
	private readonly Action<T> _reset;

	public StrictTempObjectContainer(T obj, Action<T> reset = null)
		: base(obj)
	{
		_reset = reset;
	}

	protected override void Reset(T obj)
	{
		_reset?.Invoke(obj);
	}

	protected override void Error(string errorMessage)
	{
		throw new InvalidOperationException(errorMessage);
	}
}
