using System;

namespace GameData.Domains.Building;

public class BuildingEffectValue : IBuildingEffectValue
{
	private int _value;

	public void Change(int delta)
	{
		_value += delta;
	}

	public virtual void Change(int index, int delta)
	{
		throw new NotSupportedException();
	}

	public virtual void Clear()
	{
		_value = 0;
	}

	public int Get()
	{
		return _value;
	}

	public virtual int Get(int index)
	{
		return Get();
	}

	public override string ToString()
	{
		return _value.ToString();
	}
}
