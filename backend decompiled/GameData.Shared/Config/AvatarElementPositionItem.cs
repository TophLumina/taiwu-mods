using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarElementPositionItem : ConfigItem<AvatarElementPositionItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 左眼
	/// </summary>
	public readonly float[] LeftEye;

	/// <summary>
	/// 右眼
	/// </summary>
	public readonly float[] RightEye;

	/// <summary>
	/// 左眉毛
	/// </summary>
	public readonly float[] LeftBrow;

	/// <summary>
	/// 右眉毛
	/// </summary>
	public readonly float[] RightBrow;

	/// <summary>
	/// 鼻子
	/// </summary>
	public readonly float[] Nose;

	/// <summary>
	/// 嘴巴
	/// </summary>
	public readonly float[] Mouth;

	/// <summary>
	/// 上胡须
	/// </summary>
	public readonly float[] UpperBeard;

	/// <summary>
	/// 下胡须
	/// </summary>
	public readonly float[] LowerBeard;

	/// <summary>
	/// 前发
	/// </summary>
	public readonly float[] FrontHair;

	/// <summary>
	/// 后发
	/// </summary>
	public readonly float[] BackHair;

	/// <summary>
	/// 正面特性
	/// </summary>
	public readonly float[] PositiveFeature;

	/// <summary>
	/// 负面特性
	/// </summary>
	public readonly float[] NegativeFeature;

	/// <summary>
	/// 头部与身体
	/// </summary>
	public readonly float[] HeadBodyOffset;

	/// <summary>
	/// 眼睛间距范围
	/// - {最小值,阈值,阈值,最大值}
	/// </summary>
	public readonly float[] EyeDistanceRange;

	/// <summary>
	/// 眼睛高度范围
	/// </summary>
	public readonly float[] EyeHeightRange;

	/// <summary>
	/// 眼睛缩放范围
	/// </summary>
	public readonly float[] EyeScaleRange;

	/// <summary>
	/// 眼睛角度范围
	/// </summary>
	public readonly float[] EyeAngleRange;

	/// <summary>
	/// 眉毛间距范围
	/// </summary>
	public readonly float[] EyebrowDistanceRange;

	/// <summary>
	/// 眉毛高度范围
	/// </summary>
	public readonly float[] EyebrowHeightRange;

	/// <summary>
	/// 眉毛缩放范围
	/// </summary>
	public readonly float[] EyebrowScaleRange;

	/// <summary>
	/// 眉毛角度范围
	/// </summary>
	public readonly float[] EyebrowAngleRange;

	/// <summary>
	/// 鼻子高度范围
	/// </summary>
	public readonly float[] NoseHeightRange;

	/// <summary>
	/// 鼻子缩放范围
	/// </summary>
	public readonly float[] NoseScaleRange;

	/// <summary>
	/// 嘴巴高度范围
	/// </summary>
	public readonly float[] MouthHeightRange;

	/// <summary>
	/// 嘴巴缩放范围
	/// </summary>
	public readonly float[] MouthScaleRange;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="leftEye">左眼</param>
	/// <param name="rightEye">右眼</param>
	/// <param name="leftBrow">左眉毛</param>
	/// <param name="rightBrow">右眉毛</param>
	/// <param name="nose">鼻子</param>
	/// <param name="mouth">嘴巴</param>
	/// <param name="upperBeard">上胡须</param>
	/// <param name="lowerBeard">下胡须</param>
	/// <param name="frontHair">前发</param>
	/// <param name="backHair">后发</param>
	/// <param name="positiveFeature">正面特性</param>
	/// <param name="negativeFeature">负面特性</param>
	/// <param name="headBodyOffset">头部与身体</param>
	/// <param name="eyeDistanceRange">眼睛间距范围 - {最小值,阈值,阈值,最大值}</param>
	/// <param name="eyeHeightRange">眼睛高度范围</param>
	/// <param name="eyeScaleRange">眼睛缩放范围</param>
	/// <param name="eyeAngleRange">眼睛角度范围</param>
	/// <param name="eyebrowDistanceRange">眉毛间距范围</param>
	/// <param name="eyebrowHeightRange">眉毛高度范围</param>
	/// <param name="eyebrowScaleRange">眉毛缩放范围</param>
	/// <param name="eyebrowAngleRange">眉毛角度范围</param>
	/// <param name="noseHeightRange">鼻子高度范围</param>
	/// <param name="noseScaleRange">鼻子缩放范围</param>
	/// <param name="mouthHeightRange">嘴巴高度范围</param>
	/// <param name="mouthScaleRange">嘴巴缩放范围</param>
	public AvatarElementPositionItem(sbyte templateId, float[] leftEye, float[] rightEye, float[] leftBrow, float[] rightBrow, float[] nose, float[] mouth, float[] upperBeard, float[] lowerBeard, float[] frontHair, float[] backHair, float[] positiveFeature, float[] negativeFeature, float[] headBodyOffset, float[] eyeDistanceRange, float[] eyeHeightRange, float[] eyeScaleRange, float[] eyeAngleRange, float[] eyebrowDistanceRange, float[] eyebrowHeightRange, float[] eyebrowScaleRange, float[] eyebrowAngleRange, float[] noseHeightRange, float[] noseScaleRange, float[] mouthHeightRange, float[] mouthScaleRange)
	{
		TemplateId = templateId;
		LeftEye = leftEye;
		RightEye = rightEye;
		LeftBrow = leftBrow;
		RightBrow = rightBrow;
		Nose = nose;
		Mouth = mouth;
		UpperBeard = upperBeard;
		LowerBeard = lowerBeard;
		FrontHair = frontHair;
		BackHair = backHair;
		PositiveFeature = positiveFeature;
		NegativeFeature = negativeFeature;
		HeadBodyOffset = headBodyOffset;
		EyeDistanceRange = eyeDistanceRange;
		EyeHeightRange = eyeHeightRange;
		EyeScaleRange = eyeScaleRange;
		EyeAngleRange = eyeAngleRange;
		EyebrowDistanceRange = eyebrowDistanceRange;
		EyebrowHeightRange = eyebrowHeightRange;
		EyebrowScaleRange = eyebrowScaleRange;
		EyebrowAngleRange = eyebrowAngleRange;
		NoseHeightRange = noseHeightRange;
		NoseScaleRange = noseScaleRange;
		MouthHeightRange = mouthHeightRange;
		MouthScaleRange = mouthScaleRange;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AvatarElementPositionItem()
	{
		TemplateId = 0;
		LeftEye = new float[2];
		RightEye = new float[2];
		LeftBrow = new float[2];
		RightBrow = new float[2];
		Nose = new float[2];
		Mouth = new float[2];
		UpperBeard = new float[2];
		LowerBeard = new float[2];
		FrontHair = new float[2];
		BackHair = new float[2];
		PositiveFeature = new float[2];
		NegativeFeature = new float[2];
		HeadBodyOffset = new float[2];
		EyeDistanceRange = new float[4];
		EyeHeightRange = new float[4];
		EyeScaleRange = new float[4];
		EyeAngleRange = new float[4];
		EyebrowDistanceRange = new float[4];
		EyebrowHeightRange = new float[4];
		EyebrowScaleRange = new float[4];
		EyebrowAngleRange = new float[4];
		NoseHeightRange = new float[4];
		NoseScaleRange = new float[4];
		MouthHeightRange = new float[4];
		MouthScaleRange = new float[4];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AvatarElementPositionItem(sbyte templateId, AvatarElementPositionItem other)
	{
		TemplateId = templateId;
		LeftEye = other.LeftEye;
		RightEye = other.RightEye;
		LeftBrow = other.LeftBrow;
		RightBrow = other.RightBrow;
		Nose = other.Nose;
		Mouth = other.Mouth;
		UpperBeard = other.UpperBeard;
		LowerBeard = other.LowerBeard;
		FrontHair = other.FrontHair;
		BackHair = other.BackHair;
		PositiveFeature = other.PositiveFeature;
		NegativeFeature = other.NegativeFeature;
		HeadBodyOffset = other.HeadBodyOffset;
		EyeDistanceRange = other.EyeDistanceRange;
		EyeHeightRange = other.EyeHeightRange;
		EyeScaleRange = other.EyeScaleRange;
		EyeAngleRange = other.EyeAngleRange;
		EyebrowDistanceRange = other.EyebrowDistanceRange;
		EyebrowHeightRange = other.EyebrowHeightRange;
		EyebrowScaleRange = other.EyebrowScaleRange;
		EyebrowAngleRange = other.EyebrowAngleRange;
		NoseHeightRange = other.NoseHeightRange;
		NoseScaleRange = other.NoseScaleRange;
		MouthHeightRange = other.MouthHeightRange;
		MouthScaleRange = other.MouthScaleRange;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarElementPositionItem Duplicate(int templateId)
	{
		return new AvatarElementPositionItem((sbyte)templateId, this);
	}
}
