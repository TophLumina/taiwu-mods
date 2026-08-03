using System;

namespace GameData.Domains.Combat.Ai;

[AttributeUsage(AttributeTargets.Class)]
public class AiActionAttribute : Attribute
{
	public EAiActionType Type;

	public AiActionAttribute(EAiActionType type)
	{
		Type = type;
	}
}
