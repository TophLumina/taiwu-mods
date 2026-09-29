using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class MainUiCustomButtonItem : ConfigItem<MainUiCustomButtonItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string IconNormal;

	public readonly string IconHighLight;

	public readonly string IconPressed;

	public readonly string IconDisable;

	public readonly bool Visible;

	public readonly int Category;

	public readonly short TutorialFunctionType;

	public readonly byte MainMenuButtonId;

	public MainMenuButtonItem MainMenuButton
	{
		[return: MaybeNull]
		get
		{
			return Config.MainMenuButton.Instance.GetItemOrDefault(MainMenuButtonId);
		}
	}

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

	public override MainUiCustomButtonItem Duplicate(int templateId)
	{
		return new MainUiCustomButtonItem((sbyte)templateId, this);
	}
}
