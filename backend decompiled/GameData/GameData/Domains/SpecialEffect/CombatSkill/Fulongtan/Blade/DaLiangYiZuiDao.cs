using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class DaLiangYiZuiDao : CombatSkillEffectBase
{
	private const sbyte AddDamagePercent = 10;

	public DaLiangYiZuiDao()
	{
	}

	public DaLiangYiZuiDao(CombatSkillKey skillKey)
		: base(skillKey, 14205, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId)
		{
			AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			int addValue = 10 * base.CombatChar.GetInjuries().Get((sbyte)dataKey.CustomParam1, !base.IsDirect) * ((!CharObj.GetEatingItems().ContainsWine()) ? 1 : 2);
			if (addValue > 0)
			{
				ShowSpecialEffectTips(0);
			}
			return addValue;
		}
		return 0;
	}
}
