using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.MysteryEffect.Common;

public abstract class AddTrickAttackRange : MysteryEffectBase
{
	private const int AddAttackRange = 5;

	protected abstract bool IsAffectTrick(sbyte trickType);

	protected AddTrickAttackRange()
	{
	}

	protected AddTrickAttackRange(int charId, int itemId, int type)
		: base(charId, itemId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(145, EDataModifyType.Add, -1);
		CreateAffectedData(146, EDataModifyType.Add, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			ShowSpecialEffect(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 145) <= 1u;
		if (flag && IsAffectTrick((sbyte)dataKey.CustomParam0))
		{
			return 5;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
