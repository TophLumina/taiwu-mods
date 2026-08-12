using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Chiwen : CombatStateEffectBase
{
	private const int AddOrReduceNeiliAllocationValue = 2;

	protected override short CombatStateId => 207;

	public Chiwen(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastSkillTrickCosted(OnCastSkillTrickCosted);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillTrickCosted(OnCastSkillTrickCosted);
		base.OnDisable(context);
	}

	private void OnCastSkillTrickCosted(DataContext context, CombatCharacter combatChar, short skillId, List<NeedTrick> costTricks)
	{
		if (combatChar.GetId() != base.CharacterId && combatChar.IsAlly == base.CombatChar.IsAlly)
		{
			return;
		}
		bool buff = combatChar.GetId() == base.CharacterId;
		int totalCostCount = costTricks.Sum((NeedTrick x) => x.NeedCount);
		NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = combatChar.GetOriginNeiliAllocation();
		int neiliAllocationCost = totalCostCount * 2 * (buff ? 1 : (-1));
		for (byte i = 0; i < 4; i++)
		{
			if (!(buff ? (neiliAllocation[i] >= originNeiliAllocation[i]) : (neiliAllocation[i] <= originNeiliAllocation[i])))
			{
				combatChar.ChangeNeiliAllocation(context, i, neiliAllocationCost);
			}
		}
	}
}
