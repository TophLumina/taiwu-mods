using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

[SerializableGameData(IsExtensible = true)]
public class JiaoPool : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Jiaos = 0;

		public const ushort NextPeriod = 1;

		public const ushort IsDisabled = 2;

		public const ushort BlockStyle = 3;

		public const ushort IsBabysitting = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "Jiaos", "NextPeriod", "IsDisabled", "BlockStyle", "IsBabysitting" };
	}

	[SerializableGameDataField]
	public List<int> Jiaos;

	[SerializableGameDataField]
	public int NextPeriod;

	[SerializableGameDataField]
	public bool IsDisabled;

	[SerializableGameDataField]
	public short BlockStyle;

	[SerializableGameDataField]
	public bool isBabysitting;

	public JiaoPool()
	{
		Jiaos = new List<int>();
		NextPeriod = -1;
		IsDisabled = false;
		BlockStyle = -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize = ((Jiaos == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Jiaos.Count)));
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
		if (Jiaos != null)
		{
			int elementsCount = Jiaos.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = Jiaos[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = NextPeriod;
		pCurrData += 4;
		*pCurrData = (IsDisabled ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = BlockStyle;
		pCurrData += 2;
		*pCurrData = (isBabysitting ? ((byte)1) : ((byte)0));
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
				if (Jiaos == null)
				{
					Jiaos = new List<int>(elementsCount);
				}
				else
				{
					Jiaos.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					Jiaos.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				Jiaos?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			NextPeriod = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			IsDisabled = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			BlockStyle = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 4)
		{
			isBabysitting = *pCurrData != 0;
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
