using System;
using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 使用玄机界面的全部显示数据
/// </summary>
[AutoGenerateSerializableGameData]
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class SkillBreakBonusSelectDisplayData : ISerializableGameData
{
	/// <summary>
	/// 能否使用仓库
	/// </summary>
	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	/// <summary>
	/// 行囊的玄机物品
	/// </summary>
	[SerializableGameDataField]
	public List<SkillBreakBonusSelectableItem> InventoryBonusItemList = new List<SkillBreakBonusSelectableItem>();

	/// <summary>
	/// 私库的玄机物品
	/// </summary>
	[SerializableGameDataField]
	public List<SkillBreakBonusSelectableItem> WarehouseBonusItemList = new List<SkillBreakBonusSelectableItem>();

	/// <summary>
	/// 公库的玄机物品
	/// </summary>
	[SerializableGameDataField]
	public List<SkillBreakBonusSelectableItem> TreasuryBonusItemList = new List<SkillBreakBonusSelectableItem>();

	/// <summary>
	/// 历练的玄机物品
	/// </summary>
	[SerializableGameDataField]
	public List<SkillBreakBonusSelectableItem> ExpBonusItemList = new List<SkillBreakBonusSelectableItem>();

	/// <summary>
	/// 人物的玄机物品
	/// </summary>
	[SerializableGameDataField]
	public List<SkillBreakBonusSelectableItem> CharacterBonusItemList = new List<SkillBreakBonusSelectableItem>();

	/// <summary>
	/// 技能显示数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillDisplayData CombatSkillDisplayData;

	/// <summary>
	/// 上次选择的人物
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData SelectedCharacterDisplayData;

	/// <summary>
	/// 内部汇总
	/// </summary>
	private List<SkillBreakBonusSelectableItem> _sourceList;

	/// <summary>
	/// 获取物品列表
	/// </summary>
	/// <param name="sourceType"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public List<SkillBreakBonusSelectableItem> GetBonusItemList(ItemSourceType sourceType)
	{
		return sourceType switch
		{
			ItemSourceType.Inventory => InventoryBonusItemList, 
			ItemSourceType.Warehouse => WarehouseBonusItemList, 
			ItemSourceType.Treasury => TreasuryBonusItemList, 
			_ => throw new ArgumentOutOfRangeException("sourceType", sourceType, null), 
		};
	}

	/// <summary>
	/// 获取用于显示的列表，包含历练、人物
	/// </summary>
	/// <param name="sourceType"></param>
	/// <returns></returns>
	public List<SkillBreakBonusSelectableItem> GetTotalBonusItemList(ItemSourceType sourceType)
	{
		if (_sourceList == null)
		{
			_sourceList = new List<SkillBreakBonusSelectableItem>();
		}
		_sourceList.Clear();
		_sourceList.AddRange(ExpBonusItemList);
		List<SkillBreakBonusSelectableItem> itemList = GetBonusItemList(sourceType);
		_sourceList.AddRange(itemList);
		_sourceList.AddRange(CharacterBonusItemList);
		return _sourceList;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		if (InventoryBonusItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < InventoryBonusItemList.Count; i++)
			{
				totalSize = ((InventoryBonusItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryBonusItemList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseBonusItemList != null)
		{
			totalSize += 2;
			for (int j = 0; j < WarehouseBonusItemList.Count; j++)
			{
				totalSize = ((WarehouseBonusItemList[j] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseBonusItemList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryBonusItemList != null)
		{
			totalSize += 2;
			for (int k = 0; k < TreasuryBonusItemList.Count; k++)
			{
				totalSize = ((TreasuryBonusItemList[k] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryBonusItemList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ExpBonusItemList != null)
		{
			totalSize += 2;
			for (int l = 0; l < ExpBonusItemList.Count; l++)
			{
				totalSize = ((ExpBonusItemList[l] == null) ? (totalSize + 2) : (totalSize + (2 + ExpBonusItemList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CharacterBonusItemList != null)
		{
			totalSize += 2;
			for (int m = 0; m < CharacterBonusItemList.Count; m++)
			{
				totalSize = ((CharacterBonusItemList[m] == null) ? (totalSize + 2) : (totalSize + (2 + CharacterBonusItemList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CombatSkillDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CombatSkillDisplayData.GetSerializedSize())));
		totalSize = ((SelectedCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + SelectedCharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (InventoryBonusItemList != null)
		{
			int elementsCount = InventoryBonusItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (InventoryBonusItemList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = InventoryBonusItemList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		if (WarehouseBonusItemList != null)
		{
			int elementsCount2 = WarehouseBonusItemList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (WarehouseBonusItemList[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = WarehouseBonusItemList[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		if (TreasuryBonusItemList != null)
		{
			int elementsCount3 = TreasuryBonusItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (TreasuryBonusItemList[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = TreasuryBonusItemList[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		if (ExpBonusItemList != null)
		{
			int elementsCount4 = ExpBonusItemList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (ExpBonusItemList[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = ExpBonusItemList[l].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
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
		if (CharacterBonusItemList != null)
		{
			int elementsCount5 = CharacterBonusItemList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (CharacterBonusItemList[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = CharacterBonusItemList[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
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
		if (CombatSkillDisplayData != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = CombatSkillDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectedCharacterDisplayData != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = SelectedCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)intPtr7 = (ushort)fieldSize7;
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
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (InventoryBonusItemList == null)
			{
				InventoryBonusItemList = new List<SkillBreakBonusSelectableItem>();
			}
			else
			{
				InventoryBonusItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				SkillBreakBonusSelectableItem element;
				if (num > 0)
				{
					element = new SkillBreakBonusSelectableItem();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				InventoryBonusItemList.Add(element);
			}
		}
		else
		{
			InventoryBonusItemList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (WarehouseBonusItemList == null)
			{
				WarehouseBonusItemList = new List<SkillBreakBonusSelectableItem>();
			}
			else
			{
				WarehouseBonusItemList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				SkillBreakBonusSelectableItem element2;
				if (num2 > 0)
				{
					element2 = new SkillBreakBonusSelectableItem();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				WarehouseBonusItemList.Add(element2);
			}
		}
		else
		{
			WarehouseBonusItemList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (TreasuryBonusItemList == null)
			{
				TreasuryBonusItemList = new List<SkillBreakBonusSelectableItem>();
			}
			else
			{
				TreasuryBonusItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				SkillBreakBonusSelectableItem element3;
				if (num3 > 0)
				{
					element3 = new SkillBreakBonusSelectableItem();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				TreasuryBonusItemList.Add(element3);
			}
		}
		else
		{
			TreasuryBonusItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ExpBonusItemList == null)
			{
				ExpBonusItemList = new List<SkillBreakBonusSelectableItem>();
			}
			else
			{
				ExpBonusItemList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				SkillBreakBonusSelectableItem element4;
				if (num4 > 0)
				{
					element4 = new SkillBreakBonusSelectableItem();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				ExpBonusItemList.Add(element4);
			}
		}
		else
		{
			ExpBonusItemList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (CharacterBonusItemList == null)
			{
				CharacterBonusItemList = new List<SkillBreakBonusSelectableItem>();
			}
			else
			{
				CharacterBonusItemList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				SkillBreakBonusSelectableItem element5;
				if (num5 > 0)
				{
					element5 = new SkillBreakBonusSelectableItem();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				CharacterBonusItemList.Add(element5);
			}
		}
		else
		{
			CharacterBonusItemList?.Clear();
		}
		ushort num6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num6 > 0)
		{
			CombatSkillDisplayData = new CombatSkillDisplayData();
			pCurrData += CombatSkillDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CombatSkillDisplayData = null;
		}
		ushort num7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num7 > 0)
		{
			SelectedCharacterDisplayData = new CharacterDisplayData();
			pCurrData += SelectedCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			SelectedCharacterDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
