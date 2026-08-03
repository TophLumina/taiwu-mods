using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkeletonItem : ConfigItem<CombatSkeletonItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 皮肤名称
	/// </summary>
	public readonly string SkinName;

	/// <summary>
	/// 全局缩放
	/// - 作用于动画对象（gameObject）的缩放，在动画内部控制过 scale 的时候使用
	/// </summary>
	public readonly float GlobalScale;

	/// <summary>
	/// 骨骼缩放
	/// - 作用于骨骼根节点（root）的缩放
	/// </summary>
	public readonly float RootScale;

	/// <summary>
	/// 头部缩放
	/// - 作用于骨骼头部节点（root/ROLL/waist/body/head）的缩放
	/// </summary>
	public readonly float HeadScale;

	/// <summary>
	/// 非标准模型
	/// - 部分模型不存在通用插槽（如动物），此时需将本列填为真值避免设置时出现报错
	/// </summary>
	public readonly bool IsNotStandard;

	/// <summary>
	/// 插槽名
	/// - 插槽名与附件名必须逐一匹配
	/// </summary>
	public readonly string[] Slots;

	/// <summary>
	/// 附件名
	/// </summary>
	public readonly string[] Attachments;

	/// <summary>
	/// 特定右手武器
	/// </summary>
	public readonly string SpecialRightWeapon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="skinName">皮肤名称</param>
	/// <param name="globalScale">全局缩放 - 作用于动画对象（gameObject）的缩放，在动画内部控制过 scale 的时候使用</param>
	/// <param name="rootScale">骨骼缩放 - 作用于骨骼根节点（root）的缩放</param>
	/// <param name="headScale">头部缩放 - 作用于骨骼头部节点（root/ROLL/waist/body/head）的缩放</param>
	/// <param name="isNotStandard">非标准模型 - 部分模型不存在通用插槽（如动物），此时需将本列填为真值避免设置时出现报错</param>
	/// <param name="slots">插槽名 - 插槽名与附件名必须逐一匹配</param>
	/// <param name="attachments">附件名</param>
	/// <param name="specialRightWeapon">特定右手武器</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatSkeletonItem Duplicate(int templateId)
	{
		return new CombatSkeletonItem((sbyte)templateId, this);
	}
}
