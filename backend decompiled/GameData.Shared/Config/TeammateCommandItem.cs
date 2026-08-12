using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeammateCommandItem : ConfigItem<TeammateCommandItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// - 必须为2个字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型
	/// - 仅通常指令可被随机生成，进阶指令为狮相特殊互动内容，负面指令不能随机给人物，只会在战斗中出现，且不显示禁用原因、不可点击操作
	/// </summary>
	public readonly ETeammateCommandType Type;

	/// <summary>
	/// 实现
	/// - 主要用于对换皮指令整合处理逻辑，并标注目前未实装的指令，新增指令由程序填入此处值
	/// </summary>
	public readonly ETeammateCommandImplement Implement;

	/// <summary>
	/// 开关
	/// - 用于提供玩家开关此指令的自动触发
	/// </summary>
	public readonly ETeammateCommandOption Option;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Description;

	/// <summary>
	/// 后方人物起始动画
	/// - 除替命指令外，均为队友效果
	/// </summary>
	public readonly string BackCharEnterAni;

	/// <summary>
	/// 后方人物起始音效
	/// </summary>
	public readonly string BackCharEnterSound;

	/// <summary>
	/// 后方人物循环动画
	/// </summary>
	public readonly string BackCharPrepareAni;

	/// <summary>
	/// 后方人物循环音效
	/// </summary>
	public readonly string BackCharPrepareSound;

	/// <summary>
	/// 后方人物结束动画
	/// </summary>
	public readonly string BackCharExitAni;

	/// <summary>
	/// 后方人物特效
	/// </summary>
	public readonly string BackCharParticle;

	/// <summary>
	/// 前方人物动画1
	/// - 除替命指令外，均为主角动画
	/// </summary>
	public readonly string ForeCharAni1;

	/// <summary>
	/// 前方人物动画2
	/// </summary>
	public readonly string ForeCharAni2;

	/// <summary>
	/// 前方人物动画3
	/// </summary>
	public readonly string ForeCharAni3;

	/// <summary>
	/// 前方人物动画时机使用 hit
	/// - 仅对于无需读条的动画有效
	/// </summary>
	public readonly bool ForeCharAniUseHit;

	/// <summary>
	/// 前方人物特效
	/// </summary>
	public readonly string ForeCharParticle;

	/// <summary>
	/// 准备帧数
	/// </summary>
	public readonly short PrepareFrame;

	/// <summary>
	/// 持续帧数
	/// </summary>
	public readonly short AffectFrame;

	/// <summary>
	/// 指令内置冷却帧数
	/// - 用于某些持续触发的指令，持续期间会在内置冷却结束后触发一次效果
	/// </summary>
	public readonly short CooldownFrame;

	/// <summary>
	/// 冷却总计数值
	/// - 默认每帧+100，受好感和特效影响
	/// </summary>
	public readonly int CdCount;

	/// <summary>
	/// 是否需要出场
	/// </summary>
	public readonly bool IntoCombatField;

	/// <summary>
	/// 上场时不运行ai
	/// </summary>
	public readonly bool DisableAi;

	/// <summary>
	/// 不检查执行或预约中的行为
	/// </summary>
	public readonly bool NotCheckDoingOrReserve;

	/// <summary>
	/// 队友位置偏移值
	/// - 负数-位于主角身后，正数-位于主角身前
	/// </summary>
	public readonly short PosOffset;

	/// <summary>
	/// 指令参数
	/// - 每种指令类型参数意义不同，详见代码中使用处
	/// </summary>
	public readonly int IntArg;

	/// <summary>
	/// 指令副参数
	/// </summary>
	public readonly int SubIntArg;

	/// <summary>
	/// 是否需要普攻蓄式
	/// </summary>
	public readonly bool RequireTrick;

	/// <summary>
	/// 是否需要摧破功法
	/// </summary>
	public readonly bool RequireAttackSkill;

	/// <summary>
	/// 是否需要护体功法
	/// </summary>
	public readonly bool RequireDefendSkill;

	/// <summary>
	/// 护体功法持续时间比例
	/// </summary>
	public readonly int DefendSkillDurationPercent;

	/// <summary>
	/// 特性勋章类型
	/// - 指令蓄力所需特性勋章类型。对应代码中的FeatureMedalType：-1.无，0.攻击，1.防御，2.机略
	/// </summary>
	public readonly sbyte MedalType;

	/// <summary>
	/// 特性勋章数量
	/// </summary>
	public readonly sbyte MedalCount;

	/// <summary>
	/// 高级指令替换的威望花费
	/// </summary>
	public readonly int UpgradeAuthorityCost;

	/// <summary>
	/// 指令触发好感区间
	/// - 好感度 [-30000, -26000]: 血仇, (-26000, -22000]: 痛恨, (-22000, -18000]: 憎恨, (-18000, -14000]: 仇视, (-14000, -10000]: 敌视, (-10000, -6000]: 鄙视, (-6000, 6000): 陌路, [6000, 10000): 冷淡, [10000, 14000): 融洽, [14000, 18000): 热忱, [18000, 22000): 喜爱, [22000, 26000): 亲密, [26000, 30000]: 不渝.
	/// </summary>
	public readonly short[] FavorLimit;

	/// <summary>
	/// 指令触发进度阈值
	/// </summary>
	public readonly int[] AutoProgress;

	/// <summary>
	/// 指令触发周期帧数
	/// </summary>
	public readonly int AutoFrame;

	/// <summary>
	/// 指令触发周期概率
	/// </summary>
	public readonly int AutoProb;

	/// <summary>
	/// 指令限定角色
	/// - 未填写时不限定可配置角色
	/// </summary>
	public readonly List<short> CompatibleCharacters;

	/// <summary>
	/// 触发对白
	/// - 触发同道指令特殊效果时的对话气泡，如消除冷却或负面指令发动
	/// </summary>
	public readonly string BubbleText;

	/// <summary>
	/// 效果显示文本
	/// - 前端显示对应指令的效果用的
	/// </summary>
	public readonly string[] EffectDisplayTextList;

	/// <summary>
	/// 效果显示数值
	/// - 前端显示对应指令的效果用的
	/// </summary>
	public readonly string[] EffectDisplayValueList;

	/// <summary>
	/// 效果数值类型
	/// - 0: 普通颜色 1: 增益的蓝 2：减的红
	/// </summary>
	public readonly sbyte[] EffectDisplayPositiveList;

	/// <summary>
	/// 预览效果的UI样式
	/// - 对应TeammateCommandEffectPreview_Style1~5
	/// </summary>
	public readonly sbyte EffectDisplayPreviewStyle;

	/// <summary>
	/// 效果显示数值
	/// - 专门给狮相门显示对应指令的效果用的
	/// </summary>
	public readonly string[] ShixiangEffectDisplayValueList;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称 - 必须为2个字</param>
	/// <param name="type">类型 - 仅通常指令可被随机生成，进阶指令为狮相特殊互动内容，负面指令不能随机给人物，只会在战斗中出现，且不显示禁用原因、不可点击操作</param>
	/// <param name="implement">实现 - 主要用于对换皮指令整合处理逻辑，并标注目前未实装的指令，新增指令由程序填入此处值</param>
	/// <param name="option">开关 - 用于提供玩家开关此指令的自动触发</param>
	/// <param name="description">描述</param>
	/// <param name="backCharEnterAni">后方人物起始动画 - 除替命指令外，均为队友效果</param>
	/// <param name="backCharEnterSound">后方人物起始音效</param>
	/// <param name="backCharPrepareAni">后方人物循环动画</param>
	/// <param name="backCharPrepareSound">后方人物循环音效</param>
	/// <param name="backCharExitAni">后方人物结束动画</param>
	/// <param name="backCharParticle">后方人物特效</param>
	/// <param name="foreCharAni1">前方人物动画1 - 除替命指令外，均为主角动画</param>
	/// <param name="foreCharAni2">前方人物动画2</param>
	/// <param name="foreCharAni3">前方人物动画3</param>
	/// <param name="foreCharAniUseHit">前方人物动画时机使用 hit - 仅对于无需读条的动画有效</param>
	/// <param name="foreCharParticle">前方人物特效</param>
	/// <param name="prepareFrame">准备帧数</param>
	/// <param name="affectFrame">持续帧数</param>
	/// <param name="cooldownFrame">指令内置冷却帧数 - 用于某些持续触发的指令，持续期间会在内置冷却结束后触发一次效果</param>
	/// <param name="cdCount">冷却总计数值 - 默认每帧+100，受好感和特效影响</param>
	/// <param name="intoCombatField">是否需要出场</param>
	/// <param name="disableAi">上场时不运行ai</param>
	/// <param name="notCheckDoingOrReserve">不检查执行或预约中的行为</param>
	/// <param name="posOffset">队友位置偏移值 - 负数-位于主角身后，正数-位于主角身前</param>
	/// <param name="intArg">指令参数 - 每种指令类型参数意义不同，详见代码中使用处</param>
	/// <param name="subIntArg">指令副参数</param>
	/// <param name="requireTrick">是否需要普攻蓄式</param>
	/// <param name="requireAttackSkill">是否需要摧破功法</param>
	/// <param name="requireDefendSkill">是否需要护体功法</param>
	/// <param name="defendSkillDurationPercent">护体功法持续时间比例</param>
	/// <param name="medalType">特性勋章类型 - 指令蓄力所需特性勋章类型。对应代码中的FeatureMedalType：-1.无，0.攻击，1.防御，2.机略</param>
	/// <param name="medalCount">特性勋章数量</param>
	/// <param name="upgradeAuthorityCost">高级指令替换的威望花费</param>
	/// <param name="favorLimit">指令触发好感区间 - 好感度 [-30000, -26000]: 血仇, (-26000, -22000]: 痛恨, (-22000, -18000]: 憎恨, (-18000, -14000]: 仇视, (-14000, -10000]: 敌视, (-10000, -6000]: 鄙视, (-6000, 6000): 陌路, [6000, 10000): 冷淡, [10000, 14000): 融洽, [14000, 18000): 热忱, [18000, 22000): 喜爱, [22000, 26000): 亲密, [26000, 30000]: 不渝.</param>
	/// <param name="autoProgress">指令触发进度阈值</param>
	/// <param name="autoFrame">指令触发周期帧数</param>
	/// <param name="autoProb">指令触发周期概率</param>
	/// <param name="compatibleCharacters">指令限定角色 - 未填写时不限定可配置角色</param>
	/// <param name="bubbleText">触发对白 - 触发同道指令特殊效果时的对话气泡，如消除冷却或负面指令发动</param>
	/// <param name="effectDisplayTextList">效果显示文本 - 前端显示对应指令的效果用的</param>
	/// <param name="effectDisplayValueList">效果显示数值 - 前端显示对应指令的效果用的</param>
	/// <param name="effectDisplayPositiveList">效果数值类型 - 0: 普通颜色 1: 增益的蓝 2：减的红</param>
	/// <param name="effectDisplayPreviewStyle">预览效果的UI样式 - 对应TeammateCommandEffectPreview_Style1~5</param>
	/// <param name="shixiangEffectDisplayValueList">效果显示数值 - 专门给狮相门显示对应指令的效果用的</param>
	public TeammateCommandItem(sbyte templateId, string name, ETeammateCommandType type, ETeammateCommandImplement implement, ETeammateCommandOption option, string description, string backCharEnterAni, string backCharEnterSound, string backCharPrepareAni, string backCharPrepareSound, string backCharExitAni, string backCharParticle, string foreCharAni1, string foreCharAni2, string foreCharAni3, bool foreCharAniUseHit, string foreCharParticle, short prepareFrame, short affectFrame, short cooldownFrame, int cdCount, bool intoCombatField, bool disableAi, bool notCheckDoingOrReserve, short posOffset, int intArg, int subIntArg, bool requireTrick, bool requireAttackSkill, bool requireDefendSkill, int defendSkillDurationPercent, sbyte medalType, sbyte medalCount, int upgradeAuthorityCost, short[] favorLimit, int[] autoProgress, int autoFrame, int autoProb, List<short> compatibleCharacters, string bubbleText, string[] effectDisplayTextList, string[] effectDisplayValueList, sbyte[] effectDisplayPositiveList, sbyte effectDisplayPreviewStyle, string[] shixiangEffectDisplayValueList)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Implement = implement;
		Option = option;
		Description = description;
		BackCharEnterAni = backCharEnterAni;
		BackCharEnterSound = backCharEnterSound;
		BackCharPrepareAni = backCharPrepareAni;
		BackCharPrepareSound = backCharPrepareSound;
		BackCharExitAni = backCharExitAni;
		BackCharParticle = backCharParticle;
		ForeCharAni1 = foreCharAni1;
		ForeCharAni2 = foreCharAni2;
		ForeCharAni3 = foreCharAni3;
		ForeCharAniUseHit = foreCharAniUseHit;
		ForeCharParticle = foreCharParticle;
		PrepareFrame = prepareFrame;
		AffectFrame = affectFrame;
		CooldownFrame = cooldownFrame;
		CdCount = cdCount;
		IntoCombatField = intoCombatField;
		DisableAi = disableAi;
		NotCheckDoingOrReserve = notCheckDoingOrReserve;
		PosOffset = posOffset;
		IntArg = intArg;
		SubIntArg = subIntArg;
		RequireTrick = requireTrick;
		RequireAttackSkill = requireAttackSkill;
		RequireDefendSkill = requireDefendSkill;
		DefendSkillDurationPercent = defendSkillDurationPercent;
		MedalType = medalType;
		MedalCount = medalCount;
		UpgradeAuthorityCost = upgradeAuthorityCost;
		FavorLimit = favorLimit;
		AutoProgress = autoProgress;
		AutoFrame = autoFrame;
		AutoProb = autoProb;
		CompatibleCharacters = compatibleCharacters;
		BubbleText = bubbleText;
		EffectDisplayTextList = effectDisplayTextList;
		EffectDisplayValueList = effectDisplayValueList;
		EffectDisplayPositiveList = effectDisplayPositiveList;
		EffectDisplayPreviewStyle = effectDisplayPreviewStyle;
		ShixiangEffectDisplayValueList = shixiangEffectDisplayValueList;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TeammateCommandItem()
	{
		TemplateId = 0;
		Name = null;
		Type = ETeammateCommandType.Normal;
		Implement = ETeammateCommandImplement.Invalid;
		Option = ETeammateCommandOption.Invalid;
		Description = null;
		BackCharEnterAni = null;
		BackCharEnterSound = null;
		BackCharPrepareAni = null;
		BackCharPrepareSound = null;
		BackCharExitAni = null;
		BackCharParticle = null;
		ForeCharAni1 = null;
		ForeCharAni2 = null;
		ForeCharAni3 = null;
		ForeCharAniUseHit = false;
		ForeCharParticle = null;
		PrepareFrame = -1;
		AffectFrame = -1;
		CooldownFrame = 0;
		CdCount = -1;
		IntoCombatField = true;
		DisableAi = false;
		NotCheckDoingOrReserve = false;
		PosOffset = 0;
		IntArg = 0;
		SubIntArg = 0;
		RequireTrick = false;
		RequireAttackSkill = false;
		RequireDefendSkill = false;
		DefendSkillDurationPercent = 100;
		MedalType = -1;
		MedalCount = 0;
		UpgradeAuthorityCost = 0;
		FavorLimit = new short[2] { -30000, 30000 };
		AutoProgress = new int[0];
		AutoFrame = 0;
		AutoProb = 0;
		CompatibleCharacters = new List<short>();
		BubbleText = null;
		EffectDisplayTextList = new string[0];
		EffectDisplayValueList = new string[0];
		EffectDisplayPositiveList = new sbyte[0];
		EffectDisplayPreviewStyle = -1;
		ShixiangEffectDisplayValueList = new string[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TeammateCommandItem(sbyte templateId, TeammateCommandItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Implement = other.Implement;
		Option = other.Option;
		Description = other.Description;
		BackCharEnterAni = other.BackCharEnterAni;
		BackCharEnterSound = other.BackCharEnterSound;
		BackCharPrepareAni = other.BackCharPrepareAni;
		BackCharPrepareSound = other.BackCharPrepareSound;
		BackCharExitAni = other.BackCharExitAni;
		BackCharParticle = other.BackCharParticle;
		ForeCharAni1 = other.ForeCharAni1;
		ForeCharAni2 = other.ForeCharAni2;
		ForeCharAni3 = other.ForeCharAni3;
		ForeCharAniUseHit = other.ForeCharAniUseHit;
		ForeCharParticle = other.ForeCharParticle;
		PrepareFrame = other.PrepareFrame;
		AffectFrame = other.AffectFrame;
		CooldownFrame = other.CooldownFrame;
		CdCount = other.CdCount;
		IntoCombatField = other.IntoCombatField;
		DisableAi = other.DisableAi;
		NotCheckDoingOrReserve = other.NotCheckDoingOrReserve;
		PosOffset = other.PosOffset;
		IntArg = other.IntArg;
		SubIntArg = other.SubIntArg;
		RequireTrick = other.RequireTrick;
		RequireAttackSkill = other.RequireAttackSkill;
		RequireDefendSkill = other.RequireDefendSkill;
		DefendSkillDurationPercent = other.DefendSkillDurationPercent;
		MedalType = other.MedalType;
		MedalCount = other.MedalCount;
		UpgradeAuthorityCost = other.UpgradeAuthorityCost;
		FavorLimit = other.FavorLimit;
		AutoProgress = other.AutoProgress;
		AutoFrame = other.AutoFrame;
		AutoProb = other.AutoProb;
		CompatibleCharacters = other.CompatibleCharacters;
		BubbleText = other.BubbleText;
		EffectDisplayTextList = other.EffectDisplayTextList;
		EffectDisplayValueList = other.EffectDisplayValueList;
		EffectDisplayPositiveList = other.EffectDisplayPositiveList;
		EffectDisplayPreviewStyle = other.EffectDisplayPreviewStyle;
		ShixiangEffectDisplayValueList = other.ShixiangEffectDisplayValueList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TeammateCommandItem Duplicate(int templateId)
	{
		return new TeammateCommandItem((sbyte)templateId, this);
	}
}
