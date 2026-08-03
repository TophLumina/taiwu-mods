using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Information.Collection;

[SerializableGameData(NotForDisplayModule = true)]
public class SecretInformationCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<SecretInformationRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SecretInformationRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			renderInfos.Add(renderInfo);
		}
	}

	public new unsafe SecretInformationRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int date = *(int*)(pCurrData + 1);
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			InstantNotificationItem config = InstantNotification.Instance[recordType];
			string[] parameters = config.Parameters;
			SecretInformationRenderInfo info = new SecretInformationRenderInfo(recordType, config.Desc, date);
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

	public int CopyRecord(int recordOffset)
	{
		int recordSize = GetRecordSize(recordOffset);
		int offset = Size;
		int newSize = Size + recordSize;
		EnsureCapacity(newSize);
		for (int i = 0; i < recordSize; i++)
		{
			RawData[offset + i] = RawData[recordOffset + i];
		}
		return offset;
	}

	private new unsafe int BeginAddingRecord(short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		int date = DomainManager.World.GetCurrDate();
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			*(int*)(pCurrData + 1) = date;
			((short*)(pCurrData + 1))[2] = recordType;
		}
		return offset;
	}

	protected new unsafe void EndAddingRecord(int beginOffset)
	{
		Size = (Size + 4 - 1) & -4;
		int size = Size - beginOffset;
		if (size > 255)
		{
			throw new Exception("Record exceeded the max size");
		}
		fixed (byte* pRawData = RawData)
		{
			pRawData[beginOffset] = (byte)size;
		}
		int count = base.Count + 1;
		base.Count = count;
	}

	public int AddDie(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKillInPublic(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKidnapInPublic(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKillForPunishment(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKidnapForPunishment(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedResourceGain(int charId, sbyte resourceType, Location location)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedItemGain(int charId, ulong itemKey, Location location)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedSkillBookGain(int charId, ulong itemKey, Location location)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedCure(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedResourceLose(int charId, sbyte resourceType, Location location)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedItemLose(int charId, ulong itemKey, Location location)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedSkillBookLose(int charId, ulong itemKey, Location location)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddUnexpectedHarm(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLifeSkillBattleWin(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCricketBattleWin(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMajorVictoryInCombat(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMinorVictoryInCombat(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMourn(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOfferProtection(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseFetus(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseFetus2(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveBirthToChild(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveBirthToChild2(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAbandonChild(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddReleaseKidnappedCharacter(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRescueKidnappedCharacter(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKidnappedCharacterEscaped(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddReadBookFail(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBreakoutFail(int charId, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseOverloadingItem(int charId, ulong itemKey, Location location)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSeverEnemy(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeEnemy(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSeverFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeLover(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBreakupWithLover(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeHusbandAndWife(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeSwornBrothersAndSisters(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSeverSwornBrothersAndSisters(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGetAdopted(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAdoptChild(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGivingResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBuildGrave(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCure(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRepairItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddInstructOnLifeSkill(int charId, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddInstructOnCombatSkill(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestHealInjury(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestDetoxPoison(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestIncreaseHealth(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestRestoreDisorderOfQi(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestIncreaseNeili(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestKillWug(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestFood(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestTeaWine(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestDrinking(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestGivingMoney(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestInstructionOnReading(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestInstructionOnBreakout(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestRepairItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestAddPoisonToItem(int charId, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestInstructionOnLifeSkill(int charId, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAcceptRequestInstructionOnCombatSkill(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRehaircutSuccess(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRehaircutIncompleted(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRehaircutFail(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestHealInjury(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestDetoxPoison(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestIncreaseHealth(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestRestoreDisorderOfQi(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestIncreaseNeili(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestKillWug(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestFood(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestTeaWine(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestDrinking(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestGivingMoney(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestInstructionOnReading(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestInstructionOnBreakout(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestRepairItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestAddPoisonToItem(int charId, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestInstructionOnLifeSkill(int charId, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRefuseRequestInstructionOnCombatSkill(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobGraveResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobResource(int charId, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobGraveItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobItem(int charId, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKillInPrivate(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddKidnapInPrivate(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPoisonEnemy(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPlotHarmEnemy(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealLifeSkill(int charId, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamLifeSkill(int charId, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealCombatSkill(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamCombatSkill(int charId, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAddPoisonToItem(int charId, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMonkBreakRule(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMakeLoveIllegal(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRape(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseFetusFatherUnknown(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveBirthToChildFatherUnknown(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDatingWithCrush(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddForcingSilence(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRetrieveChild(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSolveScripture1(int charId)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSolveScripture2(int charId)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSolveScripture3(int charId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSolveScripture4(int charId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPrisonBreak(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPregnant(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPregnantWithoutFather(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiangshuType0(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiangshuType1(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeMonk(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDivorce(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeMaster(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBecomeApprentice(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJoinOrganization(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGainQiBook(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLostQiBook(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBegMoney(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddImprisoned(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddReleasedPrison(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBegPrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealPrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamPrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobPrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSeverGetAdopted(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSeverAdoptChild(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
