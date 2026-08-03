using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 角色喜好及厌恶的门派
/// </summary>
public struct LovingAndHatingSects : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 每种立场 2 字节, 第一个字节为喜好门派, 第二个字节为厌恶门派.
	/// <see cref="T:GameData.Domains.Character.BehaviorType" />
	/// </summary>
	public unsafe fixed sbyte Items[10];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 BehaviorType.Count == 5.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = -1L;
			((short*)items)[4] = -1;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 10;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((short*)pData)[4] = ((short*)pItems)[4];
		}
		return 10;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((short*)items)[4] = ((short*)pData)[4];
		}
		return 10;
	}
}
