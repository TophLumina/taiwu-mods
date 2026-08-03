using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class YanXiaShenZhu : RawCreateEquipmentBase
{
	private const int AddAttackOdds = 100;

	private const int InevitableAvoidOdds = 33;

	protected override int ReduceDurabilityValue => 16;

	public YanXiaShenZhu()
	{
	}

	public YanXiaShenZhu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30200)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(306, EDataModifyType.AddPercent, -1);
		CreateAffectedData(290, EDataModifyType.Custom, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 306 || !base.CanAffect)
		{
			return 0;
		}
		int bodyPart = dataKey.CustomParam0;
		if (bodyPart < 0 || base.CombatChar.Armors[bodyPart] != EquipItemKey)
		{
			return 0;
		}
		return 100;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 290 || !dataKey.IsNormalAttack || !base.CanAffect)
		{
			return dataValue;
		}
		int bodyPart = dataKey.CustomParam1;
		if (bodyPart < 0 || base.CombatChar.Armors[bodyPart] != EquipItemKey)
		{
			return dataValue;
		}
		return dataValue || DomainManager.Combat.Context.Random.CheckPercentProb(33);
	}
}
