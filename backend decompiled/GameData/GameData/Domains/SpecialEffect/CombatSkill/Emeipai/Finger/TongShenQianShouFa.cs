using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class TongShenQianShouFa : CombatSkillEffectBase
{
	public TongShenQianShouFa()
	{
	}

	public TongShenQianShouFa(CombatSkillKey skillKey)
		: base(skillKey, 2205, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(215, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(217, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (!((base.IsDirect ? defender : attacker) != base.CombatChar || hit) && base.EffectCount > 0 && !base.CombatChar.NextAttackNoPrepare)
		{
			base.CombatChar.NextAttackNoPrepare = true;
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 215 || fieldId == 217) ? true : false)
		{
			return false;
		}
		return dataValue;
	}
}
