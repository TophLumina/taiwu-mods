using System;
using Config.Common;

namespace Config;

[Serializable]
public class TravelSkeletonItem : ConfigItem<TravelSkeletonItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 人物动画
	/// - 角色、代步、圆盘等共用名称
	/// </summary>
	public readonly string Animation;

	/// <summary>
	/// 人物静止动画
	/// </summary>
	public readonly string AnimationIdle;

	/// <summary>
	/// 附属人物动画
	/// - 目前仅用于捕快骨骼使用的动画，后续如有多角色旅行需求可再补充支持
	/// </summary>
	public readonly string SubAnimation;

	/// <summary>
	/// 附属人物静止动画
	/// </summary>
	public readonly string SubAnimationIdle;

	/// <summary>
	/// 简易旅行动画
	/// </summary>
	public readonly string SimpleAnimation;

	/// <summary>
	/// 复杂旅行动画
	/// </summary>
	public readonly string ComplexAnimation;

	/// <summary>
	/// 是否有载具动画
	/// </summary>
	public readonly bool AnyCarrier;

	/// <summary>
	/// 载具动画
	/// </summary>
	public readonly string CarrierAnimation;

	/// <summary>
	/// 载具静止动画
	/// </summary>
	public readonly string CarrierAnimationIdle;

	/// <summary>
	/// 载具动画皮肤
	/// - 除动画有特殊需求外此列均无需填写
	/// </summary>
	public readonly string CarrierAnimationSkin;

	/// <summary>
	/// 载具动画路径
	/// - 此列由程序维护，省略了前缀 RemakeResources/SpineAnimations/Carrier/
	/// </summary>
	public readonly string CarrierAnimationPath;

	/// <summary>
	/// 旅行音效
	/// </summary>
	public readonly string Sound;

	/// <summary>
	/// 旅行地图黑影大小
	/// </summary>
	public readonly float Size;

	/// <summary>
	/// 旅行地图黑影x偏移
	/// </summary>
	public readonly float DeltaX;

	/// <summary>
	/// 旅行地图黑影y偏移
	/// </summary>
	public readonly float DeltaY;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="animation">人物动画 - 角色、代步、圆盘等共用名称</param>
	/// <param name="animationIdle">人物静止动画</param>
	/// <param name="subAnimation">附属人物动画 - 目前仅用于捕快骨骼使用的动画，后续如有多角色旅行需求可再补充支持</param>
	/// <param name="subAnimationIdle">附属人物静止动画</param>
	/// <param name="simpleAnimation">简易旅行动画</param>
	/// <param name="complexAnimation">复杂旅行动画</param>
	/// <param name="anyCarrier">是否有载具动画</param>
	/// <param name="carrierAnimation">载具动画</param>
	/// <param name="carrierAnimationIdle">载具静止动画</param>
	/// <param name="carrierAnimationSkin">载具动画皮肤 - 除动画有特殊需求外此列均无需填写</param>
	/// <param name="carrierAnimationPath">载具动画路径 - 此列由程序维护，省略了前缀 RemakeResources/SpineAnimations/Carrier/</param>
	/// <param name="sound">旅行音效</param>
	/// <param name="size">旅行地图黑影大小</param>
	/// <param name="deltaX">旅行地图黑影x偏移</param>
	/// <param name="deltaY">旅行地图黑影y偏移</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TravelSkeletonItem Duplicate(int templateId)
	{
		return new TravelSkeletonItem((short)templateId, this);
	}
}
