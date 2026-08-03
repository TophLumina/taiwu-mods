using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class RanChenZiAssistSkillBase : AssistSkillBase
{
	protected sbyte RequireBossPhase;

	private DataUid _bossPhaseUid;

	protected RanChenZiAssistSkillBase()
	{
	}

	protected RanChenZiAssistSkillBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 217, base.SkillTemplateId), EDataModifyType.Custom);
		_bossPhaseUid = new DataUid(8, 10, (ulong)base.CharacterId, 100u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_bossPhaseUid, base.DataHandlerKey, OnBossPhaseChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_bossPhaseUid, base.DataHandlerKey);
	}

	private void OnBossPhaseChanged(DataContext context, DataUid dataUid)
	{
		sbyte currPhase = base.CombatChar.GetBossPhase();
		if (currPhase == RequireBossPhase)
		{
			ShowSpecialEffectTips(0);
			base.CombatChar.SetXiangshuEffectId((short)base.EffectId, context);
			SetConstAffecting(context, affecting: true);
			ActivateEffect(context);
		}
		else if (currPhase > RequireBossPhase)
		{
			DeactivateEffect(context);
			SetConstAffecting(context, affecting: false);
		}
	}

	protected virtual void ActivateEffect(DataContext context)
	{
	}

	protected virtual void DeactivateEffect(DataContext context)
	{
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 217)
		{
			return false;
		}
		return dataValue;
	}
}
