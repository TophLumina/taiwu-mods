using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class GetTrick : CombatSkillEffectBase
{
	private const sbyte ReverseGetTrickCount = 2;

	protected sbyte GetTrickType;

	protected sbyte[] DirectCanChangeTrickType;

	protected GetTrick()
	{
	}

	protected GetTrick(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 139, -1), EDataModifyType.Custom);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				if (base.IsDirect)
				{
					IsSrcSkillPerformed = true;
					AddMaxEffectCount();
				}
				else
				{
					DomainManager.Combat.AddTrick(context, base.CombatChar, GetTrickType, 2);
					ShowSpecialEffectTips(0);
					RemoveSelf(context);
				}
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 139)
		{
			DataContext context = DomainManager.Combat.Context;
			sbyte trickType = (sbyte)dataValue;
			if (DirectCanChangeTrickType.Exist(trickType))
			{
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
				return GetTrickType;
			}
		}
		return dataValue;
	}
}
