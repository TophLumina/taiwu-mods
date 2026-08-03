using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class ShaoLinFengMoGun : CombatSkillEffectBase
{
	private const sbyte AddPenetrateUnit = 10;

	private const sbyte AddRangeUnit = 5;

	private const int ReduceAttackPrepareFramePercent = -50;

	private const sbyte MaxAffectCount = 6;

	private int _hitCount = 0;

	public ShaoLinFengMoGun()
	{
	}

	public ShaoLinFengMoGun(CombatSkillKey skillKey)
		: base(skillKey, 1305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.CombatChar.CanNormalAttackInPrepareSkill = true;
		CreateAffectedData((ushort)(base.IsDirect ? 44 : 45), EDataModifyType.AddPercent, -1);
		CreateAffectedData(145, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(146, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(282, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.CombatChar.CanNormalAttackInPrepareSkill = false;
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && attacker == base.CombatChar && _hitCount < 6)
		{
			_hitCount++;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 44 : 45));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			ShowSpecialEffectTips(1);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId)
		{
			DomainManager.Combat.InterruptSkill(context, base.CombatChar, -1);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId)
		{
			ShowSpecialEffectTips(0);
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
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 44) <= 1u)
		{
			return 10 * _hitCount;
		}
		if (dataKey.FieldId == 282)
		{
			return -50;
		}
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 145) <= 1u)
		{
			return 5 * _hitCount;
		}
		return 0;
	}
}
