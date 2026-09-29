using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class ChangePowerByEquipType : CombatSkillEffectBase
{
	private const sbyte ChangePowerUnitDirect = 2;

	private const sbyte ChangePowerUnitReverse = 3;

	protected sbyte AffectEquipType;

	protected ChangePowerByEquipType()
	{
	}

	protected ChangePowerByEquipType(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
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
		sbyte unit = (sbyte)(base.IsDirect ? 2 : 3);
		int powerChangeValue = power / 10 * (base.IsDirect ? unit : (-unit));
		if (powerChangeValue != 0)
		{
			SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
			CombatCharacter combatChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true));
			bool anyChanged = false;
			List<short> affectCombatSkills = ObjectPool<List<short>>.Instance.Get();
			affectCombatSkills.Clear();
			if (combatChar.BossConfig == null)
			{
				affectCombatSkills.AddRange(combatChar.GetCombatSkillList(AffectEquipType));
			}
			else
			{
				affectCombatSkills.AddRange(combatChar.GetCharacter().GetLearnedCombatSkills().FindAll((short id) => Config.CombatSkill.Instance[id].EquipType == AffectEquipType));
			}
			foreach (short combatSkillId in affectCombatSkills)
			{
				if (combatSkillId < 0)
				{
					continue;
				}
				CombatSkillKey skillKey = new CombatSkillKey(combatChar.GetId(), combatSkillId);
				SkillPowerChangeCollection powerChangeCollection;
				if (base.IsDirect)
				{
					DomainManager.Combat.TryGetElement_SkillPowerAddInCombat(skillKey, out powerChangeCollection);
				}
				else
				{
					DomainManager.Combat.TryGetElement_SkillPowerReduceInCombat(skillKey, out powerChangeCollection);
				}
				int currChangeValue = ((powerChangeCollection != null && powerChangeCollection.EffectDict.ContainsKey(effectKey)) ? powerChangeCollection.EffectDict[effectKey] : 0);
				int diff = powerChangeValue - currChangeValue;
				if (base.IsDirect ? (diff > 0) : (diff < 0))
				{
					if (base.IsDirect)
					{
						DomainManager.Combat.AddSkillPowerInCombat(context, skillKey, effectKey, diff);
					}
					else
					{
						DomainManager.Combat.ReduceSkillPowerInCombat(context, skillKey, effectKey, diff);
					}
					anyChanged = true;
				}
			}
			if (anyChanged)
			{
				ShowSpecialEffectTips(0);
			}
			ObjectPool<List<short>>.Instance.Return(affectCombatSkills);
		}
		RemoveSelf(context);
	}
}
