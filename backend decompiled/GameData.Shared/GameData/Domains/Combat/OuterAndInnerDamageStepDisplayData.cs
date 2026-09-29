using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct OuterAndInnerDamageStepDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public DamageStepDisplayData Outer;

	[SerializableGameDataField]
	public DamageStepDisplayData Inner;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 48;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Outer.Serialize(pCurrData);
		pCurrData += Inner.Serialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Outer.Deserialize(pCurrData);
		pCurrData += Inner.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
