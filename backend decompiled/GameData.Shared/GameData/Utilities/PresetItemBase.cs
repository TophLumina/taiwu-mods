using System;
using GameData.Serializer;

namespace GameData.Utilities;

/// <summary>
/// 预设项基类
/// </summary>
[Serializable]
public abstract class PresetItemBase<T> : ISerializableGameData where T : PresetItemBase<T>
{
	/// <summary>
	/// 清空预设
	/// </summary>
	public abstract void Clear();

	/// <summary>
	/// 深克隆自身
	/// </summary>
	public abstract T Clone();

	public abstract bool IsSerializedSizeFixed();

	public abstract int GetSerializedSize();

	public unsafe abstract int Serialize(byte* pData);

	public unsafe abstract int Deserialize(byte* pData);
}
