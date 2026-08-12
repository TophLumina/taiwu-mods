using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreationItem : ConfigItem<WorldCreationItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string[] Icons;

	/// <summary>
	/// 选项
	/// </summary>
	public readonly string[] Options;

	/// <summary>
	/// 影响因子
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] InfluenceFactors;

	/// <summary>
	/// 遗惠加成
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] LegacyPointBonus;

	/// <summary>
	/// 次级影响因子
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] SecondaryInfluenceFactors;

	/// <summary>
	/// 能否在传承时修改
	/// - 0为不可修改，1为可以修改
	/// </summary>
	public readonly bool ShowInLegacy;

	/// <summary>
	/// 难度预设值
	/// </summary>
	public readonly sbyte[] DifficultyPreset;

	/// <summary>
	/// 提供传承点数
	/// </summary>
	public readonly sbyte[] AddProtagonistPoint;

	/// <summary>
	/// 保存在设置文件时的Key
	/// </summary>
	public readonly string SaveFileKey;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="icons">图标</param>
	/// <param name="options">选项</param>
	/// <param name="influenceFactors">影响因子 - 该列由公式生成，禁止手动填写</param>
	/// <param name="legacyPointBonus">遗惠加成 - 该列由公式生成，禁止手动填写</param>
	/// <param name="secondaryInfluenceFactors">次级影响因子 - 该列由公式生成，禁止手动填写</param>
	/// <param name="showInLegacy">能否在传承时修改 - 0为不可修改，1为可以修改</param>
	/// <param name="difficultyPreset">难度预设值</param>
	/// <param name="addProtagonistPoint">提供传承点数</param>
	/// <param name="saveFileKey">保存在设置文件时的Key</param>
	public WorldCreationItem(byte templateId, string name, string desc, string[] icons, string[] options, short[] influenceFactors, short[] legacyPointBonus, short[] secondaryInfluenceFactors, bool showInLegacy, sbyte[] difficultyPreset, sbyte[] addProtagonistPoint, string saveFileKey)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icons = icons;
		Options = options;
		InfluenceFactors = influenceFactors;
		LegacyPointBonus = legacyPointBonus;
		SecondaryInfluenceFactors = secondaryInfluenceFactors;
		ShowInLegacy = showInLegacy;
		DifficultyPreset = difficultyPreset;
		AddProtagonistPoint = addProtagonistPoint;
		SaveFileKey = saveFileKey;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WorldCreationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icons = null;
		Options = null;
		InfluenceFactors = new short[0];
		LegacyPointBonus = new short[0];
		SecondaryInfluenceFactors = new short[0];
		ShowInLegacy = false;
		DifficultyPreset = null;
		AddProtagonistPoint = new sbyte[0];
		SaveFileKey = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WorldCreationItem(byte templateId, WorldCreationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icons = other.Icons;
		Options = other.Options;
		InfluenceFactors = other.InfluenceFactors;
		LegacyPointBonus = other.LegacyPointBonus;
		SecondaryInfluenceFactors = other.SecondaryInfluenceFactors;
		ShowInLegacy = other.ShowInLegacy;
		DifficultyPreset = other.DifficultyPreset;
		AddProtagonistPoint = other.AddProtagonistPoint;
		SaveFileKey = other.SaveFileKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WorldCreationItem Duplicate(int templateId)
	{
		return new WorldCreationItem((byte)templateId, this);
	}
}
