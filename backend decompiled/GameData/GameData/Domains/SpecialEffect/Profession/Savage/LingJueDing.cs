using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class LingJueDing : ProfessionEffectBase
{
	private const sbyte AddPercent = -20;

	protected override short CombatStateId => 131;

	public LingJueDing()
	{
	}

	public LingJueDing(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(282, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 282)
		{
			return -20;
		}
		return 0;
	}
}
