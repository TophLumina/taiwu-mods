using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHeadItem : ConfigItem<AvatarHeadItem, byte>
{
	/// <summary>
	/// 部件id
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 头型Id
	/// </summary>
	public readonly byte HeadId;

	/// <summary>
	/// 对应体型Id
	/// - 与AvatarElements表中的AvatarId相同，体型id相同的元素才可以组合在一起进行捏脸组合
	/// </summary>
	public readonly byte AvatarId;

	/// <summary>
	/// 事件描述文本
	/// - 在事件对话中的占位符替换文本，是针对体型外观的描述，！！！不是头型的！！！
	/// </summary>
	public readonly string DisplayDesc;

	/// <summary>
	/// 图片名/图片相对路径
	/// - 我们内部资源配置只需要填写资源名就好了
	/// </summary>
	public readonly string NameOrPath;

	/// <summary>
	/// 动态立绘头身偏移
	/// </summary>
	public readonly short SkeletonHeadBodyOffset;

	/// <summary>
	/// 眼睛最小间距
	/// - 两眼之间的最小间距，左眼图片最右侧与右眼图片最左侧之间的距离
	/// </summary>
	public readonly byte EyesMinDistance;

	/// <summary>
	/// 眼睛区域x最小值
	/// - 眼睛区域左下角距离头部图片左下角的横向x像素值
	/// </summary>
	public readonly short EyesXmin;

	/// <summary>
	/// 眼睛区域x最大值
	/// - 眼睛区域右上角距离头部图片左下角的横向x像素值
	/// </summary>
	public readonly short EyesXmax;

	/// <summary>
	/// 眼睛区域y最小值
	/// - 眼睛区域左下角距离头部图片左下角的纵向y像素值
	/// </summary>
	public readonly short EyesYmin;

	/// <summary>
	/// 眼睛区域y最大值
	/// - 眼睛区域右上角距离头部图片左下角的纵向y像素值
	/// </summary>
	public readonly short EyesYmax;

	/// <summary>
	/// 嘴巴区域y最小值
	/// - 嘴巴可用区域下边缘距离头部图片正下方的y值像素值
	/// </summary>
	public readonly short MouthYmin;

	/// <summary>
	/// 嘴巴区域y最大值
	/// - 嘴巴可用区域上边缘距离头部图片正下方的y值像素值
	/// </summary>
	public readonly short MouthYmax;

	/// <summary>
	/// 关联额外部件
	/// </summary>
	public readonly short RelativeExtraPart;

	/// <summary>
	/// 是否可以随机
	/// - 是否可以在创建人物时成为随机元素
	/// </summary>
	public readonly bool CanRandom;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">部件id</param>
	/// <param name="headId">头型Id</param>
	/// <param name="avatarId">对应体型Id - 与AvatarElements表中的AvatarId相同，体型id相同的元素才可以组合在一起进行捏脸组合</param>
	/// <param name="displayDesc">事件描述文本 - 在事件对话中的占位符替换文本，是针对体型外观的描述，！！！不是头型的！！！</param>
	/// <param name="nameOrPath">图片名/图片相对路径 - 我们内部资源配置只需要填写资源名就好了</param>
	/// <param name="skeletonHeadBodyOffset">动态立绘头身偏移</param>
	/// <param name="eyesMinDistance">眼睛最小间距 - 两眼之间的最小间距，左眼图片最右侧与右眼图片最左侧之间的距离</param>
	/// <param name="eyesXmin">眼睛区域x最小值 - 眼睛区域左下角距离头部图片左下角的横向x像素值</param>
	/// <param name="eyesXmax">眼睛区域x最大值 - 眼睛区域右上角距离头部图片左下角的横向x像素值</param>
	/// <param name="eyesYmin">眼睛区域y最小值 - 眼睛区域左下角距离头部图片左下角的纵向y像素值</param>
	/// <param name="eyesYmax">眼睛区域y最大值 - 眼睛区域右上角距离头部图片左下角的纵向y像素值</param>
	/// <param name="mouthYmin">嘴巴区域y最小值 - 嘴巴可用区域下边缘距离头部图片正下方的y值像素值</param>
	/// <param name="mouthYmax">嘴巴区域y最大值 - 嘴巴可用区域上边缘距离头部图片正下方的y值像素值</param>
	/// <param name="relativeExtraPart">关联额外部件</param>
	/// <param name="canRandom">是否可以随机 - 是否可以在创建人物时成为随机元素</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarHeadItem Duplicate(int templateId)
	{
		return new AvatarHeadItem((byte)templateId, this);
	}
}
