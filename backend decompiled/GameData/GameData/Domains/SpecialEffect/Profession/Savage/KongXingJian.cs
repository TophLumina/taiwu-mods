using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class KongXingJian : ProfessionEffectBase
{
	private const sbyte AddPercent = 20;

	protected override short CombatStateId => 136;

	public KongXingJian()
	{
	}

	public KongXingJian(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(197, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 197)
		{
			return 20;
		}
		return 0;
	}
}
