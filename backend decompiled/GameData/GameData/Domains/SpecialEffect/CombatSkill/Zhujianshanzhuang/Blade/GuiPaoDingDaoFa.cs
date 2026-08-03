using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class GuiPaoDingDaoFa : BladeUnlockEffectBase
{
	private const int MaxTransferCount = 5;

	private int AddDamagePercentPerMark => base.IsDirectOrReverseEffectDoubling ? 6 : 3;

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 14;
			yield return 15;
		}
	}

	public GuiPaoDingDaoFa()
	{
	}

	public GuiPaoDingDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 9204)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
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

	protected override bool CanDoAffect()
	{
		DefeatMarkCollection marks = base.CombatChar.GetDefeatMarkCollection();
		return marks.MindMarkList.Count > 0 || marks.GetTotalFlawCount() > 0 || marks.GetTotalAcupointCount() > 0;
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		DefeatMarkCollection marks = base.CombatChar.GetDefeatMarkCollection();
		List<int> weights = ObjectPool<List<int>>.Instance.Get();
		weights.Add(marks.GetTotalFlawCount());
		weights.Add(marks.GetTotalAcupointCount());
		weights.Add(marks.MindMarkList.Count);
		if (weights.Sum() > 0)
		{
			ShowSpecialEffectTips(base.IsDirect, 2, 1);
		}
		for (int i = 0; i < 5; i++)
		{
			if (weights.Sum() == 0)
			{
				break;
			}
			int index = RandomUtils.GetRandomIndex(weights, context.Random);
			if (index == 0)
			{
				DomainManager.Combat.TransferRandomFlaw(context, base.CombatChar, base.EnemyChar);
			}
			if (index == 1)
			{
				DomainManager.Combat.TransferRandomAcupoint(context, base.CombatChar, base.EnemyChar);
			}
			if (index == 2)
			{
				base.CombatChar.TransferRandomMindMark(context, base.EnemyChar);
			}
			weights[index]--;
		}
		ObjectPool<List<int>>.Instance.Return(weights);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey || !base.IsReverseOrUsingDirectWeapon)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return base.CombatChar.GetDefeatMarkCollection().GetTotalCount() * AddDamagePercentPerMark;
		}
		return 0;
	}
}
