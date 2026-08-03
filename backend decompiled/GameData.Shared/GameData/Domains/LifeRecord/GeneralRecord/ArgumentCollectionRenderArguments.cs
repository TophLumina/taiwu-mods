using System.Collections.Generic;
using System.Text;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 人物经历渲染相关参数数据集合
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ArgumentCollectionRenderArguments : ISerializableGameData
{
	/// <summary>
	/// 获取时的唯一ID：为不同的界面或者通知获取时传入唯一的key
	/// </summary>
	[SerializableGameDataField]
	public string Key;

	/// <summary>
	/// 关联的角色姓名显示相关数据
	/// </summary>
	[SerializableGameDataField]
	public List<NameAndLifeRelatedData> CharNameAndLifeDataList;

	/// <summary>
	/// 关联的聚居点名字相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<SettlementNameRelatedData> SettlementNames;

	/// <summary>
	/// 关联的地点名字相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<LocationNameRelatedData> LocationNames;

	/// <summary>
	/// 关联的蛟、龙名字相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<JiaoLoongNameRelatedData> JiaoLoongNames;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Key == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Key.Length)));
		totalSize = ((CharNameAndLifeDataList == null) ? (totalSize + 2) : (totalSize + (2 + 36 * CharNameAndLifeDataList.Count)));
		totalSize = ((SettlementNames == null) ? (totalSize + 2) : (totalSize + (2 + 4 * SettlementNames.Count)));
		totalSize = ((LocationNames == null) ? (totalSize + 2) : (totalSize + (2 + 8 * LocationNames.Count)));
		totalSize = ((JiaoLoongNames == null) ? (totalSize + 2) : (totalSize + (2 + 12 * JiaoLoongNames.Count)));
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
		if (CharNameAndLifeDataList != null)
		{
			int elementsCount2 = CharNameAndLifeDataList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += CharNameAndLifeDataList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementNames != null)
		{
			int elementsCount3 = SettlementNames.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += SettlementNames[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LocationNames != null)
		{
			int elementsCount4 = LocationNames.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += LocationNames[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (JiaoLoongNames != null)
		{
			int elementsCount5 = JiaoLoongNames.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += JiaoLoongNames[m].Serialize(pCurrData);
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
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CharNameAndLifeDataList == null)
			{
				CharNameAndLifeDataList = new List<NameAndLifeRelatedData>(elementsCount2);
			}
			else
			{
				CharNameAndLifeDataList.Clear();
			}
			for (int i = 0; i < elementsCount2; i++)
			{
				NameAndLifeRelatedData element = default(NameAndLifeRelatedData);
				pCurrData += element.Deserialize(pCurrData);
				CharNameAndLifeDataList.Add(element);
			}
		}
		else
		{
			CharNameAndLifeDataList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (SettlementNames == null)
			{
				SettlementNames = new List<SettlementNameRelatedData>(elementsCount3);
			}
			else
			{
				SettlementNames.Clear();
			}
			for (int j = 0; j < elementsCount3; j++)
			{
				SettlementNameRelatedData element2 = default(SettlementNameRelatedData);
				pCurrData += element2.Deserialize(pCurrData);
				SettlementNames.Add(element2);
			}
		}
		else
		{
			SettlementNames?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (LocationNames == null)
			{
				LocationNames = new List<LocationNameRelatedData>(elementsCount4);
			}
			else
			{
				LocationNames.Clear();
			}
			for (int k = 0; k < elementsCount4; k++)
			{
				LocationNameRelatedData element3 = default(LocationNameRelatedData);
				pCurrData += element3.Deserialize(pCurrData);
				LocationNames.Add(element3);
			}
		}
		else
		{
			LocationNames?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (JiaoLoongNames == null)
			{
				JiaoLoongNames = new List<JiaoLoongNameRelatedData>(elementsCount5);
			}
			else
			{
				JiaoLoongNames.Clear();
			}
			for (int l = 0; l < elementsCount5; l++)
			{
				JiaoLoongNameRelatedData element4 = default(JiaoLoongNameRelatedData);
				pCurrData += element4.Deserialize(pCurrData);
				JiaoLoongNames.Add(element4);
			}
		}
		else
		{
			JiaoLoongNames?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
