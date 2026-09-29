using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.World.TravelingEvent;

public class TravelingEventCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<TravelingEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			TravelingEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
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

	public new unsafe TravelingEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			TravelingEventItem config = Config.TravelingEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			TravelingEventRenderInfo info = new TravelingEventRenderInfo(recordType, config.Desc, offset);
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

	public int AddJingjiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingjiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingjiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHealOuterInjury(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHealInnerInjury(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHealPoison(int charId, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHealDisorderOfQi(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHealLifeSpan(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFriendResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFriendFood(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFriendTeaWine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFriendMedicine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFameResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFameFood(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFameTeaWine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFameMedicine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverStrength(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverDexterity(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverConcentration(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverVitality(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverEnergy(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecoverIntelligence(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAreaInteractGood(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAreaInteractNormal(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAreaInteractBad(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAreaInteractIgnored(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingjiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAreaSpiritualDebtIgnored(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTravelBattlePerfectWin(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTravelBattleWin(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTravelBattleLose(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGroupMemberAccept(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGroupMemberRefuse(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGroupMemberIgnored(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeStrengthSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeDexteritySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeConcentrationSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeVitalitySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeEnergySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeIntelligenceSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddNoConsumeMainAttribute(int charId)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRoadBlockAndDetour(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRoadBlockAndIgnore(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingjiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingjiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBashuAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingBeiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShanxiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGuangdongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShandongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFujianAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLiaodongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiyuAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYunnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddHuainanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJiangbeiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitShaolin(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitEmei(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitBaihua(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitWudang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitYuanshan(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitShixiang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitRanshan(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitXuannv(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitZhujian(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitKongsang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitJingang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitWuxian(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitJieqing(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitFulong(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVisitXuehou(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddEnemyAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRighteousAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXiangshuMinionAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddShaolinAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddEmeiAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBaihuaAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddWudangAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddYuanshanAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJingangAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddWuxianAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddJieqingAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFulongAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddXuehouAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFriendGroupMember(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFameGroupMember(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeStrength(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeDexterity(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeConcentration(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeVitality(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeEnergy(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConsumeIntelligence(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRoadBlock(int charId)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public unsafe override void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
		string keyPrefix = "TravelingEvent_arg";
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			string[] parameters = Config.TravelingEvent.Instance[recordType].Parameters;
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

	public void CheckParameters(short templateId, params string[] parameters)
	{
		string[] configParams = Config.TravelingEvent.Instance[templateId].Parameters;
		for (int i = 0; i < configParams.Length; i++)
		{
			if (parameters.Length <= i)
			{
				Tester.Assert(string.IsNullOrEmpty(configParams[i]));
			}
			else
			{
				Tester.Assert(configParams[i] == parameters[i]);
			}
		}
	}

	public int AddType_AreaMaterial(short templateId, int charId, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaMaterial);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_AreaResource(short templateId, int charId, int value, sbyte resourceType)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaResource);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_AreaFood(short templateId, int charId, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaFood);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_CharacterGiftResource(short templateId, int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterGiftResource);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_CharacterGiftItem(short templateId, int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterGiftItem);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_AttributeRegen(short templateId, int charId, Location location, int value)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AttributeRegen);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_AreaInteraction(short templateId, int charId, Location location, int charId1)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaInteraction);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_SpiritualDebt(short templateId, int charId, short settlementId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SpiritualDebt);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_SectVisit(short templateId, int charId, Location location)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SectVisit);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_Combat(short templateId, int charId, short charTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.Combat);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_SectCombat(short templateId, int charId, short charTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SectCombat);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_CharacterRecommendVillager(short templateId, int charId, Location location, int charId1, int charId2)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterRecommendVillager);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddType_AttributeCost(short templateId, int charId, int value)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AttributeCost);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
