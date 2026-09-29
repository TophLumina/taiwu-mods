using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefLevel : ConfigData<CatchThiefLevelItem, sbyte>
{
	public static CatchThiefLevel Instance = new CatchThiefLevel();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "TemplateId", "Level", "SingPitch", "SingSize" };

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
		_dataArray.Add(new CatchThiefLevelItem(0, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_0"), 0, 60, 30));
		_dataArray.Add(new CatchThiefLevelItem(1, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_1"), 1, 50, 50));
		_dataArray.Add(new CatchThiefLevelItem(2, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_2"), 2, 45, 70));
		_dataArray.Add(new CatchThiefLevelItem(3, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_3"), 3, 40, 90));
		_dataArray.Add(new CatchThiefLevelItem(4, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_4"), 4, 35, 110));
		_dataArray.Add(new CatchThiefLevelItem(5, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_5"), 5, 30, 130));
		_dataArray.Add(new CatchThiefLevelItem(6, LocalStringManager.GetConfig("CatchThiefLevel_language", "Desc_6"), 6, 20, 150));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CatchThiefLevelItem>(7);
		CreateItems0();
	}
}
