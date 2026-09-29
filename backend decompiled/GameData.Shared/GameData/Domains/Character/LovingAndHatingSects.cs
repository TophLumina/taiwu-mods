using GameData.Serializer;

namespace GameData.Domains.Character;

public struct LovingAndHatingSects : ISerializableGameData
{
	public unsafe fixed sbyte Items[10];

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
