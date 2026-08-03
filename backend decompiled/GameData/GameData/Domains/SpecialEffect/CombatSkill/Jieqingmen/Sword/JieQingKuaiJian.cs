using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class JieQingKuaiJian : CombatSkillEffectBase
{
	private const sbyte AutoCastBaseOdds = 60;

	private const sbyte AutoCastExtraOdds = 20;

	private const sbyte ReduceAutoCastOdds = 20;

	private const sbyte PrepareProgressPercent = 50;

	private int _autoCastOdds;

	private bool HasExtraOdds => (base.IsDirect ? base.CombatChar : base.EnemyChar).GetTrickAtStart() == 19;

	public JieQingKuaiJian()
	{
	}

	public JieQingKuaiJian(CombatSkillKey skillKey)
		: base(skillKey, 13200, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_autoCastOdds = 60;
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _autoCastOdds < 60)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			if (PowerMatchAffectRequire(power, 1) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true) && context.Random.CheckPercentProb(_autoCastOdds + (HasExtraOdds ? 20 : 0)))
			{
				_autoCastOdds -= 20;
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			else
			{
				_autoCastOdds = 60;
			}
			DomainManager.Combat.AddTrick(context, base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!isAlly), 19, base.IsDirect);
			ShowSpecialEffectTips(0);
		}
		else
		{
			_autoCastOdds = 60;
		}
	}
}
