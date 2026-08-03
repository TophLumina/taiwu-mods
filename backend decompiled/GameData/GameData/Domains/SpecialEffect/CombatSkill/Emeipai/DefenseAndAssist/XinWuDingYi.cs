using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class XinWuDingYi : AssistSkillBase
{
	private sbyte AffectOdds = 30;

	private sbyte _getTrickType;

	private bool _gettingExtraTrick;

	public XinWuDingYi()
	{
	}

	public XinWuDingYi(CombatSkillKey skillKey)
		: base(skillKey, 2701)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			_gettingExtraTrick = false;
			Events.RegisterHandler_GetTrick(OnGetTrick);
		}
		else
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 164, base.SkillTemplateId), EDataModifyType.Custom);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_GetTrick(OnGetTrick);
		}
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (base.CharacterId == charId && usable && base.CanAffect && !_gettingExtraTrick && context.Random.CheckPercentProb(AffectOdds))
		{
			_getTrickType = trickType;
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		_gettingExtraTrick = true;
		DomainManager.Combat.AddTrick(context, base.CombatChar, _getTrickType);
		_gettingExtraTrick = false;
		ShowSpecialEffectTips(0);
		ShowEffectTips(context);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		DataContext context = DomainManager.Combat.Context;
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 164)
		{
			bool affected = false;
			for (int i = 0; i < dataValue.Count; i++)
			{
				NeedTrick costTrick = dataValue[i];
				if (base.CombatChar.IsTrickUseless(costTrick.TrickType))
				{
					continue;
				}
				byte costCount = costTrick.NeedCount;
				for (int _ = 0; _ < costCount; _++)
				{
					if (context.Random.CheckPercentProb(AffectOdds))
					{
						costTrick.NeedCount--;
						dataValue[i] = costTrick;
						affected = true;
					}
				}
			}
			if (affected)
			{
				ShowSpecialEffectTips(0);
				ShowEffectTips(context);
			}
		}
		return dataValue;
	}
}
