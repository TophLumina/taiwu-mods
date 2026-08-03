using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormBase : WugEffectBase
{
	private static readonly Dictionary<sbyte, short> WugType2SkillId = new Dictionary<sbyte, short>
	{
		[0] = 454,
		[1] = 455,
		[2] = 456,
		[3] = 457,
		[4] = 458,
		[5] = 459,
		[6] = 460,
		[7] = 461
	};

	private int ConsummateLevelBonusAddPercent => base.IsElite ? (base.IsGood ? 50 : (-50)) : 0;

	private int AddCombatStatePower => base.IsGrown ? 200 : 100;

	private static int CalcPoisonRatio(bool isGrown)
	{
		return isGrown ? 10 : 5;
	}

	protected GoldenSilkwormBase()
	{
	}

	protected GoldenSilkwormBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 16;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsGrown)
		{
			CreateAffectedData(266, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(296, EDataModifyType.TotalPercent, -1);
		}
		Events.RegisterHandler_AdvanceMonthBegin(OnAdvanceMonthBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AdvanceMonthBegin(OnAdvanceMonthBegin);
		base.OnDisable(context);
	}

	private void OnAdvanceMonthBegin(DataContext context)
	{
		if (!base.CanAffect)
		{
			return;
		}
		EatingItems eatingItems = CharObj.GetEatingItems();
		if (base.IsGrown && base.IsElite)
		{
			List<sbyte> grownWugTypes = ObjectPool<List<sbyte>>.Instance.Get();
			for (sbyte wugType = 0; wugType < 8; wugType++)
			{
				int index = eatingItems.IndexOfWug(wugType);
				if (wugType != WugConfig.WugType && index >= 0)
				{
					MedicineItem wugConfig = Config.Medicine.Instance[eatingItems.Get(index).TemplateId];
					if (wugConfig.WugGrowthType == 4)
					{
						grownWugTypes.Add(wugType);
					}
				}
			}
			if (grownWugTypes.Count > 0)
			{
				EatWug(context, grownWugTypes.GetRandom(context.Random), eatGrown: true);
			}
		}
		else if (base.CanChangeToGrown && !eatingItems.ContainsAny())
		{
			ChangeToGrown(context);
		}
	}

	public override void OnEffectAdded(DataContext context, short replacedWug)
	{
		if (base.CanAffect)
		{
			bool affected = false;
			for (sbyte wugType = 0; wugType < 8; wugType++)
			{
				affected = EatWug(context, wugType) || affected;
			}
			if (affected)
			{
				OnAffected(context);
			}
		}
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		Events.RegisterHandler_AddWug(OnAddWug);
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		Events.UnRegisterHandler_AddWug(OnAddWug);
	}

	private void OnAddWug(DataContext context, int charId, short wugTemplateId, short replacedWug)
	{
		if (charId == base.CharacterId && base.CanAffect)
		{
			MedicineItem wugConfig = Config.Medicine.Instance[wugTemplateId];
			if (EatWug(context, wugConfig.WugType))
			{
				OnAffected(context);
			}
		}
	}

	private bool EatWug(DataContext context, sbyte wugType, bool eatGrown = false)
	{
		if (wugType == WugConfig.WugType)
		{
			return false;
		}
		EatingItems eatingItems = CharObj.GetEatingItems();
		int wugIndex = eatingItems.IndexOfWug(wugType);
		if (wugIndex < 0)
		{
			return false;
		}
		short wugTemplateId = eatingItems.Get(wugIndex).TemplateId;
		MedicineItem wugConfig = Config.Medicine.Instance[wugTemplateId];
		if (!eatGrown && !WugGrowthType.IsWugGrowthTypeCombatOnly(wugConfig.WugGrowthType))
		{
			return false;
		}
		CharObj.RemoveWug(context, wugTemplateId);
		bool isGrown = wugConfig.WugGrowthType == 4;
		int poisonRatio = CalcPoisonRatio(isGrown);
		EatOtherWugEffect(context, wugConfig.WugType, poisonRatio);
		if (isGrown)
		{
			LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
			AddLifeRecord((LifeRecordAddTemplate<sbyte, short>)lifeRecord.AddWugKingGoldenSilkwormEatGrownWug, (sbyte)8, wugTemplateId);
		}
		else if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			sbyte stateType = (sbyte)(base.IsGood ? 1 : 2);
			short stateId = (short)(base.IsGood ? 251 : 252);
			DomainManager.Combat.AddCombatState(context, base.CombatChar, stateType, stateId, AddCombatStatePower);
			ShowEffectTips(context, 3);
		}
		return true;
	}

	private unsafe void EatOtherWugEffect(DataContext context, sbyte foodWugType, int poisonRatio)
	{
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[WugType2SkillId[foodWugType]];
		PoisonsAndLevels skillPoisons = skillConfig.Poisons;
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			int value = skillPoisons.Values[poisonType] * poisonRatio;
			sbyte level = skillPoisons.Levels[poisonType];
			if (level > 0)
			{
				if (DomainManager.Combat.IsInCombat())
				{
					if (base.IsGood)
					{
						DomainManager.Combat.ReducePoison(context, base.CombatChar, poisonType, value);
					}
					else
					{
						DomainManager.Combat.AddPoison(context, base.CombatChar, base.CombatChar, poisonType, level, value, -1);
					}
				}
				else if (base.IsGood)
				{
					CharObj.ChangePoisoned(context, poisonType, 3, -value);
				}
				else
				{
					CharObj.ChangePoisoned(context, poisonType, 3, value);
				}
			}
		}
	}

	private void OnAffected(DataContext context)
	{
		ShowEffectTips(context, 1);
		ShowEffectTips(context, 2);
		CostWugInCombat(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 296 || !base.CanAffect || !base.IsElite)
		{
			return 0;
		}
		return ConsummateLevelBonusAddPercent;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 266 || !base.CanAffect)
		{
			return dataValue;
		}
		return true;
	}
}
