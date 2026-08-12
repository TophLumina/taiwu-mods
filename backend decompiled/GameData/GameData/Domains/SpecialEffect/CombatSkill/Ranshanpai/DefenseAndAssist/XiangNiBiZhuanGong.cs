using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class XiangNiBiZhuanGong : DefenseSkillBase
{
	private const sbyte ReduceDamagePercent = -45;

	private bool _affected;

	public XiangNiBiZhuanGong()
	{
	}

	public XiangNiBiZhuanGong(CombatSkillKey skillKey)
		: base(skillKey, 7506)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && context.Defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (attackerId != base.CharacterId || !base.CanAffect)
		{
			return;
		}
		CombatCharacter enemyChar = base.CurrEnemyChar;
		Dictionary<short, (short, bool, int)> stateDict = (base.IsDirect ? base.CombatChar.GetDebuffCombatStateCollection() : enemyChar.GetBuffCombatStateCollection()).StateDict;
		if (stateDict.Count != 0)
		{
			List<short> stateRandomPool = ObjectPool<List<short>>.Instance.Get();
			stateRandomPool.Clear();
			stateRandomPool.AddRange(stateDict.Keys);
			short moveStateId = stateRandomPool[context.Random.Next(0, stateRandomPool.Count)];
			(short, bool, int) stateInfo = stateDict[moveStateId];
			ObjectPool<List<short>>.Instance.Return(stateRandomPool);
			if (base.IsDirect)
			{
				DomainManager.Combat.RemoveCombatState(context, base.CombatChar, 2, moveStateId);
				DomainManager.Combat.AddCombatState(context, enemyChar, 2, moveStateId, stateInfo.Item1, stateInfo.Item2);
			}
			else
			{
				DomainManager.Combat.RemoveCombatState(context, enemyChar, 1, moveStateId);
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, moveStateId, stateInfo.Item1, stateInfo.Item2);
			}
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			_affected = true;
			return -45;
		}
		return 0;
	}
}
