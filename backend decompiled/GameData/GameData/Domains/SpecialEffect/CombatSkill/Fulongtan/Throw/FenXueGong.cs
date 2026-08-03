using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class FenXueGong : CombatSkillEffectBase
{
	private const int ChangeNewInjuryCount = 3;

	private const int ChangeOldInjuryCount = 1;

	private const sbyte AddPower = 60;

	private const sbyte AddAttackRange = 20;

	public FenXueGong()
	{
	}

	public FenXueGong(CombatSkillKey skillKey)
		: base(skillKey, 14304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		Injuries injuries = base.CombatChar.GetInjuries();
		Injuries oldInjuries = base.CombatChar.GetOldInjuries();
		List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		partRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			int newInjury = injuries.Get(part, !base.IsDirect) - oldInjuries.Get(part, !base.IsDirect);
			if (newInjury > 0)
			{
				for (int i = 0; i < newInjury; i++)
				{
					partRandomPool.Add(part);
				}
			}
		}
		if (partRandomPool.Count > 0)
		{
			int oldInjuryCount = Math.Min(partRandomPool.Count, 1);
			int newInjuryCount = Math.Min(partRandomPool.Count, 3);
			CollectionUtils.Shuffle(context.Random, partRandomPool);
			for (int j = 0; j < oldInjuryCount; j++)
			{
				sbyte part2 = partRandomPool[j];
				base.CombatChar.ChangeToOldInjury(context, part2, !base.IsDirect, 1);
			}
			for (int k = oldInjuryCount; k < newInjuryCount; k++)
			{
				sbyte part3 = partRandomPool[k];
				base.CombatChar.RemoveInjury(context, part3, !base.IsDirect);
			}
			AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, base.SkillTemplateId);
			AppendAffectedData(context, base.CharacterId, 145, EDataModifyType.Add, base.SkillTemplateId);
			AppendAffectedData(context, base.CharacterId, 146, EDataModifyType.Add, base.SkillTemplateId);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return 20;
		}
		if (dataKey.FieldId == 199)
		{
			return 60;
		}
		return 0;
	}
}
