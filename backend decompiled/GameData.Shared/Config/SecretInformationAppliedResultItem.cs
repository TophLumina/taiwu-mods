using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedResultItem : ConfigItem<SecretInformationAppliedResultItem, short>
{
	/// <summary>
	/// 结果事件模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 内部转接事件
	/// - 当判定出现此事件时，转接到此表中的其他事件。此转接最优处理，且会循环转接到无内部转接为止。
	/// </summary>
	public readonly short InnerResultEvent;

	/// <summary>
	/// 外部转接事件
	/// - 需要跳转的外部GUID。此转接后于内部转接。
	/// </summary>
	public readonly string ResultEventGuid;

	/// <summary>
	/// 外部转接事件参数盒子key
	/// - 需要跳转的外部GUID在参数盒子中的key
	/// </summary>
	public readonly string ResultEventGuidKey;

	/// <summary>
	/// 外部跳转结束
	/// - 外部跳转是否视为秘闻事件链的终结
	/// </summary>
	public readonly bool EndEventAfterJump;

	/// <summary>
	/// 显示人物
	/// - 如果不显示人物，就代表两边都不出现（因为秘闻都是对人使用的，所以最好不要单独为两侧的人物进行配置）；对一些只有逻辑处理或者有跳转的result而言，填或不填false是一样的，但为了统一格式还是先填着
	/// </summary>
	public readonly bool RevealCharacters;

	/// <summary>
	/// 五个立场的文本
	/// </summary>
	public readonly string[] Texts;

	/// <summary>
	/// 选项
	/// </summary>
	public readonly short[] SelectionIds;

	/// <summary>
	/// 产生秘闻
	/// - 产生的秘闻，引用秘闻主表。秘闻自带的逻辑将在生成前进行检定，如公开杀害的对象若未死，则先令其死亡。
	/// </summary>
	public readonly List<ShortList> SecretInformation;

	/// <summary>
	/// 触发战斗
	/// </summary>
	public readonly short CombatConfigId;

	/// <summary>
	/// 是否无护卫
	/// - 注意，是是否【无】护卫，和接口逻辑保持一致
	/// </summary>
	public readonly bool NoGuard;

	/// <summary>
	/// 特殊逻辑
	/// - 引用特殊条件的模板id，没有参数了！
	/// </summary>
	public readonly short SpecialConditionId;

	/// <summary>
	/// 特殊逻辑参数
	/// - 战斗：0-玩家胜利 1-敌人胜利 2-玩家逃跑 3-敌人逃跑 4-玩家死亡 5-敌人死亡 6-敌人被擒
	/// </summary>
	public readonly List<ShortList> SpecialConditionResultIds;

	/// <summary>
	/// 双方心情变化
	/// - 玩家
	/// </summary>
	public readonly sbyte SelfHappinessDiff;

	public readonly sbyte OppositeHappinessDiff;

	/// <summary>
	/// 双方好感变化
	/// - 玩家对对方
	/// </summary>
	public readonly short SelfFavorabilityDiff;

	public readonly short OppositeFavorabilityDiff;

	/// <summary>
	/// 双方入魔变化
	/// - 玩家
	/// </summary>
	public readonly sbyte SelfInfectionDiff;

	public readonly sbyte OppositeInfectionDiff;

	/// <summary>
	/// 是否消耗好感
	/// - 如果为true，则读取对应秘闻中的消耗好感配置
	/// </summary>
	public readonly bool IsFavorabilityCost;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">结果事件模板ID</param>
	/// <param name="innerResultEvent">内部转接事件 - 当判定出现此事件时，转接到此表中的其他事件。此转接最优处理，且会循环转接到无内部转接为止。</param>
	/// <param name="resultEventGuid">外部转接事件 - 需要跳转的外部GUID。此转接后于内部转接。</param>
	/// <param name="resultEventGuidKey">外部转接事件参数盒子key - 需要跳转的外部GUID在参数盒子中的key</param>
	/// <param name="endEventAfterJump">外部跳转结束 - 外部跳转是否视为秘闻事件链的终结</param>
	/// <param name="revealCharacters">显示人物 - 如果不显示人物，就代表两边都不出现（因为秘闻都是对人使用的，所以最好不要单独为两侧的人物进行配置）；对一些只有逻辑处理或者有跳转的result而言，填或不填false是一样的，但为了统一格式还是先填着</param>
	/// <param name="texts">五个立场的文本</param>
	/// <param name="selectionIds">选项</param>
	/// <param name="secretInformation">产生秘闻 - 产生的秘闻，引用秘闻主表。秘闻自带的逻辑将在生成前进行检定，如公开杀害的对象若未死，则先令其死亡。</param>
	/// <param name="combatConfigId">触发战斗</param>
	/// <param name="noGuard">是否无护卫 - 注意，是是否【无】护卫，和接口逻辑保持一致</param>
	/// <param name="specialConditionId">特殊逻辑 - 引用特殊条件的模板id，没有参数了！</param>
	/// <param name="specialConditionResultIds">特殊逻辑参数 - 战斗：0-玩家胜利 1-敌人胜利 2-玩家逃跑 3-敌人逃跑 4-玩家死亡 5-敌人死亡 6-敌人被擒</param>
	/// <param name="selfHappinessDiff">双方心情变化 - 玩家</param>
	/// <param name="oppositeHappinessDiff"> - 对方</param>
	/// <param name="selfFavorabilityDiff">双方好感变化 - 玩家对对方</param>
	/// <param name="oppositeFavorabilityDiff"> - 对方对玩家</param>
	/// <param name="selfInfectionDiff">双方入魔变化 - 玩家</param>
	/// <param name="oppositeInfectionDiff"> - 对方</param>
	/// <param name="isFavorabilityCost">是否消耗好感 - 如果为true，则读取对应秘闻中的消耗好感配置</param>
	public SecretInformationAppliedResultItem(short templateId, short innerResultEvent, string resultEventGuid, string resultEventGuidKey, bool endEventAfterJump, bool revealCharacters, string[] texts, short[] selectionIds, List<ShortList> secretInformation, short combatConfigId, bool noGuard, short specialConditionId, List<ShortList> specialConditionResultIds, sbyte selfHappinessDiff, sbyte oppositeHappinessDiff, short selfFavorabilityDiff, short oppositeFavorabilityDiff, sbyte selfInfectionDiff, sbyte oppositeInfectionDiff, bool isFavorabilityCost)
	{
		TemplateId = templateId;
		InnerResultEvent = innerResultEvent;
		ResultEventGuid = resultEventGuid;
		ResultEventGuidKey = resultEventGuidKey;
		EndEventAfterJump = endEventAfterJump;
		RevealCharacters = revealCharacters;
		Texts = texts;
		SelectionIds = selectionIds;
		SecretInformation = secretInformation;
		CombatConfigId = combatConfigId;
		NoGuard = noGuard;
		SpecialConditionId = specialConditionId;
		SpecialConditionResultIds = specialConditionResultIds;
		SelfHappinessDiff = selfHappinessDiff;
		OppositeHappinessDiff = oppositeHappinessDiff;
		SelfFavorabilityDiff = selfFavorabilityDiff;
		OppositeFavorabilityDiff = oppositeFavorabilityDiff;
		SelfInfectionDiff = selfInfectionDiff;
		OppositeInfectionDiff = oppositeInfectionDiff;
		IsFavorabilityCost = isFavorabilityCost;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationAppliedResultItem()
	{
		TemplateId = 0;
		InnerResultEvent = 0;
		ResultEventGuid = null;
		ResultEventGuidKey = null;
		EndEventAfterJump = true;
		RevealCharacters = true;
		Texts = null;
		SelectionIds = new short[0];
		SecretInformation = new List<ShortList>
		{
			new ShortList(-1)
		};
		CombatConfigId = 0;
		NoGuard = false;
		SpecialConditionId = 0;
		SpecialConditionResultIds = new List<ShortList>
		{
			new ShortList(-1)
		};
		SelfHappinessDiff = 0;
		OppositeHappinessDiff = 0;
		SelfFavorabilityDiff = 0;
		OppositeFavorabilityDiff = 0;
		SelfInfectionDiff = 0;
		OppositeInfectionDiff = 0;
		IsFavorabilityCost = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationAppliedResultItem(short templateId, SecretInformationAppliedResultItem other)
	{
		TemplateId = templateId;
		InnerResultEvent = other.InnerResultEvent;
		ResultEventGuid = other.ResultEventGuid;
		ResultEventGuidKey = other.ResultEventGuidKey;
		EndEventAfterJump = other.EndEventAfterJump;
		RevealCharacters = other.RevealCharacters;
		Texts = other.Texts;
		SelectionIds = other.SelectionIds;
		SecretInformation = other.SecretInformation;
		CombatConfigId = other.CombatConfigId;
		NoGuard = other.NoGuard;
		SpecialConditionId = other.SpecialConditionId;
		SpecialConditionResultIds = other.SpecialConditionResultIds;
		SelfHappinessDiff = other.SelfHappinessDiff;
		OppositeHappinessDiff = other.OppositeHappinessDiff;
		SelfFavorabilityDiff = other.SelfFavorabilityDiff;
		OppositeFavorabilityDiff = other.OppositeFavorabilityDiff;
		SelfInfectionDiff = other.SelfInfectionDiff;
		OppositeInfectionDiff = other.OppositeInfectionDiff;
		IsFavorabilityCost = other.IsFavorabilityCost;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationAppliedResultItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedResultItem((short)templateId, this);
	}
}
