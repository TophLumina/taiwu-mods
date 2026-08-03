using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class BianQueShenZhen : CombatSkillEffectBase
{
	private int _addPower;

	private int AddPowerUnit => base.IsDirect ? 5 : 10;

	public BianQueShenZhen()
	{
	}

	public BianQueShenZhen(CombatSkillKey skillKey)
		: base(skillKey, 3203, -1)
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
			if (base.IsDirect ? (base.CombatChar.GetInjuries().Subtract(base.CombatChar.GetOldInjuries()).GetSum() > 0) : base.CombatChar.GetPoison().Subtract(ref base.CombatChar.GetOldPoison()).IsNonZero())
			{
				_addPower = AddPowerUnit * (base.IsDirect ? DomainManager.Combat.HealInjuryInCombat(context, base.CombatChar, base.CombatChar, canHealOld: false) : DomainManager.Combat.HealPoisonInCombat(context, base.CombatChar, base.CombatChar, canHealOld: false));
				AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, base.SkillTemplateId);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(0);
			}
			else
			{
				RemoveSelf(context);
			}
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
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
