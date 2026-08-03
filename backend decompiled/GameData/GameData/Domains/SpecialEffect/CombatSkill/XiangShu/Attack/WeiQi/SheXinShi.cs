using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class SheXinShi : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 60;

	private readonly Dictionary<short, int> _addPowerDict = new Dictionary<short, int>();

	public SheXinShi()
	{
	}

	public SheXinShi(CombatSkillKey skillKey)
		: base(skillKey, 17055, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted)
		{
			return;
		}
		IReadOnlyDictionary<int, sbyte> trickDict = base.CombatChar.GetTricks().Tricks;
		List<sbyte> trickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		short addEffectCount = 0;
		trickRandomPool.Clear();
		trickRandomPool.AddRange(trickDict.Values);
		int removeCount = Math.Min(base.MaxEffectCount, trickRandomPool.Count);
		for (int i = 0; i < removeCount; i++)
		{
			int index = context.Random.Next(trickRandomPool.Count);
			if (DomainManager.Combat.RemoveTrick(context, base.CombatChar, trickRandomPool[index], 1))
			{
				addEffectCount++;
			}
			trickRandomPool.RemoveAt(index);
		}
		ObjectPool<List<sbyte>>.Instance.Return(trickRandomPool);
		if (addEffectCount > 0)
		{
			DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), addEffectCount, base.MaxEffectCount, autoRemoveOnNoCount: true);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || base.EffectCount <= 0)
		{
			return;
		}
		ReduceEffectCount();
		if (base.EffectCount > 0)
		{
			if (!_addPowerDict.TryAdd(skillId, 60))
			{
				_addPowerDict[skillId] += 60;
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			_addPowerDict.Clear();
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return _addPowerDict.GetValueOrDefault(dataKey.CombatSkillId, 0);
	}
}
