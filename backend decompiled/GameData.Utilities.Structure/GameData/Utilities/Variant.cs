using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public abstract class Variant<T> : IVariant, ISerializableGameData
{
	public T Value;

	protected Variant()
	{
	}

	protected Variant(T value)
	{
		Value = value;
	}

	public abstract IVariant Duplicate();

	public object GetValue()
	{
		return Value;
	}

	public abstract bool IsSerializedSizeFixed();

	public abstract int GetSerializedSize();

	public unsafe abstract int Serialize(byte* pData);

	public unsafe abstract int Deserialize(byte* pData);
}
