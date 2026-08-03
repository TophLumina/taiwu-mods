using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.SectStory.Zhujian;

public class GearMateE : AutoCollectEffectBase
{
	public GearMateE(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		ClearFlawAndAcupoints(context);
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		CreateAffectedData(mainChar.GetId(), 129, EDataModifyType.Custom, -1);
		CreateAffectedData(mainChar.GetId(), 134, EDataModifyType.Custom, -1);
	}

	private void ClearFlawAndAcupoints(DataContext context)
	{
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		DomainManager.Combat.RemoveAllFlaw(context, mainChar);
		DomainManager.Combat.RemoveAllAcupoint(context, mainChar);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 129 || fieldId == 134) ? true : false)
		{
			return 0;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
