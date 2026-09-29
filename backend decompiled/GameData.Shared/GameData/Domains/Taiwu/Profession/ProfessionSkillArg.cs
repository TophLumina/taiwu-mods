using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Profession;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class ProfessionSkillArg : ISerializableGameData
{
	[SerializableGameDataField]
	public int ProfessionId;

	[SerializableGameDataField]
	public int SkillId;

	[SerializableGameDataField]
	public bool IsSuccess;

	[SerializableGameDataField]
	public ItemKey ItemKey;

	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public sbyte CombatSkillType;

	[SerializableGameDataField]
	public sbyte LifeSkillType;

	[SerializableGameDataField]
	public short EffectId;

	[SerializableGameDataField]
	public bool IsExtraordinary;

	[SerializableGameDataField]
	public List<int> CharIds;

	[SerializableGameDataField]
	public List<int> BookIds;

	[SerializableGameDataField]
	public bool SkipConfirm;

	[SerializableGameDataField]
	public bool SkipAnimation;

	[SerializableGameDataField]
	public ItemDisplayData MakeMedicineCostMedicine;

	[SerializableGameDataField]
	public ItemDisplayData MakeMedicineCostTool;

	[SerializableGameDataField]
	public int MakeMedicineCount;

	[SerializableGameDataField]
	public Location ProfessionTravelerTargetLocation;

	[SerializableGameDataField]
	public List<short> EffectBlocks;

	[SerializableGameDataField]
	public CombatResultDisplayData CombatResultData;

	[SerializableGameDataField]
	public ItemKey WeaponKey;

	[SerializableGameDataField]
	public List<sbyte> TrickList;

	[SerializableGameDataField]
	public ItemKey ToolKey;

	[SerializableGameDataField]
	public ItemSourceType ToolSourceType;

	[SerializableGameDataField]
	public Dictionary<ItemSourceType, Inventory> CostMaterials;

	[SerializableGameDataField]
	public int ChangeCountToLast;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 57;
		totalSize = ((CharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CharIds.Count)));
		totalSize = ((BookIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * BookIds.Count)));
		totalSize = ((MakeMedicineCostMedicine == null) ? (totalSize + 2) : (totalSize + (2 + MakeMedicineCostMedicine.GetSerializedSize())));
		totalSize = ((MakeMedicineCostTool == null) ? (totalSize + 2) : (totalSize + (2 + MakeMedicineCostTool.GetSerializedSize())));
		totalSize = ((EffectBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EffectBlocks.Count)));
		totalSize = ((CombatResultData == null) ? (totalSize + 2) : (totalSize + (2 + CombatResultData.GetSerializedSize())));
		totalSize = ((TrickList == null) ? (totalSize + 2) : (totalSize + (2 + TrickList.Count)));
		totalSize += 4;
		if (CostMaterials != null)
		{
			foreach (KeyValuePair<ItemSourceType, Inventory> pair in CostMaterials)
			{
				totalSize++;
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
		*(int*)pCurrData = ProfessionId;
		pCurrData += 4;
		*(int*)pCurrData = SkillId;
		pCurrData += 4;
		*pCurrData = (IsSuccess ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += ItemKey.Serialize(pCurrData);
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*pCurrData = (byte)CombatSkillType;
		pCurrData++;
		*pCurrData = (byte)LifeSkillType;
		pCurrData++;
		*(short*)pCurrData = EffectId;
		pCurrData += 2;
		*pCurrData = (IsExtraordinary ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CharIds != null)
		{
			int elementsCount = CharIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = CharIds[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BookIds != null)
		{
			int elementsCount2 = BookIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = BookIds[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (SkipConfirm ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (SkipAnimation ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (MakeMedicineCostMedicine != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = MakeMedicineCostMedicine.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MakeMedicineCostTool != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = MakeMedicineCostTool.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = MakeMedicineCount;
		pCurrData += 4;
		pCurrData += ProfessionTravelerTargetLocation.Serialize(pCurrData);
		if (EffectBlocks != null)
		{
			int elementsCount3 = EffectBlocks.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(short*)pCurrData = EffectBlocks[k];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatResultData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = CombatResultData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += WeaponKey.Serialize(pCurrData);
		if (TrickList != null)
		{
			int elementsCount4 = TrickList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*pCurrData = (byte)TrickList[l];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += ToolKey.Serialize(pCurrData);
		*pCurrData = (byte)(sbyte)ToolSourceType;
		pCurrData++;
		if (CostMaterials != null)
		{
			*(int*)pCurrData = CostMaterials.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ItemSourceType, Inventory> pair in CostMaterials)
			{
				*pCurrData = (byte)(sbyte)pair.Key;
				pCurrData++;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = ChangeCountToLast;
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
		ProfessionId = *(int*)pCurrData;
		pCurrData += 4;
		SkillId = *(int*)pCurrData;
		pCurrData += 4;
		IsSuccess = *pCurrData != 0;
		pCurrData++;
		pCurrData += ItemKey.Deserialize(pCurrData);
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		CombatSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		LifeSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		EffectId = *(short*)pCurrData;
		pCurrData += 2;
		IsExtraordinary = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharIds == null)
			{
				CharIds = new List<int>();
			}
			else
			{
				CharIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int element = *(int*)pCurrData;
				pCurrData += 4;
				CharIds.Add(element);
			}
		}
		else
		{
			CharIds?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BookIds == null)
			{
				BookIds = new List<int>();
			}
			else
			{
				BookIds.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int element2 = *(int*)pCurrData;
				pCurrData += 4;
				BookIds.Add(element2);
			}
		}
		else
		{
			BookIds?.Clear();
		}
		SkipConfirm = *pCurrData != 0;
		pCurrData++;
		SkipAnimation = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			MakeMedicineCostMedicine = new ItemDisplayData();
			pCurrData += MakeMedicineCostMedicine.Deserialize(pCurrData);
		}
		else
		{
			MakeMedicineCostMedicine = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			MakeMedicineCostTool = new ItemDisplayData();
			pCurrData += MakeMedicineCostTool.Deserialize(pCurrData);
		}
		else
		{
			MakeMedicineCostTool = null;
		}
		MakeMedicineCount = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ProfessionTravelerTargetLocation.Deserialize(pCurrData);
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (EffectBlocks == null)
			{
				EffectBlocks = new List<short>();
			}
			else
			{
				EffectBlocks.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				short element3 = *(short*)pCurrData;
				pCurrData += 2;
				EffectBlocks.Add(element3);
			}
		}
		else
		{
			EffectBlocks?.Clear();
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			CombatResultData = new CombatResultDisplayData();
			pCurrData += CombatResultData.Deserialize(pCurrData);
		}
		else
		{
			CombatResultData = null;
		}
		pCurrData += WeaponKey.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (TrickList == null)
			{
				TrickList = new List<sbyte>();
			}
			else
			{
				TrickList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				sbyte element4 = (sbyte)(*pCurrData);
				pCurrData++;
				TrickList.Add(element4);
			}
		}
		else
		{
			TrickList?.Clear();
		}
		pCurrData += ToolKey.Deserialize(pCurrData);
		ToolSourceType = (ItemSourceType)(*pCurrData);
		pCurrData++;
		int CostMaterialsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CostMaterialsElementsCount > 0)
		{
			if (CostMaterials == null)
			{
				CostMaterials = new Dictionary<ItemSourceType, Inventory>();
			}
			else
			{
				CostMaterials.Clear();
			}
			for (int m = 0; m < CostMaterialsElementsCount; m++)
			{
				ItemSourceType key = (ItemSourceType)(*pCurrData);
				pCurrData++;
				Inventory value = new Inventory();
				pCurrData += value.Deserialize(pCurrData);
				CostMaterials.Add(key, value);
			}
		}
		else
		{
			CostMaterials?.Clear();
		}
		ChangeCountToLast = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
