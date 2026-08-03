using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationEffectItem : ConfigItem<SecretInformationEffectItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 秘闻名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 行为人
	/// - 人物或物品对应的主表参序号，主要为保障数据安全，和后面条件指定的关联人序列不一样。关联人指定：0行为人，1接收方1,2接收方2,3参与判定的其他非当事人人物，4涉及物品类型。注意：请在清楚自己干什么的前提下使用序列3和4。
	/// </summary>
	public readonly int ActorIndex;

	/// <summary>
	/// 接受者1
	/// </summary>
	public readonly int ReactorIndex;

	/// <summary>
	/// 接受者2
	/// </summary>
	public readonly int SecactorIndex;

	/// <summary>
	/// 涉及物品
	/// </summary>
	public readonly int Item;

	public readonly sbyte[] ActorHappinessDiffs;

	public readonly sbyte[] ReactorHappinessDiffs;

	public readonly sbyte[] SecactorHappinessDiffs;

	public readonly List<ShortList> ActorFavorabilityDiffs;

	public readonly List<ShortList> ReactorFavorabilityDiffs;

	public readonly List<ShortList> SecactorFavorabilityDiffs;

	public readonly List<ShortList> ActorFriendFavorabilityDiffs;

	public readonly List<ShortList> ActorEnemyFavorabilityDiffs;

	public readonly List<ShortList> ReactorFriendFavorabilityDiffs;

	public readonly List<ShortList> ReactorEnemyFavorabilityDiffs;

	public readonly List<ShortList> SecactorFriendFavorabilityDiffs;

	public readonly List<ShortList> SecactorEnemyFavorabilityDiffs;

	public readonly List<ShortList> OtherFavorabilityDiffs;

	/// <summary>
	/// 判断对象
	/// - 判断对象的数量和位置必须和特殊情况对应。0-行为方，1-接受人1,2-接受人2,3-非行为人的受判定对象，4-涉及物品的类型，这里可以用3，但是请清楚知道自己要判定什么……
	/// </summary>
	public readonly List<ShortList> SpecialConditionIndices;

	/// <summary>
	/// 特殊情况
	/// - 当有特殊情况时，不再作用普通情况下的好感变化，而是依次判断特殊情况，并依次按特殊情况百分比，作用特殊情况下的好感变化
	/// </summary>
	public readonly List<ShortList> SpecialConditionFavorabilities;

	public readonly List<ShortList> ActorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ActorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ActorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> OtherFavorabilityDiffsWhenSpecial;

	/// <summary>
	/// 行为人名誉词条应用条件
	/// - {{名誉词条,特殊条件,特殊条件的判定内容}}
	/// </summary>
	public readonly List<ShortList> ActorFameApplyCondition;

	/// <summary>
	/// 行为人名誉词条内容
	/// - {{名誉词条,名誉词条的关联人,层数}},当为违法犯罪的名誉时，应用的层数=惩罚等级*此处填写的参数
	/// </summary>
	public readonly List<ShortList> ActorFameApplyContent;

	/// <summary>
	/// 接受者1名誉词条应用条件
	/// </summary>
	public readonly List<ShortList> ReactorFameApplyCondition;

	/// <summary>
	/// 接受者1名誉词条内容
	/// </summary>
	public readonly List<ShortList> ReactorFameApplyContent;

	/// <summary>
	/// 接受者2名誉词条应用条件
	/// </summary>
	public readonly List<ShortList> SeactorFameApplyCondition;

	/// <summary>
	/// 接受者2名誉词条内容
	/// </summary>
	public readonly List<ShortList> SecactorFameApplyContent;

	/// <summary>
	/// 基础概率
	/// - 基础概率：对本秘闻的行为方使用秘闻时，行为方无条件要求保密的概率；叠加概率：当满足对应的特殊条件时，行为方要求保密的附加概率；总概率=(基础概率+叠加概率)*(100-(人物对玩家的好感等级-2)*20)/100
	/// </summary>
	public readonly short[] BaseSecretRate;

	/// <summary>
	/// 战斗类型
	/// </summary>
	public readonly short CombatType;

	/// <summary>
	/// 引战概率
	/// - 拒绝保密时，人物发起战斗的概率；可以是恶斗，玩家在恶斗或死斗中失败（且仅有失败）会导致秘闻被删除
	/// </summary>
	public readonly short[] KillingProbOfRefuseKeepSecret;

	/// <summary>
	/// 对方删除秘闻
	/// - 触发结果事件时，对方对玩家的好感变化
	/// </summary>
	public readonly short[] OppositeFavorabilityDiffsWhenResult;

	/// <summary>
	/// 行为人
	/// - 用于穿针引线互动
	/// </summary>
	public readonly int JudgementOfActor;

	/// <summary>
	/// 接受者1
	/// </summary>
	public readonly int JudgementOfReactor;

	/// <summary>
	/// 接受者2
	/// </summary>
	public readonly int JudgementOfSecactor;

	public readonly List<byte> StartEnemyRelationOddsToActor;

	public readonly List<byte> StartEnemyRelationOddsToReactor;

	public readonly List<byte> StartEnemyRelationOddsToSecactor;

	public readonly List<byte> StartEnemyRelationOddsToSource;

	public readonly List<ShortList> AlertnessEffectToActor;

	public readonly List<ShortList> AlertnessEffectToReactor;

	public readonly List<ShortList> AlertnessEffectToReactor2;

	public readonly List<ShortList> AlertnessEffectToSource;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">秘闻名称</param>
	/// <param name="actorIndex">行为人 - 人物或物品对应的主表参序号，主要为保障数据安全，和后面条件指定的关联人序列不一样。关联人指定：0行为人，1接收方1,2接收方2,3参与判定的其他非当事人人物，4涉及物品类型。注意：请在清楚自己干什么的前提下使用序列3和4。</param>
	/// <param name="reactorIndex">接受者1</param>
	/// <param name="secactorIndex">接受者2</param>
	/// <param name="item">涉及物品</param>
	/// <param name="actorHappinessDiffs"></param>
	/// <param name="reactorHappinessDiffs"></param>
	/// <param name="secactorHappinessDiffs"></param>
	/// <param name="actorFavorabilityDiffs"></param>
	/// <param name="reactorFavorabilityDiffs"></param>
	/// <param name="secactorFavorabilityDiffs"></param>
	/// <param name="actorFriendFavorabilityDiffs"></param>
	/// <param name="actorEnemyFavorabilityDiffs"></param>
	/// <param name="reactorFriendFavorabilityDiffs"></param>
	/// <param name="reactorEnemyFavorabilityDiffs"></param>
	/// <param name="secactorFriendFavorabilityDiffs"></param>
	/// <param name="secactorEnemyFavorabilityDiffs"></param>
	/// <param name="otherFavorabilityDiffs"></param>
	/// <param name="specialConditionIndices">判断对象 - 判断对象的数量和位置必须和特殊情况对应。0-行为方，1-接受人1,2-接受人2,3-非行为人的受判定对象，4-涉及物品的类型，这里可以用3，但是请清楚知道自己要判定什么……</param>
	/// <param name="specialConditionFavorabilities">特殊情况 - 当有特殊情况时，不再作用普通情况下的好感变化，而是依次判断特殊情况，并依次按特殊情况百分比，作用特殊情况下的好感变化</param>
	/// <param name="actorFavorabilityDiffsWhenSpecial"></param>
	/// <param name="reactorFavorabilityDiffsWhenSpecial"></param>
	/// <param name="secactorFavorabilityDiffsWhenSpecial"></param>
	/// <param name="actorFriendFavorabilityDiffsWhenSpecial"></param>
	/// <param name="actorEnemyFavorabilityDiffsWhenSpecial"></param>
	/// <param name="reactorFriendFavorabilityDiffsWhenSpecial"></param>
	/// <param name="reactorEnemyFavorabilityDiffsWhenSpecial"></param>
	/// <param name="secactorFriendFavorabilityDiffsWhenSpecial"></param>
	/// <param name="secactorEnemyFavorabilityDiffsWhenSpecial"></param>
	/// <param name="otherFavorabilityDiffsWhenSpecial"></param>
	/// <param name="actorFameApplyCondition">行为人名誉词条应用条件 - {{名誉词条,特殊条件,特殊条件的判定内容}}</param>
	/// <param name="actorFameApplyContent">行为人名誉词条内容 - {{名誉词条,名誉词条的关联人,层数}},当为违法犯罪的名誉时，应用的层数=惩罚等级*此处填写的参数</param>
	/// <param name="reactorFameApplyCondition">接受者1名誉词条应用条件</param>
	/// <param name="reactorFameApplyContent">接受者1名誉词条内容</param>
	/// <param name="seactorFameApplyCondition">接受者2名誉词条应用条件</param>
	/// <param name="secactorFameApplyContent">接受者2名誉词条内容</param>
	/// <param name="baseSecretRate">基础概率 - 基础概率：对本秘闻的行为方使用秘闻时，行为方无条件要求保密的概率；叠加概率：当满足对应的特殊条件时，行为方要求保密的附加概率；总概率=(基础概率+叠加概率)*(100-(人物对玩家的好感等级-2)*20)/100</param>
	/// <param name="combatType">战斗类型</param>
	/// <param name="killingProbOfRefuseKeepSecret">引战概率 - 拒绝保密时，人物发起战斗的概率；可以是恶斗，玩家在恶斗或死斗中失败（且仅有失败）会导致秘闻被删除</param>
	/// <param name="oppositeFavorabilityDiffsWhenResult">对方删除秘闻 - 触发结果事件时，对方对玩家的好感变化</param>
	/// <param name="judgementOfActor">行为人 - 用于穿针引线互动</param>
	/// <param name="judgementOfReactor">接受者1</param>
	/// <param name="judgementOfSecactor">接受者2</param>
	/// <param name="startEnemyRelationOddsToActor"></param>
	/// <param name="startEnemyRelationOddsToReactor"></param>
	/// <param name="startEnemyRelationOddsToSecactor"></param>
	/// <param name="startEnemyRelationOddsToSource"></param>
	/// <param name="alertnessEffectToActor"></param>
	/// <param name="alertnessEffectToReactor"></param>
	/// <param name="alertnessEffectToReactor2"></param>
	/// <param name="alertnessEffectToSource"></param>
	public SecretInformationEffectItem(short templateId, string name, int actorIndex, int reactorIndex, int secactorIndex, int item, sbyte[] actorHappinessDiffs, sbyte[] reactorHappinessDiffs, sbyte[] secactorHappinessDiffs, List<ShortList> actorFavorabilityDiffs, List<ShortList> reactorFavorabilityDiffs, List<ShortList> secactorFavorabilityDiffs, List<ShortList> actorFriendFavorabilityDiffs, List<ShortList> actorEnemyFavorabilityDiffs, List<ShortList> reactorFriendFavorabilityDiffs, List<ShortList> reactorEnemyFavorabilityDiffs, List<ShortList> secactorFriendFavorabilityDiffs, List<ShortList> secactorEnemyFavorabilityDiffs, List<ShortList> otherFavorabilityDiffs, List<ShortList> specialConditionIndices, List<ShortList> specialConditionFavorabilities, List<ShortList> actorFavorabilityDiffsWhenSpecial, List<ShortList> reactorFavorabilityDiffsWhenSpecial, List<ShortList> secactorFavorabilityDiffsWhenSpecial, List<ShortList> actorFriendFavorabilityDiffsWhenSpecial, List<ShortList> actorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> reactorFriendFavorabilityDiffsWhenSpecial, List<ShortList> reactorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> secactorFriendFavorabilityDiffsWhenSpecial, List<ShortList> secactorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> otherFavorabilityDiffsWhenSpecial, List<ShortList> actorFameApplyCondition, List<ShortList> actorFameApplyContent, List<ShortList> reactorFameApplyCondition, List<ShortList> reactorFameApplyContent, List<ShortList> seactorFameApplyCondition, List<ShortList> secactorFameApplyContent, short[] baseSecretRate, short combatType, short[] killingProbOfRefuseKeepSecret, short[] oppositeFavorabilityDiffsWhenResult, int judgementOfActor, int judgementOfReactor, int judgementOfSecactor, List<byte> startEnemyRelationOddsToActor, List<byte> startEnemyRelationOddsToReactor, List<byte> startEnemyRelationOddsToSecactor, List<byte> startEnemyRelationOddsToSource, List<ShortList> alertnessEffectToActor, List<ShortList> alertnessEffectToReactor, List<ShortList> alertnessEffectToReactor2, List<ShortList> alertnessEffectToSource)
	{
		TemplateId = templateId;
		Name = name;
		ActorIndex = actorIndex;
		ReactorIndex = reactorIndex;
		SecactorIndex = secactorIndex;
		Item = item;
		ActorHappinessDiffs = actorHappinessDiffs;
		ReactorHappinessDiffs = reactorHappinessDiffs;
		SecactorHappinessDiffs = secactorHappinessDiffs;
		ActorFavorabilityDiffs = actorFavorabilityDiffs;
		ReactorFavorabilityDiffs = reactorFavorabilityDiffs;
		SecactorFavorabilityDiffs = secactorFavorabilityDiffs;
		ActorFriendFavorabilityDiffs = actorFriendFavorabilityDiffs;
		ActorEnemyFavorabilityDiffs = actorEnemyFavorabilityDiffs;
		ReactorFriendFavorabilityDiffs = reactorFriendFavorabilityDiffs;
		ReactorEnemyFavorabilityDiffs = reactorEnemyFavorabilityDiffs;
		SecactorFriendFavorabilityDiffs = secactorFriendFavorabilityDiffs;
		SecactorEnemyFavorabilityDiffs = secactorEnemyFavorabilityDiffs;
		OtherFavorabilityDiffs = otherFavorabilityDiffs;
		SpecialConditionIndices = specialConditionIndices;
		SpecialConditionFavorabilities = specialConditionFavorabilities;
		ActorFavorabilityDiffsWhenSpecial = actorFavorabilityDiffsWhenSpecial;
		ReactorFavorabilityDiffsWhenSpecial = reactorFavorabilityDiffsWhenSpecial;
		SecactorFavorabilityDiffsWhenSpecial = secactorFavorabilityDiffsWhenSpecial;
		ActorFriendFavorabilityDiffsWhenSpecial = actorFriendFavorabilityDiffsWhenSpecial;
		ActorEnemyFavorabilityDiffsWhenSpecial = actorEnemyFavorabilityDiffsWhenSpecial;
		ReactorFriendFavorabilityDiffsWhenSpecial = reactorFriendFavorabilityDiffsWhenSpecial;
		ReactorEnemyFavorabilityDiffsWhenSpecial = reactorEnemyFavorabilityDiffsWhenSpecial;
		SecactorFriendFavorabilityDiffsWhenSpecial = secactorFriendFavorabilityDiffsWhenSpecial;
		SecactorEnemyFavorabilityDiffsWhenSpecial = secactorEnemyFavorabilityDiffsWhenSpecial;
		OtherFavorabilityDiffsWhenSpecial = otherFavorabilityDiffsWhenSpecial;
		ActorFameApplyCondition = actorFameApplyCondition;
		ActorFameApplyContent = actorFameApplyContent;
		ReactorFameApplyCondition = reactorFameApplyCondition;
		ReactorFameApplyContent = reactorFameApplyContent;
		SeactorFameApplyCondition = seactorFameApplyCondition;
		SecactorFameApplyContent = secactorFameApplyContent;
		BaseSecretRate = baseSecretRate;
		CombatType = combatType;
		KillingProbOfRefuseKeepSecret = killingProbOfRefuseKeepSecret;
		OppositeFavorabilityDiffsWhenResult = oppositeFavorabilityDiffsWhenResult;
		JudgementOfActor = judgementOfActor;
		JudgementOfReactor = judgementOfReactor;
		JudgementOfSecactor = judgementOfSecactor;
		StartEnemyRelationOddsToActor = startEnemyRelationOddsToActor;
		StartEnemyRelationOddsToReactor = startEnemyRelationOddsToReactor;
		StartEnemyRelationOddsToSecactor = startEnemyRelationOddsToSecactor;
		StartEnemyRelationOddsToSource = startEnemyRelationOddsToSource;
		AlertnessEffectToActor = alertnessEffectToActor;
		AlertnessEffectToReactor = alertnessEffectToReactor;
		AlertnessEffectToReactor2 = alertnessEffectToReactor2;
		AlertnessEffectToSource = alertnessEffectToSource;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationEffectItem()
	{
		TemplateId = 0;
		Name = null;
		ActorIndex = -1;
		ReactorIndex = -1;
		SecactorIndex = -1;
		Item = -1;
		ActorHappinessDiffs = null;
		ReactorHappinessDiffs = null;
		SecactorHappinessDiffs = null;
		ActorFavorabilityDiffs = null;
		ReactorFavorabilityDiffs = null;
		SecactorFavorabilityDiffs = null;
		ActorFriendFavorabilityDiffs = null;
		ActorEnemyFavorabilityDiffs = null;
		ReactorFriendFavorabilityDiffs = null;
		ReactorEnemyFavorabilityDiffs = null;
		SecactorFriendFavorabilityDiffs = null;
		SecactorEnemyFavorabilityDiffs = null;
		OtherFavorabilityDiffs = null;
		SpecialConditionIndices = new List<ShortList>
		{
			new ShortList()
		};
		SpecialConditionFavorabilities = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorFavorabilityDiffsWhenSpecial = null;
		ReactorFavorabilityDiffsWhenSpecial = null;
		SecactorFavorabilityDiffsWhenSpecial = null;
		ActorFriendFavorabilityDiffsWhenSpecial = null;
		ActorEnemyFavorabilityDiffsWhenSpecial = null;
		ReactorFriendFavorabilityDiffsWhenSpecial = null;
		ReactorEnemyFavorabilityDiffsWhenSpecial = null;
		SecactorFriendFavorabilityDiffsWhenSpecial = null;
		SecactorEnemyFavorabilityDiffsWhenSpecial = null;
		OtherFavorabilityDiffsWhenSpecial = null;
		ActorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		SeactorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		BaseSecretRate = new short[5];
		CombatType = 0;
		KillingProbOfRefuseKeepSecret = new short[5];
		OppositeFavorabilityDiffsWhenResult = new short[5];
		JudgementOfActor = 999;
		JudgementOfReactor = 999;
		JudgementOfSecactor = 999;
		StartEnemyRelationOddsToActor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToReactor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToSecactor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToSource = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		AlertnessEffectToActor = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToReactor = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToReactor2 = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToSource = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationEffectItem(short templateId, SecretInformationEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ActorIndex = other.ActorIndex;
		ReactorIndex = other.ReactorIndex;
		SecactorIndex = other.SecactorIndex;
		Item = other.Item;
		ActorHappinessDiffs = other.ActorHappinessDiffs;
		ReactorHappinessDiffs = other.ReactorHappinessDiffs;
		SecactorHappinessDiffs = other.SecactorHappinessDiffs;
		ActorFavorabilityDiffs = other.ActorFavorabilityDiffs;
		ReactorFavorabilityDiffs = other.ReactorFavorabilityDiffs;
		SecactorFavorabilityDiffs = other.SecactorFavorabilityDiffs;
		ActorFriendFavorabilityDiffs = other.ActorFriendFavorabilityDiffs;
		ActorEnemyFavorabilityDiffs = other.ActorEnemyFavorabilityDiffs;
		ReactorFriendFavorabilityDiffs = other.ReactorFriendFavorabilityDiffs;
		ReactorEnemyFavorabilityDiffs = other.ReactorEnemyFavorabilityDiffs;
		SecactorFriendFavorabilityDiffs = other.SecactorFriendFavorabilityDiffs;
		SecactorEnemyFavorabilityDiffs = other.SecactorEnemyFavorabilityDiffs;
		OtherFavorabilityDiffs = other.OtherFavorabilityDiffs;
		SpecialConditionIndices = other.SpecialConditionIndices;
		SpecialConditionFavorabilities = other.SpecialConditionFavorabilities;
		ActorFavorabilityDiffsWhenSpecial = other.ActorFavorabilityDiffsWhenSpecial;
		ReactorFavorabilityDiffsWhenSpecial = other.ReactorFavorabilityDiffsWhenSpecial;
		SecactorFavorabilityDiffsWhenSpecial = other.SecactorFavorabilityDiffsWhenSpecial;
		ActorFriendFavorabilityDiffsWhenSpecial = other.ActorFriendFavorabilityDiffsWhenSpecial;
		ActorEnemyFavorabilityDiffsWhenSpecial = other.ActorEnemyFavorabilityDiffsWhenSpecial;
		ReactorFriendFavorabilityDiffsWhenSpecial = other.ReactorFriendFavorabilityDiffsWhenSpecial;
		ReactorEnemyFavorabilityDiffsWhenSpecial = other.ReactorEnemyFavorabilityDiffsWhenSpecial;
		SecactorFriendFavorabilityDiffsWhenSpecial = other.SecactorFriendFavorabilityDiffsWhenSpecial;
		SecactorEnemyFavorabilityDiffsWhenSpecial = other.SecactorEnemyFavorabilityDiffsWhenSpecial;
		OtherFavorabilityDiffsWhenSpecial = other.OtherFavorabilityDiffsWhenSpecial;
		ActorFameApplyCondition = other.ActorFameApplyCondition;
		ActorFameApplyContent = other.ActorFameApplyContent;
		ReactorFameApplyCondition = other.ReactorFameApplyCondition;
		ReactorFameApplyContent = other.ReactorFameApplyContent;
		SeactorFameApplyCondition = other.SeactorFameApplyCondition;
		SecactorFameApplyContent = other.SecactorFameApplyContent;
		BaseSecretRate = other.BaseSecretRate;
		CombatType = other.CombatType;
		KillingProbOfRefuseKeepSecret = other.KillingProbOfRefuseKeepSecret;
		OppositeFavorabilityDiffsWhenResult = other.OppositeFavorabilityDiffsWhenResult;
		JudgementOfActor = other.JudgementOfActor;
		JudgementOfReactor = other.JudgementOfReactor;
		JudgementOfSecactor = other.JudgementOfSecactor;
		StartEnemyRelationOddsToActor = other.StartEnemyRelationOddsToActor;
		StartEnemyRelationOddsToReactor = other.StartEnemyRelationOddsToReactor;
		StartEnemyRelationOddsToSecactor = other.StartEnemyRelationOddsToSecactor;
		StartEnemyRelationOddsToSource = other.StartEnemyRelationOddsToSource;
		AlertnessEffectToActor = other.AlertnessEffectToActor;
		AlertnessEffectToReactor = other.AlertnessEffectToReactor;
		AlertnessEffectToReactor2 = other.AlertnessEffectToReactor2;
		AlertnessEffectToSource = other.AlertnessEffectToSource;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationEffectItem Duplicate(int templateId)
	{
		return new SecretInformationEffectItem((short)templateId, this);
	}
}
