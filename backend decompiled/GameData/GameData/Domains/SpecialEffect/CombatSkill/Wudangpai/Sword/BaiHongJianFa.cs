using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class BaiHongJianFa : CombatSkillEffectBase
{
	private const sbyte EnemyMoveDistance = 10;

	private const sbyte SelfMoveDistance = 10;

	private const sbyte PrepareProgressPercent = 75;

	private int _enemyMoveAccumulator;

	public BaiHongJianFa()
	{
	}

	public BaiHongJianFa(CombatSkillKey skillKey)
		: base(skillKey, 4202, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId) && base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 75 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
		{
			AddMaxEffectCount();
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.IsAlly == base.CombatChar.IsAlly || !isMove || !(base.IsDirect ? (distance > 0) : (distance < 0)) || base.EffectCount <= 0)
		{
			return;
		}
		_enemyMoveAccumulator += Math.Abs(distance);
		if (_enemyMoveAccumulator >= 10)
		{
			_enemyMoveAccumulator = 0;
			bool changeToZero = base.EffectCount > 0;
			ReduceEffectCount();
			changeToZero = changeToZero && base.EffectCount == 0;
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? (-10) : 10);
			ShowSpecialEffectTips(0);
			if (changeToZero && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
		}
	}
}
