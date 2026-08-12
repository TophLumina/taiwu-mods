using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldResourceItem : ConfigItem<WorldResourceItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 影响因子
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] InfluenceFactors;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="influenceFactors">影响因子 - 该列由公式生成，禁止手动填写</param>
	public WorldResourceItem(byte templateId, short[] influenceFactors)
	{
		TemplateId = templateId;
		InfluenceFactors = influenceFactors;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WorldResourceItem()
	{
		TemplateId = 0;
		InfluenceFactors = new short[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WorldResourceItem(byte templateId, WorldResourceItem other)
	{
		TemplateId = templateId;
		InfluenceFactors = other.InfluenceFactors;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WorldResourceItem Duplicate(int templateId)
	{
		return new WorldResourceItem((byte)templateId, this);
	}
}
