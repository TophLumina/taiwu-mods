using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class BaiShuiChangShengFa : AssistSkillBase
{
	private const int ChangeNeiliAllocationPerMark = 3;

	private const int ChangeDisorderOfQiPerMark = -100;

	public BaiShuiChangShengFa()
	{
	}

	public BaiShuiChangShengFa(CombatSkillKey skillKey)
		: base(skillKey, 10706)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PoisonAffected(OnPoisonAffected);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PoisonAffected(OnPoisonAffected);
	}

	private void OnPoisonAffected(DataContext context, int charId, sbyte poisonType)
	{
		if (!base.CanAffect)
		{
			return;
		}
		CombatCharacter poisonChar = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly) : base.CombatChar);
		if (charId == poisonChar.GetId())
		{
			byte markCount = poisonChar.GetDefeatMarkCollection().PoisonMarkList[poisonType];
			if (markCount > 0)
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, markCount * -100);
				base.CombatChar.ChangeNeiliAllocation(context, 3, markCount * 3);
				ShowSpecialEffectTips(0);
				ShowSpecialEffectTips(1);
				ShowEffectTips(context);
			}
		}
	}
}
