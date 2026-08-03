using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 物品选择时单类物品需求
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public struct SelectItemFilter : ISerializableGameData
{
	/// <summary>
	/// 筛选规则配置ID
	/// </summary>
	[SerializableGameDataField]
	public short FilterTemplateId;

	/// <summary>
	/// 筛选接口委托Id
	/// </summary>
	[SerializableGameDataField]
	public ushort DisplayDataFilterId;

	/// <summary>
	/// 选择完毕后存入EventArgBox的key，如果有多个选择，会依次序递增排列
	/// </summary>
	[SerializableGameDataField]
	public string Key;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((Key == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Key.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = FilterTemplateId;
		pCurrData += 2;
		*(ushort*)pCurrData = DisplayDataFilterId;
		pCurrData += 2;
		if (Key != null)
		{
			int elementsCount = Key.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Key)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		FilterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		DisplayDataFilterId = *(ushort*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			Key = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Key = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
