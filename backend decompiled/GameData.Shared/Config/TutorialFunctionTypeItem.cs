using System;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialFunctionTypeItem : ConfigItem<TutorialFunctionTypeItem, short>
{
	public readonly short TemplateId;

	public TutorialFunctionTypeItem(short templateId)
	{
		TemplateId = templateId;
	}

	public TutorialFunctionTypeItem()
	{
		TemplateId = 0;
	}

	public TutorialFunctionTypeItem(short templateId, TutorialFunctionTypeItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TutorialFunctionTypeItem Duplicate(int templateId)
	{
		return new TutorialFunctionTypeItem((short)templateId, this);
	}
}
