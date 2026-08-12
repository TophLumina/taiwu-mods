using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.ExchangeSystem;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class ExchangeAdvantage : ISerializableGameData
{
	/// <summary>
	/// 交换类型
	/// </summary>
	[SerializableGameDataField]
	public EExchangeType ExchangeType = EExchangeType.Invalid;

	/// <summary>
	/// Npc定居点信息，对库房，定居点信息会显示为守卫的信息
	/// </summary>
	[SerializableGameDataField]
	public OrganizationInfo NpcOrganization;

	/// <summary>
	/// 对方id，用于计算秘闻
	/// </summary>
	[SerializableGameDataField]
	public int TargetCharId = -1;

	/// <summary>
	/// Npc对太吾好感等级
	/// </summary>
	[SerializableGameDataField]
	public int TargetBaseValue;

	/// <summary>
	/// Npc对太吾好感等级
	/// </summary>
	[SerializableGameDataField]
	public int TargetFavorType;

	/// <summary>
	/// Npc对太吾戒心等级
	/// </summary>
	[SerializableGameDataField]
	public int TargetAlertLevel;

	/// <summary>
	/// Npc立场
	/// </summary>
	[SerializableGameDataField]
	public int TargetBehaviorType;

	/// <summary>
	/// 太吾立场
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuBehaviorType;

	/// <summary>
	/// 太吾名誉
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuFameType;

	/// <summary>
	/// 库房匮乏
	/// </summary>
	[SerializableGameDataField]
	public int TargetLackResourceValue;

	/// <summary>
	/// Npc类型
	/// </summary>
	[SerializableGameDataField]
	public ETargetType TargetType;

	/// <summary>
	/// 额外优势值，由外部直接计算
	/// </summary>
	[SerializableGameDataField]
	public int TargetExtraValue;

	/// <summary>
	/// 喜爱物品子类型
	/// </summary>
	[SerializableGameDataField]
	public short LovingItemSubType = -1;

	/// <summary>
	/// 厌恶物品子类型
	/// </summary>
	[SerializableGameDataField]
	public short HatingItemSubType = -1;

	/// <summary>
	/// 关联人物
	/// </summary>
	[SerializableGameDataField]
	public RelatedCharacters RelatedCharIds;

	private static readonly LanguageKey[] Numbers = new LanguageKey[10]
	{
		LanguageKey.LK_Num_0,
		LanguageKey.LK_Num_1,
		LanguageKey.LK_Num_2,
		LanguageKey.LK_Num_3,
		LanguageKey.LK_Num_4,
		LanguageKey.LK_Num_5,
		LanguageKey.LK_Num_6,
		LanguageKey.LK_Num_7,
		LanguageKey.LK_Num_8,
		LanguageKey.LK_Num_9
	};

	/// <summary>
	/// 秘闻优势值
	/// </summary>
	[SerializableGameDataField]
	public int SecretValue;

	/// <summary>
	/// 秘闻id
	/// </summary>
	[SerializableGameDataField]
	public int SecretId;

	/// <summary>
	/// 支持度
	/// </summary>
	[SerializableGameDataField]
	public int ApprovingValue;

	/// <summary>
	/// 提供支持度的Npc
	/// </summary>
	[SerializableGameDataField]
	public int ApprovingCharId;

	/// <summary>
	/// 提供的地区恩义
	/// </summary>
	[SerializableGameDataField]
	public int DebtUsed;

	/// <summary>
	/// 使用此地区的恩义
	/// </summary>
	[SerializableGameDataField]
	public int TradeAreaId;

	/// <summary>
	/// 最大可消耗地区恩义
	/// </summary>
	[SerializableGameDataField]
	public int DebtMax;

	/// <summary>
	/// 任务Id
	/// </summary>
	[SerializableGameDataField]
	public int[] TaskId;

	/// <summary>
	/// 任务提供的太吾优势值，非负
	/// 需要根据任务列表与物品列表重算
	/// </summary>
	public int TaiwuTaskEffect;

	/// <summary>
	/// 任务提供的Npc优势值，非负
	/// 需要根据任务列表与物品列表重算
	/// </summary>
	public int TargetTaskEffect;

	/// <summary>
	/// 任务字典，前端直接计算
	/// </summary>
	public Dictionary<int, int> TaskDict = new Dictionary<int, int>();

	public bool Enabled
	{
		get
		{
			EExchangeType exchangeType = ExchangeType;
			if (exchangeType == EExchangeType.Person || exchangeType == EExchangeType.Settlement)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// 获取太吾id的简便调用，用于计算秘闻
	/// </summary>
	public int TaiwuCharId => ExternalDataBridge.Context.TaiwuCharId;

	public int FavorValue
	{
		get
		{
			int[] exchangeFavorLevel = GlobalConfig.Instance.ExchangeFavorLevel;
			return exchangeFavorLevel[TargetFavorType switch
			{
				6 => 0, 
				5 => 1, 
				4 => 2, 
				3 => 3, 
				2 => 4, 
				1 => 5, 
				0 => 6, 
				-1 => 7, 
				-2 => 8, 
				-3 => 9, 
				-4 => 10, 
				-5 => 11, 
				-6 => 12, 
				_ => throw new Exception($"Unknown FavorabilityType: {TargetFavorType}"), 
			}];
		}
	}

	public int AlertValue
	{
		get
		{
			int[] exchangeAlertnessLevel = GlobalConfig.Instance.ExchangeAlertnessLevel;
			return exchangeAlertnessLevel[TargetAlertLevel switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				_ => throw new Exception($"Unknown AlertLevel: {TargetAlertLevel}"), 
			}];
		}
	}

	public int BehaviorValue
	{
		get
		{
			if (!GameData.Domains.Character.BehaviorType.IsHarmonious((sbyte)TargetBehaviorType, (sbyte)TaiwuBehaviorType))
			{
				if (!GameData.Domains.Character.BehaviorType.IsConflicting((sbyte)TargetBehaviorType, (sbyte)TaiwuBehaviorType))
				{
					return GlobalConfig.Instance.ExchangeMoralitySimilar;
				}
				return GlobalConfig.Instance.ExchangeMoralityOpposite;
			}
			return GlobalConfig.Instance.ExchangeMoralitySame;
		}
	}

	public int FameValue
	{
		get
		{
			int[] array;
			switch (TargetType)
			{
			case ETargetType.GoodNpc:
			case ETargetType.GoodSect:
				array = GlobalConfig.Instance.ExchangeFameValueForGood;
				break;
			case ETargetType.NeutralNpc:
			case ETargetType.NeutralSect:
			case ETargetType.TownNpc:
			case ETargetType.Town:
				array = GlobalConfig.Instance.ExchangeFameValueForNeutral;
				break;
			case ETargetType.EvilNpc:
			case ETargetType.EvilSect:
				array = GlobalConfig.Instance.ExchangeFameValueForBad;
				break;
			default:
				throw new Exception($"Unknown NpcType: {TargetType}");
			}
			int[] array2 = array;
			int num;
			switch (TaiwuFameType)
			{
			case 6:
				num = 0;
				break;
			case 5:
				num = 1;
				break;
			case 4:
				num = 2;
				break;
			case -2:
			case 3:
				num = 3;
				break;
			case 2:
				num = 4;
				break;
			case 1:
				num = 5;
				break;
			case 0:
				num = 6;
				break;
			default:
				throw new Exception($"Unknown TaiwuFameLevel: {TaiwuFameType}");
			}
			return array2[num];
		}
	}

	/// <summary>
	/// 展示用，基础值
	/// </summary>
	public int RawTargetAdvantage => Math.Max(0, TargetBaseValue + FavorValue + AlertValue + BehaviorValue + FameValue + TargetExtraValue + GlobalConfig.Instance.ExchangeGradeOverProgress[OverGrade] + TargetTaskEffect + ChallengeValue + TargetLackResourceValue);

	/// <summary>
	/// 计算用，最终值
	/// </summary>
	public int TargetAdvantage
	{
		get
		{
			if (!Enabled)
			{
				return 100;
			}
			return ExternalDataBridge.Context.ChallengeModeData.ApplyExchangeTargetAdvantageBonus(RawTargetAdvantage);
		}
	}

	/// <summary>
	/// 敝帚自珍加成
	/// </summary>
	public int ChallengeValue
	{
		get
		{
			if (ExternalDataBridge.Context.ChallengeModeData.IsEnabled(EChallengeModeImplement.ExchangeGrade))
			{
				return ExchangeType switch
				{
					EExchangeType.Person => GlobalConfig.Instance.ChallengeExchangeGradeBonusNpc[NpcOrganization.Grade], 
					EExchangeType.Settlement => GlobalConfig.Instance.ChallengeExchangeGradeBonusTreasury[NpcOrganization.Grade], 
					_ => 0, 
				};
			}
			return 0;
		}
	}

	/// <summary>
	/// 超世界进度导致的Npc优势增加index
	/// 仅对Npc生效！（TAIWU-76728）
	/// </summary>
	public int OverGrade
	{
		get
		{
			if (ExchangeType != EExchangeType.Person)
			{
				return 0;
			}
			return Math.Max(0, NpcOrganization.Grade - ExternalDataBridge.Context.XiangshuProgress / 2);
		}
	}

	/// <summary>
	/// 使用恩义带来的优势
	/// </summary>
	public int DebtValue => DebtUsed / GlobalConfig.Instance.ExchangeDebtUnit;

	/// <summary>
	/// 太吾自身优势
	/// </summary>
	public int TaiwuAdvantage
	{
		get
		{
			if (!Enabled)
			{
				return 100;
			}
			return Math.Max(0, GlobalConfig.Instance.ExchangeBaseTaiwu + SecretValue + ApprovingValue + DebtValue + TaiwuTaskEffect);
		}
	}

	/// <summary>
	/// 防止手动序列化报错
	/// </summary>
	public ExchangeAdvantage()
	{
	}

	/// <summary>
	/// 初始化太吾部分，不应调用
	/// </summary>
	/// <param name="taiwuBehaviorType"></param>
	/// <param name="taiwuFameType"></param>
	private ExchangeAdvantage(int taiwuBehaviorType, int taiwuFameType, int tradeAreaId, int debtMax)
	{
		TaiwuBehaviorType = taiwuBehaviorType;
		TaiwuFameType = taiwuFameType;
		TradeAreaId = tradeAreaId;
		DebtMax = debtMax;
		SecretId = -1;
		ApprovingCharId = -1;
	}

	/// <summary>
	/// 人物交换
	/// </summary>
	/// <param name="npcOrganization"></param>
	/// <param name="targetFavorType"></param>
	/// <param name="targetAlertLevel"></param>
	/// <param name="targetBehaviorType"></param>
	/// <param name="targetFameType"></param>
	/// <param name="taiwuBehaviorType"></param>
	/// <param name="taiwuFameType"></param>
	public ExchangeAdvantage(int taiwuBehaviorType, int taiwuFameType, int tradeAreaId, int debtMax, int targetCharId, OrganizationInfo npcOrganization, RelatedCharacters relatedCharIds, int targetFavorType, int targetAlertLevel, int targetBehaviorType, int targetFameType, CharacterLoveAndHateItemInfo info = null)
		: this(taiwuBehaviorType, taiwuFameType, tradeAreaId, debtMax)
	{
		ExchangeType = EExchangeType.Person;
		RelatedCharIds = relatedCharIds;
		LovingItemSubType = info?.LovingItemSubType ?? (-1);
		HatingItemSubType = info?.HatingItemSubType ?? (-1);
		TargetFavorType = targetFavorType;
		TargetAlertLevel = targetAlertLevel;
		TargetBehaviorType = targetBehaviorType;
		TargetCharId = targetCharId;
		OrganizationInfo organizationInfo = (NpcOrganization = npcOrganization);
		sbyte orgTemplateId = organizationInfo.OrgTemplateId;
		TargetBaseValue = (((uint)(orgTemplateId - 1) <= 14u) ? GlobalConfig.Instance.ExchangeBaseSectNpc : GlobalConfig.Instance.ExchangeBaseNormalNpc);
		ETargetType targetType;
		switch (npcOrganization.OrgTemplateId)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			targetType = ETargetType.GoodNpc;
			break;
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			targetType = ETargetType.NeutralNpc;
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			targetType = ETargetType.EvilNpc;
			break;
		default:
			targetType = ETargetType.TownNpc;
			break;
		}
		TargetType = targetType;
		TargetExtraValue = (((npcOrganization.OrgTemplateId == 1 && ExternalDataBridge.Context.TaiwuGender != 1 && ExternalDataBridge.Context.TaiwuDisplayingGender != 1) || (npcOrganization.OrgTemplateId == 8 && ExternalDataBridge.Context.TaiwuGender != 0 && ExternalDataBridge.Context.TaiwuDisplayingGender != 0)) ? GlobalConfig.Instance.ExchangeSpecialGender : 0);
		TaskId = (from x in ExchangeTask.Instance.Where(delegate(ExchangeTaskItem item)
			{
				if (item.ForCharacter)
				{
					short[] meetOrganization = item.MeetOrganization;
					if (meetOrganization == null || Enumerable.Contains(meetOrganization, npcOrganization.OrgTemplateId))
					{
						sbyte[] meetBehaviourType = item.MeetBehaviourType;
						if (meetBehaviourType == null || Enumerable.Contains(meetBehaviourType, (sbyte)targetBehaviorType))
						{
							sbyte[] meetGrade = item.MeetGrade;
							if (meetGrade == null || Enumerable.Contains(meetGrade, npcOrganization.Grade))
							{
								return item.MeetFameLevel?.Contains((sbyte)targetFameType) ?? true;
							}
						}
					}
				}
				return false;
			})
			select x.TemplateId).ToArray();
	}

	/// <summary>
	/// 库房交换
	/// </summary>
	/// <param name="taiwuBehaviorType"></param>
	/// <param name="taiwuFameType"></param>
	/// <param name="tradeAreaId"></param>
	/// <param name="debtMax"></param>
	/// <param name="npcOrganization"></param>
	/// <param name="isLackResource"></param>
	public ExchangeAdvantage(int taiwuBehaviorType, int taiwuFameType, int tradeAreaId, int debtMax, OrganizationInfo npcOrganization, bool isLackResource)
		: this(taiwuBehaviorType, taiwuFameType, tradeAreaId, debtMax)
	{
		ExchangeType = EExchangeType.Settlement;
		TargetFavorType = 6;
		TargetAlertLevel = 0;
		TargetBaseValue = GlobalConfig.Instance.ExchangeBaseTreasury;
		NpcOrganization = npcOrganization;
		ETargetType targetType;
		switch (npcOrganization.OrgTemplateId)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			targetType = ETargetType.GoodSect;
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			targetType = ETargetType.EvilSect;
			break;
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			targetType = ETargetType.NeutralSect;
			break;
		default:
			targetType = ETargetType.Town;
			break;
		}
		TargetType = targetType;
		TargetExtraValue = (((npcOrganization.OrgTemplateId == 1 && ExternalDataBridge.Context.TaiwuGender != 1 && ExternalDataBridge.Context.TaiwuDisplayingGender != 1) || (npcOrganization.OrgTemplateId == 8 && ExternalDataBridge.Context.TaiwuGender != 0 && ExternalDataBridge.Context.TaiwuDisplayingGender != 0)) ? GlobalConfig.Instance.ExchangeSpecialGender : 0);
		TargetLackResourceValue = (isLackResource ? GlobalConfig.Instance.ExchangeSpecialLackResource : 0);
		TaskId = (from x in ExchangeTask.Instance
			where x.ForTreasury && (x.MeetOrganization?.Contains(npcOrganization.OrgTemplateId) ?? true)
			select x.TemplateId).ToArray();
	}

	public string TargetAdvantageDesc(long totalValue, long totalValueWithAdvantage)
	{
		return string.Join("\n", from x in new(string, int)[11]
			{
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_0), TargetBaseValue),
				(LocalStringManager.GetFormat(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_Grade, GlobalConfig.Instance.ExchangeGradeOverProgress[OverGrade], LocalStringManager.Get(Numbers[OverGrade])), OverGrade),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_5), TargetTaskEffect),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_1), FavorValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_2), AlertValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_3), BehaviorValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_4), FameValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_9), TargetExtraValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_10), TargetLackResourceValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_Challenge), ChallengeValue),
				(LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Challenge), ExternalDataBridge.Context.ChallengeModeData.IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess) ? ExternalDataBridge.Context.ChallengeModeData.ApplyExchangeTargetAdvantageBonus(100) : 0)
			}.Where(((string, int) x) => x.Item2 != 0).Prepend((LocalStringManager.Get(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Header), TargetAdvantage))
			select x.Item1.GetFormat(x.Item2));
	}

	public string TaiwuAdvantageDesc(long totalValue, long totalValueWithAdvantage)
	{
		return string.Join("\n", from x in new(LanguageKey, int)[5]
			{
				(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_0, GlobalConfig.Instance.ExchangeBaseTaiwu),
				(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_5, TaiwuTaskEffect),
				(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_6, SecretValue),
				(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_7, ApprovingValue),
				(LanguageKey.LK_Exchange_Advantage_Tip_Desc_Content_8, DebtValue)
			}.Where(((LanguageKey, int) x) => x.Item2 != 0).Prepend((LanguageKey.LK_Exchange_Advantage_Tip_Desc_Header, TaiwuAdvantage))
			select LocalStringManager.GetFormat(x.Item1, x.Item2));
	}

	public void SetSecret(SecretInformationDisplayData secretInformationDisplayData, bool clearApprove = true)
	{
		SecretInformationId secretId = secretInformationDisplayData?.SecretInformationId ?? SecretInformationId.Invalid;
		if (clearApprove)
		{
			ApprovingValue = 0;
			ApprovingCharId = -1;
		}
		SecretId = (int)secretId;
		SecretValue = CalcSecretAdvantage(secretInformationDisplayData);
	}

	public void SetApproving(int approvingCharId, int approvingRate, bool clearSecret = true)
	{
		if (clearSecret)
		{
			SecretValue = 0;
			SecretId = -1;
		}
		ApprovingCharId = approvingCharId;
		ApprovingValue = ((approvingCharId != -1) ? (approvingRate * GlobalConfig.Instance.ExchangeApproveAdvantageBonus) : 0);
	}

	public void Reset()
	{
		SecretValue = (SecretId = (ApprovingValue = (ApprovingCharId = 0)));
	}

	public void OnItemChange(List<ExchangeItem> exchangeItemList)
	{
		if (!Enabled)
		{
			return;
		}
		TaskDict.Clear();
		if (TaskId != null)
		{
			foreach (ExchangeTaskItem key in TaskId.Select((int index) => ExchangeTask.Instance[index]))
			{
				TaskDict[key.TemplateId] = Math.Min(Math.Abs(exchangeItemList.Where((ExchangeItem item) => ConditionMeet(key, item)).Sum((ExchangeItem item) => item.Count)), (key.Limit < 0) ? int.MaxValue : key.Limit);
			}
		}
		TaiwuTaskEffect = TaskDict.Select(delegate(KeyValuePair<int, int> pair)
		{
			if (pair.Value > 0)
			{
				ExchangeTaskItem exchangeTaskItem = ExchangeTask.Instance[pair.Key];
				if (exchangeTaskItem != null && exchangeTaskItem.Advantage > 0)
				{
					return exchangeTaskItem.Advantage * ((exchangeTaskItem.Limit < 0) ? pair.Value : Math.Min(pair.Value, exchangeTaskItem.Limit));
				}
			}
			return 0;
		}).Sum();
		TargetTaskEffect = TaskDict.Select(delegate(KeyValuePair<int, int> pair)
		{
			if (pair.Value > 0)
			{
				ExchangeTaskItem exchangeTaskItem = ExchangeTask.Instance[pair.Key];
				if (exchangeTaskItem != null && exchangeTaskItem.Advantage < 0)
				{
					return -exchangeTaskItem.Advantage * ((exchangeTaskItem.Limit < 0) ? pair.Value : Math.Min(pair.Value, exchangeTaskItem.Limit));
				}
			}
			return 0;
		}).Sum();
	}

	/// <summary>
	/// 检查任务条件是否满足
	/// </summary>
	/// <param name="cfg"></param>
	/// <param name="item"></param>
	/// <returns></returns>
	public bool ConditionMeet(ExchangeTaskItem cfg, ExchangeItem item)
	{
		return ConditionMeet(cfg, item.Content, item.Count > 0);
	}

	/// <summary>
	/// 检查任务条件是否满足
	/// </summary>
	/// <param name="cfg"></param>
	/// <param name="item"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public bool ConditionMeet(ExchangeTaskItem cfg, ITradeableContent item, bool isForTaiwu)
	{
		IItemConfig itemCfg = item.RealKey.GetConfig();
		if (isForTaiwu ^ cfg.ForTaiwuWillGainItem)
		{
			return false;
		}
		if (ExchangeType == EExchangeType.Person && ((cfg.IsTargetLoveItem && itemCfg?.ItemSubType != LovingItemSubType) || (cfg.IsTargetHateItem && itemCfg?.ItemSubType != HatingItemSubType) || (cfg.IsTaiwuItemGradeExceedTargetGrade && item.Grade + 2 < NpcOrganization.Grade) || (cfg.IsTargetEquip && item.ItemSourceType != 0) || (cfg.IsTargetHasRelationToKidnapper && (!(item is KidnapCharDisplayData charDisplayData) || !RelatedCharIds.HasRelation(charDisplayData.CharacterId)))))
		{
			return false;
		}
		if (cfg.ItemSubType != -1 && itemCfg?.ItemSubType != cfg.ItemSubType)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 计算秘闻的优势值
	/// </summary>
	/// <param name="secretLevel"></param>
	/// <returns></returns>
	public int CalcSecretAdvantage(SecretInformationDisplayData secretInformationDisplayData)
	{
		short? num = secretInformationDisplayData?.SecretInformationTemplateId;
		if (num.HasValue)
		{
			short templateId = num.GetValueOrDefault();
			if (templateId != -1)
			{
				SecretInformationItem cfg = SecretInformation.Instance[templateId];
				if (cfg != null)
				{
					secretInformationDisplayData.GetCharacterRelatedParameter(out var actorId, out var _, out var _);
					if (TargetBehaviorType switch
					{
						0 => (cfg.ValueType == ESecretInformationValueType.Positive && actorId == TaiwuCharId) ? 1 : 0, 
						1 => ((cfg.ValueType == ESecretInformationValueType.Negative && actorId == TargetAdvantage) || (cfg.ValueType == ESecretInformationValueType.Positive && actorId == TaiwuCharId)) ? 1 : 0, 
						3 => (cfg.ValueType == ESecretInformationValueType.Negative) ? 1 : 0, 
						4 => (cfg.ValueType == ESecretInformationValueType.Positive && actorId == TargetCharId) ? 1 : 0, 
						_ => 0, 
					} == 0)
					{
						return 0;
					}
					return cfg.SortValue * GlobalConfig.Instance.ExchangeSecretAdvantageBonus;
				}
			}
		}
		return 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 70;
		totalSize += NpcOrganization.GetSerializedSize();
		totalSize = ((RelatedCharIds == null) ? (totalSize + 2) : (totalSize + (2 + RelatedCharIds.GetSerializedSize())));
		totalSize = ((TaskId == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaskId.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)(sbyte)ExchangeType;
		pCurrData++;
		pCurrData += NpcOrganization.Serialize(pCurrData);
		*(int*)pCurrData = TargetCharId;
		pCurrData += 4;
		*(int*)pCurrData = TargetBaseValue;
		pCurrData += 4;
		*(int*)pCurrData = TargetFavorType;
		pCurrData += 4;
		*(int*)pCurrData = TargetAlertLevel;
		pCurrData += 4;
		*(int*)pCurrData = TargetBehaviorType;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuBehaviorType;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuFameType;
		pCurrData += 4;
		*(int*)pCurrData = TargetLackResourceValue;
		pCurrData += 4;
		*pCurrData = (byte)TargetType;
		pCurrData++;
		*(int*)pCurrData = TargetExtraValue;
		pCurrData += 4;
		*(short*)pCurrData = LovingItemSubType;
		pCurrData += 2;
		*(short*)pCurrData = HatingItemSubType;
		pCurrData += 2;
		if (RelatedCharIds != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = RelatedCharIds.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = SecretValue;
		pCurrData += 4;
		*(int*)pCurrData = SecretId;
		pCurrData += 4;
		*(int*)pCurrData = ApprovingValue;
		pCurrData += 4;
		*(int*)pCurrData = ApprovingCharId;
		pCurrData += 4;
		*(int*)pCurrData = DebtUsed;
		pCurrData += 4;
		*(int*)pCurrData = TradeAreaId;
		pCurrData += 4;
		*(int*)pCurrData = DebtMax;
		pCurrData += 4;
		if (TaskId != null)
		{
			int elementsCount = TaskId.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = TaskId[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ExchangeType = (EExchangeType)(*pCurrData);
		pCurrData++;
		pCurrData += NpcOrganization.Deserialize(pCurrData);
		TargetCharId = *(int*)pCurrData;
		pCurrData += 4;
		TargetBaseValue = *(int*)pCurrData;
		pCurrData += 4;
		TargetFavorType = *(int*)pCurrData;
		pCurrData += 4;
		TargetAlertLevel = *(int*)pCurrData;
		pCurrData += 4;
		TargetBehaviorType = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuBehaviorType = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuFameType = *(int*)pCurrData;
		pCurrData += 4;
		TargetLackResourceValue = *(int*)pCurrData;
		pCurrData += 4;
		TargetType = (ETargetType)(*pCurrData);
		pCurrData++;
		TargetExtraValue = *(int*)pCurrData;
		pCurrData += 4;
		LovingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		HatingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			RelatedCharIds = new RelatedCharacters();
			pCurrData += RelatedCharIds.Deserialize(pCurrData);
		}
		else
		{
			RelatedCharIds = null;
		}
		SecretValue = *(int*)pCurrData;
		pCurrData += 4;
		SecretId = *(int*)pCurrData;
		pCurrData += 4;
		ApprovingValue = *(int*)pCurrData;
		pCurrData += 4;
		ApprovingCharId = *(int*)pCurrData;
		pCurrData += 4;
		DebtUsed = *(int*)pCurrData;
		pCurrData += 4;
		TradeAreaId = *(int*)pCurrData;
		pCurrData += 4;
		DebtMax = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TaskId == null || TaskId.Length != elementsCount)
			{
				TaskId = new int[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TaskId[i] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			TaskId = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
