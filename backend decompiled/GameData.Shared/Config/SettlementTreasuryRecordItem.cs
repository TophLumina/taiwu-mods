using System;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryRecordItem : ConfigItem<SettlementTreasuryRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public SettlementTreasuryRecordItem(short templateId, string name, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
	}

	public SettlementTreasuryRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
	}

	public SettlementTreasuryRecordItem(short templateId, SettlementTreasuryRecordItem other)
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

	public override SettlementTreasuryRecordItem Duplicate(int templateId)
	{
		return new SettlementTreasuryRecordItem((short)templateId, this);
	}
}
