using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic;

public class LuanXin : EquipmentEffectBase
{
	public LuanXin()
	{
	}

	public LuanXin(int charId, ItemKey itemKey)
		: base(charId, itemKey, 41300, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private unsafe void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (attacker.GetId() != base.CharacterId || !IsCurrWeapon() || !hit)
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
		List<byte> typeRandomPool = ObjectPool<List<byte>>.Instance.Get();
		typeRandomPool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (neiliAllocation.Items[(int)type] > 0)
			{
				typeRandomPool.Add(type);
			}
		}
		if (typeRandomPool.Count > 0)
		{
			base.CurrEnemyChar.ChangeNeiliAllocation(context, typeRandomPool.GetRandom(context.Random), -1);
		}
		ObjectPool<List<byte>>.Instance.Return(typeRandomPool);
	}
}
