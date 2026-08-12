using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritBase : WugEffectBase
{
	private const int ReduceFavorability = 4000;

	private const int ReduceFavorabilityCharCount = 3;

	private const int TakeRevengeRateAddPercent = 900;

	public static bool CanGrown(GameData.Domains.Character.Character character)
	{
		List<short> featureIds = character.GetFeatureIds();
		return featureIds.Contains(210) || featureIds.Contains(211);
	}

	protected ForestSpiritBase()
	{
	}

	protected ForestSpiritBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 4;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsGrown)
		{
			CreateAffectedData(295, EDataModifyType.AddPercent, -1);
		}
		if (base.CanChangeToGrown)
		{
			Events.RegisterHandler_XiangshuInfectionFeatureChangedEnd(OnXiangshuInfectionFeatureChangedEnd);
		}
		if (base.IsGrown)
		{
			Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.CanChangeToGrown)
		{
			Events.UnRegisterHandler_XiangshuInfectionFeatureChangedEnd(OnXiangshuInfectionFeatureChangedEnd);
		}
		if (base.IsGrown)
		{
			Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		Events.RegisterHandler_PoisonAffected(OnPoisonAffected);
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		Events.UnRegisterHandler_PoisonAffected(OnPoisonAffected);
	}

	private void OnXiangshuInfectionFeatureChangedEnd(DataContext context, GameData.Domains.Character.Character character, short featureId)
	{
		if (CanGrown(CharObj) && base.CanAffect)
		{
			ChangeToGrown(context);
		}
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		if (!base.CanAffect)
		{
			return;
		}
		Location location = CharObj.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<int> neighborCharIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 1, includeCenter: true);
		neighborCharIds.Clear();
		neighborCharIds.AddRange(neighborBlocks.Where((MapBlockData x) => x.CharacterSet != null).SelectMany((MapBlockData x) => x.CharacterSet));
		neighborCharIds.Remove(base.CharacterId);
		CollectionUtils.Shuffle(context.Random, neighborCharIds);
		int reduceCount = Math.Min(neighborCharIds.Count, 3);
		bool isTaiwu = CharObj.GetId() == DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
		for (int i = 0; i < reduceCount; i++)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(neighborCharIds[i]);
			if (isTaiwu)
			{
				DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, character, CharObj, -4000);
			}
			else
			{
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, CharObj, -4000);
			}
			AddLifeRecord(lifeRecord.AddWugForestSpiritReduceFavorability, character.GetId());
			if (base.IsElite)
			{
				GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, CharObj, character, isTaiwu, 6, new CharacterBecomeEnemyInfo(CharObj)
				{
					WugTemplateId = WugConfig.TemplateId
				});
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<List<int>>.Instance.Return(neighborCharIds);
	}

	private void OnPoisonAffected(DataContext context, int charId, sbyte poisonType)
	{
		if (charId == base.CharacterId && base.CanAffect)
		{
			CombatCharacter affectChar = (base.IsGood ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly) : base.CombatChar);
			CValuePercent factor = CFormula.CalcPowerFactor(base.RemainDuration);
			factor *= base.EffectConfig.GetPowerFactor();
			factor *= (CValueMultiplier)((base.IsGrown || !base.IsElite) ? 1 : 2);
			affectChar.AddMindDamageByMarkPercent(context, factor);
			ShowEffectTips(context, 1);
			if (base.IsElite)
			{
				ShowEffectTips(context, 2);
			}
			CostWugInCombat(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 295 || !base.CanAffect || !base.IsElite)
		{
			return 0;
		}
		return 900;
	}
}
