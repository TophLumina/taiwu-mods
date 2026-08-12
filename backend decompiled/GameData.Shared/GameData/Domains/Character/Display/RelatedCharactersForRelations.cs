using GameData.Domains.Character.Relation;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 关系界面用关系人集合
/// </summary>
public class RelatedCharactersForRelations : ISerializableGameData
{
	/// <summary>
	/// 父母
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Parents;

	/// <summary>
	/// 子女
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Children;

	/// <summary>
	/// 手足
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet BrothersAndSisters;

	/// <summary>
	/// 结义
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet SwornBrothersAndSisters;

	/// <summary>
	/// 夫妻
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet HusbandsAndWives;

	/// <summary>
	/// 师父
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Mentors;

	/// <summary>
	/// 朋友
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Friends;

	/// <summary>
	/// 爱慕
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Adored;

	/// <summary>
	/// 爱慕自己
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet RelatedAdored;

	/// <summary>
	/// 仇视
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Enemies;

	/// <summary>
	/// 仇视自己
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet RelatedEnemies;

	/// <summary>
	/// 派系成员
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet FactionMembers;

	/// <summary>
	/// 派系头目角色 Id
	/// </summary>
	[SerializableGameDataField]
	public int FactionLeaderId;

	public RelatedCharactersForRelations(RelatedCharacters relatedChars)
	{
		Parents.AddRange(relatedChars.BloodParents.GetCollection());
		Parents.AddRange(relatedChars.StepParents.GetCollection());
		Parents.AddRange(relatedChars.AdoptiveParents.GetCollection());
		Children.AddRange(relatedChars.BloodChildren.GetCollection());
		Children.AddRange(relatedChars.StepChildren.GetCollection());
		Children.AddRange(relatedChars.AdoptiveChildren.GetCollection());
		BrothersAndSisters.AddRange(relatedChars.BloodBrothersAndSisters.GetCollection());
		BrothersAndSisters.AddRange(relatedChars.StepBrothersAndSisters.GetCollection());
		BrothersAndSisters.AddRange(relatedChars.AdoptiveBrothersAndSisters.GetCollection());
		SwornBrothersAndSisters.AddRange(relatedChars.SwornBrothersAndSisters.GetCollection());
		HusbandsAndWives.AddRange(relatedChars.HusbandsAndWives.GetCollection());
		Mentors.AddRange(relatedChars.Mentors.GetCollection());
		Friends.AddRange(relatedChars.Friends.GetCollection());
		Adored.AddRange(relatedChars.Adored.GetCollection());
		Enemies.AddRange(relatedChars.Enemies.GetCollection());
		FactionLeaderId = -1;
	}

	public RelatedCharactersForRelations()
	{
		FactionLeaderId = -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += Parents.GetSerializedSize();
		totalSize += Children.GetSerializedSize();
		totalSize += BrothersAndSisters.GetSerializedSize();
		totalSize += SwornBrothersAndSisters.GetSerializedSize();
		totalSize += HusbandsAndWives.GetSerializedSize();
		totalSize += Mentors.GetSerializedSize();
		totalSize += Friends.GetSerializedSize();
		totalSize += Adored.GetSerializedSize();
		totalSize += RelatedAdored.GetSerializedSize();
		totalSize += Enemies.GetSerializedSize();
		totalSize += RelatedEnemies.GetSerializedSize();
		totalSize += FactionMembers.GetSerializedSize();
		totalSize += 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int fieldSize = Parents.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = Children.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int fieldSize3 = BrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		int fieldSize4 = SwornBrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		int fieldSize5 = HusbandsAndWives.Serialize(pCurrData);
		pCurrData += fieldSize5;
		Tester.Assert(fieldSize5 <= 65535);
		int fieldSize6 = Mentors.Serialize(pCurrData);
		pCurrData += fieldSize6;
		Tester.Assert(fieldSize6 <= 65535);
		int fieldSize7 = Friends.Serialize(pCurrData);
		pCurrData += fieldSize7;
		Tester.Assert(fieldSize7 <= 65535);
		int fieldSize8 = Adored.Serialize(pCurrData);
		pCurrData += fieldSize8;
		Tester.Assert(fieldSize8 <= 65535);
		int fieldSize9 = RelatedAdored.Serialize(pCurrData);
		pCurrData += fieldSize9;
		Tester.Assert(fieldSize9 <= 65535);
		int fieldSize10 = Enemies.Serialize(pCurrData);
		pCurrData += fieldSize10;
		Tester.Assert(fieldSize10 <= 65535);
		int fieldSize11 = RelatedEnemies.Serialize(pCurrData);
		pCurrData += fieldSize11;
		Tester.Assert(fieldSize11 <= 65535);
		int fieldSize12 = FactionMembers.Serialize(pCurrData);
		pCurrData += fieldSize12;
		Tester.Assert(fieldSize12 <= 65535);
		*(int*)pCurrData = FactionLeaderId;
		pCurrData += 4;
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
		pCurrData += Parents.Deserialize(pCurrData);
		pCurrData += Children.Deserialize(pCurrData);
		pCurrData += BrothersAndSisters.Deserialize(pCurrData);
		pCurrData += SwornBrothersAndSisters.Deserialize(pCurrData);
		pCurrData += HusbandsAndWives.Deserialize(pCurrData);
		pCurrData += Mentors.Deserialize(pCurrData);
		pCurrData += Friends.Deserialize(pCurrData);
		pCurrData += Adored.Deserialize(pCurrData);
		pCurrData += RelatedAdored.Deserialize(pCurrData);
		pCurrData += Enemies.Deserialize(pCurrData);
		pCurrData += RelatedEnemies.Deserialize(pCurrData);
		pCurrData += FactionMembers.Deserialize(pCurrData);
		FactionLeaderId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
