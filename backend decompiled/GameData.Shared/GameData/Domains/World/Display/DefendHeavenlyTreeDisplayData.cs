using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

/// <summary>
/// 武当-保卫神木界面数据
/// </summary>
[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class DefendHeavenlyTreeDisplayData : ISerializableGameData
{
	/// <summary>
	/// 所有村民、神木、太吾及其同道的角色显示数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> AllCharacterDisplayDataDict;

	/// <summary>
	/// 神木数据
	/// </summary>
	[SerializableGameDataField]
	public List<SectStoryHeavenlyTreeExtendable> HeavenlyTreeList;

	/// <summary>
	/// 空闲可工作的村民
	/// </summary>
	[SerializableGameDataField]
	public List<int> WorkAvailableVillagerList;

	/// <summary>
	/// 可以神木涤秽的村民，包括太吾及其同道，未排除垂危
	/// </summary>
	[SerializableGameDataField]
	public List<int> TreeClearEnemyAvailableVillagerList;

	/// <summary>
	/// 全部的书籍物品列表
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> BookItemList;

	/// <summary>
	/// 太吾读完的书籍列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> AvailableBookList;

	/// <summary>
	/// 太吾行囊资源物品列表
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> ResourceItemList;

	/// <summary>
	/// 神木全部地块字典，神木特殊角色ID=&gt;神木邻接范围地格列表
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, DefendHeavenlyTreeBlockData> HeavenlyTreeBlockDict = new Dictionary<int, DefendHeavenlyTreeBlockData>();

	/// <summary>
	/// 神木可见地块字典，神木特殊角色ID=&gt;神木邻接范围地格列表
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, DefendHeavenlyTreeBlockData> HeavenlyTreeVisibleBlockDict = new Dictionary<int, DefendHeavenlyTreeBlockData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 4;
		if (AllCharacterDisplayDataDict != null)
		{
			foreach (KeyValuePair<int, CharacterDisplayData> pair in AllCharacterDisplayDataDict)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		if (HeavenlyTreeList != null)
		{
			totalSize += 2;
			for (int i = 0; i < HeavenlyTreeList.Count; i++)
			{
				totalSize = ((HeavenlyTreeList[i] == null) ? (totalSize + 2) : (totalSize + (2 + HeavenlyTreeList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((WorkAvailableVillagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * WorkAvailableVillagerList.Count)));
		totalSize = ((TreeClearEnemyAvailableVillagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TreeClearEnemyAvailableVillagerList.Count)));
		if (BookItemList != null)
		{
			totalSize += 2;
			for (int j = 0; j < BookItemList.Count; j++)
			{
				totalSize = ((BookItemList[j] == null) ? (totalSize + 2) : (totalSize + (2 + BookItemList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AvailableBookList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AvailableBookList.Count)));
		if (ResourceItemList != null)
		{
			totalSize += 2;
			for (int k = 0; k < ResourceItemList.Count; k++)
			{
				totalSize = ((ResourceItemList[k] == null) ? (totalSize + 2) : (totalSize + (2 + ResourceItemList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (HeavenlyTreeBlockDict != null)
		{
			foreach (KeyValuePair<int, DefendHeavenlyTreeBlockData> pair2 in HeavenlyTreeBlockDict)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (HeavenlyTreeVisibleBlockDict != null)
		{
			foreach (KeyValuePair<int, DefendHeavenlyTreeBlockData> pair3 in HeavenlyTreeVisibleBlockDict)
			{
				totalSize += 4;
				totalSize += pair3.Value.GetSerializedSize();
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
		if (AllCharacterDisplayDataDict != null)
		{
			*(int*)pCurrData = AllCharacterDisplayDataDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterDisplayData> pair in AllCharacterDisplayDataDict)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (HeavenlyTreeList != null)
		{
			int elementsCount = HeavenlyTreeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (HeavenlyTreeList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = HeavenlyTreeList[i].Serialize(pCurrData);
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
		if (WorkAvailableVillagerList != null)
		{
			int elementsCount2 = WorkAvailableVillagerList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = WorkAvailableVillagerList[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TreeClearEnemyAvailableVillagerList != null)
		{
			int elementsCount3 = TreeClearEnemyAvailableVillagerList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(int*)pCurrData = TreeClearEnemyAvailableVillagerList[k];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BookItemList != null)
		{
			int elementsCount4 = BookItemList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (BookItemList[l] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = BookItemList[l].Serialize(pCurrData);
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
		if (AvailableBookList != null)
		{
			int elementsCount5 = AvailableBookList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				*(short*)pCurrData = AvailableBookList[m];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ResourceItemList != null)
		{
			int elementsCount6 = ResourceItemList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				if (ResourceItemList[n] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = ResourceItemList[n].Serialize(pCurrData);
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
		if (HeavenlyTreeBlockDict != null)
		{
			*(int*)pCurrData = HeavenlyTreeBlockDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, DefendHeavenlyTreeBlockData> pair2 in HeavenlyTreeBlockDict)
			{
				*(int*)pCurrData = pair2.Key;
				pCurrData += 4;
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (HeavenlyTreeVisibleBlockDict != null)
		{
			*(int*)pCurrData = HeavenlyTreeVisibleBlockDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, DefendHeavenlyTreeBlockData> pair3 in HeavenlyTreeVisibleBlockDict)
			{
				*(int*)pCurrData = pair3.Key;
				pCurrData += 4;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		int AllCharacterDisplayDataDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (AllCharacterDisplayDataDictElementsCount > 0)
		{
			if (AllCharacterDisplayDataDict == null)
			{
				AllCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayData>();
			}
			else
			{
				AllCharacterDisplayDataDict.Clear();
			}
			for (int i = 0; i < AllCharacterDisplayDataDictElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				CharacterDisplayData value = new CharacterDisplayData();
				pCurrData += value.Deserialize(pCurrData);
				AllCharacterDisplayDataDict.Add(key, value);
			}
		}
		else
		{
			AllCharacterDisplayDataDict?.Clear();
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (HeavenlyTreeList == null)
			{
				HeavenlyTreeList = new List<SectStoryHeavenlyTreeExtendable>();
			}
			else
			{
				HeavenlyTreeList.Clear();
			}
			for (int j = 0; j < elementsCount; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				SectStoryHeavenlyTreeExtendable element;
				if (num > 0)
				{
					element = new SectStoryHeavenlyTreeExtendable();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				HeavenlyTreeList.Add(element);
			}
		}
		else
		{
			HeavenlyTreeList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (WorkAvailableVillagerList == null)
			{
				WorkAvailableVillagerList = new List<int>();
			}
			else
			{
				WorkAvailableVillagerList.Clear();
			}
			for (int k = 0; k < elementsCount2; k++)
			{
				int element2 = *(int*)pCurrData;
				pCurrData += 4;
				WorkAvailableVillagerList.Add(element2);
			}
		}
		else
		{
			WorkAvailableVillagerList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (TreeClearEnemyAvailableVillagerList == null)
			{
				TreeClearEnemyAvailableVillagerList = new List<int>();
			}
			else
			{
				TreeClearEnemyAvailableVillagerList.Clear();
			}
			for (int l = 0; l < elementsCount3; l++)
			{
				int element3 = *(int*)pCurrData;
				pCurrData += 4;
				TreeClearEnemyAvailableVillagerList.Add(element3);
			}
		}
		else
		{
			TreeClearEnemyAvailableVillagerList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (BookItemList == null)
			{
				BookItemList = new List<ItemDisplayData>();
			}
			else
			{
				BookItemList.Clear();
			}
			for (int m = 0; m < elementsCount4; m++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element4;
				if (num2 > 0)
				{
					element4 = new ItemDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				BookItemList.Add(element4);
			}
		}
		else
		{
			BookItemList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (AvailableBookList == null)
			{
				AvailableBookList = new List<short>();
			}
			else
			{
				AvailableBookList.Clear();
			}
			for (int n = 0; n < elementsCount5; n++)
			{
				short element5 = *(short*)pCurrData;
				pCurrData += 2;
				AvailableBookList.Add(element5);
			}
		}
		else
		{
			AvailableBookList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (ResourceItemList == null)
			{
				ResourceItemList = new List<ItemDisplayData>();
			}
			else
			{
				ResourceItemList.Clear();
			}
			for (int num3 = 0; num3 < elementsCount6; num3++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element6;
				if (num4 > 0)
				{
					element6 = new ItemDisplayData();
					pCurrData += element6.Deserialize(pCurrData);
				}
				else
				{
					element6 = null;
				}
				ResourceItemList.Add(element6);
			}
		}
		else
		{
			ResourceItemList?.Clear();
		}
		int HeavenlyTreeBlockDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (HeavenlyTreeBlockDictElementsCount > 0)
		{
			if (HeavenlyTreeBlockDict == null)
			{
				HeavenlyTreeBlockDict = new Dictionary<int, DefendHeavenlyTreeBlockData>();
			}
			else
			{
				HeavenlyTreeBlockDict.Clear();
			}
			for (int num5 = 0; num5 < HeavenlyTreeBlockDictElementsCount; num5++)
			{
				int key2 = *(int*)pCurrData;
				pCurrData += 4;
				DefendHeavenlyTreeBlockData value2 = new DefendHeavenlyTreeBlockData();
				pCurrData += value2.Deserialize(pCurrData);
				HeavenlyTreeBlockDict.Add(key2, value2);
			}
		}
		else
		{
			HeavenlyTreeBlockDict?.Clear();
		}
		int HeavenlyTreeVisibleBlockDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (HeavenlyTreeVisibleBlockDictElementsCount > 0)
		{
			if (HeavenlyTreeVisibleBlockDict == null)
			{
				HeavenlyTreeVisibleBlockDict = new Dictionary<int, DefendHeavenlyTreeBlockData>();
			}
			else
			{
				HeavenlyTreeVisibleBlockDict.Clear();
			}
			for (int num6 = 0; num6 < HeavenlyTreeVisibleBlockDictElementsCount; num6++)
			{
				int key3 = *(int*)pCurrData;
				pCurrData += 4;
				DefendHeavenlyTreeBlockData value3 = new DefendHeavenlyTreeBlockData();
				pCurrData += value3.Deserialize(pCurrData);
				HeavenlyTreeVisibleBlockDict.Add(key3, value3);
			}
		}
		else
		{
			HeavenlyTreeVisibleBlockDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
