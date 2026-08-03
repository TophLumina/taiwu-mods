using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 后端开始制造的参数
/// </summary>
[AutoGenerateSerializableGameData]
public struct StartMakeArguments : ISerializableGameData
{
	/// <summary>
	/// 执行制造操作的角色ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 制造时所在的产业地块的Key
	/// </summary>
	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	/// <summary>
	/// 所用工具的Key
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData Tool;

	/// <summary>
	/// 所用材料的Key
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData Material;

	/// <summary>
	/// 制造的物品类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType;

	/// <summary>
	/// 制造的物品模板ID列表，数量就是制造次数
	/// </summary>
	[SerializableGameDataField]
	public List<short> ItemList;

	/// <summary>
	/// 制造的一级分类模板ID
	/// </summary>
	[SerializableGameDataField]
	public short MakeItemSubTypeId;

	/// <summary>
	/// 制造投入的资源份数，用于生成装备数据
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts ResourceCount;

	/// <summary>
	/// 制造所需的资源
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts NeedResource;

	/// <summary>
	/// 精益求精的目标装备特效
	/// </summary>
	[SerializableGameDataField]
	public short EquipmentEffectId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize += BuildingBlockKey.GetSerializedSize();
		totalSize = ((Tool == null) ? (totalSize + 2) : (totalSize + (2 + Tool.GetSerializedSize())));
		totalSize = ((Material == null) ? (totalSize + 2) : (totalSize + (2 + Material.GetSerializedSize())));
		totalSize = ((ItemList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ItemList.Count)));
		totalSize += ResourceCount.GetSerializedSize();
		totalSize += NeedResource.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		if (Tool != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Tool.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Material != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = Material.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)ItemType;
		pCurrData++;
		if (ItemList != null)
		{
			int elementsCount = ItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = ItemList[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = MakeItemSubTypeId;
		pCurrData += 2;
		pCurrData += ResourceCount.Serialize(pCurrData);
		pCurrData += NeedResource.Serialize(pCurrData);
		*(short*)pCurrData = EquipmentEffectId;
		pCurrData += 2;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Tool = new ItemDisplayData();
			pCurrData += Tool.Deserialize(pCurrData);
		}
		else
		{
			Tool = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			Material = new ItemDisplayData();
			pCurrData += Material.Deserialize(pCurrData);
		}
		else
		{
			Material = null;
		}
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ItemList == null)
			{
				ItemList = new List<short>();
			}
			else
			{
				ItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				ItemList.Add(element);
			}
		}
		else
		{
			ItemList?.Clear();
		}
		MakeItemSubTypeId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += ResourceCount.Deserialize(pCurrData);
		pCurrData += NeedResource.Deserialize(pCurrData);
		EquipmentEffectId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
