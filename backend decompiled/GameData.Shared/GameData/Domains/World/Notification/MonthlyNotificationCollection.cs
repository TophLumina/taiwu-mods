using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.World.Notification;

public class MonthlyNotificationCollection : WriteableRecordCollection
{
	public MonthlyNotificationCollection()
	{
	}

	public MonthlyNotificationCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	public new void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection, EMonthlyNotificationSectionType sectionType)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null && MonthlyNotification.Instance[renderInfo.RecordType].SectionType == sectionType)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public new unsafe RenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			MonthlyNotificationItem config = MonthlyNotification.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			RenderInfo info = new RenderInfo(recordType, config.Desc);
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
		int newSize = Size + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset + 1) = recordType;
		}
		return offset;
	}

	public unsafe byte* PrepareCopy(int size)
	{
		int offset = Size;
		int newSize = Size + size;
		EnsureCapacity(newSize);
		Size = newSize;
		int count = base.Count + 1;
		base.Count = count;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)size;
			return pRawData + offset;
		}
	}

	public void AddMonthlyNotificationWithNoArgument(short templateId)
	{
		Tester.Assert(MonthlyNotification.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	public void TryShrink(int maxSize)
	{
		if (GetSerializedSize() > maxSize)
		{
			int trimmedSize = TrimExcess();
			if (GetSerializedSize() <= maxSize)
			{
				AdaptableLog.TagInfo("MonthlyNotificationCollection", $"TrimExcess by {trimmedSize}");
				return;
			}
		}
		Dictionary<short, List<int>> recordCounts = new Dictionary<short, List<int>>();
		ushort metaSize = GetSerializedFixedSizeOfMetadata();
		while (GetSize() + metaSize > maxSize)
		{
			int index = -1;
			int offset = -1;
			while (Next(ref index, ref offset))
			{
				short recordType = GetRecordType(offset);
				if (recordCounts.TryGetValue(recordType, out var list))
				{
					list.Add(offset);
					continue;
				}
				recordCounts[recordType] = new List<int> { offset };
			}
			KeyValuePair<short, List<int>> maxCountPair = recordCounts.Aggregate((KeyValuePair<short, List<int>> a, KeyValuePair<short, List<int>> b) => (a.Value.Count <= b.Value.Count) ? b : a);
			short toRemoveRecordType = maxCountPair.Key;
			List<int> toRemoveList = maxCountPair.Value;
			int removedCount = 0;
			for (int i = toRemoveList.Count - 1; i >= 0; i--)
			{
				int toRemoveOffset = toRemoveList[i];
				int size = GetRecordSize(toRemoveOffset);
				Remove(toRemoveOffset, size);
				removedCount++;
				if (GetSize() + metaSize <= maxSize)
				{
					break;
				}
			}
			recordCounts.Clear();
			AdaptableLog.TagInfo("MonthlyNotificationCollection", $"Removed {removedCount} instances of {MonthlyNotification.Instance[toRemoveRecordType].Name}({toRemoveRecordType}) because of exceeding size.");
		}
		int trimmedSize2 = TrimExcess();
		AdaptableLog.TagInfo("MonthlyNotificationCollection", $"TrimExcess by {trimmedSize2}");
	}

	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(short*)(pRawData + offset + 1);
		}
	}

	public void AddSolarTerm0()
	{
		int beginOffset = BeginAddingRecord(0);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm1()
	{
		int beginOffset = BeginAddingRecord(1);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm2()
	{
		int beginOffset = BeginAddingRecord(2);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm3()
	{
		int beginOffset = BeginAddingRecord(3);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm4()
	{
		int beginOffset = BeginAddingRecord(4);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm5()
	{
		int beginOffset = BeginAddingRecord(5);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm6()
	{
		int beginOffset = BeginAddingRecord(6);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm7()
	{
		int beginOffset = BeginAddingRecord(7);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm8()
	{
		int beginOffset = BeginAddingRecord(8);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm9()
	{
		int beginOffset = BeginAddingRecord(9);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm10()
	{
		int beginOffset = BeginAddingRecord(10);
		EndAddingRecord(beginOffset);
	}

	public void AddSolarTerm11()
	{
		int beginOffset = BeginAddingRecord(11);
		EndAddingRecord(beginOffset);
	}

	public void AddGraveDestroyed(int charId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNest(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseItemCausedByWarehouseFull(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAssassinated(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAssassinatedDueToKillerToken(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDie(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddInfectXiangshuPartially(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddInfectXiangshuCompletely(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCreateHatredByPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketEndLife(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseResourceCausedByInventoryFull(int charId, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseItemCausedByInventoryFull(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCreateHatred(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDecreaseHatred(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddConfessLoveAndSucceed(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverLove(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMarriage(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeFriend(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDecreaseFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeSwornBrotherOrSister(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptBoy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptGirl(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRecognizeFather(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRecognizeMother(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeLove(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRapeFailure(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherGiveBirthToBoy(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherGiveBirthToGirl(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFatherGetBoy(int charId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFatherGetGirl(int charId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToCricket(int charId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherLoseFetus(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToJoinOrganization(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoinOrganization(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToAppointment(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWaitingForAppointment(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAppointmentExpired(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAppointmentCancelled(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToRescue(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddRescuePrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddReleasePrisoner(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDisappear(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToRevenge(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGoToProtect(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddProtectRelativeOrFriend(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddSectUpgrade(int charId, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddCivilianSettlementUpgrade(int charId, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	public void AddFactionUpgrade(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceSuccess(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddCheatResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddDigResource(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemSuccess(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCheatItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDigItem(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillSuccess(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCheatLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillSuccess(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddCheatCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGivePresentResource(int charId, Location location, sbyte resourceType, int charId1)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGivePresentItem(int charId, Location location, sbyte itemType, short itemTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachLifeSkillSuccess(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachCombatSkillSuccess(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAmuseOthersByMusic(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAmuseOthersByChess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAmuseOthersByPoem(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAmuseOthersByPainting(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeFamousItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddEnlightenedByDaoism(int charId, Location location, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddEnlightenedByBuddhism(int charId, Location location, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	public void AddPractiseDivination(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyGetRareItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyGetResource(int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyGetCombatSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyGetLifeSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyGetHealth(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyHealOuterInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyHealInnerInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyHealPoison(int charId, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyHealQi(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyLoseRareItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyLoseResource(int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyLoseCombatSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyLoseLifeSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlyLoseHealth(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlySufferOuterInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlySufferInneInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlySufferPoison(int charId, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddUnexpectedlySufferDisorderOfQi(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingResourceIncreased(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingResourceSpread(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingDamaged(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingRuined(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingConstructionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingUpgradingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingDemolitionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingIncome(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDispatchInPlace(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindViciousBeggarsNest(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindThievesCamp(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindBanditsStronghold(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindTraitorsGang(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindVillainsValley(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindMixiangzhen(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindMassGrave(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindHereticHome(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnappedByHeresy(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnappedByHeart(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnappedBySoumoulou(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddKidnappedByWorldWeary(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddTownCombatAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketsAppeared()
	{
		int beginOffset = BeginAddingRecord(133);
		EndAddingRecord(beginOffset);
	}

	public void AddStartCricketContest(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeCompetitionAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddStartSectJuniorContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddStartSectIntermediateContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddStartSectSeniorContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddJoustForSpouse(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddMarryNotice(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuAvatarAppeared(sbyte xiangshuAvatarId)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendSwordTomb(xiangshuAvatarId);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiuhanvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangervBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddYiYihouvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQivBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXuefengBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddShuFangvBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMonvSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDayueYaochangSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJiuhanvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddJinHuangervSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddYiYihouvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWeiQivSaveSuffering(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddYixiangvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXuefengSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddShuFangvSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCivilianDisappear(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMerchantGoTravelling(short settlementId, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendSettlement(settlementId);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddChickenEscaped(short chickenId)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendChicken(chickenId);
		EndAddingRecord(beginOffset);
	}

	public void AddNaturalDisasterOccurred(Location location, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendLocation(location);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddReincarnation(int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddAccumulatedSkillPowerLost(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillageDestructed(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRebirthAsJuniorXiangshu()
	{
		int beginOffset = BeginAddingRecord(167);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookAppeared(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(168);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceWithoutParticipant()
	{
		int beginOffset = BeginAddingRecord(169);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceInPreparing()
	{
		int beginOffset = BeginAddingRecord(170);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceInProgress(Location location)
	{
		int beginOffset = BeginAddingRecord(171);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuKilling(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(172);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMonthlyNormalInformation()
	{
		int beginOffset = BeginAddingRecord(173);
		EndAddingRecord(beginOffset);
	}

	public void AddMonthlySecretInformation()
	{
		int beginOffset = BeginAddingRecord(174);
		EndAddingRecord(beginOffset);
	}

	public void AddSecretInformationWillExpire()
	{
		int beginOffset = BeginAddingRecord(175);
		EndAddingRecord(beginOffset);
	}

	public void AddSecretInformationExpired()
	{
		int beginOffset = BeginAddingRecord(176);
		EndAddingRecord(beginOffset);
	}

	public void AddYirenAppearInTaiwuArea(int charId)
	{
		int beginOffset = BeginAddingRecord(177);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchantBackAfterLong()
	{
		int beginOffset = BeginAddingRecord(178);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchantLoseContact()
	{
		int beginOffset = BeginAddingRecord(179);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchantBackSucceed()
	{
		int beginOffset = BeginAddingRecord(180);
		EndAddingRecord(beginOffset);
	}

	public void AddGainAuthority(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(181);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFemaleJoustForSpouseReady(Location location)
	{
		int beginOffset = BeginAddingRecord(182);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddStartSectNormalCompetition(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(183);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeWithForeverLover(Location location)
	{
		int beginOffset = BeginAddingRecord(184);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDisasterAndPreciousMaterial(Location location)
	{
		int beginOffset = BeginAddingRecord(185);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddHeroesDefendMorality(Location location)
	{
		int beginOffset = BeginAddingRecord(186);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestViciousBeggars(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(187);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestThievesCamp(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(188);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestBanditsStronghold(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(189);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestVillainsValley(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(190);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestRighteousLow(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(191);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddIncomeFromNestRighteousMiddle(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(192);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingWorkerDie(int charId, Location location, short buildingTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(193);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendBuilding(buildingTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddStoneHouseInfectedKidnapped(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(194);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanLost()
	{
		int beginOffset = BeginAddingRecord(195);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindMirage()
	{
		int beginOffset = BeginAddingRecord(196);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindBigfoot()
	{
		int beginOffset = BeginAddingRecord(197);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindPlant()
	{
		int beginOffset = BeginAddingRecord(198);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindAnimal()
	{
		int beginOffset = BeginAddingRecord(199);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanGetInformation()
	{
		int beginOffset = BeginAddingRecord(200);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindSettlement()
	{
		int beginOffset = BeginAddingRecord(201);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindWeather()
	{
		int beginOffset = BeginAddingRecord(202);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindWreckage()
	{
		int beginOffset = BeginAddingRecord(203);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanHelpPasserby()
	{
		int beginOffset = BeginAddingRecord(204);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanGetHelp()
	{
		int beginOffset = BeginAddingRecord(205);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindVenison()
	{
		int beginOffset = BeginAddingRecord(206);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindFruit()
	{
		int beginOffset = BeginAddingRecord(207);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanFindVillage()
	{
		int beginOffset = BeginAddingRecord(208);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanMeetMerchan()
	{
		int beginOffset = BeginAddingRecord(209);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanMeetTheif()
	{
		int beginOffset = BeginAddingRecord(210);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanGoodsDamage()
	{
		int beginOffset = BeginAddingRecord(211);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanUnacclimatized()
	{
		int beginOffset = BeginAddingRecord(212);
		EndAddingRecord(beginOffset);
	}

	public void AddWesternMerchanLackReplenishment()
	{
		int beginOffset = BeginAddingRecord(213);
		EndAddingRecord(beginOffset);
	}

	public void AddAboutToDie(int charId)
	{
		int beginOffset = BeginAddingRecord(214);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyNestDemise(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(215);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddSecretInformationBroadcast()
	{
		int beginOffset = BeginAddingRecord(216);
		EndAddingRecord(beginOffset);
	}

	public void AddReadingEvent(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyNestGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(218);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRandomEnemyGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(219);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRandomEnemyDecay(Location location)
	{
		int beginOffset = BeginAddingRecord(220);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuGetStrengthened()
	{
		int beginOffset = BeginAddingRecord(221);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookShocked(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookInsane(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(223);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookConsumed(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(224);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookLost(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(225);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForNewLegendaryBook(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(226);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookAbandoned(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookOwnerDie(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(228);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookOwnerConsumed(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(229);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookAppear(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(230);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddChallengeForLegendaryBook(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(231);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRobLegendaryBook(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(232);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerLeftForLegendaryBook(int charId)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHappyBirthday(sbyte month, int charId)
	{
		int beginOffset = BeginAddingRecord(234);
		AppendMonth(month);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonMakeLoss(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(235);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRottenPoisonDiffuse(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(236);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDestroyFace(int charId)
	{
		int beginOffset = BeginAddingRecord(237);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddIllusoryPoisonDiffuse(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(238);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindAttckSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindEmpoisonSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(240);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindSneakAttckSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindRapeSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindAttckFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindEmpoisonFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(244);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindSneakAttckFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(245);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPoisonDisturbMindRapeFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(246);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiKillsPeople(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(247);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanAbsorbInfectedPeople(int charId)
	{
		int beginOffset = BeginAddingRecord(248);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangAdventure()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiGone()
	{
		int beginOffset = BeginAddingRecord(250);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceWinner(short settlementId)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiInfighting(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(252);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWhiteGibbonReturns()
	{
		int beginOffset = BeginAddingRecord(253);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiGoneAgain()
	{
		int beginOffset = BeginAddingRecord(254);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiRescue(int charId)
	{
		int beginOffset = BeginAddingRecord(255);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiGoneFinal(int charId)
	{
		int beginOffset = BeginAddingRecord(256);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryKongsangTripodVesselCures(Location location)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryKongsangTripodVesselDetoxifies(Location location)
	{
		int beginOffset = BeginAddingRecord(258);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryKongsangTripodVesselRemovesQiDisorder(Location location)
	{
		int beginOffset = BeginAddingRecord(259);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryKongsangTripodVesselRestoresHealth(Location location)
	{
		int beginOffset = BeginAddingRecord(260);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddReincarnationNewWithLocation(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(261);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangVillagersInjured(int value)
	{
		int beginOffset = BeginAddingRecord(262);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangVillagerCasualty(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(263);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKillHereticRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(264);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByHereticRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillRighteousRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(266);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByRighteousRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(267);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillAnimal(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(268);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByAnimal(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(269);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromEnemyNest(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(270);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddDummy0(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(271);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDummy1(int charId)
	{
		int beginOffset = BeginAddingRecord(272);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDummy2()
	{
		int beginOffset = BeginAddingRecord(273);
		EndAddingRecord(beginOffset);
	}

	public void AddMiscarriageAndReincarnation(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(274);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMiscarriageAndReincarnationMotherDies(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(275);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMiscarriageAndReincarnationMotherKilled(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiShiReturns()
	{
		int beginOffset = BeginAddingRecord(277);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiDoomOfEmei()
	{
		int beginOffset = BeginAddingRecord(278);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromEnemyNest(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddSavedFromEnemyNest(int charId, Location location, int adventureCoreId, int charId1)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddCultureDecline(short settlementId, int charId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFiveLoongArise(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoPoolAccident(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(283);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoGoHome(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoBrokeThroughTheShell(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoHasReachedAnAdultAge(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectQiuniu(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectYazi(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChaofeng(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectPulao(int jiaoLoongId, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendJiaoLoong(jiaoLoongId);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectSuanni(Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBaxia(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBian(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectFuxi(Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChiwen(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoLayEggs(Location location, int jiaoLoongId, int jiaoLoongId1)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoLoong(jiaoLoongId1);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoTamingPointsLow(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(297);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromAge(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromPoorHealth(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddKilledInPubilc(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(300);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangHaunted(int charId)
	{
		int beginOffset = BeginAddingRecord(301);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangFollowedByGhost(int charId)
	{
		int beginOffset = BeginAddingRecord(302);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangWrongdoing()
	{
		int beginOffset = BeginAddingRecord(303);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangPray()
	{
		int beginOffset = BeginAddingRecord(304);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangFameDistribution(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(305);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingParasitiferDead(sbyte itemType, short itemTemplateId, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingDead(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(307);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddWugKingDeadSpecial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangFamousFakeMonk()
	{
		int beginOffset = BeginAddingRecord(309);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangRockFleshed()
	{
		int beginOffset = BeginAddingRecord(310);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianParanoiaAppeared(int charId)
	{
		int beginOffset = BeginAddingRecord(311);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangVillagerFlee(int charId)
	{
		int beginOffset = BeginAddingRecord(312);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanSanZongBiWu()
	{
		int beginOffset = BeginAddingRecord(313);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessHuaJu(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(314);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessXuanZhi(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(315);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookSuccessYingJiao(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(316);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookFailureHuaJu(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(317);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookFailureXuanZhi(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(318);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookFailureYingJiao(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseBookHuaJu(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(320);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseBookXuanZhi(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseBookYingJiao(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(322);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseTargetHuaJu(int charId)
	{
		int beginOffset = BeginAddingRecord(323);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseTargetXuanZhi(int charId)
	{
		int beginOffset = BeginAddingRecord(324);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveUpLegendaryBookLoseTargetYingJiao(int charId)
	{
		int beginOffset = BeginAddingRecord(325);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeLinkHealing(int charId)
	{
		int beginOffset = BeginAddingRecord(326);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeLinkDamage(int charId)
	{
		int beginOffset = BeginAddingRecord(327);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaLeukoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(328);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaMelanoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(329);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaLeukoHelps()
	{
		int beginOffset = BeginAddingRecord(330);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaMelanoHelps()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManicLow(Location location)
	{
		int beginOffset = BeginAddingRecord(332);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManicHigh(Location location)
	{
		int beginOffset = BeginAddingRecord(333);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLoopingEvent(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(334);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFiveElementsChange()
	{
		int beginOffset = BeginAddingRecord(335);
		EndAddingRecord(beginOffset);
	}

	public void AddResourcesCollectionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(336);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongSacrifice()
	{
		int beginOffset = BeginAddingRecord(337);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFeatherDrop(short chickenId)
	{
		int beginOffset = BeginAddingRecord(338);
		AppendChicken(chickenId);
		EndAddingRecord(beginOffset);
	}

	public void AddMarketComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(339);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTownCombatComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(340);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketContestComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(341);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLifeCompetitionComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(342);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSectNormalCompetitionComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(343);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddJoustForSpouseComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(344);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDyingNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(345);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddInjuredNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(346);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTrappedNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(347);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFightSucceed(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(348);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFightFail(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(349);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFamilyFightFail(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(350);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongRobbery(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(351);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFamilyRobbery(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(352);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddDeliverInPrison0(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(353);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDeliverInPrison1(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(354);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDieInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(355);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddAssassinatedInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(356);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddAssassinatedDueToKillerTokenInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(357);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonAndAbandonBaby0(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(358);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddImprisonAndAbandonBaby1(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(359);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddResourceMigration(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(360);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddChickenSecretInformation(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(361);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuNormalInformation(int charId, sbyte xiangshuAvatarId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(362);
		AppendCharacter(charId);
		AppendSwordTomb(xiangshuAvatarId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFireVanishes()
	{
		int beginOffset = BeginAddingRecord(363);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongLooting()
	{
		int beginOffset = BeginAddingRecord(364);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangTreesGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(365);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryZhujianSwordTestCeremony()
	{
		int beginOffset = BeginAddingRecord(366);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanMove(sbyte merchant, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(367);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassSettlement(sbyte merchant, short settlementId, int value, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(368);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(369);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(370);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassLowSafetySettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(371);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassHighSafetySettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(372);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassLowSafetyLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(373);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassLowSafetyHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(374);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassHighSafetyLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(375);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanPassHighSafetyHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(376);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanArrive(sbyte merchant, short settlementId, int value, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(377);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanIsRobbed(sbyte merchant, Location location)
	{
		int beginOffset = BeginAddingRecord(378);
		AppendMerchant(merchant);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddInvestedCaravanIsRobbedAndFailed(sbyte merchant, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(379);
		AppendMerchant(merchant);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBuildingUpgradingHolded(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(380);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPunishmentLost0(short settlementId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(381);
		AppendSettlement(settlementId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	public void AddPunishmentLost1(short settlementId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(382);
		AppendSettlement(settlementId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	public void AddOutsiderMakeHarvest(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(383);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillageCraftObjectsFinished(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(384);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddOutsiderMakeHarvest1(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(385);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerDied(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, Location location)
	{
		int beginOffset = BeginAddingRecord(386);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRemakeEmeiHomocideCase()
	{
		int beginOffset = BeginAddingRecord(387);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRemakeEmeiRumor()
	{
		int beginOffset = BeginAddingRecord(388);
		EndAddingRecord(beginOffset);
	}

	public void AddDieNotice(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(389);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWantedNotice(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(390);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanJuemo()
	{
		int beginOffset = BeginAddingRecord(391);
		EndAddingRecord(beginOffset);
	}

	public void AddCoreMaterialIncome(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(392);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyGetInfected(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(393);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFamilyDieByInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(394);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddFocusedGetInfected(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(395);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFocusedDieByInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(396);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalVillagersInjured(int value)
	{
		int beginOffset = BeginAddingRecord(397);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalVillagerCasualty(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(398);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalTreesGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(399);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCraftFinished0(short buildingTemplateId, sbyte itemType, short itemTemplateId, int charId)
	{
		int beginOffset = BeginAddingRecord(400);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCraftFinished1(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(401);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCraftFinished2(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(402);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillagerCraftFinished3(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(403);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcCraftFinished0(int charId, short settlementId, sbyte itemType, short itemTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(404);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcCraftFinished1(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(405);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcCraftFinished2(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(406);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcCraftFinished3(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(407);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcLongDistanceMarriage0(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(408);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcLongDistanceMarriage1(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(409);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddNpcLongDistanceMarriage2(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(410);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWithoutFood(int charId)
	{
		int beginOffset = BeginAddingRecord(411);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscape0(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(412);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEscape1(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(413);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFailed(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(438);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddFirstGetInfected0(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(414);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFirstGetInfected1(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(415);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddYuanshanSpiritCrisis(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(416);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddYuanshanDemonCrisis(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(417);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotPoisonedEnemyEscaped(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(418);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddPlotHarmEnemyEscaped(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(419);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGoingToAppointment(int charId, int value, Location location)
	{
		int beginOffset = BeginAddingRecord(420);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainPeople(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(421);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainFail(int charId)
	{
		int beginOffset = BeginAddingRecord(422);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouTaiwuTransferFiveElements(int charId)
	{
		int beginOffset = BeginAddingRecord(423);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouTaiwuTransferFiveElementsFail(int charId)
	{
		int beginOffset = BeginAddingRecord(424);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeili(int charId)
	{
		int beginOffset = BeginAddingRecord(425);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeiliFail(int charId)
	{
		int beginOffset = BeginAddingRecord(426);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouTaiwuTransFiveElements(Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(427);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouTaiwuTransFiveElementsFail(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(428);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeiliFail1(int charId)
	{
		int beginOffset = BeginAddingRecord(429);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeiliFail2(int charId)
	{
		int beginOffset = BeginAddingRecord(430);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiDrainNeiliFail3(int charId)
	{
		int beginOffset = BeginAddingRecord(431);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddChallengeModeAdvanceMonthWorsenInjuryOuter(int value)
	{
		int beginOffset = BeginAddingRecord(432);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddChallengeModeAdvanceMonthWorsenInjuryInner(int value)
	{
		int beginOffset = BeginAddingRecord(433);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddChallengeModeAdvanceMonthWorsenPoison()
	{
		int beginOffset = BeginAddingRecord(434);
		EndAddingRecord(beginOffset);
	}

	public void AddChickenFullyFledged()
	{
		int beginOffset = BeginAddingRecord(435);
		EndAddingRecord(beginOffset);
	}

	public void AddCostResourceNotEnough(int charId)
	{
		int beginOffset = BeginAddingRecord(436);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCostResourceNotEnoughResult(int charId)
	{
		int beginOffset = BeginAddingRecord(437);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketGrowUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(439);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillRighteousRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(440);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByRighteousRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(441);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillHereticRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(442);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByHereticRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(443);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddKillAnimalVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(444);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDefeatedByAnimalVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(445);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDieFromEnemyNestVillager(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(446);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromEnemyNestVillager(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(447);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddSavedFromEnemyNestVillager(int charId, Location location, int adventureCoreId, int charId1)
	{
		int beginOffset = BeginAddingRecord(448);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddInfectedKidnapedCharacterEscape(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(449);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddOwningBookKidnapedCharacterEscape(int charId, int charId1, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(450);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiStrangerAttack()
	{
		int beginOffset = BeginAddingRecord(451);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiInsaneMember()
	{
		int beginOffset = BeginAddingRecord(452);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiRumors()
	{
		int beginOffset = BeginAddingRecord(453);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiReputation()
	{
		int beginOffset = BeginAddingRecord(454);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiSecretBook()
	{
		int beginOffset = BeginAddingRecord(455);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingUpgradeXingYun(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(456);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalWuFanKe(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(457);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalDianFanMo(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(458);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureCapitalCity(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(459);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddSmallMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(460);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureJieqi(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(461);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureTeaParty(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(462);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureWineParty(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(463);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureMartialHall(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(464);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureMissionReward(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(465);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureWorldSecretRealm(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(466);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventureJieqiComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(467);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction1(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(468);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBehaviorTypeAction2(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(469);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNewMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(470);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	public void AddPreciousMaterial(Location location)
	{
		int beginOffset = BeginAddingRecord(471);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCChickenFeatherGift(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(472);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdventurePrepareNotification(short notificationId, AdventureRuntime runtime)
	{
		if (notificationId >= 0)
		{
			int currDate = ExternalDataBridge.Context.CurrDate;
			AdventureParameterValue? autoCheckSatisfiedDate = runtime.GetParameterOrNull("ConchShipPresetKey_AutoCheckSatisfiedDate");
			if (autoCheckSatisfiedDate.HasValue && autoCheckSatisfiedDate.Value.Current > currDate)
			{
				int remainMonth = autoCheckSatisfiedDate.Value.Current - currDate;
				int beginOffset = BeginAddingRecord(notificationId);
				AppendLocation(runtime.MapLocation);
				AppendAdventure(runtime.CoreId);
				AppendInteger(remainMonth);
				EndAddingRecord(beginOffset);
			}
		}
	}

	public void AddAdventureActiveNotification(short notificationId, AdventureRuntime runtime)
	{
		if (notificationId >= 0)
		{
			int beginOffset = BeginAddingRecord(notificationId);
			AppendLocation(runtime.MapLocation);
			AppendAdventure(runtime.CoreId);
			EndAddingRecord(beginOffset);
		}
	}

	public void AddConfigMonthlyActionNotification(MonthlyActionsItem actionCfg, IRecordArgumentSource argSource)
	{
		short recordType = actionCfg.NotificationId;
		if (recordType < 0)
		{
			return;
		}
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[recordType];
		int beginOffset = BeginAddingRecord(recordType);
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
				AppendCharacter(argSource.GetCharacterArg());
				continue;
			case 1:
				AppendLocation(argSource.GetLocationArg());
				continue;
			case 5:
				AppendSettlement(argSource.GetSettlementArg());
				continue;
			case 10:
				AppendAdventure(argSource.GetAdventureArg());
				continue;
			case 27:
				AppendLifeSkillType(argSource.GetLifeSkillTypeArg());
				continue;
			}
			throw new Exception("Unsupported parameter type " + paramTypeStr + " detected for world action " + actionCfg.Name + ".");
		}
		EndAddingRecord(beginOffset);
	}

	public void AddConfigMonthlyActionAnnouncementNotification(MonthlyActionsItem actionCfg, IRecordArgumentSource argSource, int countDown)
	{
		short recordType = actionCfg.NotificationId;
		if (recordType < 0)
		{
			return;
		}
		short notificationId = recordType switch
		{
			139 => 344, 
			182 => 344, 
			183 => 343, 
			131 => 339, 
			132 => 340, 
			135 => 342, 
			134 => 341, 
			_ => -1, 
		};
		if (notificationId < 0)
		{
			return;
		}
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[notificationId];
		int beginOffset = BeginAddingRecord(notificationId);
		for (int i = 0; i < recordCfg.Parameters.Length; i++)
		{
			string paramTypeStr = recordCfg.Parameters[i];
			if (string.IsNullOrEmpty(paramTypeStr))
			{
				break;
			}
			switch (ParameterType.Parse(paramTypeStr))
			{
			case 5:
				AppendSettlement(argSource.GetSettlementArg());
				continue;
			case 10:
				AppendAdventure(argSource.GetAdventureArg());
				continue;
			case 22:
				AppendInteger(countDown);
				continue;
			}
			throw new Exception("Unsupported parameter type " + paramTypeStr + " detected for world action " + actionCfg.Name + ".");
		}
		EndAddingRecord(beginOffset);
	}

	public void AddDeathNotification(int charId, CharacterDeathTypeItem deathType, ref CharacterDeathInfo deathInfo)
	{
		int beginOffset = BeginAddingRecord(deathType.DefaultMonthlyNotification);
		bool selfCharIdAdded = false;
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[deathType.DefaultMonthlyNotification];
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
				if (!selfCharIdAdded)
				{
					selfCharIdAdded = true;
					AppendCharacter(charId);
				}
				else
				{
					AppendCharacter((deathInfo.KillerId >= 0) ? deathInfo.KillerId : charId);
				}
				break;
			case 10:
				AppendAdventure(deathInfo.AdventureId);
				break;
			case 1:
				AppendLocation(deathInfo.Location);
				break;
			default:
				throw new Exception("Unrecognized parameter type for death record " + recordCfg.Name);
			}
		}
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionCommonSingleTarget(int selfCharId, int targetCharId, Location location, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.MonthlyNotification >= 0)
		{
			MonthlyNotificationItem monthlyNotificationCfg = MonthlyNotification.Instance[actionTemplate.MonthlyNotification];
			if (monthlyNotificationCfg.Parameters.Length < 3 || monthlyNotificationCfg.Parameters[0] != "Character" || monthlyNotificationCfg.Parameters[1] != "Character" || monthlyNotificationCfg.Parameters[2] != "Location")
			{
				AdaptableLog.Warning($"Invalid monthly notification parameters for {monthlyNotificationCfg.Name}({monthlyNotificationCfg.TemplateId})");
				return;
			}
			int beginOffset = BeginAddingRecord(actionTemplate.MonthlyNotification);
			AppendCharacter(selfCharId);
			AppendCharacter(targetCharId);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}
}
