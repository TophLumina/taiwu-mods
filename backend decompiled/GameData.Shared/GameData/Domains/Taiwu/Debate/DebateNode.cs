using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 论点格子
/// </summary>
public class DebateNode : ISerializableGameData
{
	/// <summary>
	/// 坐标
	/// </summary>
	[SerializableGameDataField]
	public IntPair Coordinate;

	/// <summary>
	/// 是否对太吾有利
	/// 总是拥有视野、未被对方棋子阻挡时可直接下子
	/// </summary>
	[SerializableGameDataField]
	public bool IsVantage;

	/// <summary>
	/// 是否太吾可见
	/// </summary>
	[SerializableGameDataField]
	public bool IsVisible;

	/// <summary>
	/// 太吾能否落子
	/// </summary>
	[SerializableGameDataField]
	public bool TaiwuCanMakeMove;

	/// <summary>
	/// npc能否落子
	/// </summary>
	[SerializableGameDataField]
	public bool NpcCanMakeMove;

	/// <summary>
	/// 棋子
	/// </summary>
	[SerializableGameDataField]
	public int PawnId;

	/// <summary>
	/// 效果
	/// </summary>
	[SerializableGameDataField]
	public DebateNodeEffectState EffectState;

	/// <summary>
	///
	/// </summary>
	public DebateNode(int x, int y)
	{
		Coordinate = new IntPair(x, y);
		IsVantage = x < DebateConstants.TaiwuVantageNodeCount[y];
		IsVisible = IsVantage;
		TaiwuCanMakeMove = false;
		PawnId = -1;
		EffectState = DebateNodeEffectState.Invalid;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DebateNode()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
