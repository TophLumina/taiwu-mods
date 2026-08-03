using System;

namespace GameData.Domains.Combat.Ai;

[AttributeUsage(AttributeTargets.Class)]
public class AiConditionAttribute : Attribute
{
	public EAiConditionType Type;

	public AiConditionAttribute(EAiConditionType type)
	{
		Type = type;
	}
}
