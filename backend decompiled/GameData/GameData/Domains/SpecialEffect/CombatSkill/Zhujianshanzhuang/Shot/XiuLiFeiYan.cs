using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class XiuLiFeiYan : CombatSkillEffectBase
{
	private bool _gettingTrick;

	public XiuLiFeiYan()
	{
	}

	public XiuLiFeiYan(CombatSkillKey skillKey)
		: base(skillKey, 9400, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(164, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_GetTrick(OnGetTrick);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_GetTrick(OnGetTrick);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (base.CharacterId == charId && base.IsDirect && trickType == 12 && !_gettingTrick && base.EffectCount > 0)
		{
			_gettingTrick = true;
			DomainManager.Combat.AddTrick(context, base.CombatChar, 12);
			_gettingTrick = false;
			ShowSpecialEffectTips(0);
			ReduceEffectCount();
		}
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 164 || base.EffectCount <= 0)
		{
			return dataValue;
		}
		if (!dataValue.Exists((NeedTrick needTrick) => needTrick.TrickType == 12))
		{
			return dataValue;
		}
		for (int i = 0; i < dataValue.Count; i++)
		{
			NeedTrick costTrick = dataValue[i];
			if (costTrick.TrickType == 12)
			{
				costTrick.NeedCount--;
				dataValue[i] = costTrick;
				break;
			}
		}
		ShowSpecialEffectTips(0);
		ReduceEffectCount();
		return dataValue;
	}
}
