using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class XueChiGuiZhua : CombatSkillEffectBase
{
	public XueChiGuiZhua()
	{
	}

	public XueChiGuiZhua(CombatSkillKey skillKey)
		: base(skillKey, 15206, -1)
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
		if (PowerMatchAffectRequire(power))
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries newInjuries = injuries.Subtract(base.CombatChar.GetOldInjuries());
			List<short> enemyFeatures = base.CurrEnemyChar.GetCharacter().GetFeatureIds();
			bool anyInjuryTransferred = false;
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				short featureId = (base.IsDirect ? BreakFeatureHelper.BodyPart2CrashFeature : BreakFeatureHelper.BodyPart2HurtFeature)[bodyPart];
				if (newInjuries.Get(bodyPart, !base.IsDirect) > 0 && enemyFeatures.Contains(featureId))
				{
					injuries.Change(bodyPart, !base.IsDirect, -1);
					base.CurrEnemyChar.AddInjury(context, bodyPart, !base.IsDirect, 1);
					anyInjuryTransferred = true;
				}
			}
			if (anyInjuryTransferred)
			{
				base.CombatChar.SetInjuries(context, injuries, updateDefeatMark: true, syncAutoHealProgress: true, byTransfer: true);
				DomainManager.Combat.UpdateBodyDefeatMark(context, base.CurrEnemyChar);
				ShowSpecialEffectTips(0);
			}
		}
		RemoveSelf(context);
	}
}
