using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class GuiJiangDaFa : DefenseSkillBase
{
	private const sbyte RequireWuOrMindUnit = 2;

	private const sbyte FlawOrAcupointLevel = 3;

	private const int ChangeDirectDamagePercent = -60;

	public GuiJiangDaFa()
	{
	}

	public GuiJiangDaFa(CombatSkillKey skillKey)
		: base(skillKey, 12707)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (AffectDatas == null)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType> { 
			{
				new AffectedDataKey(base.CharacterId, 102, -1),
				EDataModifyType.AddPercent
			} };
		}
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!hit && pursueIndex <= 0 && defender == base.CombatChar && base.CanAffect)
		{
			DoEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!hit && index <= 2 && context.Defender == base.CombatChar && base.CanAffect)
		{
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		if (base.IsDirect)
		{
			byte effectCount = enemyChar.GetTrickCount(20);
			if (effectCount >= 2)
			{
				int count = effectCount / 2;
				for (int i = 0; i < count; i++)
				{
					DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, 3, new CombatSkillKey(base.CharacterId, base.SkillTemplateId), -1);
				}
				ShowSpecialEffectTips(1);
			}
			else if (effectCount == 0)
			{
				DomainManager.Combat.AddTrick(context, enemyChar, 20, 2, addedByAlly: false);
				ShowSpecialEffectTips(2);
			}
			return;
		}
		int effectCount2 = (enemyChar.GetMindMarkTime()?.MarkList?.Count).GetValueOrDefault();
		if (effectCount2 >= 2)
		{
			int count2 = effectCount2 / 2;
			for (int j = 0; j < count2; j++)
			{
				DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 3, new CombatSkillKey(base.CharacterId, base.SkillTemplateId), -1);
			}
			ShowSpecialEffectTips(1);
		}
		else if (effectCount2 == 0)
		{
			AddPowerDamageMind(context, base.CurrEnemyChar);
			ShowSpecialEffectTips(2);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam2 == 0)
		{
			ShowSpecialEffectTips(0);
			return -60;
		}
		return 0;
	}
}
