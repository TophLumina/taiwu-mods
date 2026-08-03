using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class XiangshuInfectedDemonData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharId = 0;

		public const ushort Minions = 1;

		public const ushort LastRescuedOrKilledDate = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "CharId", "Minions", "LastRescuedOrKilledDate" };
	}

	/// <summary>
	/// 失心魔 ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId = -1;

	/// <summary>
	/// 召唤出的爪牙
	/// </summary>
	[SerializableGameDataField]
	public List<XiangshuInfectedDemonMinion> Minions;

	/// <summary>
	/// 上一次被解救或消灭的时间
	/// </summary>
	[SerializableGameDataField]
	public int LastRescuedOrKilledDate = int.MinValue;

	public static XiangshuInfectedDemonData Invalid => new XiangshuInfectedDemonData();

	public bool RemoveMinion(short areaId, MapTemplateEnemyInfo mapTemplateEnemyInfo)
	{
		List<XiangshuInfectedDemonMinion> minions = Minions;
		if (minions == null || minions.Count <= 0)
		{
			return false;
		}
		for (int i = Minions.Count - 1; i >= 0; i--)
		{
			XiangshuInfectedDemonMinion minion = Minions[i];
			if (minion.AreaId == areaId && minion.EnemyInfo.Equals(mapTemplateEnemyInfo))
			{
				CollectionUtils.SwapAndRemove(Minions, i);
				return true;
			}
		}
		return false;
	}

	public void AddMinion(short areaId, MapTemplateEnemyInfo mapTemplateEnemyInfo)
	{
		Tester.Assert(mapTemplateEnemyInfo.SourceType == 3);
		if (Minions == null)
		{
			Minions = new List<XiangshuInfectedDemonMinion>();
		}
		Minions.Add(new XiangshuInfectedDemonMinion(areaId, mapTemplateEnemyInfo));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize = ((Minions == null) ? (totalSize + 2) : (totalSize + (2 + 12 * Minions.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		if (Minions != null)
		{
			int elementsCount = Minions.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Minions[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = LastRescuedOrKilledDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Minions == null)
				{
					Minions = new List<XiangshuInfectedDemonMinion>(elementsCount);
				}
				else
				{
					Minions.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					XiangshuInfectedDemonMinion element = default(XiangshuInfectedDemonMinion);
					pCurrData += element.Deserialize(pCurrData);
					Minions.Add(element);
				}
			}
			else
			{
				Minions?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			LastRescuedOrKilledDate = *(int*)pCurrData;
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
