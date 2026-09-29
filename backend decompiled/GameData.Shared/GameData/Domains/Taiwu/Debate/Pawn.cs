using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class Pawn : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public IntPair Coordinate;

	[SerializableGameDataField]
	public bool IsOwnedByTaiwu;

	[SerializableGameDataField]
	public int Bases;

	[SerializableGameDataField]
	public bool IsRevealed;

	[SerializableGameDataField]
	public bool IsAlive;

	[SerializableGameDataField]
	public bool IsZero;

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public int[] Strategies = new int[3] { -1, -1, -1 };

	public int NodeDamage;

	public bool Damaged;

	public bool IsHalt;

	public bool IsSwitchLocation;

	public bool IsImmuneDebuff;

	public bool IsHalfImmuneRemove;

	public bool IsImmuneRemove;

	public int ChangeSelfGamePointByDamagePercent;

	public bool ChangeSelfGamePointByDamagePercentIsCastedByTaiwu;

	public List<PawnDamageInfo> DamageList = new List<PawnDamageInfo>();

	public int DamageToSelf => DamageList.Where((PawnDamageInfo d) => d.IsToSelf).Sum((PawnDamageInfo d) => d.Damage);

	public int DamageToOpponent => DamageList.Where((PawnDamageInfo d) => !d.IsToSelf && !d.IsStrategyDamage).Sum((PawnDamageInfo d) => d.Damage);

	public void ResetNodeValue()
	{
		NodeDamage = 0;
		Damaged = false;
	}

	public void ResetStrategyValue()
	{
		IsHalt = false;
		IsSwitchLocation = false;
		IsHalfImmuneRemove = false;
		IsImmuneRemove = false;
		IsImmuneDebuff = false;
		ChangeSelfGamePointByDamagePercent = 0;
		DamageList.Clear();
	}

	public Pawn(int id, IntPair coordinate, bool isOwnedByTaiwu, int bases)
	{
		Id = id;
		Coordinate = coordinate;
		IsOwnedByTaiwu = isOwnedByTaiwu;
		Bases = bases;
		IsRevealed = false;
		IsAlive = true;
		IsZero = bases == 0;
	}

	public Pawn()
	{
	}

	public Pawn(Pawn other)
	{
		Id = other.Id;
		Coordinate = other.Coordinate;
		IsOwnedByTaiwu = other.IsOwnedByTaiwu;
		Bases = other.Bases;
		IsRevealed = other.IsRevealed;
		IsAlive = other.IsAlive;
		IsZero = other.IsZero;
		int[] item = other.Strategies;
		int elementsCount = item.Length;
		Strategies = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Strategies[i] = item[i];
		}
	}

	public void Assign(Pawn other)
	{
		Id = other.Id;
		Coordinate = other.Coordinate;
		IsOwnedByTaiwu = other.IsOwnedByTaiwu;
		Bases = other.Bases;
		IsRevealed = other.IsRevealed;
		IsAlive = other.IsAlive;
		IsZero = other.IsZero;
		int[] item = other.Strategies;
		int elementsCount = item.Length;
		Strategies = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Strategies[i] = item[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 32;
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
		pCurrData += Coordinate.Serialize(pCurrData);
		*pCurrData = (IsOwnedByTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Bases;
		pCurrData += 4;
		*pCurrData = (IsRevealed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsAlive ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsZero ? ((byte)1) : ((byte)0));
		pCurrData++;
		Tester.Assert(Strategies.Length == 3);
		for (int i = 0; i < 3; i++)
		{
			((int*)pCurrData)[i] = Strategies[i];
		}
		pCurrData += 12;
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
		pCurrData += Coordinate.Deserialize(pCurrData);
		IsOwnedByTaiwu = *pCurrData != 0;
		pCurrData++;
		Bases = *(int*)pCurrData;
		pCurrData += 4;
		IsRevealed = *pCurrData != 0;
		pCurrData++;
		IsAlive = *pCurrData != 0;
		pCurrData++;
		IsZero = *pCurrData != 0;
		pCurrData++;
		if (Strategies == null || Strategies.Length != 3)
		{
			Strategies = new int[3];
		}
		for (int i = 0; i < 3; i++)
		{
			Strategies[i] = ((int*)pCurrData)[i];
		}
		pCurrData += 12;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
