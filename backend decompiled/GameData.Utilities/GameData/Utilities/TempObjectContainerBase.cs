using System.Diagnostics;

namespace GameData.Utilities;

public abstract class TempObjectContainerBase<T> : ITempObjectContainer where T : class
{
	protected readonly T Obj;

	private bool _locked;

	public bool IsLocked => _locked;

	protected TempObjectContainerBase(T obj)
	{
		Obj = obj;
		_locked = false;
	}

	public T Occupy()
	{
		if (_locked)
		{
			Error("Object in use already.");
			return GetFallbackObject();
		}
		_locked = true;
		return Obj;
	}

	public T Get()
	{
		if (_locked)
		{
			return Obj;
		}
		Error("Trying to access a object that is not occupied.");
		return GetFallbackObject();
	}

	public void Release(ref T obj)
	{
		if (!_locked)
		{
			Error("Releasing object when it's not in use.");
		}
		if (obj != Obj)
		{
			Error("Releasing object from different source.");
			return;
		}
		_locked = false;
		Reset(obj);
		obj = null;
	}

	protected abstract void Reset(T obj);

	protected virtual T GetFallbackObject()
	{
		return Obj;
	}

	protected virtual void Error(string errorMessage)
	{
		AdaptableLog.TagWarning("TempObjectContainer", $"{errorMessage}\n{new StackTrace()}");
	}
}
