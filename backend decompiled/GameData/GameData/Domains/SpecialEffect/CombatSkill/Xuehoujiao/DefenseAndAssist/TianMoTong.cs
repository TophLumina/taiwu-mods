using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class TianMoTong : DefenseSkillBase
{
	private const sbyte ReduceDamagePercent = -60;

	private const int AddPoison = 120;

	private const int AddPoisonLevel = 2;

	private sbyte AddPoisonType => (sbyte)(base.IsDirect ? 3 : 2);

	public TianMoTong()
	{
	}

	public TianMoTong(CombatSkillKey skillKey)
		: base(skillKey, 15707)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
		base.OnDisable(context);
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (attackerId == base.CharacterId && base.CanAffect)
		{
			OuterAndInnerInts bouncePower = base.CombatChar.GetBouncePower(50);
			DomainManager.Combat.AddPoison(context, base.CombatChar, base.CurrEnemyChar, AddPoisonType, 2, 120 * (base.IsDirect ? bouncePower.Outer : bouncePower.Inner) / 100, base.SkillTemplateId);
			DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
			ShowSpecialEffectTips(1);
			if (base.CurrEnemyChar.WorsenAllInjury(context, !base.IsDirect, WorsenConstants.LowPercent))
			{
				ShowSpecialEffectTips(2);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			ShowSpecialEffectTips(0);
			return -60;
		}
		return 0;
	}
}
