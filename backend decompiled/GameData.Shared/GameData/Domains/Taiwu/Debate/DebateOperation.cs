using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class DebateOperation : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte OperationType;

	[SerializableGameDataField]
	public int PawnId;

	[SerializableGameDataField]
	public int NpcPawnId;

	[SerializableGameDataField]
	public int TaiwuPressure;

	[SerializableGameDataField]
	public int TaiwuGamePoint;

	[SerializableGameDataField]
	public int TaiwuBases;

	[SerializableGameDataField]
	public int NpcPressure;

	[SerializableGameDataField]
	public int NpcGamePoint;

	[SerializableGameDataField]
	public int NpcBases;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public int Result;

	[SerializableGameDataField]
	public bool IsFailed;

	[SerializableGameDataField]
	public IntPair Target;

	[SerializableGameDataField]
	public int Index;

	[SerializableGameDataField]
	public int Source;

	[SerializableGameDataField]
	public int Destination;

	[SerializableGameDataField]
	public bool IsTaiwu;

	[SerializableGameDataField]
	public List<StrategyTarget> StrategyTargets;

	[SerializableGameDataField]
	public DebateNodeEffectState NodeEffectState;

	[SerializableGameDataField]
	public int[] RecordParams;

	[SerializableGameDataField]
	public List<short> CardIdList;

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

	public DebateOperation(sbyte type, DebateNodeEffectState nodeEffectState, IntPair coordinate, bool isTaiwu = false)
	{
		OperationType = type;
		NodeEffectState = nodeEffectState;
		Target = coordinate;
		IsTaiwu = isTaiwu;
	}

	public DebateOperation(sbyte type, bool isTaiwu, short templateId, int[] recordParams)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		TemplateId = templateId;
		RecordParams = recordParams;
	}

	public DebateOperation(sbyte type, bool isTaiwu, List<short> cardIdList)
	{
		OperationType = type;
		IsTaiwu = isTaiwu;
		CardIdList = new List<short>(cardIdList);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Format("{0}: {1}, ", "OperationType", OperationType));
		stringBuilder.Append(string.Format("{0}: {1}, ", "PawnId", PawnId));
		stringBuilder.Append(string.Format("{0}: {1}, ", "NpcPawnId", NpcPawnId));
		stringBuilder.Append(string.Format("{0}: {1}, ", "TaiwuPressure", TaiwuPressure));
		stringBuilder.Append(string.Format("{0}: {1}, ", "TaiwuGamePoint", TaiwuGamePoint));
		stringBuilder.Append(string.Format("{0}: {1}, ", "TaiwuBases", TaiwuBases));
		stringBuilder.Append(string.Format("{0}: {1}, ", "NpcPressure", NpcPressure));
		stringBuilder.Append(string.Format("{0}: {1}, ", "NpcGamePoint", NpcGamePoint));
		stringBuilder.Append(string.Format("{0}: {1}, ", "NpcBases", NpcBases));
		stringBuilder.Append(string.Format("{0}: {1}, ", "TemplateId", TemplateId));
		stringBuilder.Append(string.Format("{0}: {1}, ", "Result", Result));
		stringBuilder.Append(string.Format("{0}: {1}, ", "IsFailed", IsFailed));
		stringBuilder.Append(string.Format("{0}: {1}, ", "Target", Target));
		stringBuilder.Append(string.Format("{0}: {1}, ", "Index", Index));
		stringBuilder.Append(string.Format("{0}: {1}, ", "Source", Source));
		stringBuilder.Append(string.Format("{0}: {1}, ", "Destination", Destination));
		stringBuilder.Append(string.Format("{0}: {1}, ", "IsTaiwu", IsTaiwu));
		int strategyCount = StrategyTargets?.Count ?? (-1);
		stringBuilder.Append(string.Format("{0}.Count: {1}, ", "StrategyTargets", strategyCount));
		stringBuilder.Append("NodeEffectState: " + (NodeEffectState?.ToString() ?? "null") + ", ");
		stringBuilder.Append((RecordParams == null) ? "RecordParams: null, " : ("RecordParams: [" + string.Join(", ", RecordParams) + "], "));
		stringBuilder.Append((CardIdList == null) ? "CardIdList: null" : ("CardIdList: [" + string.Join(", ", CardIdList) + "]"));
		return stringBuilder.ToString();
	}

	public DebateOperation()
	{
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
