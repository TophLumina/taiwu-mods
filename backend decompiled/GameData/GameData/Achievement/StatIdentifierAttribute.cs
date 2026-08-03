using System;

namespace GameData.Achievement;

[AttributeUsage(AttributeTargets.Method)]
internal class StatIdentifierAttribute : Attribute
{
	public readonly short Id;

	public StatIdentifierAttribute(short id)
	{
		Id = id;
	}
}
