using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class XueLiuPiaoLu : AgileSkillBase
{
	private const sbyte AddPowerUnit = 10;

	private DataUid _defeatMarkUid;

	private int _addPower;

	public XueLiuPiaoLu()
	{
	}

	public XueLiuPiaoLu(CombatSkillKey skillKey)
		: base(skillKey, 16207)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AutoRemove = false;
		_addPower = 0;
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		_defeatMarkUid = ParseCombatCharacterDataUid(50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, UpdateAddPower);
		UpdateAddPower(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
	}

	private void UpdateAddPower(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection marks = base.CombatChar.GetDefeatMarkCollection();
		int addPower = 10 * (marks.OuterInjuryMarkList.Sum() + marks.InnerInjuryMarkList.Sum());
		if (_addPower != addPower)
		{
			if (addPower > _addPower)
			{
				ShowSpecialEffectTips(0);
			}
			_addPower = addPower;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
