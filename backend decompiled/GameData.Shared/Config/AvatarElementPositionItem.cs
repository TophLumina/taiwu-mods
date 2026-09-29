using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarElementPositionItem : ConfigItem<AvatarElementPositionItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly float[] LeftEye;

	public readonly float[] RightEye;

	public readonly float[] LeftBrow;

	public readonly float[] RightBrow;

	public readonly float[] Nose;

	public readonly float[] Mouth;

	public readonly float[] UpperBeard;

	public readonly float[] LowerBeard;

	public readonly float[] FrontHair;

	public readonly float[] BackHair;

	public readonly float[] PositiveFeature;

	public readonly float[] NegativeFeature;

	public readonly float[] HeadBodyOffset;

	public readonly float[] EyeDistanceRange;

	public readonly float[] EyeHeightRange;

	public readonly float[] EyeScaleRange;

	public readonly float[] EyeAngleRange;

	public readonly float[] EyebrowDistanceRange;

	public readonly float[] EyebrowHeightRange;

	public readonly float[] EyebrowScaleRange;

	public readonly float[] EyebrowAngleRange;

	public readonly float[] NoseHeightRange;

	public readonly float[] NoseScaleRange;

	public readonly float[] MouthHeightRange;

	public readonly float[] MouthScaleRange;

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

	public override AvatarElementPositionItem Duplicate(int templateId)
	{
		return new AvatarElementPositionItem((sbyte)templateId, this);
	}
}
