using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class AutoMoveAndCast : CombatSkillEffectBase
{
	private const sbyte MoveDistance = 20;

	private const sbyte PrepareProgressPercent = 50;

	private short _autoCastSkillId;

	protected abstract bool MoveForward { get; }

	protected abstract short RequireWeaponType { get; }

	protected abstract sbyte RequireSkillType { get; }

	private static CombatSkillItem GetConfig(short skillId)
	{
		return Config.CombatSkill.Instance[skillId];
	}

	private bool IsAffectPower(int power)
	{
		return base.IsDirect ? (!PowerMatchAffectRequire(power)) : PowerMatchAffectRequire(power);
	}

	private bool IsAffectSkill(short skillId)
	{
		return base.IsDirect ? (skillId == base.SkillTemplateId) : (base.EffectCount > 0 && skillId != base.SkillTemplateId && GetConfig(skillId).Type == RequireSkillType && GetConfig(skillId).Grade < base.SkillConfig.Grade);
	}

	private bool IsRequireWeapon(CombatWeaponData weaponData)
	{
		return weaponData.Template.ItemSubType == RequireWeaponType;
	}

	protected AutoMoveAndCast()
	{
	}

	protected AutoMoveAndCast(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_autoCastSkillId = -1;
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (!base.IsDirect)
		{
			AddMaxEffectCount(autoRemoveOnNoCount: false);
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (!base.IsDirect && charId == base.CharacterId && !IsRequireWeapon(oldWeapon) && IsRequireWeapon(newWeapon))
		{
			AddEffectCount();
			ShowSpecialEffectTips(1);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == _autoCastSkillId)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _autoCastSkillId)
		{
			_autoCastSkillId = -1;
		}
		if (charId != base.CharacterId || !IsAffectPower(power) || !IsAffectSkill(skillId) || interrupted)
		{
			return;
		}
		DomainManager.Combat.ChangeDistance(context, base.CombatChar, MoveForward ? (-20) : 20);
		if (!DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			return;
		}
		_autoCastSkillId = (base.IsDirect ? DomainManager.Combat.GetRandomAttackSkill(base.CombatChar, RequireSkillType, Config.CombatSkill.Instance[base.SkillTemplateId].Grade, context.Random, descSearch: true, -1) : base.SkillTemplateId);
		if (_autoCastSkillId >= 0)
		{
			DomainManager.Combat.CastSkillFree(context, base.CombatChar, _autoCastSkillId, ECombatCastFreePriority.AutoMoveAndCast);
			ShowSpecialEffectTips(0);
			if (!base.IsDirect)
			{
				ReduceEffectCount();
			}
		}
	}
}
