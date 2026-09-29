using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureItemDropRate : ConfigData<AdventureItemDropRateItem, byte>
{
	public static AdventureItemDropRate Instance = new AdventureItemDropRate();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "ItemGradeDropRate" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AdventureItemDropRateItem(0, new short[9] { 75, 20, 5, 0, 0, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(1, new short[9] { 40, 50, 10, 0, 0, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(2, new short[9] { 20, 40, 30, 10, 0, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(3, new short[9] { 0, 0, 75, 20, 5, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(4, new short[9] { 0, 0, 40, 50, 10, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(5, new short[9] { 0, 0, 20, 40, 30, 10, 0, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(6, new short[9] { 0, 0, 0, 0, 75, 20, 5, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(7, new short[9] { 0, 0, 0, 0, 40, 50, 10, 0, 0 }));
		_dataArray.Add(new AdventureItemDropRateItem(8, new short[9] { 0, 0, 0, 0, 20, 40, 30, 10, 0 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureItemDropRateItem>(9);
		CreateItems0();
	}
}
