using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class FeiShaZouShi : TrickBuffFlaw
{
	private const int FatalDamageValuePercent = 10;

	private int _directDamageValue;

	public FeiShaZouShi()
	{
	}

	public FeiShaZouShi(CombatSkillKey skillKey)
		: base(skillKey, 14300)
	{
		RequireTrickType = 0;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(PrepareSkillBegin);
		Events.RegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(PrepareSkillBegin);
		Events.UnRegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		base.OnDisable(context);
	}

	private void PrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_directDamageValue = 0;
		}
	}

	private void AddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId)
		{
			_directDamageValue += damageValue;
		}
	}

	protected override bool OnReverseAffect(DataContext context, int trickCount)
	{
		int fatalDamageValue = _directDamageValue * trickCount * 10 / 100;
		if (fatalDamageValue <= 0)
		{
			return false;
		}
		base.CurrEnemyChar.AddFatalDamage(context, fatalDamageValue, -1, -1, base.SkillTemplateId);
		DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
		return true;
	}
}
