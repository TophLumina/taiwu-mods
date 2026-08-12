using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class WangXue : AutoCollectEffectBase
{
	private const int AddValuePerMark = 5;

	private int _affectValue;

	public WangXue(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		int mainCharId = mainChar.GetId();
		CreateAffectedData(mainCharId, 44, EDataModifyType.AddPercent, -1);
		CreateAffectedData(mainCharId, 45, EDataModifyType.AddPercent, -1);
		CreateAffectedData(mainCharId, 46, EDataModifyType.AddPercent, -1);
		CreateAffectedData(mainCharId, 47, EDataModifyType.AddPercent, -1);
		DataUid uid = ParseCombatCharacterDataUid(mainCharId, 50);
		AutoMonitor(uid, UpdateAffectValue);
		UpdateAffectValue(context, default(DataUid));
	}

	private void UpdateAffectValue(DataContext context, DataUid dataUid)
	{
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		int affectValue = mainChar.GetDefeatMarkCollection().FatalDamageMarkCount * 5;
		if (affectValue != _affectValue)
		{
			_affectValue = affectValue;
			InvalidateAllAffectDataCache(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 44) <= 3u)
		{
			return _affectValue;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
