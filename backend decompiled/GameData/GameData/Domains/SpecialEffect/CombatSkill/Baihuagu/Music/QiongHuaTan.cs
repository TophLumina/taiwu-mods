using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class QiongHuaTan : CombatSkillEffectBase
{
	private const int StateClearThreshold = 300;

	private const int StatePowerUnit = 100;

	public QiongHuaTan()
	{
	}

	public QiongHuaTan(CombatSkillKey skillKey)
		: base(skillKey, 3304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				DoAffect(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		CombatCharacter stateChar = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		sbyte stateType = (sbyte)((!base.IsDirect) ? 1 : 2);
		Dictionary<short, (short, bool, int)> stateDict = stateChar.GetCombatStateCollection(stateType).StateDict;
		if (stateDict.Count <= 0)
		{
			return;
		}
		List<short> pool = ObjectPool<List<short>>.Instance.Get();
		pool.Clear();
		pool.AddRange(stateDict.Where<KeyValuePair<short, (short, bool, int)>>(delegate(KeyValuePair<short, (short power, bool reverse, int srcCharId)> state)
		{
			KeyValuePair<short, (short, bool, int)> keyValuePair = state;
			return keyValuePair.Value.Item1 >= 300;
		}).Select<KeyValuePair<short, (short, bool, int)>, short>(delegate(KeyValuePair<short, (short power, bool reverse, int srcCharId)> state)
		{
			KeyValuePair<short, (short, bool, int)> keyValuePair = state;
			return keyValuePair.Key;
		}));
		foreach (short stateId in pool)
		{
			DomainManager.Combat.RemoveCombatState(context, stateChar, stateType, stateId);
		}
		sbyte newStateType = (sbyte)(base.IsDirect ? 1 : 2);
		short newStateId = (short)(base.IsDirect ? 222 : 223);
		if (pool.Count > 0)
		{
			DomainManager.Combat.AddCombatState(context, stateChar, newStateType, newStateId, 100 * pool.Count);
			ShowSpecialEffectTips(0);
			ShowSpecialEffectTips(1);
		}
		ObjectPool<List<short>>.Instance.Return(pool);
	}
}
