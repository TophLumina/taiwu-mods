using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class YouTanChen : ProfessionEffectBase
{
	private const sbyte AddPoisonLevel = 1;

	private const sbyte AddPoisonPercent = 50;

	protected override short CombatStateId => 140;

	public YouTanChen()
	{
	}

	public YouTanChen(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(72, EDataModifyType.Add, -1);
		CreateAffectedData(73, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 72)
		{
			return 1;
		}
		if (dataKey.FieldId == 73)
		{
			return 50;
		}
		return 0;
	}
}
