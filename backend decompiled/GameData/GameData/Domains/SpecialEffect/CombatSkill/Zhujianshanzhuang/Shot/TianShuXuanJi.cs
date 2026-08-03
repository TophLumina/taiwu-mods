using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class TianShuXuanJi : CombatSkillEffectBase
{
	private DefeatMarkCollection _removedMarks;

	private int _removeFatalCount;

	private Dictionary<sbyte, List<FlawOrAcupointEntry>> _flawTimeDict;

	private Dictionary<sbyte, List<FlawOrAcupointEntry>> _acupointTimeDict;

	private List<CountdownData> _mindMarkTimeList;

	private static CValueFraction TransferMarkPercent => CValueHalf.RoundUp;

	public TianShuXuanJi()
	{
	}

	public TianShuXuanJi(CombatSkillKey skillKey)
		: base(skillKey, 9407, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power) && !base.SkillData.GetSilencing())
		{
			AddMaxEffectCount();
			OnCharAboutToFall(context, base.CombatChar, ECombatCharAboutToFallType.TianShuXuanJi);
		}
	}

	private void OnCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar == base.CombatChar && type == ECombatCharAboutToFallType.TianShuXuanJi && DomainManager.Combat.DefeatMarkReachFailCount(base.CombatChar) && base.EffectCount > 0)
		{
			DoAffect(context);
			ReduceEffectCount();
			DomainManager.Combat.SilenceSkill(context, base.CombatChar, base.SkillTemplateId, -1, -1);
		}
	}

	private void DoAffect(DataContext context)
	{
		_removedMarks = new DefeatMarkCollection();
		if (base.IsDirect)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries newInjuries = injuries.Subtract(base.CombatChar.GetOldInjuries());
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				(sbyte, sbyte) injury = newInjuries.Get(bodyPart);
				if (injury.Item1 > 0)
				{
					injuries.Change(bodyPart, isInnerInjury: false, (sbyte)(-injury.Item1));
					_removedMarks.OuterInjuryMarkList[bodyPart] = (byte)injury.Item1;
				}
				if (injury.Item2 > 0)
				{
					injuries.Change(bodyPart, isInnerInjury: true, (sbyte)(-injury.Item2));
					_removedMarks.InnerInjuryMarkList[bodyPart] = (byte)injury.Item2;
				}
			}
			if (newInjuries.HasAnyInjury())
			{
				base.CombatChar.SetInjuries(context, injuries, updateDefeatMark: true, syncAutoHealProgress: true, byTransfer: true);
			}
		}
		else
		{
			_flawTimeDict = new Dictionary<sbyte, List<FlawOrAcupointEntry>>();
			_acupointTimeDict = new Dictionary<sbyte, List<FlawOrAcupointEntry>>();
			_mindMarkTimeList = new List<CountdownData>();
			DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
			byte[] flawCounts = base.CombatChar.GetFlawCount();
			FlawOrAcupointCollection flaws = base.CombatChar.GetFlawCollection();
			byte[] acupointCounts = base.CombatChar.GetAcupointCount();
			FlawOrAcupointCollection acupoints = base.CombatChar.GetAcupointCollection();
			MindMarkList mindMarks = base.CombatChar.GetMindMarkTime();
			for (sbyte bodyPart2 = 0; bodyPart2 < 7; bodyPart2++)
			{
				List<FlawOrAcupointEntry> flawList = flaws.BodyPartDict[bodyPart2];
				List<FlawOrAcupointEntry> acupointList = acupoints.BodyPartDict[bodyPart2];
				_flawTimeDict.Add(bodyPart2, new List<FlawOrAcupointEntry>());
				_flawTimeDict[bodyPart2].AddRange(flawList);
				for (int i = 0; i < flawList.Count; i++)
				{
					_removedMarks.FlawMarkList[bodyPart2].Add((byte)flawList[i].Level);
				}
				markCollection.FlawMarkList[bodyPart2].Clear();
				flawCounts[bodyPart2] = 0;
				flawList.Clear();
				_acupointTimeDict.Add(bodyPart2, new List<FlawOrAcupointEntry>());
				_acupointTimeDict[bodyPart2].AddRange(acupointList);
				for (int j = 0; j < flawList.Count; j++)
				{
					_removedMarks.FlawMarkList[bodyPart2].Add((byte)acupointList[j].Level);
				}
				markCollection.AcupointMarkList[bodyPart2].Clear();
				acupointCounts[bodyPart2] = 0;
				acupointList.Clear();
			}
			if (mindMarks.MarkList != null)
			{
				_mindMarkTimeList.AddRange(mindMarks.MarkList);
				_removedMarks.MindMarkList.AddRange(markCollection.MindMarkList);
				mindMarks.MarkList.Clear();
				markCollection.MindMarkList.Clear();
			}
			base.CombatChar.SetFlawCount(flawCounts, context);
			base.CombatChar.SetFlawCollection(flaws, context);
			base.CombatChar.SetAcupointCount(acupointCounts, context);
			base.CombatChar.SetAcupointCollection(acupoints, context);
			base.CombatChar.SetMindMarkTime(mindMarks, context);
			base.CombatChar.SetDefeatMarkCollection(markCollection, context);
		}
		int transferFatalCount = base.CombatChar.GetDefeatMarkCollection().FatalDamageMarkCount * TransferMarkPercent;
		_removeFatalCount = base.CombatChar.GetDefeatMarkCollection().FatalDamageMarkCount - transferFatalCount;
		base.CombatChar.TransferFatalMark(context, base.EnemyChar, transferFatalCount);
		base.CombatChar.RemoveFatalMark(context, _removeFatalCount);
		if (_removedMarks.GetTotalCount() > 0)
		{
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		int totalCount = _removedMarks.GetTotalCount();
		int transferCount = totalCount * TransferMarkPercent;
		int addTrickCount = totalCount - transferCount + _removeFatalCount;
		if (transferCount > 0)
		{
			List<DefeatMarkKey> pool = new List<DefeatMarkKey>(_removedMarks.GetAllKeysWithoutOld());
			foreach (DefeatMarkKey markKey in RandomUtils.GetRandomUnrepeatedAndRemove(context.Random, transferCount, pool))
			{
				ApplyMarkKey(context, markKey);
			}
			base.EnemyChar.SetMindMarkTime(base.EnemyChar.GetMindMarkTime(), context);
			base.EnemyChar.UpdateMindMark(context);
			DomainManager.Combat.UpdateBodyDefeatMark(context, base.EnemyChar);
			DomainManager.Combat.AddToCheckFallenSet(base.EnemyChar.GetId());
			int remainInjuryCount = pool.Count(delegate(DefeatMarkKey x)
			{
				EMarkType type = x.Type;
				return (uint)type <= 1u;
			});
			base.CombatChar.AddScarMarkProgress(context, remainInjuryCount);
			ShowSpecialEffectTips(0);
		}
		if (addTrickCount > 0)
		{
			DomainManager.Combat.AddTrick(context, base.CombatChar, 12, addTrickCount);
			ShowSpecialEffectTips(1);
		}
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void ApplyMarkKey(DataContext context, DefeatMarkKey markKey)
	{
		EMarkType type = markKey.Type;
		if ((uint)type <= 1u)
		{
			bool inner = markKey.Type == EMarkType.Inner;
			base.EnemyChar.AddInjury(context, markKey.BodyPart, inner, 1);
			return;
		}
		type = markKey.Type;
		if ((uint)(type - 2) <= 1u)
		{
			bool flaw = markKey.Type == EMarkType.Flaw;
			Dictionary<sbyte, List<FlawOrAcupointEntry>> dict = (flaw ? _flawTimeDict : _acupointTimeDict);
			int index = context.Random.Next(0, dict[markKey.BodyPart].Count);
			var (level, total, left) = (FlawOrAcupointEntry)(ref _flawTimeDict[markKey.BodyPart][index]);
			dict[markKey.BodyPart].RemoveAt(index);
			base.EnemyChar.AddOrUpdateFlawOrAcupoint(context, markKey.BodyPart, flaw, level, raiseEvent: true, left, total);
		}
		else if (markKey.Type == EMarkType.Mind)
		{
			int index2 = context.Random.Next(0, _mindMarkTimeList.Count);
			CountdownData mindMark = _mindMarkTimeList[index2];
			_mindMarkTimeList.RemoveAt(index2);
			CombatCharacter enemyChar = base.EnemyChar;
			MindMarkList mindMarkTime = enemyChar.GetMindMarkTime();
			List<CountdownData> markList = mindMarkTime.MarkList ?? (mindMarkTime.MarkList = new List<CountdownData>());
			short keepTime = GlobalConfig.Instance.MindMarkBaseKeepTime;
			markList.Add(mindMark.Infinite ? CountdownData.Create(keepTime) : mindMark);
		}
		else if (markKey.Type == EMarkType.Fatal)
		{
			base.EnemyChar.AddFatalMark(context, 1, -1, -1);
		}
		else
		{
			PredefinedLog.Show(7, base.EffectId, $"Cannot analysis markKey {markKey}");
		}
	}
}
