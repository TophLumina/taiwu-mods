using System;
using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 地图一个格子里所有拾取物的数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, IsExtensible = true)]
public class MapPickupCollection : ISerializableGameData, IEnumerable<MapPickup>, IEnumerable
{
	private static class FieldIds
	{
		public const ushort PickupList = 0;

		public const ushort IsNormalPickupTriggeredThisMonth = 1;

		public const ushort IsEventPickupTriggeredThisMonth = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "PickupList", "IsNormalPickupTriggeredThisMonth", "IsEventPickupTriggeredThisMonth" };
	}

	/// <summary>
	/// 拾取物列表，有顺序
	/// </summary>
	[SerializableGameDataField]
	public List<MapPickup> PickupList;

	/// <summary>
	/// 本月是否触发过普通拾取物，如果有，本格上的普通拾取物就不再可见
	/// </summary>
	[Obsolete("现在可以堆叠显示了")]
	[SerializableGameDataField]
	public bool IsNormalPickupTriggeredThisMonth;

	/// <summary>
	/// 本月是否触发过事件拾取物，如果有，本格上的事件拾取物就不再可见
	/// </summary>
	[Obsolete("现在可以堆叠显示了")]
	[SerializableGameDataField]
	public bool IsEventPickupTriggeredThisMonth;

	/// <summary>
	/// 拾取物的数量
	/// </summary>
	public int Count
	{
		get
		{
			if (PickupList == null)
			{
				return 0;
			}
			return PickupList.Count;
		}
	}

	/// <summary>
	/// 默认构造
	/// </summary>
	public MapPickupCollection()
	{
		PickupList = new List<MapPickup>();
	}

	/// <summary>
	/// 添加一个拾取物
	/// </summary>
	public void AddPickup(MapPickup pickup)
	{
		if (pickup != null)
		{
			PickupList.Add(pickup);
		}
	}

	/// <summary>
	/// 将指定拾取物移至最前
	/// </summary>
	public void SetPickupAtFirst(MapPickup pickup)
	{
		if (pickup != null)
		{
			int index = PickupList.IndexOf(pickup);
			if (index < 0)
			{
				throw new ArgumentException("IgnorePickup: pickup not found in PickupList");
			}
			if (index != 0)
			{
				List<MapPickup> pickupList = PickupList;
				List<MapPickup> pickupList2 = PickupList;
				int index2 = index;
				MapPickup value = PickupList[index];
				MapPickup value2 = PickupList[0];
				pickupList[0] = value;
				pickupList2[index2] = value2;
			}
		}
	}

	/// <summary>
	/// 置之不理一个拾取物
	/// </summary>
	/// <param name="pickup"></param>
	public void IgnorePickup(MapPickup pickup)
	{
		if (pickup != null)
		{
			int index = PickupList.IndexOf(pickup);
			if (index < 0)
			{
				throw new ArgumentException("IgnorePickup: pickup not found in PickupList");
			}
			pickup.Ignored = true;
			PickupList.RemoveAt(index);
			PickupList.Add(pickup);
		}
	}

	/// <summary>
	/// 获取一个拾取物
	/// </summary>
	public MapPickup Get(int index)
	{
		if (PickupList == null || index < 0 || index >= PickupList.Count)
		{
			return null;
		}
		return PickupList[index];
	}

	/// <summary>
	/// 清理触发过状态，和所有置之不理状态
	/// </summary>
	/// <returns>是否修改了自身</returns>
	public bool ClearIgnoredAndTriggered()
	{
		bool modified = false;
		foreach (MapPickup pickup in PickupList)
		{
			if (pickup.Ignored)
			{
				modified = true;
				pickup.Ignored = false;
			}
		}
		return modified;
	}

	/// <inheritdoc cref="M:System.Collections.Generic.IEnumerable`1.GetEnumerator" />
	public IEnumerator<MapPickup> GetEnumerator()
	{
		return PickupList.GetEnumerator();
	}

	/// <inheritdoc cref="M:System.Collections.IEnumerable.GetEnumerator" />
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (PickupList != null)
		{
			totalSize += 2;
			int elementsCount = PickupList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				MapPickup element = PickupList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (PickupList != null)
		{
			int elementsCount = PickupList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				MapPickup element = PickupList[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsNormalPickupTriggeredThisMonth ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsEventPickupTriggeredThisMonth ? ((byte)1) : ((byte)0));
		pCurrData++;
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
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PickupList == null)
				{
					PickupList = new List<MapPickup>(elementsCount);
				}
				else
				{
					PickupList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						MapPickup element = new MapPickup();
						pCurrData += element.Deserialize(pCurrData);
						PickupList.Add(element);
					}
					else
					{
						PickupList.Add(null);
					}
				}
			}
			else
			{
				PickupList?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			IsNormalPickupTriggeredThisMonth = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			IsEventPickupTriggeredThisMonth = *pCurrData != 0;
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
