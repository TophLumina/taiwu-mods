using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningParameter : ConfigData<PlanningParameterItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Integer = 0;

		public const sbyte MainAttributeType = 1;

		public const sbyte InjuryType = 2;

		public const sbyte PoisonType = 3;

		public const sbyte WugType = 4;

		public const sbyte ResourceType = 5;

		public const sbyte ItemType = 6;

		public const sbyte CombatSkillType = 7;

		public const sbyte LifeSkillType = 8;

		public const sbyte RelationType = 9;

		public const sbyte ItemSubType = 10;

		public const sbyte ItemTemplate = 11;

		public const sbyte Item = 12;

		public const sbyte Character = 13;

		public const sbyte Organization = 14;

		public const sbyte MapBlock = 15;

		public const sbyte Adventure = 16;

		public const sbyte CombatSkill = 17;

		public const sbyte LifeSkill = 18;

		public const sbyte NeiliType = 19;

		public const sbyte PersonalityType = 20;

		public const sbyte Grave = 21;
	}

	public static class DefValue
	{
		public static PlanningParameterItem Integer => Instance[(sbyte)0];

		public static PlanningParameterItem MainAttributeType => Instance[(sbyte)1];

		public static PlanningParameterItem InjuryType => Instance[(sbyte)2];

		public static PlanningParameterItem PoisonType => Instance[(sbyte)3];

		public static PlanningParameterItem WugType => Instance[(sbyte)4];

		public static PlanningParameterItem ResourceType => Instance[(sbyte)5];

		public static PlanningParameterItem ItemType => Instance[(sbyte)6];

		public static PlanningParameterItem CombatSkillType => Instance[(sbyte)7];

		public static PlanningParameterItem LifeSkillType => Instance[(sbyte)8];

		public static PlanningParameterItem RelationType => Instance[(sbyte)9];

		public static PlanningParameterItem ItemSubType => Instance[(sbyte)10];

		public static PlanningParameterItem ItemTemplate => Instance[(sbyte)11];

		public static PlanningParameterItem Item => Instance[(sbyte)12];

		public static PlanningParameterItem Character => Instance[(sbyte)13];

		public static PlanningParameterItem Organization => Instance[(sbyte)14];

		public static PlanningParameterItem MapBlock => Instance[(sbyte)15];

		public static PlanningParameterItem Adventure => Instance[(sbyte)16];

		public static PlanningParameterItem CombatSkill => Instance[(sbyte)17];

		public static PlanningParameterItem LifeSkill => Instance[(sbyte)18];

		public static PlanningParameterItem NeiliType => Instance[(sbyte)19];

		public static PlanningParameterItem PersonalityType => Instance[(sbyte)20];

		public static PlanningParameterItem Grave => Instance[(sbyte)21];
	}

	public static PlanningParameter Instance = new PlanningParameter();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Type", "ValueType" };

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
		_dataArray.Add(new PlanningParameterItem(0, EPlanningParameterType.Integer, EPlanningParameterValueType.Int, hideInUI: true));
		_dataArray.Add(new PlanningParameterItem(1, EPlanningParameterType.MainAttributeType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(2, EPlanningParameterType.InjuryType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(3, EPlanningParameterType.PoisonType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(4, EPlanningParameterType.WugType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(5, EPlanningParameterType.ResourceType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(6, EPlanningParameterType.ItemType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(7, EPlanningParameterType.CombatSkillType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(8, EPlanningParameterType.LifeSkillType, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(9, EPlanningParameterType.RelationType, EPlanningParameterValueType.Ushort, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(10, EPlanningParameterType.ItemSubType, EPlanningParameterValueType.Short, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(11, EPlanningParameterType.ItemTemplate, EPlanningParameterValueType.Short, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(12, EPlanningParameterType.Item, EPlanningParameterValueType.Int, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(13, EPlanningParameterType.Character, EPlanningParameterValueType.Int, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(14, EPlanningParameterType.Organization, EPlanningParameterValueType.Sbyte, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(15, EPlanningParameterType.MapBlock, EPlanningParameterValueType.Location, hideInUI: true));
		_dataArray.Add(new PlanningParameterItem(16, EPlanningParameterType.Adventure, EPlanningParameterValueType.Int, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(17, EPlanningParameterType.CombatSkill, EPlanningParameterValueType.Short, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(18, EPlanningParameterType.LifeSkill, EPlanningParameterValueType.Short, hideInUI: false));
		_dataArray.Add(new PlanningParameterItem(19, EPlanningParameterType.NeiliType, EPlanningParameterValueType.Sbyte, hideInUI: true));
		_dataArray.Add(new PlanningParameterItem(20, EPlanningParameterType.PersonalityType, EPlanningParameterValueType.Sbyte, hideInUI: true));
		_dataArray.Add(new PlanningParameterItem(21, EPlanningParameterType.Grave, EPlanningParameterValueType.Int, hideInUI: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PlanningParameterItem>(22);
		CreateItems0();
	}
}
