using System;
using Config.Common;

namespace Config;

[Serializable]
public class TravelSkeletonItem : ConfigItem<TravelSkeletonItem, short>
{
	public readonly short TemplateId;

	public readonly string Animation;

	public readonly string AnimationIdle;

	public readonly string SubAnimation;

	public readonly string SubAnimationIdle;

	public readonly string SimpleAnimation;

	public readonly string ComplexAnimation;

	public readonly bool AnyCarrier;

	public readonly string CarrierAnimation;

	public readonly string CarrierAnimationIdle;

	public readonly string CarrierAnimationSkin;

	public readonly string CarrierAnimationPath;

	public readonly string Sound;

	public readonly float Size;

	public readonly float DeltaX;

	public readonly float DeltaY;

	public TravelSkeletonItem(short templateId, string animation, string animationIdle, string subAnimation, string subAnimationIdle, string simpleAnimation, string complexAnimation, bool anyCarrier, string carrierAnimation, string carrierAnimationIdle, string carrierAnimationSkin, string carrierAnimationPath, string sound, float size, float deltaX, float deltaY)
	{
		TemplateId = templateId;
		Animation = animation;
		AnimationIdle = animationIdle;
		SubAnimation = subAnimation;
		SubAnimationIdle = subAnimationIdle;
		SimpleAnimation = simpleAnimation;
		ComplexAnimation = complexAnimation;
		AnyCarrier = anyCarrier;
		CarrierAnimation = carrierAnimation;
		CarrierAnimationIdle = carrierAnimationIdle;
		CarrierAnimationSkin = carrierAnimationSkin;
		CarrierAnimationPath = carrierAnimationPath;
		Sound = sound;
		Size = size;
		DeltaX = deltaX;
		DeltaY = deltaY;
	}

	public TravelSkeletonItem()
	{
		TemplateId = 0;
		Animation = null;
		AnimationIdle = null;
		SubAnimation = null;
		SubAnimationIdle = null;
		SimpleAnimation = null;
		ComplexAnimation = null;
		AnyCarrier = true;
		CarrierAnimation = null;
		CarrierAnimationIdle = null;
		CarrierAnimationSkin = "default";
		CarrierAnimationPath = null;
		Sound = null;
		Size = 0.5f;
		DeltaX = 0f;
		DeltaY = 0f;
	}

	public TravelSkeletonItem(short templateId, TravelSkeletonItem other)
	{
		TemplateId = templateId;
		Animation = other.Animation;
		AnimationIdle = other.AnimationIdle;
		SubAnimation = other.SubAnimation;
		SubAnimationIdle = other.SubAnimationIdle;
		SimpleAnimation = other.SimpleAnimation;
		ComplexAnimation = other.ComplexAnimation;
		AnyCarrier = other.AnyCarrier;
		CarrierAnimation = other.CarrierAnimation;
		CarrierAnimationIdle = other.CarrierAnimationIdle;
		CarrierAnimationSkin = other.CarrierAnimationSkin;
		CarrierAnimationPath = other.CarrierAnimationPath;
		Sound = other.Sound;
		Size = other.Size;
		DeltaX = other.DeltaX;
		DeltaY = other.DeltaY;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TravelSkeletonItem Duplicate(int templateId)
	{
		return new TravelSkeletonItem((short)templateId, this);
	}
}
