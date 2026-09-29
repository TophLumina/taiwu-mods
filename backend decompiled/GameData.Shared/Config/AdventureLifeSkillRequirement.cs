using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureLifeSkillRequirement : ConfigData<AdventureLifeSkillRequirementItem, byte>
{
	public static AdventureLifeSkillRequirement Instance = new AdventureLifeSkillRequirement();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "RequiredValue" };

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
		_dataArray.Add(new AdventureLifeSkillRequirementItem(0, 0, 0));
		_dataArray.Add(new AdventureLifeSkillRequirementItem(1, 20, 15));
		_dataArray.Add(new AdventureLifeSkillRequirementItem(2, 30, 30));
		_dataArray.Add(new AdventureLifeSkillRequirementItem(3, 40, 60));
		_dataArray.Add(new AdventureLifeSkillRequirementItem(4, 50, 30));
		_dataArray.Add(new AdventureLifeSkillRequirementItem(5, 60, 15));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureLifeSkillRequirementItem>(6);
		CreateItems0();
	}
}
