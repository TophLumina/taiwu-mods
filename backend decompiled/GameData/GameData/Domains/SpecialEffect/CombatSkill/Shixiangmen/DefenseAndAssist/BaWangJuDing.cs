using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;

public class BaWangJuDing : AssistSkillBase
{
	private int _changeDamage;

	public BaWangJuDing()
	{
	}

	public BaWangJuDing(CombatSkillKey skillKey)
		: base(skillKey, 6603)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 69 : 102), -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	private void OnCombatBegin(DataContext context)
	{
		_changeDamage = ((base.CombatChar.GetUsingWeaponIndex() < 3) ? (base.CombatChar.GetWeaponData().Item.GetWeight() / 100) : 0);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId)
		{
			_changeDamage = ((base.CombatChar.GetUsingWeaponIndex() < 3) ? (newWeapon.Item.GetWeight() / 100) : 0);
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		return base.IsDirect ? _changeDamage : (-_changeDamage);
	}
}
