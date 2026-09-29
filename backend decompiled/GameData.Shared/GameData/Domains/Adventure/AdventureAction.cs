using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public class AdventureAction : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort Key = 1;

		public const ushort RemainTime = 2;

		public const ushort ContainsTaiwu = 3;

		public const ushort Elements = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "Id", "Key", "RemainTime", "ContainsTaiwu", "Elements" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int Id;

	[SerializableGameDataField(FieldIndex = 1)]
	public string Key;

	[SerializableGameDataField(FieldIndex = 2)]
	public int RemainTime;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool ContainsTaiwu;

	[SerializableGameDataField(FieldIndex = 4)]
	public List<int> Elements;

	public AdventureAction()
	{
	}

	public AdventureAction(AdventureAction other)
	{
		Id = other.Id;
		Key = other.Key;
		RemainTime = other.RemainTime;
		ContainsTaiwu = other.ContainsTaiwu;
		Elements = ((other.Elements == null) ? null : new List<int>(other.Elements));
	}

	public void Assign(AdventureAction other)
	{
		Id = other.Id;
		Key = other.Key;
		RemainTime = other.RemainTime;
		ContainsTaiwu = other.ContainsTaiwu;
		Elements = ((other.Elements == null) ? null : new List<int>(other.Elements));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((Key == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Key.Length)));
		totalSize = ((Elements == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Elements.Count)));
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
		*(int*)pCurrData = Id;
		pCurrData += 4;
		if (Key != null)
		{
			int elementsCount = Key.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Key)
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
		*(int*)pCurrData = RemainTime;
		pCurrData += 4;
		*pCurrData = (ContainsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Elements != null)
		{
			int elementsCount2 = Elements.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = Elements[j];
			}
			pCurrData += 4 * elementsCount2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				Key = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				Key = null;
			}
		}
		if (num > 2)
		{
			RemainTime = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			ContainsTaiwu = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (Elements == null)
				{
					Elements = new List<int>(elementsCount2);
				}
				else
				{
					Elements.Clear();
				}
				for (int i = 0; i < elementsCount2; i++)
				{
					Elements.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				Elements?.Clear();
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
