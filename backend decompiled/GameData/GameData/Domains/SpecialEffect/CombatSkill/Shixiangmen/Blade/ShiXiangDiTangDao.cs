using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class ShiXiangDiTangDao : CombatSkillEffectBase
{
	private const sbyte AddMobilityPercent = 30;

	private const sbyte MoveDistInCast = 20;

	public ShiXiangDiTangDao()
	{
	}

	public ShiXiangDiTangDao(CombatSkillKey skillKey)
		: base(skillKey, 6200, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		ChangeMobilityValue(context, base.CombatChar, MoveSpecialConstants.MaxMobility * 30 / 100);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 20, base.IsDirect);
		ShowSpecialEffectTips(0);
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
			RemoveSelf(context);
		}
	}
}
