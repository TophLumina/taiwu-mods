using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class CangMangYe : ProfessionEffectBase
{
	private const sbyte AddPercent = 20;

	protected override short CombatStateId => 134;

	public CangMangYe()
	{
	}

	public CangMangYe(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(74, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 74)
		{
			return 20;
		}
		return 0;
	}
}
