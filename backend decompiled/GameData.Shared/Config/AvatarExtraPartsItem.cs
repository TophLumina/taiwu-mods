using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarExtraPartsItem : ConfigItem<AvatarExtraPartsItem, short>
{
	/// <summary>
	/// 部件id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 所属AvatarId
	/// - 必填项
	/// </summary>
	public readonly byte AvatarId;

	/// <summary>
	/// 资源类型
	/// - 必填项
	/// </summary>
	public readonly EAvatarExtraPartsType Type;

	/// <summary>
	/// 资源名
	/// - 必填项
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 坐标跟随的物体名
	/// - 必填项
	/// </summary>
	public readonly string PositionFollow;

	/// <summary>
	/// 坐标跟随的偏移量
	/// - 本物体中心点距离目标物体的偏移，不同物体可能偏移原点不同，需要具体调试
	/// </summary>
	public readonly float[] PositionOffset;

	/// <summary>
	/// 层级跟随的物体名
	/// - 必填项
	/// </summary>
	public readonly string LayerFollow;

	/// <summary>
	/// 层级跟随的偏移量
	/// - 0是显示在层级跟随物体的上一级，大于0表示盖住指定层级，小于等于0表示只被指定层级盖住
	/// </summary>
	public readonly sbyte LayerOffset;

	/// <summary>
	/// 颜色跟随的物体名
	/// - 选填项
	/// </summary>
	public readonly string ColorFollow;

	/// <summary>
	/// 缩放跟随的物体名
	/// - 选填项
	/// </summary>
	public readonly string ScaleFollow;

	/// <summary>
	/// 动态立绘鸭头素材
	/// </summary>
	public readonly string DynamicDuckHead;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">部件id</param>
	/// <param name="avatarId">所属AvatarId - 必填项</param>
	/// <param name="type">资源类型 - 必填项</param>
	/// <param name="name">资源名 - 必填项</param>
	/// <param name="positionFollow">坐标跟随的物体名 - 必填项</param>
	/// <param name="positionOffset">坐标跟随的偏移量 - 本物体中心点距离目标物体的偏移，不同物体可能偏移原点不同，需要具体调试</param>
	/// <param name="layerFollow">层级跟随的物体名 - 必填项</param>
	/// <param name="layerOffset">层级跟随的偏移量 - 0是显示在层级跟随物体的上一级，大于0表示盖住指定层级，小于等于0表示只被指定层级盖住</param>
	/// <param name="colorFollow">颜色跟随的物体名 - 选填项</param>
	/// <param name="scaleFollow">缩放跟随的物体名 - 选填项</param>
	/// <param name="dynamicDuckHead">动态立绘鸭头素材</param>
	public AvatarExtraPartsItem(short templateId, byte avatarId, EAvatarExtraPartsType type, string name, string positionFollow, float[] positionOffset, string layerFollow, sbyte layerOffset, string colorFollow, string scaleFollow, string dynamicDuckHead)
	{
		TemplateId = templateId;
		AvatarId = avatarId;
		Type = type;
		Name = name;
		PositionFollow = positionFollow;
		PositionOffset = positionOffset;
		LayerFollow = layerFollow;
		LayerOffset = layerOffset;
		ColorFollow = colorFollow;
		ScaleFollow = scaleFollow;
		DynamicDuckHead = dynamicDuckHead;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AvatarExtraPartsItem()
	{
		TemplateId = 0;
		AvatarId = 0;
		Type = (EAvatarExtraPartsType)0;
		Name = null;
		PositionFollow = null;
		PositionOffset = new float[2];
		LayerFollow = null;
		LayerOffset = 0;
		ColorFollow = null;
		ScaleFollow = null;
		DynamicDuckHead = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AvatarExtraPartsItem(short templateId, AvatarExtraPartsItem other)
	{
		TemplateId = templateId;
		AvatarId = other.AvatarId;
		Type = other.Type;
		Name = other.Name;
		PositionFollow = other.PositionFollow;
		PositionOffset = other.PositionOffset;
		LayerFollow = other.LayerFollow;
		LayerOffset = other.LayerOffset;
		ColorFollow = other.ColorFollow;
		ScaleFollow = other.ScaleFollow;
		DynamicDuckHead = other.DynamicDuckHead;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarExtraPartsItem Duplicate(int templateId)
	{
		return new AvatarExtraPartsItem((short)templateId, this);
	}
}
