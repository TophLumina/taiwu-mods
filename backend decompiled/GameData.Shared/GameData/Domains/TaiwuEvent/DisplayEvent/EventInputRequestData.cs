using System.Text;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public class EventInputRequestData : ISerializableGameData
{
	[SerializableGameDataField]
	public string DataKey;

	[SerializableGameDataField]
	public sbyte InputDataType;

	[SerializableGameDataField]
	public int[] NumberRange;

	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public string ConfirmDisableTips;

	[SerializableGameDataField]
	public bool ShowPartnerBtn;

	[SerializableGameDataField]
	public bool CanUsePartnerBtn;

	[SerializableGameDataField]
	public FullName ChildFullName;

	[SerializableGameDataField]
	public sbyte ChildGender;

	public static readonly string ExtraSurNameKey = "ExtraSurName";

	public EventInputRequestData()
	{
	}

	public EventInputRequestData(EventInputRequestData other)
	{
		DataKey = other.DataKey;
		InputDataType = other.InputDataType;
		int[] item = other.NumberRange;
		int elementsCount = item.Length;
		NumberRange = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			NumberRange[i] = item[i];
		}
		FullName = other.FullName;
		ConfirmDisableTips = other.ConfirmDisableTips;
		ShowPartnerBtn = other.ShowPartnerBtn;
		CanUsePartnerBtn = other.CanUsePartnerBtn;
		ChildFullName = other.ChildFullName;
		ChildGender = other.ChildGender;
	}

	public void Assign(EventInputRequestData other)
	{
		DataKey = other.DataKey;
		InputDataType = other.InputDataType;
		int[] item = other.NumberRange;
		int elementsCount = item.Length;
		NumberRange = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			NumberRange[i] = item[i];
		}
		FullName = other.FullName;
		ConfirmDisableTips = other.ConfirmDisableTips;
		ShowPartnerBtn = other.ShowPartnerBtn;
		CanUsePartnerBtn = other.CanUsePartnerBtn;
		ChildFullName = other.ChildFullName;
		ChildGender = other.ChildGender;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		totalSize = ((DataKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * DataKey.Length)));
		totalSize = ((NumberRange == null) ? (totalSize + 2) : (totalSize + (2 + 4 * NumberRange.Length)));
		totalSize = ((ConfirmDisableTips == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ConfirmDisableTips.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DataKey != null)
		{
			int elementsCount = DataKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = DataKey)
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
		*pCurrData = (byte)InputDataType;
		pCurrData++;
		if (NumberRange != null)
		{
			int elementsCount2 = NumberRange.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = NumberRange[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += FullName.Serialize(pCurrData);
		if (ConfirmDisableTips != null)
		{
			int elementsCount3 = ConfirmDisableTips.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			fixed (char* pChar2 = ConfirmDisableTips)
			{
				for (int k = 0; k < elementsCount3; k++)
				{
					((short*)pCurrData)[k] = (short)pChar2[k];
				}
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (ShowPartnerBtn ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (CanUsePartnerBtn ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += ChildFullName.Serialize(pCurrData);
		*pCurrData = (byte)ChildGender;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			DataKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			DataKey = null;
		}
		InputDataType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (NumberRange == null || NumberRange.Length != elementsCount2)
			{
				NumberRange = new int[elementsCount2];
			}
			for (int i = 0; i < elementsCount2; i++)
			{
				NumberRange[i] = ((int*)pCurrData)[i];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			NumberRange = null;
		}
		pCurrData += FullName.Deserialize(pCurrData);
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			int fieldSize2 = 2 * elementsCount3;
			ConfirmDisableTips = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			ConfirmDisableTips = null;
		}
		ShowPartnerBtn = *pCurrData != 0;
		pCurrData++;
		CanUsePartnerBtn = *pCurrData != 0;
		pCurrData++;
		pCurrData += ChildFullName.Deserialize(pCurrData);
		ChildGender = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
