using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Story.SectMainStory;

[SerializableGameData(IsExtensible = true)]
public class SectBaihuaLifeLinkData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort LifeGateCharIds = 0;

		public const ushort DeathGateCharIds = 1;

		public const ushort Cooldown = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "LifeGateCharIds", "DeathGateCharIds", "Cooldown" };
	}

	[SerializableGameDataField]
	public int[] LifeGateCharIds;

	[SerializableGameDataField]
	public int[] DeathGateCharIds;

	[SerializableGameDataField]
	public sbyte Cooldown;

	public const int InitialGateCharCount = 4;

	public const int BonusGateCharCount = 4;

	public const int MaxGateCharCount = 8;

	public bool IsInitialized()
	{
		if (LifeGateCharIds != null)
		{
			return DeathGateCharIds != null;
		}
		return false;
	}

	public void Initialize()
	{
		LifeGateCharIds = new int[4];
		DeathGateCharIds = new int[4];
		Array.Fill(LifeGateCharIds, -1);
		Array.Fill(DeathGateCharIds, -1);
	}

	public void Upgrade()
	{
		int[] lifeGateCharIds = LifeGateCharIds;
		int[] deathGateCharIds = DeathGateCharIds;
		LifeGateCharIds = new int[lifeGateCharIds.Length + 4];
		DeathGateCharIds = new int[deathGateCharIds.Length + 4];
		for (int i = 0; i < lifeGateCharIds.Length; i++)
		{
			LifeGateCharIds[i] = lifeGateCharIds[i];
		}
		for (int j = 0; j < deathGateCharIds.Length; j++)
		{
			DeathGateCharIds[j] = deathGateCharIds[j];
		}
		for (int k = lifeGateCharIds.Length; k < LifeGateCharIds.Length; k++)
		{
			LifeGateCharIds[k] = -1;
		}
		for (int l = deathGateCharIds.Length; l < DeathGateCharIds.Length; l++)
		{
			DeathGateCharIds[l] = -1;
		}
	}

	public SectBaihuaLifeLinkData()
	{
	}

	public SectBaihuaLifeLinkData(SectBaihuaLifeLinkData other)
	{
		int[] item = other.LifeGateCharIds;
		int elementsCount = item.Length;
		LifeGateCharIds = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			LifeGateCharIds[i] = item[i];
		}
		int[] item2 = other.DeathGateCharIds;
		int elementsCount2 = item2.Length;
		DeathGateCharIds = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			DeathGateCharIds[j] = item2[j];
		}
		Cooldown = other.Cooldown;
	}

	public void Assign(SectBaihuaLifeLinkData other)
	{
		int[] item = other.LifeGateCharIds;
		int elementsCount = item.Length;
		LifeGateCharIds = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			LifeGateCharIds[i] = item[i];
		}
		int[] item2 = other.DeathGateCharIds;
		int elementsCount2 = item2.Length;
		DeathGateCharIds = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			DeathGateCharIds[j] = item2[j];
		}
		Cooldown = other.Cooldown;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((LifeGateCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LifeGateCharIds.Length)));
		totalSize = ((DeathGateCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * DeathGateCharIds.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		if (LifeGateCharIds != null)
		{
			int elementsCount = LifeGateCharIds.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = LifeGateCharIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DeathGateCharIds != null)
		{
			int elementsCount2 = DeathGateCharIds.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = DeathGateCharIds[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)Cooldown;
		pCurrData++;
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
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (LifeGateCharIds == null || LifeGateCharIds.Length != elementsCount)
				{
					LifeGateCharIds = new int[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					LifeGateCharIds[i] = ((int*)pCurrData)[i];
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				LifeGateCharIds = null;
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (DeathGateCharIds == null || DeathGateCharIds.Length != elementsCount2)
				{
					DeathGateCharIds = new int[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					DeathGateCharIds[j] = ((int*)pCurrData)[j];
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				DeathGateCharIds = null;
			}
		}
		if (fieldCount > 2)
		{
			Cooldown = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
