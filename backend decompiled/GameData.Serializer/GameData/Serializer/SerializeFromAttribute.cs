using System;

namespace GameData.Serializer;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = true)]
public class SerializeFromAttribute : Attribute
{
	public Type SrcType;

	public SerializeFromAttribute(Type srcType)
	{
		SrcType = srcType;
	}
}
