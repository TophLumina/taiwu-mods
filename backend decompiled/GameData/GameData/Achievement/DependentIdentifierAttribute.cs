using System;

namespace GameData.Achievement;

[AttributeUsage(AttributeTargets.Method)]
internal class DependentIdentifierAttribute : Attribute
{
	public readonly short Id;

	public DependentIdentifierAttribute(EDependent id)
	{
		Id = (short)id;
	}
}
