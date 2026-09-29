using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Chicken;

public class ChickenBrave : AutoCollectEffectBase
{
	private readonly int _addDamage;

	public ChickenBrave(int charId, int totalPoint)
		: base(charId)
	{
		_addDamage = totalPoint / 2 * 100;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(274, EDataModifyType.AddPercent, -1);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		base.OnDisable(context);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.IsAlly == base.CombatChar.IsAlly)
		{
			MakeEffect(context);
		}
	}

	private void MakeEffect(DataContext context)
	{
		CombatCharacter combatChar = base.CombatChar;
		CombatCharacter enemyChar = base.CurrEnemyChar;
		bool prevIsFightBack = combatChar.GetIsFightBack();
		combatChar.SetIsFightBack(isFightBack: false, context);
		sbyte trickType = combatChar.GetWeaponTricks().GetRandom(context.Random);
		sbyte prevBodyPart = combatChar.NormalAttackBodyPart;
		sbyte prevHitType = combatChar.NormalAttackHitType;
		sbyte part = DomainManager.Combat.GetAttackBodyPart(base.CombatChar, enemyChar, context.Random, -1, trickType, -1);
		combatChar.NormalAttackBodyPart = part;
		combatChar.NormalAttackHitType = DomainManager.Combat.GetAttackHitType(combatChar, trickType);
		DomainManager.Combat.CalcNormalAttack(CombatContext.Create(combatChar, null, -1, -1), trickType);
		combatChar.SetIsFightBack(prevIsFightBack, context);
		combatChar.NormalAttackBodyPart = prevBodyPart;
		combatChar.NormalAttackHitType = prevHitType;
		RemoveSelf(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId == base.CharacterId;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 69 || fieldId == 274) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return _addDamage;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
