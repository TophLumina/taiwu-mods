using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class XinMiWuJue : CombatSkillEffectBase
{
	private const short AddGoneMadInjury = 200;

	public XinMiWuJue()
	{
	}

	public XinMiWuJue(CombatSkillKey skillKey)
		: base(skillKey, 17093, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
		else if (isAlly != base.CombatChar.IsAlly && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			DomainManager.Combat.AddGoneMadInjury(context, DomainManager.Combat.GetElement_CombatCharacterDict(charId), skillId, 200);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (isAlly != base.CombatChar.IsAlly && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			if (power < 100 && !interrupted)
			{
				DomainManager.Combat.SilenceSkill(context, DomainManager.Combat.GetElement_CombatCharacterDict(charId), skillId, -1, -1);
				ShowSpecialEffectTips(1);
			}
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}
