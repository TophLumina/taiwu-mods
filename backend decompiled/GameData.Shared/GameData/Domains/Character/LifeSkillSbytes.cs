using GameData.Serializer;

namespace GameData.Domains.Character;

public struct LifeSkillSbytes : ISerializableGameData
{
	public unsafe fixed sbyte Items[16];

	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 16;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
		}
		return 16;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
		}
		return 16;
	}

	public unsafe LifeSkillSbytes Subtract(LifeSkillSbytes other)
	{
		LifeSkillSbytes delta = default(LifeSkillSbytes);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe LifeSkillSbytes GetReversed()
	{
		LifeSkillSbytes reversed = default(LifeSkillSbytes);
		for (int i = 0; i < 16; i++)
		{
			reversed.Items[i] = (sbyte)(-Items[i]);
		}
		return reversed;
	}
}
