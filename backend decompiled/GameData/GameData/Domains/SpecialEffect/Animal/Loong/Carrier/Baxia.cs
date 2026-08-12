using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Baxia : CombatStateEffectBase
{
	private const int WeightUnit = 500;

	private const int MaxPowerUnit = 1;

	protected override short CombatStateId => 204;

	public Baxia(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(27, EDataModifyType.Add, -1);
		CreateAffectedData(30, EDataModifyType.Add, -1);
		CreateAffectedData(278, EDataModifyType.Custom, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 27 || fieldId == 30) ? true : false);
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		int weight = CharObj.GetCurrEquipmentLoad();
		return weight / 500;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 278)
		{
			return dataValue;
		}
		return true;
	}
}
