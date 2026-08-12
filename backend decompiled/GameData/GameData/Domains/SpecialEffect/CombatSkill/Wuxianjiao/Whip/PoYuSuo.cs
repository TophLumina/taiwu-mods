using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;

public class PoYuSuo : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 5;

	private bool _castingWithMobility;

	private int _addPower;

	public PoYuSuo()
	{
	}

	public PoYuSuo(CombatSkillKey skillKey)
		: base(skillKey, 12405, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_castingWithMobility = false;
		_addPower = 0;
		Events.RegisterHandler_CastSkillUseMobilityAsBreathOrStance(OnCastSkillUseMobilityAsBreathOrStance);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillUseMobilityAsBreathOrStance(OnCastSkillUseMobilityAsBreathOrStance);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDataAdded(DataContext context)
	{
		UpdateAffectData(context);
	}

	protected override void OnDirectionChanged(DataContext context)
	{
		UpdateAffectData(context);
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
	}

	private void UpdateAffectData(DataContext context)
	{
		ClearAffectedData(context);
		AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, base.SkillTemplateId);
		AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 230 : 229), EDataModifyType.Custom, -1);
	}

	private void OnCastSkillUseMobilityAsBreathOrStance(DataContext context, int charId, short skillId, bool asBreath)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && asBreath != base.IsDirect)
		{
			_castingWithMobility = true;
			base.CombatChar.CanNormalAttackInPrepareSkill = true;
			DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: true);
			DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: false);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_castingWithMobility && hit && attacker == base.CombatChar)
		{
			_addPower += 5;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (_castingWithMobility && charId == base.CharacterId)
		{
			DomainManager.Combat.InterruptSkill(context, base.CombatChar, -1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_castingWithMobility && charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (_addPower > 0)
			{
				_addPower = 0;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			}
			_castingWithMobility = false;
			base.CombatChar.CanNormalAttackInPrepareSkill = false;
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

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 230 || dataKey.FieldId == 229)
		{
			return true;
		}
		return dataValue;
	}
}
