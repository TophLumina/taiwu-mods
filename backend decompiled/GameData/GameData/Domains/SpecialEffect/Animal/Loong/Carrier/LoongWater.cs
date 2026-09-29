using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class LoongWater : CombatStateEffectBase
{
	private const int AddMakePoisonPercent = 100;

	private const int ReducePoisonResistPercent = -50;

	protected override short CombatStateId => 254;

	public LoongWater(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(73, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 245, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 73)
		{
			return 100;
		}
		if (dataKey.CharId != base.CharacterId && dataKey.FieldId == 245)
		{
			return -50;
		}
		return 0;
	}
}
