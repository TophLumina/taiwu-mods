using System;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGameLevelItem : ConfigItem<JieqingGameLevelItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte SingPitch;

	public JieqingGameLevelItem(short templateId, sbyte singPitch)
	{
		TemplateId = templateId;
		SingPitch = singPitch;
	}

	public JieqingGameLevelItem()
	{
		TemplateId = 0;
		SingPitch = 0;
	}

	public JieqingGameLevelItem(short templateId, JieqingGameLevelItem other)
	{
		TemplateId = templateId;
		SingPitch = other.SingPitch;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override JieqingGameLevelItem Duplicate(int templateId)
	{
		return new JieqingGameLevelItem((short)templateId, this);
	}
}
