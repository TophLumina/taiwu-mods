using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class LoongMetal : CombatStateEffectBase
{
	private const int ReduceMoveCostPercent = -50;

	protected override short CombatStateId => 253;

	public LoongMetal(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(175, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 175)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return -50;
	}
}
