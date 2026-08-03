using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeMapBlockItem : ConfigItem<AdventureRemakeMapBlockItem, short>
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
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 奇遇外圈数
	/// </summary>
	public readonly int CircleCount;

	/// <summary>
	/// 每圈高度范围
	/// - 归一化的高度范围(0,1)
	/// </summary>
	public readonly float[] CircleHeight;

	/// <summary>
	/// 平铺格子比例
	/// - 取值范围0~100，表示奇遇外地格平铺数量的比例
	/// </summary>
	public readonly int FlatPercentage;

	/// <summary>
	/// 平铺格子高度范围
	/// - 需要FlatPercentage有效才会生效，相邻的同组平铺格子高度相同
	/// </summary>
	public readonly float[] FlatHeight;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="circleCount">奇遇外圈数</param>
	/// <param name="circleHeight">每圈高度范围 - 归一化的高度范围(0,1)</param>
	/// <param name="flatPercentage">平铺格子比例 - 取值范围0~100，表示奇遇外地格平铺数量的比例</param>
	/// <param name="flatHeight">平铺格子高度范围 - 需要FlatPercentage有效才会生效，相邻的同组平铺格子高度相同</param>
	public AdventureRemakeMapBlockItem(short templateId, string name, string desc, int circleCount, float[] circleHeight, int flatPercentage, float[] flatHeight)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		CircleCount = circleCount;
		CircleHeight = circleHeight;
		FlatPercentage = flatPercentage;
		FlatHeight = flatHeight;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureRemakeMapBlockItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		CircleCount = 0;
		CircleHeight = new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f };
		FlatPercentage = -1;
		FlatHeight = new float[2] { 0.5f, 0.5f };
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureRemakeMapBlockItem(short templateId, AdventureRemakeMapBlockItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		CircleCount = other.CircleCount;
		CircleHeight = other.CircleHeight;
		FlatPercentage = other.FlatPercentage;
		FlatHeight = other.FlatHeight;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureRemakeMapBlockItem Duplicate(int templateId)
	{
		return new AdventureRemakeMapBlockItem((short)templateId, this);
	}
}
