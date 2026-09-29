using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class NeiliAllocationEffect : ConfigData<NeiliAllocationEffectItem, sbyte>
{
	public static NeiliAllocationEffect Instance = new NeiliAllocationEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new NeiliAllocationEffectItem(0, new HitOrAvoidShorts(1, 6, 3, 3), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(1, 1), new OuterAndInnerShorts(0, 0), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 5, 0, 5, 0, new PoisonShorts(2, 0, 0, 0, 0, 0)));
		_dataArray.Add(new NeiliAllocationEffectItem(1, new HitOrAvoidShorts(6, 3, 1, 3), new HitOrAvoidShorts(3, 6, 1, 3), new OuterAndInnerShorts(3, 6), new OuterAndInnerShorts(3, 6), new OuterAndInnerShorts(5, 0), 5, 0, 0, 0, 0, 5, 0, 0, new PoisonShorts(0, 2, 0, 0, 0, 0)));
		_dataArray.Add(new NeiliAllocationEffectItem(2, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new HitOrAvoidShorts(1, 3, 6, 3), new OuterAndInnerShorts(0, 0), new OuterAndInnerShorts(1, 1), new OuterAndInnerShorts(0, 0), 0, 5, 0, 5, 0, 0, 0, 0, new PoisonShorts(0, 0, 2, 2, 0, 0)));
		_dataArray.Add(new NeiliAllocationEffectItem(3, new HitOrAvoidShorts(3, 1, 6, 3), new HitOrAvoidShorts(6, 1, 3, 3), new OuterAndInnerShorts(6, 3), new OuterAndInnerShorts(6, 3), new OuterAndInnerShorts(0, 5), 0, 0, 5, 0, 0, 0, 0, 5, new PoisonShorts(0, 0, 0, 0, 2, 2)));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<NeiliAllocationEffectItem>(4);
		CreateItems0();
	}
}
