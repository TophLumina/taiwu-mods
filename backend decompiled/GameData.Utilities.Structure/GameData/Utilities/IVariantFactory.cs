using System;

namespace GameData.Utilities;

public interface IVariantFactory
{
	ComplexVariantTypeId CreateTypeId(Type type);

	IVariant CreateVariant<T>(byte subType, int id, T value);

	IVariant CreateVariant(byte subType, int id);
}
