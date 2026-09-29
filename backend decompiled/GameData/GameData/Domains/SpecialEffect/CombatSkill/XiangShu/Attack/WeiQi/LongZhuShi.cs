using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class LongZhuShi : CombatSkillEffectBase
{
	private const sbyte ReducePowerUnit = -30;

	private readonly Dictionary<CombatSkillKey, int> _reducePowerDict = new Dictionary<CombatSkillKey, int>();

	public LongZhuShi()
	{
	}

	public LongZhuShi(CombatSkillKey skillKey)
		: base(skillKey, 17052, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedAllEnemyData(199, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId || !PowerMatchAffectRequire(power))
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		IReadOnlyDictionary<int, sbyte> trickDict = enemyChar.GetTricks().Tricks;
		List<sbyte> trickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		int addEffectCount = 0;
		trickRandomPool.Clear();
		trickRandomPool.AddRange(trickDict.Values.Where(enemyChar.IsTrickUsable));
		int removeCount = Math.Min(base.MaxEffectCount, trickRandomPool.Count);
		foreach (sbyte trick in RandomUtils.GetRandomUnrepeated(context.Random, removeCount, trickRandomPool))
		{
			if (DomainManager.Combat.RemoveTrick(context, enemyChar, trick, 1))
			{
				addEffectCount++;
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(trickRandomPool);
		if (addEffectCount > 0)
		{
			AddEffectCount(addEffectCount);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			ClearPowers(context);
		}
		if (base.CombatChar.IsAlly != isAlly && base.EffectCount > 0 && base.IsCurrent)
		{
			CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
			_reducePowerDict[skillKey] = _reducePowerDict.GetOrDefault(skillKey) + -30;
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			InvalidateAllAffectDataCache(context);
		}
	}

	private void ClearPowers(DataContext context)
	{
		_reducePowerDict.Clear();
		InvalidateAllEnemyCache(context, 199);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		int baseValue = base.GetModifyValue(dataKey, currModifyValue);
		if (!base.IsCurrent)
		{
			return baseValue;
		}
		return CollectionExtensions.GetValueOrDefault(key: new CombatSkillKey(dataKey.CharId, dataKey.CombatSkillId), dictionary: _reducePowerDict, defaultValue: baseValue);
	}
}
