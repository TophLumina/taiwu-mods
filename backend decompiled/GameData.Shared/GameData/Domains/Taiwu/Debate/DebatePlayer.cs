using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class DebatePlayer : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public int GamePoint;

	[SerializableGameDataField]
	public int Pressure;

	[SerializableGameDataField]
	public int MaxPressure;

	[SerializableGameDataField]
	public int HighestPressure;

	[SerializableGameDataField]
	public int Bases;

	[SerializableGameDataField]
	public int MaxBases;

	[SerializableGameDataField]
	public int StrategyPoint;

	[SerializableGameDataField]
	public int MakeMoveCount;

	[SerializableGameDataField]
	public List<short> OwnedCards = new List<short>();

	[SerializableGameDataField]
	public List<short> UsedCards = new List<short>();

	[SerializableGameDataField]
	public List<short> CanUseCards = new List<short>();

	public DebatePlayer(int id, int maxPressure, int attainment, List<short> ownedCards)
	{
		Id = id;
		GamePoint = DebateConstants.MaxGamePoint;
		Pressure = 0;
		MaxPressure = maxPressure;
		HighestPressure = 0;
		Bases = attainment;
		MaxBases = attainment;
		StrategyPoint = DebateConstants.InitialStrategyPoint;
		MakeMoveCount = 0;
		OwnedCards = ownedCards;
	}

	public DebatePlayer()
	{
	}

	public DebatePlayer(DebatePlayer other)
	{
		Id = other.Id;
		GamePoint = other.GamePoint;
		Pressure = other.Pressure;
		MaxPressure = other.MaxPressure;
		HighestPressure = other.HighestPressure;
		Bases = other.Bases;
		MaxBases = other.MaxBases;
		StrategyPoint = other.StrategyPoint;
		MakeMoveCount = other.MakeMoveCount;
		OwnedCards = ((other.OwnedCards == null) ? null : new List<short>(other.OwnedCards));
		UsedCards = ((other.UsedCards == null) ? null : new List<short>(other.UsedCards));
		CanUseCards = ((other.CanUseCards == null) ? null : new List<short>(other.CanUseCards));
	}

	public void Assign(DebatePlayer other)
	{
		Id = other.Id;
		GamePoint = other.GamePoint;
		Pressure = other.Pressure;
		MaxPressure = other.MaxPressure;
		HighestPressure = other.HighestPressure;
		Bases = other.Bases;
		MaxBases = other.MaxBases;
		StrategyPoint = other.StrategyPoint;
		MakeMoveCount = other.MakeMoveCount;
		OwnedCards = ((other.OwnedCards == null) ? null : new List<short>(other.OwnedCards));
		UsedCards = ((other.UsedCards == null) ? null : new List<short>(other.UsedCards));
		CanUseCards = ((other.CanUseCards == null) ? null : new List<short>(other.CanUseCards));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 36;
		totalSize = ((OwnedCards == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OwnedCards.Count)));
		totalSize = ((UsedCards == null) ? (totalSize + 2) : (totalSize + (2 + 2 * UsedCards.Count)));
		totalSize = ((CanUseCards == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanUseCards.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(int*)pCurrData = GamePoint;
		pCurrData += 4;
		*(int*)pCurrData = Pressure;
		pCurrData += 4;
		*(int*)pCurrData = MaxPressure;
		pCurrData += 4;
		*(int*)pCurrData = HighestPressure;
		pCurrData += 4;
		*(int*)pCurrData = Bases;
		pCurrData += 4;
		*(int*)pCurrData = MaxBases;
		pCurrData += 4;
		*(int*)pCurrData = StrategyPoint;
		pCurrData += 4;
		*(int*)pCurrData = MakeMoveCount;
		pCurrData += 4;
		if (OwnedCards != null)
		{
			int elementsCount = OwnedCards.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = OwnedCards[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (UsedCards != null)
		{
			int elementsCount2 = UsedCards.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = UsedCards[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CanUseCards != null)
		{
			int elementsCount3 = CanUseCards.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CanUseCards[k];
			}
			pCurrData += 2 * elementsCount3;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		GamePoint = *(int*)pCurrData;
		pCurrData += 4;
		Pressure = *(int*)pCurrData;
		pCurrData += 4;
		MaxPressure = *(int*)pCurrData;
		pCurrData += 4;
		HighestPressure = *(int*)pCurrData;
		pCurrData += 4;
		Bases = *(int*)pCurrData;
		pCurrData += 4;
		MaxBases = *(int*)pCurrData;
		pCurrData += 4;
		StrategyPoint = *(int*)pCurrData;
		pCurrData += 4;
		MakeMoveCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (OwnedCards == null)
			{
				OwnedCards = new List<short>(elementsCount);
			}
			else
			{
				OwnedCards.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				OwnedCards.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			OwnedCards?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (UsedCards == null)
			{
				UsedCards = new List<short>(elementsCount2);
			}
			else
			{
				UsedCards.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				UsedCards.Add(((short*)pCurrData)[j]);
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			UsedCards?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CanUseCards == null)
			{
				CanUseCards = new List<short>(elementsCount3);
			}
			else
			{
				CanUseCards.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				CanUseCards.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			CanUseCards?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
