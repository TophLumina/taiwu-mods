using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class YongLie : AutoCollectEffectBase
{
	private const int AddFightBackPower = 33;

	public YongLie(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		CreateAffectedData(mainChar.GetId(), 112, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(mainChar.GetId(), 340, EDataModifyType.Custom, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 112)
		{
			return 33;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 340)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
