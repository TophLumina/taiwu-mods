using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Bian : CombatStateEffectBase
{
	private static readonly IReadOnlyDictionary<sbyte, int> FameTypeToAddPercent = new Dictionary<sbyte, int>
	{
		{ 2, 15 },
		{ 1, 30 },
		{ 0, 45 }
	};

	protected override short CombatStateId => 205;

	public Bian(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(64, EDataModifyType.AddPercent, -1);
		CreateAffectedData(65, EDataModifyType.AddPercent, -1);
		CreateAffectedData(100, EDataModifyType.AddPercent, -1);
		CreateAffectedData(101, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (((uint)(fieldId - 64) <= 1u || (uint)(fieldId - 100) <= 1u) ? true : false);
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		sbyte fameType = base.CurrEnemyChar.GetCharacter().GetFameType();
		int addPercent;
		return FameTypeToAddPercent.TryGetValue(fameType, out addPercent) ? addPercent : 0;
	}
}
