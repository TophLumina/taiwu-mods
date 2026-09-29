using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(NoCopyConstructors = true)]
public class TaiwuAsXiangshuSkill0ResultItem : ISerializableGameData
{
	[SerializableGameDataField]
	public int SelfCharId;

	[SerializableGameDataField]
	public CharacterDisplayData SelfCharacterDisplayData;

	[SerializableGameDataField]
	public int TargetCharId;

	[SerializableGameDataField]
	public CharacterDisplayData TargetCharacterDisplayData;

	[SerializableGameDataField]
	public sbyte MixedPoisonHarmfulActionType;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize = ((SelfCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + SelfCharacterDisplayData.GetSerializedSize())));
		totalSize = ((TargetCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TargetCharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = SelfCharId;
		pCurrData += 4;
		if (SelfCharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SelfCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TargetCharId;
		pCurrData += 4;
		if (TargetCharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = TargetCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)MixedPoisonHarmfulActionType;
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
		SelfCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SelfCharacterDisplayData == null)
			{
				SelfCharacterDisplayData = new CharacterDisplayData();
			}
			pCurrData += SelfCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			SelfCharacterDisplayData = null;
		}
		TargetCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (TargetCharacterDisplayData == null)
			{
				TargetCharacterDisplayData = new CharacterDisplayData();
			}
			pCurrData += TargetCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TargetCharacterDisplayData = null;
		}
		MixedPoisonHarmfulActionType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
