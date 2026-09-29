using System;

namespace GameData.Serializer;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
public class SerializeToAttribute : Attribute
{
	public Type ForceConvertType;

	public SerializeToAttribute(Type forceConvertType)
	{
		ForceConvertType = forceConvertType;
	}
}
