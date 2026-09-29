using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class BuildingOptionAutoAddSoldItemPreset : ISerializableGameData
{
	public enum EGradeOrder : sbyte
	{
		Invalid,
		High,
		Low
	}

	[Flags]
	public enum EPropertyOrder : sbyte
	{
		Invalid = 0,
		MaxValue = 1,
		MaxAmount = 2
	}

	public static class FieldIds
	{
		public const ushort ItemTypeList = 0;

		public const ushort MinGrade = 1;

		public const ushort MaxGrade = 2;

		public const ushort GradeOrder = 3;

		public const ushort PropertyOrder = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "ItemTypeList", "MinGrade", "MaxGrade", "GradeOrder", "PropertyOrder" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<sbyte> ItemTypeList;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte MinGrade;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte MaxGrade = 8;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte GradeOrder = 1;

	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte PropertyOrder = 3;

	public EPropertyOrder PropertyOrderEnum => (EPropertyOrder)PropertyOrder;

	public BuildingOptionAutoAddSoldItemPreset()
	{
	}

	public BuildingOptionAutoAddSoldItemPreset(BuildingOptionAutoAddSoldItemPreset other)
	{
		ItemTypeList = ((other.ItemTypeList == null) ? null : new List<sbyte>(other.ItemTypeList));
		MinGrade = other.MinGrade;
		MaxGrade = other.MaxGrade;
		GradeOrder = other.GradeOrder;
		PropertyOrder = other.PropertyOrder;
	}

	public void Assign(BuildingOptionAutoAddSoldItemPreset other)
	{
		ItemTypeList = ((other.ItemTypeList == null) ? null : new List<sbyte>(other.ItemTypeList));
		MinGrade = other.MinGrade;
		MaxGrade = other.MaxGrade;
		GradeOrder = other.GradeOrder;
		PropertyOrder = other.PropertyOrder;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((ItemTypeList == null) ? (totalSize + 2) : (totalSize + (2 + ItemTypeList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		if (ItemTypeList != null)
		{
			int elementsCount = ItemTypeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)ItemTypeList[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)MinGrade;
		pCurrData++;
		*pCurrData = (byte)MaxGrade;
		pCurrData++;
		*pCurrData = (byte)GradeOrder;
		pCurrData++;
		*pCurrData = (byte)PropertyOrder;
		pCurrData++;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ItemTypeList == null)
				{
					ItemTypeList = new List<sbyte>();
				}
				else
				{
					ItemTypeList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					sbyte element = (sbyte)(*pCurrData);
					pCurrData++;
					ItemTypeList.Add(element);
				}
			}
			else
			{
				ItemTypeList?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			MinGrade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			MaxGrade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			GradeOrder = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			PropertyOrder = (sbyte)(*pCurrData);
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
