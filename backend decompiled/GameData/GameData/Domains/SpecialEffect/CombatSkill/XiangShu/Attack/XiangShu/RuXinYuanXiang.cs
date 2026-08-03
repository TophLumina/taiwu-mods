using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class RuXinYuanXiang : CombatSkillEffectBase
{
	private const short AddGoneMadInjury = 200;

	public RuXinYuanXiang()
	{
	}

	public RuXinYuanXiang(CombatSkillKey skillKey)
		: base(skillKey, 17090, -1)
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
		if (SkillKey.IsMatch(charId, skillId))
		{
			AddMaxEffectCount();
		}
		else if (isAlly != base.CombatChar.IsAlly && base.EffectCount > 0 && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			DomainManager.Combat.AddGoneMadInjury(context, DomainManager.Combat.GetElement_CombatCharacterDict(charId), skillId, 200);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}
}
