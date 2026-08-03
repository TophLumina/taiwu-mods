using System;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGamePeaceItem : ConfigItem<JieqingGamePeaceItem, short>
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
	/// 颜色
	/// </summary>
	public readonly string Color;

	/// <summary>
	/// 宽
	/// </summary>
	public readonly sbyte Width;

	/// <summary>
	/// 高
	/// </summary>
	public readonly sbyte Height;

	/// <summary>
	/// 形状
	/// - 表示从左到右，从上到下格子的top,right,bottom,left 占据情况
	/// </summary>
	public readonly bool[] Shape;

	/// <summary>
	/// 美术资源Index
	/// - 对应的美术资源Index
	/// </summary>
	public readonly sbyte ArtResourceIndex;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="color">颜色</param>
	/// <param name="width">宽</param>
	/// <param name="height">高</param>
	/// <param name="shape">形状 - 表示从左到右，从上到下格子的top,right,bottom,left 占据情况</param>
	/// <param name="artResourceIndex">美术资源Index - 对应的美术资源Index</param>
	public JieqingGamePeaceItem(short templateId, string name, string color, sbyte width, sbyte height, bool[] shape, sbyte artResourceIndex)
	{
		TemplateId = templateId;
		Name = name;
		Color = color;
		Width = width;
		Height = height;
		Shape = shape;
		ArtResourceIndex = artResourceIndex;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JieqingGamePeaceItem()
	{
		TemplateId = 0;
		Name = null;
		Color = null;
		Width = 0;
		Height = 0;
		Shape = null;
		ArtResourceIndex = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JieqingGamePeaceItem(short templateId, JieqingGamePeaceItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Color = other.Color;
		Width = other.Width;
		Height = other.Height;
		Shape = other.Shape;
		ArtResourceIndex = other.ArtResourceIndex;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JieqingGamePeaceItem Duplicate(int templateId)
	{
		return new JieqingGamePeaceItem((short)templateId, this);
	}
}
