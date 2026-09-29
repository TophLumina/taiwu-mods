using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Organization.SettlementTreasuryRecord;

public class SettlementTreasuryRecordCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<SettlementTreasuryRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SettlementTreasuryRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
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
			return ((short*)(pRawData + offset + 1))[2];
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	public new unsafe SettlementTreasuryRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short settlementId = *(short*)pCurrData;
			pCurrData += 2;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			SettlementTreasuryRecordItem config = Config.SettlementTreasuryRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SettlementTreasuryRecordRenderInfo info = new SettlementTreasuryRecordRenderInfo(recordType, config.Desc, date, settlementId);
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

	private unsafe int BeginAddingRecord(int date, short settlementId, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = settlementId;
			((short*)(num + 1 + 4))[1] = recordType;
		}
		return offset;
	}

	public int AddSupplementResource(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 0);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSupplementItem(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStorageResource(int date, short settlementId, int charId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 2);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStorageItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 3);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTakeOutResource(int date, short settlementId, int charId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 4);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTakeOutItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTaiwuStorageResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 6);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTaiwuStorageItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTaiwuTakeOutResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 8);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTaiwuTakeOutItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDonateSectTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 10);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDonateTownTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 11);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddIntrudeSectTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddIntrudeTownTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPlunderSectTreasurySuccess(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 14);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPlunderTownTreasurySuccess(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 15);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPlunderSectTreasuryFail(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 16);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPlunderTownTreasuryFail(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 17);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConfiscateResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 18);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddConfiscateItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 19);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDistributeItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 20);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddClearRecord(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 21);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDistributeResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 22);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSectStoryFulongLooting(int date, short settlementId, sbyte resourceType, int value, sbyte resourceType1, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 23);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendResource(resourceType1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDonateLegacy(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
