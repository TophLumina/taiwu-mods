using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SpecialEffectDataField : ConfigData<SpecialEffectDataFieldItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SpecialEffectDataField Instance = new SpecialEffectDataField();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "FieldName", "DisplayFormat" };

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
		_dataArray.Add(new SpecialEffectDataFieldItem(0, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_0"), "HitStrength", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(1, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_1"), "HitTechnique", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(2, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_2"), "HitSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(3, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_3"), "HitMind", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(4, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_4"), "PenetrateOuter", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(5, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_5"), "PenetrateInner", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(6, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_6"), "AvoidStrength", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(7, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_7"), "AvoidTechnique", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(8, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_8"), "AvoidSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(9, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_9"), "AvoidMind", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(10, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_10"), "PenetrateResistOuter", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(11, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_11"), "PenetrateResistInner", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(12, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_12"), "RecoveryOfStance", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(13, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_13"), "RecoveryOfBreath", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(14, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_14"), "MoveSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(15, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_15"), "RecoveryOfFlaw", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(16, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_16"), "CastSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(17, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_17"), "RecoveryOfBlockedAcupoint", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(18, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_18"), "WeaponSwitchSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(19, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_19"), "AttackSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(20, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_20"), "InnerRatio", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(21, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_21"), "RecoveryOfQiDisorder", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(22, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_22"), "ResistOfHotPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(23, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_23"), "ResistOfGloomyPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(24, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_24"), "ResistOfColdPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(25, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_25"), "ResistOfRedPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(26, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_26"), "ResistOfRottenPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(27, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_27"), "ResistOfIllusoryPoison", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(28, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_28"), "MakeDirectDamage", new int[3] { 0, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(29, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_29"), "MakeDirectDamage", new int[3] { 1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(30, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_30"), "Happiness", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(31, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_31"), "AddNeiliAllocation", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(32, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_32"), "MobilityRecoverSpeed", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(33, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_33"), "AttackRangeForward", new int[3] { -1, -1, -1 }, 10, "F1"));
		_dataArray.Add(new SpecialEffectDataFieldItem(34, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_34"), "AttackRangeBackward", new int[3] { -1, -1, -1 }, 10, "F1"));
		_dataArray.Add(new SpecialEffectDataFieldItem(35, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_35"), "PersonalitiesAll", new int[3] { -1, -1, -1 }, -1, null));
		_dataArray.Add(new SpecialEffectDataFieldItem(36, LocalStringManager.GetConfig("SpecialEffectDataField_language", "Name_36"), "AcceptDirectDamage", new int[3] { -1, -1, -1 }, -1, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SpecialEffectDataFieldItem>(37);
		CreateItems0();
	}
}
