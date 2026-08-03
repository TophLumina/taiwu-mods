using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Combat.Ai.Memory;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class DingHuiShenZhen : CombatSkillEffectBase
{
	private const sbyte ChangePower = 40;

	public DingHuiShenZhen()
	{
	}

	public DingHuiShenZhen(CombatSkillKey skillKey)
		: base(skillKey, 2405, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		AiMemory aiMemory = base.CurrEnemyChar.AiController.Memory;
		if (PowerMatchAffectRequire(power) && aiMemory != null)
		{
			SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
			SkillPowerChangeCollection value;
			if (base.IsDirect)
			{
				foreach (short combatSkillId in aiMemory.EnemyRecordDict[base.CharacterId].SkillRecord.Keys)
				{
					CombatSkillKey skillKey = new CombatSkillKey(base.CharacterId, combatSkillId);
					if (DomainManager.Combat.CombatSkillDataExist(skillKey) && (!DomainManager.Combat.TryGetElement_SkillPowerAddInCombat(skillKey, out value) || !DomainManager.Combat.GetElement_SkillPowerAddInCombat(skillKey).EffectDict.ContainsKey(effectKey)))
					{
						DomainManager.Combat.AddSkillPowerInCombat(context, skillKey, effectKey, 40);
					}
				}
			}
			else
			{
				foreach (short combatSkillId2 in aiMemory.SelfRecord.SkillRecord.Keys)
				{
					CombatSkillKey skillKey2 = new CombatSkillKey(base.CurrEnemyChar.GetId(), combatSkillId2);
					if (DomainManager.Combat.CombatSkillDataExist(skillKey2) && (!DomainManager.Combat.TryGetElement_SkillPowerReduceInCombat(skillKey2, out value) || !DomainManager.Combat.GetElement_SkillPowerReduceInCombat(skillKey2).EffectDict.ContainsKey(effectKey)))
					{
						DomainManager.Combat.ReduceSkillPowerInCombat(context, skillKey2, effectKey, -40);
					}
				}
			}
			base.CurrEnemyChar.AiController.ClearMemories();
			ShowSpecialEffectTips(0);
		}
		RemoveSelf(context);
	}
}
