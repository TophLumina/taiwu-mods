using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class ChangMuFeiErGong : AssistSkillBase
{
	private const sbyte MinAffectDistance = 30;

	private int _currAddValue;

	public ChangMuFeiErGong()
	{
	}

	public ChangMuFeiErGong(CombatSkillKey skillKey)
		: base(skillKey, 7601)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_currAddValue = -1;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 32, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 33, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 34, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 35, -1), EDataModifyType.AddPercent);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 38, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 39, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 40, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 41, -1), EDataModifyType.AddPercent);
		}
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateAddValue(context);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		UpdateAddValue(context);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		InvalidateCache(context);
	}

	private void UpdateAddValue(DataContext context)
	{
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		int addValue = ((currDistance > 30) ? (5 + (currDistance - 30) * 5 / 10) : 0);
		if (_currAddValue != addValue)
		{
			_currAddValue = addValue;
			InvalidateCache(context);
		}
	}

	private void InvalidateCache(DataContext context)
	{
		SetConstAffecting(context, base.CanAffect && _currAddValue > 0);
		if (base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 32);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 33);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 34);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 35);
		}
		else
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 38);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 39);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 40);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 41);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return base.CanAffect ? _currAddValue : 0;
	}
}
