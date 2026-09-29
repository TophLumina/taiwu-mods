using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class LoongWood : CombatStateEffectBase
{
	private const int AddAttackRange = 10;

	protected override short CombatStateId => 255;

	public LoongWood(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(145, EDataModifyType.Add, -1);
		CreateAffectedData(146, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 145) <= 1u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		return 10;
	}
}
