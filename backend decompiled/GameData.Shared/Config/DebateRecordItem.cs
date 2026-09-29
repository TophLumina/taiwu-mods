using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateRecordItem : ConfigItem<DebateRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Desc;

	public readonly EDebateRecordParamType[] Parameters;

	public DebateRecordItem(short templateId, string desc, EDebateRecordParamType[] parameters)
	{
		TemplateId = templateId;
		Desc = desc;
		Parameters = parameters;
	}

	public DebateRecordItem()
	{
		TemplateId = 0;
		Desc = null;
		Parameters = new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		};
	}

	public DebateRecordItem(short templateId, DebateRecordItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DebateRecordItem Duplicate(int templateId)
	{
		return new DebateRecordItem((short)templateId, this);
	}
}
