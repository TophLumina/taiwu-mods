using System;

namespace GameData.Serializer;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
public class SerializeAsAttribute : Attribute
{
	public Type ForceConvertType;

	public SerializeAsAttribute(Type forceConvertType)
	{
		ForceConvertType = forceConvertType;
	}
}
