using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class BingQingYuJie : AssistSkillBase
{
	private const sbyte AttractionUnit = 45;

	private const sbyte MaxAddValue = 20;

	private DataUid _attractionUid;

	private int _addValue;

	public BingQingYuJie()
	{
	}

	public BingQingYuJie(CombatSkillKey skillKey)
		: base(skillKey, 8600)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_addValue = Math.Min(CharObj.GetAttraction() / 45, 20);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 35 : 41), -1), EDataModifyType.AddPercent);
		_attractionUid = new DataUid(4, 0, (ulong)base.CharacterId, 78u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_attractionUid, base.DataHandlerKey, OnAttractionChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_attractionUid, base.DataHandlerKey);
	}

	private void OnAttractionChanged(DataContext context, DataUid dataUid)
	{
		_addValue = Math.Min(CharObj.GetAttraction() / 45, 20);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 35);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 35);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		return _addValue;
	}
}
