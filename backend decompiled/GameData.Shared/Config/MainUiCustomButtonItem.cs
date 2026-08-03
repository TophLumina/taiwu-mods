using System;
using Config.Common;

namespace Config;

[Serializable]
public class MainUiCustomButtonItem : ConfigItem<MainUiCustomButtonItem, sbyte>
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
	/// 是否完成
	/// </summary>
	public readonly bool Visible;

	/// <summary>
	/// 类别
	/// - (1:人物2:产业3:功能)
	/// </summary>
	public readonly int Category;

	/// <summary>
	/// 关联教学功能开关
	/// - 存在关联开关时, 如果开关关闭则按钮不可交互.
	/// </summary>
	public readonly short TutorialFunctionType;

	/// <summary>
	/// Tab按钮Id
	/// - 不为“产业视图”时转接到MainMenuButton。由于产业视图已经彻底ban掉了，所以此处使用产业视图作为invalid（程序里写 != DefKey.Building判定）
	/// </summary>
	public readonly byte MainMenuButtonId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">按钮名称</param>
	/// <param name="iconNormal">按钮图标 - 由公式自动生成</param>
	/// <param name="iconHighLight">按钮图标 - 由公式自动生成</param>
	/// <param name="iconPressed">按钮图标 - 由公式自动生成</param>
	/// <param name="iconDisable">按钮图标 - 由公式自动生成</param>
	/// <param name="visible">是否完成</param>
	/// <param name="category">类别 - (1:人物2:产业3:功能)</param>
	/// <param name="tutorialFunctionType">关联教学功能开关 - 存在关联开关时, 如果开关关闭则按钮不可交互.</param>
	/// <param name="mainMenuButtonId">Tab按钮Id - 不为“产业视图”时转接到MainMenuButton。由于产业视图已经彻底ban掉了，所以此处使用产业视图作为invalid（程序里写 != DefKey.Building判定）</param>
	public MainUiCustomButtonItem(sbyte templateId, string name, string iconNormal, string iconHighLight, string iconPressed, string iconDisable, bool visible, int category, short tutorialFunctionType, byte mainMenuButtonId)
	{
		TemplateId = templateId;
		Name = name;
		IconNormal = iconNormal;
		IconHighLight = iconHighLight;
		IconPressed = iconPressed;
		IconDisable = iconDisable;
		Visible = visible;
		Category = category;
		TutorialFunctionType = tutorialFunctionType;
		MainMenuButtonId = mainMenuButtonId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MainUiCustomButtonItem()
	{
		TemplateId = 0;
		Name = null;
		IconNormal = null;
		IconHighLight = null;
		IconPressed = null;
		IconDisable = null;
		Visible = true;
		Category = 1;
		TutorialFunctionType = 0;
		MainMenuButtonId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MainUiCustomButtonItem(sbyte templateId, MainUiCustomButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IconNormal = other.IconNormal;
		IconHighLight = other.IconHighLight;
		IconPressed = other.IconPressed;
		IconDisable = other.IconDisable;
		Visible = other.Visible;
		Category = other.Category;
		TutorialFunctionType = other.TutorialFunctionType;
		MainMenuButtonId = other.MainMenuButtonId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MainUiCustomButtonItem Duplicate(int templateId)
	{
		return new MainUiCustomButtonItem((sbyte)templateId, this);
	}
}
