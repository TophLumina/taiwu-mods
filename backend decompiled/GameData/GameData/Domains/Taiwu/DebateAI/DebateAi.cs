using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Taiwu.Debate;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.DebateAI;

public class DebateAi
{
	private bool _isTaiwu;

	private sbyte _behaviorType;

	private int _pawnDiff;

	private List<(int, int, int)> _lineWeight;

	private List<IntPair> _lineBases;

	private List<IntPair> _lineCanMakeMoveNodes;

	private List<short> _strategyCards;

	private int _state;

	public List<Action<List<StrategyTarget>>> PrepareStrategyTargetActions;

	public Dictionary<EDebateStrategyAiCheckType, Func<List<StrategyTarget>, int, bool>> StrategyCheckers;

	private static DebateGame Debate => DomainManager.Taiwu.Debate;

	public DebateAi(bool isTaiwu, sbyte behaviorType)
	{
		_isTaiwu = isTaiwu;
		_behaviorType = behaviorType;
		PrepareStrategyTargetActions = new List<Action<List<StrategyTarget>>>
		{
			SelectTargetMusic1, SelectTargetMusic2, SelectTargetMusic3, SelectTargetChess1, SelectTargetChess2, SelectTargetChess3, SelectTargetPoem1, SelectTargetPoem2, SelectTargetPoem3, SelectTargetPainting1,
			SelectTargetPainting2, SelectTargetPainting3, SelectTargetMath1, SelectTargetMath2, SelectTargetMath3, SelectTargetAppraisal1, SelectTargetAppraisal2, SelectTargetAppraisal3, SelectTargetForging1, SelectTargetForging2,
			SelectTargetForging3, SelectTargetWoodworking1, SelectTargetWoodworking2, SelectTargetWoodworking3, SelectTargetMedicine1, SelectTargetMedicine2, SelectTargetMedicine3, SelectTargetToxicology1, SelectTargetToxicology2, SelectTargetToxicology3,
			SelectTargetWeaving1, SelectTargetWeaving2, SelectTargetWeaving3, SelectTargetJade1, SelectTargetJade2, SelectTargetJade3, SelectTargetTaoism1, SelectTargetTaoism2, SelectTargetTaoism3, SelectTargetBuddhism1,
			SelectTargetBuddhism2, SelectTargetBuddhism3, SelectTargetCooking1, SelectTargetCooking2, SelectTargetCooking3, SelectTargetEclectic1, SelectTargetEclectic2, SelectTargetEclectic3
		};
		StrategyCheckers = new Dictionary<EDebateStrategyAiCheckType, Func<List<StrategyTarget>, int, bool>>
		{
			{
				EDebateStrategyAiCheckType.OpponentUsedCardCountGreater,
				CheckOpponentUsedCardCountGreater
			},
			{
				EDebateStrategyAiCheckType.OpponentOwnedCardCountGreater,
				CheckOpponentOwnedCardCountGreater
			},
			{
				EDebateStrategyAiCheckType.SelfCanUseCardCountSmaller,
				CheckSelfCanUseCardCountSmaller
			},
			{
				EDebateStrategyAiCheckType.SelfCanUseCardCountGreater,
				CheckSelfCanUseCardCountGreater
			},
			{
				EDebateStrategyAiCheckType.SelfPawnCountGreater,
				CheckSelfPawnCountGreater
			},
			{
				EDebateStrategyAiCheckType.SelfBasesGreater,
				CheckSelfBasesGreater
			},
			{
				EDebateStrategyAiCheckType.SelfStrategyPointSmaller,
				CheckSelfStrategyPointSmaller
			},
			{
				EDebateStrategyAiCheckType.TargetCountGreater,
				CheckTargetCountGreater
			},
			{
				EDebateStrategyAiCheckType.OpponentTargetCountGreater,
				CheckOpponentTargetCountGreater
			},
			{
				EDebateStrategyAiCheckType.SelfGamePointSmaller,
				CheckSelfGamePointSmaller
			},
			{
				EDebateStrategyAiCheckType.SelfGamePointGreater,
				CheckSelfGamePointGreater
			},
			{
				EDebateStrategyAiCheckType.OpponentGamePointGreater,
				CheckOpponentGamePointGreater
			},
			{
				EDebateStrategyAiCheckType.OpponentGamePointNotGreaterThanSelf,
				OpponentGamePointNotGreaterThanSelf
			},
			{
				EDebateStrategyAiCheckType.SelfNotCheckMate,
				CheckSelfNotCheckMate
			}
		};
	}

	public void Initialize(DataContext context)
	{
		_lineWeight = new List<(int, int, int)>();
		_lineBases = new List<IntPair>();
		_lineCanMakeMoveNodes = new List<IntPair>();
		_strategyCards = new List<short>();
		for (int y = 0; y < DebateConstants.DebateLineCount; y++)
		{
			int index = GetLineIndex(y);
			if (1 == 0)
			{
			}
			int num = index switch
			{
				0 => context.Random.Next(DebateAiConstants.AttackLineWeight[_behaviorType][0], DebateAiConstants.AttackLineWeight[_behaviorType][1]), 
				1 => context.Random.Next(DebateAiConstants.MidLineWeight[_behaviorType][0], DebateAiConstants.MidLineWeight[_behaviorType][1]), 
				2 => context.Random.Next(DebateAiConstants.DefenseLineWeight[_behaviorType][0], DebateAiConstants.DefenseLineWeight[_behaviorType][1]), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			int value = num;
			_lineWeight.Add((y, value, 100));
		}
	}

	public void Start(DataContext context)
	{
		int count = 0;
		while (GetCanMakeMove() && count++ < 10)
		{
			UpdateState();
			UpdateLineWeight();
			UpdateLineBases();
			ProcessStrategy(context, isBeforeMakeMove: true);
			ProcessMakeMove(context);
			ProcessStrategy(context, isBeforeMakeMove: false);
		}
	}

	public void UpdateLineWeightByDamage(bool isPawnOwner, int y)
	{
		int factor = (isPawnOwner ? DebateAiConstants.DamageLineWeight[_behaviorType] : DebateAiConstants.DamagedLineWeight[_behaviorType]);
		for (int i = 0; i < _lineWeight.Count; i++)
		{
			if (_lineWeight[i].Item1 == y)
			{
				_lineWeight[i] = (y, _lineWeight[i].Item2 * factor, _lineWeight[i].Item3);
				break;
			}
		}
	}

	public List<int> GetRemovingCards(DataContext context)
	{
		List<int> res = new List<int>();
		if (!Debate.TryGetPlayerCardRemovingCount(_isTaiwu, out var _))
		{
			return res;
		}
		List<short> cards = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).CanUseCards;
		for (int i = 0; i < cards.Count; i++)
		{
			res.Add(i);
		}
		CollectionUtils.Shuffle(context.Random, res);
		for (int j = 0; j < GlobalConfig.Instance.DebateMaxCanUseCards; j++)
		{
			res.RemoveAt(0);
		}
		return res;
	}

	private bool GetCanMakeMove()
	{
		if (Debate.GetPlayerCanMakeMove(_isTaiwu))
		{
			return true;
		}
		for (int y = 0; y < DebateConstants.DebateLineCount; y++)
		{
			for (int x = 0; x < DebateConstants.DebateLineNodeCount; x++)
			{
				IntPair coordinate = new IntPair(x, y);
				if (Debate.GetNodeCanMakeMove(coordinate, _isTaiwu) && Debate.GetNodeIsContainingEffect(coordinate, 41))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool TryMakeMove(DataContext context, IntPair coordinate, sbyte grade)
	{
		if (!Debate.GetNodeCanMakeMove(coordinate, _isTaiwu))
		{
			return false;
		}
		DomainManager.Taiwu.DebateGameMakeMove(context, coordinate, _isTaiwu, grade);
		return true;
	}

	private bool TryMakeMove(DataContext context, int y, sbyte grade, sbyte type)
	{
		int start = 0;
		int direction = 1;
		switch (type)
		{
		case 2:
		{
			_lineCanMakeMoveNodes.Clear();
			for (int x = 0; x < DebateConstants.DebateLineNodeCount; x++)
			{
				if (Debate.GetNodeCanMakeMove(new IntPair(x, y), _isTaiwu))
				{
					_lineCanMakeMoveNodes.Add(new IntPair(x, y));
				}
			}
			if (_lineCanMakeMoveNodes.Count <= 0)
			{
				return false;
			}
			CollectionUtils.Shuffle(context.Random, _lineCanMakeMoveNodes);
			DomainManager.Taiwu.DebateGameMakeMove(context, _lineCanMakeMoveNodes[0], _isTaiwu, grade);
			return true;
		}
		case 0:
			start = (_isTaiwu ? (DebateConstants.DebateLineNodeCount - 1) : 0);
			direction = ((!_isTaiwu) ? 1 : (-1));
			break;
		case 1:
			start = ((!_isTaiwu) ? (DebateConstants.DebateLineNodeCount - 1) : 0);
			direction = (_isTaiwu ? 1 : (-1));
			break;
		}
		foreach (var data in _lineWeight)
		{
			for (int i = start; Debate.GetCoordinateValid(i); i += direction)
			{
				IntPair coordinate = new IntPair(i, data.Item1);
				if (Debate.GetNodeCanMakeMove(coordinate, _isTaiwu))
				{
					DomainManager.Taiwu.DebateGameMakeMove(context, coordinate, _isTaiwu, grade);
					return true;
				}
			}
		}
		return false;
	}

	private void MakeMoveByWeight(DataContext context, sbyte grade, sbyte type)
	{
		using List<(int, int, int)>.Enumerator enumerator = _lineWeight.GetEnumerator();
		while (enumerator.MoveNext() && !TryMakeMove(context, enumerator.Current.Item1, grade, type))
		{
		}
	}

	private void MakeMoveByBases(DataContext context, sbyte grade, sbyte type, bool isReversed)
	{
		_lineBases.Sort(isReversed ? new Comparison<IntPair>(CompareLineBasesReversed) : new Comparison<IntPair>(CompareLineBases));
		using List<IntPair>.Enumerator enumerator = _lineBases.GetEnumerator();
		while (enumerator.MoveNext() && !TryMakeMove(context, enumerator.Current.First, grade, type))
		{
		}
	}

	private void MakeMoveByBehavior(DataContext context, sbyte grade)
	{
		switch (_behaviorType)
		{
		case 0:
		{
			if (!TryGetDisadvantageLine(out var y6) || !TryMakeMove(context, y6, grade, 2))
			{
				MakeMoveByWeight(context, grade, 2);
			}
			break;
		}
		case 1:
		{
			if (!TryGetDisadvantageLine(out var y3) || !TryMakeMove(context, y3, grade, 1))
			{
				MakeMoveByWeight(context, grade, 1);
			}
			break;
		}
		case 2:
		{
			DebatePlayer selfPlayer2 = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
			DebatePlayer opponentPlayer2 = Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu);
			int y5;
			if (selfPlayer2.MaxBases >= opponentPlayer2.MaxBases)
			{
				if (!TryGetDisadvantageLine(out var y4) || !TryMakeMove(context, y4, grade, 2))
				{
					MakeMoveByWeight(context, grade, 2);
				}
			}
			else if (!TryGetEmptyOpponentPawnLine(out y5) || !TryMakeMove(context, y5, grade, 0))
			{
				MakeMoveByWeight(context, grade, 0);
			}
			break;
		}
		case 3:
		{
			DebatePlayer selfPlayer = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
			DebatePlayer opponentPlayer = Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu);
			int y2;
			if (selfPlayer.MaxBases >= opponentPlayer.MaxBases)
			{
				if (!TryGetDisadvantageLine(out var y) || !TryMakeMove(context, y, grade, 0))
				{
					MakeMoveByWeight(context, grade, 0);
				}
			}
			else if (!TryGetEmptyOpponentPawnLine(out y2) || !TryMakeMove(context, y2, grade, 0))
			{
				MakeMoveByWeight(context, grade, 0);
			}
			break;
		}
		case 4:
			MakeMoveByWeight(context, grade, 2);
			break;
		}
	}

	private void CastStrategy(DataContext context, short templateId)
	{
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		int index = -1;
		for (int i = 0; i < player.CanUseCards.Count; i++)
		{
			short card = player.CanUseCards[i];
			if (card == templateId)
			{
				index = i;
				break;
			}
		}
		if (index < 0 || config.UsedCost > player.StrategyPoint || !Debate.TryGetStrategyTarget(templateId, _isTaiwu, out var targets))
		{
			return;
		}
		if (targets != null)
		{
			for (int j = 0; j < targets.Count; j++)
			{
				StrategyTarget target = targets[j];
				Debate.AddStrategyRepeatedTargets(config.TargetList[j][0], target.List);
				CollectionUtils.Shuffle(context.Random, target.List);
			}
		}
		PrepareStrategyTargetActions[templateId](targets);
		if (TrySelectTargetGeneral(templateId, targets) && CheckStrategyCanUse(templateId, targets))
		{
			DomainManager.Taiwu.DebateGameCastStrategy(context, index, _isTaiwu, targets);
		}
	}

	private void UpdateState()
	{
		if (Debate.Round > DebateAiConstants.StateRoundInfluence[_behaviorType])
		{
			_state = 2;
			return;
		}
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		int gamePointPressure = player.GamePoint * 100 / DebateConstants.MaxGamePoint - player.Pressure * 100 / player.MaxPressure;
		if (gamePointPressure <= DebateAiConstants.StateGamePointPressureInfluence[_behaviorType][1])
		{
			_state = 2;
			return;
		}
		_state = ((gamePointPressure <= DebateAiConstants.StateGamePointPressureInfluence[_behaviorType][0]) ? 1 : 0);
		_pawnDiff = GetPawnDiff();
		if (_pawnDiff >= DebateAiConstants.StatePawnCountInfluence[_behaviorType][1])
		{
			_state = 2;
		}
		else if (_pawnDiff >= DebateAiConstants.StatePawnCountInfluence[_behaviorType][0])
		{
			_state = 1;
		}
	}

	private void UpdateLineWeight()
	{
		for (int i = 0; i < _lineWeight.Count; i++)
		{
			int y = _lineWeight[i].Item1;
			int factor = 100;
			if (Debate.DebateGrid[new IntPair(0, y)].EffectState.TemplateId == 4)
			{
				factor += DebateAiConstants.EgoisticNodeEffectWeightPercent;
			}
			if (Debate.DebateGrid[new IntPair(DebateConstants.DebateLineNodeCount - 1, y)].EffectState.TemplateId == 4)
			{
				factor += DebateAiConstants.EgoisticNodeEffectWeightPercent;
			}
			_lineWeight[i] = (y, _lineWeight[i].Item2, factor);
		}
		_lineWeight.Sort(CompareLineWeight);
	}

	private void UpdateLineBases()
	{
		_lineBases.Clear();
		for (int y = 0; y < DebateConstants.DebateLineCount; y++)
		{
			int bases = 0;
			for (int x = 0; x < DebateConstants.DebateLineNodeCount; x++)
			{
				int pawnId = Debate.DebateGrid[new IntPair(x, y)].PawnId;
				if (pawnId >= 0 && Debate.Pawns[pawnId].IsOwnedByTaiwu == _isTaiwu)
				{
					bases += Debate.GetPawnBases(pawnId, -1, isReal: false, _isTaiwu);
				}
			}
			_lineBases.Add(new IntPair(y, bases));
		}
	}

	private void ProcessStrategy(DataContext context, bool isBeforeMakeMove)
	{
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		if (!isBeforeMakeMove)
		{
			_strategyCards.Clear();
			foreach (short card in player.CanUseCards)
			{
				if (DebateStrategy.Instance[card].AvoidCheckMate)
				{
					_strategyCards.Add(card);
				}
			}
			_strategyCards.Sort(CompareStrategy);
			foreach (short card2 in _strategyCards)
			{
				if (!TryGetCheckMatePawn(_isTaiwu, checkBeatable: false, out var _, out var _))
				{
					break;
				}
				CastStrategy(context, card2);
			}
		}
		int kept = GetStrategyPointKept(isBeforeMakeMove);
		if (player.StrategyPoint < kept)
		{
			return;
		}
		_strategyCards.Clear();
		foreach (short card3 in player.CanUseCards)
		{
			if (DebateStrategy.Instance[card3].UseBeforeMakeMove == isBeforeMakeMove)
			{
				_strategyCards.Add(card3);
			}
		}
		_strategyCards.Sort(CompareStrategy);
		foreach (short card4 in _strategyCards)
		{
			if (player.StrategyPoint < kept)
			{
				return;
			}
			CastStrategy(context, card4);
		}
		int gamePointDelta = Debate.GetGamePointAndPressureDelta(player, GlobalConfig.Instance.DebateResetCardsPressureDelta).gamePoint;
		if (Debate.GetPlayerCanUseResetStrategy(_isTaiwu) && gamePointDelta + player.GamePoint > 0 && player.UsedCards.Count > GlobalConfig.Instance.ResetStrategyUsedCardLimit)
		{
			DomainManager.Taiwu.DebateGameResetCards(context, _isTaiwu, isManul: false);
		}
		DomainManager.Taiwu.DebateGameRemoveCards(_isTaiwu, GetRemovingCards(context));
	}

	private void ProcessMakeMove(DataContext context)
	{
		if (TryGetCheckMatePawn(_isTaiwu, checkBeatable: true, out var minGrade, out var coordinate) && TryGetMaxGradeCanMakeMove(8, minGrade, out var maxGrade) && TryMakeMove(context, coordinate, (sbyte)context.Random.Next(minGrade, maxGrade + 1)))
		{
			return;
		}
		TryGetMaxGradeCanMakeMove(8, 0, out maxGrade);
		DebatePlayer selfPlayer = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		DebatePlayer opponentPlayer = Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu);
		foreach (DebateNode node in Debate.DebateGrid.Values)
		{
			if (node.EffectState.TemplateId == 1 && TryMakeMove(context, GetBehindCoordinate(node.Coordinate), maxGrade))
			{
				return;
			}
		}
		foreach (DebateNode node2 in Debate.DebateGrid.Values)
		{
			if (node2.EffectState.TemplateId == 2 && TryMakeMove(context, node2.Coordinate, (sbyte)(context.Random.CheckPercentProb(DebateAiConstants.EvenNodeEffectMaxGradeProb[_behaviorType]) ? maxGrade : 0)))
			{
				return;
			}
		}
		if (_behaviorType == 3)
		{
			foreach (DebateNode node3 in Debate.DebateGrid.Values)
			{
				if (node3.EffectState.TemplateId == 3 && TryMakeMove(context, GetBehindCoordinate(node3.Coordinate), maxGrade))
				{
					return;
				}
			}
		}
		if (Debate.Round <= DebateAiConstants.RoundBeforeEarly)
		{
			MakeMoveByBehavior(context, maxGrade);
			return;
		}
		sbyte grade = (sbyte)(GetBasesEnough() ? context.Random.Next(DebateAiConstants.MinGradeIfEnoughBases, maxGrade + 1) : ((!context.Random.CheckPercentProb(DebateAiConstants.ZeroGradePawnProb[_state])) ? maxGrade : 0));
		if (_state == 2)
		{
			if (_pawnDiff + selfPlayer.GamePoint - opponentPlayer.GamePoint >= 0)
			{
				MakeMoveByBases(context, grade, 2, isReversed: false);
			}
			else if (context.Random.CheckPercentProb(DebateAiConstants.MakeMoveOnOverwhelmingLineProb))
			{
				MakeMoveByBases(context, grade, 2, isReversed: true);
			}
			else
			{
				MakeMoveByWeight(context, grade, 2);
			}
		}
		else
		{
			MakeMoveByWeight(context, grade, 2);
		}
	}

	private bool GetGamePointNotFull()
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).GamePoint < DebateConstants.MaxGamePoint;
	}

	private int GetBasesPercent()
	{
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		return (player.MaxBases != 0) ? (player.Bases * 100 / player.MaxBases) : 0;
	}

	private bool GetBasesEnough()
	{
		int state = _state;
		if (1 == 0)
		{
		}
		int num = state switch
		{
			0 => DebateAiConstants.EarlyBases[_behaviorType], 
			1 => DebateAiConstants.MidBases[_behaviorType], 
			_ => DebateAiConstants.LateBases[_behaviorType], 
		};
		if (1 == 0)
		{
		}
		int minPercent = num;
		return GetBasesPercent() >= minPercent;
	}

	private int GetStrategyPointKept(bool beforeMakeMove)
	{
		int index = ((!beforeMakeMove) ? 1 : 0);
		int state = _state;
		if (1 == 0)
		{
		}
		int result = state switch
		{
			0 => DebateAiConstants.EarlyStrategyPoint[_behaviorType][index], 
			1 => DebateAiConstants.MidStrategyPoint[_behaviorType][index], 
			_ => DebateAiConstants.LateStrategyPoint[_behaviorType][index], 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private int GetLineIndex(int y)
	{
		return _isTaiwu ? y : Math.Abs(y - 2);
	}

	private int GetCheckMatePosition(bool isTaiwu)
	{
		return (!isTaiwu) ? 1 : (DebateConstants.DebateLineNodeCount - 2);
	}

	private IntPair GetBehindCoordinate(IntPair coordinate)
	{
		return new IntPair(_isTaiwu ? (coordinate.First - 1) : (coordinate.First + 1), coordinate.Second);
	}

	private int GetPawnDiff()
	{
		int selfCount = 0;
		int opponentCount = 0;
		foreach (Pawn pawn in Debate.Pawns.Values)
		{
			if (pawn.IsAlive)
			{
				if (pawn.IsOwnedByTaiwu == _isTaiwu)
				{
					selfCount++;
				}
				else
				{
					opponentCount++;
				}
			}
		}
		return opponentCount - selfCount;
	}

	private bool CheckStrategyCanUse(short templateId, List<StrategyTarget> targets)
	{
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		int state = _state;
		if (1 == 0)
		{
		}
		List<EDebateStrategyAiCheckType> list = state switch
		{
			0 => config.EarlyLimits, 
			1 => config.MidLimits, 
			2 => config.LateLimits, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		if (1 == 0)
		{
		}
		List<EDebateStrategyAiCheckType> limits = list;
		int state2 = _state;
		if (1 == 0)
		{
		}
		List<int> list2 = state2 switch
		{
			0 => config.EarlyLimitParams, 
			1 => config.MidLimitParams, 
			2 => config.LateLimitParams, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		if (1 == 0)
		{
		}
		List<int> limitParams = list2;
		if (limits == null || limits.Count == 0)
		{
			return true;
		}
		for (int index = 0; index < limits.Count; index++)
		{
			if (!StrategyCheckers[limits[index]](targets, limitParams[index]))
			{
				return false;
			}
		}
		return true;
	}

	private bool TrySelectTargetGeneral(short templateId, List<StrategyTarget> targets)
	{
		if (targets == null)
		{
			return true;
		}
		DebateStrategyItem config = DebateStrategy.Instance[templateId];
		for (int i = 0; i < targets.Count; i++)
		{
			StrategyTarget target = targets[i];
			short min = config.TargetList[i][1];
			short max = config.TargetList[i][2];
			if (target == null)
			{
				return false;
			}
			if (i > 0 && target.Type == targets[i - 1].Type)
			{
				Debate.CullStrategyTargets(targets[i - 1].List, target.List);
			}
			if (target.List.Count > max)
			{
				while (target.List.Count > max)
				{
					target.List.RemoveAt(target.List.Count - 1);
				}
			}
			else if (target.List.Count < min)
			{
				return false;
			}
		}
		sbyte cost = config.UsedCost;
		int remaining = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).StrategyPoint - cost;
		for (int j = 0; j < targets.Count; j++)
		{
			StrategyTarget target2 = targets[j];
			short min2 = config.TargetList[j][1];
			if (target2.Type != EDebateStrategyTargetObjectType.Pawn)
			{
				continue;
			}
			for (int k = 0; k < target2.List.Count; k++)
			{
				if (!Debate.TryGetPawnStrategyEffectValue((int)target2.List[k], 28, out var value))
				{
					continue;
				}
				remaining -= value;
				if (remaining < 0)
				{
					remaining += value;
					target2.List.RemoveAt(k--);
					if (target2.List.Count < min2)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private bool TryGetCheckMatePawn(bool isTaiwu, bool checkBeatable, out sbyte resGrade, out IntPair resCoordinate)
	{
		int x = GetCheckMatePosition(!isTaiwu);
		bool found = false;
		resGrade = 8;
		resCoordinate = default(IntPair);
		for (int y = 0; y < DebateConstants.DebateLineCount; y++)
		{
			int pawnId = Debate.DebateGrid[new IntPair(x, y)].PawnId;
			IntPair coordinate = Debate.GetStartCoordinate(isTaiwu, y);
			sbyte grade = 0;
			if (pawnId >= 0 && Debate.Pawns[pawnId].IsOwnedByTaiwu != isTaiwu && Debate.DebateGrid[coordinate].PawnId < 0 && (!checkBeatable || TryGetRequiredGradeToBeatPawn(pawnId, out grade)) && grade <= resGrade)
			{
				found = true;
				resGrade = grade;
				resCoordinate = coordinate;
			}
		}
		return found;
	}

	private bool TryGetRequiredGradeToBeatPawn(int pawnId, out sbyte grade)
	{
		int bases = Debate.GetPawnBases(pawnId, -1, isReal: false, _isTaiwu);
		grade = -1;
		if (Debate.TryGetPawnRevealedStrategyEffectValue(pawnId, 6, _isTaiwu, out var percent))
		{
			bases = bases * 100 / percent;
		}
		for (sbyte i = 0; i < 8; i++)
		{
			if (Debate.GetPawnInitialBases(_isTaiwu, i, 0) > bases)
			{
				grade = i;
				return true;
			}
		}
		return false;
	}

	private bool TryGetMaxGradeCanMakeMove(sbyte maxGrade, sbyte minGrade, out sbyte grade)
	{
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		for (grade = maxGrade; grade >= minGrade; grade--)
		{
			if (player.Bases >= Debate.GetPawnGradeToBase(player.MaxBases, grade))
			{
				return true;
			}
		}
		return false;
	}

	private bool TryGetDisadvantageLine(out int y)
	{
		y = -1;
		foreach (var data in _lineWeight)
		{
			int selfCount = 0;
			int opponentCount = 0;
			for (int x = 0; x < DebateConstants.DebateLineNodeCount; x++)
			{
				int pawnId = Debate.DebateGrid[new IntPair(x, data.Item1)].PawnId;
				if (pawnId >= 0)
				{
					if (Debate.Pawns[pawnId].IsOwnedByTaiwu == _isTaiwu)
					{
						selfCount++;
					}
					else
					{
						opponentCount++;
					}
				}
			}
			if (selfCount == 0 && opponentCount != 0)
			{
				(y, _, _) = data;
				return true;
			}
		}
		return false;
	}

	private bool TryGetEmptyOpponentPawnLine(out int y)
	{
		y = -1;
		foreach (var data in _lineWeight)
		{
			int opponentCount = 0;
			for (int x = 0; x < DebateConstants.DebateLineNodeCount; x++)
			{
				int pawnId = Debate.DebateGrid[new IntPair(x, data.Item1)].PawnId;
				if (pawnId >= 0 && Debate.Pawns[pawnId].IsOwnedByTaiwu != _isTaiwu)
				{
					opponentCount++;
				}
			}
			if (opponentCount == 0)
			{
				(y, _, _) = data;
				return true;
			}
		}
		return false;
	}

	private bool TryGetConflictingPawnId(int pawnId, out int otherId)
	{
		otherId = Debate.DebateGrid[Debate.GetPawnTargetPosition(pawnId)].PawnId;
		return otherId >= 0 && Debate.Pawns[pawnId].IsOwnedByTaiwu != Debate.Pawns[otherId].IsOwnedByTaiwu;
	}

	private int CompareLineWeight((int, int, int) a, (int, int, int) b)
	{
		int aValue = a.Item2 * a.Item3 / 100;
		int bValue = b.Item2 * b.Item3 / 100;
		return -aValue.CompareTo(bValue);
	}

	private int CompareLineBases(IntPair a, IntPair b)
	{
		return a.Second.CompareTo(b.Second);
	}

	private int CompareLineBasesReversed(IntPair a, IntPair b)
	{
		return -a.Second.CompareTo(b.Second);
	}

	private int CompareStrategy(short a, short b)
	{
		return a.CompareTo(b);
	}

	private void RemoveInvertBasesPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			if (Debate.TryGetPawnRevealedStrategyEffectValue(pawnId, 8, _isTaiwu, out var _))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveCheckMatePawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if (pawn.Coordinate.First == GetCheckMatePosition(pawn.IsOwnedByTaiwu))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveSpawnPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if (pawn.Coordinate.First == Debate.GetStartCoordinate(pawn.IsOwnedByTaiwu))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveGreaterConflictingPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			if (TryGetConflictingPawnId(pawnId, out var otherId) && Debate.GetPawnBases(pawnId, otherId, isReal: false, _isTaiwu) > Debate.GetPawnBases(otherId, pawnId, isReal: false, _isTaiwu))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveSmallerConflictingPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			if (TryGetConflictingPawnId(pawnId, out var otherId) && Debate.GetPawnBases(pawnId, otherId, isReal: false, _isTaiwu) <= Debate.GetPawnBases(otherId, pawnId, isReal: false, _isTaiwu))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveSmallerPawnBasesPercentTarget(StrategyTarget target)
	{
		int taiwuMaxBases = Debate.GetPlayerByPlayerIsTaiwu(isTaiwu: true).MaxBases;
		int npcMaxBases = Debate.GetPlayerByPlayerIsTaiwu(isTaiwu: false).MaxBases;
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			int maxBases = (Debate.Pawns[pawnId].IsOwnedByTaiwu ? taiwuMaxBases : npcMaxBases);
			if (Debate.GetPawnBases(pawnId) < maxBases * DebateAiConstants.RemoveStrategyTargetPawnBasesPercent / 100)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemovePlayerConflictingPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			if (TryGetConflictingPawnId(pawnId, out var otherId))
			{
				int selfPawnBases = Debate.GetPawnBases(pawnId, otherId, isReal: false, _isTaiwu);
				int opponentPawnBases = Debate.GetPawnBases(otherId, pawnId, isReal: false, _isTaiwu);
				if ((Debate.Pawns[pawnId].IsOwnedByTaiwu == _isTaiwu && selfPawnBases > opponentPawnBases) || (Debate.Pawns[pawnId].IsOwnedByTaiwu != _isTaiwu && selfPawnBases <= opponentPawnBases))
				{
					target.List.RemoveAt(i);
				}
			}
		}
	}

	private void RemoveFactorPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if ((pawn.IsOwnedByTaiwu == _isTaiwu && Debate.GetPawnBasesFactor(pawnId, isReal: false, _isTaiwu) > 0) || (pawn.IsOwnedByTaiwu != _isTaiwu && Debate.GetPawnBasesFactor(pawnId, isReal: false, _isTaiwu) < 0))
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveSelfPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if (pawn.IsOwnedByTaiwu == _isTaiwu)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveOpponentPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if (pawn.IsOwnedByTaiwu != _isTaiwu)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveOpponentNonCheckMatePawnTarget(StrategyTarget target)
	{
		int x = GetCheckMatePosition(!_isTaiwu);
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			if (pawn.IsOwnedByTaiwu != _isTaiwu && pawn.Coordinate.First != x)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveNonOpponentStrategyPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			bool found = false;
			int[] strategies = pawn.Strategies;
			foreach (int strategyId in strategies)
			{
				if (strategyId >= 0)
				{
					ActivatedStrategy strategy = Debate.ActivatedStrategies[strategyId];
					if (strategy.IsCastedByTaiwu != _isTaiwu)
					{
						found = true;
						break;
					}
				}
			}
			if (!found)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveLessOpponentStrategyPawnTarget(StrategyTarget target)
	{
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int pawnId = (int)target.List[i];
			Pawn pawn = Debate.Pawns[pawnId];
			int selfCount = 0;
			int opponentCount = 0;
			int[] strategies = pawn.Strategies;
			foreach (int strategyId in strategies)
			{
				if (strategyId >= 0)
				{
					if (Debate.ActivatedStrategies[strategyId].IsCastedByTaiwu == _isTaiwu)
					{
						selfCount++;
					}
					else
					{
						opponentCount++;
					}
				}
			}
			if (opponentCount == 0 || selfCount >= opponentCount)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private void RemoveFreeCard(StrategyTarget target)
	{
		DebatePlayer player = Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu);
		for (int i = target.List.Count - 1; i >= 0; i--)
		{
			int index = (int)target.List[i];
			if (DebateStrategy.Instance[player.CanUseCards[index]].UsedCost == 0)
			{
				target.List.RemoveAt(i);
			}
		}
	}

	private int ComparePawnByDistance(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int distanceA = Math.Abs(pawnA.Coordinate.First - Debate.GetStartCoordinate(pawnA.IsOwnedByTaiwu));
		int distanceB = Math.Abs(pawnB.Coordinate.First - Debate.GetStartCoordinate(pawnB.IsOwnedByTaiwu));
		return distanceA.CompareTo(distanceB);
	}

	private int ComparePawnByDistanceReversed(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int distanceA = Math.Abs(pawnA.Coordinate.First - Debate.GetStartCoordinate(pawnA.IsOwnedByTaiwu));
		int distanceB = Math.Abs(pawnB.Coordinate.First - Debate.GetStartCoordinate(pawnB.IsOwnedByTaiwu));
		return -distanceA.CompareTo(distanceB);
	}

	private int ComparePawnByBasesFactorAndPlayer(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int factorA = Debate.GetPawnBasesFactor(pawnA.Id, isReal: false, _isTaiwu) * ((pawnA.IsOwnedByTaiwu == _isTaiwu) ? 1 : (-1));
		int factorB = Debate.GetPawnBasesFactor(pawnB.Id, isReal: false, _isTaiwu) * ((pawnB.IsOwnedByTaiwu == _isTaiwu) ? 1 : (-1));
		return factorA.CompareTo(factorB);
	}

	private int ComparePawnByDistanceReversedAndConflict(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int distanceA = Math.Abs(pawnA.Coordinate.First - Debate.GetStartCoordinate(pawnA.IsOwnedByTaiwu));
		int distanceB = Math.Abs(pawnB.Coordinate.First - Debate.GetStartCoordinate(pawnB.IsOwnedByTaiwu));
		if (distanceA == DebateConstants.DebateLineNodeCount - 2)
		{
			return -1;
		}
		if (distanceB == DebateConstants.DebateLineNodeCount - 2)
		{
			return 1;
		}
		int otherId;
		bool resultA = TryGetConflictingPawnId(pawnA.Id, out otherId);
		bool resultB = TryGetConflictingPawnId(pawnB.Id, out otherId);
		if (resultA)
		{
			return -1;
		}
		if (resultB)
		{
			return 1;
		}
		return -distanceA.CompareTo(distanceB);
	}

	private int ComparePawnByBases(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int basesA = Debate.GetPawnBases(pawnA.Id, -1, isReal: false, _isTaiwu);
		int basesB = Debate.GetPawnBases(pawnB.Id, -1, isReal: false, _isTaiwu);
		return basesA.CompareTo(basesB);
	}

	private int ComparePawnByBasesReversed(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int basesA = Debate.GetPawnBases(pawnA.Id, -1, isReal: false, _isTaiwu);
		int basesB = Debate.GetPawnBases(pawnB.Id, -1, isReal: false, _isTaiwu);
		return -basesA.CompareTo(basesB);
	}

	private int ComparePawnByBasesAndConflict(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int otherId;
		bool resultA = TryGetConflictingPawnId(pawnA.Id, out otherId);
		bool resultB = TryGetConflictingPawnId(pawnB.Id, out otherId);
		if (resultA && !resultB)
		{
			return -1;
		}
		if (!resultA && resultB)
		{
			return 1;
		}
		int basesA = Debate.GetPawnBases(pawnA.Id, -1, isReal: false, _isTaiwu) * ((pawnA.IsOwnedByTaiwu == _isTaiwu) ? 1 : (-1));
		int basesB = Debate.GetPawnBases(pawnB.Id, -1, isReal: false, _isTaiwu) * ((pawnB.IsOwnedByTaiwu == _isTaiwu) ? 1 : (-1));
		return -basesA.CompareTo(basesB);
	}

	private int ComparePawnByOpponentStrategyCount(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int countA = 0;
		int countB = 0;
		int[] strategies = pawnA.Strategies;
		foreach (int strategyId in strategies)
		{
			if (strategyId >= 0 && Debate.ActivatedStrategies[strategyId].IsCastedByTaiwu != _isTaiwu)
			{
				countA++;
			}
		}
		int[] strategies2 = pawnB.Strategies;
		foreach (int strategyId2 in strategies2)
		{
			if (strategyId2 >= 0 && Debate.ActivatedStrategies[strategyId2].IsCastedByTaiwu != _isTaiwu)
			{
				countB++;
			}
		}
		return countA.CompareTo(countB);
	}

	private int ComparePawnByOpponentStrategyCountReversed(ulong a, ulong b)
	{
		Pawn pawnA = Debate.Pawns[(int)a];
		Pawn pawnB = Debate.Pawns[(int)b];
		int countA = 0;
		int countB = 0;
		int[] strategies = pawnA.Strategies;
		foreach (int strategyId in strategies)
		{
			if (strategyId >= 0 && Debate.ActivatedStrategies[strategyId].IsCastedByTaiwu != _isTaiwu)
			{
				countA++;
			}
		}
		int[] strategies2 = pawnB.Strategies;
		foreach (int strategyId2 in strategies2)
		{
			if (strategyId2 >= 0 && Debate.ActivatedStrategies[strategyId2].IsCastedByTaiwu != _isTaiwu)
			{
				countB++;
			}
		}
		return -countA.CompareTo(countB);
	}

	private int CompareNodeByDistance(ulong a, ulong b)
	{
		DebateNode nodeA = Debate.DebateGrid[(IntPair)a];
		DebateNode nodeB = Debate.DebateGrid[(IntPair)b];
		int distanceA = Math.Abs(nodeA.Coordinate.First - Debate.GetStartCoordinate(!_isTaiwu));
		int distanceB = Math.Abs(nodeB.Coordinate.First - Debate.GetStartCoordinate(!_isTaiwu));
		return distanceA.CompareTo(distanceB);
	}

	private int CompareNodeByVantageDistanceReversed(ulong a, ulong b)
	{
		DebateNode nodeA = Debate.DebateGrid[(IntPair)a];
		DebateNode nodeB = Debate.DebateGrid[(IntPair)b];
		int distanceA = Math.Abs(nodeA.Coordinate.First - Debate.GetStartCoordinate(nodeA.IsVantage));
		int distanceB = Math.Abs(nodeB.Coordinate.First - Debate.GetStartCoordinate(nodeB.IsVantage));
		return -distanceA.CompareTo(distanceB);
	}

	private bool CheckOpponentUsedCardCountGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu).UsedCards.Count > value;
	}

	private bool CheckOpponentOwnedCardCountGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu).OwnedCards.Count > value;
	}

	private bool CheckSelfCanUseCardCountSmaller(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).CanUseCards.Count < value;
	}

	private bool CheckSelfCanUseCardCountGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).CanUseCards.Count > value;
	}

	private bool CheckSelfPawnCountGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPawnCount(_isTaiwu) > value;
	}

	private bool CheckSelfBasesGreater(List<StrategyTarget> targets, int value)
	{
		return GetBasesPercent() > value;
	}

	private bool CheckSelfStrategyPointSmaller(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).StrategyPoint < value;
	}

	private bool CheckTargetCountGreater(List<StrategyTarget> targets, int value)
	{
		int count = 0;
		foreach (StrategyTarget target in targets)
		{
			count += target.List.Count;
		}
		return count > value;
	}

	private bool CheckOpponentTargetCountGreater(List<StrategyTarget> targets, int value)
	{
		int count = 0;
		foreach (StrategyTarget target in targets)
		{
			if (target.Type != EDebateStrategyTargetObjectType.Pawn)
			{
				continue;
			}
			foreach (ulong data in target.List)
			{
				if (Debate.Pawns[(int)data].IsOwnedByTaiwu != _isTaiwu)
				{
					count++;
				}
			}
		}
		return count > value;
	}

	private bool CheckSelfGamePointSmaller(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).GamePoint < value;
	}

	private bool CheckSelfGamePointGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).GamePoint > value;
	}

	private bool CheckOpponentGamePointGreater(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu).GamePoint > value;
	}

	private bool OpponentGamePointNotGreaterThanSelf(List<StrategyTarget> targets, int value)
	{
		return Debate.GetPlayerByPlayerIsTaiwu(!_isTaiwu).GamePoint <= Debate.GetPlayerByPlayerIsTaiwu(_isTaiwu).GamePoint;
	}

	private bool CheckSelfNotCheckMate(List<StrategyTarget> targets, int value)
	{
		sbyte resGrade;
		IntPair resCoordinate;
		return !TryGetCheckMatePawn(!_isTaiwu, checkBeatable: false, out resGrade, out resCoordinate);
	}

	private void SelectTargetMusic1(List<StrategyTarget> targets)
	{
		bool avoidCheckMate = !Debate.GetPlayerCanMakeMove(_isTaiwu);
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
			if (avoidCheckMate)
			{
				RemoveCheckMatePawnTarget(target);
			}
		}
	}

	private void SelectTargetMusic2(List<StrategyTarget> targets)
	{
		bool avoidCheckMate = !Debate.GetPlayerCanMakeMove(_isTaiwu);
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
			if (avoidCheckMate)
			{
				RemoveCheckMatePawnTarget(target);
			}
		}
	}

	private void SelectTargetMusic3(List<StrategyTarget> targets)
	{
		bool avoidCheckMate = !Debate.GetPlayerCanMakeMove(_isTaiwu);
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
			if (avoidCheckMate)
			{
				RemoveCheckMatePawnTarget(target);
			}
		}
	}

	private void SelectTargetChess1(List<StrategyTarget> targets)
	{
		List<ulong> list = targets[1].List;
		TryGetMaxGradeCanMakeMove(8, 0, out var grade);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (i > grade || i <= grade - 3)
			{
				list.RemoveAt(i);
			}
		}
	}

	private void SelectTargetChess2(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetChess3(List<StrategyTarget> targets)
	{
		RemoveCheckMatePawnTarget(targets[0]);
		RemoveGreaterConflictingPawnTarget(targets[0]);
		targets[0].List.Sort(ComparePawnByDistance);
		targets[1].List.Sort(CompareNodeByVantageDistanceReversed);
	}

	private void SelectTargetPoem1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetPoem2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveCheckMatePawnTarget(target);
			RemoveSmallerConflictingPawnTarget(target);
		}
	}

	private void SelectTargetPoem3(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetPainting1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
		}
	}

	private void SelectTargetPainting2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
		}
	}

	private void SelectTargetPainting3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
		}
	}

	private void SelectTargetMath1(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetMath2(List<StrategyTarget> targets)
	{
		RemoveInvertBasesPawnTarget(targets[0]);
		RemoveFactorPawnTarget(targets[0]);
		targets[0].List.Sort(ComparePawnByBasesFactorAndPlayer);
	}

	private void SelectTargetMath3(List<StrategyTarget> targets)
	{
		RemoveSmallerConflictingPawnTarget(targets[0]);
		RemoveSpawnPawnTarget(targets[0]);
		targets[1].List.Sort(CompareNodeByDistance);
	}

	private void SelectTargetAppraisal1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveCheckMatePawnTarget(target);
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetAppraisal2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveCheckMatePawnTarget(target);
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetAppraisal3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetForging1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveCheckMatePawnTarget(target);
			RemoveSmallerConflictingPawnTarget(target);
			RemoveSmallerPawnBasesPercentTarget(target);
		}
	}

	private void SelectTargetForging2(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetForging3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetWoodworking1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetWoodworking2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetWoodworking3(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetMedicine1(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetMedicine2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSelfPawnTarget(target);
			target.List.Sort(ComparePawnByBasesReversed);
		}
	}

	private void SelectTargetMedicine3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetToxicology1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			target.List.Sort(ComparePawnByDistance);
		}
	}

	private void SelectTargetToxicology2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSelfPawnTarget(target);
			target.List.Sort(ComparePawnByBasesReversed);
		}
	}

	private void SelectTargetToxicology3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetWeaving1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveInvertBasesPawnTarget(target);
		}
	}

	private void SelectTargetWeaving2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByBasesAndConflict);
		}
	}

	private void SelectTargetWeaving3(List<StrategyTarget> targets)
	{
		targets[0].List.Sort(ComparePawnByBases);
		List<ulong> list = targets[0].List;
		List<ulong> list2 = targets[0].List;
		int index = list2.Count - 1;
		List<ulong> list3 = targets[0].List;
		ulong value = list3[list3.Count - 1];
		ulong value2 = targets[0].List[0];
		list[0] = value;
		list2[index] = value2;
	}

	private void SelectTargetJade1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSelfPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversedAndConflict);
		}
	}

	private void SelectTargetJade2(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetJade3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetTaoism1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSelfPawnTarget(target);
			RemoveSmallerConflictingPawnTarget(target);
			target.List.Sort(ComparePawnByDistanceReversed);
		}
	}

	private void SelectTargetTaoism2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveFreeCard(target);
		}
	}

	private void SelectTargetTaoism3(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetBuddhism1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveNonOpponentStrategyPawnTarget(target);
		}
	}

	private void SelectTargetBuddhism2(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemovePlayerConflictingPawnTarget(target);
		}
	}

	private void SelectTargetBuddhism3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveSmallerConflictingPawnTarget(target);
		}
	}

	private void SelectTargetCooking1(List<StrategyTarget> targets)
	{
	}

	private void SelectTargetCooking2(List<StrategyTarget> targets)
	{
		RemoveOpponentPawnTarget(targets[0]);
		RemoveSelfPawnTarget(targets[1]);
		targets[1].List.Sort(ComparePawnByBasesReversed);
	}

	private void SelectTargetCooking3(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveOpponentNonCheckMatePawnTarget(target);
		}
	}

	private void SelectTargetEclectic1(List<StrategyTarget> targets)
	{
		foreach (StrategyTarget target in targets)
		{
			RemoveLessOpponentStrategyPawnTarget(target);
		}
	}

	private void SelectTargetEclectic2(List<StrategyTarget> targets)
	{
		RemoveSelfPawnTarget(targets[0]);
		RemoveOpponentPawnTarget(targets[1]);
		targets[0].List.Sort(ComparePawnByOpponentStrategyCountReversed);
		targets[1].List.Sort(ComparePawnByOpponentStrategyCount);
	}

	private void SelectTargetEclectic3(List<StrategyTarget> targets)
	{
	}
}
