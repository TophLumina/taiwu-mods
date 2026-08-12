using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 传递给显示模块的事件数据组合
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class TaiwuEventDisplayData : ISerializableGameData
{
	/// <summary>
	/// 事件的GUID
	/// </summary>
	[SerializableGameDataField]
	public string EventGuid;

	/// <summary>
	/// 选项上的角色
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData MainCharacter;

	/// <summary>
	/// 背景图位置的人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData TargetCharacter;

	/// <summary>
	/// 用于目标角色显示的额外数据
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public TaiwuEventDisplayExtraData ExtraData;

	/// <summary>
	/// 事件经过占位符替换以后的最终字符串。
	/// !!!没有进行颜色的替换!!!
	/// </summary>
	[SerializableGameDataField]
	public string EventContent;

	/// <summary>
	/// 解析该事件要使用到的全部姓名相关数据
	/// </summary>
	[SerializableGameDataField]
	public List<TaiwuEventCharacterNameDecodeData> NameDecodeDataList;

	/// <summary>
	/// 额外的格式化多语言Key
	/// </summary>
	[SerializableGameDataField]
	public List<string> ExtraFormatLanguageKeys;

	/// <summary>
	/// 事件背景图的名字或者路径
	/// </summary>
	[SerializableGameDataField]
	public string EventTexture;

	/// <summary>
	/// 事件背景遮罩控制码
	/// </summary>
	[SerializableGameDataField]
	public sbyte MaskControlCode;

	/// <summary>
	/// 事件背景遮罩渐变时间(使用的时候乘以0.01f)
	/// </summary>
	[SerializableGameDataField]
	public ushort MaskTweenTime;

	/// <summary>
	/// 被绑定于Esc快捷选中的选项在EventOptionInfos中的索引
	/// </summary>
	[SerializableGameDataField]
	public sbyte EscOptionIndex;

	/// <summary>
	/// 事件处理好的用于显示UI的选项信息
	/// </summary>
	[SerializableGameDataField]
	public List<EventOptionInfo> EventOptionInfos;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((EventGuid == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EventGuid.Length)));
		totalSize = ((MainCharacter == null) ? (totalSize + 2) : (totalSize + (2 + MainCharacter.GetSerializedSize())));
		totalSize = ((TargetCharacter == null) ? (totalSize + 2) : (totalSize + (2 + TargetCharacter.GetSerializedSize())));
		totalSize = ((ExtraData == null) ? (totalSize + 4) : (totalSize + (4 + ExtraData.GetSerializedSize())));
		totalSize = ((EventContent == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EventContent.Length)));
		totalSize = ((NameDecodeDataList == null) ? (totalSize + 2) : (totalSize + (2 + 36 * NameDecodeDataList.Count)));
		if (ExtraFormatLanguageKeys != null)
		{
			totalSize += 2;
			int elementsCount = ExtraFormatLanguageKeys.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = ExtraFormatLanguageKeys[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((EventTexture == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EventTexture.Length)));
		if (EventOptionInfos != null)
		{
			totalSize += 2;
			int elementsCount2 = EventOptionInfos.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				totalSize += EventOptionInfos[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (EventGuid != null)
		{
			int elementsCount = EventGuid.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = EventGuid)
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
		if (MainCharacter != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = MainCharacter.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetCharacter != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = TargetCharacter.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 4;
			int fieldSize3 = ExtraData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= int.MaxValue);
			*(int*)intPtr3 = fieldSize3;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (EventContent != null)
		{
			int elementsCount2 = EventContent.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = EventContent)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (NameDecodeDataList != null)
		{
			int elementsCount3 = NameDecodeDataList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += NameDecodeDataList[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraFormatLanguageKeys != null)
		{
			int elementsCount4 = ExtraFormatLanguageKeys.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				string element = ExtraFormatLanguageKeys[l];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar3 = element)
					{
						for (int m = 0; m < subElementsCount; m++)
						{
							((short*)pCurrData)[m] = (short)pChar3[m];
						}
					}
					pCurrData += 2 * subElementsCount;
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
		if (EventTexture != null)
		{
			int elementsCount5 = EventTexture.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			fixed (char* pChar4 = EventTexture)
			{
				for (int n = 0; n < elementsCount5; n++)
				{
					((short*)pCurrData)[n] = (short)pChar4[n];
				}
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)MaskControlCode;
		pCurrData++;
		*(ushort*)pCurrData = MaskTweenTime;
		pCurrData += 2;
		*pCurrData = (byte)EscOptionIndex;
		pCurrData++;
		if (EventOptionInfos != null)
		{
			int elementsCount6 = EventOptionInfos.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int num = 0; num < elementsCount6; num++)
			{
				int subDataSize = EventOptionInfos[num].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
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
			EventGuid = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			EventGuid = null;
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (MainCharacter == null)
			{
				MainCharacter = new CharacterDisplayData();
			}
			pCurrData += MainCharacter.Deserialize(pCurrData);
		}
		else
		{
			MainCharacter = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (TargetCharacter == null)
			{
				TargetCharacter = new CharacterDisplayData();
			}
			pCurrData += TargetCharacter.Deserialize(pCurrData);
		}
		else
		{
			TargetCharacter = null;
		}
		int num3 = *(int*)pCurrData;
		pCurrData += 4;
		if (num3 > 0)
		{
			if (ExtraData == null)
			{
				ExtraData = new TaiwuEventDisplayExtraData();
			}
			pCurrData += ExtraData.Deserialize(pCurrData);
		}
		else
		{
			ExtraData = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			EventContent = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			EventContent = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (NameDecodeDataList == null)
			{
				NameDecodeDataList = new List<TaiwuEventCharacterNameDecodeData>(elementsCount3);
			}
			else
			{
				NameDecodeDataList.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				TaiwuEventCharacterNameDecodeData element = default(TaiwuEventCharacterNameDecodeData);
				pCurrData += element.Deserialize(pCurrData);
				NameDecodeDataList.Add(element);
			}
		}
		else
		{
			NameDecodeDataList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ExtraFormatLanguageKeys == null)
			{
				ExtraFormatLanguageKeys = new List<string>(elementsCount4);
			}
			else
			{
				ExtraFormatLanguageKeys.Clear();
			}
			for (int j = 0; j < elementsCount4; j++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					ExtraFormatLanguageKeys.Add(Encoding.Unicode.GetString(pCurrData, subDataSize));
					pCurrData += subDataSize;
				}
				else
				{
					ExtraFormatLanguageKeys.Add(null);
				}
			}
		}
		else
		{
			ExtraFormatLanguageKeys?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			int fieldSize3 = 2 * elementsCount5;
			EventTexture = Encoding.Unicode.GetString(pCurrData, fieldSize3);
			pCurrData += fieldSize3;
		}
		else
		{
			EventTexture = null;
		}
		MaskControlCode = (sbyte)(*pCurrData);
		pCurrData++;
		MaskTweenTime = *(ushort*)pCurrData;
		pCurrData += 2;
		EscOptionIndex = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (EventOptionInfos == null)
			{
				EventOptionInfos = new List<EventOptionInfo>(elementsCount6);
			}
			else
			{
				EventOptionInfos.Clear();
			}
			for (int k = 0; k < elementsCount6; k++)
			{
				EventOptionInfo element2 = default(EventOptionInfo);
				pCurrData += element2.Deserialize(pCurrData);
				EventOptionInfos.Add(element2);
			}
		}
		else
		{
			EventOptionInfos?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
