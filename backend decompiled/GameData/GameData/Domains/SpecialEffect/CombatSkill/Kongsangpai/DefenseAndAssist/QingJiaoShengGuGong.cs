using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class QingJiaoShengGuGong : DefenseSkillBase
{
	private const sbyte AutoHealSpeed = 2;

	private const sbyte RemoveFatalDamageCount = 6;

	private DataUid _defendSkillCanAffectUid;

	private bool _affecting;

	public QingJiaoShengGuGong()
	{
	}

	public QingJiaoShengGuGong(CombatSkillKey skillKey)
		: base(skillKey, 10607)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		_defendSkillCanAffectUid = ParseCombatSkillDataUid(9);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defendSkillCanAffectUid, base.DataHandlerKey, UpdateCanAffect);
		_affecting = false;
		UpdateCanAffect(context, _defendSkillCanAffectUid);
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defendSkillCanAffectUid, base.DataHandlerKey);
		List<short> speedList = (base.IsDirect ? base.CombatChar.OuterInjuryAutoHealSpeeds : base.CombatChar.InnerInjuryAutoHealSpeeds);
		speedList.Remove(2);
		if (speedList.Count <= 0)
		{
			base.CombatChar.ClearInjuryAutoHealProgress(context, !base.IsDirect);
		}
		base.CombatChar.RemoveFatalMark(context, 6);
		DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			List<short> speedList = (base.IsDirect ? base.CombatChar.OuterInjuryAutoHealSpeeds : base.CombatChar.InnerInjuryAutoHealSpeeds);
			_affecting = canAffect;
			if (canAffect)
			{
				speedList.Add(2);
			}
			else
			{
				speedList.Remove(2);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 281)
		{
			return dataValue;
		}
		return dataValue || _affecting;
	}
}
