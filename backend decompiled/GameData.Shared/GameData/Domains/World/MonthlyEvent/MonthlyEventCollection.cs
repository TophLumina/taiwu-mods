using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.MonthlyEvent;

public class MonthlyEventCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<MonthlyEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			MonthlyEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(short*)(pRawData + offset + 1);
		}
	}

	public new unsafe MonthlyEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			MonthlyEventItem config = Config.MonthlyEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			MonthlyEventRenderInfo info = new MonthlyEventRenderInfo(recordType, config.Desc, offset);
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
			info.EventGuid = config.Event;
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

	private unsafe static string ReadString(byte** ppData)
	{
		*ppData += SerializationHelper.Deserialize(*ppData, out var value);
		return value;
	}

	private unsafe void AppendString(string value)
	{
		int offset = Size;
		int newSize = Size + 2 + value.Length * 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			SerializationHelper.Serialize(pRawData + offset, value);
		}
	}

	public void AddMonthlyEventWithNoArgument(short templateId)
	{
		Tester.Assert(Config.MonthlyEvent.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMonthlyEventWithOneCharacterArgument(short templateId, int charId)
	{
		MonthlyEventItem config = Config.MonthlyEvent.Instance[templateId];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 1 && ParameterType.Parse(config.Parameters[0]) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddReadingEvent(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuDeath(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAreaTotallyDestoryed(int charId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuInfectedPartially(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRandomEnemyAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRandomAnimalAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRandomRighteousAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddInfectedCharacterAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddHumanSkeletonAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketInDream(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToCricketTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddGiveBirthToCricketWife(int charId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddPrenatalEducationTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAbortionTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddLoseFetusWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherFetusBothDieTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMotherFetusBothDieWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaLoseFetusTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaLoseFetusWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaButHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaButHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaButHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaButHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaAndHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaAndHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaAndHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDystociaAndHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAbandonedBabyInVilliage(int charId)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddChildZhuazhou(int charId)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachChild(int charId)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddReachAdulthood(int charId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCaptiveHaveChild(int charId, int charId1, int charId2, int charId3, int charId4, int charId5, int charId6)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		AppendCharacter(charId3);
		AppendCharacter(charId4);
		AppendCharacter(charId5);
		AppendCharacter(charId6);
		EndAddingRecord(beginOffset);
	}

	public void AddCaptiveBecomeEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGroupGetMarried(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSpringMarket()
	{
		int beginOffset = BeginAddingRecord(39);
		EndAddingRecord(beginOffset);
	}

	public void AddSummerTownCompetition(Location location)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAutumnCricketContest(Location location)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddWinterLifeCompetition(short lifeSkillTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdore(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddConfess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBreakup(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddProposeMarriage(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeFriend(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBecomeSwornBrotherOrSister(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSeverSwornBrotherhood(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedByFather(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddGetAdoptedByMother(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptSon(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdoptDaughter(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDie(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddEscapeFromPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAppointmentCancelled(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRevengeAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAskProtectByRevengeAttack(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddCatchEnemyPoison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyPoisonAndEscape(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddCatchEnemyPlotHarm(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddEnemyPlotHarmAndEscape(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealOuterInjuryByItem(int charId, Location location, int charId1, ulong itemKey, sbyte bodyPartType)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendBodyPartType(bodyPartType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealOuterInjuryByResource(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealInnerInjuryByItem(int charId, Location location, int charId1, ulong itemKey, sbyte bodyPartType)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendBodyPartType(bodyPartType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealInnerInjuryByResource(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealPoisonByItem(int charId, Location location, int charId1, ulong itemKey, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealPoisonByResource(int charId, Location location, int charId1, int value, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealth(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestHealDisorderOfQi(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestNeili(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestKillWug(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestFood(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestTeaWine(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestItem(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestRepairItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestAddPoisonToItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnLifeSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnCombatSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnReadingLifeSkill(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnReadingCombatSkill(int charId, Location location, int charId1, ulong itemKey, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestInstructionOnBreakout(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestPlayCombat(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestNormalCombat(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestLifeSkillBattle(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestCricketBattle(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyButBeCaught(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterSecretlyAndEscape(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithWit(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddRescueKidnappedCharacterWithForce(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceButBeCaught(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealResourceAndEscape(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamResource(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobResource(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemButBeCaught(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddStealItemAndEscape(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddScamItem(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRobItem(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillButBeCaught(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLifeSkillAndEscape(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLifeSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillButBeCaught(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddStealCombatSkillAndEscape(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddScamCombatSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseExtendFavours(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseWinPeopleSupport(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseMerchantFavor(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseTeaWine(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseSales(int charId, Location location, int charId1, ulong itemKey, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseHealInjury(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseHealPoison(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseRepairItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseBarb(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddAskForMoney(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceTaiwuAbsent()
	{
		int beginOffset = BeginAddingRecord(119);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceAskForHelp(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillageBeDestoryed()
	{
		int beginOffset = BeginAddingRecord(121);
		EndAddingRecord(beginOffset);
	}

	public void AddForeverLoverBePunished(int charId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByMonv()
	{
		int beginOffset = BeginAddingRecord(123);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByDayueYaochang()
	{
		int beginOffset = BeginAddingRecord(124);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByJiuhan()
	{
		int beginOffset = BeginAddingRecord(125);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByJinHuanger()
	{
		int beginOffset = BeginAddingRecord(126);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByYiYihou()
	{
		int beginOffset = BeginAddingRecord(127);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByWeiQi()
	{
		int beginOffset = BeginAddingRecord(128);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByYixiang()
	{
		int beginOffset = BeginAddingRecord(129);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByXuefeng()
	{
		int beginOffset = BeginAddingRecord(130);
		EndAddingRecord(beginOffset);
	}

	public void AddVillageWoodenManByShuFang()
	{
		int beginOffset = BeginAddingRecord(131);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuNotAttendingWedding(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuAlreadyMarried(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddChallengeForLegendaryBook(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddRequestLegendaryBook(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddExchangeLegendaryBookByMoney(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddExchangeLegendaryBookByAuthority(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddExchangeLegendaryBookByExperience(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLegendaryBookAndEscape(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddStealLegendaryBookGotCaught(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddScamLegendaryBook(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddRobLegendaryBook(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookShockedAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookInsaneAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddLegendaryBookConsumedAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombGetStronger(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordTombBackToNormal(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForNewLegendaryBook(Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookAbandoned(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookOwnerDie(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddFightForLegendaryBookOwnerConsumed(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddDateWithLoverEveryday(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddHappyBirthdayTaiwu(int charId, sbyte month)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendCharacter(charId);
		AppendMonth(month);
		EndAddingRecord(beginOffset);
	}

	public void AddLoveAnniversary(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddNeglectedLover(int charId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddLoverBecomeJealous(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddLoversBecomeJealousAndViolent(int charId, int charId1, int charId2, int charId3)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		AppendCharacter(charId3);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnancyWithLover(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggerSkill2TargetUnavailable(int charId)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggarSkill2TargetBrought(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggarSkill2TargetDeadAndMissing(int charId)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggarSkill2TargetDead(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBeggarSkill2TargetNoneExistent(string text)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendText(text);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuTribulation(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuComingSuccess(int charId, int charId1, Location location, int charId2)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuComingDefeated(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuFreeAndunFettered(int charId)
	{
		int beginOffset = BeginAddingRecord(167);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouGraveDigging()
	{
		int beginOffset = BeginAddingRecord(172);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouGraveDiggingNormal()
	{
		int beginOffset = BeginAddingRecord(173);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouStrangeDeath()
	{
		int beginOffset = BeginAddingRecord(174);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouOldManAppears()
	{
		int beginOffset = BeginAddingRecord(175);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouOldManReturns()
	{
		int beginOffset = BeginAddingRecord(176);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouOnBloodBlock()
	{
		int beginOffset = BeginAddingRecord(177);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouOldManAttacks()
	{
		int beginOffset = BeginAddingRecord(178);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouHarmoniousTaiwu()
	{
		int beginOffset = BeginAddingRecord(179);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouFeedJixi()
	{
		int beginOffset = BeginAddingRecord(180);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouMythInVillage()
	{
		int beginOffset = BeginAddingRecord(181);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouProtectJixi()
	{
		int beginOffset = BeginAddingRecord(182);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiAskForFood()
	{
		int beginOffset = BeginAddingRecord(183);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiFeedChicken()
	{
		int beginOffset = BeginAddingRecord(184);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouJixiKills()
	{
		int beginOffset = BeginAddingRecord(185);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouVillageWork()
	{
		int beginOffset = BeginAddingRecord(186);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouFinale()
	{
		int beginOffset = BeginAddingRecord(187);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinTowerFalling()
	{
		int beginOffset = BeginAddingRecord(190);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinLearning()
	{
		int beginOffset = BeginAddingRecord(193);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinNotEnough()
	{
		int beginOffset = BeginAddingRecord(194);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinChallenge()
	{
		int beginOffset = BeginAddingRecord(195);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinEndChallenge()
	{
		int beginOffset = BeginAddingRecord(196);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinNeverLearnChallenge()
	{
		int beginOffset = BeginAddingRecord(197);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuannvPrologue()
	{
		int beginOffset = BeginAddingRecord(200);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanInfectedCharacterAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(210);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanDisciplesInfected()
	{
		int beginOffset = BeginAddingRecord(211);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanLastMonsterAppear()
	{
		int beginOffset = BeginAddingRecord(212);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryYuanshanProsperous()
	{
		int beginOffset = BeginAddingRecord(213);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangDuel(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangPeopleSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(219);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangAttack()
	{
		int beginOffset = BeginAddingRecord(220);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangMonkMurdered()
	{
		int beginOffset = BeginAddingRecord(221);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangExorcism(int charId)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangGhostAppears()
	{
		int beginOffset = BeginAddingRecord(223);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianPoisonousWug(int charId)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianProsperous()
	{
		int beginOffset = BeginAddingRecord(228);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianFailing0()
	{
		int beginOffset = BeginAddingRecord(229);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianFailing1()
	{
		int beginOffset = BeginAddingRecord(230);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianStrangeThings()
	{
		int beginOffset = BeginAddingRecord(231);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianPoison()
	{
		int beginOffset = BeginAddingRecord(232);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianAssault(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiProsperous()
	{
		int beginOffset = BeginAddingRecord(234);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiFailing()
	{
		int beginOffset = BeginAddingRecord(235);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingProsperous()
	{
		int beginOffset = BeginAddingRecord(236);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingFailing()
	{
		int beginOffset = BeginAddingRecord(237);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouEmptyGrave()
	{
		int beginOffset = BeginAddingRecord(238);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouLookingForTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryXuehouComing()
	{
		int beginOffset = BeginAddingRecord(240);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanPaperCraneFromYufuFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanPaperCraneFromShenjianFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanPaperCraneFromYinyangFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanProsperous()
	{
		int beginOffset = BeginAddingRecord(244);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanFailing()
	{
		int beginOffset = BeginAddingRecord(245);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinDreamOfReadingSutra()
	{
		int beginOffset = BeginAddingRecord(246);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinDreamOfNewTaiwu()
	{
		int beginOffset = BeginAddingRecord(247);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinEnlightenment()
	{
		int beginOffset = BeginAddingRecord(248);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinNotEnoughCommon()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangRequestBook(int charId, Location location, ulong itemKey, int charId1)
	{
		int beginOffset = BeginAddingRecord(250);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangRequestLifeSkill(int charId, Location location, ulong itemKey, int charId1)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangGoodNews()
	{
		int beginOffset = BeginAddingRecord(252);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(254);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinEndChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(255);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinNeverLearnChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(256);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangLetterFrom2(int charId)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangGoodNews2()
	{
		int beginOffset = BeginAddingRecord(258);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangEnemyAttack2()
	{
		int beginOffset = BeginAddingRecord(259);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShixiangStrange()
	{
		int beginOffset = BeginAddingRecord(260);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangProtectHeavenlyTree()
	{
		int beginOffset = BeginAddingRecord(262);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangHeavenlyTreeDestroyed(Location location)
	{
		int beginOffset = BeginAddingRecord(263);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangMeetingImmortal(int charId, Location location, int charId1, Location location1)
	{
		int beginOffset = BeginAddingRecord(265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangGuardHeavenlyTree(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(266);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangHeavenlyTreeDestroyed2(Location location)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMirrorCreatedImpostureXiangshuInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(277);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWudangProtectHeavenlyTree2()
	{
		int beginOffset = BeginAddingRecord(278);
		EndAddingRecord(beginOffset);
	}

	public void AddCrossArchiveReunionWithAcquaintance(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTeachCombatSkill(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddPregnant(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddTamingCarriers(short charTemplateId, Location location, ulong itemKey, Location location1)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	public void AddFiveLoongLetterFromTaiwuVillage()
	{
		int beginOffset = BeginAddingRecord(283);
		EndAddingRecord(beginOffset);
	}

	public void AddJiaoGrowold(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectQiuniu(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectYazi(int charId, int jiaoLoongId, int charId1)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChaofeng(int charId, int jiaoLoongId, int charId1)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectPulao(int charId, int jiaoLoongId, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectSuanni(int charId, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBaxia(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectBian(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectFuxi(int charId, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongRidingEffectChiwen(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddMinionLoongAttack(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCLoongJiaoGrowUp(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianGiftsReceived(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangVisitorsArrive()
	{
		int beginOffset = BeginAddingRecord(297);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangLettersFromJingang(int charId)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangPiety(int charId)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangRitualsInDream()
	{
		int beginOffset = BeginAddingRecord(301);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangReincarnation(int charId)
	{
		int beginOffset = BeginAddingRecord(304);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJingangGhostVanishes()
	{
		int beginOffset = BeginAddingRecord(305);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryWuxianMiaoWoman(Location location)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanDragonGate()
	{
		int beginOffset = BeginAddingRecord(307);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanMessage(int charId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanAfterQinglang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(309);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryRanshanSanshiLeave(int charId)
	{
		int beginOffset = BeginAddingRecord(310);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaEndenmic()
	{
		int beginOffset = BeginAddingRecord(311);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaDreamAboutPastLast(int charId)
	{
		int beginOffset = BeginAddingRecord(313);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaLeukoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(317);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMerchantVisit()
	{
		int beginOffset = BeginAddingRecord(318);
		EndAddingRecord(beginOffset);
	}

	public void AddToRepayKindness(Location location)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaAmbushLeuko()
	{
		int beginOffset = BeginAddingRecord(320);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaMelanoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaAmbushMelano()
	{
		int beginOffset = BeginAddingRecord(322);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaManicAttack(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(325);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaAnonymReturns()
	{
		int beginOffset = BeginAddingRecord(326);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaMelanoPlay()
	{
		int beginOffset = BeginAddingRecord(328);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaLeukoPlay()
	{
		int beginOffset = BeginAddingRecord(329);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryBaihuaLeukoMelanoPlay()
	{
		int beginOffset = BeginAddingRecord(330);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongDiasterAppear()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongLazuliLetter()
	{
		int beginOffset = BeginAddingRecord(333);
		EndAddingRecord(beginOffset);
	}

	public void AddHuntCriminal(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(336);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddSentenceCompleted(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(337);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongRobTaiwu(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(338);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongInterfereRobbery(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(339);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongProtect(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(340);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryFulongFireFighting(int charId)
	{
		int beginOffset = BeginAddingRecord(341);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseHealDisorderOfQi(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(343);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddAdviseHealHealth(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(344);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiWuVillagerClothing(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(345);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddHuntCriminalTaiwu(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(346);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryZhujianHeir(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(347);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryZhujianFailing()
	{
		int beginOffset = BeginAddingRecord(352);
		EndAddingRecord(beginOffset);
	}

	public void AddJieQingPunishmentAssassin(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(353);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuBeHuntedHunterDie(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(354);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWardOffXiangshuProtection(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(355);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddProfessionDukeReceiveCricket(int charId)
	{
		int beginOffset = BeginAddingRecord(356);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddCricketInDreamTaiwuPartnerPregnant(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(357);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryShaolinDharmaCave(int charId)
	{
		int beginOffset = BeginAddingRecord(358);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillageStoneClaimed(int charId, short settlementId, short settlementId1, int value)
	{
		int beginOffset = BeginAddingRecord(359);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuVillagerAdoptOrphan(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(360);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalHeavenlyTreeDestroyed(Location location)
	{
		int beginOffset = BeginAddingRecord(363);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddNormalGuardHeavenlyTree(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(364);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddBackFromOuterWorlds(int charId)
	{
		int beginOffset = BeginAddingRecord(374);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddAiLongDistanceMarriageAskAdvice(int charId)
	{
		int beginOffset = BeginAddingRecord(378);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCYearOfHorseCloth()
	{
		int beginOffset = BeginAddingRecord(393);
		EndAddingRecord(beginOffset);
	}

	public void AddBequest(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(394);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryTianmuPeopleRemoveItem(int charId)
	{
		int beginOffset = BeginAddingRecord(395);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalXuSeekSacrifice(int charId)
	{
		int beginOffset = BeginAddingRecord(396);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryHeavenlyDarkFire(int charId)
	{
		int beginOffset = BeginAddingRecord(397);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryWuxiaoSpiritSection0(int charId)
	{
		int beginOffset = BeginAddingRecord(398);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryWuxiaoSpiritSection1(int charId)
	{
		int beginOffset = BeginAddingRecord(399);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryWuxiaoSpiritSection2(int charId)
	{
		int beginOffset = BeginAddingRecord(400);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryThreeWorldDevilAppear()
	{
		int beginOffset = BeginAddingRecord(401);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryThreeWorldDevilFire(Location location)
	{
		int beginOffset = BeginAddingRecord(402);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryThreeWorldDevilBlood(Location location)
	{
		int beginOffset = BeginAddingRecord(403);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryThreeWorldDevilMelee(Location location)
	{
		int beginOffset = BeginAddingRecord(404);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalXuStolen(int charId)
	{
		int beginOffset = BeginAddingRecord(405);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCTransmogrifyingCricketToHumanbeing(short colorId, short partId, int nameId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(406);
		AppendCricket(colorId, partId, nameId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCTransmogrifyingHumanbeingToCricket(int charId, short colorId, short partId, int nameId, int charId1)
	{
		int beginOffset = BeginAddingRecord(407);
		AppendCharacter(charId);
		AppendCricket(colorId, partId, nameId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingBloodBeiDou()
	{
		int beginOffset = BeginAddingRecord(408);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingMessage()
	{
		int beginOffset = BeginAddingRecord(409);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingSmashPearl()
	{
		int beginOffset = BeginAddingRecord(410);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingRecovery()
	{
		int beginOffset = BeginAddingRecord(411);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieqingAssassination()
	{
		int beginOffset = BeginAddingRecord(412);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCGiftFromConchShip1()
	{
		int beginOffset = BeginAddingRecord(413);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCGiftFromConchShip2()
	{
		int beginOffset = BeginAddingRecord(414);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCHappyNewYear2024()
	{
		int beginOffset = BeginAddingRecord(415);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCYearOfSnakeCloth()
	{
		int beginOffset = BeginAddingRecord(416);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineIronPlateMonkInvestigate()
	{
		int beginOffset = BeginAddingRecord(417);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineIronPlateItemReceived()
	{
		int beginOffset = BeginAddingRecord(418);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineEvilDemonBlood(int charId)
	{
		int beginOffset = BeginAddingRecord(419);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineEvilMohaMind(int charId)
	{
		int beginOffset = BeginAddingRecord(420);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineEvilBloodAdv()
	{
		int beginOffset = BeginAddingRecord(421);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameFuxietie()
	{
		int beginOffset = BeginAddingRecord(422);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameJielongpo()
	{
		int beginOffset = BeginAddingRecord(423);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameDaxuanning()
	{
		int beginOffset = BeginAddingRecord(424);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameQiumomu()
	{
		int beginOffset = BeginAddingRecord(425);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameFenshenlian()
	{
		int beginOffset = BeginAddingRecord(426);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameRongchenyin()
	{
		int beginOffset = BeginAddingRecord(427);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameFenghuangjian()
	{
		int beginOffset = BeginAddingRecord(428);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameGuishenxia()
	{
		int beginOffset = BeginAddingRecord(429);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryLineDivineflameMonvyi()
	{
		int beginOffset = BeginAddingRecord(430);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiUpgradeRumors()
	{
		int beginOffset = BeginAddingRecord(431);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiUpgradeStudy()
	{
		int beginOffset = BeginAddingRecord(432);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiUpgradeAchieve(int charId)
	{
		int beginOffset = BeginAddingRecord(433);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMakeLoveWithTaiwu(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(434);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillMonvGood(int charId)
	{
		int beginOffset = BeginAddingRecord(435);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillMonvBad(int charId)
	{
		int beginOffset = BeginAddingRecord(436);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillDayueYaochangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(437);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillDayueYaochangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(438);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillJiuhanGood(int charId)
	{
		int beginOffset = BeginAddingRecord(439);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillJiuhanBad(int charId)
	{
		int beginOffset = BeginAddingRecord(440);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillJinHuangerGood(int charId)
	{
		int beginOffset = BeginAddingRecord(441);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillJinHuangerBad(int charId)
	{
		int beginOffset = BeginAddingRecord(442);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillYiYihouGood(int charId)
	{
		int beginOffset = BeginAddingRecord(443);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillYiYihouBad(int charId)
	{
		int beginOffset = BeginAddingRecord(444);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillWeiQiGood(int charId)
	{
		int beginOffset = BeginAddingRecord(445);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillWeiQiBad(int charId)
	{
		int beginOffset = BeginAddingRecord(446);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillYixiangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(447);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillYixiangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(448);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillXuefengGood(int charId)
	{
		int beginOffset = BeginAddingRecord(449);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillXuefengBad(int charId)
	{
		int beginOffset = BeginAddingRecord(450);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillShuFangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(451);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSwordFragmentUnlockSkillShuFangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(452);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryMessagefromtheAvatar(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(453);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryTidingsonSwiftBlades(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(454);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryMessagefromanOldFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(455);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryTidingsfromanOldFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(456);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryMessagefromWunian(int charId)
	{
		int beginOffset = BeginAddingRecord(457);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryTidingsoftheMind(int charId)
	{
		int beginOffset = BeginAddingRecord(458);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryStirringoftheSwordHilt()
	{
		int beginOffset = BeginAddingRecord(459);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryMoonlitPurpleDust()
	{
		int beginOffset = BeginAddingRecord(460);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryMidnightUpheaval()
	{
		int beginOffset = BeginAddingRecord(461);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryStrangeFireScorchestheSky()
	{
		int beginOffset = BeginAddingRecord(462);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieQingUpgradeYuchan()
	{
		int beginOffset = BeginAddingRecord(463);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryJieQingUpgradeXingYun()
	{
		int beginOffset = BeginAddingRecord(464);
		EndAddingRecord(beginOffset);
	}

	public void AddXiangshuAvatarAttack(sbyte xiangshuAvatarId)
	{
		int beginOffset = BeginAddingRecord(465);
		AppendSwordTomb(xiangshuAvatarId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiBeginning()
	{
		int beginOffset = BeginAddingRecord(466);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiMidnight()
	{
		int beginOffset = BeginAddingRecord(467);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiSecretLetter()
	{
		int beginOffset = BeginAddingRecord(468);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiUrgentLetter()
	{
		int beginOffset = BeginAddingRecord(469);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiFruitsGift(int charId)
	{
		int beginOffset = BeginAddingRecord(470);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiAppreciateofEmei()
	{
		int beginOffset = BeginAddingRecord(471);
		EndAddingRecord(beginOffset);
	}

	public void AddSectMainStoryEmeiFarewell()
	{
		int beginOffset = BeginAddingRecord(472);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalChiHongZi(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(473);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalPoJinShangRen(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(474);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalBaJiuJianYin(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(475);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalZhenDanShengNv(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(476);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCGreenHillsRemain()
	{
		int beginOffset = BeginAddingRecord(477);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCEightYearsOneJourney()
	{
		int beginOffset = BeginAddingRecord(478);
		EndAddingRecord(beginOffset);
	}

	public void AddMainStoryImmortalHuoGuShi(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(479);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	public void AddWulinConferenceGift(int charId)
	{
		int beginOffset = BeginAddingRecord(480);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCSmarterChickenKingBecomeHuman()
	{
		int beginOffset = BeginAddingRecord(481);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCTransmogrifyingHumanToChicken(int charId)
	{
		int beginOffset = BeginAddingRecord(482);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCAdoptChicken(short settlementId, short chickenId)
	{
		int beginOffset = BeginAddingRecord(483);
		AppendSettlement(settlementId);
		AppendChicken(chickenId);
		EndAddingRecord(beginOffset);
	}

	public void AddDLCTameLoongPolymorphReturn(int charId)
	{
		int beginOffset = BeginAddingRecord(484);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	public void AddTaiwuAsXiangshuSkill0(Location location)
	{
		int beginOffset = BeginAddingRecord(485);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	public void AddAutoMonthlyEvent(IVariantCollection<string> argBox, MonthlyEventItem monthlyEventCfg)
	{
		int i = 0;
		for (int count = monthlyEventCfg.Parameters.Length; i < count; i++)
		{
			string parameter = monthlyEventCfg.Parameters[i];
			if (!string.IsNullOrEmpty(parameter) && !monthlyEventCfg.AutoTriggerArguments.CheckIndex(i))
			{
				AdaptableLog.Warning($"Invalid auto monthly event with args: {monthlyEventCfg.Name} arg{i}={parameter}", appendWarningMessage: true);
				return;
			}
		}
		int beginOffset = BeginAddingRecord(monthlyEventCfg.TemplateId);
		int j = 0;
		for (int count2 = monthlyEventCfg.Parameters.Length; j < count2; j++)
		{
			string parameter2 = monthlyEventCfg.Parameters[j];
			if (!string.IsNullOrEmpty(parameter2))
			{
				sbyte paramType = ParameterType.Parse(parameter2);
				string argKey = monthlyEventCfg.AutoTriggerArguments[j];
				switch (paramType)
				{
				case 0:
				{
					int charId = GetCharIdFromArgBox(argBox, argKey);
					AppendCharacter(charId);
					break;
				}
				case 1:
				{
					Location location = GetLocationFromArgBox(argBox, argKey);
					AppendLocation(location);
					break;
				}
				case 5:
				{
					int settlement = -1;
					argBox.Get(argKey, ref settlement);
					AppendSettlement((short)settlement);
					break;
				}
				case 10:
				{
					int adventureId = -1;
					argBox.Get(argKey, ref adventureId);
					AppendAdventure((short)adventureId);
					break;
				}
				case 22:
				{
					int value = 0;
					argBox.Get(argKey, ref value);
					AppendInteger(value);
					break;
				}
				case 25:
				{
					argBox.Get(argKey, out ItemKey itemKey);
					AppendItemKey((ulong)itemKey);
					break;
				}
				default:
					AdaptableLog.Warning("Invalid auto monthly event with args: " + monthlyEventCfg.Name, appendWarningMessage: true);
					break;
				}
			}
		}
		EndAddingRecord(beginOffset);
	}

	public void AddAutoMonthlyEvent(IVariantCollection<string> argBox, AutoTriggerMonthlyEvent monthlyEvent)
	{
		int beginOffset = BeginAddingRecord(monthlyEvent.MonthlyEventId);
		MonthlyEventItem monthlyEventCfg = Config.MonthlyEvent.Instance[monthlyEvent.MonthlyEventId];
		int i = 0;
		for (int count = monthlyEventCfg.Parameters.Length; i < count; i++)
		{
			string parameter = monthlyEventCfg.Parameters[i];
			if (string.IsNullOrEmpty(parameter))
			{
				break;
			}
			string argKey = monthlyEvent.Args[i];
			switch (ParameterType.Parse(parameter))
			{
			case 0:
			{
				int charId = GetCharIdFromArgBox(argBox, argKey);
				AppendCharacter(charId);
				break;
			}
			case 1:
			{
				Location location = GetLocationFromArgBox(argBox, argKey);
				AppendLocation(location);
				break;
			}
			case 5:
			{
				int settlement = -1;
				argBox.Get(argKey, ref settlement);
				AppendSettlement((short)settlement);
				break;
			}
			case 10:
			{
				int adventureId = -1;
				argBox.Get(argKey, ref adventureId);
				AppendAdventure((short)adventureId);
				break;
			}
			case 22:
			{
				int value = 0;
				argBox.Get(argKey, ref value);
				AppendInteger(value);
				break;
			}
			case 25:
			{
				argBox.Get(argKey, out ItemKey itemKey);
				AppendItemKey((ulong)itemKey);
				break;
			}
			}
		}
		EndAddingRecord(beginOffset);
	}

	public void AddWorldStateMonthlyEvent(WorldStateItem worldState, MonthlyEventItem monthlyEvent)
	{
		int beginOffset = BeginAddingRecord(monthlyEvent.TemplateId);
		EndAddingRecord(beginOffset);
	}

	private int GetCharIdFromArgBox(IVariantCollection<string> argBox, string argKey)
	{
		if (argKey == "RoleTaiwu")
		{
			return ExternalDataBridge.Context.TaiwuCharId;
		}
		int charId = -1;
		if (!argBox.Get(argKey, ref charId))
		{
			return -1;
		}
		return charId;
	}

	private Location GetLocationFromArgBox(IVariantCollection<string> argBox, string argKey)
	{
		if (argKey == "TaiwuLocation")
		{
			return ExternalDataBridge.Context.TaiwuLocation;
		}
		if (!argBox.Get(argKey, out Location location))
		{
			return Location.Invalid;
		}
		return location;
	}

	public unsafe override void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
		string keyPrefix = "MonthlyEvent_arg";
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			string[] parameters = Config.MonthlyEvent.Instance[recordType].Parameters;
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				ReadArgumentToEventArgBox(keyPrefix, i, paramType, &pCurrData, eventArgBox);
			}
		}
	}
}
