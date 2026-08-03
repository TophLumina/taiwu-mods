using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 促织决斗预设项
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CricketPresetItem : PresetItemBase<CricketPresetItem>
{
	private static class FieldIds
	{
		public const ushort CricketIds = 0;

		public const ushort PolymorphCharIds = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CricketIds", "PolymorphCharIds" };
	}

	/// <summary>
	/// 促织道具 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public List<int> CricketIds;

	/// <summary>
	/// 化念角色 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public List<int> PolymorphCharIds;

	public override void Clear()
	{
		CricketIds?.Clear();
		PolymorphCharIds?.Clear();
	}

	public override CricketPresetItem Clone()
	{
		return new CricketPresetItem(this);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketPresetItem()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketPresetItem(CricketPresetItem other)
	{
		CricketIds = ((other.CricketIds == null) ? null : new List<int>(other.CricketIds));
		PolymorphCharIds = ((other.PolymorphCharIds == null) ? null : new List<int>(other.PolymorphCharIds));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketPresetItem other)
	{
		CricketIds = ((other.CricketIds == null) ? null : new List<int>(other.CricketIds));
		PolymorphCharIds = ((other.PolymorphCharIds == null) ? null : new List<int>(other.PolymorphCharIds));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public override int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((CricketIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CricketIds.Count)));
		totalSize = ((PolymorphCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * PolymorphCharIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (CricketIds != null)
		{
			int elementsCount = CricketIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = CricketIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PolymorphCharIds != null)
		{
			int elementsCount2 = PolymorphCharIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = PolymorphCharIds[j];
			}
			pCurrData += 4 * elementsCount2;
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
	public unsafe override int Deserialize(byte* pData)
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
				if (CricketIds == null)
				{
					CricketIds = new List<int>(elementsCount);
				}
				else
				{
					CricketIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					CricketIds.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				CricketIds?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (PolymorphCharIds == null)
				{
					PolymorphCharIds = new List<int>(elementsCount2);
				}
				else
				{
					PolymorphCharIds.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					PolymorphCharIds.Add(((int*)pCurrData)[j]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				PolymorphCharIds?.Clear();
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
