using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGameLevel : ConfigData<JieqingGameLevelItem, short>
{
	public static JieqingGameLevel Instance = new JieqingGameLevel();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "SingPitch" };

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
		_dataArray.Add(new JieqingGameLevelItem(0, 1));
		_dataArray.Add(new JieqingGameLevelItem(1, 3));
		_dataArray.Add(new JieqingGameLevelItem(2, 6));
		_dataArray.Add(new JieqingGameLevelItem(3, 9));
		_dataArray.Add(new JieqingGameLevelItem(4, 12));
		_dataArray.Add(new JieqingGameLevelItem(5, 16));
		_dataArray.Add(new JieqingGameLevelItem(6, 20));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JieqingGameLevelItem>(7);
		CreateItems0();
	}
}
