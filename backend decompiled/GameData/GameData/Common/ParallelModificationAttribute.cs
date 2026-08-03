using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Field)]
public class ParallelModificationAttribute : Attribute
{
	public readonly ushort DomainId;

	public readonly string ClassName;

	public readonly string MethodName;

	public ParallelModificationAttribute(ushort domainId, string methodName)
	{
		DomainId = domainId;
		MethodName = methodName;
	}

	public ParallelModificationAttribute(string className, string methodName)
	{
		DomainId = ushort.MaxValue;
		ClassName = className;
		MethodName = methodName;
	}
}
