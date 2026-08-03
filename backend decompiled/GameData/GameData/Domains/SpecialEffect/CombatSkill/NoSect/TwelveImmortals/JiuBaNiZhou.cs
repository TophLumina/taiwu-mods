using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class JiuBaNiZhou : TwelveImmortalsBase
{
	private const int MaxTransferImpairCount = 6;

	private CValueMultiplier _destroyBlockCount;

	private static CValuePercent FatalDamagePercentUnit => 33;

	public JiuBaNiZhou()
	{
	}

	public JiuBaNiZhou(CombatSkillKey skillKey)
		: base(skillKey, 18001)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_destroyBlockCount = CalcDestroyBlockCount();
		Events.RegisterHandler_FlawAdded(OnFlawAdded);
		Events.RegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.RegisterHandler_AddMindMark(OnAddMindMark);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_FlawAdded(OnFlawAdded);
		Events.UnRegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.UnRegisterHandler_AddMindMark(OnAddMindMark);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private CValueMultiplier CalcDestroyBlockCount()
	{
		return base.TwelveImmortalsConfig.GetImpactRangeBlocks(CharObj).Count((MapBlockData blockData) => blockData.Destroyed);
	}

	private void OnFlawAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (base.IsDirect && combatChar.IsAlly != base.CombatChar.IsAlly)
		{
			DoAffect(context, combatChar);
		}
	}

	private void OnAcuPointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (base.IsDirect && combatChar.IsAlly != base.CombatChar.IsAlly)
		{
			DoAffect(context, combatChar);
		}
	}

	private void OnAddMindMark(DataContext context, CombatCharacter character, int count)
	{
		if (base.IsDirect && character.IsAlly != base.CombatChar.IsAlly)
		{
			DoAffect(context, character, count);
		}
	}

	private void DoAffect(DataContext context, CombatCharacter combatChar, int count = 1)
	{
		CValuePercent percent = FatalDamagePercentUnit * _destroyBlockCount;
		int step = combatChar.GetDamageStepCollection().FatalDamageStep;
		int damage = step * percent * count;
		if (damage > 0)
		{
			combatChar.AddFatalDamage(context, damage, -1, -1, -1);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (base.IsDirect || charId != base.CharacterId || !CombatSkillEquipType.IsDefense(skillId))
		{
			return;
		}
		List<DefeatMarkKey> pool = ObjectPool<List<DefeatMarkKey>>.Instance.Get();
		DefeatMarkCollection marks = base.CombatChar.GetDefeatMarkCollection();
		foreach (DefeatMarkKey markKey in marks.GetAllKeys(base.CombatChar))
		{
			if (markKey.Type.GetGroup() == EMarkGroupType.Impair)
			{
				pool.Add(markKey);
			}
		}
		CombatCharacter enemyChar = base.EnemyChar;
		int count = Math.Min(pool.Count, 6);
		if (count > 0)
		{
			ShowSpecialEffectTips(0);
		}
		foreach (DefeatMarkKey markKey2 in RandomUtils.GetRandomUnrepeated(context.Random, count, pool))
		{
			if (markKey2.Type == EMarkType.Flaw)
			{
				DomainManager.Combat.TransferRandomFlaw(context, base.CombatChar, enemyChar);
			}
			else if (markKey2.Type == EMarkType.Acupoint)
			{
				DomainManager.Combat.TransferRandomAcupoint(context, base.CombatChar, enemyChar);
			}
			else if (markKey2.Type == EMarkType.Mind)
			{
				base.CombatChar.TransferRandomMindMark(context, enemyChar);
			}
		}
		ObjectPool<List<DefeatMarkKey>>.Instance.Return(pool);
		int step = base.CombatChar.GetDamageStepCollection().FatalDamageStep;
		int damage = step * FatalDamagePercentUnit * count;
		base.CombatChar.AddFatalDamage(context, damage, -1, -1, -1);
	}
}
