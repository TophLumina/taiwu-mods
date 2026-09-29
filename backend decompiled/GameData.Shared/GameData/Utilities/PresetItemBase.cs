using System;
using GameData.Serializer;

namespace GameData.Utilities;

[Serializable]
public abstract class PresetItemBase<T> : ISerializableGameData where T : PresetItemBase<T>
{
	public abstract void Clear();

	public abstract T Clone();

	public abstract bool IsSerializedSizeFixed();

	public abstract int GetSerializedSize();

	public unsafe abstract int Serialize(byte* pData);

	public unsafe abstract int Deserialize(byte* pData);
}
