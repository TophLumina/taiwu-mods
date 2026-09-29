using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheckItem : ConfigItem<InteractCheckItem, short>
{
	public readonly short TemplateId;

	public readonly short[] ActionPhaseList;

	public readonly short[] EscapePhaseList;

	public readonly bool CheckAllPhase;

	public InteractCheckItem(short templateId, short[] actionPhaseList, short[] escapePhaseList, bool checkAllPhase)
	{
		TemplateId = templateId;
		ActionPhaseList = actionPhaseList;
		EscapePhaseList = escapePhaseList;
		CheckAllPhase = checkAllPhase;
	}

	public InteractCheckItem()
	{
		TemplateId = 0;
		ActionPhaseList = null;
		EscapePhaseList = new short[1] { -1 };
		CheckAllPhase = false;
	}

	public InteractCheckItem(short templateId, InteractCheckItem other)
	{
		TemplateId = templateId;
		ActionPhaseList = other.ActionPhaseList;
		EscapePhaseList = other.EscapePhaseList;
		CheckAllPhase = other.CheckAllPhase;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override InteractCheckItem Duplicate(int templateId)
	{
		return new InteractCheckItem((short)templateId, this);
	}
}
