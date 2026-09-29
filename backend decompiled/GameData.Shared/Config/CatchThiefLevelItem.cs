using System;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefLevelItem : ConfigItem<CatchThiefLevelItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Desc;

	public readonly sbyte Level;

	public readonly sbyte SingPitch;

	public readonly short SingSize;

	public CatchThiefLevelItem(sbyte templateId, string desc, sbyte level, sbyte singPitch, short singSize)
	{
		TemplateId = templateId;
		Desc = desc;
		Level = level;
		SingPitch = singPitch;
		SingSize = singSize;
	}

	public CatchThiefLevelItem()
	{
		TemplateId = 0;
		Desc = null;
		Level = 0;
		SingPitch = 0;
		SingSize = 0;
	}

	public CatchThiefLevelItem(sbyte templateId, CatchThiefLevelItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Level = other.Level;
		SingPitch = other.SingPitch;
		SingSize = other.SingSize;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CatchThiefLevelItem Duplicate(int templateId)
	{
		return new CatchThiefLevelItem((sbyte)templateId, this);
	}
}
