using System.Text;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ChickenPolymorphLocationData : ISerializableGameData
{
	[SerializableGameDataField]
	public string StateName;

	[SerializableGameDataField]
	public string AreaName;

	[SerializableGameDataField]
	public string SettlementName;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((StateName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * StateName.Length)));
		totalSize = ((AreaName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AreaName.Length)));
		totalSize = ((SettlementName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SettlementName.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (StateName != null)
		{
			int stringCount = StateName.Length;
			Tester.Assert(stringCount <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount;
			pCurrData += 2;
			fixed (char* pChar = StateName)
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
		if (AreaName != null)
		{
			int stringCount2 = AreaName.Length;
			Tester.Assert(stringCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount2;
			pCurrData += 2;
			fixed (char* pChar2 = AreaName)
			{
				for (int i = 0; i < stringCount2; i++)
				{
					((short*)pCurrData)[i] = (short)pChar2[i];
				}
			}
			pCurrData += 2 * stringCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementName != null)
		{
			int stringCount3 = SettlementName.Length;
			Tester.Assert(stringCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount3;
			pCurrData += 2;
			fixed (char* pChar3 = SettlementName)
			{
				for (int j = 0; j < stringCount3; j++)
				{
					((short*)pCurrData)[j] = (short)pChar3[j];
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
		ushort stringCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount > 0)
		{
			int fieldSize = 2 * stringCount;
			StateName = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			StateName = null;
		}
		ushort stringCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount2 > 0)
		{
			int fieldSize2 = 2 * stringCount2;
			AreaName = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			AreaName = null;
		}
		ushort stringCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount3 > 0)
		{
			int fieldSize3 = 2 * stringCount3;
			SettlementName = Encoding.Unicode.GetString(pCurrData, fieldSize3);
			pCurrData += fieldSize3;
		}
		else
		{
			SettlementName = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
