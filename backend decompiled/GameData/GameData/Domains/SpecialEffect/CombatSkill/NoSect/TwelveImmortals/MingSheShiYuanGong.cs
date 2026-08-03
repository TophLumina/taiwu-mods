using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class MingSheShiYuanGong : TwelveImmortalsBase
{
	private const int AbsorbUnit = 3;

	private const sbyte AddFlawOrAcupointLevel = 1;

	private const int ReverseAbsorbFrame = 180;

	private const int ReverseAbsorbValue = 20;

	private int _directDemonCount;

	private bool _reverseAffected;

	private static int CalcDemonCount(MapBlockData block)
	{
		HashSet<int> enemyCharacterSet = block.EnemyCharacterSet;
		if (enemyCharacterSet == null || enemyCharacterSet.Count <= 0)
		{
			return 0;
		}
		int count = 0;
		foreach (int charId in block.EnemyCharacterSet)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				count += (character.GetFeatureIds().Contains(880) ? 1 : 0);
			}
		}
		return count;
	}

	public MingSheShiYuanGong()
	{
	}

	public MingSheShiYuanGong(CombatSkillKey skillKey)
		: base(skillKey, 18008)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			_directDemonCount = base.TwelveImmortalsConfig.GetImpactRangeBlocks(CharObj).Sum((Func<MapBlockData, int>)CalcDemonCount);
		}
		AutoMonitor(ParseCombatCharacterDataUid(50), TryAbsorb);
		Events.RegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
		base.OnDisable(context);
	}

	public override bool IsOn(int counterType)
	{
		return !base.IsDirect && DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar);
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 180;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		CombatCharacter enemyChar = base.EnemyChar;
		NeiliAllocation neiliAllocation = enemyChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = enemyChar.GetOriginNeiliAllocation();
		bool anyAbsorb = false;
		for (byte i = 0; i < 4; i++)
		{
			if (neiliAllocation[i] > originNeiliAllocation[i] && base.CombatChar.AbsorbNeiliAllocation(context, enemyChar, i, 3))
			{
				anyAbsorb = true;
			}
		}
		if (anyAbsorb)
		{
			bool flaw = context.Random.CheckPercentProb(50);
			if (flaw)
			{
				DomainManager.Combat.AddFlaw(context, base.CombatChar, 1, CombatSkillKey.Invalid, -1);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, base.CombatChar, 1, CombatSkillKey.Invalid, -1);
			}
			ShowSpecialEffectTips(0);
			ShowSpecialEffectTips(flaw, 1, 2);
		}
	}

	private void TryAbsorb(DataContext context, DataUid dataUid)
	{
		if (!_reverseAffected && !base.IsDirect && DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar))
		{
			_reverseAffected = true;
			bool anyAbsorb = false;
			for (byte i = 0; i < 4; i++)
			{
				anyAbsorb = base.CombatChar.AbsorbNeiliAllocation(context, base.EnemyChar, i, 20) || anyAbsorb;
			}
			if (anyAbsorb)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnAddFatalDamageMark(DataContext context, CombatCharacter combatChar, int count)
	{
		if (combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		int absorbValue = 3 * count * _directDemonCount;
		if (absorbValue > 0)
		{
			bool anyAbsorb = false;
			for (byte i = 0; i < 4; i++)
			{
				anyAbsorb = base.CombatChar.AbsorbNeiliAllocation(context, base.EnemyChar, i, absorbValue) || anyAbsorb;
			}
			if (anyAbsorb)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}
}
