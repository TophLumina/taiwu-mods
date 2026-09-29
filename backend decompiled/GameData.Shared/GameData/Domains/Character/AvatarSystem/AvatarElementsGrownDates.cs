using GameData.Serializer;

namespace GameData.Domains.Character.AvatarSystem;

[SerializableGameData(NotForDisplayModule = true)]
public struct AvatarElementsGrownDates : ISerializableGameData
{
	public unsafe fixed int Items[7];

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
