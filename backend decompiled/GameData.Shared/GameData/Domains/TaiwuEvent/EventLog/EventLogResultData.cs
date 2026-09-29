using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character.Display;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.TaiwuEvent.EventLog;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class EventLogResultData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte Type;

	[SerializableGameDataField]
	public bool IsLosing;

	[SerializableGameDataField]
	public List<int> ValueList;

	[SerializableGameDataField]
	public Dictionary<int, NameStringAndAvatar> CharDict;

	[SerializableGameDataField]
	public string Text;

	[SerializableGameDataField]
	public EventActorData LeftActorData;

	[SerializableGameDataField]
	public EventActorData RightActorData;

	[SerializableGameDataField]
	public string LeftName;

	[SerializableGameDataField]
	public string RightName;

	public EventLogResultData()
	{
		Type = -1;
		IsLosing = false;
		ValueList = new List<int> { 0 };
		Text = null;
		LeftActorData = null;
		RightActorData = null;
		LeftName = null;
		RightName = null;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(string.Format("type: {0}; isLosing: {1}; text: {2}; avatar count: {3}; avatars: ", Type, IsLosing, Text ?? "null", ValueList[0]));
		for (int i = 1; i <= ValueList[0]; i++)
		{
			sb.Append($"{ValueList[i]}, ");
		}
		sb.Append("; remaining values: ");
		for (int j = ValueList[0] + 1; j < ValueList.Count; j++)
		{
			sb.Append($"{ValueList[j]}, ");
		}
		return sb.ToString();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((ValueList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ValueList.Count)));
		totalSize += 4;
		if (CharDict != null)
		{
			foreach (KeyValuePair<int, NameStringAndAvatar> pair in CharDict)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize = ((Text == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Text.Length)));
		totalSize = ((LeftActorData == null) ? (totalSize + 2) : (totalSize + (2 + LeftActorData.GetSerializedSize())));
		totalSize = ((RightActorData == null) ? (totalSize + 2) : (totalSize + (2 + RightActorData.GetSerializedSize())));
		totalSize = ((LeftName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LeftName.Length)));
		totalSize = ((RightName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * RightName.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)Type;
		pCurrData++;
		*pCurrData = (IsLosing ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ValueList != null)
		{
			int elementsCount = ValueList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = ValueList[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CharDict != null)
		{
			*(int*)pCurrData = CharDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, NameStringAndAvatar> pair in CharDict)
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
		if (Text != null)
		{
			int stringCount = Text.Length;
			Tester.Assert(stringCount <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount;
			pCurrData += 2;
			fixed (char* pChar = Text)
			{
				for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
				{
					((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
				}
			}
			pCurrData += 2 * stringCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LeftActorData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = LeftActorData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RightActorData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = RightActorData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LeftName != null)
		{
			int stringCount2 = LeftName.Length;
			Tester.Assert(stringCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount2;
			pCurrData += 2;
			fixed (char* pChar2 = LeftName)
			{
				for (int j = 0; j < stringCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * stringCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RightName != null)
		{
			int stringCount3 = RightName.Length;
			Tester.Assert(stringCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount3;
			pCurrData += 2;
			fixed (char* pChar3 = RightName)
			{
				for (int k = 0; k < stringCount3; k++)
				{
					((short*)pCurrData)[k] = (short)pChar3[k];
				}
			}
			pCurrData += 2 * stringCount3;
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
		Type = (sbyte)(*pCurrData);
		pCurrData++;
		IsLosing = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ValueList == null)
			{
				ValueList = new List<int>();
			}
			else
			{
				ValueList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int element = *(int*)pCurrData;
				pCurrData += 4;
				ValueList.Add(element);
			}
		}
		else
		{
			ValueList?.Clear();
		}
		int CharDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharDictElementsCount > 0)
		{
			if (CharDict == null)
			{
				CharDict = new Dictionary<int, NameStringAndAvatar>();
			}
			else
			{
				CharDict.Clear();
			}
			for (int j = 0; j < CharDictElementsCount; j++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				NameStringAndAvatar value = default(NameStringAndAvatar);
				pCurrData += value.Deserialize(pCurrData);
				CharDict.Add(key, value);
			}
		}
		else
		{
			CharDict?.Clear();
		}
		ushort stringCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount > 0)
		{
			int fieldSize = 2 * stringCount;
			Text = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Text = null;
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			LeftActorData = new EventActorData();
			pCurrData += LeftActorData.Deserialize(pCurrData);
		}
		else
		{
			LeftActorData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			RightActorData = new EventActorData();
			pCurrData += RightActorData.Deserialize(pCurrData);
		}
		else
		{
			RightActorData = null;
		}
		ushort stringCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount2 > 0)
		{
			int fieldSize2 = 2 * stringCount2;
			LeftName = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			LeftName = null;
		}
		ushort stringCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount3 > 0)
		{
			int fieldSize3 = 2 * stringCount3;
			RightName = Encoding.Unicode.GetString(pCurrData, fieldSize3);
			pCurrData += fieldSize3;
		}
		else
		{
			RightName = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
