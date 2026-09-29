using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord;

public class ReadonlyLifeRecords : ReadonlyRecordCollection
{
	public unsafe void GetPartialLifeRecords(int startDate, int monthCount, ref ReadonlyLifeRecords readonlyLifeRecords)
	{
		if (readonlyLifeRecords == null)
		{
			readonlyLifeRecords = new ReadonlyLifeRecords();
		}
		int index = -1;
		int offset = -1;
		int endDate = startDate + monthCount;
		int beginOffset = -1;
		int endOffset = -1;
		int beginIndex = -1;
		int endIndex = -1;
		while (Next(ref index, ref offset))
		{
			int recordDate = GetDate(offset);
			if (beginOffset < 0 && recordDate >= startDate)
			{
				beginOffset = offset;
				beginIndex = index;
			}
			if (recordDate > endDate)
			{
				endOffset = offset;
				endIndex = index;
				break;
			}
		}
		int size = endOffset - beginOffset;
		readonlyLifeRecords.EnsureCapacity(size);
		fixed (byte* pSrc = RawData)
		{
			fixed (byte* pDst = readonlyLifeRecords.RawData)
			{
				Buffer.MemoryCopy(pSrc + beginOffset, pDst, size, size);
			}
		}
		readonlyLifeRecords.Count = endIndex - beginIndex;
		readonlyLifeRecords.Size = size;
	}

	public void GetRenderInfos(List<LifeRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			LifeRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public (int, int[]) GetRenderInfosOfDates(List<LifeRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection, int startDate, int monthCount)
	{
		int index = -1;
		int offset = -1;
		int totalScoreCount = 0;
		int totalScore = 0;
		int averageScore = int.MaxValue;
		int endDate = startDate + monthCount - 1;
		int[] monthScores = new int[monthCount];
		for (int i = 0; i < monthCount; i++)
		{
			monthScores[i] = 50;
		}
		int currMonthScoreCount = 0;
		int currMonthTotalScore = 0;
		int currMonthAverageScore = int.MaxValue;
		int currDate = startDate;
		while (Next(ref index, ref offset))
		{
			int recordDate = GetDate(offset);
			if (recordDate < startDate)
			{
				continue;
			}
			if (recordDate > endDate)
			{
				break;
			}
			LifeRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo == null)
			{
				continue;
			}
			renderInfos.Add(renderInfo);
			if (currDate != recordDate)
			{
				if (currMonthAverageScore == int.MaxValue)
				{
					currMonthAverageScore = ((currMonthScoreCount > 0) ? (currMonthTotalScore / currMonthScoreCount) : 50);
				}
				monthScores[currDate - startDate] = currMonthAverageScore;
				currMonthTotalScore = 0;
				currMonthScoreCount = 0;
				currMonthAverageScore = int.MaxValue;
				currDate = recordDate;
			}
			LifeRecordItem recordCfg = Config.LifeRecord.Instance[renderInfo.RecordType];
			switch (recordCfg.ScoreType)
			{
			case ELifeRecordScoreType.Normal:
				renderInfo.Score = recordCfg.Score;
				break;
			case ELifeRecordScoreType.Absolute:
				renderInfo.Score = recordCfg.Score;
				averageScore = ((averageScore > recordCfg.Score) ? recordCfg.Score : averageScore);
				currMonthAverageScore = ((currMonthAverageScore > recordCfg.Score) ? recordCfg.Score : currMonthAverageScore);
				break;
			case ELifeRecordScoreType.Calculated:
				renderInfo.Score = 50;
				break;
			}
			if (renderInfo.Score != 50)
			{
				totalScore += renderInfo.Score;
				totalScoreCount++;
				currMonthTotalScore += renderInfo.Score;
				currMonthScoreCount++;
			}
		}
		if (currMonthTotalScore > 0)
		{
			if (currMonthAverageScore == int.MaxValue)
			{
				currMonthAverageScore = ((currMonthScoreCount > 0) ? (currMonthTotalScore / currMonthScoreCount) : 50);
			}
			monthScores[currDate - startDate] = currMonthAverageScore;
		}
		if (averageScore == int.MaxValue)
		{
			averageScore = ((totalScoreCount > 0) ? (totalScore / totalScoreCount) : 50);
		}
		return (averageScore, monthScores);
	}

	private int GetCalculatedLifeRecordScore(LifeRecordRenderInfo renderInfo, ArgumentCollection argumentCollection)
	{
		switch (renderInfo.RecordType)
		{
		case 16:
			var (itemType3, templateId7) = argumentCollection.Items[renderInfo.Arguments[1].index];
			return 50 + (ItemTemplateHelper.GetGrade(itemType3, templateId7) + 1) * 3;
		case 17:
			var (itemType2, templateId6) = argumentCollection.Items[renderInfo.Arguments[1].index];
			return 50 - (ItemTemplateHelper.GetGrade(itemType2, templateId6) + 1) * 3;
		case 18:
		{
			short templateId5 = argumentCollection.CombatSkills[renderInfo.Arguments[1].index];
			return 50 + (Config.CombatSkill.Instance[templateId5].Grade + 1) * 3;
		}
		case 19:
		{
			short templateId4 = argumentCollection.CombatSkills[renderInfo.Arguments[1].index];
			return 50 - (Config.CombatSkill.Instance[templateId4].Grade + 1) * 3;
		}
		case 20:
		{
			short templateId3 = argumentCollection.CombatSkills[renderInfo.Arguments[1].index];
			return 50 + (Config.CombatSkill.Instance[templateId3].Grade + 1) * 3;
		}
		case 21:
		{
			short templateId2 = argumentCollection.LifeSkills[renderInfo.Arguments[1].index];
			return 50 + (LifeSkill.Instance[templateId2].Grade + 1) * 3;
		}
		case 81:
		case 83:
			var (itemType, templateId) = argumentCollection.Items[renderInfo.Arguments[1].index];
			return 50 + (ItemTemplateHelper.GetGrade(itemType, templateId) + 1) * 3;
		default:
			return 50;
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	public new unsafe LifeRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int date = *(int*)(pCurrData + 1);
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			LifeRecordItem config = Config.LifeRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = GetParameters(config);
			LifeRecordRenderInfo info = new LifeRecordRenderInfo(recordType, config.Desc, date);
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

	public unsafe (int, short) GetDreamBackRelatedCharacterId(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			LifeRecordItem config = Config.LifeRecord.Instance[recordType];
			if (config == null || config.DreamBackEventPriority < 0)
			{
				return (-1, recordType);
			}
			Tester.Assert(ParameterType.Parse(GetParameters(config)[0]) == 0);
			return (*(int*)pCurrData, recordType);
		}
	}

	private static string[] GetParameters(LifeRecordItem config)
	{
		if (config.IsSourceRecord)
		{
			return config.Parameters;
		}
		short relatedTemplateId = config.RelatedIds[0];
		return Config.LifeRecord.Instance[relatedTemplateId].Parameters;
	}

	public TransferableLifeRecordData IntoData()
	{
		TransferableLifeRecordData data = new TransferableLifeRecordData();
		ReadData(data, GetParametersByTemplateId);
		return data;
	}

	public static string[] GetParametersByTemplateId(int recordType)
	{
		LifeRecordItem config = Config.LifeRecord.Instance[recordType];
		if (config != null)
		{
			return GetParameters(config) ?? Array.Empty<string>();
		}
		AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
		return null;
	}
}
