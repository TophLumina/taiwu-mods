using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFaceElementScoreItem : ConfigItem<AvatarFaceElementScoreItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 角度总分
	/// </summary>
	public readonly int AngleScore;

	/// <summary>
	/// 大小总分
	/// </summary>
	public readonly int ScaleScore;

	/// <summary>
	/// 修正强度
	/// </summary>
	public readonly int AdjustWeight;

	/// <summary>
	/// 高度总分
	/// </summary>
	public readonly int HeightScore;

	/// <summary>
	/// 间距总分
	/// </summary>
	public readonly int DistanceScore;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="angleScore">角度总分</param>
	/// <param name="scaleScore">大小总分</param>
	/// <param name="adjustWeight">修正强度</param>
	/// <param name="heightScore">高度总分</param>
	/// <param name="distanceScore">间距总分</param>
	public AvatarFaceElementScoreItem(short templateId, int angleScore, int scaleScore, int adjustWeight, int heightScore, int distanceScore)
	{
		TemplateId = templateId;
		AngleScore = angleScore;
		ScaleScore = scaleScore;
		AdjustWeight = adjustWeight;
		HeightScore = heightScore;
		DistanceScore = distanceScore;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AvatarFaceElementScoreItem()
	{
		TemplateId = 0;
		AngleScore = 0;
		ScaleScore = 0;
		AdjustWeight = 0;
		HeightScore = 0;
		DistanceScore = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarFaceElementScoreItem Duplicate(int templateId)
	{
		return new AvatarFaceElementScoreItem((short)templateId, this);
	}
}
