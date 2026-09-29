using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TrickTypeItem : ConfigItem<TrickTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string ChineseName;

	public readonly string Icon;

	public readonly string Desc;

	public readonly sbyte AvoidType;

	public readonly sbyte[] AttackDistance;

	public readonly string[] AttackAnimations;

	public readonly string[] AttackParticles;

	public readonly string[] SoundEffects;

	public readonly sbyte[] InjuryPartAtkRateDistribution;

	public readonly sbyte EquipmentBreakOdds;

	public readonly string FontColor;

	public readonly string BackIcon;

	public readonly string BigBackIcon;

	public readonly string AvoidBackIcon;

	public readonly string AvoidBigBackIcon;

	public readonly List<StringList> ExecuteAni;

	public readonly List<StringList> ExecuteParticle;

	public readonly List<StringList> ExecuteSound;

	public TrickTypeItem(sbyte templateId, string name, string chineseName, string icon, string desc, sbyte avoidType, sbyte[] attackDistance, string[] attackAnimations, string[] attackParticles, string[] soundEffects, sbyte[] injuryPartAtkRateDistribution, sbyte equipmentBreakOdds, string fontColor, string backIcon, string bigBackIcon, string avoidBackIcon, string avoidBigBackIcon, List<StringList> executeAni, List<StringList> executeParticle, List<StringList> executeSound)
	{
		TemplateId = templateId;
		Name = name;
		ChineseName = chineseName;
		Icon = icon;
		Desc = desc;
		AvoidType = avoidType;
		AttackDistance = attackDistance;
		AttackAnimations = attackAnimations;
		AttackParticles = attackParticles;
		SoundEffects = soundEffects;
		InjuryPartAtkRateDistribution = injuryPartAtkRateDistribution;
		EquipmentBreakOdds = equipmentBreakOdds;
		FontColor = fontColor;
		BackIcon = backIcon;
		BigBackIcon = bigBackIcon;
		AvoidBackIcon = avoidBackIcon;
		AvoidBigBackIcon = avoidBigBackIcon;
		ExecuteAni = executeAni;
		ExecuteParticle = executeParticle;
		ExecuteSound = executeSound;
	}

	public TrickTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ChineseName = null;
		Icon = null;
		Desc = null;
		AvoidType = -1;
		AttackDistance = new sbyte[2];
		AttackAnimations = new string[0];
		AttackParticles = new string[0];
		SoundEffects = new string[0];
		InjuryPartAtkRateDistribution = new sbyte[7] { 80, 80, 20, 60, 60, 60, 60 };
		EquipmentBreakOdds = 0;
		FontColor = null;
		BackIcon = null;
		BigBackIcon = null;
		AvoidBackIcon = null;
		AvoidBigBackIcon = null;
		ExecuteAni = new List<StringList>();
		ExecuteParticle = new List<StringList>();
		ExecuteSound = new List<StringList>();
	}

	public TrickTypeItem(sbyte templateId, TrickTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ChineseName = other.ChineseName;
		Icon = other.Icon;
		Desc = other.Desc;
		AvoidType = other.AvoidType;
		AttackDistance = other.AttackDistance;
		AttackAnimations = other.AttackAnimations;
		AttackParticles = other.AttackParticles;
		SoundEffects = other.SoundEffects;
		InjuryPartAtkRateDistribution = other.InjuryPartAtkRateDistribution;
		EquipmentBreakOdds = other.EquipmentBreakOdds;
		FontColor = other.FontColor;
		BackIcon = other.BackIcon;
		BigBackIcon = other.BigBackIcon;
		AvoidBackIcon = other.AvoidBackIcon;
		AvoidBigBackIcon = other.AvoidBigBackIcon;
		ExecuteAni = other.ExecuteAni;
		ExecuteParticle = other.ExecuteParticle;
		ExecuteSound = other.ExecuteSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TrickTypeItem Duplicate(int templateId)
	{
		return new TrickTypeItem((sbyte)templateId, this);
	}
}
