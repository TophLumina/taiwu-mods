using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class KaiHeJianShu : CombatSkillEffectBase
{
	private const sbyte StatePowerUnit = 25;

	public KaiHeJianShu()
	{
	}

	public KaiHeJianShu(CombatSkillKey skillKey)
		: base(skillKey, 7203, -1)
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

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (power > 0)
		{
			short[] stateIdList = ((!base.IsDirect) ? new short[4] { 30, 31, 32, 33 } : new short[4] { 26, 27, 28, 29 });
			HitOrAvoidInts selfValue = (base.IsDirect ? CharObj.GetAvoidValues() : CharObj.GetHitValues());
			HitOrAvoidInts enemyValue = (base.IsDirect ? base.CurrEnemyChar.GetCharacter().GetAvoidValues() : base.CurrEnemyChar.GetCharacter().GetHitValues());
			bool affected = false;
			for (sbyte type = 0; type < 4; type++)
			{
				if (selfValue.Items[type] >= enemyValue.Items[type])
				{
					affected = true;
					DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, stateIdList[type], 25 * power / 10);
				}
			}
			if (affected)
			{
				ShowSpecialEffectTips(0);
			}
		}
		RemoveSelf(context);
	}
}
