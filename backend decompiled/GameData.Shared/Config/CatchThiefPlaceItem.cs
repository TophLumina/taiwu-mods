using System;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefPlaceItem : ConfigItem<CatchThiefPlaceItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte Rate;

	public readonly int[][] LevelWeights;

	public readonly string Icon;

	public readonly string CatchAniBack;

	public CatchThiefPlaceItem(sbyte templateId, sbyte rate, int[][] levelWeights, string icon, string catchAniBack)
	{
		TemplateId = templateId;
		Rate = rate;
		LevelWeights = levelWeights;
		Icon = icon;
		CatchAniBack = catchAniBack;
	}

	public CatchThiefPlaceItem()
	{
		TemplateId = 0;
		Rate = 0;
		LevelWeights = null;
		Icon = null;
		CatchAniBack = null;
	}

	public CatchThiefPlaceItem(sbyte templateId, CatchThiefPlaceItem other)
	{
		TemplateId = templateId;
		Rate = other.Rate;
		LevelWeights = other.LevelWeights;
		Icon = other.Icon;
		CatchAniBack = other.CatchAniBack;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CatchThiefPlaceItem Duplicate(int templateId)
	{
		return new CatchThiefPlaceItem((sbyte)templateId, this);
	}
}
