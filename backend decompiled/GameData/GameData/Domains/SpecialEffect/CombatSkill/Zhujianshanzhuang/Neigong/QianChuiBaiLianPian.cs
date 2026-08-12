using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class QianChuiBaiLianPian : CombatSkillEffectBase
{
	private sbyte DamageChangeUnit = 4;

	private int _damageChangePercent;

	public QianChuiBaiLianPian()
	{
	}

	public QianChuiBaiLianPian(CombatSkillKey skillKey)
		: base(skillKey, 9003, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 102 : 69), -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateDamageChangePercent();
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		UpdateDamageChangePercent();
	}

	private void UpdateDamageChangePercent()
	{
		Weapon currWeapon = DomainManager.Item.GetElement_Weapons(DomainManager.Combat.GetUsingWeaponKey(base.CombatChar).Id);
		int refineCount = 0;
		if (ModificationStateHelper.IsActive(currWeapon.GetModificationState(), 2))
		{
			refineCount = DomainManager.Item.GetRefinedEffects(currWeapon.GetItemKey()).GetTotalRefiningCount();
		}
		_damageChangePercent = DamageChangeUnit * refineCount;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			return -_damageChangePercent;
		}
		if (dataKey.FieldId == 69)
		{
			return _damageChangePercent;
		}
		return 0;
	}
}
