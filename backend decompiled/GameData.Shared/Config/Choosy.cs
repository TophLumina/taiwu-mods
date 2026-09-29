using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Choosy : ConfigData<ChoosyItem, short>
{
	public static Choosy Instance = new Choosy();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "LifeSkillType", "TemplateId", "BaseUpgradeRate", "MaxUpgradeRate", "BaseUpgradeCount", "MaxUpgradeCount", "GradeList", "AttainmentRate", "UpgradeRateAttainmentBonus", "UpgradeCountAttainmentBonus" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new ChoosyItem(0, 2000, 6000, 20000, 60000, new List<short> { 0, 1, 2, 3, 4, 5, 6 }, 10, 2, 12, 14));
		_dataArray.Add(new ChoosyItem(1, 2000, 6000, 20000, 60000, new List<short> { 1, 2, 3, 4, 5, 6, 7 }, 10, 2, 12, 7));
		_dataArray.Add(new ChoosyItem(2, 2000, 6000, 20000, 60000, new List<short> { 1, 2, 3, 4, 5, 6, 7 }, 10, 2, 12, 6));
		_dataArray.Add(new ChoosyItem(3, 2000, 6000, 20000, 60000, new List<short> { 1, 2, 3, 4, 5, 6, 7 }, 10, 2, 12, 11));
		_dataArray.Add(new ChoosyItem(4, 2000, 6000, 20000, 60000, new List<short> { 1, 2, 3, 4, 5, 6, 7 }, 10, 2, 12, 10));
		_dataArray.Add(new ChoosyItem(5, 1000, 3000, 10000, 30000, new List<short> { 1, 3, 5, 7 }, 10, 1, 12, 8));
		_dataArray.Add(new ChoosyItem(6, 2000, 6000, 20000, 60000, new List<short> { 1, 2, 3, 4, 5, 6, 7 }, 10, 2, 12, 9));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ChoosyItem>(7);
		CreateItems0();
	}
}
