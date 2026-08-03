using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord;

[SerializableGameData(NotForDisplayModule = true)]
public class LifeRecordCollection : WriteableRecordCollection
{
	private const int DefaultCapacity = 65536;

	public LifeRecordCollection()
		: this(65536)
	{
	}

	public LifeRecordCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	private unsafe int BeginAddingRecord(int selfCharId, int date, short type)
	{
		int offset = Size;
		int newSize = Size + 4 + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			*(int*)pCurrData = selfCharId;
			*(int*)(pCurrData + 4 + 1) = date;
			((short*)(pCurrData + 4 + 1))[2] = type;
		}
		return offset + 4;
	}

	private static Exception CreateRelatedRecordIdException(short relatedRecordId)
	{
		return new Exception($"Unsupported relatedRecordId: {relatedRecordId}");
	}

	public void AddDie(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 0);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuPartiallyInfected(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuCompletelyInfected(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 2);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherLoseFetus(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 3);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFatherLoseFetus(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 4);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAbandonChild(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 5);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 6);
		AppendCharacter(selfCharId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToCricket(int selfCharId, int date, Location location, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 7);
		AppendLocation(location);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToBoy(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 8);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToGirl(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 9);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeFatherToNewBornBoy(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 10);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeFatherToNewBornGirl(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 11);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildGrave(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 12);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMonkBreakRule(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 13);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnappedCharacterEscaped(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 14);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 15);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReadBookSucceed(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 16);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddReadBookFail(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 17);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBreakoutSucceed(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 18);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBreakoutFail(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 19);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnCombatSkill(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 20);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnLifeSkill(int selfCharId, int date, Location location, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 21);
		AppendLocation(location);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRepairItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 22);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAddPoisonToItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 23);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseOverloadingResource(int selfCharId, int date, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 24);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseOverloadingItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 25);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeEnemy(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 26);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 28);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverEnemy(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 27);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 29);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdore(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 30);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLoveAtFirstSight(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 31);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 31);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddConfessLoveSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 32);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 34);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddConfessLoveFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 33);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 35);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBreakupMutually(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 36);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 36);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDumpLover(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 37);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 38);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddProposeMarriageSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 39);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 39);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddProposeMarriageFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 40);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 41);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeFriend(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 42);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 42);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverFriendship(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 43);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 43);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeSwornBrotherOrSister(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 44);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 44);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverSwornBrotherhood(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 45);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 45);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedByFather(int selfCharId, int date, int charId, Location location, short relatedRecordId)
	{
		if (relatedRecordId != 48 && relatedRecordId != 49)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 46);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedByMother(int selfCharId, int date, int charId, Location location, short relatedRecordId)
	{
		if (relatedRecordId != 48 && relatedRecordId != 49)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 47);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptSon(int selfCharId, int date, int charId, Location location, short relatedRecordId)
	{
		if (relatedRecordId != 46 && relatedRecordId != 47)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 48);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptDaughter(int selfCharId, int date, int charId, Location location, short relatedRecordId)
	{
		if (relatedRecordId != 46 && relatedRecordId != 47)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 49);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCreateFaction(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 50);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinFaction(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 51);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLeaveFaction(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 52);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFactionRecruitSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 53);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 55);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFactionRecruitFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 54);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 56);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToJoinSect(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 57);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToFullfillAppointment(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 58);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToProtect(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 59);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToRescue(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 60);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToMourn(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 61);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToVisit(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 62);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToFindLostItem(int selfCharId, int date, Location location, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 63);
		AppendLocation(location);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToFindSpecialMaterial(int selfCharId, int date, Location location, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 64);
		AppendLocation(location);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToRevenge(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 65);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToParticipateAdventure(int selfCharId, int date, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 66);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinSectFail(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 67);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinSectSucceed(int selfCharId, int date, Location location, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 68);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddCanNoLongerFullFillAppointment(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 69);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWaitForAppointment(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 70);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFullFillAppointment(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 71);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishProtection(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 72);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddOfferProtection(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 73);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishRescue(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 74);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishMourning(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 75);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMaintainGrave(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 76);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddUpgradeGrave(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 77);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishVisit(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 78);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishFIndingLostItem(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 79);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishFIndingSpecialMaterial(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 80);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFindLostItemSucceed(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 81);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindLostItemFail(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 82);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFindSpecialMaterialSucceed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 83);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishTakingRevenge(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 84);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMajorVictoryInCombat(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 85);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 86);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddMajorFailureInCombat(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 86);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 85);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddVictoryInCombat(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 87);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 88);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddFailureInCombat(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 88);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 87);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyEscape(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 89);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 90);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseAndEscape(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 90);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 89);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKillInPublic(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 91);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 712);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKillInPrivate(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 92);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 713);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnapInPublic(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 93);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 96);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnapInPrivate(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 94);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 97);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddReleaseLoser(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 95);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 98);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAgreeToProtect(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 99);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRefuseToProtect(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 100);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishAdventure(int selfCharId, int date, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 101);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealOuterInjurySucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 138);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealInnerInjurySucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 139);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestDetoxPoisonSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 140);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealthSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 141);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealDisorderOfQiSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 142);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestNeiliSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 143);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestKillWugSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 144);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestFoodSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 109);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 145);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestTeaWineSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 110);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 146);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestResourceSucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 111);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 147);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 112);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 148);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestRepairItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 113);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 149);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestAddPoisonToItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 114);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 150);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnLifeSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 115);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 151);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnCombatSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 116);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 152);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnLifeSkillFailToLearn(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 117);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 153);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnCombatSkillFailToLearn(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 118);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 154);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnReadingSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 119);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 155);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnBreakoutSucceed(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 120);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 156);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealOuterInjuryFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 121);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 157);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealInnerInjuryFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 122);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 158);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestDetoxPoisonFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 123);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 159);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealthFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 124);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 160);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealDisorderOfQiFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 125);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 161);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestNeiliFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 126);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 162);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestKillWugFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 127);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 163);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestFoodFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 128);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 164);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestTeaWineFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 129);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 165);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestResourceFail(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 130);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 166);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestItemFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 131);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 167);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestRepairItemFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 132);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 168);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestAddPoisonToItemFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 133);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 169);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnLifeSkillFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 134);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 170);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnCombatSkillFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 135);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 171);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnReadingFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 136);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 172);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnBreakoutFail(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 137);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 173);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyFail1(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 174);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyFail2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 175);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyFail3(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 176);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyFail4(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 177);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlySucceed(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 178);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 180);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlySucceedAndEscaped(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 179);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 180);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitFail1(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 181);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitFail2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 182);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitFail3(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 183);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitFail4(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 184);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitSucceed(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 185);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 187);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWitSucceedAndEscaped(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 186);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 187);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceFail1(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 188);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceFail2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 189);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceFail3(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 190);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceFail4(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 191);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceSucceed(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 192);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 194);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForceSucceedAndEscaped(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 193);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 194);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 195);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 196);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 197);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 198);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemySucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 199);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 201);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemySucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 200);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 201);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail1(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 202);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail2(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 203);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail3(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 204);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail4(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 205);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemySucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 206);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 208);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemySucceedAndEscaped(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 207);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 208);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFail1(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 209);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFail2(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 210);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFail3(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 211);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFail4(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 212);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceSucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 213);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 216);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 214);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 216);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFailAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 215);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 217);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceFail1(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 218);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceFail2(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 219);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceFail3(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 220);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceFail4(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 221);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceSucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 222);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 225);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 223);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 225);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResourceFailAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 224);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 226);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFail1(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 227);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFail2(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 228);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFail3(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 229);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFail4(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 230);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceSucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 231);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 234);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 232);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 234);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFailAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 233);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 235);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 236);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 237);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 238);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 239);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 240);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 243);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 241);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 243);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemSucceedAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 242);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 244);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 245);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 246);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 247);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 248);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 249);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 252);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 250);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 252);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItemFailAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 251);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 253);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 254);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 255);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 256);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 257);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 258);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 261);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 259);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 261);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFailAndBeatenUp(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 260);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 262);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFromGraveSucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 263);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFromGraveFail(int selfCharId, int date, int charId, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 264);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFromGraveSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFromGraveFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 266);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 267);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 268);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 269);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 270);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 271);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 273);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 272);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 273);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 274);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 275);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 276);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 277);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 278);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 280);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkillSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 279);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 280);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 281);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 282);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 283);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 284);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 285);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 287);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 286);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 287);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillFail1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 288);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillFail2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 289);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillFail3(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 290);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillFail4(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 291);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 292);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 294);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkillSucceedAndEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 293);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 294);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleWin(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 295);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleLose(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 296);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExchangeResource(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value, sbyte resourceType1, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 297);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendResource(resourceType1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveResource(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 298);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 303);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddPurchaseItem(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 299);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSellItem(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 300);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveItem(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 301);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 304);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGivePoisonousItem(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 302);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 305);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRefusePoisonousGift(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 305);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 302);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnLifeSkillWithInstructionSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 308);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 306);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnLifeSkillWithInstructionFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 309);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 306);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnCombatSkillWithInstructionSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 310);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 307);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLearnCombatSkillWithInstructionFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 311);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 307);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddInviteToDrinkSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 312);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 327);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddInviteToDrinkFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 313);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 328);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSellSucceed(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 314);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 329);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSellFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 315);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 330);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCureSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 316);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 331);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRepairItemSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 317);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 332);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBarbSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 318);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 333);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBarbMistake(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 319);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 334);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBarbFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 320);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 335);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAskForMoneySucceed(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 321);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 336);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAskForMoneyFail(int selfCharId, int date, int charId, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 322);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 337);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddEntertainWithMusic(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 323);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 338);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEntertainWithChess(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 324);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 339);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEntertainWithPoem(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 325);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 340);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEntertainWithPainting(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 326);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 341);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 342);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaoismAwakeningSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 343);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 347);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTaoismAwakeningFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 344);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 348);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBuddismAwakeningSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 345);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 349);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBuddismAwakeningFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 346);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 350);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCollectTeaWineSucceed(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 351);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCollectTeaWineFail(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 352);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDivinationSucceed(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 353);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformationTemplate(secretInfoTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDivinationFail(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 354);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketBattleWin(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 355);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 356);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketBattleLose(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 356);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 355);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeLoveLegal(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1401);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1401);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeLoveIllegal(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 357);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 357);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRapeFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 358);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 361);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRapeSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 359);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 362);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReleaseKidnappedCharacter(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 360);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 363);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMerchantGetNewProduct(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 364);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedResourceGain(int selfCharId, int date, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 365);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedItemGain(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 366);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedSkillBookGain(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 367);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedHealthCure(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 368);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedOuterInjuryCure(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 369);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedInnerInjuryCure(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 370);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedPoisonCure(int selfCharId, int date, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 371);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedDisorderOfQiCure(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 372);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedResourceLose(int selfCharId, int date, Location location, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 373);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedItemLose(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 374);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedSkillBookLose(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 375);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedHealthHarm(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 376);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedOuterInjuryHarm(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 377);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedInnerInjuryHarm(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 378);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedPoisonHarm(int selfCharId, int date, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 379);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedDisorderOfQiHarm(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 380);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKillHereticRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 381);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillRighteousRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 382);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByHereticRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 383);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByRighteousRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 384);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 385);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 386);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 387);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddYiyihouBad(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 388);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 389);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 390);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddShufangBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 391);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJixiBad(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 392);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 393);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 394);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangerGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 395);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddYiyihouGood(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 396);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 397);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 398);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXuefengGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 399);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddShufangGood(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 400);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 401);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 402);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 403);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 404);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara4(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 405);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnantWithSamsara5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 406);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGainAuthority(int selfCharId, int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 407);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishNormal(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 408);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishElope(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 409);
		EndAddingRecord(beginOffset);
	}

	public void AddExpelVillager(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 410);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 413);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSavedFromInfection(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 411);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 691);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddChangeGrade(int selfCharId, int date, Location location, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 412);
		AppendLocation(location);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddInsteadSectPunishElope(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 414);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAvoidSectPunishElope(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 415);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinJoustForSpouse(int selfCharId, int date, Location location, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 416);
		AppendLocation(location);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetHusbandByJoustForSpouse(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 417);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGetWifeByJoustForSpouse(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 418);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNoHusbandByJoustForSpouse(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 419);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectCompetitionBeWinner(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 420);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectCompetitionBeParticipant(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 421);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectCompetitionBeHost(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 422);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceBeParticipant(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 423);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceBeWinner(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 424);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceBeWinnerButTaiwu(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 425);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceBeHost(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 426);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceBeKilledByYufu(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 427);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceDonation(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 428);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeAttackedAndDieByWuYingLing(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 429);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNaturalDisasterGiveDeath(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 430);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNaturalDisasterHappen(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 431);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNaturalDisasterButSurvive(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 432);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeLovingItemSubType(int selfCharId, int date, Location location, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 433);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeHatingItemSubType(int selfCharId, int date, Location location, int charId, short itemSubType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 434);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendItemSubType(itemSubType);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeIdealSect(int selfCharId, int date, Location location, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 435);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeBaseMorality(int selfCharId, int date, Location location, int charId, sbyte behaviorType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 436);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendBehaviorType(behaviorType);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeLifeSkillTypeInterest(int selfCharId, int date, Location location, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 437);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobGraveEncounterSkeleton(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 438);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobGraveFailed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 439);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishLevelLowest(int selfCharId, int date, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 440);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	public void AddPrincipalSectPunishLevelMiddle(int selfCharId, int date, short punishmentType, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 441);
		AppendPunishmentType(punishmentType);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddPrincipalSectPunishLevelHighest(int selfCharId, int date, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 442);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	public void AddNonPrincipalSectPunishLevelLowest(int selfCharId, int date, short punishmentType, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 443);
		AppendPunishmentType(punishmentType);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddNonPrincipalSectPunishLevelHighest(int selfCharId, int date, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 444);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeSwornSiblingByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 445);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMarriedByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 446);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedFatherByThreatened(int selfCharId, int date, int charId, Location location, int charId1, short relatedRecordId)
	{
		if (relatedRecordId != 461 && relatedRecordId != 462)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 447);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedMotherByThreatened(int selfCharId, int date, int charId, Location location, int charId1, short relatedRecordId)
	{
		if (relatedRecordId != 461 && relatedRecordId != 462)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 448);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedSonByThreatened(int selfCharId, int date, int charId, Location location, int charId1, short relatedRecordId)
	{
		if (relatedRecordId != 459 && relatedRecordId != 460)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 449);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedDaughterByThreatened(int selfCharId, int date, int charId, Location location, int charId1, short relatedRecordId)
	{
		if (relatedRecordId != 459 && relatedRecordId != 460)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 450);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAddMentorByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 451);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverSwornSiblingByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 452);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDivorceByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 453);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverMentorByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 454);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveFatherByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 455);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveMotherByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 456);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveSonByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 457);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveDaughterByThreatened(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 458);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddApproveTaiwuByThreatened(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 463);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFourSeasonsAdventureBeParticipant(int selfCharId, int date, Location location, int adventureCoreId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 464);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddFourSeasonsAdventureBeWinner(int selfCharId, int date, Location location, int adventureCoreId, short titleTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 465);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacterTitle(titleTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEndAdored(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 466);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGetMentor(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 467);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 468);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGetMentee(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 468);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 467);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveParent(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 469);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 470);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverAdoptiveChild(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 470);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 469);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverMentor(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 471);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 472);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverMentee(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 472);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDivorce(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 473);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 473);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddThreatenSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 474);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdmonishSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 475);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddChangeBehaviorTypeByAdmonishedGood(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 476);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReduceDebtByAdmonished(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 477);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReduceDebtByThreatened(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 478);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddChangeBehaviorTypeByAdmonishedBad(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 479);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGainLegendaryBook(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 480);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBoostedByLegendaryBooks(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 481);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddActCrazy(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 482);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookShocked(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 483);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookInsane(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 484);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookConsumed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 485);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToContestForLegendaryBook(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 486);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishContestForLegendaryBook(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 487);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookChallengeWin(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 488);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 491);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookChallengeLose(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 489);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 490);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAcceptLegendaryBookChallengeEscape(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 492);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 493);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookChallengeSelfEscaped(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 494);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 495);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRefuseRequestLegendaryBookChallenge(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 496);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 497);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAcceptRequestLegendaryBook(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 498);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 499);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestLegendaryBookFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 500);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 501);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAcceptRequestExchangeLegendaryBook(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 502);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 503);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRefuseRequestExchangeLegendaryBook(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 504);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 505);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveLegendaryBookFail(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 506);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 507);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLegendaryBookInsaneJust(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 508);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 513);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLegendaryBookInsaneKind(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 509);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 514);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLegendaryBookInsaneEven(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 510);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 515);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLegendaryBookInsaneRebel(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 511);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 516);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLegendaryBookInsaneEgoistic(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 512);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 517);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddShockedInsaneEscaped(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 518);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 519);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddUnderAttackEscaped(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 520);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 521);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatConsumed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 522);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 523);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAcceptRequestExchangeLegendaryBookByExp(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 524);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 525);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddResignPositionToStudyLegendaryBook(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 526);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddSoundOutLoverMind(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 527);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 528);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRedeemMindSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 529);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 531);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRedeemMindFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 530);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 532);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFirstDateWithLover(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 533);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 534);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSelectLoverToken(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 535);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 536);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDateWithLover(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 537);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 538);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTillDeathDoUsPart(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 539);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCelebrateBirthday(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 540);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 541);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCelebrateAnniversary(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 542);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBeCaughtCheating(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 543);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 544);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnancyWithWife(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 545);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 546);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTeaTasting(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 547);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTeaTastingLifeSkillBattleWin(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 548);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 549);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTeaTastingDisorderOfQi(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 550);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWineTasting(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 551);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWineTastingLifeSkillBattleWin(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 552);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 553);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWineTastingDisorderOfQi(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 554);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFirstNameChanged(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 555);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillModel(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 556);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillModel(int selfCharId, int date, Location location, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 557);
		AppendLocation(location);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddPromoteReputation(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 558);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 559);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCapabilityCultivated(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 560);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBroughtToTaiwuByBeggars(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 561);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDiscardRevengeForCivilianSkill(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 562);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCivilianSkillDissolveResentment(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 563);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPersuadeWithdrawlFromOrganization(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 564);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 565);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFreeMedicalConsultation(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 566);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddOfferTreasures(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 567);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 568);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddForcefulPurchase(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 569);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 570);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBegForMoney(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 571);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAbsurdlyForceToLeave(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 572);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 573);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDiagnoseWithMedicine(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 574);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 575);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDiagnoseWithNonMedicine(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 576);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 577);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExtendLifeSpan(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 578);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 579);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPersuadeToBecomeMonk(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 580);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 581);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFailToPersuadeToBecomeMonk(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 582);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExpiateDeadSouls(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 583);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExociseXiangshuInfectionVictoryInCombat(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 584);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 585);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExociseXiangshuInfectionVictoryInCombatDefeated(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 586);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTribulationSucceeded(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 587);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTribulationFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 588);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTribulationCanceled(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 589);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTribulationContinued(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 590);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGuidingEvilToGoodSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 591);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 592);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGuidingEvilToGoodFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 593);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVisitBuddhismTemples(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 594);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEpiphanyThruVisitTemples(int selfCharId, int date, Location location, short combatSkillTemplateId, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 595);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEpiphanyThruVisitTemplesCombatSkill(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 596);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEpiphanyThruVisitTemplesLifeSkill(int selfCharId, int date, Location location, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 597);
		AppendLocation(location);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEpiphanyThruVisitTemplesExperience(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 598);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDivineUnexpectedGain(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 599);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDivineUnexpectedHarm(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 600);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExchangeFates(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 601);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 602);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddImmortalityGained(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 603);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddImmortalityLost(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 604);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddImmortalityRegained(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 605);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuReincarnation(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 606);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuReincarnationPregnancy(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 607);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRedRotten(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 608);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRottenIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 609);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRottenGloomy(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 610);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRottenCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 611);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedRottenIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 612);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedRottenGloomy(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 613);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedRottenCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 614);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRedIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 615);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRedGloomy(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 616);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotRedCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 617);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonGloomyColdIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 618);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRottenGloomyCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 619);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotGloomyCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 620);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedGloomyCold(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 621);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRottenColdIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 622);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotColdIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 623);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedColdIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 624);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRottenGloomyIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 625);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonHotGloomyIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 626);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMixPoisonRedGloomyIllusory(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 627);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDiggingXiangshuMinionCombatLost(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 628);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDiggingXiangshuMinionCombatWon(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 629);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiKills(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 630);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangTreasure(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 631);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuannvJoinOrg(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 632);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanGetAbsorbed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 633);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanResistSucceed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 634);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanResistOrdinary(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 635);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanResistFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 636);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouZombieKills(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 637);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangSkillEnemy(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 638);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianMethysis0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 639);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianPoison(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 640);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianAssault(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 641);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianMethysis1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 642);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiInfighting(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 643);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingAssassin(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 644);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferencePraiseAndGifts(int selfCharId, int date, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 645);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeIdealSectNegative(int selfCharId, int date, Location location, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 646);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiRescueTaiwu(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 647);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanJoinThreeFactionCompetetion(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 648);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanThreeFactionCompetetionWin(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 649);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanThreeFactionCompetetionLose(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 650);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGainExpByStroll(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 651);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGainExpByReadingOldBook(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 652);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPunishedAlongsideSpouse(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 653);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToAdoptFoundling(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 654);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptFoundlingFail(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 655);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptFoundlingSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 656);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 657);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddClaimFoundlingSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 658);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 659);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangVillagerKilled(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 660);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangFallIll(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 661);
		EndAddingRecord(beginOffset);
	}

	public void AddKillAnimal(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 662);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByAnimal(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 663);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEnterEnemyNest(int selfCharId, int date, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 664);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromEnemyNest(int selfCharId, int date, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 665);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromEnemyNest(int selfCharId, int date, int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 666);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 692);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddGetSecretSpreadInVeryHighProbability(int selfCharId, int date, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 667);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddGetSecretSpreadInHighProbability(int selfCharId, int date, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 668);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddGetSecretSpreadInLowProbability(int selfCharId, int date, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 669);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddGetSecretSpreadInVeryLowProbability(int selfCharId, int date, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 670);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddSpreadSecretFail(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 671);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddSpreadSecretSuccess(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 672);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddHeardSecretSpreadInVeryHighProbability(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 673);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddHeardSecretSpreadInHighProbability(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 674);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddHeardSecretSpreadInLowProbability(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 675);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddHeardSecretSpreadInVeryLowProbability(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 676);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestKeepSecretFail(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 677);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestKeepSecretSuccess(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 678);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeRequestedToKeepSecret(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 679);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleMatchFail(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 680);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleSeparateFail(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 681);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleMatchSuccess(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 682);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleSeparateSuccess(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 683);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleBeMatched1(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 684);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleBeSeparated1(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 685);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleBeMatched2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 686);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddThreadNeedleBeSeparated2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 687);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSpreadSecretKnown(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 688);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuannvBirthOfMirrorCreatedImposture(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 689);
		AppendCharacterRealName(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromEnemyNestBySelf(int selfCharId, int date, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 690);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddSaveFromEnemyNestFailed(int selfCharId, int date, int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 693);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddTameCarrierSucceed(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 694);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTameCarrierFail(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 695);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReleaseCarrier(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 696);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectQiuniuAudience(int selfCharId, int date, int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 697);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectQiuniu(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 698);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectYazi(int selfCharId, int date, int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 699);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChaofeng(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 700);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectPulao(int selfCharId, int date, int jiaoLoongId, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 701);
		AppendJiaoLoong(jiaoLoongId);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectSuanni(int selfCharId, int date, Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 702);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBaxia(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 703);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBian(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 704);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectFuxi(int selfCharId, int date, Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 705);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChiwen(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 706);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatLoong(int selfCharId, int date, short charTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 707);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByLoong(int selfCharId, int date, short charTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 708);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectYazi2(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 709);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromAge(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 710);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromPoorHealth(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 711);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKilledAfterXiangshuInfected(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 714);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAssassinated(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 715);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKilledByXiangshu(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 716);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPurchaseItem1(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 717);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSellItem1(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 718);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCleanBodyReincarnationSuccess(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 719);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 720);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddEvilBodyReincarnationSuccess(int selfCharId, int date, int charId, Location location, sbyte combatType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 721);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 722);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatType(combatType);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingForestSpiritBecomeEnemy(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 723);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 737);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSecretMakeEnemy(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 724);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformationTemplate(secretInfoTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 725);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSecretInformationTemplate(secretInfoTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCleanBodyDefeatAnimal(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 726);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEvilBodyDefeatAnimal(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 727);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCleanBodyDefeatHereticRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 728);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEvilBodyDefeatHereticRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 729);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCleanBodyDefeatRighteousRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 730);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEvilBodyDefeatRighteousRandomEnemy(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 731);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianParanoiaAdded(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 732);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianParanoiaAttack(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 733);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianParanoiaErased(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 734);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingRedEyeLoseItem(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 735);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugForestSpiritReduceFavorability(int selfCharId, int date, sbyte itemType, short itemTemplateId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 736);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingBlackBloodChangeDisorderOfQi(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 738);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugDevilInsideXiangshuInfection(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 739);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugCorpseWormChangeHealth(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 740);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingIceSilkwormLoseNeili(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 741);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingGoldenSilkwormEatGrownWug(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 742);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugAzureMarrowAddPoison(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 743);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugAzureMarrowAddWug(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 744);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 745);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianParanoiaErased2(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 746);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianDecreasedMood(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 747);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianDecreasedFavorability(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 748);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianQiDecline(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 749);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianPoisoning(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 750);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWuxianLoseItem(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 751);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugDevilInsideChangeHappiness(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 752);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugRedEyeChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 753);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugForestSpiritChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 754);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugBlackBloodChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 755);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugDevilInsideChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 756);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugCorpseWormChangeToGrown(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 757);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 758);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugIceSilkwormChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 759);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugGoldenSilkwormChangeToGrown(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 760);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWugAzureMarrowChangeToGrown(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 761);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 762);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddManageLearnLifeSkillSuccess(int selfCharId, int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 763);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddManageLearnCombatSkillSuccess(int selfCharId, int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 764);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddManageLearnLifeSkillFail(int selfCharId, int date, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 765);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddManageLearnCombatSkillFail(int selfCharId, int date, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 766);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddManageLifeSkillAbilityUp(int selfCharId, int date, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 767);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddManageCombatSkillAbilityUp(int selfCharId, int date, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 768);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddSmallVillagerXiangshuCompletelyInfected(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 769);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSmallVillagerSavedFromInfection(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 770);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 771);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddStorageResourceToTreasury(int selfCharId, int date, short settlementId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 772);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddStorageItemToTreasury(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 773);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTakeResourceFromTreasury(int selfCharId, int date, short settlementId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 774);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddTakeItemFromTreasury(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 775);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuStorageResourceToTreasury(int selfCharId, int date, short settlementId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 776);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuStorageItemToTreasury(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 777);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuTakeResourceFromTreasury(int selfCharId, int date, short settlementId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 778);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuTakeItemFromTreasury(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 779);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToGuardTreasury(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 780);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishGuardingTreasury(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 781);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryCancelSupportMakeEnemy(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 782);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryBeCancelSupportMakeEnemy(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 783);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryCancelSupport(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 784);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryBeCancelSupport(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 785);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryMakeEnemyOthers(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 786);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryBeMakeEnemyOthers(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 787);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryLostMorale(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 788);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryBeLostMorale(int selfCharId, int date, short settlementId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 789);
		AppendSettlement(settlementId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudeTreasuryBeLostMorale2(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 790);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryCancelSupportMakeEnemy(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 791);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryBeCancelSupportMakeEnemy(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 792);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryCancelSupport(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 793);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryBeCancelSupport(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 794);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryMakeEnemyOthers(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 795);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryBeMakeEnemyOthers(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 796);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryLostMorale(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 797);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryBeLostMorale(int selfCharId, int date, short settlementId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 798);
		AppendSettlement(settlementId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	public void AddPlunderTreasuryBeLostMorale2(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 799);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDonateTreasuryProvideSupport(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 800);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDonateTreasuryBeProvideSupport(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 801);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDonateTreasuryGetMorale(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 802);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDonateTreasuryBeGetMorale(int selfCharId, int date, short settlementId, float floatValue)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 803);
		AppendSettlement(settlementId);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
	}

	public void AddDonateTreasuryGetMorale2(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 804);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddTreasuryDistributeResource(int selfCharId, int date, short settlementId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 805);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTreasuryDistributeItem(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 806);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail12(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 807);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail22(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 808);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail32(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 809);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemyFail42(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 810);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemySucceed2(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 811);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 813);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonEnemySucceedAndEscaped2(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 812);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 813);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail12(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 814);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail22(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 815);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail32(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 816);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyFail42(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 817);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemySucceed2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 818);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 820);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemySucceedAndEscaped2(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 819);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 820);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManiaLow(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 821);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManiaHigh(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 822);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManiaAttack(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 823);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 824);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManiaCure(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 825);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 826);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessHuaJu(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 827);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessXuanZhi(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 828);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessYingJiao(int selfCharId, int date, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 829);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSecretMakeEnemy2(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 830);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 831);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToHuntFugitive(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 832);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishHuntFugitive(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 833);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToEscapePunishment(int selfCharId, int date, Location location, short punishmentType, short settlementId, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 834);
		AppendLocation(location);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishEscapePunishment(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 835);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToSeekAsylum(int selfCharId, int date, Location location, short punishmentType, short settlementId, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 836);
		AppendLocation(location);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	public void AddFinishSeekAsylum(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 837);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSeekAsylumSuccess(int selfCharId, int date, Location location, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 838);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddDecideToEscortPrisoner(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 839);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscortPrisonerSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 840);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedShaoLin(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 841);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedEmei1(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 842);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedEmei2(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 843);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedBaihua(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 844);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedWudang(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 845);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedYuanshan(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 846);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedShingXiang(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 847);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedRanShan(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 848);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXuanNv(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 849);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedZhuJian(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 850);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedKongSang(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 851);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedJinGang(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 852);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedWuXian(int selfCharId, int date, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 853);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedJieQing1(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 854);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedJieQing2(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 855);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedFuLong(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 856);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXueHou(int selfCharId, int date, short settlementId, sbyte bodyPartType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 857);
		AppendSettlement(settlementId);
		AppendBodyPartType(bodyPartType);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonCancelSupportMakeEnemyNpc(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 858);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonCancelSupportMakeEnemyTaiwu(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 859);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonCancelSupportNpc(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 860);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonCancelSupportTaiwu(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 861);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonMakeEnemyOthersNpc(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 862);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIntrudePrisonMakeEnemyOthersTaiwu(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 863);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestTheReleaseOfTheCriminalTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 865);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 864);
		AppendCharacter(selfCharId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 866);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 867);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXiangshuInfectedIncreaseFavorabilityNpc(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 868);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 869);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonedXiangshuInfectedTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 871);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 870);
		AppendCharacter(selfCharId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobbedFromPrisonNpc(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 872);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 873);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 874);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonCancelSupportNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 875);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonCancelSupportTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 876);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonMakeEnemyOthersNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 877);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 878);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArrestIntrudePrisonCancelSupportMakeEnemyNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 879);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 880);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 881);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 882);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 883);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 884);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestFailedCaptor(int selfCharId, int date, int charId, Location location, short settlementId, short relatedRecordId)
	{
		if (relatedRecordId != 886 && relatedRecordId != 1035)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 885);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresEngageInBattleTaiwu(int selfCharId, int date, int charId, int charId1, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 887);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSuccessfullyCaptor(int selfCharId, int date, int charId, Location location, short settlementId, short relatedRecordId)
	{
		if (relatedRecordId != 889 && relatedRecordId != 1036)
		{
			throw CreateRelatedRecordIdException(relatedRecordId);
		}
		int beginOffset = BeginAddingRecord(selfCharId, date, 888);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, relatedRecordId);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddReceiveCriminalsCaptor(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 890);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddReceiveCriminalsTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 891);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddReceiveCriminalsCriminal(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 892);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuyHandOverTheCriminalTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 894);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 893);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleHandOverTheCriminalTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 896);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 895);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleLoseHandOverTheCriminalTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 898);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 897);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddVictoryInCombatHandOverTheCriminalTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 900);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 899);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddFailureInCombatHandOverTheCriminalTaiwu(int selfCharId, int date, int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 902);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 901);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFightSucceed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 903);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFightFail(int selfCharId, int date, Location location, sbyte resourceType, int value, sbyte resourceType1, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 904);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendResource(resourceType1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongRobbery(int selfCharId, int date, Location location, sbyte resourceType, int value, sbyte resourceType1, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 905);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendResource(resourceType1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongRobberKilledByTaiwu(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 906);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongProtect(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 907);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishLevel1(int selfCharId, int date, short punishmentType, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 908);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishLevel2(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 909);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishLevel3(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 910);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishLevel4(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 911);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishLevel5(int selfCharId, int date, short punishmentType, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 912);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddHonestSectPunishTogetherWithSpouseLevel5(int selfCharId, int date, short punishmentType, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 913);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishLevel1(int selfCharId, int date, short punishmentType, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 914);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishLevel2(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 915);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishLevel3(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 916);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishLevel4(int selfCharId, int date, short punishmentType, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 917);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishLevel5(int selfCharId, int date, short punishmentType, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 918);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddArrestedSectPunishTogetherWithSpouseLevel5(int selfCharId, int date, short punishmentType, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 919);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeImplicatedSectPunishLevel5(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 920);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeReleasedUponCompletionOfASentence(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 921);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonBreak(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 922);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSendingToPrison1Taiwu(int selfCharId, int date, int charId, short settlementId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 923);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSendingToPrison2Taiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 924);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSendingToPrisonCriminal(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 925);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSentToPrisonTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 926);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 927);
		AppendCharacter(selfCharId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddCatchCriminalsWinTaiwu(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 928);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 929);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddCatchCriminalsFailedTaiwu(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 930);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 931);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuyHandOverTheCriminalTaiwuByExp(int selfCharId, int date, int charId, int charId1, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 933);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 932);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSendingToPrison1TaiwuByExp(int selfCharId, int date, int charId, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 934);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMigrateResources(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 935);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCookingIngredient(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 936);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMakingItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 937);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRepairItem0(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 938);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRepairItem1(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 939);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 960);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDisassembleItem0(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 940);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDisassembleItem1(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 941);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRefiningMedicine(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 942);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDetoxify0(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 943);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDetoxify1(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 944);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerEnvenomedItem(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 945);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerSoldItem(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 946);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerBuyItem(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 947);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerSeverEnemy(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 948);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerEmotionUp(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 949);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMakeFriends(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 950);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerGetMarried(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 951);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerBecomeBrothers(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 952);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerAdopt(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 953);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerTreatment0(int selfCharId, int date, int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 954);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 956);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerTreatment1(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 955);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 957);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuInfectedPrisonTaiwuVillage(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 958);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuInfectedPrisonSettlement(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 959);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerTakeItem(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 961);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerStorageItem(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 962);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerStorageResources(int selfCharId, int date, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 963);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerTakeResources(int selfCharId, int date, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 964);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiEntertainingUp(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 965);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiEntertainingDown(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 966);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBuildingRelationshipUp(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 967);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBuildingRelationshipDown(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 968);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceUp(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 969);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceDown(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 970);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombKeeperBuildingRelationshipUp(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 971);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombKeeperBuildingRelationshipDown(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 972);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombKeeperSpreadingInfluenceUp(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 973);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombKeeperSpreadingInfluenceDown(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 974);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddInquireSwordTomb(int selfCharId, int date, sbyte xiangshuAvatarId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 975);
		AppendSwordTomb(xiangshuAvatarId);
		EndAddingRecord(beginOffset);
	}

	public void AddGuardingSwordTomb(int selfCharId, int date, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 976);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerPrioritizedActions(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 977);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerPrioritizedActionsStop(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 978);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEnvenomedItemOverload(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 979);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		EndAddingRecord(beginOffset);
	}

	public void AddDetoxifyItemOverload(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3, sbyte itemType4, short itemTemplateId4)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 980);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		AppendItem(itemType4, itemTemplateId4);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerEnvenomedItemOverload(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 981);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDetoxifyItemOverload(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3, sbyte itemType4, short itemTemplateId4)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 982);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		AppendItem(itemType4, itemTemplateId4);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCookingIngredientFailed0(int selfCharId, int date, Location location, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 983);
		AppendLocation(location);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCookingIngredientFailed1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 984);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMakingItemFailed0(int selfCharId, int date, Location location, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 985);
		AppendLocation(location);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMakingItemFailed1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 986);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRepairFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 987);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDisassembleItemFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 988);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRefiningMedicineFailed0(int selfCharId, int date, Location location, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 989);
		AppendLocation(location);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerRefiningMedicineFailed1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 990);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerAddPoisonToItemFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 991);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDetoxItemFailed(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 992);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDistanceFailed0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 993);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDistanceFailed1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 994);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerDistanceFailed2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 995);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerAttainmentsFailed(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 996);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentTongyong(int selfCharId, int date, short settlementId, int value, Location location, int value1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 997);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendLocation(location);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentShaolin(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 998);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentEmei(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 999);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentBaihua(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1000);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentWudang(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1001);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentYuanshan(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1002);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentShingXiang(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1003);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentRanShan(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1004);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentXuanNv(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1005);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentZhuJian(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1006);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentKongSang(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1007);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentJinGang(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1008);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentWuXian(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1009);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentJieQing(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1010);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentFuLong(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1011);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuPunishmentXueHou(int selfCharId, int date, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1012);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishLevel5Expel(int selfCharId, int date, short punishmentType, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1013);
		AppendPunishmentType(punishmentType);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeImplicatedSectPunishLevel5New(int selfCharId, int date, int charId, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1014);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBeImplicatedSectPunishLevel5Expel(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1015);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1016);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1017);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1018);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1019);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1020);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1021);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddForgiveForCivilianSkill(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1022);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggarEatSomeoneFood(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1023);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1024);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAristocratReleasePrisoner(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1025);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrisonerBeReleaseByAristocrat(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1026);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddJieQingPunishmentAssassinSetOut(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1027);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJieQingPunishmentAssassinSucceed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1028);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1029);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJieQingPunishmentAssassinFailed(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1030);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1031);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJieQingPunishmentAssassinGiveUp(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1032);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddExociseXiangshuInfectionVictoryInCombatDie(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1033);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1034);
		AppendCharacter(selfCharId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleWinAndAvoidArrestTaiwu(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1038);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1037);
		AppendCharacter(selfCharId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillBattleLoseAndWasArrestedTaiwu(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1040);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1039);
		AppendCharacter(selfCharId);
		EndAddingRecord(beginOffset);
	}

	public void AddBribeSucceededInAvoidingArrestTaiwuByAuthority(int selfCharId, int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1042);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1041);
		AppendCharacter(selfCharId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBribeSucceededInAvoidingArrestTaiwuByExp(int selfCharId, int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1044);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1043);
		AppendCharacter(selfCharId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBribeSucceededInAvoidingArrestTaiwuByMoney(int selfCharId, int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1046);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1045);
		AppendCharacter(selfCharId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSubmitToCaptureMeeklyTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1047);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1048);
		AppendCharacter(selfCharId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalInformationChangeProfession(int selfCharId, int date, Location location, int charId, int professionTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1049);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendProfession(professionTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFeedTheAnimal(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1050);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionDoctorLifeTransition(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1051);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1052);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillKeyPointComprehensionByExp(int selfCharId, int date, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1053);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillKeyPointComprehensionByItems(int selfCharId, int date, short combatSkillTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1054);
		AppendCombatSkill(combatSkillTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillKeyPointComprehensionByLoveRelationship(int selfCharId, int date, short combatSkillTemplateId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1055);
		AppendCombatSkill(combatSkillTemplateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillKeyPointComprehensionByHatredRelationship(int selfCharId, int date, short combatSkillTemplateId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1056);
		AppendCombatSkill(combatSkillTemplateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSpiritualDebtKongsangPoisoned(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1057);
		EndAddingRecord(beginOffset);
	}

	public void AddMartialArtistSkill3NPCItemDropCaseA(int selfCharId, int date, Location location, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1058);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMartialArtistSkill3NPCItemDropCaseB(int selfCharId, int date, Location location, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1059);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishElopeSucceedJust(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1060);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishElopeSucceedKind(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1061);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishElopeSucceedEven(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1062);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectPunishElopeSucceed(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1063);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerGetRefineItem(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1064);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerUpgradeRefineItem(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1065);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerTreatmentTaiwu(int selfCharId, int date, int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1066);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerReduceXiangshuInfect(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1067);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerEarnMoney(int selfCharId, int date, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1068);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1069);
		AppendCharacter(selfCharId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerGetMerchantFavorability(int selfCharId, int date, int charId, Location location, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1072);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerGetMerchantFavorabilityTaiwu(int selfCharId, int date, int charId, Location location, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1073);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBeEntertainedUp(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1074);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBeEntertainedDown(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1075);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceCultureUp(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1076);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceCultureDown(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1077);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceSafetyUp(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1078);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiSpreadingInfluenceSafetyDown(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1079);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiConnectRelationshipUp(int selfCharId, int date, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1080);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiConnectRelationshipDown(int selfCharId, int date, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1081);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiConnectRelationshipUpTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1082);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiConnectRelationshipDownTaiwu(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1083);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBeConnectedRelationshipUp(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1084);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddLiteratiBeConnectedRelationshipDown(int selfCharId, int date, int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1085);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddGuardingSwordTombXiangshuInfectUp(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1086);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGuardingSwordTombSucceed(int selfCharId, int date, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1087);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerMakeEnemy(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1088);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerConfessLoveSucceed(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1089);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddOrderProduct(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1090);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1092);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReceiveProduct(int selfCharId, int date, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1091);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1093);
		AppendCharacter(selfCharId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCaptureOrder(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1094);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1095);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddCaptureOrderIntermediator(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1096);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddOrderProductForOthers(int selfCharId, int date, int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1097);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1098);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDeliveredOrderProduct(int selfCharId, int date, int charId, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1099);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1100);
		AppendCharacter(selfCharId);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAcquisitionDiscard(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1101);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingBaseDevelopLifeSkill(int selfCharId, int date, short buildingTemplateId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1102);
		AppendBuilding(buildingTemplateId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingBaseDevelopCombatSkill(int selfCharId, int date, short buildingTemplateId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1103);
		AppendBuilding(buildingTemplateId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingPersonalityDevelopLifeSkill(int selfCharId, int date, short buildingTemplateId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1104);
		AppendBuilding(buildingTemplateId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingPersonalityDevelopCombatSkill(int selfCharId, int date, short buildingTemplateId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1105);
		AppendBuilding(buildingTemplateId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingLeaderDevelopLifeSkill(int selfCharId, int date, int charId, short buildingTemplateId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1106);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingLeaderDevelopCombatSkill(int selfCharId, int date, int charId, short buildingTemplateId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1107);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingLearnLifeSkill(int selfCharId, int date, short buildingTemplateId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1108);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddShopBuildingLearnCombatSkill(int selfCharId, int date, short buildingTemplateId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1109);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinTaiwuVillageAfterTaiwuVillageStoneClaimed(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1110);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerFinishedReading(int selfCharId, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1111);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerSalaryReceived(int selfCharId, int date, short buildingTemplateId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1112);
		AppendBuilding(buildingTemplateId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddChangeGradeDrop(int selfCharId, int date, Location location, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1113);
		AppendLocation(location);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddFarmerCollectMaterial(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1114);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinOrganization(int selfCharId, int date, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1115);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddBreakAwayOrganization(int selfCharId, int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1116);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddChangeOrganization(int selfCharId, int date, short settlementId, short settlementId1, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1117);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerFavorabilityUp(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1118);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerFavorabilityDown(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1119);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerFavorabilityUpPerson(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1120);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerFavorabilityDownPerson(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1121);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpProtection(int selfCharId, int date, Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1122);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpRescue(int selfCharId, int date, Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1123);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpMourn(int selfCharId, int date, Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1124);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpVisitFriendOrFamily(int selfCharId, int date, Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1125);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpFindTreasure(int selfCharId, int date, Location location, int charId, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1126);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpFindSpecialMaterial(int selfCharId, int date, Location location, int charId, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1127);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpTakeRevenge(int selfCharId, int date, Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1128);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpContestForLegendaryBook(int selfCharId, int date, Location location, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1129);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpEscapeFromPrison(int selfCharId, int date, Location location, int charId, Location location1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1130);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeamUpSeekAsylum(int selfCharId, int date, short settlementId, int charId, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1131);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetInfected(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1132);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDieByInfected(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1133);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddInheritLegacy(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1134);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_1(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1135);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_2(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1136);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_3(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short feast)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1137);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(feast);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_4(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short feast)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1138);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(feast);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_5(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1139);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_6(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1140);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_7(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short feast)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1141);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(feast);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_8(int selfCharId, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short feast)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1142);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(feast);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_9(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1143);
		EndAddingRecord(beginOffset);
	}

	public void AddBanquet_10(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1144);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangInjured(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1145);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddExtendDarkAshTime(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1146);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoreInMarriage(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1147);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSameAreaDistantMarriage(int selfCharId, int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1148);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSameStateDistantMarriage(int selfCharId, int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1149);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDifferentStateDistantMarriage(int selfCharId, int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1150);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToOuterWorlds(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1151);
		EndAddingRecord(beginOffset);
	}

	public void AddBackFromOuterWorlds(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1152);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeili(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1153);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouTaiwuTransferFiveElements(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1154);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAlertnessUpBySecretInformation(int selfCharId, int date, short secretInfoTemplateId, int secretInfoId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1155);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAlertnessDownBySecretInformation(int selfCharId, int date, short secretInfoTemplateId, int secretInfoId, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1156);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddConsummateLevelIncreased(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1157);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillQualificationGrowthGuaranteed(int selfCharId, int date, Location location, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1158);
		AppendLocation(location);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillQualificationGrowthPersonality(int selfCharId, int date, Location location, sbyte personalityType, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1159);
		AppendLocation(location);
		AppendPersonalityType(personalityType);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddCombatSkillQualificationGrowthMentor(int selfCharId, int date, int charId, Location location, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1160);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillQualificationGrowthGuaranteed(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1161);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillQualificationGrowthPersonality(int selfCharId, int date, Location location, sbyte personalityType, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1162);
		AppendLocation(location);
		AppendPersonalityType(personalityType);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeSkillQualificationGrowthMentor(int selfCharId, int date, int charId, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1163);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionHelpCivilians(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1164);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionHelpCiviliansTarget(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1205);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionFightHeretics(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1165);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionFightHereticsTarget(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1206);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1166);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin0Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1207);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin1(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1167);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1168);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin2Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1208);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin3(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1169);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin4(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1170);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin4Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1375);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1171);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin5Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1376);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShaolin6(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1172);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1173);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei0Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1380);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei1(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1174);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei4(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1175);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei4Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1209);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei5(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1176);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei6(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1177);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionEmei6Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1210);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1178);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua0Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1211);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua1(int selfCharId, int date, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1179);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua2(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1180);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua3(int selfCharId, int date, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1181);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua3Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1212);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1183);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionBaihua5Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1213);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWudang5(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1188);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan1(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1191);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan1Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1218);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1192);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1193);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan3Target(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1219);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1194);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan5Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1220);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionYuanshan6(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1195);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1384);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang0(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1196);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1197);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1198);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1199);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang4(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1200);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1201);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang5Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1221);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang6(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1202);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang6Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1222);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1203);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang7Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1223);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang8(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1204);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionShixiang8Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1224);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan1(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1225);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan1Target(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1226);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1227);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan2Target(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1228);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1229);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan4(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1230);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan5(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1231);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan6(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId, int value1, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1232);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value1);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1233);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan7Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1234);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan8(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1235);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionRanShan8Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1236);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1237);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv1Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1238);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv2(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1239);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv2Target(int selfCharId, int date)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1388);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv3(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1240);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv3Audience(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1389);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv4(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1241);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv4Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1242);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1243);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv5Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1244);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv6(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1245);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXuanNv7(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1246);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1247);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian1Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1248);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian2(int selfCharId, int date, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1249);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian3(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1250);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian4(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1251);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian5(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1252);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionZhuJian8(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1377);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1256);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang1Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1257);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1258);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1259);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang4A(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1260);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang4B(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1261);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang5A(int selfCharId, int date, Location location, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1262);
		AppendLocation(location);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang5B(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1263);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang6(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1264);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang6Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1266);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang7Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1267);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang8A(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1268);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1390);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang8B(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1269);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang9A(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1270);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1391);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang9B(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1271);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang10(int selfCharId, int date, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1272);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionKongSang10Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1273);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong2Steal(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1277);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong2Rob(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1278);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong2Scam(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1279);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong3(int selfCharId, int date, Location location, short settlementId, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1280);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong4(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1281);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong4Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1282);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1283);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong5Target(int selfCharId, int date, int charId, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1284);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong6(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1285);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong6Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1286);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJingGangZong7(int selfCharId, int date, Location location, short settlementId, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1287);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian1(int selfCharId, int date, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1288);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1289);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian2Target(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1290);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1291);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian3Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1292);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian4(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1293);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian4Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1378);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian5(int selfCharId, int date, Location location, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1294);
		AppendLocation(location);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionWuXian6(int selfCharId, int date, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1295);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing1A(int selfCharId, int date, Location location, short secretInfoTemplateId, int secretInfoId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1296);
		AppendLocation(location);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing1B(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1297);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing2(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1298);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1392);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing3(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1299);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing4(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1300);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing5(int selfCharId, int date, int charId, int charId1, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1301);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing6A(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1302);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing6B(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1303);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1304);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing7Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1381);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionJieQing8(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1305);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionFuLong2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1308);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionFuLong6(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1314);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou2StealA(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1317);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou2StealB(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1318);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou3RobA(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1319);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou3RobB(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1320);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou4ScamA(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1321);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou4ScamB(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1322);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou5(int selfCharId, int date, int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1323);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou6(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1324);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1325);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionXveHou7Target(int selfCharId, int date, int charId, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1326);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1330);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen1TargetA(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1331);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen1TargetB(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1332);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1333);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen2TargetA(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1334);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen2TargetB(int selfCharId, int date, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1335);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen3(int selfCharId, int date, Location location, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1336);
		AppendLocation(location);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen4(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1337);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen5(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1338);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen6(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1339);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen6Target(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1340);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen7(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1341);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen7Target(int selfCharId, int date, int charId, Location location, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1342);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen8(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1343);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen8Target(int selfCharId, int date, int charId, Location location, short settlementId, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1344);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen9(int selfCharId, int date, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1345);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen9Target(int selfCharId, int date, int charId, Location location, short settlementId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1346);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen10(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1347);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen10TargetA(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1348);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen10TargetB(int selfCharId, int date, int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1349);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen11(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1350);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen12(int selfCharId, int date, Location location, sbyte merchantType, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1351);
		AppendLocation(location);
		AppendMerchantType(merchantType);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen13(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1352);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen13Target(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1353);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen14(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1354);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen15(int selfCharId, int date, Location location, int value, sbyte resourceType, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1355);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen16(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1356);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen16Target(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1357);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen17(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1358);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen18(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1359);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen19(int selfCharId, int date, Location location, int value, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1360);
		AppendLocation(location);
		AppendInteger(value);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen20(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1361);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen21(int selfCharId, int date, int charId, Location location, short secretInfoTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1362);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendSecretInformationTemplate(secretInfoTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionChengZhen22(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1363);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction1(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1364);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1402);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction2(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1365);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1403);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction3(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1366);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction4(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1367);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction5(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1368);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction6(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1369);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCherryPickResource(int selfCharId, int date, Location location, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1370);
		AppendLocation(location);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddBuddistMeditate(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1371);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTaoistMeditate(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1372);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionCaptureCricket1(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1373);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBaxia02(int selfCharId, int date, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1374);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiBadOther(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1386);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQiGoodOther(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1387);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectAdored(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1393);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectEnemy(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1394);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectSuxia(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1395);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectBecomeMoTian(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1396);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectBeAttackByMoTian(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1397);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectBeAttackByJiao(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1398);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectBeAttackByMirror(int selfCharId, int date, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1399);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTwelveImmortalsEffectBeAttackBySkeletonDemon(int selfCharId, int date, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1400);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDemonHeirRevenge(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1404);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatDemonHeir(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1405);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1406);
		AppendCharacter(selfCharId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDemonHeirDefeatTaiwu(int selfCharId, int date, int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1407);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDemonHeirRebirth1(int selfCharId, int date, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1408);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDemonHeirRebirth2(int selfCharId, int date, Location location)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1409);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCCricketTurnToCricketForm(int selfCharId, int date, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1410);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCCricketRetranmogrifyToHuman(int selfCharId, int date, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1411);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddDeathRecord(GameData.Domains.Character.Character character, CharacterDeathTypeItem deathType, ref CharacterDeathInfo deathInfo)
	{
		if (deathType.DefaultLifeRecord >= 0)
		{
			int selfCharId = character.GetId();
			int targetCharId = deathInfo.KillerId;
			LifeRecordItem srcLifeRecordCfg = Config.LifeRecord.Instance[deathType.DefaultLifeRecord];
			int beginOffset = BeginAddingRecord(selfCharId, deathInfo.DeathDate, deathType.DefaultLifeRecord);
			FillParameters(srcLifeRecordCfg, targetCharId, ref deathInfo);
			EndAddingRecord(beginOffset);
			List<short> relatedIds = srcLifeRecordCfg.RelatedIds;
			if (relatedIds != null && relatedIds.Count > 0 && targetCharId >= 0)
			{
				short relatedId = srcLifeRecordCfg.RelatedIds[0];
				int beginOffset2 = BeginAddingRecord(targetCharId, deathInfo.DeathDate, relatedId);
				FillParameters(srcLifeRecordCfg, selfCharId, ref deathInfo);
				EndAddingRecord(beginOffset2);
			}
		}
		void FillParameters(LifeRecordItem recordCfg, int relatedCharId, ref CharacterDeathInfo reference)
		{
			if (!recordCfg.IsSourceRecord)
			{
				recordCfg = Config.LifeRecord.Instance[recordCfg.RelatedIds[0]];
			}
			for (int i = 0; i < recordCfg.Parameters.Length; i++)
			{
				string paramTypeStr = recordCfg.Parameters[i];
				if (string.IsNullOrEmpty(paramTypeStr))
				{
					break;
				}
				switch (ParameterType.Parse(paramTypeStr))
				{
				case 0:
					AppendCharacter(relatedCharId);
					break;
				case 10:
					AppendAdventure(reference.AdventureId);
					break;
				case 1:
					AppendLocation(reference.Location);
					break;
				default:
					throw new Exception("Unrecognized parameter type for death record " + recordCfg.Name);
				}
			}
		}
	}

	public void AddBecomeEnemyRecord(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, BecomeEnemyTypeItem becomeEnemyType, ref CharacterBecomeEnemyInfo becomeEnemyInfo)
	{
		if (becomeEnemyType.DefaultLifeRecord >= 0)
		{
			int selfCharId = selfChar.GetId();
			int targetCharId = targetChar.GetId();
			LifeRecordItem srcLifeRecordCfg = Config.LifeRecord.Instance[becomeEnemyType.DefaultLifeRecord];
			int beginOffset = BeginAddingRecord(selfCharId, becomeEnemyInfo.Date, becomeEnemyType.DefaultLifeRecord);
			FillParameters(srcLifeRecordCfg, targetCharId, ref becomeEnemyInfo);
			EndAddingRecord(beginOffset);
			List<short> relatedIds = srcLifeRecordCfg.RelatedIds;
			if (relatedIds != null && relatedIds.Count > 0)
			{
				short relatedId = srcLifeRecordCfg.RelatedIds[0];
				int beginOffset2 = BeginAddingRecord(targetCharId, becomeEnemyInfo.Date, relatedId);
				FillParameters(srcLifeRecordCfg, selfCharId, ref becomeEnemyInfo);
				EndAddingRecord(beginOffset2);
			}
		}
		void FillParameters(LifeRecordItem recordCfg, int relatedCharId, ref CharacterBecomeEnemyInfo reference)
		{
			if (!recordCfg.IsSourceRecord)
			{
				recordCfg = Config.LifeRecord.Instance[recordCfg.RelatedIds[0]];
			}
			for (int i = 0; i < recordCfg.Parameters.Length; i++)
			{
				string paramTypeStr = recordCfg.Parameters[i];
				if (string.IsNullOrEmpty(paramTypeStr))
				{
					break;
				}
				switch (ParameterType.Parse(paramTypeStr))
				{
				case 0:
					AppendCharacter(relatedCharId);
					break;
				case 2:
					AppendItem(8, reference.WugTemplateId);
					break;
				case 1:
					AppendLocation(reference.Location);
					break;
				case 30:
					AppendSecretInformationTemplate(reference.SecretInformationTemplateId);
					break;
				default:
					throw new Exception("Unrecognized parameter type for death record " + recordCfg.Name);
				}
			}
		}
	}

	public void AddSectPunishmentRecord(PunishmentTypeItem punishmentTypeCfg, PunishmentSeverityItem severityCfg, short settlementId, bool isArrested, GameData.Domains.Character.Character selfChar, int implicatedCharId)
	{
		int selfCharId = selfChar.GetId();
		int date = DomainManager.World.GetCurrDate();
		if (punishmentTypeCfg.TemplateId == 21)
		{
			AddBeImplicatedSectPunishLevel5New(selfCharId, date, implicatedCharId, settlementId, severityCfg.PrisonTime);
			return;
		}
		short recordId = (isArrested ? severityCfg.ArrestedRecord : severityCfg.NormalRecord);
		int beginOffset = BeginAddingRecord(selfCharId, date, recordId);
		AppendPunishmentType(punishmentTypeCfg.TemplateId);
		AppendSettlement(settlementId);
		if (severityCfg.PrisonTime >= 0)
		{
			AppendInteger(severityCfg.PrisonTime);
		}
		if (implicatedCharId >= 0)
		{
			AppendCharacter(implicatedCharId);
		}
		EndAddingRecord(beginOffset);
	}

	public void AddMixedPoisonEffectRecord(GameData.Domains.Character.Character character, MixPoisonEffectItem mixPoisonEffectCfg)
	{
		if (mixPoisonEffectCfg.LifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int selfCharId = character.GetId();
			Location location = character.GetValidLocation();
			LifeRecordItem lifeRecordCfg = Config.LifeRecord.Instance[mixPoisonEffectCfg.LifeRecord];
			Tester.Assert(lifeRecordCfg.Parameters[0] == "Location");
			Tester.Assert(string.IsNullOrEmpty(lifeRecordCfg.Parameters[1]));
			int beginOffset = BeginAddingRecord(selfCharId, date, mixPoisonEffectCfg.LifeRecord);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddCaptureOrderCorrectly(int selfCharId, int date, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(selfCharId, date, 1094);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId1, date, 1095);
		AppendCharacter(charId);
		AppendCharacter(selfCharId);
		EndAddingRecord(beginOffset);
		beginOffset = BeginAddingRecord(charId, date, 1096);
		AppendCharacter(charId1);
		AppendCharacter(selfCharId);
		EndAddingRecord(beginOffset);
	}

	public int AddFeastRecord(GameData.Domains.Character.Character selfChar, ItemKey dish, ItemKey gift, short feastType, bool loveItem)
	{
		int selfCharId = selfChar.GetId();
		int date = DomainManager.World.GetCurrDate();
		short defKey = (short)((selfChar.GetHappiness() <= GlobalConfig.Instance.FeastLowHappiness) ? ((feastType != 0) ? ((!loveItem) ? 1137 : 1138) : ((!loveItem) ? 1135 : 1136)) : ((feastType != 0) ? ((!loveItem) ? 1141 : 1142) : ((!loveItem) ? 1139 : 1140)));
		int beginOffset = BeginAddingRecord(selfCharId, date, defKey);
		AppendItem(dish.ItemType, dish.TemplateId);
		AppendItem(gift.ItemType, gift.TemplateId);
		if (feastType != 0)
		{
			AppendFeast(feastType);
		}
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public void AddIdentityActionCommonSelf(int selfCharId, Location location, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionCommonSelf(int selfCharId, int targetCharId, Location location, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			Tester.Assert(Config.LifeRecord.Instance[actionTemplate.ExecuteSelfLifeRecord].Parameters[0] == "Character");
			AppendCharacter(targetCharId);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionCommonTarget(int targetCharId, int selfCharId, Location location, PlanningActionItem actionTemplate)
	{
		int date = DomainManager.World.GetCurrDate();
		if (actionTemplate.ExecuteTargetLifeRecord >= 0)
		{
			int beginOffset = BeginAddingRecord(targetCharId, date, actionTemplate.ExecuteTargetLifeRecord);
			LifeRecordItem template = Config.LifeRecord.Instance[actionTemplate.ExecuteTargetLifeRecord];
			string[] parameters = (template.IsSourceRecord ? template.Parameters : Config.LifeRecord.Instance[template.RelatedIds[0]].Parameters);
			Tester.Assert(parameters[0] == "Character" && parameters[1] == "Location");
			AppendCharacter(selfCharId);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionAwakeningLifeSkill(int selfCharId, Location location, sbyte lifeSkillType, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			AppendLocation(location);
			AppendLifeSkillType(lifeSkillType);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionBreakOutSectSkill(int selfCharId, Location location, short combatSkillTemplateId, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			AppendLocation(location);
			AppendCombatSkill(combatSkillTemplateId);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionHelpSectMembersBreakSkillsTarget(int targetCharId, int selfCharId, Location location, short combatSkillTemplateId, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteTargetLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(targetCharId, date, actionTemplate.ExecuteTargetLifeRecord);
			AppendCharacter(selfCharId);
			AppendLocation(location);
			AppendCombatSkill(combatSkillTemplateId);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionLearnSkill(int selfCharId, Location location, int pageCount, sbyte itemType, short itemTemplateId, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			AppendLocation(location);
			AppendInteger(pageCount);
			AppendItem(itemType, itemTemplateId);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionHelpLearnSkillTarget(int targetCharId, int selfCharId, Location location, int pageCount, sbyte itemType, short itemTemplateId, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteTargetLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(targetCharId, date, actionTemplate.ExecuteTargetLifeRecord);
			AppendCharacter(selfCharId);
			AppendLocation(location);
			AppendInteger(pageCount);
			AppendItem(itemType, itemTemplateId);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionHealDoctor(int selfCharId, Location location, int costAmount, sbyte resourceType, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteSelfLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(selfCharId, date, actionTemplate.ExecuteSelfLifeRecord);
			AppendLocation(location);
			AppendInteger(costAmount);
			AppendResource(resourceType);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddIdentityActionHealPatient(int targetCharId, Location location, int selfCharId, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.ExecuteTargetLifeRecord >= 0)
		{
			int date = DomainManager.World.GetCurrDate();
			int beginOffset = BeginAddingRecord(targetCharId, date, actionTemplate.ExecuteTargetLifeRecord);
			AppendCharacter(selfCharId);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}
}
