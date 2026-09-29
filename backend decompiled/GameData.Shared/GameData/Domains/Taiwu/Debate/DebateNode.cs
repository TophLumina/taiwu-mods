using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class DebateNode : ISerializableGameData
{
	[SerializableGameDataField]
	public IntPair Coordinate;

	[SerializableGameDataField]
	public bool IsVantage;

	[SerializableGameDataField]
	public bool IsVisible;

	[SerializableGameDataField]
	public bool TaiwuCanMakeMove;

	[SerializableGameDataField]
	public bool NpcCanMakeMove;

	[SerializableGameDataField]
	public int PawnId;

	[SerializableGameDataField]
	public DebateNodeEffectState EffectState;

	public DebateNode(int x, int y)
	{
		Coordinate = new IntPair(x, y);
		IsVantage = x < DebateConstants.TaiwuVantageNodeCount[y];
		IsVisible = IsVantage;
		TaiwuCanMakeMove = false;
		PawnId = -1;
		EffectState = DebateNodeEffectState.Invalid;
	}

	public DebateNode()
	{
	}

	public DebateNode(DebateNode other)
	{
		Coordinate = other.Coordinate;
		IsVantage = other.IsVantage;
		IsVisible = other.IsVisible;
		TaiwuCanMakeMove = other.TaiwuCanMakeMove;
		NpcCanMakeMove = other.NpcCanMakeMove;
		PawnId = other.PawnId;
		EffectState = new DebateNodeEffectState(other.EffectState);
	}

	public void Assign(DebateNode other)
	{
		Coordinate = other.Coordinate;
		IsVantage = other.IsVantage;
		IsVisible = other.IsVisible;
		TaiwuCanMakeMove = other.TaiwuCanMakeMove;
		NpcCanMakeMove = other.NpcCanMakeMove;
		PawnId = other.PawnId;
		EffectState = new DebateNodeEffectState(other.EffectState);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		totalSize = ((EffectState == null) ? (totalSize + 2) : (totalSize + (2 + EffectState.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Coordinate.Serialize(pCurrData);
		*pCurrData = (IsVantage ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsVisible ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TaiwuCanMakeMove ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (NpcCanMakeMove ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = PawnId;
		pCurrData += 4;
		if (EffectState != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = EffectState.Serialize(pCurrData);
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
		pCurrData += Coordinate.Deserialize(pCurrData);
		IsVantage = *pCurrData != 0;
		pCurrData++;
		IsVisible = *pCurrData != 0;
		pCurrData++;
		TaiwuCanMakeMove = *pCurrData != 0;
		pCurrData++;
		NpcCanMakeMove = *pCurrData != 0;
		pCurrData++;
		PawnId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (EffectState == null)
			{
				EffectState = new DebateNodeEffectState();
			}
			pCurrData += EffectState.Deserialize(pCurrData);
		}
		else
		{
			EffectState = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
