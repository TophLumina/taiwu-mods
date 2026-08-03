using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class YinYangMaiNiZhuan : DefenseSkillBase
{
	public YinYangMaiNiZhuan()
	{
	}

	public YinYangMaiNiZhuan(CombatSkillKey skillKey)
		: base(skillKey, 3504)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && hit && attacker == base.CombatChar && base.CanAffect)
		{
			CombatCharacter stateChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			Dictionary<short, (short, bool, int)> stateDict = (base.IsDirect ? stateChar.GetDebuffCombatStateCollection() : stateChar.GetBuffCombatStateCollection()).StateDict;
			if (stateDict.Count > 0)
			{
				List<short> stateRandomPool = ObjectPool<List<short>>.Instance.Get();
				stateRandomPool.Clear();
				stateRandomPool.AddRange(stateDict.Keys);
				short key = stateRandomPool[context.Random.Next(0, stateRandomPool.Count)];
				DomainManager.Combat.ReverseCombatState(context, stateChar, (sbyte)((!base.IsDirect) ? 1 : 2), key);
				ObjectPool<List<short>>.Instance.Return(stateRandomPool);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
