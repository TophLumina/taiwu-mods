using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarExtraPartsItem : ConfigItem<AvatarExtraPartsItem, short>
{
	public readonly short TemplateId;

	public readonly byte AvatarId;

	public readonly EAvatarExtraPartsType Type;

	public readonly string Name;

	public readonly string PositionFollow;

	public readonly float[] PositionOffset;

	public readonly string LayerFollow;

	public readonly sbyte LayerOffset;

	public readonly string ColorFollow;

	public readonly string ScaleFollow;

	public readonly string DynamicDuckHead;

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

	public override AvatarExtraPartsItem Duplicate(int templateId)
	{
		return new AvatarExtraPartsItem((short)templateId, this);
	}
}
