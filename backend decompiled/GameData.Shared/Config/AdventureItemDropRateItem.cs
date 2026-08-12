using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureItemDropRateItem : ConfigItem<AdventureItemDropRateItem, byte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 各个品阶物品的掉落几率
	/// - 当奇遇中某处的物品掉落是按照物品子类设置的，则需要根据奇遇难度和此表中的掉落机率计算掉落物品的品阶。
	/// </summary>
	public readonly short[] ItemGradeDropRate;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="itemGradeDropRate">各个品阶物品的掉落几率 - 当奇遇中某处的物品掉落是按照物品子类设置的，则需要根据奇遇难度和此表中的掉落机率计算掉落物品的品阶。</param>
	public AdventureItemDropRateItem(byte templateId, short[] itemGradeDropRate)
	{
		TemplateId = templateId;
		ItemGradeDropRate = itemGradeDropRate;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureItemDropRateItem()
	{
		TemplateId = 0;
		ItemGradeDropRate = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureItemDropRateItem(byte templateId, AdventureItemDropRateItem other)
	{
		TemplateId = templateId;
		ItemGradeDropRate = other.ItemGradeDropRate;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureItemDropRateItem Duplicate(int templateId)
	{
		return new AdventureItemDropRateItem((byte)templateId, this);
	}
}
