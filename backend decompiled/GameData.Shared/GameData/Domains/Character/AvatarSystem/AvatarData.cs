using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character.AvatarSystem.AvatarRes;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.AvatarSystem;

/// <summary>
/// 根据偏移量修正值进行魅力计算的相关逻辑.
/// 备注: 数据上存储的是偏移量而非百分比/插值参数, 主要是为了保证当配置发生修改时，立绘外观尽可能保持不变，只改变魅力的计算结果.
/// </summary>
/// <summary>
/// 角色根据avatar数据进行魅力计算，不包含由于属性带来的魅力加成影响
/// </summary>
[Serializable]
[SerializableGameData(IsExtensible = true)]
public class AvatarData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ShowVeil = 0;

		public const ushort AvatarId = 1;

		public const ushort ColorSkinId = 2;

		public const ushort ColorClothId = 3;

		public const ushort ChildClothId = 4;

		public const ushort ClothPartId = 5;

		public const ushort HeadId = 6;

		public const ushort EyesMainId = 7;

		public const ushort EyesLeftId = 8;

		public const ushort EyesRightId = 9;

		public const ushort EyebrowId = 10;

		public const ushort ColorEyeballId = 11;

		public const ushort ColorEyebrowId = 12;

		public const ushort EyesHeight = 13;

		public const ushort EyesDistance = 14;

		public const ushort EyesAngle = 15;

		public const ushort EyesScale = 16;

		public const ushort EyebrowHeight = 17;

		public const ushort EyebrowDistance = 18;

		public const ushort EyebrowAngle = 19;

		public const ushort EyebrowScale = 20;

		public const ushort NoseId = 21;

		public const ushort NoseHeight = 22;

		public const ushort NoseScale = 23;

		public const ushort MouthId = 24;

		public const ushort MouthHeight = 25;

		public const ushort MouthScale = 26;

		public const ushort ColorMouthId = 27;

		public const ushort Beard1Id = 28;

		public const ushort Beard2Id = 29;

		public const ushort ColorBeard1Id = 30;

		public const ushort ColorBeard2Id = 31;

		public const ushort FrontHairId = 32;

		public const ushort BackHairId = 33;

		public const ushort ColorFrontHairId = 34;

		public const ushort ColorBackHairId = 35;

		public const ushort Feature1Id = 36;

		public const ushort Feature2Id = 37;

		public const ushort Wrinkle1Id = 38;

		public const ushort Wrinkle2Id = 39;

		public const ushort Wrinkle3Id = 40;

		public const ushort ColorFeature1Id = 41;

		public const ushort ColorFeature2Id = 42;

		public const ushort GrowableElementsShowingAbilities = 43;

		public const ushort GrowableElementsShowingStates = 44;

		public const ushort Feature1MirrorType = 45;

		public const ushort Feature2MirrorType = 46;

		public const ushort Count = 47;

		public static readonly string[] FieldId2FieldName = new string[47]
		{
			"ShowVeil", "AvatarId", "ColorSkinId", "ColorClothId", "ChildClothId", "ClothPartId", "HeadId", "EyesMainId", "EyesLeftId", "EyesRightId",
			"EyebrowId", "ColorEyeballId", "ColorEyebrowId", "EyesHeight", "EyesDistance", "EyesAngle", "EyesScale", "EyebrowHeight", "EyebrowDistance", "EyebrowAngle",
			"EyebrowScale", "NoseId", "NoseHeight", "NoseScale", "MouthId", "MouthHeight", "MouthScale", "ColorMouthId", "Beard1Id", "Beard2Id",
			"ColorBeard1Id", "ColorBeard2Id", "FrontHairId", "BackHairId", "ColorFrontHairId", "ColorBackHairId", "Feature1Id", "Feature2Id", "Wrinkle1Id", "Wrinkle2Id",
			"Wrinkle3Id", "ColorFeature1Id", "ColorFeature2Id", "GrowableElementsShowingAbilities", "GrowableElementsShowingStates", "Feature1MirrorType", "Feature2MirrorType"
		};
	}

	/// <summary>
	/// 是否显示面纱
	/// </summary>
	[SerializableGameDataField]
	public bool ShowVeil;

	/// <summary>
	/// 形象 ID.
	/// 【隐形规则】：奇数是男性体型，偶数是女性体型！
	/// 取值范围 [1, 6]. 1, 3, 5 为男性体型从瘦到胖. 2, 4, 6 为女性体型从瘦到胖.
	/// </summary>
	[SerializableGameDataField]
	public byte AvatarId;

	/// <summary>
	/// 整体皮肤颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorSkinId;

	/// <summary>
	/// 衣服颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorClothId;

	/// <summary>
	/// 婴幼儿衣服id，以幼儿作为索引，婴儿取模
	/// </summary>
	[SerializableGameDataField]
	public short ChildClothId;

	/// <summary>
	/// 前端专用，要么监听，要么手动赋值，否则影响魅力的显示
	/// 衣服Id
	/// </summary>
	public short ClothDisplayId;

	/// <summary>
	/// 前端专用
	/// 是否显示害羞表现
	/// </summary>
	public bool ShowBlush;

	/// <summary>
	/// 前端专用
	/// 是否显示界青特殊面具
	/// </summary>
	public bool ShowJieqingMask;

	/// <summary>
	/// 前端专用 玄灰状态的款式 从0开始，-1代表没有
	/// </summary>
	public sbyte DarkAshStyle = -1;

	/// <summary>
	/// 前端专用 入邪展示状态：-1=没有, 0=入邪, 1=入魔
	/// </summary>
	public sbyte XiangshuInfectionStyle = -1;

	/// <summary>
	/// 前端专用 心念展示状态：-1=没有, 0=蓝睁眼, 1=蓝闭眼, 2=白睁眼, 3=白闭眼, 4=红睁眼, 5=红闭眼
	/// </summary>
	public sbyte HuanxinFaceStyle = -1;

	/// <summary>
	/// 前端专用 婴儿所属门派/城镇的模板ID
	/// </summary>
	public sbyte BabyOrgTemplateId = -1;

	/// <summary>
	/// 前端专用 婴儿的品阶等级，仅当BabyOrgTemplateId不为-1时有效
	/// </summary>
	public sbyte BabyOrgGrade = -1;

	/// <summary>
	/// 衣服部件id，0表示没有
	/// </summary>
	[SerializableGameDataField]
	public byte ClothPartId;

	/// <summary>
	/// 头部id，0表示没有,只有mod体型能不使用头
	/// </summary>
	[SerializableGameDataField]
	public byte HeadId = 1;

	/// <summary>
	/// 眼部主系列id
	/// </summary>
	[SerializableGameDataField]
	public short EyesMainId;

	/// <summary>
	/// 左眼异种id
	/// </summary>
	[SerializableGameDataField]
	public short EyesLeftId;

	/// <summary>
	/// 右眼异种id
	/// </summary>
	[SerializableGameDataField]
	public short EyesRightId;

	/// <summary>
	/// 眉毛id
	/// </summary>
	[SerializableGameDataField]
	public short EyebrowId;

	/// <summary>
	/// 眼珠颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorEyeballId;

	/// <summary>
	/// 眉毛颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorEyebrowId;

	/// <summary>
	/// 【百分比】在眼睛区域所处高度的百分比
	/// </summary>
	[SerializableGameDataField]
	public short EyesHeight;

	/// <summary>
	/// 【百分比】两眼间距的百分比
	/// </summary>
	[SerializableGameDataField]
	public short EyesDistance;

	/// <summary>
	/// 【绝对值】左眼旋转角度(右眼自动镜像)
	/// </summary>
	[SerializableGameDataField]
	public short EyesAngle;

	/// <summary>
	/// 【绝对值】眼睛缩放值
	/// </summary>
	[SerializableGameDataField]
	public short EyesScale;

	/// <summary>
	/// 【绝对值】眉毛相对眼睛图片上边缘的高度差
	/// </summary>
	[SerializableGameDataField]
	public short EyebrowHeight;

	/// <summary>
	/// 【百分比】眉毛间距百分比
	/// </summary>
	[SerializableGameDataField]
	public short EyebrowDistance;

	/// <summary>
	/// 【绝对值】左眼眉毛旋转角度(右眼眉毛自动镜像)
	/// </summary>
	[SerializableGameDataField]
	public short EyebrowAngle;

	/// <summary>
	/// 【绝对值】眉毛缩放值
	/// </summary>
	[SerializableGameDataField]
	public short EyebrowScale;

	/// <summary>
	/// 鼻子ID 0表示没有鼻子，只有mod资源才可以赋值0
	/// </summary>
	[SerializableGameDataField]
	public short NoseId;

	/// <summary>
	/// 【百分比】鼻子在脸部区域的高度百分比(x必定居中)
	/// </summary>
	[SerializableGameDataField]
	public short NoseHeight;

	/// <summary>
	/// 【绝对值】鼻子的缩放值
	/// </summary>
	[SerializableGameDataField]
	public short NoseScale;

	/// <summary>
	/// 嘴巴id 0表示没有嘴巴，只有mod资源才可以赋值0
	/// </summary>
	[SerializableGameDataField]
	public short MouthId;

	/// <summary>
	/// 【百分比】在嘴巴区域的高度百分比(x必定居中)
	/// </summary>
	[SerializableGameDataField]
	public short MouthHeight;

	/// <summary>
	/// 【绝对值】嘴巴的缩放值
	/// </summary>
	[SerializableGameDataField]
	public short MouthScale;

	/// <summary>
	/// 唇色索引
	/// </summary>
	[SerializableGameDataField]
	public byte ColorMouthId;

	/// <summary>
	/// 上嘴唇胡须id
	/// </summary>
	[SerializableGameDataField]
	public short Beard1Id;

	/// <summary>
	/// 下嘴唇胡须id
	/// </summary>
	[SerializableGameDataField]
	public short Beard2Id;

	/// <summary>
	/// 上胡须颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorBeard1Id;

	/// <summary>
	/// 下胡须颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorBeard2Id;

	/// <summary>
	/// 前发id
	/// </summary>
	[SerializableGameDataField]
	public short FrontHairId;

	/// <summary>
	/// 后发id
	/// </summary>
	[SerializableGameDataField]
	public short BackHairId;

	/// <summary>
	/// 前发层颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorFrontHairId;

	/// <summary>
	/// 后发层颜色
	/// </summary>
	[SerializableGameDataField]
	public byte ColorBackHairId;

	/// <summary>
	/// 特征1id
	/// </summary>
	[SerializableGameDataField]
	public short Feature1Id;

	/// <summary>
	/// 特征2id
	/// </summary>
	[SerializableGameDataField]
	public short Feature2Id;

	/// <summary>
	/// 抬头纹id
	/// </summary>
	[SerializableGameDataField]
	public short Wrinkle1Id;

	/// <summary>
	/// 表情纹id
	/// </summary>
	[SerializableGameDataField]
	public short Wrinkle2Id;

	/// <summary>
	/// 眼袋纹id
	/// </summary>
	[SerializableGameDataField]
	public short Wrinkle3Id;

	/// <summary>
	/// 特征1颜色id
	/// </summary>
	[SerializableGameDataField]
	public byte ColorFeature1Id;

	/// <summary>
	/// 特征2颜色id
	/// </summary>
	[SerializableGameDataField]
	public byte ColorFeature2Id;

	/// <summary>
	/// 可生长部件的显示能力.
	/// 比如为女性, 或者男性年龄未到, 都不可显示胡须.
	/// 每个比特位一个表示一个部件的显示能力, 0 表示不可显示, 1 表示可显示.
	/// 部件的顺序参见 <see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" />
	/// </summary>
	[SerializableGameDataField]
	private byte _growableElementsShowingAbilities;

	/// <summary>
	/// 可生长部件的显示状态.
	/// 比如剃须后, 胡须就处于隐藏状态; 几个月后, 会再生长出来.
	/// 每个比特位一个表示一个部件的显示状态, 0 表示隐藏, 1 表示显示.
	/// 部件的顺序参见 <see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" />
	/// </summary>
	[SerializableGameDataField]
	private byte _growableElementsShowingStates;

	/// <summary>
	/// 特征1镜像类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte Feature1MirrorType;

	/// <summary>
	/// 特征2镜像类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte Feature2MirrorType;

	/// <summary>
	/// 魅力等级排序
	/// </summary>
	public static readonly short[] CharmLevel = new short[9] { 100, 200, 300, 400, 500, 600, 700, 800, 900 };

	[NonSerialized]
	private sbyte _eyesHeightIndex;

	[NonSerialized]
	private AvatarGroup _avatarGroup;

	[NonSerialized]
	private AvatarAsset _headAsset;

	/// 所有的id均表示资源名中解析出来的id，不是存储在AvatarGroup中各个IEnumrable的索引
	///  <summary>
	///  基础魅力值
	///  </summary>
	public short BaseCharm => GetBaseCharm();

	/// <summary>
	/// 性别，不存档
	/// 这个性别仅是玩家体型数据表现出来的性别，并不是角色的真实性别
	/// </summary>
	public sbyte Gender => GetGender();

	/// <summary>
	/// 面部可见性
	/// </summary>
	public bool FaceVisible
	{
		get
		{
			if (!ShowVeil)
			{
				return !ShowMask();
			}
			return false;
		}
	}

	public AvatarElementPositionItem PositionConfig => AvatarElementPosition.Instance[AvatarId - 1];

	private AvatarManager AvatarManager => AvatarManager.Instance;

	/// <summary>
	/// 获取形象的性别 (角色对象里有正式的性别字段)
	/// </summary>
	/// <returns></returns>
	public sbyte GetGender()
	{
		return (AvatarId % 2 == 1) ? ((sbyte)1) : ((sbyte)0);
	}

	/// <summary>
	/// 是否显示面具
	/// </summary>
	/// <returns></returns>
	public bool ShowMask()
	{
		short clothDisplayId = ClothDisplayId;
		return ShowMask(clothDisplayId);
	}

	public bool ShowMask(short clothDisplayId)
	{
		AvatarAsset asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Cloth, clothDisplayId);
		if (asset != null && asset.Config.RelativeExtraPart >= 6)
		{
			return asset.Config.RelativeExtraPart <= 23;
		}
		return false;
	}

	/// <summary>
	/// 改变形象的性别 (角色对象里有正式的性别字段).
	/// 此方法未提交数据更改.
	/// </summary>
	/// <param name="gender"></param>
	public void ChangeGender(sbyte gender)
	{
		int oriGender = AvatarId % 2;
		if (oriGender != gender)
		{
			if (oriGender == 1)
			{
				AvatarId++;
			}
			else
			{
				AvatarId--;
			}
		}
	}

	/// <summary>
	/// 获取体型
	/// </summary>
	/// <returns></returns>
	public sbyte GetBodyType()
	{
		return (sbyte)((AvatarId - 1) / 2);
	}

	/// <summary>
	/// 改变体型.
	/// 此方法未提交数据更改.
	/// </summary>
	/// <param name="bodyType"><see cref="T:GameData.Domains.Character.BodyType" /></param>
	public void ChangeBodyType(sbyte bodyType)
	{
		int genderOffset = (AvatarId - 1) % 2;
		AvatarId = (byte)(bodyType * 2 + genderOffset + 1);
	}

	/// <summary>
	/// 把受到禁用的数据修改到空值
	/// </summary>
	/// <returns></returns>
	public AvatarData FormatDisabledElements()
	{
		AvatarManager manager = AvatarManager.Instance;
		AvatarAsset backHairAsset = manager.GetAsset(AvatarId, EAvatarElementsType.Hair2, BackHairId);
		AvatarAsset frontHairAsset = manager.GetAsset(AvatarId, EAvatarElementsType.Hair1, FrontHairId);
		if (frontHairAsset.Config.DisableRelativeType)
		{
			BackHairId = 1;
		}
		if (frontHairAsset.Config.BanElements != null && Array.Exists(frontHairAsset.Config.BanElements, (uint e) => e == backHairAsset.Config.TemplateId))
		{
			BackHairId = 1;
		}
		return this;
	}

	/// <summary>
	/// 根据体型将外貌数据转换为骷髅
	/// </summary>
	/// <exception cref="T:System.Exception"></exception>
	public void ConvertAvatarToSkeleton()
	{
		sbyte bodyType = GetBodyType();
		byte headTemplateId = bodyType switch
		{
			0 => (byte)((Gender == 0) ? 11 : 10), 
			1 => (byte)((Gender == 0) ? 13 : 12), 
			2 => (byte)((Gender == 0) ? 15 : 14), 
			_ => throw new Exception($"invalid body type {bodyType}"), 
		};
		HeadId = AvatarHead.Instance[headTemplateId].HeadId;
	}

	/// <summary>
	/// 设置指定的可生长部件的显示能力.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	/// <param name="showable"></param>
	public void SetGrowableElementShowingAbility(sbyte growableElementType, bool showable)
	{
		if (showable)
		{
			_growableElementsShowingAbilities |= (byte)(1 << (int)growableElementType);
		}
		else
		{
			_growableElementsShowingAbilities &= (byte)(~(1 << (int)growableElementType));
		}
	}

	/// <summary>
	/// 设置指定的可生长部件为有显示能力.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	public void SetGrowableElementShowingAbility(sbyte growableElementType)
	{
		_growableElementsShowingAbilities |= (byte)(1 << (int)growableElementType);
	}

	/// <summary>
	/// 设置指定的可生长部件为没有显示能力.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	public void ResetGrowableElementShowingAbility(sbyte growableElementType)
	{
		_growableElementsShowingAbilities &= (byte)(~(1 << (int)growableElementType));
	}

	public void ClearGrowableElementShowingAbilities()
	{
		_growableElementsShowingAbilities = 0;
	}

	public void FillGrowableElementsShowingStates()
	{
		_growableElementsShowingStates = byte.MaxValue;
	}

	public byte GetGrowableElementShowingAbilities()
	{
		return _growableElementsShowingAbilities;
	}

	public byte GetGrowableElementShowingStates()
	{
		return _growableElementsShowingStates;
	}

	/// <summary>
	/// 获取指定的可生长部件的显示能力.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"></param>
	/// <returns>true: 可显示, false: 不可显示</returns>
	public bool GetGrowableElementShowingAbility(sbyte growableElementType)
	{
		return (_growableElementsShowingAbilities & (1 << (int)growableElementType)) != 0;
	}

	/// <summary>
	/// 设置指定可生长部件的显示状态.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	/// <param name="show"></param>
	public void SetGrowableElementShowingState(sbyte growableElementType, bool show)
	{
		if (show)
		{
			_growableElementsShowingStates |= (byte)(1 << (int)growableElementType);
		}
		else
		{
			_growableElementsShowingStates &= (byte)(~(1 << (int)growableElementType));
		}
	}

	/// <summary>
	/// 设置指定可生长部件为处于显示状态.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	public void SetGrowableElementShowingState(sbyte growableElementType)
	{
		_growableElementsShowingStates |= (byte)(1 << (int)growableElementType);
	}

	/// <summary>
	/// 设置指定可生长部件为处于隐藏状态.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	public void ResetGrowableElementShowingState(sbyte growableElementType)
	{
		_growableElementsShowingStates &= (byte)(~(1 << (int)growableElementType));
	}

	/// <summary>
	/// 获取指定可生长部件的显示状态.
	/// 有显示能力, 且处于显示状态, 才会显示; 其他情况都不会显示.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	/// <returns>true: 显示, false: 隐藏</returns>
	public bool GetGrowableElementShowingState(sbyte growableElementType)
	{
		return (_growableElementsShowingStates & (1 << (int)growableElementType)) != 0;
	}

	/// <summary>
	/// 获取多胞胎婴儿的形象.
	/// 多胞胎婴儿的先天形象完全一样, 只有部分后天形象不同.
	/// </summary>
	/// <param name="random"></param>
	/// <param name="gender"></param>
	/// <returns></returns>
	public AvatarData GenerateMultipleBirthChildAvatar(IRandomSource random, sbyte gender)
	{
		AvatarData avatar = new AvatarData(this);
		avatar.ChangeGender(gender);
		AvatarGroup group = AvatarManager.Instance.GetAvatarGroup(avatar.AvatarId);
		(avatar.FrontHairId, avatar.BackHairId) = group.GetRandomHairs(random);
		return avatar;
	}

	/// <summary>
	/// 从其他捏脸数据复制
	/// </summary>
	/// <param name="other"></param>
	public void Copy(AvatarData other)
	{
		Assign(other);
		ClothDisplayId = other.ClothDisplayId;
	}

	/// <summary>
	/// 获取前发和后发的Spine动画形象插槽配置字段
	/// </summary>
	/// <returns>(前发,后发)</returns>
	public (string[], string[]) GetSkeletonSlotAndAttachment()
	{
		if (!GetGrowableElementShowingState(0) || !GetGrowableElementShowingAbility(0))
		{
			return (null, null);
		}
		AvatarManager manager = AvatarManager.Instance;
		AvatarAsset frontHairAsset = manager.GetAsset(AvatarId, EAvatarElementsType.Hair1, FrontHairId);
		AvatarAsset backHairAsset = manager.GetAsset(AvatarId, EAvatarElementsType.Hair2, BackHairId);
		return (frontHairAsset.Config.SkeletonSlotAndAttachment, backHairAsset.Config.SkeletonSlotAndAttachment);
	}

	/// <summary>
	/// 切换到结婚时风格1的显示数据（冠冕1/盖头）
	/// </summary>
	public void ChangeToMarriageStyle1()
	{
		ClothDisplayId = SharedConstValue.MarriageClothDisplayId;
		FrontHairId = SharedConstValue.MarriageHairHeadDressId;
		BackHairId = SharedConstValue.MarriageHairHeadDressId;
	}

	/// <summary>
	/// 切换到结婚时风格2的显示数据（冠冕2/凤冠）
	/// </summary>
	public void ChangeToMarriageStyle2()
	{
		ClothDisplayId = SharedConstValue.MarriageClothDisplayId;
		FrontHairId = SharedConstValue.MarriageHairPhoenixCoronetId;
		BackHairId = SharedConstValue.MarriageHairPhoenixCoronetId;
	}

	/// <summary>
	/// 狮相异族高手衣装
	/// </summary>
	public void ChangeToShixiangBarbarianMaster()
	{
		ClothDisplayId = SharedConstValue.ShixiangBarbarianMasterClothDisplayId;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AvatarData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AvatarData(AvatarData other)
	{
		ShowVeil = other.ShowVeil;
		AvatarId = other.AvatarId;
		ColorSkinId = other.ColorSkinId;
		ColorClothId = other.ColorClothId;
		ChildClothId = other.ChildClothId;
		ClothPartId = other.ClothPartId;
		HeadId = other.HeadId;
		EyesMainId = other.EyesMainId;
		EyesLeftId = other.EyesLeftId;
		EyesRightId = other.EyesRightId;
		EyebrowId = other.EyebrowId;
		ColorEyeballId = other.ColorEyeballId;
		ColorEyebrowId = other.ColorEyebrowId;
		EyesHeight = other.EyesHeight;
		EyesDistance = other.EyesDistance;
		EyesAngle = other.EyesAngle;
		EyesScale = other.EyesScale;
		EyebrowHeight = other.EyebrowHeight;
		EyebrowDistance = other.EyebrowDistance;
		EyebrowAngle = other.EyebrowAngle;
		EyebrowScale = other.EyebrowScale;
		NoseId = other.NoseId;
		NoseHeight = other.NoseHeight;
		NoseScale = other.NoseScale;
		MouthId = other.MouthId;
		MouthHeight = other.MouthHeight;
		MouthScale = other.MouthScale;
		ColorMouthId = other.ColorMouthId;
		Beard1Id = other.Beard1Id;
		Beard2Id = other.Beard2Id;
		ColorBeard1Id = other.ColorBeard1Id;
		ColorBeard2Id = other.ColorBeard2Id;
		FrontHairId = other.FrontHairId;
		BackHairId = other.BackHairId;
		ColorFrontHairId = other.ColorFrontHairId;
		ColorBackHairId = other.ColorBackHairId;
		Feature1Id = other.Feature1Id;
		Feature2Id = other.Feature2Id;
		Wrinkle1Id = other.Wrinkle1Id;
		Wrinkle2Id = other.Wrinkle2Id;
		Wrinkle3Id = other.Wrinkle3Id;
		ColorFeature1Id = other.ColorFeature1Id;
		ColorFeature2Id = other.ColorFeature2Id;
		_growableElementsShowingAbilities = other._growableElementsShowingAbilities;
		_growableElementsShowingStates = other._growableElementsShowingStates;
		Feature1MirrorType = other.Feature1MirrorType;
		Feature2MirrorType = other.Feature2MirrorType;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AvatarData other)
	{
		ShowVeil = other.ShowVeil;
		AvatarId = other.AvatarId;
		ColorSkinId = other.ColorSkinId;
		ColorClothId = other.ColorClothId;
		ChildClothId = other.ChildClothId;
		ClothPartId = other.ClothPartId;
		HeadId = other.HeadId;
		EyesMainId = other.EyesMainId;
		EyesLeftId = other.EyesLeftId;
		EyesRightId = other.EyesRightId;
		EyebrowId = other.EyebrowId;
		ColorEyeballId = other.ColorEyeballId;
		ColorEyebrowId = other.ColorEyebrowId;
		EyesHeight = other.EyesHeight;
		EyesDistance = other.EyesDistance;
		EyesAngle = other.EyesAngle;
		EyesScale = other.EyesScale;
		EyebrowHeight = other.EyebrowHeight;
		EyebrowDistance = other.EyebrowDistance;
		EyebrowAngle = other.EyebrowAngle;
		EyebrowScale = other.EyebrowScale;
		NoseId = other.NoseId;
		NoseHeight = other.NoseHeight;
		NoseScale = other.NoseScale;
		MouthId = other.MouthId;
		MouthHeight = other.MouthHeight;
		MouthScale = other.MouthScale;
		ColorMouthId = other.ColorMouthId;
		Beard1Id = other.Beard1Id;
		Beard2Id = other.Beard2Id;
		ColorBeard1Id = other.ColorBeard1Id;
		ColorBeard2Id = other.ColorBeard2Id;
		FrontHairId = other.FrontHairId;
		BackHairId = other.BackHairId;
		ColorFrontHairId = other.ColorFrontHairId;
		ColorBackHairId = other.ColorBackHairId;
		Feature1Id = other.Feature1Id;
		Feature2Id = other.Feature2Id;
		Wrinkle1Id = other.Wrinkle1Id;
		Wrinkle2Id = other.Wrinkle2Id;
		Wrinkle3Id = other.Wrinkle3Id;
		ColorFeature1Id = other.ColorFeature1Id;
		ColorFeature2Id = other.ColorFeature2Id;
		_growableElementsShowingAbilities = other._growableElementsShowingAbilities;
		_growableElementsShowingStates = other._growableElementsShowingStates;
		Feature1MirrorType = other.Feature1MirrorType;
		Feature2MirrorType = other.Feature2MirrorType;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 77;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 47;
		byte* num = pData + 2;
		*num = (ShowVeil ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = AvatarId;
		byte* num3 = num2 + 1;
		*num3 = ColorSkinId;
		byte* num4 = num3 + 1;
		*num4 = ColorClothId;
		byte* num5 = num4 + 1;
		*(short*)num5 = ChildClothId;
		byte* num6 = num5 + 2;
		*num6 = ClothPartId;
		byte* num7 = num6 + 1;
		*num7 = HeadId;
		byte* num8 = num7 + 1;
		*(short*)num8 = EyesMainId;
		byte* num9 = num8 + 2;
		*(short*)num9 = EyesLeftId;
		byte* num10 = num9 + 2;
		*(short*)num10 = EyesRightId;
		byte* num11 = num10 + 2;
		*(short*)num11 = EyebrowId;
		byte* num12 = num11 + 2;
		*num12 = ColorEyeballId;
		byte* num13 = num12 + 1;
		*num13 = ColorEyebrowId;
		byte* num14 = num13 + 1;
		*(short*)num14 = EyesHeight;
		byte* num15 = num14 + 2;
		*(short*)num15 = EyesDistance;
		byte* num16 = num15 + 2;
		*(short*)num16 = EyesAngle;
		byte* num17 = num16 + 2;
		*(short*)num17 = EyesScale;
		byte* num18 = num17 + 2;
		*(short*)num18 = EyebrowHeight;
		byte* num19 = num18 + 2;
		*(short*)num19 = EyebrowDistance;
		byte* num20 = num19 + 2;
		*(short*)num20 = EyebrowAngle;
		byte* num21 = num20 + 2;
		*(short*)num21 = EyebrowScale;
		byte* num22 = num21 + 2;
		*(short*)num22 = NoseId;
		byte* num23 = num22 + 2;
		*(short*)num23 = NoseHeight;
		byte* num24 = num23 + 2;
		*(short*)num24 = NoseScale;
		byte* num25 = num24 + 2;
		*(short*)num25 = MouthId;
		byte* num26 = num25 + 2;
		*(short*)num26 = MouthHeight;
		byte* num27 = num26 + 2;
		*(short*)num27 = MouthScale;
		byte* num28 = num27 + 2;
		*num28 = ColorMouthId;
		byte* num29 = num28 + 1;
		*(short*)num29 = Beard1Id;
		byte* num30 = num29 + 2;
		*(short*)num30 = Beard2Id;
		byte* num31 = num30 + 2;
		*num31 = ColorBeard1Id;
		byte* num32 = num31 + 1;
		*num32 = ColorBeard2Id;
		byte* num33 = num32 + 1;
		*(short*)num33 = FrontHairId;
		byte* num34 = num33 + 2;
		*(short*)num34 = BackHairId;
		byte* num35 = num34 + 2;
		*num35 = ColorFrontHairId;
		byte* num36 = num35 + 1;
		*num36 = ColorBackHairId;
		byte* num37 = num36 + 1;
		*(short*)num37 = Feature1Id;
		byte* num38 = num37 + 2;
		*(short*)num38 = Feature2Id;
		byte* num39 = num38 + 2;
		*(short*)num39 = Wrinkle1Id;
		byte* num40 = num39 + 2;
		*(short*)num40 = Wrinkle2Id;
		byte* num41 = num40 + 2;
		*(short*)num41 = Wrinkle3Id;
		byte* num42 = num41 + 2;
		*num42 = ColorFeature1Id;
		byte* num43 = num42 + 1;
		*num43 = ColorFeature2Id;
		byte* num44 = num43 + 1;
		*num44 = _growableElementsShowingAbilities;
		byte* num45 = num44 + 1;
		*num45 = _growableElementsShowingStates;
		byte* num46 = num45 + 1;
		*num46 = (byte)Feature1MirrorType;
		byte* num47 = num46 + 1;
		*num47 = (byte)Feature2MirrorType;
		int totalSize = (int)(num47 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ShowVeil = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			AvatarId = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			ColorSkinId = *pCurrData;
			pCurrData++;
		}
		if (num > 3)
		{
			ColorClothId = *pCurrData;
			pCurrData++;
		}
		if (num > 4)
		{
			ChildClothId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			ClothPartId = *pCurrData;
			pCurrData++;
		}
		if (num > 6)
		{
			HeadId = *pCurrData;
			pCurrData++;
		}
		if (num > 7)
		{
			EyesMainId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 8)
		{
			EyesLeftId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 9)
		{
			EyesRightId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 10)
		{
			EyebrowId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 11)
		{
			ColorEyeballId = *pCurrData;
			pCurrData++;
		}
		if (num > 12)
		{
			ColorEyebrowId = *pCurrData;
			pCurrData++;
		}
		if (num > 13)
		{
			EyesHeight = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 14)
		{
			EyesDistance = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 15)
		{
			EyesAngle = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 16)
		{
			EyesScale = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 17)
		{
			EyebrowHeight = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 18)
		{
			EyebrowDistance = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 19)
		{
			EyebrowAngle = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 20)
		{
			EyebrowScale = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 21)
		{
			NoseId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 22)
		{
			NoseHeight = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 23)
		{
			NoseScale = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 24)
		{
			MouthId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 25)
		{
			MouthHeight = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 26)
		{
			MouthScale = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 27)
		{
			ColorMouthId = *pCurrData;
			pCurrData++;
		}
		if (num > 28)
		{
			Beard1Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 29)
		{
			Beard2Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 30)
		{
			ColorBeard1Id = *pCurrData;
			pCurrData++;
		}
		if (num > 31)
		{
			ColorBeard2Id = *pCurrData;
			pCurrData++;
		}
		if (num > 32)
		{
			FrontHairId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 33)
		{
			BackHairId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 34)
		{
			ColorFrontHairId = *pCurrData;
			pCurrData++;
		}
		if (num > 35)
		{
			ColorBackHairId = *pCurrData;
			pCurrData++;
		}
		if (num > 36)
		{
			Feature1Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 37)
		{
			Feature2Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 38)
		{
			Wrinkle1Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 39)
		{
			Wrinkle2Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 40)
		{
			Wrinkle3Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 41)
		{
			ColorFeature1Id = *pCurrData;
			pCurrData++;
		}
		if (num > 42)
		{
			ColorFeature2Id = *pCurrData;
			pCurrData++;
		}
		if (num > 43)
		{
			_growableElementsShowingAbilities = *pCurrData;
			pCurrData++;
		}
		if (num > 44)
		{
			_growableElementsShowingStates = *pCurrData;
			pCurrData++;
		}
		if (num > 45)
		{
			Feature1MirrorType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 46)
		{
			Feature2MirrorType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 五官魅力值.
	/// </summary>
	/// <returns></returns>
	public short GetFaceCharm()
	{
		(int, int) adjust = GetFaceValueAdjust();
		return (short)(GetBaseCharm() * adjust.Item1 / 100 * adjust.Item2 / 100);
	}

	private (int elementAdjust, int layoutAdjust) GetFaceValueAdjust()
	{
		int layoutAdjust = 0;
		AvatarElementPositionItem positionCfg = PositionConfig;
		AvatarFaceElementScoreItem eyeScoreCfg = AvatarFaceElementScore.DefValue.Eye;
		int eyeElementAdjust = CalcScore(eyeScoreCfg.ScaleScore, positionCfg.EyeScaleRange, EyesScale) + CalcScore(eyeScoreCfg.AngleScore, positionCfg.EyeAngleRange, EyesAngle);
		int totalScore = eyeScoreCfg.ScaleScore + eyeScoreCfg.AngleScore;
		eyeElementAdjust = CalcAdjustedScore(eyeScoreCfg, eyeElementAdjust, totalScore);
		int val = eyeElementAdjust;
		layoutAdjust = CalcScore(eyeScoreCfg.HeightScore, positionCfg.EyeHeightRange, EyesHeight) + CalcScore(eyeScoreCfg.DistanceScore, positionCfg.EyeDistanceRange, EyesDistance);
		AvatarFaceElementScoreItem eyebrowScoreCfg = AvatarFaceElementScore.DefValue.Eyebrow;
		int eyebrowElementAdjust = CalcScore(eyebrowScoreCfg.ScaleScore, positionCfg.EyebrowScaleRange, EyebrowScale) + CalcScore(eyebrowScoreCfg.AngleScore, positionCfg.EyebrowAngleRange, EyebrowAngle);
		int totalScore2 = eyebrowScoreCfg.ScaleScore + eyebrowScoreCfg.AngleScore;
		eyebrowElementAdjust = CalcAdjustedScore(eyebrowScoreCfg, eyebrowElementAdjust, totalScore2);
		int val2 = Math.Min(val, eyebrowElementAdjust);
		layoutAdjust += CalcScore(eyebrowScoreCfg.HeightScore, positionCfg.EyebrowHeightRange, EyebrowHeight) + CalcScore(eyebrowScoreCfg.DistanceScore, positionCfg.EyebrowDistanceRange, EyebrowDistance);
		AvatarFaceElementScoreItem noseScoreCfg = AvatarFaceElementScore.DefValue.Nose;
		int noseElementAdjust = CalcScore(noseScoreCfg.ScaleScore, positionCfg.NoseScaleRange, NoseScale);
		noseElementAdjust = CalcAdjustedScore(noseScoreCfg, noseElementAdjust, noseScoreCfg.ScaleScore);
		int val3 = Math.Min(val2, noseElementAdjust);
		layoutAdjust += CalcScore(noseScoreCfg.HeightScore, positionCfg.NoseHeightRange, NoseHeight);
		AvatarFaceElementScoreItem mouthScoreCfg = AvatarFaceElementScore.DefValue.Mouth;
		int mouthElementAdjust = CalcScore(mouthScoreCfg.ScaleScore, positionCfg.MouthScaleRange, MouthScale);
		mouthElementAdjust = CalcAdjustedScore(mouthScoreCfg, mouthElementAdjust, mouthScoreCfg.ScaleScore);
		int item = Math.Min(val3, mouthElementAdjust);
		layoutAdjust += CalcScore(mouthScoreCfg.HeightScore, positionCfg.MouthHeightRange, MouthHeight);
		return (elementAdjust: item, layoutAdjust: layoutAdjust);
	}

	/// <summary>
	/// 计算得分
	/// </summary>
	public static int CalcScore(int totalScore, float[] offsetRange, short offsetShort)
	{
		float offset = (float)offsetShort / 100f;
		if (offset < offsetRange[1])
		{
			float t = (offset - offsetRange[1]) / (offsetRange[0] - offsetRange[1]);
			return (int)((float)totalScore - (float)totalScore * t * t);
		}
		if (offset > offsetRange[2])
		{
			float t2 = (offset - offsetRange[2]) / (offsetRange[3] - offsetRange[2]);
			return (int)((float)totalScore - (float)totalScore * t2 * t2);
		}
		return totalScore;
	}

	/// <summary>
	/// 计算得分修正
	/// </summary>
	/// <param name="scoreConfig"></param>
	/// <param name="score"></param>
	/// <param name="totalScore"></param>
	/// <returns></returns>
	public static int CalcAdjustedScore(AvatarFaceElementScoreItem scoreConfig, int score, int totalScore)
	{
		return 100 - scoreConfig.AdjustWeight + scoreConfig.AdjustWeight * score / totalScore;
	}

	/// <summary>
	/// 根据百分比计算当前偏移
	/// </summary>
	/// <param name="offsetRange"></param>
	/// <param name="percent"></param>
	/// <returns></returns>
	public static float CalcOffset(float[] offsetRange, int percent)
	{
		return (offsetRange[^1] - offsetRange[0]) * (float)percent / 100f + offsetRange[0];
	}

	/// <summary>
	/// 根据百分比计算当前偏移量的 short 格式 (* 100).
	/// </summary>
	/// <param name="offsetRange"></param>
	/// <param name="percent"></param>
	/// <returns></returns>
	public static short CalcOffsetShortVal(float[] offsetRange, int percent)
	{
		return (short)(100f * CalcOffset(offsetRange, percent));
	}

	public static int CalcOffsetPercent(float[] offsetRange, float offset)
	{
		return (int)((offset - offsetRange[0]) / (offsetRange[^1] - offsetRange[0]) * 100f);
	}

	public static int CalcOffsetShortValPercent(float[] offsetRange, short val)
	{
		return CalcOffsetPercent(offsetRange, (float)val / 100f);
	}

	/// <summary>
	/// 获取最佳范围内的组件偏移量
	/// </summary>
	/// <param name="random"></param>
	/// <param name="offsetRange"></param>
	/// <returns></returns>
	public static float GetRandomOffset(IRandomSource random, float[] offsetRange)
	{
		return offsetRange[1] + (float)(random.NextDouble() * (double)(offsetRange[2] - offsetRange[1]));
	}

	/// <summary>
	/// 获取最佳范围内的组件偏移量 short 格式
	/// </summary>
	/// <param name="random"></param>
	/// <param name="offsetRange"></param>
	/// <returns></returns>
	public static short GetRandomOffsetShortVal(IRandomSource random, float[] offsetRange)
	{
		return (short)(GetRandomOffset(random, offsetRange) * 100f);
	}

	/// <summary>
	/// 获取纯随机组件偏移量
	/// </summary>
	/// <param name="random"></param>
	/// <param name="offsetRange"></param>
	/// <returns></returns>
	public static float GetTotalRandomOffset(IRandomSource random, float[] offsetRange)
	{
		return offsetRange[0] + (float)(random.NextDouble() * (double)(offsetRange[^1] - offsetRange[0]));
	}

	/// <summary>
	/// 获取纯随机组件偏移量 short 格式
	/// </summary>
	/// <param name="random"></param>
	/// <param name="offsetRange"></param>
	/// <returns></returns>
	public static short GetTotalRandomOffsetShortVal(IRandomSource random, float[] offsetRange)
	{
		return (short)(GetTotalRandomOffset(random, offsetRange) * 100f);
	}

	/// <summary>
	/// 计算魅力值
	/// 注意：获取眼睛魅力值的接口必须早于获取鼻子魅力值的接口先被调用
	/// </summary>
	/// <param name="characterAge">角色年龄</param>
	/// <param name="clothId"></param>
	/// <returns></returns>
	public short GetCharm(short characterAge, short clothId)
	{
		_headAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Head, HeadId);
		_eyesHeightIndex = -1;
		double num = (double)GetFaceCharm() * CalCharmRate() + GetWrinkleCharm(characterAge) + GetClothCharm(clothId);
		_headAsset = null;
		return (short)num;
	}

	/// <summary>
	/// 获取人物形象基础魅力值
	/// 注意：获取眼睛魅力值的接口必须早于获取鼻子魅力值的接口先被调用
	/// </summary>
	/// <returns></returns>
	public short GetBaseCharm()
	{
		_headAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Head, HeadId);
		double feature1Charm = GetFeatureCharm().Item1;
		double num = GetEyebrowsCharm() * (double)GlobalConfig.Instance.EyebrowRatioInBaseCharm + GetEyesCharm() * (double)GlobalConfig.Instance.EyesRatioInBaseCharm + GetNoseCharm() * (double)GlobalConfig.Instance.NoseRatioInBaseCharm + GetMouthCharm() * (double)GlobalConfig.Instance.MouthRatioInBaseCharm + feature1Charm;
		_headAsset = null;
		return (short)num;
	}

	public (double, double) GetFeatureCharm()
	{
		double feature1Charm = 0.0;
		AvatarAsset feature1Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Feature1, Feature1Id);
		if (feature1Asset != null)
		{
			feature1Charm = feature1Asset.Config.ElemCharm;
		}
		double feature2CharmRate = 1.0;
		AvatarAsset feature2Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Feature2, Feature2Id);
		if (feature2Asset != null)
		{
			feature2CharmRate = feature2Asset.Config.CharmExtraArg;
		}
		return (feature1Charm, feature2CharmRate);
	}

	public double GetWrinkleCharm(short age)
	{
		short charm = 0;
		if (GetGrowableElementShowingState(3) && GetGrowableElementShowingAbility(3))
		{
			AvatarAsset wrinkle1Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Wrinkle1, Wrinkle1Id);
			if (wrinkle1Asset != null)
			{
				charm += wrinkle1Asset.Config.ElemCharm;
			}
		}
		if (GetGrowableElementShowingState(4) && GetGrowableElementShowingAbility(4))
		{
			AvatarAsset wrinkle2Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Wrinkle2, Wrinkle2Id);
			if (wrinkle2Asset != null)
			{
				charm += wrinkle2Asset.Config.ElemCharm;
			}
		}
		if (GetGrowableElementShowingState(5) && GetGrowableElementShowingAbility(5))
		{
			AvatarAsset wrinkle3Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Wrinkle3, Wrinkle3Id);
			if (wrinkle3Asset != null)
			{
				charm += wrinkle3Asset.Config.ElemCharm;
			}
		}
		return charm;
	}

	public double CalCharmRate()
	{
		short frontHairId = FrontHairId;
		short backHairId = BackHairId;
		if (!GetGrowableElementShowingState(0) || !GetGrowableElementShowingAbility(0))
		{
			frontHairId = 1;
			backHairId = 1;
		}
		float charmRate = 1f;
		AvatarAsset frontHairAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Hair1, frontHairId);
		if (frontHairAsset != null)
		{
			charmRate = Math.Min(charmRate, frontHairAsset.Config.CharmExtraArg);
		}
		AvatarAsset backHairAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Hair2, backHairId);
		if (backHairAsset != null)
		{
			charmRate = Math.Min(charmRate, backHairAsset.Config.CharmExtraArg);
		}
		if (GetGrowableElementShowingAbility(1) && GetGrowableElementShowingState(1))
		{
			AvatarAsset beard1Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Beard1, Beard1Id);
			if (beard1Asset != null)
			{
				charmRate = Math.Min(charmRate, beard1Asset.Config.CharmExtraArg);
			}
		}
		if (GetGrowableElementShowingAbility(2) && GetGrowableElementShowingState(2))
		{
			AvatarAsset beard2Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Beard2, Beard2Id);
			if (beard2Asset != null)
			{
				charmRate = Math.Min(charmRate, beard2Asset.Config.CharmExtraArg);
			}
		}
		double feature2CharmRate = GetFeatureCharm().Item2;
		charmRate = Math.Min(charmRate, (float)feature2CharmRate);
		return charmRate;
	}

	public double GetBeard1Charm(short age)
	{
		if (!GetGrowableElementShowingState(1) || !GetGrowableElementShowingAbility(1))
		{
			return 0.0;
		}
		short beard1Charm = 0;
		AvatarAsset beard1Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Beard1, Beard1Id);
		if (beard1Asset != null)
		{
			beard1Charm = beard1Asset.Config.ElemCharm;
		}
		return beard1Charm;
	}

	public double GetBeard2Charm(short age)
	{
		if (!GetGrowableElementShowingState(2) || !GetGrowableElementShowingAbility(2))
		{
			return 0.0;
		}
		short beard2Charm = 0;
		AvatarAsset beard2Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Beard2, Beard2Id);
		if (beard2Asset != null)
		{
			beard2Charm = beard2Asset.Config.ElemCharm;
		}
		return beard2Charm;
	}

	public double GetClothCharm(short clothId)
	{
		short clothCharm = 0;
		AvatarAsset clothAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Cloth, clothId);
		if (clothAsset != null)
		{
			clothCharm = clothAsset.Config.ElemCharm;
		}
		return clothCharm;
	}

	public double GetMouthCharm()
	{
		double mouthCharm = 0.0;
		AvatarAsset mouthAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Mouth, MouthId);
		if (mouthAsset != null)
		{
			mouthCharm = mouthAsset.Config.ElemCharm;
		}
		return mouthCharm;
	}

	public double GetNoseCharm()
	{
		double noseCharm = 0.0;
		AvatarAsset noseAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Nose, NoseId);
		if (noseAsset != null)
		{
			noseCharm = noseAsset.Config.ElemCharm;
		}
		return noseCharm;
	}

	public double GetEyesCharm()
	{
		AvatarAsset leftEyeAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Eye, EyesMainId, EyesLeftId);
		AvatarAsset rightEyeAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Eye, EyesMainId, EyesRightId);
		return Math.Min(leftEyeAsset.Config.ElemCharm, rightEyeAsset.Config.ElemCharm);
	}

	public double GetEyebrowsCharm()
	{
		double charm = 0.0;
		AvatarAsset eyebrowAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.EyeBrow, EyebrowId);
		AvatarAsset headAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Head, HeadId);
		if (eyebrowAsset != null && headAsset != null)
		{
			charm = eyebrowAsset.Config.ElemCharm;
		}
		return charm;
	}

	/// <summary>
	/// 调整到目标魅力值
	/// </summary>
	/// <param name="random"></param>
	/// <param name="targetBaseCharm"></param>
	/// <returns></returns>
	public bool AdjustToBaseCharm(IRandomSource random, short targetBaseCharm)
	{
		_avatarGroup = AvatarManager.GetAvatarGroup(AvatarId);
		_headAsset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Head, HeadId);
		double targetCharm = targetBaseCharm;
		if (random.CheckProb(GlobalConfig.Instance.AvatarBadFeatureObb, 10000) && targetCharm / (double)_avatarGroup.WorstFeature2.Config.CharmExtraArg < 900.0)
		{
			AvatarAsset randomFeature2 = _avatarGroup.Feature2Res[random.Next(1, _avatarGroup.Feature2Res.Count)];
			Feature2Id = randomFeature2.Id;
			targetCharm /= (double)randomFeature2.Config.CharmExtraArg;
		}
		else
		{
			Feature2Id = 1;
		}
		AvatarAsset feature1Asset = AvatarManager.GetAsset(AvatarId, EAvatarElementsType.Feature1, Feature1Id);
		if (feature1Asset != null && feature1Asset.Config.ElemCharm != 0)
		{
			targetCharm -= (double)feature1Asset.Config.ElemCharm;
		}
		if (targetCharm <= 0.0)
		{
			targetCharm = targetBaseCharm;
			Feature1Id = 1;
		}
		double charmEyes = targetCharm * (double)GlobalConfig.Instance.EyesRatioInBaseCharm;
		double charmMouth = targetCharm * (double)GlobalConfig.Instance.MouthRatioInBaseCharm;
		double charmNose = targetCharm * (double)GlobalConfig.Instance.NoseRatioInBaseCharm;
		double charmEyebrow = targetCharm - charmEyes - charmMouth - charmNose;
		bool num = AdjustEyes(random, charmEyes);
		double eyesRealCharm = GetEyesCharm() * (double)GlobalConfig.Instance.EyesRatioInBaseCharm;
		charmMouth = targetCharm - eyesRealCharm - charmNose - charmEyebrow;
		bool adjustMouthResult = AdjustMouth(random, charmMouth);
		double mouthRealCharm = GetMouthCharm() * (double)GlobalConfig.Instance.MouthRatioInBaseCharm;
		charmNose = targetCharm - eyesRealCharm - mouthRealCharm - charmEyebrow;
		bool noseAdjustResult = AdjustNose(random, charmNose);
		double noseRealCharm = GetNoseCharm() * (double)GlobalConfig.Instance.NoseRatioInBaseCharm;
		charmEyebrow = targetCharm - eyesRealCharm - mouthRealCharm - noseRealCharm;
		bool adjustEyebrowResult = AdjustEyebrow(random, charmEyebrow);
		if (AttractionType.GetAttractionType(targetBaseCharm) == 0)
		{
			AvatarElementPositionItem positionCfg = PositionConfig;
			EyesHeight = GetTotalRandomOffsetShortVal(random, positionCfg.EyeHeightRange);
			EyesDistance = GetTotalRandomOffsetShortVal(random, positionCfg.EyeDistanceRange);
			EyesAngle = GetTotalRandomOffsetShortVal(random, positionCfg.EyeAngleRange);
			EyesScale = GetTotalRandomOffsetShortVal(random, positionCfg.EyeScaleRange);
			EyebrowHeight = GetTotalRandomOffsetShortVal(random, positionCfg.EyebrowHeightRange);
			EyebrowDistance = GetTotalRandomOffsetShortVal(random, positionCfg.EyebrowDistanceRange);
			EyebrowAngle = GetTotalRandomOffsetShortVal(random, positionCfg.EyebrowAngleRange);
			EyebrowScale = GetTotalRandomOffsetShortVal(random, positionCfg.EyebrowScaleRange);
			MouthHeight = GetTotalRandomOffsetShortVal(random, positionCfg.MouthHeightRange);
			MouthScale = GetTotalRandomOffsetShortVal(random, positionCfg.MouthScaleRange);
			NoseHeight = GetTotalRandomOffsetShortVal(random, positionCfg.NoseHeightRange);
			NoseScale = GetTotalRandomOffsetShortVal(random, positionCfg.NoseScaleRange);
		}
		_avatarGroup = null;
		_headAsset = null;
		return num && noseAdjustResult && adjustEyebrowResult && adjustMouthResult;
	}

	private bool AdjustEyebrow(IRandomSource random, double charm)
	{
		charm /= (double)GlobalConfig.Instance.EyebrowRatioInBaseCharm;
		List<AvatarAsset> bestEyebrows = new List<AvatarAsset>();
		double cacheCharmOffset = double.MaxValue;
		for (int i = 0; i < _avatarGroup.EyeBrowRes.Count; i++)
		{
			double offset = (double)_avatarGroup.EyeBrowRes[i].Config.ElemCharm - charm;
			if (bestEyebrows.Count <= 0)
			{
				cacheCharmOffset = offset;
				bestEyebrows.Add(_avatarGroup.EyeBrowRes[i]);
				continue;
			}
			if (Math.Abs(offset - cacheCharmOffset) < 0.20000000298023224)
			{
				bestEyebrows.Add(_avatarGroup.EyeBrowRes[i]);
				continue;
			}
			bool canReplace = Math.Abs(offset) < Math.Abs(cacheCharmOffset);
			if (canReplace)
			{
				if (offset < 0.0 && cacheCharmOffset > 0.0 && cacheCharmOffset < Math.Abs(offset) * 2.0)
				{
					canReplace = false;
				}
			}
			else if (offset > 0.0 && cacheCharmOffset < 0.0 && offset < Math.Abs(cacheCharmOffset) * 2.0)
			{
				canReplace = true;
			}
			if (canReplace)
			{
				bestEyebrows.Clear();
				cacheCharmOffset = offset;
				bestEyebrows.Add(_avatarGroup.EyeBrowRes[i]);
			}
		}
		if (bestEyebrows.Count <= 0)
		{
			return false;
		}
		AvatarAsset eyebrowAsset = bestEyebrows.GetRandom(random);
		EyebrowId = eyebrowAsset.Id;
		return (double)eyebrowAsset.Config.ElemCharm >= charm;
	}

	private bool AdjustEyes(IRandomSource random, double charm)
	{
		charm /= (double)GlobalConfig.Instance.EyesRatioInBaseCharm;
		List<EyeRes> bestEyes = new List<EyeRes>();
		double cacheCharmOffset = double.MaxValue;
		for (int i = 0; i < _avatarGroup.EyesGroup.Count; i++)
		{
			double offset = (double)Math.Min(_avatarGroup.EyesGroup[i].LeftEye.Config.ElemCharm, _avatarGroup.EyesGroup[i].RightEye.Config.ElemCharm) - charm;
			if (bestEyes.Count <= 0)
			{
				bestEyes.Add(_avatarGroup.EyesGroup[i]);
				cacheCharmOffset = offset;
				continue;
			}
			if (Math.Abs(offset - cacheCharmOffset) < 0.20000000298023224)
			{
				bestEyes.Add(_avatarGroup.EyesGroup[i]);
				continue;
			}
			bool canReplace = Math.Abs(offset) < Math.Abs(cacheCharmOffset);
			if (canReplace)
			{
				if (offset < 0.0 && cacheCharmOffset > 0.0 && cacheCharmOffset < Math.Abs(offset) * 2.0)
				{
					canReplace = false;
				}
			}
			else if (offset > 0.0 && cacheCharmOffset < 0.0 && offset < Math.Abs(cacheCharmOffset) * 2.0)
			{
				canReplace = true;
			}
			if (canReplace)
			{
				cacheCharmOffset = offset;
				bestEyes.Clear();
				bestEyes.Add(_avatarGroup.EyesGroup[i]);
			}
		}
		if (bestEyes.Count <= 0)
		{
			return false;
		}
		EyeRes eyeRes = bestEyes.GetRandom(random);
		short num = Math.Min(eyeRes.LeftEye.Config.ElemCharm, eyeRes.RightEye.Config.ElemCharm);
		EyesMainId = eyeRes.Id;
		EyesLeftId = eyeRes.LeftEye.SubId;
		EyesRightId = eyeRes.RightEye.SubId;
		return (double)num >= charm;
	}

	private bool AdjustNose(IRandomSource random, double charm)
	{
		charm /= (double)GlobalConfig.Instance.NoseRatioInBaseCharm;
		List<AvatarAsset> bestNose = new List<AvatarAsset>();
		double cacheCharmOffset = double.MaxValue;
		for (int i = 0; i < _avatarGroup.NoseRes.Count; i++)
		{
			double offset = (double)_avatarGroup.NoseRes[i].Config.ElemCharm - charm;
			if (bestNose.Count <= 0)
			{
				bestNose.Add(_avatarGroup.NoseRes[i]);
				cacheCharmOffset = offset;
				continue;
			}
			if (Math.Abs(offset - cacheCharmOffset) < 0.20000000298023224)
			{
				bestNose.Add(_avatarGroup.NoseRes[i]);
				continue;
			}
			bool canReplace = Math.Abs(offset) < Math.Abs(cacheCharmOffset);
			if (canReplace)
			{
				if (offset < 0.0 && cacheCharmOffset > 0.0 && cacheCharmOffset < Math.Abs(offset) * 2.0)
				{
					canReplace = false;
				}
			}
			else if (offset > 0.0 && cacheCharmOffset < 0.0 && offset < Math.Abs(cacheCharmOffset) * 2.0)
			{
				canReplace = true;
			}
			if (canReplace)
			{
				cacheCharmOffset = offset;
				bestNose.Clear();
				bestNose.Add(_avatarGroup.NoseRes[i]);
			}
		}
		if (bestNose.Count <= 0)
		{
			return false;
		}
		AvatarAsset noseAsset = bestNose.GetRandom(random);
		NoseId = noseAsset.Id;
		return (double)noseAsset.Config.ElemCharm >= charm;
	}

	private bool AdjustMouth(IRandomSource random, double charm)
	{
		charm /= (double)GlobalConfig.Instance.MouthRatioInBaseCharm;
		List<MouthRes> bestMouth = new List<MouthRes>();
		double cacheCharmOffset = double.MaxValue;
		for (int i = 0; i < _avatarGroup.MouthRes.Count; i++)
		{
			double offset = (double)_avatarGroup.MouthRes[i].Mouth.Config.ElemCharm - charm;
			if (bestMouth.Count <= 0)
			{
				cacheCharmOffset = offset;
				bestMouth.Add(_avatarGroup.MouthRes[i]);
				continue;
			}
			if (Math.Abs(offset - cacheCharmOffset) < 0.20000000298023224)
			{
				bestMouth.Add(_avatarGroup.MouthRes[i]);
				continue;
			}
			bool canReplace = Math.Abs(offset) < Math.Abs(cacheCharmOffset);
			if (canReplace)
			{
				if (offset < 0.0 && cacheCharmOffset > 0.0 && cacheCharmOffset < Math.Abs(offset) * 2.0)
				{
					canReplace = false;
				}
			}
			else if (offset > 0.0 && cacheCharmOffset < 0.0 && offset < Math.Abs(cacheCharmOffset) * 2.0)
			{
				canReplace = true;
			}
			if (canReplace)
			{
				bestMouth.Clear();
				cacheCharmOffset = offset;
				bestMouth.Add(_avatarGroup.MouthRes[i]);
			}
		}
		if (bestMouth.Count <= 0)
		{
			return false;
		}
		MouthRes mouthAsset = bestMouth.GetRandom(random);
		MouthId = mouthAsset.Id;
		return (double)mouthAsset.Mouth.Config.ElemCharm > charm;
	}
}
