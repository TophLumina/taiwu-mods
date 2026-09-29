using System;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoRecordItem : ConfigItem<JiaoRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public JiaoRecordItem(short templateId, string name, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
	}

	public JiaoRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = null;
	}

	public JiaoRecordItem(short templateId, JiaoRecordItem other)
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

	public override JiaoRecordItem Duplicate(int templateId)
	{
		return new JiaoRecordItem((short)templateId, this);
	}
}
