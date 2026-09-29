using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Building.SamsaraPlatformRecord;

public class SamsaraPlatformRecordCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<SamsaraPlatformRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SamsaraPlatformRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
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

	public new unsafe SamsaraPlatformRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			SamsaraPlatformRecordItem config = Config.SamsaraPlatformRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SamsaraPlatformRecordRenderInfo info = new SamsaraPlatformRecordRenderInfo(recordType, config.Desc, date);
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

	private unsafe int BeginAddingRecord(int date, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = recordType;
		}
		return offset;
	}

	public int AddSamsaraSuccess(int date, int charId, sbyte destinyType, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendCharacter(charId);
		AppendDestinyType(destinyType);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSamsaraFailed(int date, int charId, sbyte destinyType)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendCharacter(charId);
		AppendDestinyType(destinyType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
