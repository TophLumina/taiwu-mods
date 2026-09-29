using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkeletonItem : ConfigItem<CombatSkeletonItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string SkinName;

	public readonly float GlobalScale;

	public readonly float RootScale;

	public readonly float HeadScale;

	public readonly bool IsNotStandard;

	public readonly string[] Slots;

	public readonly string[] Attachments;

	public readonly string SpecialRightWeapon;

	public CombatSkeletonItem(sbyte templateId, string skinName, float globalScale, float rootScale, float headScale, bool isNotStandard, string[] slots, string[] attachments, string specialRightWeapon)
	{
		TemplateId = templateId;
		SkinName = skinName;
		GlobalScale = globalScale;
		RootScale = rootScale;
		HeadScale = headScale;
		IsNotStandard = isNotStandard;
		Slots = slots;
		Attachments = attachments;
		SpecialRightWeapon = specialRightWeapon;
	}

	public CombatSkeletonItem()
	{
		TemplateId = 0;
		SkinName = null;
		GlobalScale = 1f;
		RootScale = 1f;
		HeadScale = 1f;
		IsNotStandard = false;
		Slots = new string[0];
		Attachments = new string[0];
		SpecialRightWeapon = null;
	}

	public CombatSkeletonItem(sbyte templateId, CombatSkeletonItem other)
	{
		TemplateId = templateId;
		SkinName = other.SkinName;
		GlobalScale = other.GlobalScale;
		RootScale = other.RootScale;
		HeadScale = other.HeadScale;
		IsNotStandard = other.IsNotStandard;
		Slots = other.Slots;
		Attachments = other.Attachments;
		SpecialRightWeapon = other.SpecialRightWeapon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatSkeletonItem Duplicate(int templateId)
	{
		return new CombatSkeletonItem((sbyte)templateId, this);
	}
}
