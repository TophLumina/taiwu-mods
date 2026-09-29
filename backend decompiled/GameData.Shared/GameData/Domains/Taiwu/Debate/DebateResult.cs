using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Debate;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class DebateResult : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsTaiwuWin;

	[SerializableGameDataField]
	public IntPair Exp = new IntPair(0, 0);

	[SerializableGameDataField]
	public IntPair Authority = new IntPair(0, 0);

	[SerializableGameDataField]
	public bool ShowReadingEvent;

	[SerializableGameDataField]
	public bool ShowReadingEvent2;

	[SerializableGameDataField]
	public bool ShowLoopingEvent;

	[SerializableGameDataField]
	public bool ShowLoopingEvent2;

	[SerializableGameDataField]
	public List<short> Evaluations = new List<short>();

	[SerializableGameDataField]
	public Dictionary<short, int> TaiwuComments = new Dictionary<short, int>();

	[SerializableGameDataField]
	public Dictionary<short, int> NpcComments = new Dictionary<short, int>();

	[SerializableGameDataField]
	public Dictionary<int, IntPair> Favorability = new Dictionary<int, IntPair>();

	[SerializableGameDataField]
	public Dictionary<int, IntPair> Happiness = new Dictionary<int, IntPair>();

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> CharacterDisplayDataMap = new Dictionary<int, CharacterDisplayData>();

	[SerializableGameDataField]
	public IntPair AreaSpiritualDebt;

	public int ExpA;

	public int ExpB = 100;

	public int ExpCMax;

	public int ExpCMin;

	public int AuthorityA;

	public int AuthorityB = 100;

	public int AuthorityCMax;

	public int AuthorityCMin;

	public int FavorA;

	public int FavorIncreaseB = 100;

	public int FavorDecreaseB = 100;

	public int FavorIncreaseCMax;

	public int FavorIncreaseCMin;

	public int FavorDecreaseCMax;

	public int FavorDecreaseCMin;

	public int ReadRate;

	public int LoopRate;

	public int HappinessDelta;

	public int GetHappiness(int charId)
	{
		if (!Happiness.TryGetValue(charId, out var val))
		{
			return 0;
		}
		return val.First;
	}

	public void AddHappiness(int charId, int delta)
	{
		Happiness[charId] = new IntPair(GetHappiness(charId) + delta, 0);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize += Exp.GetSerializedSize();
		totalSize += Authority.GetSerializedSize();
		totalSize = ((Evaluations == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Evaluations.Count)));
		totalSize += 4;
		if (TaiwuComments != null)
		{
			foreach (KeyValuePair<short, int> taiwuComment in TaiwuComments)
			{
				_ = taiwuComment;
				totalSize += 2;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (NpcComments != null)
		{
			foreach (KeyValuePair<short, int> npcComment in NpcComments)
			{
				_ = npcComment;
				totalSize += 2;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (Favorability != null)
		{
			foreach (KeyValuePair<int, IntPair> pair in Favorability)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (Happiness != null)
		{
			foreach (KeyValuePair<int, IntPair> pair2 in Happiness)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (CharacterDisplayDataMap != null)
		{
			foreach (KeyValuePair<int, CharacterDisplayData> pair3 in CharacterDisplayDataMap)
			{
				totalSize += 4;
				totalSize += pair3.Value.GetSerializedSize();
			}
		}
		totalSize += AreaSpiritualDebt.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsTaiwuWin ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize = Exp.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = Authority.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*pCurrData = (ShowReadingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowReadingEvent2 ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowLoopingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowLoopingEvent2 ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Evaluations != null)
		{
			int elementsCount = Evaluations.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = Evaluations[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuComments != null)
		{
			*(int*)pCurrData = TaiwuComments.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in TaiwuComments)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (NpcComments != null)
		{
			*(int*)pCurrData = NpcComments.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair2 in NpcComments)
			{
				*(short*)pCurrData = pair2.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair2.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Favorability != null)
		{
			*(int*)pCurrData = Favorability.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, IntPair> pair3 in Favorability)
			{
				*(int*)pCurrData = pair3.Key;
				pCurrData += 4;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Happiness != null)
		{
			*(int*)pCurrData = Happiness.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, IntPair> pair4 in Happiness)
			{
				*(int*)pCurrData = pair4.Key;
				pCurrData += 4;
				pCurrData += pair4.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (CharacterDisplayDataMap != null)
		{
			*(int*)pCurrData = CharacterDisplayDataMap.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterDisplayData> pair5 in CharacterDisplayDataMap)
			{
				*(int*)pCurrData = pair5.Key;
				pCurrData += 4;
				pCurrData += pair5.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		int fieldSize3 = AreaSpiritualDebt.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
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
		IsTaiwuWin = *pCurrData != 0;
		pCurrData++;
		pCurrData += Exp.Deserialize(pCurrData);
		pCurrData += Authority.Deserialize(pCurrData);
		ShowReadingEvent = *pCurrData != 0;
		pCurrData++;
		ShowReadingEvent2 = *pCurrData != 0;
		pCurrData++;
		ShowLoopingEvent = *pCurrData != 0;
		pCurrData++;
		ShowLoopingEvent2 = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Evaluations == null)
			{
				Evaluations = new List<short>();
			}
			else
			{
				Evaluations.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				Evaluations.Add(element);
			}
		}
		else
		{
			Evaluations?.Clear();
		}
		int TaiwuCommentsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (TaiwuCommentsElementsCount > 0)
		{
			if (TaiwuComments == null)
			{
				TaiwuComments = new Dictionary<short, int>();
			}
			else
			{
				TaiwuComments.Clear();
			}
			for (int j = 0; j < TaiwuCommentsElementsCount; j++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				TaiwuComments.Add(key, value);
			}
		}
		else
		{
			TaiwuComments?.Clear();
		}
		int NpcCommentsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (NpcCommentsElementsCount > 0)
		{
			if (NpcComments == null)
			{
				NpcComments = new Dictionary<short, int>();
			}
			else
			{
				NpcComments.Clear();
			}
			for (int k = 0; k < NpcCommentsElementsCount; k++)
			{
				short key2 = *(short*)pCurrData;
				pCurrData += 2;
				int value2 = *(int*)pCurrData;
				pCurrData += 4;
				NpcComments.Add(key2, value2);
			}
		}
		else
		{
			NpcComments?.Clear();
		}
		int FavorabilityElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (FavorabilityElementsCount > 0)
		{
			if (Favorability == null)
			{
				Favorability = new Dictionary<int, IntPair>();
			}
			else
			{
				Favorability.Clear();
			}
			for (int l = 0; l < FavorabilityElementsCount; l++)
			{
				int key3 = *(int*)pCurrData;
				pCurrData += 4;
				IntPair value3 = default(IntPair);
				pCurrData += value3.Deserialize(pCurrData);
				Favorability.Add(key3, value3);
			}
		}
		else
		{
			Favorability?.Clear();
		}
		int HappinessElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (HappinessElementsCount > 0)
		{
			if (Happiness == null)
			{
				Happiness = new Dictionary<int, IntPair>();
			}
			else
			{
				Happiness.Clear();
			}
			for (int m = 0; m < HappinessElementsCount; m++)
			{
				int key4 = *(int*)pCurrData;
				pCurrData += 4;
				IntPair value4 = default(IntPair);
				pCurrData += value4.Deserialize(pCurrData);
				Happiness.Add(key4, value4);
			}
		}
		else
		{
			Happiness?.Clear();
		}
		int CharacterDisplayDataMapElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharacterDisplayDataMapElementsCount > 0)
		{
			if (CharacterDisplayDataMap == null)
			{
				CharacterDisplayDataMap = new Dictionary<int, CharacterDisplayData>();
			}
			else
			{
				CharacterDisplayDataMap.Clear();
			}
			for (int n = 0; n < CharacterDisplayDataMapElementsCount; n++)
			{
				int key5 = *(int*)pCurrData;
				pCurrData += 4;
				CharacterDisplayData value5 = new CharacterDisplayData();
				pCurrData += value5.Deserialize(pCurrData);
				CharacterDisplayDataMap.Add(key5, value5);
			}
		}
		else
		{
			CharacterDisplayDataMap?.Clear();
		}
		pCurrData += AreaSpiritualDebt.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
