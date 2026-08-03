using System.Collections.Generic;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 匠人订单
/// 太吾村建筑和非太吾村匠人
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ArtisanOrder : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BuildingBlockKey = 0;

		public const ushort ArtisanId = 1;

		public const ushort SubscriberId = 2;

		public const ushort ItemSubType = 3;

		public const ushort LifeSkillType = 4;

		public const ushort Progress = 5;

		public const ushort StorageType = 6;

		public const ushort ProductionWeight = 7;

		public const ushort IsDebateWon = 8;

		public const ushort ProgressDelta = 9;

		public const ushort DebateCount = 10;

		public const ushort ProgressBaseDelta = 11;

		public const ushort Count = 12;

		public static readonly string[] FieldId2FieldName = new string[12]
		{
			"BuildingBlockKey", "ArtisanId", "SubscriberId", "ItemSubType", "LifeSkillType", "Progress", "StorageType", "ProductionWeight", "IsDebateWon", "ProgressDelta",
			"DebateCount", "ProgressBaseDelta"
		};
	}

	/// <summary>
	/// 产业建筑Key
	/// 匠人npc为Invalid
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public BuildingBlockKey BuildingBlockKey;

	/// <summary>
	/// 匠人Id
	/// 太吾村产业为领袖npcId
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int ArtisanId;

	/// <summary>
	/// 订购者Id
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int SubscriberId;

	/// <summary>
	/// 指定的产出类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public short ItemSubType;

	/// <summary>
	/// 指定的产出类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte LifeSkillType;

	/// <summary>
	/// 制造进度
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public int Progress;

	/// <summary>
	/// 制造完毕后放入的位置
	/// 目前仅支持私库和公库
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public int StorageType;

	/// <summary>
	/// 产物权重
	/// 仅包含投入引子增加的权重
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	public Dictionary<Production, int> ProductionWeight;

	/// <summary>
	/// 压价较艺胜利
	/// 仅匠人订单需要
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public bool IsDebateWon;

	/// <summary>
	/// 订单进度每月增量
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	public int ProgressDelta;

	/// <summary>
	/// 较艺次数
	/// 仅匠人订单需要
	/// </summary>
	[SerializableGameDataField(FieldIndex = 10)]
	public int DebateCount;

	/// <summary>
	/// 订单进度每月增量基础值，不受ArtisanOrderProgressBonus影响
	/// </summary>
	[SerializableGameDataField(FieldIndex = 11)]
	public int ProgressBaseDelta;

	/// <summary>
	/// 用于判定是否为受玄狱模式影响
	/// 由于目前太吾村外不存在建筑代制，所以可以直接使用BuildingBlockKey进行判定
	/// </summary>
	public bool IsAffectedByChallenge => !BuildingBlockKey.Equals(BuildingBlockKey.Invalid);

	/// <summary>
	///
	/// </summary>
	public ArtisanOrder()
	{
		BuildingBlockKey = BuildingBlockKey.Invalid;
		ArtisanId = -1;
		SubscriberId = -1;
		ItemSubType = -1;
		Progress = 0;
		StorageType = 2;
		ProductionWeight = new Dictionary<Production, int>();
		IsDebateWon = false;
		ProgressDelta = 0;
		ProgressBaseDelta = 0;
		DebateCount = 0;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="artisanId"></param>
	/// <param name="subscriberId"></param>
	/// <param name="lifeSkillType"></param>
	/// <param name="progressDelta"></param>
	public ArtisanOrder(int artisanId, int subscriberId, sbyte lifeSkillType, int progressDelta)
	{
		BuildingBlockKey = BuildingBlockKey.Invalid;
		ArtisanId = artisanId;
		SubscriberId = subscriberId;
		ItemSubType = -1;
		LifeSkillType = lifeSkillType;
		Progress = 0;
		StorageType = 2;
		ProductionWeight = new Dictionary<Production, int>();
		IsDebateWon = false;
		ProgressDelta = progressDelta;
		DebateCount = 0;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="buildingBlockKey"></param>
	/// <param name="artisanId"></param>
	/// <param name="subscriberId"></param>
	/// <param name="lifeSkillType"></param>
	/// <param name="progressDelta"></param>
	/// <param name="progressBaseDelta"></param>
	/// <param name="itemSubType"></param>
	public ArtisanOrder(BuildingBlockKey buildingBlockKey, int artisanId, int subscriberId, sbyte lifeSkillType, int progressDelta, int progressBaseDelta, short itemSubType)
	{
		BuildingBlockKey = buildingBlockKey;
		ArtisanId = artisanId;
		SubscriberId = subscriberId;
		ItemSubType = itemSubType;
		LifeSkillType = lifeSkillType;
		Progress = 0;
		StorageType = 2;
		ProductionWeight = new Dictionary<Production, int>();
		IsDebateWon = false;
		ProgressDelta = progressDelta;
		ProgressBaseDelta = progressBaseDelta;
		DebateCount = 0;
	}

	/// <summary>
	/// 是否是匠人订单
	/// </summary>
	/// <returns></returns>
	public bool IsArtisanOrder()
	{
		return BuildingBlockKey.Equals(BuildingBlockKey.Invalid);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 34;
		totalSize += BuildingBlockKey.GetSerializedSize();
		totalSize += 4;
		if (ProductionWeight != null)
		{
			foreach (KeyValuePair<Production, int> item in ProductionWeight)
			{
				totalSize += item.Key.GetSerializedSize();
				totalSize += 4;
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 12;
		pCurrData += 2;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		*(int*)pCurrData = ArtisanId;
		pCurrData += 4;
		*(int*)pCurrData = SubscriberId;
		pCurrData += 4;
		*(short*)pCurrData = ItemSubType;
		pCurrData += 2;
		*pCurrData = (byte)LifeSkillType;
		pCurrData++;
		*(int*)pCurrData = Progress;
		pCurrData += 4;
		*(int*)pCurrData = StorageType;
		pCurrData += 4;
		if (ProductionWeight != null)
		{
			*(int*)pCurrData = ProductionWeight.Count;
			pCurrData += 4;
			foreach (KeyValuePair<Production, int> pair in ProductionWeight)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (IsDebateWon ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ProgressDelta;
		pCurrData += 4;
		*(int*)pCurrData = DebateCount;
		pCurrData += 4;
		*(int*)pCurrData = ProgressBaseDelta;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			ArtisanId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			SubscriberId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ItemSubType = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 4)
		{
			LifeSkillType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			Progress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			StorageType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			int ProductionWeightElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (ProductionWeightElementsCount > 0)
			{
				if (ProductionWeight == null)
				{
					ProductionWeight = new Dictionary<Production, int>();
				}
				else
				{
					ProductionWeight.Clear();
				}
				for (int i = 0; i < ProductionWeightElementsCount; i++)
				{
					Production key = default(Production);
					pCurrData += key.Deserialize(pCurrData);
					int value = *(int*)pCurrData;
					pCurrData += 4;
					ProductionWeight.Add(key, value);
				}
			}
			else
			{
				ProductionWeight?.Clear();
			}
		}
		if (fieldCount > 8)
		{
			IsDebateWon = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 9)
		{
			ProgressDelta = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 10)
		{
			DebateCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 11)
		{
			ProgressBaseDelta = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
