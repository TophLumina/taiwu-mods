using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class StrengthenOnSwitchWeapon : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 50;

	private const sbyte AddPower = 20;

	protected short RequireWeaponSubType;

	private int _addPower;

	protected StrengthenOnSwitchWeapon()
	{
	}

	protected StrengthenOnSwitchWeapon(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		if (base.IsDirect)
		{
			Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
			return;
		}
		_addPower = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		}
		else
		{
			Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId != base.CharacterId)
		{
			return;
		}
		short oldType = oldWeapon.Template.ItemSubType;
		short newType = newWeapon.Template.ItemSubType;
		if (newType != RequireWeaponSubType || oldType == RequireWeaponSubType)
		{
			return;
		}
		if (base.IsDirect)
		{
			if (DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
		}
		else if (_addPower == 0)
		{
			_addPower = 20;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _addPower != 0)
		{
			_addPower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
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
