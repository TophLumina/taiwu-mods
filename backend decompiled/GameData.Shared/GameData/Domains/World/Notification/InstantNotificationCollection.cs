using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.Notification;

/// <summary>
/// 即时通知的集合.
/// 单条即时通知的数据格式: size (uint8_t), date (int32_t), record_type (int16_t), optional arguments.
/// </summary>
/// <summary>
/// 即时通知的集合 - 添加即时通知
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class InstantNotificationCollection : WriteableRecordCollection
{
	/// <summary>
	/// 即时通知的集合
	/// </summary>
	public InstantNotificationCollection()
	{
	}

	/// <summary>
	/// 即时通知的集合
	/// </summary>
	/// <param name="initialCapacity">原始数据容器的初始容量</param>
	public InstantNotificationCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	/// <summary>
	/// 获取所有即时通知的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<InstantNotificationRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			InstantNotificationRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定索引的即时通知的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe InstantNotificationRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int date = *(int*)(pCurrData + 1);
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			InstantNotificationItem config = InstantNotification.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			InstantNotificationRenderInfo info = new InstantNotificationRenderInfo(recordType, config.Desc, config.SimpleDesc, date);
			string[] parameters = config.Parameters;
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadonlyRecordCollection.ReadArgumentAndGetIndex(paramType, &pCurrData, argumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	/// <summary>
	/// 开始添加即时通知
	/// </summary>
	/// <param name="recordType">即时通知类型</param>
	/// <returns>当前即时通知的起始偏移</returns>
	private new unsafe int BeginAddingRecord(short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		int date = ExternalDataBridge.Context.CurrDate;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 添加无参数通知
	/// </summary>
	/// <param name="templateId">通知类型, 对应通知表的模板 ID <see cref="T:Config.InstantNotification" /></param>
	public void AddNotificationWithNoArgument(short templateId)
	{
		Tester.Assert(InstantNotification.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加通知：参数是一个角色
	/// </summary>
	/// <param name="recordType">通知类型, 对应通知表的模板 ID <see cref="T:Config.InstantNotification" /></param>
	/// <param name="charId"></param>
	public void AddNotificationWithOneCharacterArgument(short recordType, int charId)
	{
		InstantNotificationItem config = InstantNotification.Instance[recordType];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 1 && ParameterType.Parse(config.Parameters[0]) == 0);
		int beginOffset = BeginAddingRecord(recordType);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加通知：参数是两个角色
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="charId"></param>
	/// <param name="charId1"></param>
	public void AddNotificationWithTwoCharacterArgument(short recordType, int charId, int charId1)
	{
		InstantNotificationItem config = InstantNotification.Instance[recordType];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) >= 2 && config.Parameters.Take(2).All((string p) => ParameterType.Parse(p) == 0));
		int beginOffset = BeginAddingRecord(recordType);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	///  添加通知：参数是三个角色
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="charId"></param>
	/// <param name="charId1"></param>
	/// <param name="charId2"></param>
	public void AddNotificationWithThreeCharacterArgument(short recordType, int charId, int charId1, int charId2)
	{
		InstantNotificationItem config = InstantNotification.Instance[recordType];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) >= 3 && config.Parameters.Take(3).All((string p) => ParameterType.Parse(p) == 0));
		int beginOffset = BeginAddingRecord(recordType);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 扩建完成
	/// {0}{1}扩建完成！
	/// </summary>
	public void AddBuildingUpgradingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 撤除完成
	/// {0}{1}撤除完成！
	/// </summary>
	public void AddBuildingDemolitionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 制造完成
	/// {0}{1}完成制造！
	/// </summary>
	public void AddBuildingCraftingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 建设完成
	/// {0}{1}建设完成！
	/// </summary>
	public void AddBuildingConstructionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 收获完成
	/// {0}{1}有收获消息！
	/// </summary>
	public void AddBuildingProductGenerated(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 规模下降
	/// {0}{1}规模正在&lt;color=#red&gt;下降&lt;/color&gt;！
	/// </summary>
	public void AddBuildingDamaged(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 建筑荒废
	/// {0}{1}已经被荒废！
	/// </summary>
	public void AddBuildingRuined(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 开始建设
	/// 开始在{0}建设{1}…
	/// </summary>
	public void AddBeginBuildingConstruction(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 开始扩建
	/// 开始在{0}扩建{1}…
	/// </summary>
	public void AddBeginBuildingUpgrading(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 开始撤除
	/// 开始在{0}撤除{1}…
	/// </summary>
	public void AddBeginBuildingDemolition(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 取消撤除
	/// 取消在{0}撤除{1}…
	/// </summary>
	public void AddCancelBuildingDemolition(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物来访
	/// 一位流民来到了{0}…
	/// </summary>
	public void AddCandidateArrived(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物离去
	/// 一位流民离开了{0}…
	/// </summary>
	public void AddCandidateLeaved(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 加入太吾村
	/// {0}加入太吾村…
	/// </summary>
	public void AddJoinTaiwuVillage(int charId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 离开太吾村
	/// {0}离开太吾村…
	/// </summary>
	public void AddLeaveTaiwuVillage(int charId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 仓库物品遗失
	/// 仓库中的{0}不慎遗失…
	/// </summary>
	public void AddWarehouseItemLost(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 损失威望
	/// {0}的{1}缺乏维护…
	/// </summary>
	public void AddBuildingLoseAuthority(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 新的驿站
	/// 发现了新的驿站：{1}！
	/// </summary>
	public void AddDiscoverRelay(Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 通过暗渊
	/// 所有人及代步受到了损伤！
	/// </summary>
	public void AddWalkThroughAbyss()
	{
		int beginOffset = BeginAddingRecord(18);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 出现奇遇
	/// 新的奇遇：「{1}」…
	/// </summary>
	public void AddBeginAdventure(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 遭遇天灾
	/// 所有同道均受到了损伤！
	/// </summary>
	public void AddNaturalDisasterEncountered(Location location)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 成为同道
	/// {0}加入了同道队伍！
	/// </summary>
	public void AddJoinGroup(int charId)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 退出同道
	/// {0}离开了同道队伍…
	/// </summary>
	public void AddLeaveGroup(int charId)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 立场变化
	/// {0}的处世立场变化…
	/// </summary>
	public void AddBehaviorTypeChanged(int charId, sbyte behaviorType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendBehaviorType(behaviorType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得学艺许可
	/// 获得{0}的学艺许可…
	/// </summary>
	public void AddSectInheritedApprovingReceived(short settlementId)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得支持
	/// 获得&lt;color=#lightblue&gt;门派支持&lt;/color&gt;…
	/// </summary>
	public void AddInheritedApprovingRateReceived(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 名誉上升
	/// {0}的&lt;color=#ffffff&gt;名誉&lt;/color&gt;&lt;color=#lightblue&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddFameIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 名誉下降
	/// {0}的&lt;color=#ffffff&gt;名誉&lt;/color&gt;&lt;color=#red&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddFameDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 心情上升
	/// {0}的&lt;color=#ffffff&gt;心情&lt;/color&gt;&lt;color=#lightblue&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddHappinessIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 心情下降
	/// {0}的&lt;color=#ffffff&gt;心情&lt;/color&gt;&lt;color=#red&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddHappinessDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 好感上升
	/// {1}对{2}&lt;color=#ffffff&gt;好感&lt;/color&gt;&lt;color=#lightblue&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddFavorabilityIncreased(short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 好感下降
	/// {1}对{2}&lt;color=#ffffff&gt;好感&lt;/color&gt;&lt;color=#red&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddFavorabilityDecreased(short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 好感阶段性上升
	/// {0}与{1}关系&lt;color=#lightblue&gt;加深&lt;/color&gt;…
	/// </summary>
	public void AddFavorabilityIncreasedAcrossLevels(int charId, int charId1, sbyte favorabilityType)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendFavorabilityType(favorabilityType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 好感阶段性下降
	/// {0}与{1}关系&lt;color=#red&gt;疏远&lt;/color&gt;…
	/// </summary>
	public void AddFavorabilityDecreasedAcrossLevels(int charId, int charId1, sbyte favorabilityType)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendFavorabilityType(favorabilityType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 探知喜好
	/// 听闻{0}的&lt;color=#lightblue&gt;喜爱&lt;/color&gt;…
	/// </summary>
	public void AddLovingItemRevealed(short settlementId, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 探知厌恶
	/// 听闻{1}的&lt;color=#red&gt;厌恶&lt;/color&gt;…
	/// </summary>
	public void AddHatingItemRevealed(short settlementId, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 没有喜好
	/// 听闻{1}没有&lt;color=#lightblue&gt;喜爱&lt;/color&gt;的东西…
	/// </summary>
	public void AddLovingItemRevealedNothing(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 没有厌恶
	/// 听闻{1}没有&lt;color=#red&gt;厌恶&lt;/color&gt;的东西…
	/// </summary>
	public void AddHatingItemRevealedNothing(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 收化血露
	/// {0}收化了{1}中灵气…
	/// </summary>
	public void AddEatBloodDew(int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 功法增加
	/// {0}学会了新的功法：{1}…
	/// </summary>
	public void AddCombatSkillLearned(int charId, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 健康值上升
	/// {0}的健康值&lt;color=#lightgreen&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddHealthIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 健康值下降
	/// {0}的健康值&lt;color=#red&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddHealthDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 入魔值上升
	/// {0}入魔程度&lt;color=#red&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddXiangshuInfectionIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 入魔值下降
	/// {0}入魔程度&lt;color=#lightblue&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddXiangshuInfectionDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色入邪
	/// {0}&lt;color=#red&gt;入邪&lt;/color&gt;！
	/// </summary>
	public void AddXiangshuPartlyInfected(int charId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色入魔
	/// {0}&lt;color=#red&gt;入魔&lt;/color&gt;！
	/// </summary>
	public void AddXiangshuCompletelyInfected(int charId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恢复属性
	/// {0}的{1}&lt;color=#lightblue&gt;恢复&lt;/color&gt;…
	/// </summary>
	public void AddMainAttributeRecovered(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 消耗属性
	/// {0}的{1}&lt;color=#red&gt;消耗&lt;/color&gt;…
	/// </summary>
	public void AddMainAttributeConsumed(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内息紊乱上升
	/// {0}的内息紊乱&lt;color=#red&gt;上升&lt;/color&gt;…
	/// </summary>
	public void AddDisorderOfQiIncreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内息紊乱下降
	/// {0}的内息紊乱&lt;color=#lightblue&gt;下降&lt;/color&gt;…
	/// </summary>
	public void AddDisorderOfQiDecreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 伤势增加
	/// {0}的伤势&lt;color=#red&gt;增加&lt;/color&gt;…
	/// </summary>
	public void AddInjuryIncreased(int charId, sbyte bodyPartType, sbyte injuryType)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendBodyPartType(bodyPartType);
		AppendInjuryType(injuryType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 伤势恢复
	/// {0}的伤势得到&lt;color=#lightblue&gt;恢复&lt;/color&gt;…
	/// </summary>
	public void AddInjuryDecreased(int charId, sbyte bodyPartType, sbyte injuryType)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendBodyPartType(bodyPartType);
		AppendInjuryType(injuryType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色中毒
	/// {0}体内的毒素&lt;color=#red&gt;增加&lt;/color&gt;…
	/// </summary>
	public void AddPoisonIncreased(int charId, sbyte poisonType, int value)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色减毒
	/// {0}体内的毒素&lt;color=#lightblue&gt;减少&lt;/color&gt;…
	/// </summary>
	public void AddPoisonDecreased(int charId, sbyte poisonType, int value)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 历练增加
	/// {0}&lt;color=#lightblue&gt;获得&lt;/color&gt;{1}历练…
	/// </summary>
	public void AddExpIncreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 历练减少
	/// {0}&lt;color=#red&gt;失去&lt;/color&gt;{1}历练…
	/// </summary>
	public void AddExpDecreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 资源上升
	/// {0}&lt;color=#lightblue&gt;获得&lt;/color&gt; {2} {1}…
	/// </summary>
	public void AddResourceIncreased(int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 资源下降
	/// {0}&lt;color=#red&gt;失去&lt;/color&gt; {2} {1}…
	/// </summary>
	public void AddResourceDecreased(int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得物品
	/// {0}&lt;color=#lightblue&gt;获得&lt;/color&gt;{1}…
	/// </summary>
	public void AddGetItem(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 失去物品
	/// {0}&lt;color=#red&gt;失去&lt;/color&gt;{1}…
	/// </summary>
	public void AddLoseItem(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色成年
	/// {0}成年了！
	/// </summary>
	public void AddCharacterGrownUp(int charId)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色死亡
	/// {0}离开了人世…
	/// </summary>
	public void AddCharacterDead(int charId)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织寿终
	/// 促织{0}寿终正寝了……
	/// </summary>
	public void AddCricketDead(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友死亡
	/// {2}听闻{0}离开人世…
	/// </summary>
	public void AddFamilyDied(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人死亡
	/// {2}听闻{0}离开人世…
	/// </summary>
	public void AddEnemyDied(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人受福
	/// {2}听闻{0}意外收获…
	/// </summary>
	public void AddEnemyLucky(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人受祸
	/// {2}听闻{0}遭逢灾祸…
	/// </summary>
	public void AddEnemyUnlucky(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人失败
	/// {2}听闻{0}较艺落败…
	/// </summary>
	public void AddEnemyLoseInLifeSkill(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人失败
	/// {2}听闻{0}落败…
	/// </summary>
	public void AddEnemyLoseInCombat(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌人失败
	/// {2}听闻{0}狼狈落败…
	/// </summary>
	public void AddEnemyGreatLoseInCombat(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友流产
	/// {2}听闻{0}痛失骨肉…
	/// </summary>
	public void AddFamilyMiscarriage(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 罪行公开
	/// {0}遗弃之事败露…
	/// </summary>
	public void AddAbandonExposed(int charId)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 遭人遗弃
	/// {0}得知了自己遭人遗弃…
	/// </summary>
	public void AddAbandonAcknowledged(int charId)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友遗弃
	/// {1}得知亲友遗弃了孩子…
	/// </summary>
	public void AddFamilyAbandon(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 得知乱伦
	/// {0}得知自己的复杂身世…
	/// </summary>
	public void AddSelfImmoralLove(int charId)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友生子
	/// {2}得知亲友生子…
	/// </summary>
	public void AddFamilyHaveKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 诞育后代
	/// {1}得知后代降生…
	/// </summary>
	public void AddHaveKid(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友乱伦
	/// {2}得知亲友乱伦…
	/// </summary>
	public void AddFamilyImmoralKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友破戒
	/// {2}得知亲友破戒…
	/// </summary>
	public void AddReligiousFamilyHaveKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友恋爱
	/// {2}得知亲友恋爱…
	/// </summary>
	public void AddFamilyInLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友乱伦
	/// {2}得知亲友乱伦…
	/// </summary>
	public void AddFamilyImmoralLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友破戒
	/// {2}得知亲友破戒…
	/// </summary>
	public void AddReligiousFamilyInLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恋人成亲
	/// {2}得知恋人成亲…
	/// </summary>
	public void AddFamilyMarried(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友乱伦
	/// {2}得知亲友乱伦…
	/// </summary>
	public void AddFamilyImmoralMarriage(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyBeFriendWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyJieyiWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyAdoptedMaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyAdoptedFemaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyAdoptedByMaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 敌友不分
	/// {2}得知{0}敌友不分…
	/// </summary>
	public void AddFamilyAdoptedByFemaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 亲友分手
	/// {2}得知{0}分手…
	/// </summary>
	public void AddFamilyEndedImmoralLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 是敌非友
	/// {2}得知{0}断绝友谊…
	/// </summary>
	public void AddFamilyEndedFriendshipWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 是敌非友
	/// {2}得知{0}割袍断义…
	/// </summary>
	public void AddFamilyEndedJieyiWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恋人春宵
	/// {2}得知{0}春宵…
	/// </summary>
	public void AddLoverHaveSex(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 空闲村民
	/// {0}现有{1}名村民空闲…
	/// </summary>
	public void AddTaiwuVillageIdleCount(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 资历增长
	/// {0}志向的资历增长…
	/// </summary>
	public void AddProfessionSeniorityIncrease(int professionTemplateId)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendProfession(professionTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 技能解锁
	/// 对{0}志向产生新的理解…
	/// </summary>
	public void AddProfessionUnlockSkill(int professionTemplateId, int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendProfession(professionTemplateId);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 技能冷却
	/// {0}已经可以使用…
	/// </summary>
	public void AddProfessionSkillHasCoolDown(int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 效果结束
	/// {0}的效果失效…
	/// </summary>
	public void AddProfessionSkillEffectIsEnd(int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 追踪野兽
	/// 发现一只新的野兽…
	/// </summary>
	public void AddProfessionHunterSkill0(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 侠士典范
	/// {0}开始流行{1}…
	/// </summary>
	public void AddProfessionMartialArtistSkill2(Location location, sbyte combatSkillType, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendLocation(location);
		AppendCombatSkillType(combatSkillType);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 贤士典范
	/// {0}开始流行{1}…
	/// </summary>
	public void AddProfessionLiteratiSkill2(Location location, sbyte lifeSkillType, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 安居乐业
	/// {0}与他人化解了仇恨…
	/// </summary>
	public void AddProfessionCivilianSkill1(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 退隐江湖
	/// {0}退隐江湖…
	/// </summary>
	public void AddProfessionCivilianSkill2(int charId, int charId1, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 游医义诊
	/// {0}在{1}义诊…
	/// </summary>
	public void AddProfessionDoctorSkill1(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 酒肉破戒
	/// {0}因贪食酒肉破戒…
	/// </summary>
	public void AddProfessionMonkBreakFoodRule(int charId, int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 春宵破戒
	/// {0}因一夜春宵破戒…
	/// </summary>
	public void AddProfessionMonkBreakLoveRule(int charId, int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 追踪野兽失败
	/// 当前区域没有发现野兽的踪迹…
	/// </summary>
	public void AddProfessionHunterSkill0None()
	{
		int beginOffset = BeginAddingRecord(106);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 地区主线昌盛结局
	/// 获得了{0}昌盛的见闻…
	/// </summary>
	public void AddSettlementStoryGoodEnd(short settlementId)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 地区主线衰落结局
	/// 获得了{0}衰落的见闻…
	/// </summary>
	public void AddSettlementStoryBadEnd(short settlementId)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发战斗读书
	/// 提升了对{0}的理解…
	/// </summary>
	public void AddReadInCombat(sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发较艺读书
	/// 提升了对{0}的理解…
	/// </summary>
	public void AddReadInLifeSkillCombat(sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发战斗读书
	/// 提升了对{0}的理解…
	/// </summary>
	public void AddReadInCombatNoChance(sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发较艺读书
	/// 提升了对{0}的理解…
	/// </summary>
	public void AddReadInLifeSkillCombatNoChance(sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 藏书阁修复成功
	/// 藏书{0}已修复…
	/// </summary>
	public void AddBookRepairSuccess(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 轮回台轮回结束
	/// {0}在轮回台中等待转世…
	/// </summary>
	public void AddReincarnationArchitectureReincarnationEnd(int charId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 监管的巢穴消亡
	/// {2}监管的奇遇消亡…
	/// </summary>
	public void AddTheNestOfRegulationDies(Location location, int adventureCoreId, int charId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 收录组织的曲子
	/// 已收录{0}的名曲《{1}》…
	/// </summary>
	public void AddXuannvBlockMusicTranscribe(short settlementId, short musicTemplateId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendSettlement(settlementId);
		AppendMusic(musicTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 收录州域的曲子
	/// 已收录{0}的名曲《{1}》…
	/// </summary>
	public void AddXuannvStateMusicTranscribe(sbyte stateTemplateId, short musicTemplateId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendMapState(stateTemplateId);
		AppendMusic(musicTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 独创一格准备完毕
	/// {0}已完成武学独创…
	/// </summary>
	public void AddDuChuangYiGeReady(int charId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 民力凋敝
	/// {0}的{2}停止襄助…
	/// </summary>
	public void AddCultureDecline(short settlementId, int charId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 雷泽神力增强
	/// 雷泽神力增强…
	/// </summary>
	public void AddThunderPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 洪泽神力增强
	/// 洪泽神力增强…
	/// </summary>
	public void AddFloodPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 炎泽神力增强
	/// 炎泽神力增强…
	/// </summary>
	public void AddBlazePowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 风泽神力增强
	/// 风泽神力增强…
	/// </summary>
	public void AddStormPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 沙泽神力增强
	/// 沙泽神力增强…
	/// </summary>
	public void AddSandPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 雷泽神力减弱
	/// 雷泽神力减弱…
	/// </summary>
	public void AddThunderPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 洪泽神力减弱
	/// 洪泽神力减弱…
	/// </summary>
	public void AddFloodPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 炎泽神力减弱
	/// 炎泽神力减弱…
	/// </summary>
	public void AddBlazePowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 风泽神力减弱
	/// 风泽神力减弱…
	/// </summary>
	public void AddStormPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 沙泽神力减弱
	/// 沙泽神力减弱…
	/// </summary>
	public void AddSandPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性增强
	/// {0}的属性增加…
	/// </summary>
	public void AddJiaoAbilityUp(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性减弱
	/// {0}的属性减少…
	/// </summary>
	public void AddJiaoAbilityDown(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟礼物属性增加
	/// {0}的属性增加…
	/// </summary>
	public void AddJiaoGiftAbilityUp(int jiaoLoongId, short jiaoPropertyId)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟礼物属性减少
	/// {0}的属性减少…
	/// </summary>
	public void AddJiaoGiftAbilityDown(int jiaoLoongId, short jiaoPropertyId)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性增加百分号
	/// {0}的属性增加…
	/// </summary>
	public void AddJiaoAbilityUpPercent(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性减少百分号
	/// {0}的属性减少…
	/// </summary>
	public void AddJiaoAbilityDownPercent(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性增加浮点数
	/// {0}的属性增加…
	/// </summary>
	public void AddJiaoAbilityUpFloat(int jiaoLoongId, short jiaoPropertyId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 蛟属性减少浮点数
	/// {0}的属性减少…
	/// </summary>
	public void AddJiaoAbilityDownFloat(int jiaoLoongId, short jiaoPropertyId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 王蛊逃离
	/// {0}自宿主体内逃离…
	/// </summary>
	public void AddWugKingEscape(sbyte itemType, short itemTemplateId, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 宿主死亡
	/// {0}自宿主体内逃离…
	/// </summary>
	public void AddWugKingParasitiferDead(sbyte itemType, short itemTemplateId, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 王蛊死亡
	/// {0}体内的王蛊死亡…
	/// </summary>
	public void AddWugKingDead(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 王蛊死亡
	/// {0}体内的王蛊死亡…
	/// </summary>
	public void AddWugKingDeadSpecial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 知晓高僧秘闻
	/// {0}已知晓高僧宝经秘闻…
	/// </summary>
	public void AddKnowMonkSecret(int charId)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恩义上升
	/// {0}恩义上升…
	/// </summary>
	public void AddGraceIncreased(Location location)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 王蛊逃离1
	/// {0}自宿主体内逃离…
	/// </summary>
	public void AddWugKingEscape1(sbyte itemType, short itemTemplateId, short charTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendItem(itemType, itemTemplateId);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 王蛊逃离2
	/// {0}自宿主体内逃离…
	/// </summary>
	public void AddWugKingEscape2(sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发战斗周天
	/// 对{0}有所感应…
	/// </summary>
	public void AddQiArtInCombatNoChance(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发较艺周天
	/// 对{0}有所感应…
	/// </summary>
	public void AddQiArtInLifeSkillCombatNoChance(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 玄白化身动物
	/// 玄白化为了玄鸮白鹿…
	/// </summary>
	public void AddSectStoryBaihuaToAnimal(int charId)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 玄白化身人形
	/// 玄鸮白鹿化为了人形…
	/// </summary>
	public void AddSectStoryBaihuaToHuman()
	{
		int beginOffset = BeginAddingRecord(149);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 引爆机关
	/// 所有同道均受到了损伤！
	/// </summary>
	public void AddMechanismOfDetonation()
	{
		int beginOffset = BeginAddingRecord(150);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 资历增长
	/// {0}志向的资历增长…
	/// </summary>
	public void AddProfessionSeniorityIncrease1(int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 休养生息
	/// 周围地格资源得到恢复…
	/// </summary>
	public void AddBlockResourceRecovery(int value)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 休养生息
	/// 神树得到了成长…
	/// </summary>
	public void AddShenTreeGrow()
	{
		int beginOffset = BeginAddingRecord(153);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 万兽升灵
	/// 已将代步{0}升灵为同道…
	/// </summary>
	public void AddBeastUpgrade(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 万兽归灵
	/// 已将野兽同道归灵…
	/// </summary>
	public void AddBeastDowngrade(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 风卷残云
	/// 引来了若干义士与外道…
	/// </summary>
	public void AddGatherCompanions(int value, int value1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 金口玉言
	/// 将一则秘闻公之于众…
	/// </summary>
	public void AddDisseminateSecretInformation(short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 谈天说地
	/// 将此见闻告知{1}人…
	/// </summary>
	public void AddDisseminateInformation(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 扶助保荐
	/// {0}的势力值&lt;color=#brightblue&gt;增加&lt;/color&gt;…
	/// </summary>
	public void AddRecommendFellowUp(int charId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 扶助保荐
	/// {0}的势力值&lt;color=#brightred&gt;降低&lt;/color&gt;…
	/// </summary>
	public void AddRecommendFellowDown(int charId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;{1}&lt;/color&gt;得到了提升…
	/// </summary>
	public void AddComradePropertyUp(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;武学&lt;/color&gt;资质得到了提升…
	/// </summary>
	public void AddComradeCombatSkillUp(int charId)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;技艺&lt;/color&gt;资质得到了提升…
	/// </summary>
	public void AddComradeLifeSkillUp(int charId)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的特性产生了变化…
	/// </summary>
	public void AddComradeFeatureUp(int charId)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 有教无类
	/// {0}释放了{1}名囚犯…
	/// </summary>
	public void AddReleasePrisoners(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 芜行俚语
	/// 当前地格人物已被驱赶…
	/// </summary>
	public void AddDriveAwayPeople(Location location)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 安居乐业
	/// 化解了{0}人的仇恨…
	/// </summary>
	public void AddQuenchHatred(int value)
	{
		int beginOffset = BeginAddingRecord(167);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 无量浮屠
	/// 完成了佛寺的参拜…
	/// </summary>
	public void AddVisitTemple(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(168);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 茶中岁月
	/// {0}的精力&lt;color=#brightblue&gt;增加&lt;/color&gt;…
	/// </summary>
	public void AddDrinkTeaRecharge(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(169);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 超度法会
	/// 成功超度了{0}人的亡魂…
	/// </summary>
	public void AddReleaseSouls(int value)
	{
		int beginOffset = BeginAddingRecord(170);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 出神之地悬赏消除
	/// 所有的悬赏已经消除…
	/// </summary>
	public void AddSectPunishmentWarrantRelieved(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(171);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 出神之地负面特性消除
	/// 所有门派处罚已经消除…
	/// </summary>
	public void AddSectPunishmentCharacterFeatureRelieved(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(172);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 解甲归田
	/// {0}失去了官职…
	/// </summary>
	public void AddResignationPosition(int charId)
	{
		int beginOffset = BeginAddingRecord(173);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得遗惠
	/// 获得可用遗惠「{0}」
	/// </summary>
	public void AddLegacy(short legacyTemplateId)
	{
		int beginOffset = BeginAddingRecord(174);
		AppendLegacy(legacyTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 文化提升
	/// {0}的文化提升…
	/// </summary>
	public void AddCultureUp(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(175);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 安定提升
	/// {0}的安定提升…
	/// </summary>
	public void AddSecurityUp(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(176);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 文化降低
	/// {0}的文化降低…
	/// </summary>
	public void AddCultureDown(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(177);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 安定降低
	/// {0}的安定降低…
	/// </summary>
	public void AddSecurityDown(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(178);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 拾取资源
	/// 获得{2}{1}…
	/// </summary>
	public void AddMapPickupsResource(Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(179);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得食材
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsFoodIngredients(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(180);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得制造引子
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsMaterials(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(181);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得药材引子
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsHerbal0(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(182);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得毒物引子
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsHerbal1(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(183);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得毒药
	/// 获得{0}…
	/// </summary>
	public void AddMapPickupsPoison(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(184);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得治疗丹药
	/// 获得{0}…
	/// </summary>
	public void AddMapPickupsInjuryMedicine(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(185);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得解毒药
	/// 获得{0}…
	/// </summary>
	public void AddMapPickupsAntidote(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(186);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得增幅丹药
	/// 获得{0}…
	/// </summary>
	public void AddMapPickupsGainMedicine(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(187);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得水果
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsFruit(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(188);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得禽类食物
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsChickenDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(189);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得兽类食物
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsMeatDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(190);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得素食食物
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsVegetarianDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(191);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得水产食物
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsSeafoodDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(192);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得酒
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsWine(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(193);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得茶
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsTea(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(194);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得工具
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsTool(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(195);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得宝物
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsAccessory(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(196);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得药霜或毒砂
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsPoisonCream(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(197);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得机关
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsHarrier(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(198);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得令符
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsToken(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(199);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得针匣
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsNeedleBox(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(200);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得对刺
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsThorn(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(201);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得暗器
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsHiddenWeapon(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(202);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得箫笛
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsFlute(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(203);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得掌套
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsGloves(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(204);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得织物掌套
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsFurGloves(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(205);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得短杵
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsPestle(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(206);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得剑
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsSword(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(207);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得刀
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsBlade(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(208);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得长兵
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsPolearm(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(209);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得瑶琴
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupQin(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(210);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得拂尘
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsWhisk(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(211);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得长鞭
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsWhip(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(212);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得冠饰
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsCrest(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(213);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得鞋子
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsShoes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(214);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得护甲
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsArmor(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(215);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得护臂
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsArmGuard(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(216);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得代步
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsCarDrop(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得历练
	/// 获得{1}历练…
	/// </summary>
	public void AddMapPickupsExp(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(218);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 研读书籍
	/// 完成一次书籍研读…
	/// </summary>
	public void AddMapPickupsReading()
	{
		int beginOffset = BeginAddingRecord(219);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 周天运转
	/// 完成一次周天运转…
	/// </summary>
	public void AddMapPickupsQiArt()
	{
		int beginOffset = BeginAddingRecord(220);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得州域恩义
	/// 获得{0}恩义…
	/// </summary>
	public void AddMapPickupsMorale(sbyte stateTemplateId)
	{
		int beginOffset = BeginAddingRecord(221);
		AppendMapState(stateTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得属性
	/// {0}的{1}增加…
	/// </summary>
	public void AddMapPickupsProperty(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 爪牙逃跑
	/// 潜伏的爪牙望风而逃…
	/// </summary>
	public void AddMapPickupsEnemyEscape(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(223);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得历练
	/// &lt;color=#lightblue&gt;获得&lt;/color&gt;{0}历练…
	/// </summary>
	public void AddBuildingExp(int value)
	{
		int beginOffset = BeginAddingRecord(224);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 通过毁坏地块
	/// 所有人的代步受到了损伤！
	/// </summary>
	public void AddWalkThroughDestroyBlock()
	{
		int beginOffset = BeginAddingRecord(225);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 通过玄石之地
	/// 所有人的代步受到了损伤！
	/// </summary>
	public void AddWalkThroughErosionBlock()
	{
		int beginOffset = BeginAddingRecord(226);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;主要属性&lt;/color&gt;变化为{1}的水平…
	/// </summary>
	public void AddComradePropertyUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;武学&lt;/color&gt;资质变化为{1}的水平…
	/// </summary>
	public void AddComradeCombatSkillUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(228);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;技艺&lt;/color&gt;资质变化为{1}的水平…
	/// </summary>
	public void AddComradeLifeSkillUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(229);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;主要属性&lt;/color&gt;变化为{1}的水平…
	/// </summary>
	public void AddComradePropertyUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(230);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;武学&lt;/color&gt;资质变化为{1}的水平…
	/// </summary>
	public void AddComradeCombatSkillUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(231);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 采擢荐进
	/// {0}的&lt;color=#pinkyellow&gt;技艺&lt;/color&gt;资质变化为{1}的水平…
	/// </summary>
	public void AddComradeLifeSkillUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(232);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物逃离
	/// {0}逃离了此地…
	/// </summary>
	public void AddCharacterEscape(int charId)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恩义上升
	/// {0}恩义上升…
	/// </summary>
	public void AddGraceUp(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(234);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 恩义下降
	/// {0}恩义下降…
	/// </summary>
	public void AddGraceDown(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(235);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 驱灭外道
	/// 驱灭了外道{0}…
	/// </summary>
	public void AddExpelEnemy(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(236);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 驱灭义士
	/// 驱灭了义士{0}…
	/// </summary>
	public void AddExpelRighteous(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(237);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 驱灭相枢爪牙
	/// 驱灭了爪牙{0}…
	/// </summary>
	public void AddExpelXiangshuMinion(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(238);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 驱灭野兽
	/// 驱灭了野兽{0}…
	/// </summary>
	public void AddExpelBeast(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得毒药
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsPoisonCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(240);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得治疗丹药
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsInjuryMedicineCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得解毒药
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsAntidoteCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 获得增幅丹药
	/// 获得{1}…
	/// </summary>
	public void AddMapPickupsGainMedicineCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外拾取奖励
	/// 额外获得{1}{0}…
	/// </summary>
	public void AddMapPickupsResourceUpdate(sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(244);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外历练奖励
	/// 额外获得{0}历练…
	/// </summary>
	public void AddMapPickupsExpUpdate(int value)
	{
		int beginOffset = BeginAddingRecord(245);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外恩义奖励
	/// 额外获得{0}恩义…
	/// </summary>
	public void AddMapPickupsMoraleUpdate(sbyte stateTemplateId)
	{
		int beginOffset = BeginAddingRecord(246);
		AppendMapState(stateTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 升级物品奖励
	/// 意外获得{0}…
	/// </summary>
	public void AddMapPickupsItemUpdate(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(247);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外研读书籍
	/// 完成一次高效的书籍研读…
	/// </summary>
	public void AddMapPickupsReadingUpdate()
	{
		int beginOffset = BeginAddingRecord(248);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外周天运转
	/// 完成一次高效的周天运转…
	/// </summary>
	public void AddMapPickupsQiArtUpdate()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 制成物品
	/// 制出的&lt;color=#pinkyellow&gt;物品&lt;/color&gt;均已置入太吾村&lt;color=#pinkyellow&gt;私库&lt;/color&gt;…
	/// </summary>
	public void AddMakeItemOutsideSettlement()
	{
		int beginOffset = BeginAddingRecord(250);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 战斗解救获得心念
	/// 获得{1}「伏虞心念」…
	/// </summary>
	public void AddGainFuyuFaith1(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 石屋解救获得心念
	/// 获得{1}「伏虞心念」…
	/// </summary>
	public void AddGainFuyuFaith2(int value, int value1)
	{
		int beginOffset = BeginAddingRecord(252);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 通用获得伏虞心念
	/// 获得{0}「伏虞心念」…
	/// </summary>
	public void AddGainFuyuFaith3(int value)
	{
		int beginOffset = BeginAddingRecord(253);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 额外拾取药材
	/// 额外获得{0}…
	/// </summary>
	public void AddMapPickupsMedicineUpdate(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(254);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 姬穸消灭外道
	/// {0}恩义上升…
	/// </summary>
	public void AddJixiKillTemplateEnemy(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(255);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色内力恢复
	/// {0}的内力上升了…
	/// </summary>
	public void AddNeiliRecovery(int charId)
	{
		int beginOffset = BeginAddingRecord(256);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 前往赎身
	/// {0}前往{1}处，等待{2}为其赎身..
	/// </summary>
	public void AddAdventureRedeem(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物跟随
	/// {0}开始跟随太吾…
	/// </summary>
	public void AddAdventureCharacterFollow(int charId)
	{
		int beginOffset = BeginAddingRecord(258);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物停止跟随
	/// {0}停止跟随太吾…
	/// </summary>
	public void AddAdventureStopFollow(int charId)
	{
		int beginOffset = BeginAddingRecord(259);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物前往宴会
	/// {0}开始前往宴会…
	/// </summary>
	public void AddAdventureAttendBanquet(int charId)
	{
		int beginOffset = BeginAddingRecord(260);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 外道被歼灭
	/// {0}被歼灭了…
	/// </summary>
	public void AddAdventureKillHeretics(int charId)
	{
		int beginOffset = BeginAddingRecord(261);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 人物对太吾敌对
	/// {0}对太吾敌对了…
	/// </summary>
	public void AddAdventureBecomeEnemy(int charId)
	{
		int beginOffset = BeginAddingRecord(262);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 音乐宴会开始举办
	/// 音乐宴会开始举办了..
	/// </summary>
	public void AddAdventureMusicStart()
	{
		int beginOffset = BeginAddingRecord(263);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 弈棋宴会开始举办
	/// 弈棋宴会开始举办了..
	/// </summary>
	public void AddAdventureChessStart()
	{
		int beginOffset = BeginAddingRecord(264);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 诗词宴会开始举办
	/// 诗词宴会开始举办了..
	/// </summary>
	public void AddAdventurePoemStart()
	{
		int beginOffset = BeginAddingRecord(265);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 绘画宴会开始举办
	/// 绘画宴会开始举办了..
	/// </summary>
	public void AddAdventurePaintStart()
	{
		int beginOffset = BeginAddingRecord(266);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 太吾放弃赎身
	/// {0}放弃了对{1}的赎身..
	/// </summary>
	public void AddAdventureGiveUpRedeem(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(267);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石治疗
	/// 队伍的伤势和内息紊乱&lt;color=#brightblue&gt;减轻了&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDElementStoneBuffMetal(int charId)
	{
		int beginOffset = BeginAddingRecord(268);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石治疗
	/// 队伍的伤势和内息紊乱&lt;color=#brightblue&gt;减轻了&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDElementStoneBuffWood(int charId)
	{
		int beginOffset = BeginAddingRecord(269);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石治疗
	/// 队伍的伤势和内息紊乱&lt;color=#brightblue&gt;减轻了&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDElementStoneBuffWater(int charId)
	{
		int beginOffset = BeginAddingRecord(270);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石治疗
	/// 队伍的伤势和内息紊乱&lt;color=#brightblue&gt;减轻了&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDElementStoneBuffFire(int charId)
	{
		int beginOffset = BeginAddingRecord(271);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石治疗
	/// 队伍的伤势和内息紊乱&lt;color=#brightblue&gt;减轻了&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDElementStoneBuffEarth(int charId)
	{
		int beginOffset = BeginAddingRecord(272);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;增加了&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffMetal0(int charId)
	{
		int beginOffset = BeginAddingRecord(273);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;增加了&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffWood0(int charId)
	{
		int beginOffset = BeginAddingRecord(274);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;增加了&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffWater0(int charId)
	{
		int beginOffset = BeginAddingRecord(275);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;增加了&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffFire0(int charId)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;增加了&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffEarth0(int charId)
	{
		int beginOffset = BeginAddingRecord(277);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;大幅增加&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffMetal1(int charId)
	{
		int beginOffset = BeginAddingRecord(278);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;大幅增加&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffWood1(int charId)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;大幅增加&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffWater1(int charId)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;大幅增加&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffFire1(int charId)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 狱石损害
	/// 队伍的伤势和内息紊乱&lt;color=#brightred&gt;大幅增加&lt;/color&gt;！
	/// </summary>
	public void AddAdventureXRSDElementStoneDeBuffEarth1(int charId)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内力变化为金刚
	/// {0}的内力五行变化为了&lt;color=#FiveElementType_Jingang&gt;金刚&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDNeiliChangeMetal(int charId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内力变化为紫霞
	/// {0}的内力五行变化为了&lt;color=#FiveElementType_Zixia&gt;紫霞&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDNeiliChangeWood(int charId)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内力变化为玄阴
	/// {0}的内力五行变化为了&lt;color=#FiveElementType_Xuanyin&gt;玄阴&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDNeiliChangeWater(int charId)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内力变化为纯阳
	/// {0}的内力五行变化为了&lt;color=#FiveElementType_Chunyang&gt;纯阳&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDNeiliChangeFire(int charId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 内力变化为归元
	/// {0}的内力五行变化为了&lt;color=#FiveElementType_Guiyuan&gt;归元&lt;/color&gt;…
	/// </summary>
	public void AddAdventureXRSDNeiliChangeEarth(int charId)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色死亡
	/// {0}离开了人世…
	/// </summary>
	public void AddAdventureCharacterDie(int charId, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(283);
		AppendCharacter(charId);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 角色死亡
	/// {0}{1}离开了人世…
	/// </summary>
	public void AddAdventureCharacterDie0(int elementCoreId, string text, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendAdventureElement(elementCoreId);
		AppendText(text);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 戒心上升
	/// {0}对{1}的戒心提升了……
	/// </summary>
	public void AddAlertnessUp(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 戒心下降
	/// {0}对{1}的戒心降低了……
	/// </summary>
	public void AddAlertnessDown(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的耐力提升了…
	/// </summary>
	public void AddCricketHPUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的斗性提升了…
	/// </summary>
	public void AddCricketSPUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的气势提升了…
	/// </summary>
	public void AddCricketVigorUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的角力提升了…
	/// </summary>
	public void AddCricketStrengthUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的牙钳提升了…
	/// </summary>
	public void AddCricketBiteUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(297);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的致命提升了…
	/// </summary>
	public void AddCricketDeadlinessUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的伤害提升了…
	/// </summary>
	public void AddCricketDamageUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的伤残提升了…
	/// </summary>
	public void AddCricketCrippleUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(300);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的防御提升了…
	/// </summary>
	public void AddCricketDefenceUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(301);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的减伤提升了…
	/// </summary>
	public void AddCricketDamageReduceUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(302);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的反击提升了…
	/// </summary>
	public void AddCricketCounterUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(303);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 促织属性提升
	/// {0}的耐久提升了…
	/// </summary>
	public void AddCricketDurabilityUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(304);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发爆炸陷阱
	/// {0}触发了爆炸陷阱…
	/// </summary>
	public void AddBlastTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(305);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发暗器陷阱
	/// {0}触发了暗器陷阱…
	/// </summary>
	public void AddShootTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发毒气陷阱
	/// {0}触发了毒气陷阱…
	/// </summary>
	public void AddGasTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(307);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发鬼哨陷阱
	/// {0}触发了鬼哨陷阱…
	/// </summary>
	public void AddScreamTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 触发迷雾陷阱
	/// {0}触发了迷雾陷阱…
	/// </summary>
	public void AddMistTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(309);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 自动丢弃物品
	/// 自动丢弃了{0}…
	/// </summary>
	public void AddAutoOperationDiscard(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(310);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 自动拆解物品
	/// 自动拆解了{1}…
	/// </summary>
	public void AddAutoOperationDisassemble(sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(311);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 俘虏试图逃跑
	/// 被{0}关押的{1}正试图逃遁…
	/// </summary>
	public void AddPrepareEscape(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(312);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 慈心救苦
	/// 治愈了{0}的伤势和毒素…
	/// </summary>
	public void AddMonvGood(int charId)
	{
		int beginOffset = BeginAddingRecord(313);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 毒雾缠身
	/// 对{0}施加了伤势和毒素…
	/// </summary>
	public void AddMonvBad(int charId)
	{
		int beginOffset = BeginAddingRecord(314);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 斩妖除魔
	/// 杀死了{0}…
	/// </summary>
	public void AddDayueYaochangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(315);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 当煞立断
	/// 杀死了{0}…
	/// </summary>
	public void AddDayueYaochangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(316);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 九寒救苦
	/// 恢复了周围地格的资源…
	/// </summary>
	public void AddJiuhanGood()
	{
		int beginOffset = BeginAddingRecord(317);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 九寒为祸
	/// 毁坏了周围的地格…
	/// </summary>
	public void AddJiuhanBad()
	{
		int beginOffset = BeginAddingRecord(318);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 引禄招福
	/// 对{0}施加了天降横福…
	/// </summary>
	public void AddJinHuangerGood(int charId)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 引祸招恶
	/// 对{0}施加了天降横祸…
	/// </summary>
	public void AddJinHuangerBad(int charId)
	{
		int beginOffset = BeginAddingRecord(320);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 娱心唤情
	/// {0}对{1}心生爱慕…
	/// </summary>
	public void AddYiyihouGood(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 惑恨崩心
	/// {0}与{1}结下仇怨…
	/// </summary>
	public void AddYiyihouBad(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(322);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 护元度厄
	/// {0}受到了护佑…
	/// </summary>
	public void AddWeiQiGood(int charId)
	{
		int beginOffset = BeginAddingRecord(323);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 妖龙借甲
	/// {0}承担了伤病…
	/// </summary>
	public void AddWeiQiBad(int charId)
	{
		int beginOffset = BeginAddingRecord(324);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 解煞清神
	/// 附近人物的立场变为仁善…
	/// </summary>
	public void AddYixiangGood()
	{
		int beginOffset = BeginAddingRecord(325);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 邪光乱目
	/// 附近人物的立场变为叛逆…
	/// </summary>
	public void AddYixiangBad()
	{
		int beginOffset = BeginAddingRecord(326);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 荒天教习
	/// {0}受到了血枫的惩戒…
	/// </summary>
	public void AddXuefengGood(int charId)
	{
		int beginOffset = BeginAddingRecord(327);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 血枫为祸
	/// 在附近地格召来了相枢爪牙…
	/// </summary>
	public void AddXuefengBad()
	{
		int beginOffset = BeginAddingRecord(328);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 真仙化羽
	/// 减少了{0}的身龄…
	/// </summary>
	public void AddShufangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(329);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 鬼仙纳命
	/// 增加了{0}的身龄…
	/// </summary>
	public void AddShufangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(330);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 引禄招福
	/// 未能施加天降横福…
	/// </summary>
	public void AddJinHuangerGoodFailed()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 引禄招福
	/// 未能施加天降横祸…
	/// </summary>
	public void AddJinHuangerBadFailed()
	{
		int beginOffset = BeginAddingRecord(332);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 护元度厄
	/// 卫起开始护卫{0}…
	/// </summary>
	public void AddWeiQiGoodStart(int charId)
	{
		int beginOffset = BeginAddingRecord(333);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加即时通知 - 妖龙借甲
	/// 卫起开始为祸{0}…
	/// </summary>
	public void AddWeiQiBadStart(int charId)
	{
		int beginOffset = BeginAddingRecord(334);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}
}
