using System;

namespace GameData.DomainEvents;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Delegate)]
public class DomainEventAttribute : Attribute
{
	public int MaxReenterCount = 0;
}
