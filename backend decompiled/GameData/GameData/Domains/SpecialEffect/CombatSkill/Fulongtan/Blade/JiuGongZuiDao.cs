using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class JiuGongZuiDao : CombatSkillEffectBase
{
	private const sbyte NormalRemoveTrickCount = 2;

	private const sbyte DrunkRemoveTrickCount = 3;

	private const sbyte DrunkAddPowerUnit = 10;

	private int _addPower;

	public JiuGongZuiDao()
	{
	}

	public JiuGongZuiDao(CombatSkillKey skillKey)
		: base(skillKey, 14201, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true));
		List<sbyte> trickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		trickRandomPool.Clear();
		trickRandomPool.AddRange(affectChar.GetTricks().Tricks.Values);
		trickRandomPool.RemoveAll((sbyte type) => affectChar.IsTrickUsable(type) == base.IsDirect);
		if (trickRandomPool.Count > 0)
		{
			bool isDrunk = CharObj.GetEatingItems().ContainsWine();
			int removeCount = Math.Min(isDrunk ? 3 : 2, trickRandomPool.Count);
			List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
			removeTricks.Clear();
			for (int i = 0; i < removeCount; i++)
			{
				sbyte trickType = trickRandomPool[context.Random.Next(0, trickRandomPool.Count)];
				trickRandomPool.Remove(trickType);
				removeTricks.Add(new NeedTrick(trickType, 1));
			}
			if (isDrunk)
			{
				_addPower = removeCount * 10;
				AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
				AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			}
			DomainManager.Combat.RemoveTrick(context, affectChar, removeTricks, base.IsDirect);
			ShowSpecialEffectTips(0);
			ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
		}
		ObjectPool<List<sbyte>>.Instance.Return(trickRandomPool);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
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
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
