using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;

public class BuDongMingWangChu : PestleEffectBase
{
	private const int ChangeAttackRange = 15;

	private const sbyte ChangeMoveSpeed = 80;

	private const sbyte ChangeDamage = 40;

	public BuDongMingWangChu(int charId, SkillEffectKey effectKey)
		: base(charId, effectKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 9, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		base.OnDisable(context);
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 9);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 145) <= 1u)
		{
			return 15;
		}
		if (dataKey.FieldId == 9)
		{
			return base.IsDirect ? (-80) : 80;
		}
		if (dataKey.FieldId == 102)
		{
			return base.IsDirect ? (-40) : 40;
		}
		return 0;
	}
}
