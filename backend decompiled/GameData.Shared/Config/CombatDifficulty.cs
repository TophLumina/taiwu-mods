using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class CombatDifficulty : ConfigData<CombatDifficultyItem, byte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatDifficulty Instance = new CombatDifficulty();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "TemplateId", "HitValues", "Penetrations", "AvoidValues", "PenetrationResists", "RecoveryOfStanceAndBreath", "MoveSpeed", "RecoveryOfFlaw", "CastSpeed",
		"RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed", "AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "ExtraCombatSkillGrids"
	};

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
		_dataArray.Add(new CombatDifficultyItem(0, LocalStringManager.GetConfig("CombatDifficulty_language", "Name_0"), 25, 25, 25, 25, new OuterAndInnerShorts(50, 50), 50, 50, 50, 50, 50, 50, 50, 50, 0));
		_dataArray.Add(new CombatDifficultyItem(1, LocalStringManager.GetConfig("CombatDifficulty_language", "Name_1"), 100, 100, 100, 100, new OuterAndInnerShorts(100, 100), 100, 100, 100, 100, 100, 100, 100, 100, 50));
		_dataArray.Add(new CombatDifficultyItem(2, LocalStringManager.GetConfig("CombatDifficulty_language", "Name_2"), 125, 150, 125, 150, new OuterAndInnerShorts(125, 125), 125, 125, 125, 125, 125, 125, 125, 125, 100));
		_dataArray.Add(new CombatDifficultyItem(3, LocalStringManager.GetConfig("CombatDifficulty_language", "Name_3"), 150, 200, 150, 200, new OuterAndInnerShorts(150, 150), 150, 150, 150, 150, 150, 150, 150, 150, 200));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatDifficultyItem>(4);
		CreateItems0();
	}
}
