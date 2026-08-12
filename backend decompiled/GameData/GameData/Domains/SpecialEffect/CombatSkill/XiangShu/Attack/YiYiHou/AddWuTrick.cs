using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class AddWuTrick : CombatSkillEffectBase
{
	protected sbyte AddTrickCount;

	protected AddWuTrick()
	{
	}

	protected AddWuTrick(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: true);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: false);
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (DomainManager.Character.HasTwoWayRelation(enemyChar.GetId(), 16384) || DomainManager.Character.HasTwoWayRelation(enemyChar.GetId(), 32768))
		{
			DomainManager.Combat.AddTrick(context, enemyChar, 20, AddTrickCount, addedByAlly: false);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				DomainManager.Combat.AddTrick(context, enemyChar, 20, AddTrickCount, addedByAlly: false);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
