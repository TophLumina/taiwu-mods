using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AccumulateNeiliAllocationToStrengthen : CombatSkillEffectBase
{
	private const sbyte AddPower = 20;

	private const sbyte PrepareProgressPercent = 50;

	protected byte RequireNeiliAllocationType;

	protected AccumulateNeiliAllocationToStrengthen()
	{
	}

	protected AccumulateNeiliAllocationToStrengthen(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 154, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNeiliAllocationChanged(DataContext context, int charId, byte type, int changeValue)
	{
		if (charId == base.CharacterId && type == RequireNeiliAllocationType && base.EffectCount < base.MaxEffectCount && (base.IsDirect ? (changeValue > 0) : (changeValue < 0)))
		{
			short addValue = (short)Math.Min(Math.Abs(changeValue), base.MaxEffectCount - base.EffectCount);
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), addValue);
			if (base.EffectCount >= base.MaxEffectCount)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 154);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.EffectCount >= base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.EffectCount >= base.MaxEffectCount)
		{
			ReduceEffectCount(base.MaxEffectCount);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return (base.EffectCount == base.MaxEffectCount) ? 20 : 0;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 154)
		{
			return base.EffectCount != base.MaxEffectCount;
		}
		return dataValue;
	}
}
