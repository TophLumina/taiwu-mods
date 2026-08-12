using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class BaiLongQianYuan : AgileSkillBase
{
	private const int ReduceCostUnitPercent = -150;

	private DataUid _defeatMarkUid;

	private int _reduceCostPercent;

	public BaiLongQianYuan()
	{
	}

	public BaiLongQianYuan(CombatSkillKey skillKey)
		: base(skillKey, 16205)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_reduceCostPercent = 0;
		CreateAffectedData(175, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(179, EDataModifyType.TotalPercent, -1);
		_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		OnDefeatMarkChanged(context, default(DataUid));
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		byte maxMarkCount = GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()];
		_reduceCostPercent = Math.Max(-150 * markCollection.GetTotalCount() / maxMarkCount, -100);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 175);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 179);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 175 || fieldId == 179) ? true : false)
		{
			return _reduceCostPercent;
		}
		return 0;
	}
}
