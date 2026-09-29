using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Creation;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class ChallengeModeInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public short ReincarnationBonusFeatureId = -1;

	public ChallengeModeInfo()
	{
	}

	public ChallengeModeInfo(ChallengeModeInfo other)
	{
		ReincarnationBonusFeatureId = other.ReincarnationBonusFeatureId;
	}

	public void Assign(ChallengeModeInfo other)
	{
		ReincarnationBonusFeatureId = other.ReincarnationBonusFeatureId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = ReincarnationBonusFeatureId;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ReincarnationBonusFeatureId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
