using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Method)]
public class DomainMethodAttribute : Attribute
{
	public bool IsPassthrough;
}
