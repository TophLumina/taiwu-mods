using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class MingLongZhi : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 20;

	private const int MaxCostTrick = 3;

	private const sbyte AddDamagePercentUnit = 20;

	private int _addPower;

	private int _addDamagePercent;

	public MingLongZhi()
	{
	}

	public MingLongZhi(CombatSkillKey skillKey)
		: base(skillKey, 13306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter trickChar = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		_addPower = 20 * trickChar.GetContinueTricksAtStart(19);
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId || skillId != base.SkillTemplateId || !DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			return;
		}
		CombatCharacter trickChar = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		int maxCostTrick = Math.Min(3, (int)trickChar.GetTrickCount(19));
		if (maxCostTrick <= 0)
		{
			return;
		}
		List<int> preferIndexes = ObjectPool<List<int>>.Instance.Get();
		List<int> alterIndexes = ObjectPool<List<int>>.Instance.Get();
		preferIndexes.Clear();
		alterIndexes.Clear();
		TrickCollection tricks = trickChar.GetTricks();
		foreach (var (index, trick) in tricks.Tricks)
		{
			if (trick != 19)
			{
				if (trickChar.IsTrickUsable(trick))
				{
					(base.IsDirect ? alterIndexes : preferIndexes).Add(index);
				}
				else
				{
					(base.IsDirect ? preferIndexes : alterIndexes).Add(index);
				}
			}
		}
		int trulyCostTrick = Math.Min(maxCostTrick, preferIndexes.Count + alterIndexes.Count);
		for (int i = 0; i < trulyCostTrick; i++)
		{
			int index2 = ((i < preferIndexes.Count) ? preferIndexes[i] : alterIndexes[i - preferIndexes.Count]);
			tricks.RemoveTrick(index2);
		}
		ObjectPool<List<int>>.Instance.Return(preferIndexes);
		ObjectPool<List<int>>.Instance.Return(alterIndexes);
		if (trulyCostTrick > 0)
		{
			trickChar.SetTricks(tricks, context);
			_addDamagePercent = 20 * trulyCostTrick;
			AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			69 => _addDamagePercent, 
			199 => _addPower, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
