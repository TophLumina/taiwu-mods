using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeRecordItem : ConfigItem<LifeRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly bool IsSourceRecord;

	public readonly List<short> RelatedIds;

	public readonly short RequiredFavorability;

	public readonly ELifeRecordScoreType ScoreType;

	public readonly short Score;

	public readonly sbyte DreamBackEventPriority;

	public readonly ELifeRecordDisplayType DisplayType;

	public LifeRecordItem(short templateId, string name, string desc, string[] parameters, bool isSourceRecord, List<short> relatedIds, short requiredFavorability, ELifeRecordScoreType scoreType, short score, sbyte dreamBackEventPriority, ELifeRecordDisplayType displayType)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		IsSourceRecord = isSourceRecord;
		RelatedIds = relatedIds;
		RequiredFavorability = requiredFavorability;
		ScoreType = scoreType;
		Score = score;
		DreamBackEventPriority = dreamBackEventPriority;
		DisplayType = displayType;
	}

	public LifeRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
		IsSourceRecord = true;
		RelatedIds = new List<short>();
		RequiredFavorability = -30000;
		ScoreType = ELifeRecordScoreType.Invalid;
		Score = -1;
		DreamBackEventPriority = -1;
		DisplayType = ELifeRecordDisplayType.NoCategory;
	}

	public LifeRecordItem(short templateId, LifeRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		IsSourceRecord = other.IsSourceRecord;
		RelatedIds = other.RelatedIds;
		RequiredFavorability = other.RequiredFavorability;
		ScoreType = other.ScoreType;
		Score = other.Score;
		DreamBackEventPriority = other.DreamBackEventPriority;
		DisplayType = other.DisplayType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LifeRecordItem Duplicate(int templateId)
	{
		return new LifeRecordItem((short)templateId, this);
	}

	public bool CheckParameterCount(int count)
	{
		if (count == 0 || !string.IsNullOrEmpty(Parameters[count - 1]))
		{
			if (count != Parameters.Length)
			{
				return string.IsNullOrEmpty(Parameters[count]);
			}
			return true;
		}
		return false;
	}
}
