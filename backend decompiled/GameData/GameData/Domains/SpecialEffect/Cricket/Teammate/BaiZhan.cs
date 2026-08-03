using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class BaiZhan : AutoCollectEffectBase
{
	private const int AddBouncePower = 33;

	public BaiZhan(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		CreateAffectedData(mainChar.GetId(), 111, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(mainChar.GetId(), 177, EDataModifyType.Custom, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 111)
		{
			return 33;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.FieldId != 177)
		{
			return dataValue;
		}
		CombatConfigItem combatConfig = DomainManager.Combat.CombatConfig;
		return new OuterAndInnerInts(combatConfig.MinDistance, combatConfig.MaxDistance);
	}
}
