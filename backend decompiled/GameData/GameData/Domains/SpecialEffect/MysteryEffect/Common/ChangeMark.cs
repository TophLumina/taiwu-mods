using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.MysteryEffect.Common;

public abstract class ChangeMark : MysteryEffectBase
{
	private const int ChangeOdds = 33;

	protected abstract ushort FieldId { get; }

	protected virtual bool IsTarget(AffectedDataKey dataKey)
	{
		return dataKey.CharId == base.CharacterId && dataKey.FieldId == FieldId;
	}

	protected ChangeMark()
	{
	}

	protected ChangeMark(int charId, int itemId, int type)
		: base(charId, itemId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(FieldId, EDataModifyType.Add, -1);
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
		return IsTarget(dataKey) ? CMath.SumPercentOdds(currModifyValue, 33) : base.GetModifyValue(dataKey, currModifyValue);
	}
}
