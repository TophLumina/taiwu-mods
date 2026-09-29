using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHeadItem : ConfigItem<AvatarHeadItem, byte>
{
	public readonly byte TemplateId;

	public readonly byte HeadId;

	public readonly byte AvatarId;

	public readonly string DisplayDesc;

	public readonly string NameOrPath;

	public readonly short SkeletonHeadBodyOffset;

	public readonly byte EyesMinDistance;

	public readonly short EyesXmin;

	public readonly short EyesXmax;

	public readonly short EyesYmin;

	public readonly short EyesYmax;

	public readonly short MouthYmin;

	public readonly short MouthYmax;

	public readonly short RelativeExtraPart;

	public readonly bool CanRandom;

	public AvatarHeadItem(byte templateId, byte headId, byte avatarId, string displayDesc, string nameOrPath, short skeletonHeadBodyOffset, byte eyesMinDistance, short eyesXmin, short eyesXmax, short eyesYmin, short eyesYmax, short mouthYmin, short mouthYmax, short relativeExtraPart, bool canRandom)
	{
		TemplateId = templateId;
		HeadId = headId;
		AvatarId = avatarId;
		DisplayDesc = displayDesc;
		NameOrPath = nameOrPath;
		SkeletonHeadBodyOffset = skeletonHeadBodyOffset;
		EyesMinDistance = eyesMinDistance;
		EyesXmin = eyesXmin;
		EyesXmax = eyesXmax;
		EyesYmin = eyesYmin;
		EyesYmax = eyesYmax;
		MouthYmin = mouthYmin;
		MouthYmax = mouthYmax;
		RelativeExtraPart = relativeExtraPart;
		CanRandom = canRandom;
	}

	public AvatarHeadItem()
	{
		TemplateId = 0;
		HeadId = 0;
		AvatarId = 0;
		DisplayDesc = null;
		NameOrPath = null;
		SkeletonHeadBodyOffset = 0;
		EyesMinDistance = 0;
		EyesXmin = 0;
		EyesXmax = 0;
		EyesYmin = 0;
		EyesYmax = 0;
		MouthYmin = 0;
		MouthYmax = 0;
		RelativeExtraPart = 0;
		CanRandom = false;
	}

	public AvatarHeadItem(byte templateId, AvatarHeadItem other)
	{
		TemplateId = templateId;
		HeadId = other.HeadId;
		AvatarId = other.AvatarId;
		DisplayDesc = other.DisplayDesc;
		NameOrPath = other.NameOrPath;
		SkeletonHeadBodyOffset = other.SkeletonHeadBodyOffset;
		EyesMinDistance = other.EyesMinDistance;
		EyesXmin = other.EyesXmin;
		EyesXmax = other.EyesXmax;
		EyesYmin = other.EyesYmin;
		EyesYmax = other.EyesYmax;
		MouthYmin = other.MouthYmin;
		MouthYmax = other.MouthYmax;
		RelativeExtraPart = other.RelativeExtraPart;
		CanRandom = other.CanRandom;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AvatarHeadItem Duplicate(int templateId)
	{
		return new AvatarHeadItem((byte)templateId, this);
	}
}
