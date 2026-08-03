using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

/// <summary>
/// 地区主线 - 铸剑 - 机关人 武学和技艺 显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class SectZhujianGearMateSkillDisplayData : ISerializableGameData
{
	/// <summary>
	/// 机关人数据
	/// </summary>
	[SerializableGameDataField]
	public GearMate GearMate;

	/// <summary>
	/// 机关人显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData GearMateDisplayData;

	/// <summary>
	/// 武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	/// <summary>
	/// 武学造诣
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	/// <summary>
	/// 技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	/// <summary>
	/// 技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 目标已学技艺列表
	/// </summary>
	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkills;

	/// <summary>
	/// 功法盘配置数据
	/// </summary>
	[SerializableGameDataField]
	public short[] CombatSkillAttainmentPanels;

	/// <summary>
	/// 是否可以使用仓库
	/// </summary>
	[SerializableGameDataField]
	public bool CanUseWarehouse;

	/// <summary>
	/// 太吾持有的机关人可读书籍物品（包含行囊、私库、公库）
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> CanReadBookItemList;

	/// <summary>
	/// 书页显示数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, SkillBookPageDisplayData> PageDisplayDataDict;

	/// <summary>
	///             太吾历练
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuExp;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((GearMate == null) ? (totalSize + 2) : (totalSize + (2 + GearMate.GetSerializedSize())));
		totalSize = ((GearMateDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + GearMateDisplayData.GetSerializedSize())));
		totalSize += CombatSkillQualifications.GetSerializedSize();
		totalSize += CombatSkillAttainments.GetSerializedSize();
		totalSize += LifeSkillQualifications.GetSerializedSize();
		totalSize += LifeSkillAttainments.GetSerializedSize();
		totalSize = ((LearnedLifeSkills == null) ? (totalSize + 2) : (totalSize + (2 + default(LifeSkillItem).GetSerializedSize() * LearnedLifeSkills.Count)));
		totalSize = ((CombatSkillAttainmentPanels == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CombatSkillAttainmentPanels.Length)));
		if (CanReadBookItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CanReadBookItemList.Count; i++)
			{
				totalSize = ((CanReadBookItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CanReadBookItemList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (PageDisplayDataDict != null)
		{
			foreach (KeyValuePair<int, SkillBookPageDisplayData> pair in PageDisplayDataDict)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
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
		if (GearMate != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = GearMate.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GearMateDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GearMateDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		if (LearnedLifeSkills != null)
		{
			int elementsCount = LearnedLifeSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += LearnedLifeSkills[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkillAttainmentPanels != null)
		{
			int elementsCount2 = CombatSkillAttainmentPanels.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(short*)pCurrData = CombatSkillAttainmentPanels[j];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CanUseWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CanReadBookItemList != null)
		{
			int elementsCount3 = CanReadBookItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (CanReadBookItemList[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = CanReadBookItemList[k].Serialize(pCurrData);
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
		if (PageDisplayDataDict != null)
		{
			*(int*)pCurrData = PageDisplayDataDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, SkillBookPageDisplayData> pair in PageDisplayDataDict)
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
		*(int*)pCurrData = TaiwuExp;
		pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			GearMate = new GearMate();
			pCurrData += GearMate.Deserialize(pCurrData);
		}
		else
		{
			GearMate = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			GearMateDisplayData = new CharacterDisplayData();
			pCurrData += GearMateDisplayData.Deserialize(pCurrData);
		}
		else
		{
			GearMateDisplayData = null;
		}
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedLifeSkills == null)
			{
				LearnedLifeSkills = new List<LifeSkillItem>();
			}
			else
			{
				LearnedLifeSkills.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				LifeSkillItem element = default(LifeSkillItem);
				pCurrData += element.Deserialize(pCurrData);
				LearnedLifeSkills.Add(element);
			}
		}
		else
		{
			LearnedLifeSkills?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CombatSkillAttainmentPanels == null || CombatSkillAttainmentPanels.Length != elementsCount2)
			{
				CombatSkillAttainmentPanels = new short[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				CombatSkillAttainmentPanels[j] = *(short*)pCurrData;
				pCurrData += 2;
			}
		}
		else
		{
			CombatSkillAttainmentPanels = null;
		}
		CanUseWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CanReadBookItemList == null)
			{
				CanReadBookItemList = new List<ItemDisplayData>();
			}
			else
			{
				CanReadBookItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num3 > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				CanReadBookItemList.Add(element2);
			}
		}
		else
		{
			CanReadBookItemList?.Clear();
		}
		int PageDisplayDataDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (PageDisplayDataDictElementsCount > 0)
		{
			if (PageDisplayDataDict == null)
			{
				PageDisplayDataDict = new Dictionary<int, SkillBookPageDisplayData>();
			}
			else
			{
				PageDisplayDataDict.Clear();
			}
			for (int l = 0; l < PageDisplayDataDictElementsCount; l++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				SkillBookPageDisplayData value = new SkillBookPageDisplayData();
				pCurrData += value.Deserialize(pCurrData);
				PageDisplayDataDict.Add(key, value);
			}
		}
		else
		{
			PageDisplayDataDict?.Clear();
		}
		TaiwuExp = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
