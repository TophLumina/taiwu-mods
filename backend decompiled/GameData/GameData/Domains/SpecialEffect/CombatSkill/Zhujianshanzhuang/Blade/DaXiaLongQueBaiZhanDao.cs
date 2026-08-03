using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class DaXiaLongQueBaiZhanDao : BladeUnlockEffectBase
{
	private const int MaxChangeDistance = 60;

	private const int ExtraFlawDistance = 5;

	private int AddBouncePower => base.IsDirectOrReverseEffectDoubling ? 80 : 40;

	private int AddFightBackPower => base.IsDirectOrReverseEffectDoubling ? 200 : 100;

	private bool CastingSelf => base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId || base.CombatChar.GetPerformingSkillId() == base.SkillTemplateId;

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 4;
		}
	}

	public DaXiaLongQueBaiZhanDao()
	{
	}

	public DaXiaLongQueBaiZhanDao(CombatSkillKey skillKey)
		: base(skillKey, 9202)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(111, EDataModifyType.Add, -1);
		CreateAffectedData(177, EDataModifyType.Custom, -1);
		CreateAffectedData(112, EDataModifyType.Add, -1);
		CreateAffectedData(193, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (SkillKey.IsMatch(attacker.GetId(), skillId) && base.IsReverseOrUsingDirectWeapon)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		short center = base.CombatChar.GetAttackRange().Average;
		short current = DomainManager.Combat.GetCurrentDistance();
		int addDistance = Math.Min(Math.Abs(center - current), 60);
		if (addDistance > 0)
		{
			DomainManager.Combat.ChangeDistance(context, base.EnemyChar, addDistance * ((current < center) ? 1 : (-1)), isForced: true);
			ShowSpecialEffectTips(base.IsDirect, 2, 1);
		}
		int flawCount = 1 + addDistance / 5;
		if (1 == 0)
		{
		}
		sbyte b = (sbyte)((addDistance > 10) ? ((addDistance < 20) ? 1 : 2) : 0);
		if (1 == 0)
		{
		}
		sbyte flawLevel = b;
		DomainManager.Combat.AddFlaw(context, base.EnemyChar, flawLevel, SkillKey, -1, flawCount);
		ShowSpecialEffectTips(base.IsDirect, 3, 2);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !CastingSelf || !base.IsReverseOrUsingDirectWeapon)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			111 => AddBouncePower, 
			112 => AddFightBackPower, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !CastingSelf || !base.IsReverseOrUsingDirectWeapon)
		{
			return dataValue;
		}
		if (dataKey.FieldId != 177)
		{
			return dataValue;
		}
		OuterAndInnerInts skillRange = DomainManager.Combat.GetSkillAttackRange(base.CombatChar, base.SkillTemplateId);
		dataValue.Outer = Math.Min(dataValue.Outer, skillRange.Outer);
		dataValue.Inner = Math.Max(dataValue.Inner, skillRange.Inner);
		return dataValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !CastingSelf || !base.IsReverseOrUsingDirectWeapon)
		{
			return dataValue;
		}
		if (dataKey.FieldId != 193)
		{
			return dataValue;
		}
		return true;
	}
}
