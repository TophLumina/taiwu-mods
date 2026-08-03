using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMapBlockButtonItem : ConfigItem<CharacterMapBlockButtonItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 按钮名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 按钮图标
	/// - 由公式自动生成
	/// </summary>
	public readonly string IconNormal;

	/// <summary>
	/// 按钮图标
	/// - 由公式自动生成
	/// </summary>
	public readonly string IconHighLight;

	/// <summary>
	/// 按钮图标
	/// - 由公式自动生成
	/// </summary>
	public readonly string IconPressed;

	/// <summary>
	/// 按钮图标
	/// - 由公式自动生成
	/// </summary>
	public readonly string IconDisable;

	/// <summary>
	/// 相关事件
	/// - Invalid == 不检查
	/// </summary>
	public readonly short InteractionEventOption;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">按钮名称</param>
	/// <param name="iconNormal">按钮图标 - 由公式自动生成</param>
	/// <param name="iconHighLight">按钮图标 - 由公式自动生成</param>
	/// <param name="iconPressed">按钮图标 - 由公式自动生成</param>
	/// <param name="iconDisable">按钮图标 - 由公式自动生成</param>
	/// <param name="interactionEventOption">相关事件 - Invalid == 不检查</param>
	public CharacterMapBlockButtonItem(sbyte templateId, string name, string iconNormal, string iconHighLight, string iconPressed, string iconDisable, short interactionEventOption)
	{
		TemplateId = templateId;
		Name = name;
		IconNormal = iconNormal;
		IconHighLight = iconHighLight;
		IconPressed = iconPressed;
		IconDisable = iconDisable;
		InteractionEventOption = interactionEventOption;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterMapBlockButtonItem()
	{
		TemplateId = 0;
		Name = null;
		IconNormal = null;
		IconHighLight = null;
		IconPressed = null;
		IconDisable = null;
		InteractionEventOption = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterMapBlockButtonItem(sbyte templateId, CharacterMapBlockButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IconNormal = other.IconNormal;
		IconHighLight = other.IconHighLight;
		IconPressed = other.IconPressed;
		IconDisable = other.IconDisable;
		InteractionEventOption = other.InteractionEventOption;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterMapBlockButtonItem Duplicate(int templateId)
	{
		return new CharacterMapBlockButtonItem((sbyte)templateId, this);
	}
}
