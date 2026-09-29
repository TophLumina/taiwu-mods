using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarElementsItem : ConfigItem<AvatarElementsItem, uint>
{
	public readonly uint TemplateId;

	public readonly byte AvatarId;

	public readonly EAvatarElementsType Type;

	public readonly short ElementId;

	public readonly short ElemCharm;

	public readonly float CharmExtraArg;

	public readonly float[] Offset;

	public readonly bool Inherit;

	public readonly byte ColorGroup;

	public readonly string NameOrPath;

	public readonly short[] SpriteSize;

	public readonly byte ParentId;

	public readonly bool CanCreate;

	public readonly uint[] BanElements;

	public readonly short RelativeExtraPart;

	public readonly string HatBack;

	public readonly bool DisableRelativeType;

	public readonly bool ShouldMirrorEyes;

	public readonly bool CanMirror;

	public readonly byte DefaultMirrorType;

	public readonly bool ShouldHideMirrorObject;

	public readonly string[] SkeletonSlotAndAttachment;

	public readonly string ClothEffect;

	public readonly string ClothSkeletonName;

	public readonly bool HasCover;

	public readonly bool AboveEye;

	public AvatarElementsItem(uint templateId, byte avatarId, EAvatarElementsType type, short elementId, short elemCharm, float charmExtraArg, float[] offset, bool inherit, byte colorGroup, string nameOrPath, short[] spriteSize, byte parentId, bool canCreate, uint[] banElements, short relativeExtraPart, string hatBack, bool disableRelativeType, bool shouldMirrorEyes, bool canMirror, byte defaultMirrorType, bool shouldHideMirrorObject, string[] skeletonSlotAndAttachment, string clothEffect, string clothSkeletonName, bool hasCover, bool aboveEye)
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
		AboveEye = aboveEye;
	}

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
		AboveEye = false;
	}

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
		AboveEye = other.AboveEye;
	}

	public override int GetTemplateId()
	{
		return (int)TemplateId;
	}

	public override AvatarElementsItem Duplicate(int templateId)
	{
		return new AvatarElementsItem((uint)templateId, this);
	}
}
