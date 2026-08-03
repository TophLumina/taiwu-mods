using System;

namespace GameData.Domains.Combat.MixPoison;

[AttributeUsage(AttributeTargets.Method)]
public class MixPoisonEffectAttribute : Attribute
{
	public sbyte TemplateId;

	public MixPoisonEffectAttribute(sbyte templateId)
	{
		TemplateId = templateId;
	}
}
