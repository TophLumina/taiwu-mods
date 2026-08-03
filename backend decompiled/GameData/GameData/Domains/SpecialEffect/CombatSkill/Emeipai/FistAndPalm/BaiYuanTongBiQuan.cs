using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;

public class BaiYuanTongBiQuan : CombatSkillEffectBase
{
	public BaiYuanTongBiQuan()
	{
	}

	public BaiYuanTongBiQuan(CombatSkillKey skillKey)
		: base(skillKey, 2103, -1)
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (power > 0)
			{
				CombatCharacter agileChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
				int changeValue = MoveSpecialConstants.MaxMobility * power / 100 * (base.IsDirect ? 1 : (-1));
				ChangeMobilityValue(context, agileChar, changeValue);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
