using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class GouQianZhi : CombatSkillEffectBase
{
	private const int AddDamageUnit = 15;

	private int _addDamagePercent;

	private bool _affected;

	public GouQianZhi()
	{
	}

	public GouQianZhi(CombatSkillKey skillKey)
		: base(skillKey, 7101, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && index >= 2 && CombatCharPowerMatchAffectRequire() && index == 2)
		{
			_addDamagePercent = 15 * base.CurrEnemyChar.GetFlawCollection().BodyPartDict[base.CombatChar.SkillAttackBodyPart].Count;
			_affected = false;
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
		if (dataKey.CombatSkillId != base.SkillTemplateId || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (!_affected)
			{
				_affected = true;
				ShowSpecialEffectTips(0);
			}
			return _addDamagePercent;
		}
		return 0;
	}
}
