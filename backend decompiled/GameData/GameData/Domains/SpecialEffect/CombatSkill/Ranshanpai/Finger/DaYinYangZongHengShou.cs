using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class DaYinYangZongHengShou : CombatSkillEffectBase
{
	private const int StateFrame = 1200;

	private static readonly List<DaYinYangZongHengShou> ActiveInstances;

	private CombatCharacter _affectChar;

	private Dictionary<short, (short power, bool reverse)> _copiedStates;

	private int _autoRemoveCounter;

	private CombatCharacter SrcChar => base.IsDirect ? base.CombatChar : base.EnemyChar;

	private CombatCharacter DstChar => base.IsDirect ? base.EnemyChar : base.CombatChar;

	private sbyte SrcStateType => (sbyte)(base.IsDirect ? 1 : 2);

	private sbyte DstStateType => (sbyte)((!base.IsDirect) ? 1 : 2);

	static DaYinYangZongHengShou()
	{
		ActiveInstances = new List<DaYinYangZongHengShou>();
		SpecialEffectDomain.RegisterResetHandler(ActiveInstances.Clear);
	}

	private static void SetActiveAndRemoveExistInstance(DataContext context, DaYinYangZongHengShou instance)
	{
		for (int i = ActiveInstances.Count - 1; i >= 0; i--)
		{
			ActiveInstances[i].RemoveSelf(context);
		}
		ActiveInstances.Add(instance);
	}

	private static void UnsetActive(DaYinYangZongHengShou instance)
	{
		Tester.Assert(ActiveInstances.Remove(instance));
	}

	public DaYinYangZongHengShou()
	{
	}

	public DaYinYangZongHengShou(CombatSkillKey skillKey)
		: base(skillKey, 7105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		SetActiveAndRemoveExistInstance(context, this);
		_affectChar = DstChar;
		Dictionary<short, (short, bool, int)> srcStateDict = SrcChar.GetCombatStateCollection(SrcStateType).StateDict;
		Dictionary<short, (short, bool, int)> dstStateDict = DstChar.GetCombatStateCollection(DstStateType).StateDict;
		if (srcStateDict.Count > 0)
		{
			_copiedStates = new Dictionary<short, (short, bool)>();
			foreach (KeyValuePair<short, (short, bool, int)> stateEntry in srcStateDict)
			{
				(short stateId, bool reverse) tuple = CombatDomain.CalcReversedCombatState(stateEntry.Key, stateEntry.Value.Item2);
				short stateId = tuple.stateId;
				bool reverse = tuple.reverse;
				short power = stateEntry.Value.Item1;
				if (!dstStateDict.ContainsKey(stateId))
				{
					_copiedStates.Add(stateId, (power, reverse));
					DomainManager.Combat.AddCombatState(context, _affectChar, DstStateType, stateId, power, reverse, applyEffect: false);
					ShowSpecialEffectTipsOnceInFrame(0);
				}
			}
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (_copiedStates != null)
		{
			foreach (KeyValuePair<short, (short, bool)> stateEntry in _copiedStates)
			{
				DomainManager.Combat.AddCombatState(context, _affectChar, DstStateType, stateEntry.Key, -stateEntry.Value.Item1, stateEntry.Value.Item2, applyEffect: false);
			}
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		UnsetActive(this);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId == base.CharacterId && !(key != base.EffectKey) && newCount <= 0)
		{
			RemoveSelf(context);
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() == base.CharacterId && !DomainManager.Combat.Pause)
		{
			_autoRemoveCounter++;
			if (_autoRemoveCounter >= 1200)
			{
				ReduceEffectCount();
			}
		}
	}
}
