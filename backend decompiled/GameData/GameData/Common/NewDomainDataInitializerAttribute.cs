using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Method)]
public class NewDomainDataInitializerAttribute : Attribute
{
	public readonly ushort DomainId;

	public readonly ushort DataId;

	public NewDomainDataInitializerAttribute(ushort domainId, ushort dataId)
	{
		DomainId = domainId;
		DataId = dataId;
	}
}
