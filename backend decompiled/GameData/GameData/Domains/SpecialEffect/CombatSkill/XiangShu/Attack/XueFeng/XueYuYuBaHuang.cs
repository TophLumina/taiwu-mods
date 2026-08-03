using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;

public class XueYuYuBaHuang : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 10;

	private const sbyte TransferInjuryCount = 8;

	private int _addPower;

	public XueYuYuBaHuang()
	{
	}

	public XueYuYuBaHuang(CombatSkillKey skillKey)
		: base(skillKey, 17075, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 10 * base.CombatChar.GetOldInjuries().GetSum();
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
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
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			List<(sbyte, bool)> injuryRandomPool = ObjectPool<List<(sbyte, bool)>>.Instance.Get();
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			Injuries oldInjuries = base.CombatChar.GetOldInjuries();
			injuryRandomPool.Clear();
			for (sbyte part = 0; part < 7; part++)
			{
				(sbyte, sbyte) injury = oldInjuries.Get(part);
				for (int i = 0; i < injury.Item1; i++)
				{
					injuryRandomPool.Add((part, false));
				}
				for (int j = 0; j < injury.Item2; j++)
				{
					injuryRandomPool.Add((part, true));
				}
			}
			while (injuryRandomPool.Count > 8)
			{
				injuryRandomPool.RemoveAt(context.Random.Next(injuryRandomPool.Count));
			}
			if (injuryRandomPool.Count > 0)
			{
				int[] enemyCharIds = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
				List<CombatCharacter> enemyCharList = new List<CombatCharacter>();
				CombatCharacter enemyCurrChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				for (int k = 0; k < enemyCharIds.Length; k++)
				{
					if (enemyCharIds[k] >= 0)
					{
						enemyCharList.Add(DomainManager.Combat.GetElement_CombatCharacterDict(enemyCharIds[k]));
					}
				}
				for (int l = 0; l < injuryRandomPool.Count; l++)
				{
					(sbyte, bool) injuryInfo = injuryRandomPool[l];
					int charIndex = context.Random.Next(enemyCharList.Count);
					CombatCharacter enemyChar = enemyCharList[charIndex];
					Injuries enemyInjuries = enemyChar.GetInjuries();
					bodyPartRandomPool.Clear();
					for (sbyte part2 = 0; part2 < 7; part2++)
					{
						if (enemyInjuries.Get(part2, injuryInfo.Item2) < 6)
						{
							bodyPartRandomPool.Add(part2);
						}
					}
					if (bodyPartRandomPool.Count > 0)
					{
						sbyte bodyPart = bodyPartRandomPool[context.Random.Next(bodyPartRandomPool.Count)];
						base.CombatChar.RemoveInjury(context, injuryInfo.Item1, injuryInfo.Item2, 1, updateDefeatMark: false, removeOldInjury: true, byTransfer: true);
						enemyChar.AddInjury(context, bodyPart, injuryInfo.Item2, 1, updateDefeatMark: true, changeToOld: true);
						continue;
					}
					enemyCharList.RemoveAt(charIndex);
					if (enemyCharList.Count > 0)
					{
						l--;
						continue;
					}
					break;
				}
				DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
				DomainManager.Combat.AddToCheckFallenSet(enemyCurrChar.GetId());
				if (enemyCurrChar != base.CurrEnemyChar)
				{
					DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
				}
				ShowSpecialEffectTips(1);
			}
			ObjectPool<List<(sbyte, bool)>>.Instance.Return(injuryRandomPool);
			ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		}
		RemoveSelf(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
