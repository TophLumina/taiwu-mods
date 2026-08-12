using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;

public class SanShiLiuBiShou : CombatSkillEffectBase
{
	public SanShiLiuBiShou()
	{
	}

	public SanShiLiuBiShou(CombatSkillKey skillKey)
		: base(skillKey, 2100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
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
				IsSrcSkillPerformed = true;
				AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 138 : 164), EDataModifyType.Custom, -1);
				AddMaxEffectCount();
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

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 138 && dataKey.CustomParam1 == 0 && dataKey.CustomParam2 == 1 && !base.CombatChar.GetWeaponTricks().Exist((sbyte)dataKey.CustomParam0))
		{
			ShowSpecialEffectTips(0);
			ReduceEffectCount();
			return false;
		}
		return dataValue;
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		DataContext context = DomainManager.Combat.Context;
		if (dataKey.FieldId == 164 && dataKey.CustomParam1 == 0)
		{
			sbyte[] weaponTricks = base.CombatChar.GetWeaponTricks();
			int reducedCount = 0;
			for (int i = 0; i < dataValue.Count; i++)
			{
				NeedTrick costTrick = dataValue[i];
				if (weaponTricks.Exist(costTrick.TrickType))
				{
					int reduceCount = Math.Min(costTrick.NeedCount, base.EffectCount - reducedCount);
					reducedCount += reduceCount;
					costTrick.NeedCount = (byte)(costTrick.NeedCount - reduceCount);
					dataValue[i] = costTrick;
					if (reducedCount >= base.EffectCount)
					{
						break;
					}
				}
			}
			if (reducedCount > 0)
			{
				ShowSpecialEffectTips(0);
				ReduceEffectCount(reducedCount);
			}
		}
		return dataValue;
	}
}
