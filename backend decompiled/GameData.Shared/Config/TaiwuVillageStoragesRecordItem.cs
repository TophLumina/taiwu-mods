using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuVillageStoragesRecordItem : ConfigItem<TaiwuVillageStoragesRecordItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">显示名称</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	public TaiwuVillageStoragesRecordItem(short templateId, string name, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaiwuVillageStoragesRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaiwuVillageStoragesRecordItem(short templateId, TaiwuVillageStoragesRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaiwuVillageStoragesRecordItem Duplicate(int templateId)
	{
		return new TaiwuVillageStoragesRecordItem((short)templateId, this);
	}
}
