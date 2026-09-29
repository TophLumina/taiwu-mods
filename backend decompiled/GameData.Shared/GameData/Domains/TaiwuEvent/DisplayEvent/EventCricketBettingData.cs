using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NoCopyConstructors = true)]
public class EventCricketBettingData : ISerializableGameData
{
	public bool IsComplete;

	public bool IsConfirmed;

	public string SelectForEventGuid;

	public string SelectForOptionKey;

	public Wager Wager;

	public int Index;

	[SerializableGameDataField]
	public bool IsValid;

	[SerializableGameDataField]
	public bool AutoBet;

	[SerializableGameDataField]
	public CharacterDisplayData SelfCharacter;

	[SerializableGameDataField]
	public CharacterDisplayData TargetCharacter;

	[SerializableGameDataField]
	public List<CricketWagerData> BetRewards;

	[SerializableGameDataField]
	public List<ItemDisplayData> BetItems;

	[SerializableGameDataField]
	public List<CharacterDisplayData> BetCharacters;

	[SerializableGameDataField]
	public Dictionary<int, long> BetCharacterValueMap;

	[SerializableGameDataField]
	public bool DoubleDamage;

	[SerializableGameDataField]
	public bool OnlyNoInjuryCricket;

	[SerializableGameDataField]
	public sbyte MinGrade;

	[SerializableGameDataField]
	public sbyte MaxGrade;

	public EventCricketBettingData()
	{
		IsValid = false;
		AutoBet = false;
		IsComplete = false;
		IsConfirmed = false;
		BetCharacterValueMap = new Dictionary<int, long>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((SelfCharacter == null) ? (totalSize + 2) : (totalSize + (2 + SelfCharacter.GetSerializedSize())));
		totalSize = ((TargetCharacter == null) ? (totalSize + 2) : (totalSize + (2 + TargetCharacter.GetSerializedSize())));
		if (BetRewards != null)
		{
			totalSize += 2;
			int elementsCount = BetRewards.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CricketWagerData element = BetRewards[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BetItems != null)
		{
			totalSize += 2;
			int elementsCount2 = BetItems.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemDisplayData element2 = BetItems[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BetCharacters != null)
		{
			totalSize += 2;
			int elementsCount3 = BetCharacters.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterDisplayData element3 = BetCharacters[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(BetCharacterValueMap);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsValid ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoBet ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SelfCharacter != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SelfCharacter.Serialize(pCurrData);
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
		if (BetRewards != null)
		{
			int elementsCount = BetRewards.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CricketWagerData element = BetRewards[i];
				if (element != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr3 = (ushort)subDataSize;
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
		if (BetItems != null)
		{
			int elementsCount2 = BetItems.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemDisplayData element2 = BetItems[j];
				if (element2 != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr4 = (ushort)subDataSize2;
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
		if (BetCharacters != null)
		{
			int elementsCount3 = BetCharacters.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterDisplayData element3 = BetCharacters[k];
				if (element3 != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)intPtr5 = (ushort)subDataSize3;
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref BetCharacterValueMap);
		*pCurrData = (DoubleDamage ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (OnlyNoInjuryCricket ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)MinGrade;
		pCurrData++;
		*pCurrData = (byte)MaxGrade;
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
		IsValid = *pCurrData != 0;
		pCurrData++;
		AutoBet = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SelfCharacter == null)
			{
				SelfCharacter = new CharacterDisplayData();
			}
			pCurrData += SelfCharacter.Deserialize(pCurrData);
		}
		else
		{
			SelfCharacter = null;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BetRewards == null)
			{
				BetRewards = new List<CricketWagerData>(elementsCount);
			}
			else
			{
				BetRewards.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					CricketWagerData element = new CricketWagerData();
					pCurrData += element.Deserialize(pCurrData);
					BetRewards.Add(element);
				}
				else
				{
					BetRewards.Add(null);
				}
			}
		}
		else
		{
			BetRewards?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BetItems == null)
			{
				BetItems = new List<ItemDisplayData>(elementsCount2);
			}
			else
			{
				BetItems.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num4 > 0)
				{
					ItemDisplayData element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					BetItems.Add(element2);
				}
				else
				{
					BetItems.Add(null);
				}
			}
		}
		else
		{
			BetItems?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (BetCharacters == null)
			{
				BetCharacters = new List<CharacterDisplayData>(elementsCount3);
			}
			else
			{
				BetCharacters.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num5 > 0)
				{
					CharacterDisplayData element3 = new CharacterDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
					BetCharacters.Add(element3);
				}
				else
				{
					BetCharacters.Add(null);
				}
			}
		}
		else
		{
			BetCharacters?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref BetCharacterValueMap);
		DoubleDamage = *pCurrData != 0;
		pCurrData++;
		OnlyNoInjuryCricket = *pCurrData != 0;
		pCurrData++;
		MinGrade = (sbyte)(*pCurrData);
		pCurrData++;
		MaxGrade = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
