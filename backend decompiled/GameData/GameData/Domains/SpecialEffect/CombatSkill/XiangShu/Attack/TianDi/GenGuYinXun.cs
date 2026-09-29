using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.TianDi;

public class GenGuYinXun : CombatSkillEffectBase, IHeavenlyEmperorHandler
{
	private const int SilenceFrame = 1200;

	private const int RemoveMarkUnit = 2;

	private readonly HeavenlyEmperorHelper _handler;

	public GenGuYinXun()
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public GenGuYinXun(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			DoAffect(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && !interrupted)
		{
			DomainManager.Combat.SilenceSkill(context, base.CombatChar, skillId, 1200, -1);
		}
	}

	private void DoAffect(DataContext context)
	{
		int outerUnit = _handler.MakeDamageEffectCount;
		int innerUnit = _handler.AcceptDamageEffectCount;
		int totalUnit = outerUnit + innerUnit;
		if (totalUnit > 0)
		{
			ShowSpecialEffectTips(0);
			base.CombatChar.RemoveRandomInjury(context, inner: false, outerUnit * 2);
			base.CombatChar.RemoveRandomInjury(context, inner: true, innerUnit * 2);
			base.CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: true, outerUnit * 2);
			base.CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: false, innerUnit * 2);
			base.CombatChar.RemoveMindMark(context, totalUnit * 2, random: true);
			base.CombatChar.RemoveFatalMark(context, totalUnit * 2);
		}
	}
}
