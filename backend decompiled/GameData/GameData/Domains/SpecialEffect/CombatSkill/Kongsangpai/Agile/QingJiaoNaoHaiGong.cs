using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;

public class QingJiaoNaoHaiGong : AgileSkillBase
{
	private short _affectingLegSkill;

	public QingJiaoNaoHaiGong()
	{
	}

	public QingJiaoNaoHaiGong(CombatSkillKey skillKey)
		: base(skillKey, 10504)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	private void OnCastLegSkillWithAgile(DataContext context, CombatCharacter combatChar, short legSkillId)
	{
		if (base.CanAffect && combatChar == base.CombatChar && !combatChar.GetAutoCastingSkill())
		{
			AutoRemove = false;
			_affectingLegSkill = legSkillId;
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != _affectingLegSkill)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			short autoCastSkillId = DomainManager.Combat.GetRandomAttackSkill(base.CombatChar, 5, (sbyte)(Config.CombatSkill.Instance[skillId].Grade + ((!base.IsDirect) ? 1 : (-1))), context.Random, base.IsDirect, skillId);
			if (autoCastSkillId >= 0)
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, autoCastSkillId);
				ShowSpecialEffectTips(0);
			}
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (AgileSkillChanged)
		{
			RemoveSelf(context);
		}
		else
		{
			AutoRemove = true;
		}
	}
}
