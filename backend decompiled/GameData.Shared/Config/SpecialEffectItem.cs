using System;
using Config.Common;
using GameData.Combat.Math;
using GameData.Utilities;

namespace Config;

[Serializable]
public class SpecialEffectItem : ConfigItem<SpecialEffectItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 生效时机
	/// - 仅用于功法特效。0-施展时（摧破-开始读条时，其它-读条结束时），1-进入战斗时，2-运功时，3-突破时
	/// </summary>
	public readonly sbyte EffectActiveType;

	/// <summary>
	/// 效果层数下限
	/// </summary>
	public readonly short MinEffectCount;

	/// <summary>
	/// 效果层数上限
	/// </summary>
	public readonly short MaxEffectCount;

	/// <summary>
	/// AI加分发挥成数
	/// - 0~100，用于战斗AI得分计算，-1表示需要动态计算生效成数
	/// </summary>
	public readonly sbyte RequireAttackPower;

	/// <summary>
	/// AI使用施展增幅时机
	/// - Ai开始读条后多少帧判断使用施展增幅，负数表示开始施展时判断
	/// </summary>
	public readonly sbyte AiCostNeiliAllocationChanceDelayFrame;

	/// <summary>
	/// AI使用施展增幅条件
	/// - “无效值”表示该功法不可通过 Ai 施展增幅，新增施展增幅功法应将此列改为其它条件，目前攻击范围类施展增幅判定“攻击范围”，王蛊类施展增幅判定“必然触发”，其它均为“仅聪颖”
	/// </summary>
	public readonly ESpecialEffectAiCostNeiliAllocationType AiCostNeiliAllocationType;

	/// <summary>
	/// 变招变化五行属性比例
	/// - 变化方向可查看 BodyPartType.TransferToFiveElementsType；此处目前仅用于界面表现，如需修改值，请联系相关程序处理
	/// </summary>
	public readonly int TransferProportion;

	/// <summary>
	/// 效果生效需要的成数
	/// - 对应效果生效所需成数，如果填入-1，表示需要动态计算的最高两项成数之和
	/// </summary>
	public readonly int[] AffectRequirePower;

	/// <summary>
	/// 威力伤害影响系数
	/// - 仅对于有根据威力造成伤害的功法有效
	/// </summary>
	public readonly int[] PowerDamageFactors;

	/// <summary>
	/// 每帧增加解封值
	/// </summary>
	public readonly int AddUnlockValue;

	/// <summary>
	/// 增加解封值的物品类型
	/// - 有相关实现才可生效，如需修改请联系程序
	/// </summary>
	public readonly short AddUnlockValueItemSubType;

	/// <summary>
	/// 生铸装备特效
	/// - 有相关实现才可生效，如需修改请联系程序
	/// </summary>
	public readonly short RawCreateEffect;

	/// <summary>
	/// 生铸效果跳字
	/// </summary>
	public readonly short RawCreateTips;

	/// <summary>
	/// 生铸目标类型
	/// </summary>
	public readonly ESpecialEffectRawCreateType RawCreateType;

	/// <summary>
	/// 生铸升阶所需精制材料数
	/// - 仅生铸的品级高于原品级时消耗
	/// </summary>
	public readonly int RawCreateRequireMaterialCount;

	/// <summary>
	/// 显示使用物品按钮的UI特效
	/// </summary>
	public readonly bool ShowUsingItemButtonEffect;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 功法模板ID
	/// </summary>
	public readonly short SkillTemplateId;

	/// <summary>
	/// 简述
	/// - 效果提示标题，通常为6个字
	/// </summary>
	public readonly string[] ShortDesc;

	/// <summary>
	/// 说明
	/// - 第1项为完整特效描述、第2项及之后的显示时机由特效自行决定
	/// </summary>
	public readonly string[] Desc;

	/// <summary>
	/// 详细说明
	/// - 结构完全对应说明列
	/// </summary>
	public readonly string[] DetailedDesc;

	/// <summary>
	/// 玩家施展boss功法时的说明文字
	/// </summary>
	public readonly string[] PlayerCastBossSkillDesc;

	/// <summary>
	/// 特效类名
	/// - 此列由特效代码作者维护
	/// </summary>
	public readonly string ClassName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="effectActiveType">生效时机 - 仅用于功法特效。0-施展时（摧破-开始读条时，其它-读条结束时），1-进入战斗时，2-运功时，3-突破时</param>
	/// <param name="minEffectCount">效果层数下限</param>
	/// <param name="maxEffectCount">效果层数上限</param>
	/// <param name="requireAttackPower">AI加分发挥成数 - 0~100，用于战斗AI得分计算，-1表示需要动态计算生效成数</param>
	/// <param name="aiCostNeiliAllocationChanceDelayFrame">AI使用施展增幅时机 - Ai开始读条后多少帧判断使用施展增幅，负数表示开始施展时判断</param>
	/// <param name="aiCostNeiliAllocationType">AI使用施展增幅条件 - “无效值”表示该功法不可通过 Ai 施展增幅，新增施展增幅功法应将此列改为其它条件，目前攻击范围类施展增幅判定“攻击范围”，王蛊类施展增幅判定“必然触发”，其它均为“仅聪颖”</param>
	/// <param name="transferProportion">变招变化五行属性比例 - 变化方向可查看 BodyPartType.TransferToFiveElementsType；此处目前仅用于界面表现，如需修改值，请联系相关程序处理</param>
	/// <param name="affectRequirePower">效果生效需要的成数 - 对应效果生效所需成数，如果填入-1，表示需要动态计算的最高两项成数之和</param>
	/// <param name="powerDamageFactors">威力伤害影响系数 - 仅对于有根据威力造成伤害的功法有效</param>
	/// <param name="addUnlockValue">每帧增加解封值</param>
	/// <param name="addUnlockValueItemSubType">增加解封值的物品类型 - 有相关实现才可生效，如需修改请联系程序</param>
	/// <param name="rawCreateEffect">生铸装备特效 - 有相关实现才可生效，如需修改请联系程序</param>
	/// <param name="rawCreateTips">生铸效果跳字</param>
	/// <param name="rawCreateType">生铸目标类型</param>
	/// <param name="rawCreateRequireMaterialCount">生铸升阶所需精制材料数 - 仅生铸的品级高于原品级时消耗</param>
	/// <param name="showUsingItemButtonEffect">显示使用物品按钮的UI特效</param>
	/// <param name="name">名称</param>
	/// <param name="skillTemplateId">功法模板ID</param>
	/// <param name="shortDesc">简述 - 效果提示标题，通常为6个字</param>
	/// <param name="desc">说明 - 第1项为完整特效描述、第2项及之后的显示时机由特效自行决定</param>
	/// <param name="detailedDesc">详细说明 - 结构完全对应说明列</param>
	/// <param name="playerCastBossSkillDesc">玩家施展boss功法时的说明文字</param>
	/// <param name="className">特效类名 - 此列由特效代码作者维护</param>
	public SpecialEffectItem(short templateId, sbyte effectActiveType, short minEffectCount, short maxEffectCount, sbyte requireAttackPower, sbyte aiCostNeiliAllocationChanceDelayFrame, ESpecialEffectAiCostNeiliAllocationType aiCostNeiliAllocationType, int transferProportion, int[] affectRequirePower, int[] powerDamageFactors, int addUnlockValue, short addUnlockValueItemSubType, short rawCreateEffect, short rawCreateTips, ESpecialEffectRawCreateType rawCreateType, int rawCreateRequireMaterialCount, bool showUsingItemButtonEffect, string name, short skillTemplateId, string[] shortDesc, string[] desc, string[] detailedDesc, string[] playerCastBossSkillDesc, string className)
	{
		TemplateId = templateId;
		EffectActiveType = effectActiveType;
		MinEffectCount = minEffectCount;
		MaxEffectCount = maxEffectCount;
		RequireAttackPower = requireAttackPower;
		AiCostNeiliAllocationChanceDelayFrame = aiCostNeiliAllocationChanceDelayFrame;
		AiCostNeiliAllocationType = aiCostNeiliAllocationType;
		TransferProportion = transferProportion;
		AffectRequirePower = affectRequirePower;
		PowerDamageFactors = powerDamageFactors;
		AddUnlockValue = addUnlockValue;
		AddUnlockValueItemSubType = addUnlockValueItemSubType;
		RawCreateEffect = rawCreateEffect;
		RawCreateTips = rawCreateTips;
		RawCreateType = rawCreateType;
		RawCreateRequireMaterialCount = rawCreateRequireMaterialCount;
		ShowUsingItemButtonEffect = showUsingItemButtonEffect;
		Name = name;
		SkillTemplateId = skillTemplateId;
		ShortDesc = shortDesc;
		Desc = desc;
		DetailedDesc = detailedDesc;
		PlayerCastBossSkillDesc = playerCastBossSkillDesc;
		ClassName = className;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SpecialEffectItem()
	{
		TemplateId = 0;
		EffectActiveType = -1;
		MinEffectCount = 1;
		MaxEffectCount = -1;
		RequireAttackPower = -1;
		AiCostNeiliAllocationChanceDelayFrame = -1;
		AiCostNeiliAllocationType = ESpecialEffectAiCostNeiliAllocationType.None;
		TransferProportion = 0;
		AffectRequirePower = new int[0];
		PowerDamageFactors = new int[0];
		AddUnlockValue = 0;
		AddUnlockValueItemSubType = 0;
		RawCreateEffect = 0;
		RawCreateTips = 0;
		RawCreateType = ESpecialEffectRawCreateType.None;
		RawCreateRequireMaterialCount = 0;
		ShowUsingItemButtonEffect = false;
		Name = null;
		SkillTemplateId = 0;
		ShortDesc = new string[0];
		Desc = new string[0];
		DetailedDesc = new string[0];
		PlayerCastBossSkillDesc = new string[0];
		ClassName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SpecialEffectItem(short templateId, SpecialEffectItem other)
	{
		TemplateId = templateId;
		EffectActiveType = other.EffectActiveType;
		MinEffectCount = other.MinEffectCount;
		MaxEffectCount = other.MaxEffectCount;
		RequireAttackPower = other.RequireAttackPower;
		AiCostNeiliAllocationChanceDelayFrame = other.AiCostNeiliAllocationChanceDelayFrame;
		AiCostNeiliAllocationType = other.AiCostNeiliAllocationType;
		TransferProportion = other.TransferProportion;
		AffectRequirePower = other.AffectRequirePower;
		PowerDamageFactors = other.PowerDamageFactors;
		AddUnlockValue = other.AddUnlockValue;
		AddUnlockValueItemSubType = other.AddUnlockValueItemSubType;
		RawCreateEffect = other.RawCreateEffect;
		RawCreateTips = other.RawCreateTips;
		RawCreateType = other.RawCreateType;
		RawCreateRequireMaterialCount = other.RawCreateRequireMaterialCount;
		ShowUsingItemButtonEffect = other.ShowUsingItemButtonEffect;
		Name = other.Name;
		SkillTemplateId = other.SkillTemplateId;
		ShortDesc = other.ShortDesc;
		Desc = other.Desc;
		DetailedDesc = other.DetailedDesc;
		PlayerCastBossSkillDesc = other.PlayerCastBossSkillDesc;
		ClassName = other.ClassName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SpecialEffectItem Duplicate(int templateId)
	{
		return new SpecialEffectItem((short)templateId, this);
	}

	public CValuePercent GetPowerFactor(int index = 0)
	{
		if (PowerDamageFactors.CheckIndex(index))
		{
			return PowerDamageFactors[index];
		}
		PredefinedLog.Show(8, $"{TemplateId} failed to get power factor at {index}");
		return 100;
	}
}
