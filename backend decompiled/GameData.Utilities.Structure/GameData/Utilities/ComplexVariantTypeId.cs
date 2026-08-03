using System;
using GameData.Serializer;

namespace GameData.Utilities;

public struct ComplexVariantTypeId : ISerializableGameData
{
	public enum EType : sbyte
	{
		Custom,
		String
	}

	public EType Type;

	public byte SubType;

	public int Id;

	public static readonly ComplexVariantTypeId String = new ComplexVariantTypeId
	{
		Type = EType.String,
		Id = -1
	};

	public static readonly ComplexVariantTypeId Invalid = new ComplexVariantTypeId
	{
		Type = EType.Custom,
		Id = -1
	};

	public static IVariantFactory VariantFactory;

	public IVariant CreateVariantObject()
	{
		return Type switch
		{
			EType.Custom => VariantFactory.CreateVariant(SubType, Id), 
			EType.String => new StringValue(), 
			_ => throw new InvalidOperationException($"Unable to create variant with type {Type} and id {Id}"), 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 6;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)Type;
		byte* num = pData + 1;
		*num = SubType;
		byte* num2 = num + 1;
		*(int*)num2 = Id;
		return (int)(num2 + 4 - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Type = (EType)(*pCurrData);
		pCurrData++;
		SubType = *pCurrData;
		pCurrData++;
		Id = *(int*)pCurrData;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}
}
