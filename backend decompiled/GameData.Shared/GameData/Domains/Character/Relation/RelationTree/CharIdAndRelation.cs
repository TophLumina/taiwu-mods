using GameData.Serializer;

namespace GameData.Domains.Character.Relation.RelationTree;

[SerializableGameData(NotForDisplayModule = true)]
public struct CharIdAndRelation(int charId, ushort relationType) : ISerializableGameData
{
	public int CharId = charId;

	public ushort RelationType = relationType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharId;
		((short*)pData)[2] = (short)RelationType;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		CharId = *(int*)pData;
		RelationType = ((ushort*)pData)[2];
		return 8;
	}
}
