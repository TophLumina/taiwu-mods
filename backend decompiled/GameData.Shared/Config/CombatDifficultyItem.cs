using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class CombatDifficultyItem : ConfigItem<CombatDifficultyItem, byte>
{
	public readonly byte TemplateId;

	public readonly string Name;

	public readonly short HitValues;

	public readonly short Penetrations;

	public readonly short AvoidValues;

	public readonly short PenetrationResists;

	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	public readonly short MoveSpeed;

	public readonly short RecoveryOfFlaw;

	public readonly short CastSpeed;

	public readonly short RecoveryOfBlockedAcupoint;

	public readonly short WeaponSwitchSpeed;

	public readonly short AttackSpeed;

	public readonly short InnerRatio;

	public readonly short RecoveryOfQiDisorder;

	public readonly short ExtraCombatSkillGrids;

	public CombatDifficultyItem(byte templateId, string name, short hitValues, short penetrations, short avoidValues, short penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, short extraCombatSkillGrids)
	{
		TemplateId = templateId;
		Name = name;
		HitValues = hitValues;
		Penetrations = penetrations;
		AvoidValues = avoidValues;
		PenetrationResists = penetrationResists;
		RecoveryOfStanceAndBreath = recoveryOfStanceAndBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		ExtraCombatSkillGrids = extraCombatSkillGrids;
	}

	public CombatDifficultyItem()
	{
		TemplateId = 0;
		Name = null;
		HitValues = 0;
		Penetrations = 0;
		AvoidValues = 0;
		PenetrationResists = 0;
		RecoveryOfStanceAndBreath = default(OuterAndInnerShorts);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		ExtraCombatSkillGrids = 0;
	}

	public CombatDifficultyItem(byte templateId, CombatDifficultyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HitValues = other.HitValues;
		Penetrations = other.Penetrations;
		AvoidValues = other.AvoidValues;
		PenetrationResists = other.PenetrationResists;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatDifficultyItem Duplicate(int templateId)
	{
		return new CombatDifficultyItem((byte)templateId, this);
	}
}
