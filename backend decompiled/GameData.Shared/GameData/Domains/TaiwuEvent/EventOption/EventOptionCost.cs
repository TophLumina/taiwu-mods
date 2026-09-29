using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.EventOption;

[Serializable]
[SerializableGameData(NotForDisplayModule = true, NotForArchive = true)]
public class EventOptionCost : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ConsumeType;

	[SerializableGameDataField]
	public int CostAmount;

	[SerializableGameDataField]
	public bool AutoConsume;

	[SerializableGameDataField]
	public string Expression;

	public EventOptionCost()
	{
		ConsumeType = -1;
		CostAmount = 0;
		AutoConsume = false;
		Expression = null;
	}

	public EventOptionCost(EventOptionCost other)
	{
		ConsumeType = other.ConsumeType;
		CostAmount = other.CostAmount;
		AutoConsume = other.AutoConsume;
		Expression = other.Expression;
	}

	public void Assign(EventOptionCost other)
	{
		ConsumeType = other.ConsumeType;
		CostAmount = other.CostAmount;
		AutoConsume = other.AutoConsume;
		Expression = other.Expression;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Expression == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Expression.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)ConsumeType;
		pCurrData++;
		*(int*)pCurrData = CostAmount;
		pCurrData += 4;
		*pCurrData = (AutoConsume ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Expression != null)
		{
			int elementsCount = Expression.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Expression)
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
		ConsumeType = (sbyte)(*pCurrData);
		pCurrData++;
		CostAmount = *(int*)pCurrData;
		pCurrData += 4;
		AutoConsume = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			Expression = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Expression = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
