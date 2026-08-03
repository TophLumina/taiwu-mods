using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class SenLuoZhang : ProfessionEffectBase
{
	private const sbyte AddPercent = 20;

	protected override short CombatStateId => 138;

	public SenLuoZhang()
	{
	}

	public SenLuoZhang(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(198, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 198)
		{
			return 20;
		}
		return 0;
	}
}
