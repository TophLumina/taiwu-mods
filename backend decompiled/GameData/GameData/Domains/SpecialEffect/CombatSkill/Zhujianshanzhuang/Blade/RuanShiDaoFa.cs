using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class RuanShiDaoFa : BladeUnlockEffectBase
{
	private int StealTrickCount => (!base.IsDirectOrReverseEffectDoubling) ? 1 : 2;

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 6;
			yield return 7;
		}
	}

	public RuanShiDaoFa()
	{
	}

	public RuanShiDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 9201)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power) && base.IsReverseOrUsingDirectWeapon)
		{
			DoStealTrick(context);
		}
	}

	private void DoStealTrick(DataContext context)
	{
		List<sbyte> allUsableTricks = ObjectPool<List<sbyte>>.Instance.Get();
		foreach (sbyte trick in base.EnemyChar.GetTricks().Tricks.Values)
		{
			if (base.CombatChar.IsTrickUsable(trick))
			{
				allUsableTricks.Add(trick);
			}
		}
		if (allUsableTricks.Count > 0)
		{
			List<sbyte> stealTricks = ObjectPool<List<sbyte>>.Instance.Get();
			stealTricks.AddRange(RandomUtils.GetRandomUnrepeated(context.Random, StealTrickCount, allUsableTricks));
			DomainManager.Combat.StealTrick(context, base.CombatChar, base.EnemyChar, stealTricks);
			ObjectPool<List<sbyte>>.Instance.Return(stealTricks);
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
		ObjectPool<List<sbyte>>.Instance.Return(allUsableTricks);
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		CombatWeaponData weapon = base.CombatChar.GetWeaponData(weaponIndex);
		sbyte[] tricks = weapon.GetWeaponTricks();
		DomainManager.Combat.AddTrick(context, base.CombatChar, tricks);
		ShowSpecialEffectTips(base.IsDirect, 2, 1);
	}
}
