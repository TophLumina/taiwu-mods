using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class LianHuaMiaoJian : CombatSkillEffectBase
{
	private sbyte RequireMarkCount = 1;

	private sbyte AcupointLevel = 2;

	private bool _affected;

	public LianHuaMiaoJian()
	{
	}

	public LianHuaMiaoJian(CombatSkillKey skillKey)
		: base(skillKey, 2303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && (base.IsDirect ? outerMarkCount : innerMarkCount) >= RequireMarkCount)
		{
			AddAcupoint(context, bodyPart);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && (base.IsDirect ? outerMarkCount : innerMarkCount) >= RequireMarkCount)
		{
			AddAcupoint(context, bodyPart);
		}
	}

	private void AddAcupoint(DataContext context, sbyte bodyPart)
	{
		if (!_affected)
		{
			DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, AcupointLevel, SkillKey, bodyPart);
			ShowSpecialEffectTips(0);
			_affected = true;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
