using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningParameter : ConfigData<PlanningParameterItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 整数
		/// </summary>
		public const sbyte Integer = 0;

		/// <summary>
		/// 主要属性类型
		/// </summary>
		public const sbyte MainAttributeType = 1;

		/// <summary>
		/// 伤势类型
		/// </summary>
		public const sbyte InjuryType = 2;

		/// <summary>
		/// 毒素类型
		/// </summary>
		public const sbyte PoisonType = 3;

		/// <summary>
		/// 蛊类型
		/// </summary>
		public const sbyte WugType = 4;

		/// <summary>
		/// 资源类型
		/// </summary>
		public const sbyte ResourceType = 5;

		/// <summary>
		/// 道具类型
		/// </summary>
		public const sbyte ItemType = 6;

		/// <summary>
		/// 武学类型
		/// </summary>
		public const sbyte CombatSkillType = 7;

		/// <summary>
		/// 技艺类型
		/// </summary>
		public const sbyte LifeSkillType = 8;

		/// <summary>
		/// 关系类型
		/// </summary>
		public const sbyte RelationType = 9;

		/// <summary>
		/// 道具子类型
		/// </summary>
		public const sbyte ItemSubType = 10;

		/// <summary>
		/// 道具模板
		/// </summary>
		public const sbyte ItemTemplate = 11;

		/// <summary>
		/// 道具实例
		/// </summary>
		public const sbyte Item = 12;

		/// <summary>
		/// 角色实例
		/// </summary>
		public const sbyte Character = 13;

		/// <summary>
		/// 组织模板
		/// </summary>
		public const sbyte Organization = 14;

		/// <summary>
		/// 地格位置
		/// </summary>
		public const sbyte MapBlock = 15;

		/// <summary>
		/// 奇遇实例
		/// </summary>
		public const sbyte Adventure = 16;

		/// <summary>
		/// 武学
		/// </summary>
		public const sbyte CombatSkill = 17;

		/// <summary>
		/// 技艺
		/// </summary>
		public const sbyte LifeSkill = 18;

		/// <summary>
		/// 内力类型
		/// </summary>
		public const sbyte NeiliType = 19;

		/// <summary>
		/// 七元类型
		/// </summary>
		public const sbyte PersonalityType = 20;

		/// <summary>
		/// 坟墓实例
		/// </summary>
		public const sbyte Grave = 21;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 整数
		/// </summary>
		public static PlanningParameterItem Integer => Instance[(sbyte)0];

		/// <summary>
		/// 主要属性类型
		/// </summary>
		public static PlanningParameterItem MainAttributeType => Instance[(sbyte)1];

		/// <summary>
		/// 伤势类型
		/// </summary>
		public static PlanningParameterItem InjuryType => Instance[(sbyte)2];

		/// <summary>
		/// 毒素类型
		/// </summary>
		public static PlanningParameterItem PoisonType => Instance[(sbyte)3];

		/// <summary>
		/// 蛊类型
		/// </summary>
		public static PlanningParameterItem WugType => Instance[(sbyte)4];

		/// <summary>
		/// 资源类型
		/// </summary>
		public static PlanningParameterItem ResourceType => Instance[(sbyte)5];

		/// <summary>
		/// 道具类型
		/// </summary>
		public static PlanningParameterItem ItemType => Instance[(sbyte)6];

		/// <summary>
		/// 武学类型
		/// </summary>
		public static PlanningParameterItem CombatSkillType => Instance[(sbyte)7];

		/// <summary>
		/// 技艺类型
		/// </summary>
		public static PlanningParameterItem LifeSkillType => Instance[(sbyte)8];

		/// <summary>
		/// 关系类型
		/// </summary>
		public static PlanningParameterItem RelationType => Instance[(sbyte)9];

		/// <summary>
		/// 道具子类型
		/// </summary>
		public static PlanningParameterItem ItemSubType => Instance[(sbyte)10];

		/// <summary>
		/// 道具模板
		/// </summary>
		public static PlanningParameterItem ItemTemplate => Instance[(sbyte)11];

		/// <summary>
		/// 道具实例
		/// </summary>
		public static PlanningParameterItem Item => Instance[(sbyte)12];

		/// <summary>
		/// 角色实例
		/// </summary>
		public static PlanningParameterItem Character => Instance[(sbyte)13];

		/// <summary>
		/// 组织模板
		/// </summary>
		public static PlanningParameterItem Organization => Instance[(sbyte)14];

		/// <summary>
		/// 地格位置
		/// </summary>
		public static PlanningParameterItem MapBlock => Instance[(sbyte)15];

		/// <summary>
		/// 奇遇实例
		/// </summary>
		public static PlanningParameterItem Adventure => Instance[(sbyte)16];

		/// <summary>
		/// 武学
		/// </summary>
		public static PlanningParameterItem CombatSkill => Instance[(sbyte)17];

		/// <summary>
		/// 技艺
		/// </summary>
		public static PlanningParameterItem LifeSkill => Instance[(sbyte)18];

		/// <summary>
		/// 内力类型
		/// </summary>
		public static PlanningParameterItem NeiliType => Instance[(sbyte)19];

		/// <summary>
		/// 七元类型
		/// </summary>
		public static PlanningParameterItem PersonalityType => Instance[(sbyte)20];

		/// <summary>
		/// 坟墓实例
		/// </summary>
		public static PlanningParameterItem Grave => Instance[(sbyte)21];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
