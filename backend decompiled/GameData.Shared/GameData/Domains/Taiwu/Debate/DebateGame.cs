using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 新版较艺辩论游戏
/// </summary>
/// <summary>
/// 辩论策略相关计算
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class DebateGame : ISerializableGameData
{
	/// <summary>
	/// 策略效果的显示数据
	/// </summary>
	public struct EffectItem(int value, short effectTemplateId, short strategyTemplateId)
	{
		public int Value = value;

		public short EffectTemplateId = effectTemplateId;

		public short StrategyTemplateId = strategyTemplateId;
	}

	/// <summary>
	/// 类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeSkillType;

	/// <summary>
	/// 是否太吾先手
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwuFirst;

	/// <summary>
	/// 回合阶段
	/// </summary>
	[SerializableGameDataField]
	public sbyte State;

	/// <summary>
	/// 回合
	/// </summary>
	[SerializableGameDataField]
	public int Round;

	/// <summary>
	/// 左方选手
	/// </summary>
	[SerializableGameDataField]
	public DebatePlayer PlayerLeft;

	/// <summary>
	/// 右方选手
	/// </summary>
	[SerializableGameDataField]
	public DebatePlayer PlayerRight;

	/// <summary>
	/// 观众评价
	/// 暂时只影响赛后奖励
	/// </summary>
	[SerializableGameDataField]
	public List<DebateComment> Comments;

	/// <summary>
	/// 观众列表
	/// </summary>
	[SerializableGameDataField]
	public List<int> Spectators;

	/// <summary>
	/// 论点格集合
	/// 从上至下、从左至右
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<IntPair, DebateNode> DebateGrid;

	/// <summary>
	/// 论点棋子集合
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, Pawn> Pawns;

	/// <summary>
	/// 生效中的策略集合
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, ActivatedStrategy> ActivatedStrategies;

	/// <summary>
	/// 场地效果集合
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, DebateNodeEffectState> NodeEffects;

	/// <summary>
	/// 前端需要的数据变动
	/// </summary>
	[SerializableGameDataField]
	public List<DebateOperation> DebateOperations;

	/// <summary>
	/// 游戏是否结束
	/// </summary>
	[SerializableGameDataField]
	public bool IsGameOver;

	/// <summary>
	/// 太吾是否胜利
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwuWin;

	/// <summary>
	/// 太吾是否由AI控制
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwuAi;

	/// <summary>
	/// 太吾AI本回合是否已执行过
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwuAiProcessedInRound;

	/// <summary>
	///
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isTaiwuFirst"></param>
	/// <param name="playerLeft"></param>
	/// <param name="playerRight"></param>
	/// <param name="spectators"></param>
	/// <param name="debateGrid"></param>
	/// <param name="isTaiwuAi"></param>
	public DebateGame(sbyte type, bool isTaiwuFirst, DebatePlayer playerLeft, DebatePlayer playerRight, List<int> spectators, Dictionary<IntPair, DebateNode> debateGrid, bool isTaiwuAi)
	{
		LifeSkillType = type;
		IsTaiwuFirst = isTaiwuFirst;
		State = -1;
		Round = 0;
		PlayerLeft = playerLeft;
		PlayerRight = playerRight;
		Comments = new List<DebateComment>();
		Spectators = spectators;
		DebateGrid = debateGrid;
		Pawns = new Dictionary<int, Pawn>();
		NodeEffects = new Dictionary<int, DebateNodeEffectState>();
		ActivatedStrategies = new Dictionary<int, ActivatedStrategy>();
		DebateOperations = new List<DebateOperation>();
		IsGameOver = false;
		IsTaiwuWin = false;
		IsTaiwuAi = isTaiwuAi;
		IsTaiwuAiProcessedInRound = false;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DebateGame()
	{
		PlayerLeft = new DebatePlayer();
		PlayerRight = new DebatePlayer();
		Comments = new List<DebateComment>();
		Spectators = new List<int>();
		DebateGrid = new Dictionary<IntPair, DebateNode>();
		Pawns = new Dictionary<int, Pawn>();
		NodeEffects = new Dictionary<int, DebateNodeEffectState>();
		ActivatedStrategies = new Dictionary<int, ActivatedStrategy>();
		DebateOperations = new List<DebateOperation>();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((PlayerLeft == null) ? (totalSize + 2) : (totalSize + (2 + PlayerLeft.GetSerializedSize())));
		totalSize = ((PlayerRight == null) ? (totalSize + 2) : (totalSize + (2 + PlayerRight.GetSerializedSize())));
		totalSize = ((Comments == null) ? (totalSize + 2) : (totalSize + (2 + 12 * Comments.Count)));
		totalSize = ((Spectators == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Spectators.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(DebateGrid);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Pawns);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(ActivatedStrategies);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(NodeEffects);
		if (DebateOperations != null)
		{
			totalSize += 2;
			int elementsCount = DebateOperations.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				DebateOperation element = DebateOperations[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		*pCurrData = (byte)LifeSkillType;
		pCurrData++;
		*pCurrData = (IsTaiwuFirst ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)State;
		pCurrData++;
		*(int*)pCurrData = Round;
		pCurrData += 4;
		if (PlayerLeft != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = PlayerLeft.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PlayerRight != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = PlayerRight.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Comments != null)
		{
			int elementsCount = Comments.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Comments[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Spectators != null)
		{
			int elementsCount2 = Spectators.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = Spectators[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref DebateGrid);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Pawns);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref ActivatedStrategies);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref NodeEffects);
		if (DebateOperations != null)
		{
			int elementsCount3 = DebateOperations.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				DebateOperation element = DebateOperations[k];
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
		*pCurrData = (IsGameOver ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTaiwuWin ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTaiwuAi ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTaiwuAiProcessedInRound ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		LifeSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		IsTaiwuFirst = *pCurrData != 0;
		pCurrData++;
		State = (sbyte)(*pCurrData);
		pCurrData++;
		Round = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (PlayerLeft == null)
			{
				PlayerLeft = new DebatePlayer();
			}
			pCurrData += PlayerLeft.Deserialize(pCurrData);
		}
		else
		{
			PlayerLeft = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (PlayerRight == null)
			{
				PlayerRight = new DebatePlayer();
			}
			pCurrData += PlayerRight.Deserialize(pCurrData);
		}
		else
		{
			PlayerRight = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Comments == null)
			{
				Comments = new List<DebateComment>(elementsCount);
			}
			else
			{
				Comments.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				DebateComment element = new DebateComment();
				pCurrData += element.Deserialize(pCurrData);
				Comments.Add(element);
			}
		}
		else
		{
			Comments?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Spectators == null)
			{
				Spectators = new List<int>(elementsCount2);
			}
			else
			{
				Spectators.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				Spectators.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			Spectators?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref DebateGrid);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Pawns);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref ActivatedStrategies);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref NodeEffects);
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (DebateOperations == null)
			{
				DebateOperations = new List<DebateOperation>(elementsCount3);
			}
			else
			{
				DebateOperations.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					DebateOperation element2 = new DebateOperation();
					pCurrData += element2.Deserialize(pCurrData);
					DebateOperations.Add(element2);
				}
				else
				{
					DebateOperations.Add(null);
				}
			}
		}
		else
		{
			DebateOperations?.Clear();
		}
		IsGameOver = *pCurrData != 0;
		pCurrData++;
		IsTaiwuWin = *pCurrData != 0;
		pCurrData++;
		IsTaiwuAi = *pCurrData != 0;
		pCurrData++;
		IsTaiwuAiProcessedInRound = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 获取压力类型
	/// </summary>
	public sbyte GetPressureType(int pressure, int maxPressure)
	{
		int percent = pressure * 100 / maxPressure;
		if (percent >= DebateConstants.HighPressurePercent)
		{
			return 3;
		}
		if (percent >= DebateConstants.MidPressurePercent)
		{
			return 2;
		}
		if (percent >= DebateConstants.LowPressurePercent)
		{
			return 1;
		}
		return 0;
	}

	/// <summary>
	/// 获取玩家数据
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public DebatePlayer GetPlayerByPlayerIsTaiwu(bool isTaiwu)
	{
		if (!isTaiwu)
		{
			return PlayerRight;
		}
		return PlayerLeft;
	}

	/// <summary>
	/// 是否是玩家回合
	/// </summary>
	/// <returns></returns>
	public bool GetIsTaiwuTurn()
	{
		if (State != 0 || !IsTaiwuFirst)
		{
			if (State == 1)
			{
				return !IsTaiwuFirst;
			}
			return false;
		}
		return true;
	}

	/// <summary>
	/// 获取一个数值除以指定角色最大论据后的值
	/// </summary>
	/// <param name="value"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public int GetValueDividedByMaxBases(int value, bool isTaiwu)
	{
		DebatePlayer player = GetPlayerByPlayerIsTaiwu(isTaiwu);
		if (player.MaxBases != 0)
		{
			return value / player.MaxBases;
		}
		return 0;
	}

	public (int pressure, int gamePoint) GetGamePointAndPressureDelta(DebatePlayer player, int value)
	{
		int pressure = Math.Clamp(value, 0, player.MaxPressure);
		return (pressure: pressure, gamePoint: GetPressureType(player.HighestPressure, player.MaxPressure) - GetPressureType(pressure, player.MaxPressure));
	}

	/// <summary>
	/// 获取创建论点时，每级对应的论据
	/// </summary>
	/// <param name="maxBases"></param>
	/// <param name="grade"></param>
	/// <returns></returns>
	public int GetPawnGradeToBase(int maxBases, int grade)
	{
		return maxBases * grade * DebateConstants.GradeToBasesPercent / 100;
	}

	/// <summary>
	/// 计算论点的初始基础论据
	/// 总论据上限 * 级别 * 5%
	/// </summary>
	/// <param name="grade"></param>
	/// <param name="isOwnedByTaiwu"></param>
	/// <param name="value">由厨艺23织锦2的效果获得的部分</param>
	/// <returns></returns>
	public int GetPawnInitialBases(bool isOwnedByTaiwu, sbyte grade, int value)
	{
		return GetPawnGradeToBase(GetPlayerByPlayerIsTaiwu(isOwnedByTaiwu).MaxBases, grade) + value;
	}

	/// <summary>
	/// 获取论点棋子的战斗力
	/// Max(基础论据 + 基础论据 * (策略buff总和 * 是否反转) / 100, 存在织锦3的其它己方论点的战斗力) + (诗书3敌方论点50%战斗力 * 是否反转)
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="otherId">论战对手论点的Id</param>
	/// <param name="isReal">获取真值</param>
	/// <param name="isTaiwu">玩家或者AI在查看</param>
	/// <returns></returns>
	public int GetPawnBases(int pawnId, int otherId = -1, bool isReal = true, bool isTaiwu = true)
	{
		bool num = otherId >= 0;
		int bases = 0;
		if (num && TryGetPawnStrategyEffectValue(pawnId, 6, isReal, isTaiwu, out var value))
		{
			bases += GetPawnBases(otherId, isReal: true, isTaiwu) * value / 100 * ((!TryGetPawnStrategyEffectValue(pawnId, 8, isReal, isTaiwu, out var _)) ? 1 : (-1));
		}
		if (!TryGetMaxBasesOfLinkedPawns(pawnId, isReal, isTaiwu, includeSelf: true, out var maxBases))
		{
			return bases + GetPawnBases(pawnId, isReal, isTaiwu);
		}
		return bases + maxBases;
	}

	/// <summary>
	/// 获取不包含织锦3诗书3情况的论点论据
	/// </summary>
	/// <returns></returns>
	public int GetPawnBases(int id, bool isReal, bool isTaiwu)
	{
		return Pawns[id].Bases * (100 + GetPawnBasesFactor(id, isReal, isTaiwu)) / 100;
	}

	/// <summary>
	/// 获取棋子战斗力策略buff总和
	/// </summary>
	/// <param name="id"></param>
	/// <param name="isReal"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public int GetPawnBasesFactor(int id, bool isReal, bool isTaiwu)
	{
		int res = 0;
		if (TryGetPawnStrategyEffectValue(id, 0, isReal, isTaiwu, out var value))
		{
			res += value;
		}
		if (TryGetPawnStrategyEffectValue(id, 24, isReal, isTaiwu, out value))
		{
			res += value * GetPawnCount(Pawns[id].IsOwnedByTaiwu);
		}
		if (TryGetPawnStrategyEffectValue(id, 8, isReal, isTaiwu, out var _))
		{
			res = -res;
		}
		return res;
	}

	/// <summary>
	/// 获取棋子战斗力策略buff总和的列表
	/// </summary>
	/// <param name="id"></param>
	/// <param name="isReal"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public List<EffectItem> GetPawnBasesFactorList(int id, bool isReal, bool isTaiwu)
	{
		List<EffectItem> resultList = new List<EffectItem>();
		int value;
		bool invert = TryGetPawnStrategyEffectValue(id, 8, isReal, isTaiwu, out value, resultList);
		if (TryGetPawnStrategyEffectValue(id, 0, isReal, isTaiwu, out value, resultList))
		{
			for (int index = 0; index < resultList.Count; index++)
			{
				EffectItem effectItem = resultList[index];
				if (effectItem.EffectTemplateId == 0)
				{
					effectItem.Value = (invert ? (-effectItem.Value) : effectItem.Value);
					resultList[index] = effectItem;
				}
			}
		}
		if (TryGetPawnStrategyEffectValue(id, 24, isReal, isTaiwu, out var value2, resultList))
		{
			int result = value2 * GetPawnCount(Pawns[id].IsOwnedByTaiwu);
			if (invert)
			{
				result = -result;
			}
			for (int i = 0; i < resultList.Count; i++)
			{
				EffectItem effectItem2 = resultList[i];
				if (effectItem2.EffectTemplateId == 24)
				{
					effectItem2.Value = result;
					resultList[i] = effectItem2;
				}
			}
		}
		return resultList;
	}

	/// <summary>
	/// 计算织锦3的效果
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="includeSelf"></param>
	/// <param name="value"></param>
	/// <param name="id"></param>
	/// <param name="isReal"></param>
	/// <returns></returns>
	public bool TryGetMaxBasesOfLinkedPawns(int id, bool isReal, bool isTaiwu, bool includeSelf, out int value)
	{
		value = 0;
		if (!TryGetPawnStrategyEffectValue(id, 26, isReal, isTaiwu, out var value2))
		{
			return false;
		}
		bool isOwnedByTaiwu = Pawns[id].IsOwnedByTaiwu;
		foreach (KeyValuePair<int, Pawn> pawn2 in Pawns)
		{
			pawn2.Deconstruct(out value2, out var value3);
			int pawnId = value2;
			Pawn pawn = value3;
			if (pawn.IsAlive && pawn.IsOwnedByTaiwu == isOwnedByTaiwu && (includeSelf || id != pawnId) && TryGetPawnStrategyEffectValue(pawnId, 26, isReal: true, isTaiwu, out value2))
			{
				value = Math.Max(value, GetPawnBases(pawnId, isReal: true, isTaiwu));
			}
		}
		return true;
	}

	/// <summary>
	/// 获取论点数量
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public int GetPawnCount(bool isTaiwu)
	{
		int count = 0;
		foreach (Pawn pawn in Pawns.Values)
		{
			if (pawn.IsOwnedByTaiwu == isTaiwu && pawn.IsAlive)
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 获取一个棋子的目标位置
	/// </summary>
	public IntPair GetPawnTargetPosition(int pawnId)
	{
		return GetPawnTargetPosition(Pawns[pawnId]);
	}

	/// <summary>
	/// 获取一个棋子的目标位置
	/// </summary>
	public IntPair GetPawnTargetPosition(Pawn pawn)
	{
		return new IntPair(pawn.IsOwnedByTaiwu ? (pawn.Coordinate.First + 1) : (pawn.Coordinate.First - 1), pawn.Coordinate.Second);
	}

	/// <summary>
	/// 获取一个棋子的目标位置
	/// </summary>
	public IntPair GetPawnBehindPosition(int pawnId, int distance = 1)
	{
		return GetPawnBehindPosition(Pawns[pawnId], distance);
	}

	/// <summary>
	/// 获取一个棋子的目标位置
	/// </summary>
	public IntPair GetPawnBehindPosition(Pawn pawn, int distance)
	{
		return new IntPair(pawn.IsOwnedByTaiwu ? (pawn.Coordinate.First - distance) : (pawn.Coordinate.First + distance), pawn.Coordinate.Second);
	}

	/// <summary>
	/// 获取棋子能否造成伤害
	/// </summary>
	/// <param name="isOwnedByTaiwu"></param>
	/// <param name="x"></param>
	/// <returns></returns>
	public bool GetPawnCanDamage(bool isOwnedByTaiwu, int x)
	{
		if (!isOwnedByTaiwu || x != DebateConstants.DebateLineNodeCount - 1)
		{
			if (!isOwnedByTaiwu)
			{
				return x == 0;
			}
			return false;
		}
		return true;
	}

	/// <summary>
	/// 获取棋子是否停止前进
	/// </summary>
	/// <param name="pawnId"></param>
	/// <returns></returns>
	public bool GetPawnIsHalt(int pawnId)
	{
		if (Pawns[pawnId].IsHalt)
		{
			return Round % 2 == 0;
		}
		return false;
	}

	/// <summary>
	/// 获取论点格
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public DebateNode GetNode(int x, int y)
	{
		return DebateGrid[new IntPair(x, y)];
	}

	/// <summary>
	/// 获取一个坐标是否合法
	/// </summary>
	/// <param name="coordinate"></param>
	/// <returns></returns>
	public bool GetCoordinateValid(IntPair coordinate)
	{
		if (coordinate.First >= 0 && coordinate.First < DebateConstants.DebateLineNodeCount && coordinate.Second >= 0)
		{
			return coordinate.Second < DebateConstants.DebateLineCount;
		}
		return false;
	}

	/// <summary>
	/// 获取一个横坐标是否合法
	/// </summary>
	public bool GetCoordinateValid(int x)
	{
		if (x >= 0)
		{
			return x < DebateConstants.DebateLineNodeCount;
		}
		return false;
	}

	/// <summary>
	/// 一个论点格能否落子
	/// </summary>
	/// <param name="coordinate"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public bool GetNodeCanMakeMove(IntPair coordinate, bool isTaiwu)
	{
		if (!GetCoordinateValid(coordinate) || DebateGrid[coordinate].IsVantage != isTaiwu || DebateGrid[coordinate].PawnId >= 0 || GetMakeMoveBlockedByPawn(new IntPair(coordinate.First + 1, coordinate.Second), isTaiwu) || GetMakeMoveBlockedByPawn(new IntPair(coordinate.First - 1, coordinate.Second), isTaiwu) || GetMakeMoveBlockedByPawn(new IntPair(coordinate.First, coordinate.Second + 1), isTaiwu) || GetMakeMoveBlockedByPawn(new IntPair(coordinate.First, coordinate.Second - 1), isTaiwu) || GetNodeIsContainingEffect(coordinate, 23))
		{
			return false;
		}
		int startCoordinate = GetStartCoordinate(isTaiwu);
		int direction = (isTaiwu ? 1 : (-1));
		for (int i = startCoordinate; i != coordinate.First; i += direction)
		{
			int pawnId = DebateGrid[new IntPair(i, coordinate.Second)].PawnId;
			if (pawnId >= 0 && Pawns[pawnId].IsOwnedByTaiwu != isTaiwu)
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 一个格子能否移动论点
	/// </summary>
	/// <param name="coordinate"></param>
	/// <returns></returns>
	public bool GetNodeCanTeleportPawn(IntPair coordinate)
	{
		if (GetCoordinateValid(coordinate))
		{
			return DebateGrid[coordinate].PawnId < 0;
		}
		return false;
	}

	/// <summary>
	/// 该坐标是否有附着了毒术1的论点
	/// </summary>
	/// <param name="coordinate"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public bool GetMakeMoveBlockedByPawn(IntPair coordinate, bool isTaiwu)
	{
		int value;
		if (GetCoordinateValid(coordinate) && DebateGrid[coordinate].PawnId >= 0)
		{
			return TryGetPawnStrategyEffectId(DebateGrid[coordinate].PawnId, 23, !isTaiwu, out value);
		}
		return false;
	}

	/// <summary>
	/// 该坐标是否有指定势力的论点
	/// </summary>
	/// <param name="coordinate"></param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public bool GetNodeContainsPawn(IntPair coordinate, bool isTaiwu)
	{
		if (GetCoordinateValid(coordinate) && DebateGrid[coordinate].PawnId >= 0)
		{
			return Pawns[DebateGrid[coordinate].PawnId].IsOwnedByTaiwu == isTaiwu;
		}
		return false;
	}

	/// <summary>
	/// 尝试获取一方的空论点格
	/// 不受到毒术1的影响
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="coordinates"></param>
	/// <returns></returns>
	public bool TryGetEmptyNode(bool isTaiwu, out List<IntPair> coordinates)
	{
		coordinates = null;
		foreach (var (coordinate, node) in DebateGrid)
		{
			if (node.PawnId < 0 && node.IsVantage == isTaiwu)
			{
				if (coordinates == null)
				{
					coordinates = new List<IntPair>();
				}
				coordinates.Add(coordinate);
			}
		}
		return coordinates != null;
	}

	/// <summary>
	/// 尝试获取一方的空论点格
	/// 不受到毒术1的影响
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="coordinates"></param>
	/// <returns></returns>
	public bool TryGetEmptyNode(bool isTaiwu, List<IntPair> coordinates)
	{
		coordinates.Clear();
		foreach (var (coordinate, node) in DebateGrid)
		{
			if (node.PawnId < 0 && node.IsVantage == isTaiwu)
			{
				coordinates.Add(coordinate);
			}
		}
		return coordinates.Count != 0;
	}

	/// <summary>
	/// 获取起始点
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public IntPair GetStartCoordinate(bool isTaiwu, int y)
	{
		return new IntPair(GetStartCoordinate(isTaiwu), y);
	}

	/// <summary>
	/// 获取起始点
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public int GetStartCoordinate(bool isTaiwu)
	{
		if (!isTaiwu)
		{
			return DebateConstants.DebateLineNodeCount - 1;
		}
		return 0;
	}

	/// <summary>
	/// 查看论点前后是否有空格
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="distance"></param>
	/// <returns></returns>
	public bool GetPawnNodeContainsEmptyNeighbor(int pawnId, int distance)
	{
		Pawn pawn = Pawns[pawnId];
		int direction = ((distance > 0) ? 1 : (-1));
		IntPair startPos = pawn.Coordinate;
		direction *= (pawn.IsOwnedByTaiwu ? 1 : (-1));
		distance = Math.Abs(distance);
		for (int i = 1; i <= distance; i++)
		{
			if (GetNodeCanTeleportPawn(new IntPair(startPos.First + i * direction, startPos.Second)))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 查看论点格是否有指定效果
	/// </summary>
	/// <param name="coordinate"></param>
	/// <param name="effectId"></param>
	/// <returns></returns>
	public bool GetNodeIsContainingEffect(IntPair coordinate, short effectId)
	{
		if (!GetCoordinateValid(coordinate))
		{
			return false;
		}
		DebateNode node = DebateGrid[coordinate];
		if (node.EffectState.TemplateId < 0)
		{
			return false;
		}
		foreach (IntPair specialEffect in DebateNodeEffect.Instance[node.EffectState.TemplateId].SpecialEffectList)
		{
			if (specialEffect.First == effectId)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 能否落子
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public bool GetPlayerCanMakeMove(bool isTaiwu)
	{
		return GetPlayerByPlayerIsTaiwu(isTaiwu).MakeMoveCount < DebateConstants.MakeMoveLimit;
	}

	/// <summary>
	/// 尝试获取一个策略的可选目标集合,如果返回true则集合的元素数量必然大于等于最小数量
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="res"></param>
	/// <returns>无需目标或有指定目标为true，无目标为false</returns>
	public bool TryGetStrategyTarget(short templateId, bool isTaiwu, out List<StrategyTarget> res)
	{
		res = null;
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		if (config.TargetList == null || config.TargetList.Count == 0)
		{
			return IsStrategyTargetEnough(templateId, isTaiwu);
		}
		res = new List<StrategyTarget>();
		bool isInstant = config.TriggerType == EDebateStrategyTriggerType.Instant;
		foreach (short[] list in config.TargetList)
		{
			StrategyTarget target = GetStrategyTarget(config.UsedCost, list, isTaiwu, isInstant);
			CullStrategyTargets(templateId, target);
			res.Add(target);
			if (!IsStrategyTargetEnough(target, list[0], list[1], isInstant))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsStrategyTargetEnough(short templateId, bool isTaiwu)
	{
		List<int> collection;
		return DebateStrategy.Instance[templateId].TargetRestrict switch
		{
			15 => TryGetStrategyCardIndexCollection(ref isTaiwu, 6, out collection) != -1, 
			16 => TryGetStrategyCardIndexCollection(ref isTaiwu, 7, out collection) != -1, 
			17 => (isTaiwu ? PlayerRight.CanUseCards.Count : PlayerLeft.CanUseCards.Count) > 0, 
			_ => true, 
		};
	}

	private bool IsStrategyTargetEnough(StrategyTarget target, short type, int limit, bool isInstant)
	{
		if (target == null)
		{
			return false;
		}
		switch (type)
		{
		case 0:
		case 2:
		case 4:
		{
			if (isInstant)
			{
				return target.List.Count > 0;
			}
			int count = 0;
			foreach (ulong data in target.List)
			{
				count += DebateConstants.PawnStrategyLimit - GetPawnStrategyCount((int)data);
			}
			return count >= limit;
		}
		default:
			return target.List.Count >= limit;
		}
	}

	/// <summary>
	/// 获取一个策略的其中一组目标的对象
	/// 持续生效的策略目标必为论点，并且论点必须有空策略槽
	/// </summary>
	/// <param name="cost"></param>
	/// <param name="config"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="isInstant"></param>
	/// <returns></returns>
	private StrategyTarget GetStrategyTarget(int cost, short[] config, bool isTaiwu, bool isInstant)
	{
		EDebateStrategyTargetObjectType type = GetStrategyTargetType(config[0]);
		List<ulong> list = config[0] switch
		{
			0 => GetSelfPawn(isTaiwu, !isInstant, cost), 
			1 => GetSelfPawn(isTaiwu, !isInstant, cost), 
			2 => GetOpponentPawn(isTaiwu, !isInstant, cost), 
			3 => GetOpponentPawn(isTaiwu, !isInstant, cost), 
			4 => GetBothPawn(isTaiwu, !isInstant, cost), 
			5 => GetBothPawn(isTaiwu, !isInstant, cost), 
			6 => GetAnyNode(!isTaiwu), 
			7 => GetAnyNode(isTaiwu), 
			8 => GetSelfNode(isTaiwu), 
			9 => GetPawnGrade(), 
			10 => GetStrategyCard(isTaiwu), 
			_ => null, 
		};
		if (list != null)
		{
			return new StrategyTarget(type, list);
		}
		return null;
	}

	private List<ulong> GetSelfPawn(bool isTaiwu, bool checkStrategySlot, int cost)
	{
		if (!TryGetStrategyPawnTarget(isBoth: false, isTaiwu, checkStrategySlot, cost, out var res))
		{
			return null;
		}
		return res;
	}

	private List<ulong> GetOpponentPawn(bool isTaiwu, bool checkStrategySlot, int cost)
	{
		if (!TryGetStrategyPawnTarget(isBoth: false, !isTaiwu, checkStrategySlot, cost, out var res))
		{
			return null;
		}
		return res;
	}

	private List<ulong> GetBothPawn(bool isTaiwu, bool checkStrategySlot, int cost)
	{
		if (!TryGetStrategyPawnTarget(isBoth: true, isTaiwu, checkStrategySlot, cost, out var res))
		{
			return null;
		}
		return res;
	}

	/// <summary>
	/// 注意要去除参数阵营的底线格
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	private List<ulong> GetAnyNode(bool isTaiwu)
	{
		List<ulong> res = null;
		int invalidate = GetStartCoordinate(isTaiwu);
		foreach (var (coordinate, debateNode2) in DebateGrid)
		{
			if (debateNode2.PawnId < 0 && coordinate.First != invalidate)
			{
				if (res == null)
				{
					res = new List<ulong>();
				}
				res.Add((ulong)coordinate);
			}
		}
		return res;
	}

	/// <summary>
	/// 注意这里实际特指弈棋1的效果，即己方论点周围的空格
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	private List<ulong> GetSelfNode(bool isTaiwu)
	{
		List<ulong> res = null;
		foreach (var (coordinate, node) in DebateGrid)
		{
			if (node.PawnId < 0 && node.IsVantage == isTaiwu && !GetNodeIsContainingEffect(coordinate, 23) && (GetNodeContainsPawn(new IntPair(coordinate.First + 1, coordinate.Second), isTaiwu) || GetNodeContainsPawn(new IntPair(coordinate.First - 1, coordinate.Second), isTaiwu) || GetNodeContainsPawn(new IntPair(coordinate.First, coordinate.Second + 1), isTaiwu) || GetNodeContainsPawn(new IntPair(coordinate.First, coordinate.Second - 1), isTaiwu)) && !GetMakeMoveBlockedByPawn(new IntPair(coordinate.First + 1, coordinate.Second), isTaiwu) && !GetMakeMoveBlockedByPawn(new IntPair(coordinate.First - 1, coordinate.Second), isTaiwu) && !GetMakeMoveBlockedByPawn(new IntPair(coordinate.First, coordinate.Second + 1), isTaiwu) && !GetMakeMoveBlockedByPawn(new IntPair(coordinate.First, coordinate.Second - 1), isTaiwu))
			{
				if (res == null)
				{
					res = new List<ulong>();
				}
				res.Add((ulong)coordinate);
			}
		}
		return res;
	}

	private List<ulong> GetPawnGrade()
	{
		return new List<ulong> { 0uL, 1uL, 2uL, 3uL, 4uL, 5uL, 6uL, 7uL, 8uL };
	}

	private List<ulong> GetStrategyCard(bool isTaiwu)
	{
		DebatePlayer player = GetPlayerByPlayerIsTaiwu(isTaiwu);
		if (player.CanUseCards.Count == 0)
		{
			return null;
		}
		List<ulong> res = new List<ulong>();
		for (int index = 0; index < player.CanUseCards.Count; index++)
		{
			res.Add((ulong)index);
		}
		return res;
	}

	/// <summary>
	/// 对论点的所属阵营、空策略槽、额外策略点进行检查
	/// </summary>
	private bool TryGetStrategyPawnTarget(bool isBoth, bool isTaiwu, bool emptySlot, int cost, out List<ulong> res)
	{
		res = null;
		int remaining = GetPlayerByPlayerIsTaiwu(isTaiwu).StrategyPoint - cost;
		foreach (KeyValuePair<int, Pawn> pawn2 in Pawns)
		{
			pawn2.Deconstruct(out var key, out var value);
			int pawnId = key;
			Pawn pawn = value;
			if (pawn.IsAlive && (isBoth || isTaiwu == pawn.IsOwnedByTaiwu) && (!emptySlot || TryGetPawnEmptyStrategySlotIndex(pawnId, out key)) && (!TryGetPawnStrategyEffectValue(pawnId, 28, out var value2) || value2 <= remaining))
			{
				if (res == null)
				{
					res = new List<ulong>();
				}
				res.Add((ulong)pawnId);
			}
		}
		return res != null;
	}

	/// <summary>
	/// 添加可重复目标
	/// </summary>
	/// <param name="type"></param>
	/// <param name="targets"></param>
	public void AddStrategyRepeatedTargets(short type, List<ulong> targets)
	{
		switch (type)
		{
		case 0:
		case 2:
		case 4:
		{
			for (int index = targets.Count - 1; index >= 0; index--)
			{
				ulong data = targets[index];
				int count = DebateConstants.PawnStrategyLimit - GetPawnStrategyCount((int)data);
				for (int i = 0; i < count - 1; i++)
				{
					targets.Add(data);
				}
			}
			break;
		}
		case 1:
		case 3:
			break;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="selectedTargets"></param>
	/// <param name="canSelectTargets"></param>
	public void CullStrategyTargets(List<ulong> selectedTargets, List<ulong> canSelectTargets)
	{
		foreach (ulong target in selectedTargets)
		{
			canSelectTargets.Remove(target);
		}
	}

	private void CullStrategyTargets(short templateId, StrategyTarget target)
	{
		if (target == null)
		{
			return;
		}
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		switch (config.TargetRestrict)
		{
		case 11:
		{
			if (config.TargetRestrictValue == 0)
			{
				List<IntPair> coordinates;
				bool taiwuHasEmpty = TryGetEmptyNode(isTaiwu: true, out coordinates);
				bool npcHasEmpty = TryGetEmptyNode(isTaiwu: false, out coordinates);
				for (int i4 = target.List.Count - 1; i4 >= 0; i4--)
				{
					int pawnId4 = (int)target.List[i4];
					Pawn pawn3 = Pawns[pawnId4];
					if ((pawn3.IsOwnedByTaiwu && !taiwuHasEmpty) || (!pawn3.IsOwnedByTaiwu && !npcHasEmpty))
					{
						target.List.RemoveAt(i4);
					}
				}
				break;
			}
			for (int i5 = target.List.Count - 1; i5 >= 0; i5--)
			{
				int pawnId5 = (int)target.List[i5];
				if (!GetPawnNodeContainsEmptyNeighbor(pawnId5, config.TargetRestrictValue))
				{
					target.List.RemoveAt(i5);
				}
			}
			break;
		}
		case 12:
		{
			for (int i2 = target.List.Count - 1; i2 >= 0; i2--)
			{
				int pawnId2 = (int)target.List[i2];
				if (Pawns[pawnId2].IsRevealed)
				{
					target.List.RemoveAt(i2);
				}
			}
			break;
		}
		case 13:
		{
			for (int i3 = target.List.Count - 1; i3 >= 0; i3--)
			{
				int pawnId3 = (int)target.List[i3];
				Pawn pawn2 = Pawns[pawnId3];
				bool flag2 = false;
				int[] strategies = pawn2.Strategies;
				foreach (int strategyId2 in strategies)
				{
					if (strategyId2 >= 0 && !ActivatedStrategies[strategyId2].IsRevealed)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					target.List.RemoveAt(i3);
				}
			}
			break;
		}
		case 14:
		{
			for (int i = target.List.Count - 1; i >= 0; i--)
			{
				int pawnId = (int)target.List[i];
				Pawn pawn = Pawns[pawnId];
				bool flag = false;
				int[] strategies = pawn.Strategies;
				foreach (int strategyId in strategies)
				{
					if (strategyId >= 0 && !ActivatedStrategies[strategyId].GetIsInertia())
					{
						flag = true;
					}
				}
				if (!flag)
				{
					target.List.RemoveAt(i);
				}
			}
			break;
		}
		}
	}

	private EDebateStrategyTargetObjectType GetStrategyTargetType(short templateId)
	{
		return DebateStrategyTarget.Instance[templateId].ObjectType;
	}

	/// <summary>
	/// 获取一个论点上附着的策略数量
	/// </summary>
	/// <param name="pawnId"></param>
	/// <returns></returns>
	public int GetPawnStrategyCount(int pawnId)
	{
		int res = 0;
		int[] strategies = Pawns[pawnId].Strategies;
		for (int i = 0; i < strategies.Length; i++)
		{
			if (strategies[i] >= 0)
			{
				res++;
			}
		}
		return res;
	}

	/// <summary>
	/// 尝试获取一个论点上的空策略槽位置
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool TryGetPawnEmptyStrategySlotIndex(int pawnId, out int index)
	{
		index = -1;
		for (int i = 0; i < Pawns[pawnId].Strategies.Length; i++)
		{
			if (Pawns[pawnId].Strategies[i] < 0)
			{
				index = i;
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 尝试获取一个论点上附着的特定效果策略的策略id
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="effectTemplateId"></param>
	/// <param name="isCastedByTaiwu"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool TryGetPawnStrategyEffectId(int pawnId, short effectTemplateId, bool isCastedByTaiwu, out int value)
	{
		value = -1;
		int[] strategies = Pawns[pawnId].Strategies;
		foreach (int strategyId in strategies)
		{
			if (strategyId < 0 || !ActivatedStrategies.TryGetValue(strategyId, out var strategy) || strategy.IsCastedByTaiwu != isCastedByTaiwu)
			{
				continue;
			}
			DebateStrategyItem config = strategy.GetConfig();
			if (config.EffectList == null || config.EffectList.Count == 0)
			{
				continue;
			}
			foreach (IntPair effect in config.EffectList)
			{
				if (effect.First == effectTemplateId)
				{
					value = strategyId;
					return true;
				}
			}
		}
		return false;
	}

	/// <summary>
	/// 尝试获取一个论点上附着的策略的效果值
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="effectTemplateId"></param>
	/// <param name="value"></param>
	/// <param name="effectItemList"></param>
	/// <returns></returns>
	public bool TryGetPawnStrategyEffectValue(int pawnId, short effectTemplateId, out int value, List<EffectItem> effectItemList = null)
	{
		value = 0;
		int[] strategies = Pawns[pawnId].Strategies;
		foreach (int strategyId in strategies)
		{
			if (strategyId < 0 || !ActivatedStrategies.TryGetValue(strategyId, out var strategy))
			{
				continue;
			}
			DebateStrategyItem config = strategy.GetConfig();
			if (config.EffectList == null || config.EffectList.Count == 0)
			{
				continue;
			}
			foreach (IntPair effect in config.EffectList)
			{
				if (effect.First == effectTemplateId)
				{
					value += effect.Second;
					if (effect.Second != 0)
					{
						effectItemList?.Add(new EffectItem(effect.Second, effectTemplateId, strategy.TemplateId));
					}
				}
			}
		}
		return value != 0;
	}

	/// <summary>
	/// 尝试获取一个论点上附着的可见策略的效果值
	/// 计算论点表面论据时用
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="effectTemplateId"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="value"></param>
	/// <param name="effectItemList"></param>
	/// <returns></returns>
	public bool TryGetPawnRevealedStrategyEffectValue(int pawnId, short effectTemplateId, bool isTaiwu, out int value, List<EffectItem> effectItemList = null)
	{
		value = 0;
		int[] strategies = Pawns[pawnId].Strategies;
		foreach (int strategyId in strategies)
		{
			if (strategyId < 0 || !ActivatedStrategies.TryGetValue(strategyId, out var strategy) || (strategy.IsCastedByTaiwu != isTaiwu && !strategy.IsRevealed))
			{
				continue;
			}
			DebateStrategyItem config = strategy.GetConfig();
			if (config.EffectList == null || config.EffectList.Count == 0)
			{
				continue;
			}
			foreach (IntPair effect in config.EffectList)
			{
				if (effect.First == effectTemplateId)
				{
					value += effect.Second;
					if (effect.Second != 0)
					{
						effectItemList?.Add(new EffectItem(effect.Second, effectTemplateId, strategy.TemplateId));
					}
				}
			}
		}
		return value != 0;
	}

	/// <summary>
	/// 尝试获取一个论点上附着的策略的效果值
	/// </summary>
	/// <param name="pawnId"></param>
	/// <param name="templateId"></param>
	/// <param name="isReal"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="value"></param>
	/// <param name="effectItemList"></param>
	/// <returns></returns>
	public bool TryGetPawnStrategyEffectValue(int pawnId, short templateId, bool isReal, bool isTaiwu, out int value, List<EffectItem> effectItemList = null)
	{
		if (!isReal)
		{
			return TryGetPawnRevealedStrategyEffectValue(pawnId, templateId, isTaiwu, out value, effectItemList);
		}
		return TryGetPawnStrategyEffectValue(pawnId, templateId, out value, effectItemList);
	}

	/// <summary>
	/// 获取卡片位置
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="location"></param>
	/// <returns></returns>
	public int GetStrategyCardLocation(bool isTaiwu, int location)
	{
		return location switch
		{
			6 => (!isTaiwu) ? 3 : 0, 
			7 => isTaiwu ? 1 : 4, 
			8 => isTaiwu ? 2 : 8, 
			_ => location, 
		};
	}

	/// <summary>
	/// 获取策略卡片集合
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="location"></param>
	/// <returns></returns>
	public List<short> GetStrategyCardCollection(bool isTaiwu, int location)
	{
		return location switch
		{
			6 => isTaiwu ? PlayerLeft.OwnedCards : PlayerRight.OwnedCards, 
			7 => isTaiwu ? PlayerLeft.UsedCards : PlayerRight.UsedCards, 
			8 => isTaiwu ? PlayerLeft.CanUseCards : PlayerRight.CanUseCards, 
			0 => PlayerLeft.OwnedCards, 
			1 => PlayerLeft.UsedCards, 
			2 => PlayerLeft.CanUseCards, 
			3 => PlayerRight.OwnedCards, 
			4 => PlayerRight.UsedCards, 
			5 => PlayerRight.CanUseCards, 
			_ => null, 
		};
	}

	/// <summary>
	/// 查看指定策略模板是否含有指定效果
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="effectId"></param>
	/// <returns></returns>
	public bool GetStrategyTemplateContainsEffect(short templateId, short effectId)
	{
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		if (config.EffectList == null || config.EffectList.Count == 0)
		{
			return false;
		}
		foreach (IntPair effect in config.EffectList)
		{
			if (effect.First == effectId)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 尝试选一个太吾或者npc不为空的指定集合
	/// </summary>
	/// <param name="location"></param>
	/// <param name="collection">集合中的数值是卡片在原集合中的index</param>
	/// <param name="isTaiwu"></param>
	/// <returns></returns>
	public int TryGetStrategyCardIndexCollection(ref bool isTaiwu, int location, out List<int> collection)
	{
		List<short> taiwuCollection = GetStrategyCardCollection(isTaiwu: true, location);
		List<short> npcCollection = GetStrategyCardCollection(isTaiwu: false, location);
		int taiwuCollectionCount = taiwuCollection.Count;
		int npcCollectionCount = npcCollection.Count;
		if (location == 7)
		{
			foreach (short templateId in taiwuCollection)
			{
				if (GetStrategyTemplateContainsEffect(templateId, 31))
				{
					taiwuCollectionCount--;
				}
			}
			foreach (short templateId2 in npcCollection)
			{
				if (GetStrategyTemplateContainsEffect(templateId2, 31))
				{
					npcCollectionCount--;
				}
			}
		}
		if (taiwuCollectionCount == 0 && npcCollectionCount == 0)
		{
			collection = null;
			return -1;
		}
		if (taiwuCollectionCount != 0 && npcCollectionCount == 0)
		{
			isTaiwu = true;
		}
		else if (taiwuCollectionCount == 0 && npcCollectionCount != 0)
		{
			isTaiwu = false;
		}
		List<short> selected = (isTaiwu ? taiwuCollection : npcCollection);
		collection = new List<int>();
		for (int index = 0; index < selected.Count; index++)
		{
			if (location != 7 || !GetStrategyTemplateContainsEffect(selected[index], 31))
			{
				collection.Add(index);
			}
		}
		return GetStrategyCardLocation(isTaiwu, location);
	}

	public bool TryGetPlayerCardRemovingCount(bool isTaiwu, out int count)
	{
		count = GetPlayerByPlayerIsTaiwu(isTaiwu).CanUseCards.Count - GlobalConfig.Instance.DebateMaxCanUseCards;
		return count > 0;
	}

	public bool GetPlayerCanUseResetStrategy(bool isTaiwu)
	{
		DebatePlayer player = GetPlayerByPlayerIsTaiwu(isTaiwu);
		if (player.Pressure < player.MaxPressure && player.OwnedCards.Count == 0)
		{
			return player.UsedCards.Count != 0;
		}
		return false;
	}
}
