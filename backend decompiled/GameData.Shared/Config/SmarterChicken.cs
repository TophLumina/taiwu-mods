using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SmarterChicken : ConfigData<SmarterChickenItem, short>
{
	public static SmarterChicken Instance = new SmarterChicken();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "PersonalityType", "CharacterMale", "CharacterFemale", "CharacterFeature", "FeatherMaterialId", "TemplateId" };

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
		_dataArray.Add(new SmarterChickenItem(0, 0, 1294, 1295, 909, 343));
		_dataArray.Add(new SmarterChickenItem(1, 1, 1298, 1299, 910, 344));
		_dataArray.Add(new SmarterChickenItem(2, 2, 1292, 1293, 911, 345));
		_dataArray.Add(new SmarterChickenItem(3, 3, 1290, 1291, 912, 346));
		_dataArray.Add(new SmarterChickenItem(4, 4, 1296, 1297, 913, 347));
		_dataArray.Add(new SmarterChickenItem(5, 5, 1300, 1301, 914, 348));
		_dataArray.Add(new SmarterChickenItem(6, 6, 1302, 1303, 915, 349));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SmarterChickenItem>(7);
		CreateItems0();
	}
}
