using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class XiaoYuYangShenQuan : CombatSkillEffectBase
{
	private const sbyte CostNeiliAllocation = 10;

	private const int MaxChangeCount = 2;

	private const sbyte RequireEquipType = 1;

	private static readonly CValuePercent ChangeEffectCountPercent = 50;

	public XiaoYuYangShenQuan()
	{
	}

	public XiaoYuYangShenQuan(CombatSkillKey skillKey)
		: base(skillKey, 14105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private unsafe void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index < 3)
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
		if (CombatCharPowerMatchAffectRequire() && neiliAllocation.Items[0] >= 10)
		{
			CombatCharacter target = (base.IsDirect ? base.CombatChar : base.EnemyChar);
			CValuePercent percent = (base.IsDirect ? ChangeEffectCountPercent : (-ChangeEffectCountPercent));
			if (DomainManager.Combat.ChangeSkillEffectRandom(context, target, percent, 2, 1))
			{
				base.CombatChar.ChangeNeiliAllocation(context, 0, -10);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
