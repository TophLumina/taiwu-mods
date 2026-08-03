using System.Collections.Generic;

namespace GameData.Domains.Building;

public class BuildingEffectGroupValue : BuildingEffectValue
{
	private readonly BuildingEffectValue[] _group;

	public BuildingEffectGroupValue(int count)
	{
		_group = new BuildingEffectValue[count];
		for (int i = 0; i < count; i++)
		{
			_group[i] = new BuildingEffectValue();
		}
	}

	public override int Get(int index)
	{
		return Get() + _group[index].Get();
	}

	public override void Change(int index, int delta)
	{
		_group[index].Change(delta);
	}

	public override void Clear()
	{
		base.Clear();
		for (int i = 0; i < _group.Length; i++)
		{
			_group[i].Clear();
		}
	}

	public override string ToString()
	{
		return $"{Get()}, {{{string.Join(',', (IEnumerable<BuildingEffectValue>)_group)}}}";
	}
}
