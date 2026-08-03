using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;

public class SuiXinWuNian : MysteryEffectBase
{
	protected override short SpecialEffectId => 1754;

	public SuiXinWuNian()
	{
	}

	public SuiXinWuNian(int charId, int itemId)
		: base(charId, itemId, 50001)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightBack, bool isMind)
	{
		if (attacker.GetId() != base.CharacterId || pursueIndex <= 0 || !hit)
		{
			return;
		}
		FlawOrAcupointCollection flaws = defender.GetFlawCollection();
		FlawOrAcupointCollection acupoints = defender.GetAcupointCollection();
		bool anyFlaw = flaws.BodyPartDict.Values.Any((List<FlawOrAcupointEntry> x) => x.Count > 0);
		bool anyAcupoint = acupoints.BodyPartDict.Values.Any((List<FlawOrAcupointEntry> x) => x.Count > 0);
		if (!anyFlaw && !anyAcupoint)
		{
			return;
		}
		if (context.Random.RandomIsInner(anyAcupoint, anyFlaw) && acupoints.RandomRecoverKeepTimeToTotal(context.Random))
		{
			defender.SetAcupointCollection(acupoints, context);
		}
		else
		{
			if (!flaws.RandomRecoverKeepTimeToTotal(context.Random))
			{
				return;
			}
			defender.SetFlawCollection(flaws, context);
		}
		ShowSpecialEffect(0);
	}
}
