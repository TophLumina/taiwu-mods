using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPointItem : ConfigItem<LegacyPointItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Type;

	public readonly short BasePoint;

	public readonly int MaxPoint;

	public readonly bool IsHidden;

	public readonly byte[] BonusTypes;

	public readonly string ConditionDesc;

	public LegacyPointItem(short templateId, string name, sbyte type, short basePoint, int maxPoint, bool isHidden, byte[] bonusTypes, string conditionDesc)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		BasePoint = basePoint;
		MaxPoint = maxPoint;
		IsHidden = isHidden;
		BonusTypes = bonusTypes;
		ConditionDesc = conditionDesc;
	}

	public LegacyPointItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		BasePoint = -1;
		MaxPoint = -1;
		IsHidden = false;
		BonusTypes = new byte[0];
		ConditionDesc = null;
	}

	public LegacyPointItem(short templateId, LegacyPointItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		BasePoint = other.BasePoint;
		MaxPoint = other.MaxPoint;
		IsHidden = other.IsHidden;
		BonusTypes = other.BonusTypes;
		ConditionDesc = other.ConditionDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LegacyPointItem Duplicate(int templateId)
	{
		return new LegacyPointItem((short)templateId, this);
	}
}
