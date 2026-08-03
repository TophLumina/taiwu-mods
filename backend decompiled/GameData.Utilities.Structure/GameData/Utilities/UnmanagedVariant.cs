using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class UnmanagedVariant<T> : Variant<T> where T : unmanaged
{
	public UnmanagedVariant()
	{
	}

	public UnmanagedVariant(T value)
		: base(value)
	{
	}

	public override IVariant Duplicate()
	{
		return new UnmanagedVariant<T>(Value);
	}

	public sealed override bool IsSerializedSizeFixed()
	{
		return true;
	}

	public unsafe sealed override int GetSerializedSize()
	{
		return sizeof(T);
	}

	public unsafe sealed override int Serialize(byte* pData)
	{
		*(T*)pData = Value;
		return sizeof(T);
	}

	public unsafe sealed override int Deserialize(byte* pData)
	{
		Value = *(T*)pData;
		return sizeof(T);
	}
}
