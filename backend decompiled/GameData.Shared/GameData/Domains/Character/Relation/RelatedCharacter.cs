using GameData.Serializer;

namespace GameData.Domains.Character.Relation;

/// <summary>
/// 关系人
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public struct RelatedCharacter(ushort relationType, short favorability, int establishmentDate) : ISerializableGameData
{
	/// <summary>
	/// 关系类型, 包含多种关系.
	/// <see cref="T:GameData.Domains.Character.Relation.RelationType" />
	/// </summary>
	public ushort RelationType = relationType;

	/// <summary>
	/// 自己对此人的好感
	/// </summary>
	public short Favorability = favorability;

	/// <summary>
	/// 关系建立日期 (从第一年一月开始经过的月份数)
	/// </summary>
	public int EstablishmentDate = establishmentDate;

	/// <summary>
	/// 好感类型
	/// </summary>
	/// <returns></returns>
	public sbyte GetFavorabilityType()
	{
		return FavorabilityType.GetFavorabilityType(Favorability);
	}

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
		*(ushort*)pData = RelationType;
		((short*)pData)[1] = Favorability;
		((int*)pData)[1] = EstablishmentDate;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		RelationType = *(ushort*)pData;
		Favorability = ((short*)pData)[1];
		EstablishmentDate = ((int*)pData)[1];
		return 8;
	}
}
