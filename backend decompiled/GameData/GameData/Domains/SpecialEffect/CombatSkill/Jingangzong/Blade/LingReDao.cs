using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class LingReDao : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 1;

	private const sbyte AddRangeUnit = 1;

	private bool _effectReady;

	public LingReDao()
	{
	}

	public LingReDao(CombatSkillKey skillKey)
		: base(skillKey, 11203, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_effectReady = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, -1), EDataModifyType.Add);
		Events.RegisterHandler_ChangeNeiliAllocationAfterCombatBegin(OnChangeNeiliAllocationAfterCombatBegin);
		Events.RegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeNeiliAllocationAfterCombatBegin(OnChangeNeiliAllocationAfterCombatBegin);
		Events.UnRegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
	}

	private void OnChangeNeiliAllocationAfterCombatBegin(DataContext context, CombatCharacter character, NeiliAllocation _)
	{
		if (character.GetId() == base.CharacterId)
		{
			_effectReady = true;
			DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		}
	}

	private void OnNeiliAllocationChanged(DataContext context, int charId, byte type, int changeValue)
	{
		if (charId == base.CharacterId && (base.IsDirect ? (changeValue > 0) : (changeValue < 0)) && _effectReady)
		{
			changeValue = Math.Abs(changeValue);
			if (base.EffectCount + changeValue > base.MaxEffectCount)
			{
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), (short)(-base.EffectCount));
				DomainManager.Combat.AddGoneMadInjury(context, base.CombatChar, base.SkillTemplateId);
			}
			else
			{
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), (short)changeValue);
				ShowSpecialEffectTips(0);
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
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
			return base.EffectCount;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return base.EffectCount;
		}
		return 0;
	}
}
