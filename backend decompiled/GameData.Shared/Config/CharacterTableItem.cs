using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableItem : ConfigItem<CharacterTableItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 类型
	/// - 用于Unity组件的添加
	/// </summary>
	public readonly ECharacterTableType Type;

	/// <summary>
	/// 元素
	/// </summary>
	public readonly List<short> Elements;

	/// <summary>
	/// 列宽
	/// - 和元素一一对应
	/// </summary>
	public readonly List<int> Width;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="title">标题</param>
	/// <param name="type">类型 - 用于Unity组件的添加</param>
	/// <param name="elements">元素</param>
	/// <param name="width">列宽 - 和元素一一对应</param>
	public CharacterTableItem(short templateId, string title, ECharacterTableType type, List<short> elements, List<int> width)
	{
		TemplateId = templateId;
		Title = title;
		Type = type;
		Elements = elements;
		Width = width;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterTableItem()
	{
		TemplateId = 0;
		Title = null;
		Type = ECharacterTableType.Invalid;
		Elements = null;
		Width = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterTableItem(short templateId, CharacterTableItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		Type = other.Type;
		Elements = other.Elements;
		Width = other.Width;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterTableItem Duplicate(int templateId)
	{
		return new CharacterTableItem((short)templateId, this);
	}
}
