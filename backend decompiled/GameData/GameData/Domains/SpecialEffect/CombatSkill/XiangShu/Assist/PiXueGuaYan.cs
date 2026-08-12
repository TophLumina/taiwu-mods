using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class PiXueGuaYan : AssistSkillBase
{
	private const sbyte ChangeDamage = 50;

	private const sbyte AddPowerUnit = 10;

	private DataUid _defeatMarkUid;

	private int _addPower;

	public PiXueGuaYan()
	{
	}

	public PiXueGuaYan(CombatSkillKey skillKey)
		: base(skillKey, 16418)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 0;
		_defeatMarkUid = ParseCombatCharacterDataUid(50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnMarkChanged);
		CreateAffectedData(131, EDataModifyType.Custom, -1);
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
	}

	private void OnMarkChanged(DataContext context, DataUid dataUid)
	{
		_addPower = 10 * base.CombatChar.GetDefeatMarkCollection().OuterInjuryMarkList.Sum();
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 131)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		if (dataKey.FieldId == 102)
		{
			return (dataKey.CustomParam0 == 1) ? (-50) : 50;
		}
		return 0;
	}
}
