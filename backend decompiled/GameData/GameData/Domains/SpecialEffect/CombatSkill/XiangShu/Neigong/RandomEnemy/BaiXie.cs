using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class BaiXie : MinionBase
{
	private const sbyte ChangeInjury = 2;

	public BaiXie()
	{
	}

	public BaiXie(CombatSkillKey skillKey)
		: base(skillKey, 16004)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (base.CombatChar.IsAlly == isAlly || !base.IsCurrent || !MinionBase.CanAffect)
		{
			return;
		}
		sbyte direction = DomainManager.CombatSkill.GetElement_CombatSkills((charId: charId, skillId: skillId)).GetDirection();
		if (direction != -1)
		{
			bool worsen = direction == 0;
			CombatCharacter affectChar = (worsen ? DomainManager.Combat.GetElement_CombatCharacterDict(charId) : base.CombatChar);
			if (worsen ? affectChar.WorsenRandomInjury(context, WorsenConstants.SpecialPercentBaiXie) : affectChar.RemoveRandomInjury(context, 2))
			{
				ShowSpecialEffectTips(worsen, 0, 1);
			}
		}
	}
}
