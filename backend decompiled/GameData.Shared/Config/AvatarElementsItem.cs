using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarElementsItem : ConfigItem<AvatarElementsItem, uint>
{
	/// <summary>
	/// 部件id
	/// - 部件id的万位等于AvatarId
	/// </summary>
	public readonly uint TemplateId;

	/// <summary>
	/// 所属体型
	/// - 奇数体型的id为男性体型，偶数体型的id为女性体型
	/// </summary>
	public readonly byte AvatarId;

	/// <summary>
	/// 部件类型
	/// - 眼睛部件、眉毛部件和眼袋纹部件，默认自动镜像处理；嘴巴部件可以上下移动，可以缩放；鼻子部件可以上下移动，可以缩放；眼睛和眉毛部件可以上下移动，可以旋转缩放
	/// </summary>
	public readonly EAvatarElementsType Type;

	/// <summary>
	/// 部件类型Id
	/// - 按照从小到大的顺序进行排序，优先级低的显示序号靠前,所有部件的类型id，除非特别约定，否则都是从1开始。
	/// - 特别约定1：衣服的部件类型id从0开始，强制要求0表示该体型赤身裸体的形象
	/// - 特别约定2：上嘴唇胡须和下嘴唇胡须的id编号1已经被占用，强制要求1号胡须为无胡须的空白图片状态
	/// - 特别约定3：正向特征和负向特征的id编号1已经被占用，强制要求1号特征为无任何特征的空白图片状态
	/// - 特别约定4：强制要求所有体型的前后发的1号组合成和尚头发型
	/// - 特别越定5：奇数和偶数体型之间，正向特征负向特征的部件类型id数量需要对应
	/// - 特别约定6：衣服的id，普通的衣服为0开头，相枢爪牙的衣服为100开头，相枢爪牙骷髅的衣服为200开头，DLC衣服为300开头
	/// </summary>
	public readonly short ElementId;

	/// <summary>
	/// 部件魅力值
	/// - 部件提供的基础魅力值，不提供魅力值的部件填写0或直接不填写任何值
	/// </summary>
	public readonly short ElemCharm;

	/// <summary>
	/// 额外魅力参数
	/// - 该部件对基础魅力值的基本影响系数
	/// </summary>
	public readonly float CharmExtraArg;

	/// <summary>
	/// 部件偏移量
	/// - 默认偏移量是{x:0,y:0}
	/// </summary>
	public readonly float[] Offset;

	/// <summary>
	/// 是否遗传
	/// - 该部件是否参与遗传算法
	/// </summary>
	public readonly bool Inherit;

	/// <summary>
	/// 使用的颜色库
	/// - 0-不使用颜色组
	/// - 1-皮肤颜色组
	/// - 2-特征颜色组
	/// - 3-唇色颜色组
	/// - 4-衣服颜色组
	/// - 5-眼球颜色组
	/// - 6-毛发颜色组
	/// </summary>
	public readonly byte ColorGroup;

	/// <summary>
	/// 图片名/图片相对路径
	/// - 内部资源配置只需要填写资源名就好了
	/// </summary>
	public readonly string NameOrPath;

	/// <summary>
	/// 图片资源的尺寸
	/// - 以像素为单位，格式为：{宽，高}
	/// </summary>
	public readonly short[] SpriteSize;

	/// <summary>
	/// 父级id
	/// - 如果是衣服部件，这里需要填写对应衣服资源的部件类型id；
	/// - 如果是眼睛的异形状态，这里需要填写眼睛正常状态眼睛部件的部件类型id；
	/// - 如果是嘴巴部件，这里需要填写所属嘴巴部件的部件类型id
	/// </summary>
	public readonly byte ParentId;

	/// <summary>
	/// 天生可用
	/// - 创建人物时是否可以直接使用该素材,
	/// - 对于衣服来说，一旦衣服的状态值是true/false，那么与该衣服相匹配的衣服颜色，衣服对应的皮肤都直接可用/不可用了，三者全部都听衣服的
	/// - 按照从小到大的顺序进行排序，优先级低的显示序号靠前,所有部件的类型id，除非特别约定，否则都是从1开始。不可以超过10000，否则会被判定为相枢的服装
	/// </summary>
	public readonly bool CanCreate;

	/// <summary>
	/// 排除元素id列表
	/// - 该元素引起的所有不可使用的元素,并不支持所有的元素。目前支持的类型有：
	/// - 1、前发排除不可使用的后发
	/// </summary>
	public readonly uint[] BanElements;

	/// <summary>
	/// 显示时自动调用的关联额外部件
	/// - 关联到AvatarExtraParts配置表
	/// </summary>
	public readonly short RelativeExtraPart;

	/// <summary>
	/// 帽子的后半部分
	/// - 有帽子的时候会隐藏后发，因此这部分使用后发组件显示
	/// </summary>
	public readonly string HatBack;

	/// <summary>
	/// 禁用关联部件类型
	/// - 禁用关联的部件类型，目前支持的类型有：
	/// - 1、前发禁用后发
	/// </summary>
	public readonly bool DisableRelativeType;

	/// <summary>
	/// 是否应该跟随眼部镜像处理
	/// </summary>
	public readonly bool ShouldMirrorEyes;

	/// <summary>
	/// 是否可以镜像
	/// - 居中的特征美术资源该值为False,资源名使用NameOrPath；非居中的该值为True,资源名使用NameOrPath+_l 或NameOrPath+_r
	/// </summary>
	public readonly bool CanMirror;

	/// <summary>
	/// 默认镜像类型
	/// - 用来保证特征美术资源拆分后，没有存储AvatarExtraData数据的人物和之前的特征尽量相同；原来对称的特征，设置为both=2；其他根据原来的位置设置为left=0或right=1
	/// </summary>
	public readonly byte DefaultMirrorType;

	/// <summary>
	/// 是否应该隐藏镜像产生的部件
	/// </summary>
	public readonly bool ShouldHideMirrorObject;

	/// <summary>
	/// 人物骨骼动画插槽和附件
	/// - 格式{插槽1,附件1,插槽2,附件2...}
	/// </summary>
	public readonly string[] SkeletonSlotAndAttachment;

	/// <summary>
	/// 衣服特效名字
	/// - 只需要在衣服类型配
	/// </summary>
	public readonly string ClothEffect;

	/// <summary>
	/// 衣服动态立绘资源
	/// </summary>
	public readonly string ClothSkeletonName;

	/// <summary>
	/// 存在覆盖层
	/// - 只有静态有这个概念，动态用的是另外的机制
	/// </summary>
	public readonly bool HasCover;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">部件id - 部件id的万位等于AvatarId</param>
	/// <param name="avatarId">所属体型 - 奇数体型的id为男性体型，偶数体型的id为女性体型</param>
	/// <param name="type">部件类型 - 眼睛部件、眉毛部件和眼袋纹部件，默认自动镜像处理；嘴巴部件可以上下移动，可以缩放；鼻子部件可以上下移动，可以缩放；眼睛和眉毛部件可以上下移动，可以旋转缩放</param>
	/// <param name="elementId">部件类型Id - 按照从小到大的顺序进行排序，优先级低的显示序号靠前,所有部件的类型id，除非特别约定，否则都是从1开始。 特别约定1：衣服的部件类型id从0开始，强制要求0表示该体型赤身裸体的形象 特别约定2：上嘴唇胡须和下嘴唇胡须的id编号1已经被占用，强制要求1号胡须为无胡须的空白图片状态 特别约定3：正向特征和负向特征的id编号1已经被占用，强制要求1号特征为无任何特征的空白图片状态 特别约定4：强制要求所有体型的前后发的1号组合成和尚头发型 特别越定5：奇数和偶数体型之间，正向特征负向特征的部件类型id数量需要对应 特别约定6：衣服的id，普通的衣服为0开头，相枢爪牙的衣服为100开头，相枢爪牙骷髅的衣服为200开头，DLC衣服为300开头</param>
	/// <param name="elemCharm">部件魅力值 - 部件提供的基础魅力值，不提供魅力值的部件填写0或直接不填写任何值</param>
	/// <param name="charmExtraArg">额外魅力参数 - 该部件对基础魅力值的基本影响系数</param>
	/// <param name="offset">部件偏移量 - 默认偏移量是{x:0,y:0}</param>
	/// <param name="inherit">是否遗传 - 该部件是否参与遗传算法</param>
	/// <param name="colorGroup">使用的颜色库 - 0-不使用颜色组 1-皮肤颜色组 2-特征颜色组 3-唇色颜色组 4-衣服颜色组 5-眼球颜色组 6-毛发颜色组</param>
	/// <param name="nameOrPath">图片名/图片相对路径 - 内部资源配置只需要填写资源名就好了</param>
	/// <param name="spriteSize">图片资源的尺寸 - 以像素为单位，格式为：{宽，高}</param>
	/// <param name="parentId">父级id - 如果是衣服部件，这里需要填写对应衣服资源的部件类型id； 如果是眼睛的异形状态，这里需要填写眼睛正常状态眼睛部件的部件类型id； 如果是嘴巴部件，这里需要填写所属嘴巴部件的部件类型id</param>
	/// <param name="canCreate">天生可用 - 创建人物时是否可以直接使用该素材, 对于衣服来说，一旦衣服的状态值是true/false，那么与该衣服相匹配的衣服颜色，衣服对应的皮肤都直接可用/不可用了，三者全部都听衣服的 按照从小到大的顺序进行排序，优先级低的显示序号靠前,所有部件的类型id，除非特别约定，否则都是从1开始。不可以超过10000，否则会被判定为相枢的服装</param>
	/// <param name="banElements">排除元素id列表 - 该元素引起的所有不可使用的元素,并不支持所有的元素。目前支持的类型有： 1、前发排除不可使用的后发</param>
	/// <param name="relativeExtraPart">显示时自动调用的关联额外部件 - 关联到AvatarExtraParts配置表</param>
	/// <param name="hatBack">帽子的后半部分 - 有帽子的时候会隐藏后发，因此这部分使用后发组件显示</param>
	/// <param name="disableRelativeType">禁用关联部件类型 - 禁用关联的部件类型，目前支持的类型有： 1、前发禁用后发</param>
	/// <param name="shouldMirrorEyes">是否应该跟随眼部镜像处理</param>
	/// <param name="canMirror">是否可以镜像 - 居中的特征美术资源该值为False,资源名使用NameOrPath；非居中的该值为True,资源名使用NameOrPath+_l 或NameOrPath+_r</param>
	/// <param name="defaultMirrorType">默认镜像类型 - 用来保证特征美术资源拆分后，没有存储AvatarExtraData数据的人物和之前的特征尽量相同；原来对称的特征，设置为both=2；其他根据原来的位置设置为left=0或right=1</param>
	/// <param name="shouldHideMirrorObject">是否应该隐藏镜像产生的部件</param>
	/// <param name="skeletonSlotAndAttachment">人物骨骼动画插槽和附件 - 格式{插槽1,附件1,插槽2,附件2...}</param>
	/// <param name="clothEffect">衣服特效名字 - 只需要在衣服类型配</param>
	/// <param name="clothSkeletonName">衣服动态立绘资源</param>
	/// <param name="hasCover">存在覆盖层 - 只有静态有这个概念，动态用的是另外的机制</param>
	public AvatarElementsItem(uint templateId, byte avatarId, EAvatarElementsType type, short elementId, short elemCharm, float charmExtraArg, float[] offset, bool inherit, byte colorGroup, string nameOrPath, short[] spriteSize, byte parentId, bool canCreate, uint[] banElements, short relativeExtraPart, string hatBack, bool disableRelativeType, bool shouldMirrorEyes, bool canMirror, byte defaultMirrorType, bool shouldHideMirrorObject, string[] skeletonSlotAndAttachment, string clothEffect, string clothSkeletonName, bool hasCover)
	{
		TemplateId = templateId;
		AvatarId = avatarId;
		Type = type;
		ElementId = elementId;
		ElemCharm = elemCharm;
		CharmExtraArg = charmExtraArg;
		Offset = offset;
		Inherit = inherit;
		ColorGroup = colorGroup;
		NameOrPath = nameOrPath;
		SpriteSize = spriteSize;
		ParentId = parentId;
		CanCreate = canCreate;
		BanElements = banElements;
		RelativeExtraPart = relativeExtraPart;
		HatBack = hatBack;
		DisableRelativeType = disableRelativeType;
		ShouldMirrorEyes = shouldMirrorEyes;
		CanMirror = canMirror;
		DefaultMirrorType = defaultMirrorType;
		ShouldHideMirrorObject = shouldHideMirrorObject;
		SkeletonSlotAndAttachment = skeletonSlotAndAttachment;
		ClothEffect = clothEffect;
		ClothSkeletonName = clothSkeletonName;
		HasCover = hasCover;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AvatarElementsItem()
	{
		TemplateId = 0u;
		AvatarId = 0;
		Type = (EAvatarElementsType)0;
		ElementId = 0;
		ElemCharm = 0;
		CharmExtraArg = 1f;
		Offset = new float[2];
		Inherit = false;
		ColorGroup = 0;
		NameOrPath = null;
		SpriteSize = new short[2];
		ParentId = 0;
		CanCreate = true;
		BanElements = new uint[0];
		RelativeExtraPart = 0;
		HatBack = null;
		DisableRelativeType = false;
		ShouldMirrorEyes = false;
		CanMirror = false;
		DefaultMirrorType = 0;
		ShouldHideMirrorObject = false;
		SkeletonSlotAndAttachment = null;
		ClothEffect = null;
		ClothSkeletonName = null;
		HasCover = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AvatarElementsItem(uint templateId, AvatarElementsItem other)
	{
		TemplateId = templateId;
		AvatarId = other.AvatarId;
		Type = other.Type;
		ElementId = other.ElementId;
		ElemCharm = other.ElemCharm;
		CharmExtraArg = other.CharmExtraArg;
		Offset = other.Offset;
		Inherit = other.Inherit;
		ColorGroup = other.ColorGroup;
		NameOrPath = other.NameOrPath;
		SpriteSize = other.SpriteSize;
		ParentId = other.ParentId;
		CanCreate = other.CanCreate;
		BanElements = other.BanElements;
		RelativeExtraPart = other.RelativeExtraPart;
		HatBack = other.HatBack;
		DisableRelativeType = other.DisableRelativeType;
		ShouldMirrorEyes = other.ShouldMirrorEyes;
		CanMirror = other.CanMirror;
		DefaultMirrorType = other.DefaultMirrorType;
		ShouldHideMirrorObject = other.ShouldHideMirrorObject;
		SkeletonSlotAndAttachment = other.SkeletonSlotAndAttachment;
		ClothEffect = other.ClothEffect;
		ClothSkeletonName = other.ClothSkeletonName;
		HasCover = other.HasCover;
	}

	public override int GetTemplateId()
	{
		return (int)TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarElementsItem Duplicate(int templateId)
	{
		return new AvatarElementsItem((uint)templateId, this);
	}
}
