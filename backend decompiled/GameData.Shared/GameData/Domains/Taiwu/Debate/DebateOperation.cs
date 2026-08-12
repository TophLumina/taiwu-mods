using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 辩论中的行为
/// </summary>
public class DebateOperation : ISerializableGameData
{
	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public sbyte OperationType;

	/// <summary>
	/// 棋子Id
	/// 论点冲突行为时一定是太吾棋子，移动行为时可能是npc棋子
	/// </summary>
	[SerializableGameDataField]
	public int PawnId;

	/// <summary>
	/// npc棋子Id
	/// </summary>
	[SerializableGameDataField]
	public int NpcPawnId;

	/// <summary>
	/// 太吾压力
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuPressure;

	/// <summary>
	/// 太吾血量
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuGamePoint;

	/// <summary>
	/// 太吾论据
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuBases;

	/// <summary>
	/// npc压力
	/// </summary>
	[SerializableGameDataField]
	public int NpcPressure;

	/// <summary>
	/// npc血量
	/// </summary>
	[SerializableGameDataField]
	public int NpcGamePoint;

	/// <summary>
	/// npc论据
	/// </summary>
	[SerializableGameDataField]
	public int NpcBases;

	/// <summary>
	/// 模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 论战结果
	/// </summary>
	[SerializableGameDataField]
	public int Result;

	/// <summary>
	/// 操作失败
	/// </summary>
	[SerializableGameDataField]
	public bool IsFailed;

	/// <summary>
	/// 论点移动后的位置/双方论点基础论据
	/// 太吾论点论据，npc论点论据
	/// </summary>
	[SerializableGameDataField]
	public IntPair Target;

	/// <summary>
	/// 卡片index
	/// </summary>
	[SerializableGameDataField]
	public int Index;

	/// <summary>
	/// 卡片起始位置
	/// </summary>
	[SerializableGameDataField]
	public int Source;

	/// <summary>
	/// 卡片目的位置
	/// </summary>
	[SerializableGameDataField]
	public int Destination;

	/// <summary>
	/// 是否是太吾
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwu;

	/// <summary>
	/// 策略目标
	/// </summary>
	[SerializableGameDataField]
	public List<StrategyTarget> StrategyTargets;

	/// <summary>
	/// 格子效果
	/// </summary>
	[SerializableGameDataField]
	public DebateNodeEffectState NodeEffectState;

	/// <summary>
	/// 记录参数
	/// </summary>
	[SerializableGameDataField]
	public int[] RecordParams;

	/// <summary>
	/// 策略ID列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> CardIdList;

	/// <summary>
	/// 移动论点
	/// </summary>
	/// <param name="type"></param>
	/// <param name="id"></param>
	/// <param name="target"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	/// <param name="isImmuneRemove"></param>
	public DebateOperation(sbyte type, int id, IntPair target, DebatePlayer taiwu, DebatePlayer npc, bool isImmuneRemove)
	{
		OperationType = type;
		PawnId = id;
		NpcPawnId = -1;
		TemplateId = -1;
		Target = target;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
		Result = (isImmuneRemove ? 1 : 0);
	}

	/// <summary>
	/// 论点消除结论
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="id"></param>
	/// <param name="target"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, bool isTaiwu, int id, IntPair target, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		PawnId = id;
		NpcPawnId = -1;
		TemplateId = -1;
		Target = target;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 放置论点
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="id"></param>
	/// <param name="target"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	/// <param name="bases"></param>
	/// <param name="isFailed"></param>
	public DebateOperation(sbyte type, bool isTaiwu, int id, IntPair target, DebatePlayer taiwu, DebatePlayer npc, int bases, bool isFailed)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		PawnId = id;
		NpcPawnId = -1;
		TemplateId = -1;
		Target = target;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
		Result = bases;
		IsFailed = isFailed;
	}

	/// <summary>
	/// 论点基础论据变化 / 移除论点 / 一次性策略触发 / 策略触发
	/// </summary>
	/// <param name="type"></param>
	/// <param name="id"></param>
	/// <param name="result"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, int id, int result, DebatePlayer taiwu, DebatePlayer npc, bool isTaiwu = false)
	{
		OperationType = type;
		PawnId = id;
		NpcPawnId = -1;
		TemplateId = -1;
		Result = result;
		IsTaiwu = isTaiwu;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 卡片位置变化
	/// </summary>
	/// <param name="type"></param>
	/// <param name="value1"></param>
	/// <param name="value2"></param>
	/// <param name="result"></param>
	/// <param name="templateId"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, int value1, int value2, int result, short templateId, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		Source = value1;
		Destination = value2;
		Index = result;
		TemplateId = templateId;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 论战
	/// </summary>
	/// <param name="type"></param>
	/// <param name="value1"></param>
	/// <param name="value2"></param>
	/// <param name="result"></param>
	/// <param name="bases"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, int value1, int value2, int result, IntPair bases, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		PawnId = value1;
		NpcPawnId = value2;
		Result = result;
		Target = bases;
		TemplateId = -1;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 观众评价
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="ids">(观众，玩家)</param>
	/// <param name="result"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, bool isTaiwu, IntPair ids, short result, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		PawnId = -1;
		NpcPawnId = -1;
		IsTaiwu = isTaiwu;
		Target = ids;
		TemplateId = result;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 结论点变化
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	/// <param name="nodeEffectTemplateId"></param>
	public DebateOperation(sbyte type, bool isTaiwu, DebatePlayer taiwu, DebatePlayer npc, short nodeEffectTemplateId = -1)
	{
		OperationType = type;
		PawnId = -1;
		NpcPawnId = -1;
		TemplateId = nodeEffectTemplateId;
		IsTaiwu = isTaiwu;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 回合开始
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="templateId"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, bool isTaiwu, short templateId, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		PawnId = -1;
		NpcPawnId = -1;
		IsTaiwu = isTaiwu;
		TemplateId = templateId;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 使用策略
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="templateId"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	/// <param name="strategyTargets"></param>
	/// <param name="isFailed"></param>
	public DebateOperation(sbyte type, bool isTaiwu, short templateId, DebatePlayer taiwu, DebatePlayer npc, List<StrategyTarget> strategyTargets, bool isFailed)
	{
		OperationType = type;
		PawnId = -1;
		NpcPawnId = -1;
		IsTaiwu = isTaiwu;
		TemplateId = templateId;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
		StrategyTargets = strategyTargets;
		IsFailed = isFailed;
	}

	/// <summary>
	/// 压力影响
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="pressureType"></param>
	/// <param name="taiwu"></param>
	/// <param name="npc"></param>
	public DebateOperation(sbyte type, bool isTaiwu, sbyte pressureType, DebatePlayer taiwu, DebatePlayer npc)
	{
		OperationType = type;
		PawnId = -1;
		NpcPawnId = -1;
		IsTaiwu = isTaiwu;
		Result = pressureType;
		TaiwuPressure = taiwu.Pressure;
		TaiwuBases = taiwu.Bases;
		TaiwuGamePoint = taiwu.GamePoint;
		NpcPressure = npc.Pressure;
		NpcBases = npc.Bases;
		NpcGamePoint = npc.GamePoint;
	}

	/// <summary>
	/// 格子特效的变化
	/// </summary>
	/// <param name="type"></param>
	/// <param name="nodeEffectState"></param>
	/// <param name="coordinate"></param>
	/// <param name="isTaiwu">是否由太吾的棋子触发</param>
	public DebateOperation(sbyte type, DebateNodeEffectState nodeEffectState, IntPair coordinate, bool isTaiwu = false)
	{
		OperationType = type;
		NodeEffectState = nodeEffectState;
		Target = coordinate;
		IsTaiwu = isTaiwu;
	}

	/// <summary>
	/// 添加记录
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="templateId"></param>
	/// <param name="recordParams"></param>
	public DebateOperation(sbyte type, bool isTaiwu, short templateId, int[] recordParams)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		TemplateId = templateId;
		RecordParams = recordParams;
	}

	/// <summary>
	/// 重置策略
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="cardIdList"></param>
	public DebateOperation(sbyte type, bool isTaiwu, List<short> cardIdList)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		CardIdList = new List<short>(cardIdList);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DebateOperation()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DebateOperation(DebateOperation other)
	{
		OperationType = other.OperationType;
		PawnId = other.PawnId;
		NpcPawnId = other.NpcPawnId;
		TaiwuPressure = other.TaiwuPressure;
		TaiwuGamePoint = other.TaiwuGamePoint;
		TaiwuBases = other.TaiwuBases;
		NpcPressure = other.NpcPressure;
		NpcGamePoint = other.NpcGamePoint;
		NpcBases = other.NpcBases;
		TemplateId = other.TemplateId;
		Result = other.Result;
		IsFailed = other.IsFailed;
		Target = other.Target;
		Index = other.Index;
		Source = other.Source;
		Destination = other.Destination;
		IsTaiwu = other.IsTaiwu;
		if (other.StrategyTargets != null)
		{
			List<StrategyTarget> item = other.StrategyTargets;
			int elementsCount = item.Count;
			StrategyTargets = new List<StrategyTarget>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				StrategyTargets.Add(new StrategyTarget(item[i]));
			}
		}
		else
		{
			StrategyTargets = null;
		}
		NodeEffectState = new DebateNodeEffectState(other.NodeEffectState);
		int[] item2 = other.RecordParams;
		int elementsCount2 = item2.Length;
		RecordParams = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			RecordParams[j] = item2[j];
		}
		CardIdList = ((other.CardIdList == null) ? null : new List<short>(other.CardIdList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DebateOperation other)
	{
		OperationType = other.OperationType;
		PawnId = other.PawnId;
		NpcPawnId = other.NpcPawnId;
		TaiwuPressure = other.TaiwuPressure;
		TaiwuGamePoint = other.TaiwuGamePoint;
		TaiwuBases = other.TaiwuBases;
		NpcPressure = other.NpcPressure;
		NpcGamePoint = other.NpcGamePoint;
		NpcBases = other.NpcBases;
		TemplateId = other.TemplateId;
		Result = other.Result;
		IsFailed = other.IsFailed;
		Target = other.Target;
		Index = other.Index;
		Source = other.Source;
		Destination = other.Destination;
		IsTaiwu = other.IsTaiwu;
		if (other.StrategyTargets != null)
		{
			List<StrategyTarget> item = other.StrategyTargets;
			int elementsCount = item.Count;
			StrategyTargets = new List<StrategyTarget>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				StrategyTargets.Add(new StrategyTarget(item[i]));
			}
		}
		else
		{
			StrategyTargets = null;
		}
		NodeEffectState = new DebateNodeEffectState(other.NodeEffectState);
		int[] item2 = other.RecordParams;
		int elementsCount2 = item2.Length;
		RecordParams = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			RecordParams[j] = item2[j];
		}
		CardIdList = ((other.CardIdList == null) ? null : new List<short>(other.CardIdList));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 61;
		if (StrategyTargets != null)
		{
			totalSize += 2;
			int elementsCount = StrategyTargets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				StrategyTarget element = StrategyTargets[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((NodeEffectState == null) ? (totalSize + 2) : (totalSize + (2 + NodeEffectState.GetSerializedSize())));
		totalSize = ((RecordParams == null) ? (totalSize + 2) : (totalSize + (2 + 4 * RecordParams.Length)));
		totalSize = ((CardIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CardIdList.Count)));
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
		*pCurrData = (byte)OperationType;
		pCurrData++;
		*(int*)pCurrData = PawnId;
		pCurrData += 4;
		*(int*)pCurrData = NpcPawnId;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPressure;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuGamePoint;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuBases;
		pCurrData += 4;
		*(int*)pCurrData = NpcPressure;
		pCurrData += 4;
		*(int*)pCurrData = NpcGamePoint;
		pCurrData += 4;
		*(int*)pCurrData = NpcBases;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(int*)pCurrData = Result;
		pCurrData += 4;
		*pCurrData = (IsFailed ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += Target.Serialize(pCurrData);
		*(int*)pCurrData = Index;
		pCurrData += 4;
		*(int*)pCurrData = Source;
		pCurrData += 4;
		*(int*)pCurrData = Destination;
		pCurrData += 4;
		*pCurrData = (IsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (StrategyTargets != null)
		{
			int elementsCount = StrategyTargets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				StrategyTarget element = StrategyTargets[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
		if (NodeEffectState != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize = NodeEffectState.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RecordParams != null)
		{
			int elementsCount2 = RecordParams.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = RecordParams[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CardIdList != null)
		{
			int elementsCount3 = CardIdList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CardIdList[k];
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		OperationType = (sbyte)(*pCurrData);
		pCurrData++;
		PawnId = *(int*)pCurrData;
		pCurrData += 4;
		NpcPawnId = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPressure = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuGamePoint = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuBases = *(int*)pCurrData;
		pCurrData += 4;
		NpcPressure = *(int*)pCurrData;
		pCurrData += 4;
		NpcGamePoint = *(int*)pCurrData;
		pCurrData += 4;
		NpcBases = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Result = *(int*)pCurrData;
		pCurrData += 4;
		IsFailed = *pCurrData != 0;
		pCurrData++;
		pCurrData += Target.Deserialize(pCurrData);
		Index = *(int*)pCurrData;
		pCurrData += 4;
		Source = *(int*)pCurrData;
		pCurrData += 4;
		Destination = *(int*)pCurrData;
		pCurrData += 4;
		IsTaiwu = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (StrategyTargets == null)
			{
				StrategyTargets = new List<StrategyTarget>(elementsCount);
			}
			else
			{
				StrategyTargets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					StrategyTarget element = new StrategyTarget();
					pCurrData += element.Deserialize(pCurrData);
					StrategyTargets.Add(element);
				}
				else
				{
					StrategyTargets.Add(null);
				}
			}
		}
		else
		{
			StrategyTargets?.Clear();
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (NodeEffectState == null)
			{
				NodeEffectState = new DebateNodeEffectState();
			}
			pCurrData += NodeEffectState.Deserialize(pCurrData);
		}
		else
		{
			NodeEffectState = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (RecordParams == null || RecordParams.Length != elementsCount2)
			{
				RecordParams = new int[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				RecordParams[j] = ((int*)pCurrData)[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			RecordParams = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CardIdList == null)
			{
				CardIdList = new List<short>(elementsCount3);
			}
			else
			{
				CardIdList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				CardIdList.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			CardIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
