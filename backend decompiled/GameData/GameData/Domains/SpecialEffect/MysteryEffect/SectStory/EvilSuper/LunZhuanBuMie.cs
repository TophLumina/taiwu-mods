using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;

public class LunZhuanBuMie : MysteryEffectBase
{
	private int _affectedCount;

	protected override short SpecialEffectId => 1778;

	public LunZhuanBuMie()
	{
	}

	public LunZhuanBuMie(int charId, int itemId)
		: base(charId, itemId, 50110)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar.GetId() == base.CharacterId && type == ECombatCharAboutToFallType.LunZhuanBuMie)
		{
			int samsaraCount = CharObj.GetPreexistenceCharIds().Count;
			if (samsaraCount > _affectedCount)
			{
				_affectedCount++;
				combatChar.RemoveHalfFatalMark(context);
				ShowSpecialEffect(0);
			}
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		_affectedCount = 0;
	}
}
