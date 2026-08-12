using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Qiuniu : CombatStateEffectBase
{
	private static readonly CValuePercent AddOtherPercent = 33;

	protected override short CombatStateId => 199;

	public Qiuniu(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(276, EDataModifyType.Add, -1);
		CreateAffectedData(277, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 276) <= 1u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		sbyte hitType = (sbyte)dataKey.CustomParam0;
		if (hitType != 3)
		{
			return 0;
		}
		int currentValue = dataKey.CustomParam1;
		return currentValue * AddOtherPercent;
	}
}
