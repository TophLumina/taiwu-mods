using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Organization.SettlementPrisonRecord;

public class SettlementPrisonRecordCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<SettlementPrisonRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SettlementPrisonRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
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

	public new unsafe SettlementPrisonRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
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
			SettlementPrisonRecordItem config = Config.SettlementPrisonRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SettlementPrisonRecordRenderInfo info = new SettlementPrisonRecordRenderInfo(recordType, config.Desc, date, settlementId);
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

	public int AddIntrudePrison(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 0);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddIntrudePrisonAndSentToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 1);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddIntrudePrisonAndPrisonRobbery(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 2);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSendingToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 3);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPrisonRobbery(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 4);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPrisonBail(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 5);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddImprisonedVoluntarily(int date, short settlementId, int charId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 6);
		AppendCharacter(charId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddImprisonedByArrested(int date, short settlementId, int charId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 7);
		AppendCharacter(charId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBeReleasedUponCompletionOfASentence(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 8);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPrisonBreak(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 9);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSentToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 10);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPrisonerBeReleaseByAristocrat(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 11);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
