using GameData.Serializer;

namespace GameData.Domains.Character.AvatarSystem;

/// <summary>
/// 角色形象部件的生长进度 (实际上是会生长出来的日期)
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public struct AvatarElementsGrownDates : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" />
	/// </summary>
	public unsafe fixed int Items[7];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 AvatarGrowableElementType.Count == 7.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (int* items = Items)
		{
			*(long*)items = -1L;
			((long*)items)[1] = -1L;
			((long*)items)[2] = -1L;
			items[6] = -1;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 28;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (int* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
			((int*)pData)[6] = pItems[6];
		}
		return 28;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (int* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
			items[6] = ((int*)pData)[6];
		}
		return 28;
	}

	/// <summary>
	/// 返回是否包含有效数据
	/// </summary>
	/// <returns></returns>
	public unsafe bool ContainsValidData()
	{
		for (int i = 0; i < 7; i++)
		{
			if (Items[i] >= 0)
			{
				return true;
			}
		}
		return false;
	}
}
