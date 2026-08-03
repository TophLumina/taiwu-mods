using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class HuanXing : AutoCollectEffectBase
{
	private static CValuePercent RecoverPercent => 33;

	public HuanXing(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		int recoverValue = damageValue * RecoverPercent;
		if (recoverValue <= 0)
		{
			return;
		}
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		int mainCharId = mainChar.GetId();
		if (mainCharId == attackerId)
		{
			for (sbyte i = 0; i < 7; i++)
			{
				mainChar.RemoveInjuryValue(context, i, isInner, recoverValue);
			}
		}
	}
}
