using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFaceElementScoreItem : ConfigItem<AvatarFaceElementScoreItem, short>
{
	public readonly short TemplateId;

	public readonly int AngleScore;

	public readonly int ScaleScore;

	public readonly int AdjustWeight;

	public readonly int HeightScore;

	public readonly int DistanceScore;

	public AvatarFaceElementScoreItem(short templateId, int angleScore, int scaleScore, int adjustWeight, int heightScore, int distanceScore)
	{
		TemplateId = templateId;
		AngleScore = angleScore;
		ScaleScore = scaleScore;
		AdjustWeight = adjustWeight;
		HeightScore = heightScore;
		DistanceScore = distanceScore;
	}

	public AvatarFaceElementScoreItem()
	{
		TemplateId = 0;
		AngleScore = 0;
		ScaleScore = 0;
		AdjustWeight = 0;
		HeightScore = 0;
		DistanceScore = 0;
	}

	public AvatarFaceElementScoreItem(short templateId, AvatarFaceElementScoreItem other)
	{
		TemplateId = templateId;
		AngleScore = other.AngleScore;
		ScaleScore = other.ScaleScore;
		AdjustWeight = other.AdjustWeight;
		HeightScore = other.HeightScore;
		DistanceScore = other.DistanceScore;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AvatarFaceElementScoreItem Duplicate(int templateId)
	{
		return new AvatarFaceElementScoreItem((short)templateId, this);
	}
}
