using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class LiuShiBaShiLuoHanQuan : CombatSkillEffectBase
{
	public LiuShiBaShiLuoHanQuan()
	{
	}

	public LiuShiBaShiLuoHanQuan(CombatSkillKey skillKey)
		: base(skillKey, 1103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 223, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && power > 0)
		{
			CombatCharacter defendChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			if (defendChar.GetAffectingDefendSkillId() >= 0)
			{
				int leftFrame = defendChar.DefendSkillLeftFrame;
				int totalFrame = defendChar.DefendSkillTotalFrame;
				defendChar.DefendSkillLeftFrame = (short)(base.IsDirect ? Math.Min(leftFrame + totalFrame * power / 100, totalFrame) : Math.Max(leftFrame - totalFrame * power / 100, 0));
				ShowSpecialEffectTips(0);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 223)
		{
			return true;
		}
		return dataValue;
	}
}
