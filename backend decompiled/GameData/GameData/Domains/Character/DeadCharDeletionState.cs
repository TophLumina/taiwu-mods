using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true)]
public struct DeadCharDeletionState : ISerializableGameData
{
	public bool GraveRemoved;

	public bool DeletedFromOthersPreexistence;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 2;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (GraveRemoved ? ((byte)1) : ((byte)0));
		pData[1] = (DeletedFromOthersPreexistence ? ((byte)1) : ((byte)0));
		return 2;
	}

	public unsafe int Deserialize(byte* pData)
	{
		GraveRemoved = *pData != 0;
		DeletedFromOthersPreexistence = pData[1] != 0;
		return 2;
	}
}
