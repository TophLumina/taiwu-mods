using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.Notification;

[SerializableGameData(NotForDisplayModule = true)]
public class InstantNotificationCollection : WriteableRecordCollection
{
	public InstantNotificationCollection()
	{
	}

	public InstantNotificationCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

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

	public void AddNotificationWithNoArgument(short templateId)
	{
		Tester.Assert(InstantNotification.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	public void AddNotificationWithOneCharacterArgument(short recordType, int charId)
	{
		InstantNotificationItem config = InstantNotification.Instance[recordType];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 1 && ParameterType.Parse(config.Parameters[0]) == 0);
		int beginOffset = BeginAddingRecord(recordType);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddNotificationWithTwoCharacterArgument(short recordType, int charId, int charId1)
	{
		InstantNotificationItem config = InstantNotification.Instance[recordType];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) >= 2 && config.Parameters.Take(2).All((string p) => ParameterType.Parse(p) == 0));
		int beginOffset = BeginAddingRecord(recordType);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

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

	public void AddBuildingUpgradingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingDemolitionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingCraftingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingConstructionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingProductGenerated(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingDamaged(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingRuined(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeginBuildingConstruction(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeginBuildingUpgrading(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeginBuildingDemolition(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCancelBuildingDemolition(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCandidateArrived(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCandidateLeaved(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinTaiwuVillage(int charId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLeaveTaiwuVillage(int charId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWarehouseItemLost(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingLoseAuthority(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDiscoverRelay(Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddWalkThroughAbyss()
	{
		int beginOffset = BeginAddingRecord(18);
		EndAddingRecord(beginOffset);
	}

	public void AddBeginAdventure(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddNaturalDisasterEncountered(Location location)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinGroup(int charId)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLeaveGroup(int charId)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeChanged(int charId, sbyte behaviorType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendBehaviorType(behaviorType);
		EndAddingRecord(beginOffset);
	}

	public void AddSectInheritedApprovingReceived(short settlementId)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddInheritedApprovingRateReceived(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFameIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFameDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHappinessIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHappinessDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFavorabilityIncreased(short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddFavorabilityDecreased(short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddFavorabilityIncreasedAcrossLevels(int charId, int charId1, sbyte favorabilityType)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendFavorabilityType(favorabilityType);
		EndAddingRecord(beginOffset);
	}

	public void AddFavorabilityDecreasedAcrossLevels(int charId, int charId1, sbyte favorabilityType)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendFavorabilityType(favorabilityType);
		EndAddingRecord(beginOffset);
	}

	public void AddLovingItemRevealed(short settlementId, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	public void AddHatingItemRevealed(short settlementId, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	public void AddLovingItemRevealedNothing(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHatingItemRevealedNothing(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddEatBloodDew(int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillLearned(int charId, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddHealthIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHealthDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuInfectionIncreased(int charId)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuInfectionDecreased(int charId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuPartlyInfected(int charId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuCompletelyInfected(int charId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainAttributeRecovered(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMainAttributeConsumed(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDisorderOfQiIncreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDisorderOfQiDecreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddInjuryIncreased(int charId, sbyte bodyPartType, sbyte injuryType)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendBodyPartType(bodyPartType);
		AppendInjuryType(injuryType);
		EndAddingRecord(beginOffset);
	}

	public void AddInjuryDecreased(int charId, sbyte bodyPartType, sbyte injuryType)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendBodyPartType(bodyPartType);
		AppendInjuryType(injuryType);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonIncreased(int charId, sbyte poisonType, int value)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDecreased(int charId, sbyte poisonType, int value)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddExpIncreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddExpDecreased(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddResourceIncreased(int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddResourceDecreased(int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddGetItem(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseItem(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCharacterGrownUp(int charId)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCharacterDead(int charId)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDead(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyDied(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyDied(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyLucky(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyUnlucky(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyLoseInLifeSkill(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyLoseInCombat(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyGreatLoseInCombat(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyMiscarriage(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAbandonExposed(int charId)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAbandonAcknowledged(int charId)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyAbandon(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSelfImmoralLove(int charId)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyHaveKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddHaveKid(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyImmoralKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddReligiousFamilyHaveKid(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyInLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyImmoralLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddReligiousFamilyInLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyMarried(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyImmoralMarriage(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyBeFriendWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyJieyiWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyAdoptedMaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyAdoptedFemaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyAdoptedByMaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyAdoptedByFemaleEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyEndedImmoralLove(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyEndedFriendshipWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyEndedJieyiWithEnemy(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddLoverHaveSex(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillageIdleCount(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionSeniorityIncrease(int professionTemplateId)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendProfession(professionTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionUnlockSkill(int professionTemplateId, int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendProfession(professionTemplateId);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionSkillHasCoolDown(int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionSkillEffectIsEnd(int skillTemplateId)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendProfessionSkill(skillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionHunterSkill0(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionMartialArtistSkill2(Location location, sbyte combatSkillType, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendLocation(location);
		AppendCombatSkillType(combatSkillType);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionLiteratiSkill2(Location location, sbyte lifeSkillType, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionCivilianSkill1(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionCivilianSkill2(int charId, int charId1, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionDoctorSkill1(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionMonkBreakFoodRule(int charId, int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionMonkBreakLoveRule(int charId, int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionHunterSkill0None()
	{
		int beginOffset = BeginAddingRecord(106);
		EndAddingRecord(beginOffset);
	}

	public void AddSettlementStoryGoodEnd(short settlementId)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSettlementStoryBadEnd(short settlementId)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddReadInCombat(sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddReadInLifeSkillCombat(sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddReadInCombatNoChance(sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddReadInLifeSkillCombatNoChance(sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBookRepairSuccess(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddReincarnationArchitectureReincarnationEnd(int charId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTheNestOfRegulationDies(Location location, int adventureCoreId, int charId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXuannvBlockMusicTranscribe(short settlementId, short musicTemplateId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendSettlement(settlementId);
		AppendMusic(musicTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddXuannvStateMusicTranscribe(sbyte stateTemplateId, short musicTemplateId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendMapState(stateTemplateId);
		AppendMusic(musicTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDuChuangYiGeReady(int charId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCultureDecline(short settlementId, int charId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddThunderPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFloodPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBlazePowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStormPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSandPowerGrow(int value)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddThunderPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFloodPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBlazePowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStormPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSandPowerDecline(int value)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityUp(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityDown(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoGiftAbilityUp(int jiaoLoongId, short jiaoPropertyId)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoGiftAbilityDown(int jiaoLoongId, short jiaoPropertyId)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityUpPercent(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityDownPercent(int jiaoLoongId, short jiaoPropertyId, int value)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityUpFloat(int jiaoLoongId, short jiaoPropertyId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoAbilityDownFloat(int jiaoLoongId, short jiaoPropertyId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoProperty(jiaoPropertyId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingEscape(sbyte itemType, short itemTemplateId, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingParasitiferDead(sbyte itemType, short itemTemplateId, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingDead(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingDeadSpecial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKnowMonkSecret(int charId)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGraceIncreased(Location location)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingEscape1(sbyte itemType, short itemTemplateId, short charTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendItem(itemType, itemTemplateId);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingEscape2(sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddQiArtInCombatNoChance(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddQiArtInLifeSkillCombatNoChance(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectStoryBaihuaToAnimal(int charId)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectStoryBaihuaToHuman()
	{
		int beginOffset = BeginAddingRecord(149);
		EndAddingRecord(beginOffset);
	}

	public void AddMechanismOfDetonation()
	{
		int beginOffset = BeginAddingRecord(150);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionSeniorityIncrease1(int professionTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendProfession(professionTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBlockResourceRecovery(int value)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddShenTreeGrow()
	{
		int beginOffset = BeginAddingRecord(153);
		EndAddingRecord(beginOffset);
	}

	public void AddBeastUpgrade(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeastDowngrade(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGatherCompanions(int value, int value1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddDisseminateSecretInformation(short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddDisseminateInformation(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRecommendFellowUp(int charId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddRecommendFellowDown(int charId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddComradePropertyUp(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeCombatSkillUp(int charId)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeLifeSkillUp(int charId)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeFeatureUp(int charId)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddReleasePrisoners(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDriveAwayPeople(Location location)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddQuenchHatred(int value)
	{
		int beginOffset = BeginAddingRecord(167);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVisitTemple(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(168);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDrinkTeaRecharge(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(169);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddReleaseSouls(int value)
	{
		int beginOffset = BeginAddingRecord(170);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishmentWarrantRelieved(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(171);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishmentCharacterFeatureRelieved(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(172);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResignationPosition(int charId)
	{
		int beginOffset = BeginAddingRecord(173);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegacy(short legacyTemplateId)
	{
		int beginOffset = BeginAddingRecord(174);
		AppendLegacy(legacyTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCultureUp(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(175);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSecurityUp(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(176);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddCultureDown(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(177);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSecurityDown(short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(178);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsResource(Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(179);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsFoodIngredients(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(180);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsMaterials(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(181);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsHerbal0(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(182);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsHerbal1(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(183);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsPoison(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(184);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsInjuryMedicine(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(185);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsAntidote(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(186);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsGainMedicine(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(187);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsFruit(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(188);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsChickenDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(189);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsMeatDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(190);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsVegetarianDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(191);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsSeafoodDishes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(192);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsWine(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(193);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsTea(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(194);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsTool(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(195);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsAccessory(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(196);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsPoisonCream(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(197);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsHarrier(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(198);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsToken(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(199);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsNeedleBox(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(200);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsThorn(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(201);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsHiddenWeapon(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(202);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsFlute(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(203);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsGloves(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(204);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsFurGloves(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(205);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsPestle(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(206);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsSword(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(207);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsBlade(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(208);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsPolearm(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(209);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupQin(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(210);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsWhisk(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(211);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsWhip(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(212);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsCrest(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(213);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsShoes(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(214);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsArmor(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(215);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsArmGuard(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(216);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsCarDrop(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsExp(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(218);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsReading()
	{
		int beginOffset = BeginAddingRecord(219);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsQiArt()
	{
		int beginOffset = BeginAddingRecord(220);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsMorale(sbyte stateTemplateId)
	{
		int beginOffset = BeginAddingRecord(221);
		AppendMapState(stateTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsProperty(int charId, short characterPropertyReferencedType, int value)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsEnemyEscape(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(223);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingExp(int value)
	{
		int beginOffset = BeginAddingRecord(224);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddWalkThroughDestroyBlock()
	{
		int beginOffset = BeginAddingRecord(225);
		EndAddingRecord(beginOffset);
	}

	public void AddWalkThroughErosionBlock()
	{
		int beginOffset = BeginAddingRecord(226);
		EndAddingRecord(beginOffset);
	}

	public void AddComradePropertyUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeCombatSkillUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(228);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeLifeSkillUpNew(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(229);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddComradePropertyUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(230);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeCombatSkillUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(231);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	public void AddComradeLifeSkillUpNew1(int charId, sbyte charGrade)
	{
		int beginOffset = BeginAddingRecord(232);
		AppendCharacter(charId);
		AppendCharGrade(charGrade);
		EndAddingRecord(beginOffset);
	}

	public void AddCharacterEscape(int charId)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGraceUp(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(234);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddGraceDown(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(235);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddExpelEnemy(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(236);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddExpelRighteous(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(237);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddExpelXiangshuMinion(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(238);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddExpelBeast(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsPoisonCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(240);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsInjuryMedicineCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsAntidoteCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsGainMedicineCorrected(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsResourceUpdate(sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(244);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsExpUpdate(int value)
	{
		int beginOffset = BeginAddingRecord(245);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsMoraleUpdate(sbyte stateTemplateId)
	{
		int beginOffset = BeginAddingRecord(246);
		AppendMapState(stateTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsItemUpdate(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(247);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsReadingUpdate()
	{
		int beginOffset = BeginAddingRecord(248);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsQiArtUpdate()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeItemOutsideSettlement()
	{
		int beginOffset = BeginAddingRecord(250);
		EndAddingRecord(beginOffset);
	}

	public void AddGainFuyuFaith1(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddGainFuyuFaith2(int value, int value1)
	{
		int beginOffset = BeginAddingRecord(252);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddGainFuyuFaith3(int value)
	{
		int beginOffset = BeginAddingRecord(253);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMapPickupsMedicineUpdate(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(254);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddJixiKillTemplateEnemy(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(255);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddNeiliRecovery(int charId)
	{
		int beginOffset = BeginAddingRecord(256);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureRedeem(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureCharacterFollow(int charId)
	{
		int beginOffset = BeginAddingRecord(258);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureStopFollow(int charId)
	{
		int beginOffset = BeginAddingRecord(259);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureAttendBanquet(int charId)
	{
		int beginOffset = BeginAddingRecord(260);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureKillHeretics(int charId)
	{
		int beginOffset = BeginAddingRecord(261);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureBecomeEnemy(int charId)
	{
		int beginOffset = BeginAddingRecord(262);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureMusicStart()
	{
		int beginOffset = BeginAddingRecord(263);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureChessStart()
	{
		int beginOffset = BeginAddingRecord(264);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventurePoemStart()
	{
		int beginOffset = BeginAddingRecord(265);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventurePaintStart()
	{
		int beginOffset = BeginAddingRecord(266);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureGiveUpRedeem(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(267);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneBuffMetal(int charId)
	{
		int beginOffset = BeginAddingRecord(268);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneBuffWood(int charId)
	{
		int beginOffset = BeginAddingRecord(269);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneBuffWater(int charId)
	{
		int beginOffset = BeginAddingRecord(270);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneBuffFire(int charId)
	{
		int beginOffset = BeginAddingRecord(271);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneBuffEarth(int charId)
	{
		int beginOffset = BeginAddingRecord(272);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffMetal0(int charId)
	{
		int beginOffset = BeginAddingRecord(273);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffWood0(int charId)
	{
		int beginOffset = BeginAddingRecord(274);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffWater0(int charId)
	{
		int beginOffset = BeginAddingRecord(275);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffFire0(int charId)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffEarth0(int charId)
	{
		int beginOffset = BeginAddingRecord(277);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffMetal1(int charId)
	{
		int beginOffset = BeginAddingRecord(278);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffWood1(int charId)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffWater1(int charId)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffFire1(int charId)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDElementStoneDeBuffEarth1(int charId)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDNeiliChangeMetal(int charId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDNeiliChangeWood(int charId)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDNeiliChangeWater(int charId)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDNeiliChangeFire(int charId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureXRSDNeiliChangeEarth(int charId)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureCharacterDie(int charId, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(283);
		AppendCharacter(charId);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureCharacterDie0(int elementCoreId, string text, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendAdventureElement(elementCoreId);
		AppendText(text);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAlertnessUp(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAlertnessDown(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketHPUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketSPUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketVigorUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketStrengthUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketBiteUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(297);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDeadlinessUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDamageUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketCrippleUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(300);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDefenceUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(301);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDamageReduceUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(302);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketCounterUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(303);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketDurabilityUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(304);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddBlastTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(305);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddShootTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGasTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(307);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddScreamTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMistTrap(int charId)
	{
		int beginOffset = BeginAddingRecord(309);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAutoOperationDiscard(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(310);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAutoOperationDisassemble(sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(311);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPrepareEscape(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(312);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvGood(int charId)
	{
		int beginOffset = BeginAddingRecord(313);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvBad(int charId)
	{
		int beginOffset = BeginAddingRecord(314);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(315);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(316);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiuhanGood()
	{
		int beginOffset = BeginAddingRecord(317);
		EndAddingRecord(beginOffset);
	}

	public void AddJiuhanBad()
	{
		int beginOffset = BeginAddingRecord(318);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerGood(int charId)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerBad(int charId)
	{
		int beginOffset = BeginAddingRecord(320);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddYiyihouGood(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddYiyihouBad(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(322);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiGood(int charId)
	{
		int beginOffset = BeginAddingRecord(323);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiBad(int charId)
	{
		int beginOffset = BeginAddingRecord(324);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangGood()
	{
		int beginOffset = BeginAddingRecord(325);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangBad()
	{
		int beginOffset = BeginAddingRecord(326);
		EndAddingRecord(beginOffset);
	}

	public void AddXuefengGood(int charId)
	{
		int beginOffset = BeginAddingRecord(327);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddXuefengBad()
	{
		int beginOffset = BeginAddingRecord(328);
		EndAddingRecord(beginOffset);
	}

	public void AddShufangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(329);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddShufangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(330);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerGoodFailed()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerBadFailed()
	{
		int beginOffset = BeginAddingRecord(332);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiGoodStart(int charId)
	{
		int beginOffset = BeginAddingRecord(333);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiBadStart(int charId)
	{
		int beginOffset = BeginAddingRecord(334);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuAsXiangshuSkill0(int charId)
	{
		int beginOffset = BeginAddingRecord(335);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuAsXiangshuSkill1(int charId)
	{
		int beginOffset = BeginAddingRecord(336);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}
}
