using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation;

/// <summary>
/// 单个角色的关系人集合
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class RelatedCharacters : ISerializableGameData
{
	/// <summary>
	/// 非特殊关系
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet General;

	/// <summary>
	/// 血亲父母
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet BloodParents;

	/// <summary>
	/// 血亲子女
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet BloodChildren;

	/// <summary>
	/// 血亲手足 (血亲父母的血亲子女)
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet BloodBrothersAndSisters;

	/// <summary>
	/// 继亲父母
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet StepParents;

	/// <summary>
	/// 继亲子女
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet StepChildren;

	/// <summary>
	/// 继亲手足 (血亲父母的继亲子女 + 继亲父母的血亲子女 + 继亲父母的继亲子女)
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet StepBrothersAndSisters;

	/// <summary>
	/// 义亲父母
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet AdoptiveParents;

	/// <summary>
	/// 义亲子女
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet AdoptiveChildren;

	/// <summary>
	/// 义亲手足 (血亲父母的义亲子女 + 继亲父母的义亲子女 + 义亲父母的血亲子女 + 义亲父母的继亲子女 + 义亲父母的义亲子女)
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet AdoptiveBrothersAndSisters;

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
	/// 徒弟
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Mentees;

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
	/// 仇视
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet Enemies;

	/// <summary>
	/// 单个角色的关系人集合
	/// </summary>
	public RelatedCharacters()
	{
		General = default(CharacterSet);
		BloodParents = default(CharacterSet);
		BloodChildren = default(CharacterSet);
		BloodBrothersAndSisters = default(CharacterSet);
		StepParents = default(CharacterSet);
		StepChildren = default(CharacterSet);
		StepBrothersAndSisters = default(CharacterSet);
		AdoptiveParents = default(CharacterSet);
		AdoptiveChildren = default(CharacterSet);
		AdoptiveBrothersAndSisters = default(CharacterSet);
		SwornBrothersAndSisters = default(CharacterSet);
		HusbandsAndWives = default(CharacterSet);
		Mentors = default(CharacterSet);
		Mentees = default(CharacterSet);
		Friends = default(CharacterSet);
		Adored = default(CharacterSet);
		Enemies = default(CharacterSet);
	}

	/// <summary>
	/// 添加指定关系的关系人
	/// </summary>
	/// <param name="relatedCharId"></param>
	/// <param name="relationType"></param>
	public void Add(int relatedCharId, ushort relationType)
	{
		CharacterSet set = GetCharacterSet(relationType);
		if (set.Add(relatedCharId))
		{
			SetCharacterSet(relationType, set);
		}
	}

	/// <summary>
	/// 移除关系人的指定关系
	/// </summary>
	/// <param name="relatedCharId"></param>
	/// <param name="relationType"></param>
	public void Remove(int relatedCharId, ushort relationType)
	{
		CharacterSet set = GetCharacterSet(relationType);
		if (set.Remove(relatedCharId).Item1)
		{
			SetCharacterSet(relationType, set);
		}
	}

	/// <summary>
	/// 清空所有集合, 但不提交数据 (用于删除集合对象前的子对象回收)
	/// </summary>
	public void OfflineClear()
	{
		General.Clear();
		BloodParents.Clear();
		BloodChildren.Clear();
		BloodBrothersAndSisters.Clear();
		StepParents.Clear();
		StepChildren.Clear();
		StepBrothersAndSisters.Clear();
		AdoptiveParents.Clear();
		AdoptiveChildren.Clear();
		AdoptiveBrothersAndSisters.Clear();
		SwornBrothersAndSisters.Clear();
		HusbandsAndWives.Clear();
		Mentors.Clear();
		Mentees.Clear();
		Friends.Clear();
		Adored.Clear();
		Enemies.Clear();
	}

	/// <summary>
	/// 通过关系类型获取对应的关系集合.
	/// 返回值不允许修改.
	/// </summary>
	/// <param name="relationType"></param>
	/// <returns></returns>
	public CharacterSet GetCharacterSet(ushort relationType)
	{
		return relationType switch
		{
			0 => General, 
			1 => BloodParents, 
			2 => BloodChildren, 
			4 => BloodBrothersAndSisters, 
			8 => StepParents, 
			16 => StepChildren, 
			32 => StepBrothersAndSisters, 
			64 => AdoptiveParents, 
			128 => AdoptiveChildren, 
			256 => AdoptiveBrothersAndSisters, 
			512 => SwornBrothersAndSisters, 
			1024 => HusbandsAndWives, 
			2048 => Mentors, 
			4096 => Mentees, 
			8192 => Friends, 
			16384 => Adored, 
			32768 => Enemies, 
			_ => throw new Exception($"Unsupported relationType {relationType}"), 
		};
	}

	/// <summary>
	/// 通过关系类型设置对应的关系集合
	/// </summary>
	/// <param name="relationType"></param>
	/// <param name="set"></param>
	/// <exception cref="T:System.Exception"></exception>
	public void SetCharacterSet(ushort relationType, CharacterSet set)
	{
		switch (relationType)
		{
		case 0:
			General = set;
			break;
		case 1:
			BloodParents = set;
			break;
		case 2:
			BloodChildren = set;
			break;
		case 4:
			BloodBrothersAndSisters = set;
			break;
		case 8:
			StepParents = set;
			break;
		case 16:
			StepChildren = set;
			break;
		case 32:
			StepBrothersAndSisters = set;
			break;
		case 64:
			AdoptiveParents = set;
			break;
		case 128:
			AdoptiveChildren = set;
			break;
		case 256:
			AdoptiveBrothersAndSisters = set;
			break;
		case 512:
			SwornBrothersAndSisters = set;
			break;
		case 1024:
			HusbandsAndWives = set;
			break;
		case 2048:
			Mentors = set;
			break;
		case 4096:
			Mentees = set;
			break;
		case 8192:
			Friends = set;
			break;
		case 16384:
			Adored = set;
			break;
		case 32768:
			Enemies = set;
			break;
		default:
			throw new Exception($"Unsupported relationType {relationType}");
		}
	}

	/// <summary>
	/// 获取所有关系人的集合
	/// </summary>
	/// <param name="charIds">调用者保证此集合为空</param>
	/// <param name="includeGeneral">是否包含通常关系</param>
	public void GetAllRelatedCharIds(HashSet<int> charIds, bool includeGeneral = true)
	{
		if (includeGeneral)
		{
			charIds.UnionWith(General.GetCollection());
		}
		charIds.UnionWith(BloodParents.GetCollection());
		charIds.UnionWith(BloodChildren.GetCollection());
		charIds.UnionWith(BloodBrothersAndSisters.GetCollection());
		charIds.UnionWith(StepParents.GetCollection());
		charIds.UnionWith(StepChildren.GetCollection());
		charIds.UnionWith(StepBrothersAndSisters.GetCollection());
		charIds.UnionWith(AdoptiveParents.GetCollection());
		charIds.UnionWith(AdoptiveChildren.GetCollection());
		charIds.UnionWith(AdoptiveBrothersAndSisters.GetCollection());
		charIds.UnionWith(SwornBrothersAndSisters.GetCollection());
		charIds.UnionWith(HusbandsAndWives.GetCollection());
		charIds.UnionWith(Mentors.GetCollection());
		charIds.UnionWith(Mentees.GetCollection());
		charIds.UnionWith(Friends.GetCollection());
		charIds.UnionWith(Adored.GetCollection());
		charIds.UnionWith(Enemies.GetCollection());
	}

	/// <summary>
	/// 获取所有双向关系人的集合（不包含通常、爱慕、敌对）
	/// </summary>
	/// <param name="charIds">调用者保证此集合为空</param>
	public void GetAllTwoWayRelatedCharIds(HashSet<int> charIds)
	{
		charIds.UnionWith(BloodParents.GetCollection());
		charIds.UnionWith(BloodChildren.GetCollection());
		charIds.UnionWith(BloodBrothersAndSisters.GetCollection());
		charIds.UnionWith(StepParents.GetCollection());
		charIds.UnionWith(StepChildren.GetCollection());
		charIds.UnionWith(StepBrothersAndSisters.GetCollection());
		charIds.UnionWith(AdoptiveParents.GetCollection());
		charIds.UnionWith(AdoptiveChildren.GetCollection());
		charIds.UnionWith(AdoptiveBrothersAndSisters.GetCollection());
		charIds.UnionWith(SwornBrothersAndSisters.GetCollection());
		charIds.UnionWith(HusbandsAndWives.GetCollection());
		charIds.UnionWith(Mentors.GetCollection());
		charIds.UnionWith(Mentees.GetCollection());
		charIds.UnionWith(Friends.GetCollection());
	}

	/// <summary>
	/// 获得所有优先对象（未排序）
	/// </summary>
	/// <param name="charIds"></param>
	public void GetAllPrioritizedCharIds(HashSet<int> charIds)
	{
		charIds.UnionWith(BloodParents.GetCollection());
		charIds.UnionWith(BloodChildren.GetCollection());
		charIds.UnionWith(BloodBrothersAndSisters.GetCollection());
		charIds.UnionWith(StepParents.GetCollection());
		charIds.UnionWith(StepChildren.GetCollection());
		charIds.UnionWith(StepBrothersAndSisters.GetCollection());
		charIds.UnionWith(AdoptiveParents.GetCollection());
		charIds.UnionWith(AdoptiveChildren.GetCollection());
		charIds.UnionWith(AdoptiveBrothersAndSisters.GetCollection());
		charIds.UnionWith(SwornBrothersAndSisters.GetCollection());
		charIds.UnionWith(HusbandsAndWives.GetCollection());
		charIds.UnionWith(Mentors.GetCollection());
		charIds.UnionWith(Friends.GetCollection());
		charIds.UnionWith(Adored.GetCollection());
	}

	/// <summary>
	/// 检查某人是否为此人的关系人
	/// </summary>
	/// <param name="charIdSet"></param>
	/// <param name="charId"></param>
	/// <param name="relationType">传入<see cref="T:GameData.Domains.Character.Relation.RelationType" />中各关系的组合</param>
	/// <returns>进行交换的俘虏是否为此人的关系人</returns>
	/// <remarks>关系人包括父母、结义、夫妻、子女、仇敌、朋友、爱慕、师承、手足</remarks>
	public bool HasRelation(int charId, ushort relationType = ushort.MaxValue)
	{
		if (((1 & relationType) == 0 || !BloodParents.Contains(charId)) && ((2 & relationType) == 0 || !BloodChildren.Contains(charId)) && ((4 & relationType) == 0 || !BloodBrothersAndSisters.Contains(charId)) && ((8 & relationType) == 0 || !StepParents.Contains(charId)) && ((0x10 & relationType) == 0 || !StepChildren.Contains(charId)) && ((0x20 & relationType) == 0 || !StepBrothersAndSisters.Contains(charId)) && ((0x40 & relationType) == 0 || !AdoptiveParents.Contains(charId)) && ((0x80 & relationType) == 0 || !AdoptiveChildren.Contains(charId)) && ((0x100 & relationType) == 0 || !AdoptiveBrothersAndSisters.Contains(charId)) && ((0x200 & relationType) == 0 || !SwornBrothersAndSisters.Contains(charId)) && ((0x400 & relationType) == 0 || !HusbandsAndWives.Contains(charId)) && ((0x800 & relationType) == 0 || !Mentors.Contains(charId)) && ((0x1000 & relationType) == 0 || !Mentees.Contains(charId)) && ((0x2000 & relationType) == 0 || !Friends.Contains(charId)) && ((0x4000 & relationType) == 0 || !Adored.Contains(charId)))
		{
			if ((0x8000 & relationType) != 0)
			{
				return Enemies.Contains(charId);
			}
			return false;
		}
		return true;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += General.GetSerializedSize();
		totalSize += BloodParents.GetSerializedSize();
		totalSize += BloodChildren.GetSerializedSize();
		totalSize += BloodBrothersAndSisters.GetSerializedSize();
		totalSize += StepParents.GetSerializedSize();
		totalSize += StepChildren.GetSerializedSize();
		totalSize += StepBrothersAndSisters.GetSerializedSize();
		totalSize += AdoptiveParents.GetSerializedSize();
		totalSize += AdoptiveChildren.GetSerializedSize();
		totalSize += AdoptiveBrothersAndSisters.GetSerializedSize();
		totalSize += SwornBrothersAndSisters.GetSerializedSize();
		totalSize += HusbandsAndWives.GetSerializedSize();
		totalSize += Mentors.GetSerializedSize();
		totalSize += Mentees.GetSerializedSize();
		totalSize += Friends.GetSerializedSize();
		totalSize += Adored.GetSerializedSize();
		totalSize += Enemies.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int fieldSize = General.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = BloodParents.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int fieldSize3 = BloodChildren.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		int fieldSize4 = BloodBrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		int fieldSize5 = StepParents.Serialize(pCurrData);
		pCurrData += fieldSize5;
		Tester.Assert(fieldSize5 <= 65535);
		int fieldSize6 = StepChildren.Serialize(pCurrData);
		pCurrData += fieldSize6;
		Tester.Assert(fieldSize6 <= 65535);
		int fieldSize7 = StepBrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize7;
		Tester.Assert(fieldSize7 <= 65535);
		int fieldSize8 = AdoptiveParents.Serialize(pCurrData);
		pCurrData += fieldSize8;
		Tester.Assert(fieldSize8 <= 65535);
		int fieldSize9 = AdoptiveChildren.Serialize(pCurrData);
		pCurrData += fieldSize9;
		Tester.Assert(fieldSize9 <= 65535);
		int fieldSize10 = AdoptiveBrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize10;
		Tester.Assert(fieldSize10 <= 65535);
		int fieldSize11 = SwornBrothersAndSisters.Serialize(pCurrData);
		pCurrData += fieldSize11;
		Tester.Assert(fieldSize11 <= 65535);
		int fieldSize12 = HusbandsAndWives.Serialize(pCurrData);
		pCurrData += fieldSize12;
		Tester.Assert(fieldSize12 <= 65535);
		int fieldSize13 = Mentors.Serialize(pCurrData);
		pCurrData += fieldSize13;
		Tester.Assert(fieldSize13 <= 65535);
		int fieldSize14 = Mentees.Serialize(pCurrData);
		pCurrData += fieldSize14;
		Tester.Assert(fieldSize14 <= 65535);
		int fieldSize15 = Friends.Serialize(pCurrData);
		pCurrData += fieldSize15;
		Tester.Assert(fieldSize15 <= 65535);
		int fieldSize16 = Adored.Serialize(pCurrData);
		pCurrData += fieldSize16;
		Tester.Assert(fieldSize16 <= 65535);
		int fieldSize17 = Enemies.Serialize(pCurrData);
		pCurrData += fieldSize17;
		Tester.Assert(fieldSize17 <= 65535);
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
		pCurrData += General.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += BloodParents.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += BloodChildren.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += BloodBrothersAndSisters.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += StepParents.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += StepChildren.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += StepBrothersAndSisters.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += AdoptiveParents.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += AdoptiveChildren.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += AdoptiveBrothersAndSisters.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += SwornBrothersAndSisters.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += HusbandsAndWives.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += Mentors.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += Mentees.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += Friends.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += Adored.Deserialize(pCurrData, usePoolObject: false);
		pCurrData += Enemies.Deserialize(pCurrData, usePoolObject: false);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
