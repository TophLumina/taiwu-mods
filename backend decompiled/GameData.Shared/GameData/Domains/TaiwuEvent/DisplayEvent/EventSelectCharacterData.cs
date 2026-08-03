using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件系统调用角色选择弹窗时的参数
/// </summary>
public class EventSelectCharacterData : ISerializableGameData
{
	/// <summary>
	/// 可以被选择的角色列表
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<CharacterSelectFilter> FilterList;

	/// <summary>
	/// 是否对规则采用或运算
	/// </summary>
	[SerializableGameDataField]
	public bool UseOrOperate;

	[SerializableGameDataField]
	public SelectApprovedTaiwu SelectApprovedTaiwu;

	/// <summary>
	/// 事件选人时额外显示的页签
	/// </summary>
	[SerializableGameDataField]
	public sbyte ExtraSubPage;

	/// <summary>
	/// 选择完毕的回调.
	/// 该逻辑只在后端使用.
	/// </summary>
	public Action OnSelectComplete;

	public bool IsAvailableSelectResult(List<int> charIdList)
	{
		if (charIdList == null || charIdList.Count <= 0)
		{
			return false;
		}
		List<CharacterSelectFilter> list = new List<CharacterSelectFilter>(FilterList);
		foreach (int charId in charIdList)
		{
			bool matchFlag = false;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i].AvailableCharactersDisplayDataList != null && list[i].AvailableCharactersDisplayDataList.Select((CharacterDisplayData element) => element.CharacterId).ToList().Contains(charId))
				{
					matchFlag = true;
					list.RemoveAt(i);
					break;
				}
			}
			if (UseOrOperate)
			{
				if (matchFlag)
				{
					return true;
				}
			}
			else if (!matchFlag)
			{
				return false;
			}
		}
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (FilterList != null)
		{
			totalSize += 2;
			int elementsCount = FilterList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += FilterList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((SelectApprovedTaiwu == null) ? (totalSize + 2) : (totalSize + (2 + SelectApprovedTaiwu.GetSerializedSize())));
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
		if (FilterList != null)
		{
			int elementsCount = FilterList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = FilterList[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= int.MaxValue);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (UseOrOperate ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SelectApprovedTaiwu != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SelectApprovedTaiwu.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)ExtraSubPage;
		pCurrData++;
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
			if (FilterList == null)
			{
				FilterList = new List<CharacterSelectFilter>(elementsCount);
			}
			else
			{
				FilterList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterSelectFilter element = default(CharacterSelectFilter);
				pCurrData += element.Deserialize(pCurrData);
				FilterList.Add(element);
			}
		}
		else
		{
			FilterList?.Clear();
		}
		UseOrOperate = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SelectApprovedTaiwu == null)
			{
				SelectApprovedTaiwu = new SelectApprovedTaiwu();
			}
			pCurrData += SelectApprovedTaiwu.Deserialize(pCurrData);
		}
		else
		{
			SelectApprovedTaiwu = null;
		}
		ExtraSubPage = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
