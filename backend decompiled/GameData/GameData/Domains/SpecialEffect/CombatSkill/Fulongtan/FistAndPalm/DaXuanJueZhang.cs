using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class DaXuanJueZhang : CombatSkillEffectBase
{
	private const sbyte TransferPowerPercent = 10;

	public DaXuanJueZhang()
	{
	}

	public DaXuanJueZhang(CombatSkillKey skillKey)
		: base(skillKey, 14104, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
		List<short> selfSkillList = ObjectPool<List<short>>.Instance.Get();
		List<short> enemySkillList = ObjectPool<List<short>>.Instance.Get();
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		selfSkillList.Clear();
		selfSkillList.AddRange(base.CombatChar.GetCombatSkillList((sbyte)(base.IsDirect ? 3 : 2)));
		selfSkillList.RemoveAll((short id) => id < 0);
		enemySkillList.Clear();
		enemySkillList.AddRange(enemyChar.GetCombatSkillList((sbyte)(base.IsDirect ? 3 : 2)));
		enemySkillList.RemoveAll((short id) => id < 0);
		DomainManager.Combat.RemoveSkillPowerAddInCombat(context, SkillKey, effectKey);
		if (selfSkillList.Count > 0 || enemySkillList.Count > 0)
		{
			int addPower = 0;
			List<CombatSkillKey> skillKeyRandomPool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
			skillKeyRandomPool.Clear();
			if (selfSkillList.Count > 0)
			{
				short maxPower = 0;
				for (int i = 0; i < selfSkillList.Count; i++)
				{
					short skillId = selfSkillList[i];
					CombatSkillKey skillKey = new CombatSkillKey(base.CharacterId, skillId);
					short power = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey).GetPower();
					if (power > maxPower)
					{
						skillKeyRandomPool.Clear();
						skillKeyRandomPool.Add(skillKey);
						maxPower = power;
					}
					else if (power == maxPower)
					{
						skillKeyRandomPool.Add(skillKey);
					}
				}
				int transferPower = maxPower * 10 / 100;
				if (transferPower > 0)
				{
					DomainManager.Combat.ReduceSkillPowerInCombat(context, skillKeyRandomPool[context.Random.Next(0, skillKeyRandomPool.Count)], effectKey, -transferPower);
					addPower += transferPower;
				}
			}
			skillKeyRandomPool.Clear();
			if (enemySkillList.Count > 0)
			{
				short maxPower = 0;
				for (int i2 = 0; i2 < enemySkillList.Count; i2++)
				{
					short skillId2 = enemySkillList[i2];
					CombatSkillKey skillKey2 = new CombatSkillKey(enemyChar.GetId(), skillId2);
					short power2 = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey2).GetPower();
					if (power2 > maxPower)
					{
						skillKeyRandomPool.Clear();
						skillKeyRandomPool.Add(skillKey2);
						maxPower = power2;
					}
					else if (power2 == maxPower)
					{
						skillKeyRandomPool.Add(skillKey2);
					}
				}
				int transferPower2 = maxPower * 10 / 100;
				if (transferPower2 > 0)
				{
					DomainManager.Combat.ReduceSkillPowerInCombat(context, skillKeyRandomPool[context.Random.Next(0, skillKeyRandomPool.Count)], effectKey, -transferPower2);
					addPower += transferPower2;
				}
			}
			ObjectPool<List<CombatSkillKey>>.Instance.Return(skillKeyRandomPool);
			if (addPower > 0)
			{
				DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, effectKey, addPower);
				ShowSpecialEffectTips(0);
			}
		}
		ObjectPool<List<short>>.Instance.Return(selfSkillList);
		ObjectPool<List<short>>.Instance.Return(enemySkillList);
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
			RemoveSelf(context);
		}
	}
}
