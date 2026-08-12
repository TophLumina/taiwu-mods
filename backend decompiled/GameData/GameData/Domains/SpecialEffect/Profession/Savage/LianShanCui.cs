using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class LianShanCui : ProfessionEffectBase
{
	private const sbyte AddPercent = 20;

	protected override short CombatStateId => 135;

	public LianShanCui()
	{
	}

	public LianShanCui(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(195, EDataModifyType.AddPercent, -1);
		CreateAffectedData(196, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 195) <= 1u)
		{
			return 20;
		}
		return 0;
	}
}
