using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatConfigItem : ConfigItem<CombatConfigItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 战斗类型
	/// - 0-切磋、1-恶斗、2-死斗、3-接招
	/// </summary>
	public readonly sbyte CombatType;

	/// <summary>
	/// 是否 Boss 战
	/// - 用于计算战斗评价
	/// </summary>
	public readonly bool IsBossCombat;

	/// <summary>
	/// 最小距离
	/// - 取值范围20~120
	/// </summary>
	public readonly byte MinDistance;

	/// <summary>
	/// 最大距离
	/// </summary>
	public readonly byte MaxDistance;

	/// <summary>
	/// 初始距离
	/// - 未指定时随机
	/// </summary>
	public readonly sbyte InitDistance;

	/// <summary>
	/// 逃跑距离
	/// - 可逃跑最小距离，取值范围需处于最大最小距离内
	/// </summary>
	public readonly byte FleeDistance;

	/// <summary>
	/// 逃跑打断距离
	/// - 在距离内攻击命中对方时可以打断逃跑，需大于最小距离且小于最大距离
	/// </summary>
	public readonly byte FleeInterruptDistance;

	/// <summary>
	/// 隐藏距离
	/// - 隐藏时距离文本显示为“无”
	/// </summary>
	public readonly bool HideDistance;

	/// <summary>
	/// 显示敌人代称
	/// - 此项为TRUE时，敌人显示为代称AnonymousTitle而非姓名
	/// </summary>
	public readonly bool EnemyAnonymous;

	/// <summary>
	/// 是否侵袭战斗
	/// - 用于影响是否获得相关遗惠与战斗评价
	/// </summary>
	public readonly bool IsOutBoss;

	/// <summary>
	/// 战后保留比例
	/// - 战斗结束时，在战斗中受到的新伤，新紊乱，新中毒会按多少比例保留，如参数为 80 时，假设有 6 个新伤，则保留 4 个新伤，相对应的，参数为 20 时，假设有 6 个新伤，则保留 1 个新伤
	/// </summary>
	public readonly int StayPercent;

	/// <summary>
	/// 己方能否逃跑
	/// </summary>
	public readonly bool SelfCanFlee;

	/// <summary>
	/// 敌方能否逃跑
	/// </summary>
	public readonly bool EnemyCanFlee;

	/// <summary>
	/// 敌方仅可逃跑
	/// </summary>
	public readonly bool EnemyOnlyFlee;

	/// <summary>
	/// 同道是否离队
	/// - 战斗对象为太吾同道时，同道是否离队
	/// </summary>
	public readonly bool IsGroupMemberLeave;

	/// <summary>
	/// 是否允许处决
	/// </summary>
	public readonly bool AllowShowMercy;

	/// <summary>
	/// 是否允许助战
	/// - 允许同道出现在战斗中
	/// </summary>
	public readonly bool AllowGroupMember;

	/// <summary>
	/// 是否允许随机好感
	/// </summary>
	public readonly bool AllowRandomFavorability;

	/// <summary>
	/// 允许战前准备
	/// </summary>
	public readonly bool AllowPrepare;

	/// <summary>
	/// 己方允许三魔/才出战
	/// </summary>
	public readonly bool AllowVitalDemon;

	/// <summary>
	/// 敌方允许三魔/才出战
	/// </summary>
	public readonly bool AllowVitalDemonBetray;

	/// <summary>
	/// 允许战斗结果影响临时NPC
	/// - 目前只有公库战会出于逻辑的一致性而影响临时NPC
	/// </summary>
	public readonly bool AffectTemporaryCharacter;

	/// <summary>
	/// 敌方特殊同道指令
	/// - 不为空时按顺序替换同道指令
	/// </summary>
	public readonly List<List<sbyte>> SpecialTeammateCommands;

	/// <summary>
	/// 敌方特殊同道指令气泡文本
	/// - 战斗准备界面替换同道指令时相关同道的气泡文本
	/// </summary>
	public readonly string[] SpecialTeammateCommandBubbleTexts;

	/// <summary>
	/// 限定功法五行属性
	/// - 0~4: 金木水火土，5: 混元。留空表示不限制
	/// </summary>
	public readonly List<sbyte> FiveElementsOfSkill;

	/// <summary>
	/// 限制功法类型
	/// - 留空表示不限制
	/// </summary>
	public readonly List<sbyte> CombatSkillType;

	/// <summary>
	/// 限制门派功法
	/// - 只能使用对应门派的身法、护体、摧破
	/// </summary>
	public readonly sbyte Sect;

	/// <summary>
	/// 是否掉落资源
	/// - 配置为FALSE时在战斗结束后取消历练、全资源掉落
	/// </summary>
	public readonly bool DropResource;

	/// <summary>
	/// 是否掉落物品
	/// - 配置为 FALSE 时将忽略掉落概率与行囊中物品等字段，跳过掉落判定
	/// </summary>
	public readonly bool AllowDropItem;

	/// <summary>
	/// 物品掉落概率
	/// - 配置为0则不会掉落物品
	/// </summary>
	public readonly short LootItemRate;

	/// <summary>
	/// 是否掉落行囊中所有物品
	/// - 配置为TRUE时无视概率，仅掉落主战角色行囊中所有物品
	/// </summary>
	public readonly bool LootAllInventory;

	/// <summary>
	/// 人物捕获概率
	/// - 配置为0则捕获必定失败
	/// </summary>
	public readonly short CaptureRate;

	/// <summary>
	/// 捕获所需绳索
	/// - 若存在配置值，则指定绳索以外的捕获概率被强制置为 0
	/// </summary>
	public readonly short CaptureRequireRope;

	/// <summary>
	/// 捕获代步无道具
	/// - 若配置此列，则在以捕获结束与动物的战斗时，不会创建相应代步道具添加至结算界面
	/// </summary>
	public readonly bool CaptureNoCarrier;

	/// <summary>
	/// 是否恢复敌人在战斗中受到的伤害
	/// </summary>
	public readonly bool EnemyHealDamage;

	/// <summary>
	/// 己方是否根据重创减少健康
	/// </summary>
	public readonly bool SelfFatalDamageReduceHealth;

	/// <summary>
	/// 敌方是否根据重创减少健康
	/// </summary>
	public readonly bool EnemyFatalDamageReduceHealth;

	/// <summary>
	/// 限时类型
	/// </summary>
	public readonly ECombatConfigForceDefeatType ForceDefeatType;

	/// <summary>
	/// 限时帧数
	/// - 到达限制时间时根据限时类型判定结果，0为不限时战斗
	/// </summary>
	public readonly uint ForceDefeatFrame;

	/// <summary>
	/// 背景音乐
	/// - 留空表示在通用战斗BGM中随机
	/// </summary>
	public readonly string[] Bgm;

	/// <summary>
	/// 战斗场景
	/// </summary>
	public readonly short Scene;

	/// <summary>
	/// 敌方特殊 Ai
	/// </summary>
	public readonly int EnemyAi;

	/// <summary>
	/// 是否跳过转阶段
	/// - 仅用于Boss战斗
	/// </summary>
	public readonly bool SkipChangePhase;

	/// <summary>
	/// 是否直接进入2阶段
	/// </summary>
	public readonly bool StartInSecondPhase;

	/// <summary>
	/// 镜头缩放参数
	/// </summary>
	public readonly float ScaleFactor;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="combatType">战斗类型 - 0-切磋、1-恶斗、2-死斗、3-接招</param>
	/// <param name="isBossCombat">是否 Boss 战 - 用于计算战斗评价</param>
	/// <param name="minDistance">最小距离 - 取值范围20~120</param>
	/// <param name="maxDistance">最大距离</param>
	/// <param name="initDistance">初始距离 - 未指定时随机</param>
	/// <param name="fleeDistance">逃跑距离 - 可逃跑最小距离，取值范围需处于最大最小距离内</param>
	/// <param name="fleeInterruptDistance">逃跑打断距离 - 在距离内攻击命中对方时可以打断逃跑，需大于最小距离且小于最大距离</param>
	/// <param name="hideDistance">隐藏距离 - 隐藏时距离文本显示为“无”</param>
	/// <param name="enemyAnonymous">显示敌人代称 - 此项为TRUE时，敌人显示为代称AnonymousTitle而非姓名</param>
	/// <param name="isOutBoss">是否侵袭战斗 - 用于影响是否获得相关遗惠与战斗评价</param>
	/// <param name="stayPercent">战后保留比例 - 战斗结束时，在战斗中受到的新伤，新紊乱，新中毒会按多少比例保留，如参数为 80 时，假设有 6 个新伤，则保留 4 个新伤，相对应的，参数为 20 时，假设有 6 个新伤，则保留 1 个新伤</param>
	/// <param name="selfCanFlee">己方能否逃跑</param>
	/// <param name="enemyCanFlee">敌方能否逃跑</param>
	/// <param name="enemyOnlyFlee">敌方仅可逃跑</param>
	/// <param name="isGroupMemberLeave">同道是否离队 - 战斗对象为太吾同道时，同道是否离队</param>
	/// <param name="allowShowMercy">是否允许处决</param>
	/// <param name="allowGroupMember">是否允许助战 - 允许同道出现在战斗中</param>
	/// <param name="allowRandomFavorability">是否允许随机好感</param>
	/// <param name="allowPrepare">允许战前准备</param>
	/// <param name="allowVitalDemon">己方允许三魔/才出战</param>
	/// <param name="allowVitalDemonBetray">敌方允许三魔/才出战</param>
	/// <param name="affectTemporaryCharacter">允许战斗结果影响临时NPC - 目前只有公库战会出于逻辑的一致性而影响临时NPC</param>
	/// <param name="specialTeammateCommands">敌方特殊同道指令 - 不为空时按顺序替换同道指令</param>
	/// <param name="specialTeammateCommandBubbleTexts">敌方特殊同道指令气泡文本 - 战斗准备界面替换同道指令时相关同道的气泡文本</param>
	/// <param name="fiveElementsOfSkill">限定功法五行属性 - 0~4: 金木水火土，5: 混元。留空表示不限制</param>
	/// <param name="combatSkillType">限制功法类型 - 留空表示不限制</param>
	/// <param name="sect">限制门派功法 - 只能使用对应门派的身法、护体、摧破</param>
	/// <param name="dropResource">是否掉落资源 - 配置为FALSE时在战斗结束后取消历练、全资源掉落</param>
	/// <param name="allowDropItem">是否掉落物品 - 配置为 FALSE 时将忽略掉落概率与行囊中物品等字段，跳过掉落判定</param>
	/// <param name="lootItemRate">物品掉落概率 - 配置为0则不会掉落物品</param>
	/// <param name="lootAllInventory">是否掉落行囊中所有物品 - 配置为TRUE时无视概率，仅掉落主战角色行囊中所有物品</param>
	/// <param name="captureRate">人物捕获概率 - 配置为0则捕获必定失败</param>
	/// <param name="captureRequireRope">捕获所需绳索 - 若存在配置值，则指定绳索以外的捕获概率被强制置为 0</param>
	/// <param name="captureNoCarrier">捕获代步无道具 - 若配置此列，则在以捕获结束与动物的战斗时，不会创建相应代步道具添加至结算界面</param>
	/// <param name="enemyHealDamage">是否恢复敌人在战斗中受到的伤害</param>
	/// <param name="selfFatalDamageReduceHealth">己方是否根据重创减少健康</param>
	/// <param name="enemyFatalDamageReduceHealth">敌方是否根据重创减少健康</param>
	/// <param name="forceDefeatType">限时类型</param>
	/// <param name="forceDefeatFrame">限时帧数 - 到达限制时间时根据限时类型判定结果，0为不限时战斗</param>
	/// <param name="bgm">背景音乐 - 留空表示在通用战斗BGM中随机</param>
	/// <param name="scene">战斗场景</param>
	/// <param name="enemyAi">敌方特殊 Ai</param>
	/// <param name="skipChangePhase">是否跳过转阶段 - 仅用于Boss战斗</param>
	/// <param name="startInSecondPhase">是否直接进入2阶段</param>
	/// <param name="scaleFactor">镜头缩放参数</param>
	public CombatConfigItem(short templateId, sbyte combatType, bool isBossCombat, byte minDistance, byte maxDistance, sbyte initDistance, byte fleeDistance, byte fleeInterruptDistance, bool hideDistance, bool enemyAnonymous, bool isOutBoss, int stayPercent, bool selfCanFlee, bool enemyCanFlee, bool enemyOnlyFlee, bool isGroupMemberLeave, bool allowShowMercy, bool allowGroupMember, bool allowRandomFavorability, bool allowPrepare, bool allowVitalDemon, bool allowVitalDemonBetray, bool affectTemporaryCharacter, List<List<sbyte>> specialTeammateCommands, string[] specialTeammateCommandBubbleTexts, List<sbyte> fiveElementsOfSkill, List<sbyte> combatSkillType, sbyte sect, bool dropResource, bool allowDropItem, short lootItemRate, bool lootAllInventory, short captureRate, short captureRequireRope, bool captureNoCarrier, bool enemyHealDamage, bool selfFatalDamageReduceHealth, bool enemyFatalDamageReduceHealth, ECombatConfigForceDefeatType forceDefeatType, uint forceDefeatFrame, string[] bgm, short scene, int enemyAi, bool skipChangePhase, bool startInSecondPhase, float scaleFactor)
	{
		TemplateId = templateId;
		CombatType = combatType;
		IsBossCombat = isBossCombat;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
		InitDistance = initDistance;
		FleeDistance = fleeDistance;
		FleeInterruptDistance = fleeInterruptDistance;
		HideDistance = hideDistance;
		EnemyAnonymous = enemyAnonymous;
		IsOutBoss = isOutBoss;
		StayPercent = stayPercent;
		SelfCanFlee = selfCanFlee;
		EnemyCanFlee = enemyCanFlee;
		EnemyOnlyFlee = enemyOnlyFlee;
		IsGroupMemberLeave = isGroupMemberLeave;
		AllowShowMercy = allowShowMercy;
		AllowGroupMember = allowGroupMember;
		AllowRandomFavorability = allowRandomFavorability;
		AllowPrepare = allowPrepare;
		AllowVitalDemon = allowVitalDemon;
		AllowVitalDemonBetray = allowVitalDemonBetray;
		AffectTemporaryCharacter = affectTemporaryCharacter;
		SpecialTeammateCommands = specialTeammateCommands;
		SpecialTeammateCommandBubbleTexts = specialTeammateCommandBubbleTexts;
		FiveElementsOfSkill = fiveElementsOfSkill;
		CombatSkillType = combatSkillType;
		Sect = sect;
		DropResource = dropResource;
		AllowDropItem = allowDropItem;
		LootItemRate = lootItemRate;
		LootAllInventory = lootAllInventory;
		CaptureRate = captureRate;
		CaptureRequireRope = captureRequireRope;
		CaptureNoCarrier = captureNoCarrier;
		EnemyHealDamage = enemyHealDamage;
		SelfFatalDamageReduceHealth = selfFatalDamageReduceHealth;
		EnemyFatalDamageReduceHealth = enemyFatalDamageReduceHealth;
		ForceDefeatType = forceDefeatType;
		ForceDefeatFrame = forceDefeatFrame;
		Bgm = bgm;
		Scene = scene;
		EnemyAi = enemyAi;
		SkipChangePhase = skipChangePhase;
		StartInSecondPhase = startInSecondPhase;
		ScaleFactor = scaleFactor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatConfigItem()
	{
		TemplateId = 0;
		CombatType = -1;
		IsBossCombat = false;
		MinDistance = 20;
		MaxDistance = 120;
		InitDistance = -1;
		FleeDistance = 100;
		FleeInterruptDistance = 40;
		HideDistance = false;
		EnemyAnonymous = false;
		IsOutBoss = false;
		StayPercent = 50;
		SelfCanFlee = true;
		EnemyCanFlee = true;
		EnemyOnlyFlee = false;
		IsGroupMemberLeave = true;
		AllowShowMercy = true;
		AllowGroupMember = true;
		AllowRandomFavorability = true;
		AllowPrepare = true;
		AllowVitalDemon = true;
		AllowVitalDemonBetray = true;
		AffectTemporaryCharacter = false;
		SpecialTeammateCommands = new List<List<sbyte>>();
		SpecialTeammateCommandBubbleTexts = new string[0];
		FiveElementsOfSkill = new List<sbyte>();
		CombatSkillType = new List<sbyte>();
		Sect = 0;
		DropResource = true;
		AllowDropItem = true;
		LootItemRate = 100;
		LootAllInventory = false;
		CaptureRate = 100;
		CaptureRequireRope = 0;
		CaptureNoCarrier = false;
		EnemyHealDamage = false;
		SelfFatalDamageReduceHealth = true;
		EnemyFatalDamageReduceHealth = true;
		ForceDefeatType = ECombatConfigForceDefeatType.Invalid;
		ForceDefeatFrame = 0u;
		Bgm = null;
		Scene = 0;
		EnemyAi = 0;
		SkipChangePhase = false;
		StartInSecondPhase = false;
		ScaleFactor = 1f;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatConfigItem(short templateId, CombatConfigItem other)
	{
		TemplateId = templateId;
		CombatType = other.CombatType;
		IsBossCombat = other.IsBossCombat;
		MinDistance = other.MinDistance;
		MaxDistance = other.MaxDistance;
		InitDistance = other.InitDistance;
		FleeDistance = other.FleeDistance;
		FleeInterruptDistance = other.FleeInterruptDistance;
		HideDistance = other.HideDistance;
		EnemyAnonymous = other.EnemyAnonymous;
		IsOutBoss = other.IsOutBoss;
		StayPercent = other.StayPercent;
		SelfCanFlee = other.SelfCanFlee;
		EnemyCanFlee = other.EnemyCanFlee;
		EnemyOnlyFlee = other.EnemyOnlyFlee;
		IsGroupMemberLeave = other.IsGroupMemberLeave;
		AllowShowMercy = other.AllowShowMercy;
		AllowGroupMember = other.AllowGroupMember;
		AllowRandomFavorability = other.AllowRandomFavorability;
		AllowPrepare = other.AllowPrepare;
		AllowVitalDemon = other.AllowVitalDemon;
		AllowVitalDemonBetray = other.AllowVitalDemonBetray;
		AffectTemporaryCharacter = other.AffectTemporaryCharacter;
		SpecialTeammateCommands = other.SpecialTeammateCommands;
		SpecialTeammateCommandBubbleTexts = other.SpecialTeammateCommandBubbleTexts;
		FiveElementsOfSkill = other.FiveElementsOfSkill;
		CombatSkillType = other.CombatSkillType;
		Sect = other.Sect;
		DropResource = other.DropResource;
		AllowDropItem = other.AllowDropItem;
		LootItemRate = other.LootItemRate;
		LootAllInventory = other.LootAllInventory;
		CaptureRate = other.CaptureRate;
		CaptureRequireRope = other.CaptureRequireRope;
		CaptureNoCarrier = other.CaptureNoCarrier;
		EnemyHealDamage = other.EnemyHealDamage;
		SelfFatalDamageReduceHealth = other.SelfFatalDamageReduceHealth;
		EnemyFatalDamageReduceHealth = other.EnemyFatalDamageReduceHealth;
		ForceDefeatType = other.ForceDefeatType;
		ForceDefeatFrame = other.ForceDefeatFrame;
		Bgm = other.Bgm;
		Scene = other.Scene;
		EnemyAi = other.EnemyAi;
		SkipChangePhase = other.SkipChangePhase;
		StartInSecondPhase = other.StartInSecondPhase;
		ScaleFactor = other.ScaleFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatConfigItem Duplicate(int templateId)
	{
		return new CombatConfigItem((short)templateId, this);
	}
}
