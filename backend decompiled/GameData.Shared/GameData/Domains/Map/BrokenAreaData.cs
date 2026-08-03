using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 毁坏区域的额外数据，主要用于记录其等级和其中的随机敌人
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class BrokenAreaData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Level = 0;

		public const ushort RandomEnemies = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Level", "RandomEnemies" };
	}

	/// <summary>
	/// 毁坏区域等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte Level;

	/// <summary>
	/// 毁坏区域的随即敌人
	/// </summary>
	[SerializableGameDataField]
	public List<MapTemplateEnemyInfo> RandomEnemies;

	public short BaseXiangshuMinionTemplateId => (short)Math.Clamp(366 + Level - 1, 366, 374);

	public BrokenAreaData()
	{
		RandomEnemies = new List<MapTemplateEnemyInfo>();
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BrokenAreaData(BrokenAreaData other)
	{
		Level = other.Level;
		RandomEnemies = ((other.RandomEnemies == null) ? null : new List<MapTemplateEnemyInfo>(other.RandomEnemies));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BrokenAreaData other)
	{
		Level = other.Level;
		RandomEnemies = ((other.RandomEnemies == null) ? null : new List<MapTemplateEnemyInfo>(other.RandomEnemies));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((RandomEnemies == null) ? (totalSize + 2) : (totalSize + (2 + 8 * RandomEnemies.Count)));
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*pCurrData = (byte)Level;
		pCurrData++;
		if (RandomEnemies != null)
		{
			int elementsCount = RandomEnemies.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += RandomEnemies[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Level = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (RandomEnemies == null)
				{
					RandomEnemies = new List<MapTemplateEnemyInfo>(elementsCount);
				}
				else
				{
					RandomEnemies.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					MapTemplateEnemyInfo element = default(MapTemplateEnemyInfo);
					pCurrData += element.Deserialize(pCurrData);
					RandomEnemies.Add(element);
				}
			}
			else
			{
				RandomEnemies?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
