using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class TianDiXiao : CombatSkillEffectBase
{
	private sbyte ChangePower = 40;

	public TianDiXiao()
	{
	}

	public TianDiXiao(CombatSkillKey skillKey)
		: base(skillKey, 3306, -1)
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
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true));
			Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = (base.IsDirect ? DomainManager.Combat.GetAllSkillPowerAddInCombat() : DomainManager.Combat.GetAllSkillPowerReduceInCombat());
			SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
			List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
			bool affected = false;
			sbyte equipType;
			for (equipType = 1; equipType < 5; equipType++)
			{
				skillRandomPool.Clear();
				if (affectChar.BossConfig == null)
				{
					skillRandomPool.AddRange(affectChar.GetCombatSkillList(equipType));
				}
				else
				{
					skillRandomPool.AddRange(affectChar.GetCharacter().GetLearnedCombatSkills().FindAll((short id) => Config.CombatSkill.Instance[id].EquipType == equipType));
				}
				for (int i = skillRandomPool.Count - 1; i >= 0; i--)
				{
					short affectSkill = skillRandomPool[i];
					if (affectSkill < 0)
					{
						skillRandomPool.RemoveAt(i);
					}
					else
					{
						CombatSkillKey skillKey = new CombatSkillKey(affectChar.GetId(), affectSkill);
						if (powerDict.ContainsKey(skillKey) && powerDict[skillKey].EffectDict != null && powerDict[skillKey].EffectDict.ContainsKey(effectKey))
						{
							skillRandomPool.RemoveAt(i);
						}
					}
				}
				if (skillRandomPool.Count > 0)
				{
					if (base.IsDirect)
					{
						DomainManager.Combat.AddSkillPowerInCombat(context, new CombatSkillKey(affectChar.GetId(), skillRandomPool[context.Random.Next(0, skillRandomPool.Count)]), effectKey, ChangePower);
					}
					else
					{
						DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(affectChar.GetId(), skillRandomPool[context.Random.Next(0, skillRandomPool.Count)]), effectKey, -ChangePower);
					}
					affected = true;
				}
			}
			if (affected)
			{
				ShowSpecialEffectTips(0);
			}
			ObjectPool<List<short>>.Instance.Return(skillRandomPool);
		}
		RemoveSelf(context);
	}
}
