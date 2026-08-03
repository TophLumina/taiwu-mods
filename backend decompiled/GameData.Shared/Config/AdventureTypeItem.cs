using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureTypeItem : ConfigItem<AdventureTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string DisplayName;

	/// <summary>
	/// 非关键奇遇
	/// - 是否为可被覆盖的非关键奇遇
	/// </summary>
	public readonly bool IsTrivial;

	/// <summary>
	/// 颜色名
	/// </summary>
	public readonly string ColorName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="displayName">显示名称</param>
	/// <param name="isTrivial">非关键奇遇 - 是否为可被覆盖的非关键奇遇</param>
	/// <param name="colorName">颜色名</param>
	public AdventureTypeItem(sbyte templateId, string displayName, bool isTrivial, string colorName)
	{
		TemplateId = templateId;
		DisplayName = displayName;
		IsTrivial = isTrivial;
		ColorName = colorName;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureTypeItem()
	{
		TemplateId = 0;
		DisplayName = null;
		IsTrivial = true;
		ColorName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureTypeItem(sbyte templateId, AdventureTypeItem other)
	{
		TemplateId = templateId;
		DisplayName = other.DisplayName;
		IsTrivial = other.IsTrivial;
		ColorName = other.ColorName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureTypeItem Duplicate(int templateId)
	{
		return new AdventureTypeItem((sbyte)templateId, this);
	}
}
