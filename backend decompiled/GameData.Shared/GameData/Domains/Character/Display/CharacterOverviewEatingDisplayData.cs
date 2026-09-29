using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterOverviewEatingDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterAttributeDisplayData AttributeDisplayData;

	[SerializableGameDataField]
	public CharacterInjuryDisplayData InjuryDisplayData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 132;
		totalSize = ((InjuryDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + InjuryDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += AttributeDisplayData.Serialize(pCurrData);
		if (InjuryDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = InjuryDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		AttributeDisplayData = new CharacterAttributeDisplayData();
		pCurrData += AttributeDisplayData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			InjuryDisplayData = new CharacterInjuryDisplayData();
			pCurrData += InjuryDisplayData.Deserialize(pCurrData);
		}
		else
		{
			InjuryDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
