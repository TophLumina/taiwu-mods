using System;

namespace GameData.Domains.TaiwuEvent.ValueSelector;

public class ValueConverterAttribute : Attribute
{
	public readonly Type SrcType;

	public readonly Type DstType;

	public ValueConverterAttribute(Type srcType, Type dstType)
	{
		SrcType = srcType;
		DstType = dstType;
	}
}
