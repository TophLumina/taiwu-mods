using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Polearm;

public class ChuangZhen : EquipmentEffectBase
{
	private const int NeedPursueIndex = 5;

	private static readonly CValuePercent DeltaFrame = -50;

	public ChuangZhen()
	{
	}

	public ChuangZhen(int charId, ItemKey itemKey)
		: base(charId, itemKey, 40900, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (attacker.GetId() == base.CharacterId && IsCurrWeapon() && pursueIndex == 5)
		{
			defender.ChangeAffectingDefenseSkillLeftFrame(context, DeltaFrame);
		}
	}
}
