using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑自动指派预设
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class BuildingOptionAutoAddSoldItemPreset : ISerializableGameData
{
	public enum EGradeOrder : sbyte
	{
		Invalid,
		/// <summary>
		/// 优先高品级
		/// </summary>
		High,
		/// <summary>
		/// 优先低品级
		/// </summary>
		Low
	}

	[Flags]
	public enum EPropertyOrder : sbyte
	{
		Invalid = 0,
		/// <summary>
		/// 价值最高
		/// </summary>
		MaxValue = 1,
		/// <summary>
		/// 数量最多
		/// </summary>
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

	/// <summary>
	/// 物品类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public List<sbyte> ItemTypeList;

	/// <summary>
	/// 最小品级
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte MinGrade;

	/// <summary>
	/// 最大品级
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte MaxGrade = 8;

	/// <summary>
	/// 优先品级
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte GradeOrder = 1;

	/// <summary>
	/// 优先属性
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte PropertyOrder = 3;

	public EPropertyOrder PropertyOrderEnum => (EPropertyOrder)PropertyOrder;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingOptionAutoAddSoldItemPreset()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingOptionAutoAddSoldItemPreset(BuildingOptionAutoAddSoldItemPreset other)
	{
		ItemTypeList = ((other.ItemTypeList == null) ? null : new List<sbyte>(other.ItemTypeList));
		MinGrade = other.MinGrade;
		MaxGrade = other.MaxGrade;
		GradeOrder = other.GradeOrder;
		PropertyOrder = other.PropertyOrder;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
