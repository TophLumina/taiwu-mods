using GameData.Serializer;

namespace GameData.Domains.Character.Display;

public class CharacterLoveAndHateItemInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public bool LovingItemRevealed;

	[SerializableGameDataField]
	public bool HatingItemRevealed;

	[SerializableGameDataField]
	public bool NeedShowFirstRevealLovingEffect;

	[SerializableGameDataField]
	public bool NeedShowFirstRevealHatingEffect;

	[SerializableGameDataField]
	public short LovingItemSubType;

	[SerializableGameDataField]
	public short HatingItemSubType;

	[SerializableGameDataField]
	public int HobbyExpirationDate;

	[SerializableGameDataField]
	public byte CreatingType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharacterId;
		byte* num = pData + 4;
		*num = (LovingItemRevealed ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = (HatingItemRevealed ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (NeedShowFirstRevealLovingEffect ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (NeedShowFirstRevealHatingEffect ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*(short*)num5 = LovingItemSubType;
		byte* num6 = num5 + 2;
		*(short*)num6 = HatingItemSubType;
		byte* num7 = num6 + 2;
		*(int*)num7 = HobbyExpirationDate;
		byte* num8 = num7 + 4;
		*num8 = CreatingType;
		int totalSize = (int)(num8 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		LovingItemRevealed = *pCurrData != 0;
		pCurrData++;
		HatingItemRevealed = *pCurrData != 0;
		pCurrData++;
		NeedShowFirstRevealLovingEffect = *pCurrData != 0;
		pCurrData++;
		NeedShowFirstRevealHatingEffect = *pCurrData != 0;
		pCurrData++;
		LovingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		HatingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		HobbyExpirationDate = *(int*)pCurrData;
		pCurrData += 4;
		CreatingType = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
