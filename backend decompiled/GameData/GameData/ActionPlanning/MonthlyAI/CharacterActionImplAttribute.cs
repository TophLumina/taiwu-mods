using System;

namespace GameData.ActionPlanning.MonthlyAI;

[AttributeUsage(AttributeTargets.Class)]
public class CharacterActionImplAttribute : Attribute
{
	public short ActionTemplateId;

	public CharacterActionImplAttribute(short templateId)
	{
		ActionTemplateId = templateId;
	}
}
