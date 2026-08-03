using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableElementItem : ConfigItem<CharacterTableElementItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型
	/// - 决定了使用的预制体
	/// </summary>
	public readonly ECharacterTableElementType Type;

	/// <summary>
	/// 是否排序
	/// </summary>
	public readonly bool CanSort;

	/// <summary>
	/// 是否高亮
	/// </summary>
	public readonly bool CanHighlight;

	/// <summary>
	/// 是否需要异步加载
	/// - 如角色形象和特性加载很慢可以考虑异步
	/// </summary>
	public readonly bool NeedAsync;

	/// <summary>
	/// 是否隐藏属性
	/// - 非演化角色应该被隐藏的属性
	/// </summary>
	public readonly bool HideProperty;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">类型 - 决定了使用的预制体</param>
	/// <param name="canSort">是否排序</param>
	/// <param name="canHighlight">是否高亮</param>
	/// <param name="needAsync">是否需要异步加载 - 如角色形象和特性加载很慢可以考虑异步</param>
	/// <param name="hideProperty">是否隐藏属性 - 非演化角色应该被隐藏的属性</param>
	public CharacterTableElementItem(short templateId, string name, ECharacterTableElementType type, bool canSort, bool canHighlight, bool needAsync, bool hideProperty)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		CanSort = canSort;
		CanHighlight = canHighlight;
		NeedAsync = needAsync;
		HideProperty = hideProperty;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterTableElementItem()
	{
		TemplateId = 0;
		Name = null;
		Type = ECharacterTableElementType.Text;
		CanSort = true;
		CanHighlight = true;
		NeedAsync = false;
		HideProperty = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterTableElementItem(short templateId, CharacterTableElementItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		CanSort = other.CanSort;
		CanHighlight = other.CanHighlight;
		NeedAsync = other.NeedAsync;
		HideProperty = other.HideProperty;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterTableElementItem Duplicate(int templateId)
	{
		return new CharacterTableElementItem((short)templateId, this);
	}
}
