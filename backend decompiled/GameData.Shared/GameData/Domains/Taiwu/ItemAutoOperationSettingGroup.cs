using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class ItemAutoOperationSettingGroup : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort OperationType = 0;

		public const ushort IsEnabled = 1;

		public const ushort SourceList = 2;

		public const ushort TypeDict = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "OperationType", "IsEnabled", "SourceList", "TypeDict" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public EItemAutoOperationType OperationType;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool IsEnabled;

	[SerializableGameDataField(FieldIndex = 2)]
	public List<EItemAutoOperationSource> SourceList = new List<EItemAutoOperationSource>();

	[SerializableGameDataField(FieldIndex = 3)]
	public Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> TypeDict = new Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem>();

	public static readonly List<EItemAutoOperationTargetType> DisassembleTargetTypeList = new List<EItemAutoOperationTargetType>
	{
		EItemAutoOperationTargetType.Weapon,
		EItemAutoOperationTargetType.OtherEquipment,
		EItemAutoOperationTargetType.Material
	};

	public static readonly List<EItemAutoOperationTargetType> DiscardTargetTypeList = new List<EItemAutoOperationTargetType>
	{
		EItemAutoOperationTargetType.Food,
		EItemAutoOperationTargetType.Medicine,
		EItemAutoOperationTargetType.Weapon,
		EItemAutoOperationTargetType.OtherEquipment,
		EItemAutoOperationTargetType.Book,
		EItemAutoOperationTargetType.Tool,
		EItemAutoOperationTargetType.Material,
		EItemAutoOperationTargetType.RefineMaterial
	};

	public void Init(EItemAutoOperationType operationType)
	{
		OperationType = operationType;
		IsEnabled = false;
		SourceList.Clear();
		for (EItemAutoOperationSource i = EItemAutoOperationSource.Combat; i < EItemAutoOperationSource.Count; i++)
		{
			SourceList.Add(i);
		}
		TypeDict.Clear();
		List<EItemAutoOperationTargetType> targetTypeList = GetTargetTypeList(operationType);
		for (int j = 0; j < targetTypeList.Count; j++)
		{
			ItemAutoOperationSettingItem item = new ItemAutoOperationSettingItem();
			EItemAutoOperationTargetType targetType = targetTypeList[j];
			item.Init(targetType);
			TypeDict[targetType] = item;
		}
	}

	public static List<EItemAutoOperationTargetType> GetTargetTypeList(EItemAutoOperationType operationType)
	{
		return operationType switch
		{
			EItemAutoOperationType.Discard => DiscardTargetTypeList, 
			EItemAutoOperationType.Disassemble => DisassembleTargetTypeList, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public ItemAutoOperationSettingGroup()
	{
	}

	public ItemAutoOperationSettingGroup(ItemAutoOperationSettingGroup other)
	{
		OperationType = other.OperationType;
		IsEnabled = other.IsEnabled;
		SourceList = ((other.SourceList == null) ? null : new List<EItemAutoOperationSource>(other.SourceList));
		if (other.TypeDict != null)
		{
			Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> typeDict = other.TypeDict;
			int elementsCount = typeDict.Count;
			TypeDict = new Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem>(elementsCount);
			{
				foreach (KeyValuePair<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> element in typeDict)
				{
					TypeDict.Add(element.Key, new ItemAutoOperationSettingItem(element.Value));
				}
				return;
			}
		}
		TypeDict = null;
	}

	public void Assign(ItemAutoOperationSettingGroup other)
	{
		OperationType = other.OperationType;
		IsEnabled = other.IsEnabled;
		SourceList = ((other.SourceList == null) ? null : new List<EItemAutoOperationSource>(other.SourceList));
		if (other.TypeDict != null)
		{
			Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> typeDict = other.TypeDict;
			int elementsCount = typeDict.Count;
			TypeDict = new Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem>(elementsCount);
			{
				foreach (KeyValuePair<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> element in typeDict)
				{
					TypeDict.Add(element.Key, new ItemAutoOperationSettingItem(element.Value));
				}
				return;
			}
		}
		TypeDict = null;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((SourceList == null) ? (totalSize + 2) : (totalSize + (2 + SourceList.Count)));
		totalSize += 4;
		if (TypeDict != null)
		{
			foreach (KeyValuePair<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> pair in TypeDict)
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
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*pCurrData = (byte)(sbyte)OperationType;
		pCurrData++;
		*pCurrData = (IsEnabled ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SourceList != null)
		{
			int elementsCount = SourceList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)(sbyte)SourceList[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TypeDict != null)
		{
			*(int*)pCurrData = TypeDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EItemAutoOperationTargetType, ItemAutoOperationSettingItem> pair in TypeDict)
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
			OperationType = (EItemAutoOperationType)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 1)
		{
			IsEnabled = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SourceList == null)
				{
					SourceList = new List<EItemAutoOperationSource>();
				}
				else
				{
					SourceList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					EItemAutoOperationSource element = (EItemAutoOperationSource)(*pCurrData);
					pCurrData++;
					SourceList.Add(element);
				}
			}
			else
			{
				SourceList?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			int TypeDictElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (TypeDictElementsCount > 0)
			{
				if (TypeDict == null)
				{
					TypeDict = new Dictionary<EItemAutoOperationTargetType, ItemAutoOperationSettingItem>();
				}
				else
				{
					TypeDict.Clear();
				}
				for (int j = 0; j < TypeDictElementsCount; j++)
				{
					EItemAutoOperationTargetType key = (EItemAutoOperationTargetType)(*pCurrData);
					pCurrData++;
					ItemAutoOperationSettingItem value = new ItemAutoOperationSettingItem();
					pCurrData += value.Deserialize(pCurrData);
					TypeDict.Add(key, value);
				}
			}
			else
			{
				TypeDict?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
