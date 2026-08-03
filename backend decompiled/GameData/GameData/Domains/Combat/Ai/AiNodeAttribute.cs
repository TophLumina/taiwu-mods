using System;

namespace GameData.Domains.Combat.Ai;

[AttributeUsage(AttributeTargets.Class)]
public class AiNodeAttribute : Attribute
{
	public EAiNodeType Type;

	public AiNodeAttribute(EAiNodeType type)
	{
		Type = type;
	}
}
