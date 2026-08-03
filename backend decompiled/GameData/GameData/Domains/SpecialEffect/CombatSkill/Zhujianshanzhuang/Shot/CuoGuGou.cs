using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class CuoGuGou : CombatSkillEffectBase
{
	private const sbyte ReduceBreathStance = 30;

	public CuoGuGou()
	{
	}

	public CuoGuGou(CombatSkillKey skillKey)
		: base(skillKey, 9401, -1)
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
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power) && base.CombatChar.GetTrickCount(12) > 0)
		{
			if (base.IsDirect)
			{
				ChangeStanceValue(context, base.CurrEnemyChar, -1200);
			}
			else
			{
				ChangeBreathValue(context, base.CurrEnemyChar, -9000);
			}
			DomainManager.Combat.RemoveTrick(context, base.CombatChar, 12, 1);
			ShowSpecialEffectTips(0);
		}
		RemoveSelf(context);
	}
}
