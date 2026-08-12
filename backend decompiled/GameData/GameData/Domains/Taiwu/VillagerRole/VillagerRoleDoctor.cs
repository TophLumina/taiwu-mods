using System;
using System.Collections.Generic;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleDoctor : VillagerRoleBase, IVillagerRoleArrangementExecutor, IVillagerRoleSelectLocation
{
	public override short RoleTemplateId => 2;

	public sbyte InteractTargetGrade
	{
		get
		{
			int grade = VillagerRoleFormula.DefValue.DoctorInteractTargetGrade.Calculate(base.Personality);
			int maxGrade = VillagerRoleFormula.DefValue.DoctorInteractTargetMaxGrade.Calculate(DomainManager.World.GetMaxGradeOfXiangshuInfection());
			return (sbyte)Math.Min(grade, maxGrade);
		}
	}

	public int HealXiangshuInfectionAmount => VillagerRoleFormula.DefValue.DoctorChickenUpgradeInfectionChangeAmount.Calculate(MaxHealingAttainment, base.Personality);

	public int MaxHealingAttainment => Math.Max(Character.GetLifeSkillAttainment(8), Character.GetLifeSkillAttainment(9));

	public int AutoActionAuthorityIncome(GameData.Domains.Character.Character targetChar)
	{
		VillagerRoleFormulaItem baseFormula = VillagerRoleFormula.Instance[7];
		VillagerRoleFormulaItem adjustFormula = VillagerRoleFormula.Instance[8];
		int authorityThreshold = targetChar.GetAdjustedResourceSatisfyingAmount(7);
		int healingAttainment = MaxHealingAttainment;
		int baseValue = baseFormula.Calculate(authorityThreshold, healingAttainment);
		return adjustFormula.Calculate(baseValue);
	}

	public int CalcPrioritizeActionSpiritualDebtIncome(sbyte targetGrade)
	{
		return VillagerRoleFormula.DefValue.DoctorWorkSpiritualDebtIncome.Calculate(targetGrade, MaxHealingAttainment);
	}

	void IVillagerRoleArrangementExecutor.ExecuteArrangementAction(DataContext context)
	{
		Location location = Character.GetLocation();
		MapBlockData targetBlock = DomainManager.Map.GetBlock(location);
		HashSet<int> characterSet = targetBlock.CharacterSet;
		if (characterSet == null || characterSet.Count <= 1)
		{
			return;
		}
		sbyte targetGrade = InteractTargetGrade;
		bool hasChickenUpgrade = base.HasChickenUpgradeEffect;
		GameData.Domains.Character.Character targetChar = Character.SelectRandomActionTarget(context, targetBlock.CharacterSet, Condition, includeBabies: true);
		if (targetChar == null)
		{
			return;
		}
		Span<sbyte> span = stackalloc sbyte[5];
		SpanList<sbyte> actionTypes = span;
		GetValidActionTypes(targetChar, ref actionTypes);
		if (hasChickenUpgrade && targetChar.GetXiangshuInfection() >= 100)
		{
			actionTypes.Add(4);
		}
		if (actionTypes.Count > 0)
		{
			int docId = Character.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			int income = CalcPrioritizeActionSpiritualDebtIncome(targetChar.GetInteractionGrade());
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			lifeRecordCollection.AddVillagerTreatment1(docId, currDate, targetChar.GetId(), location);
			lifeRecordCollection.AddVillagerTreatmentTaiwu(DomainManager.Taiwu.GetTaiwuCharId(), currDate, docId, location, income);
			sbyte actionType = actionTypes.GetRandom(context.Random);
			if (actionType == 4)
			{
				targetChar.ChangeXiangshuInfection(context, -HealXiangshuInfectionAmount);
				lifeRecordCollection.AddVillagerReduceXiangshuInfect(targetChar.GetId(), currDate);
			}
			else
			{
				Character.DoHealAction(context, (EHealActionType)actionType, targetChar);
			}
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, income);
		}
		bool Condition(GameData.Domains.Character.Character character)
		{
			if (character.GetInteractionGrade() > targetGrade)
			{
				return false;
			}
			if (HealActionCharacterFilter(character))
			{
				return true;
			}
			if (hasChickenUpgrade)
			{
				byte infection = character.GetXiangshuInfection();
				if (infection >= 100)
				{
					return true;
				}
			}
			return false;
		}
	}

	bool IVillagerRoleSelectLocation.NextLocationFilter(MapBlockData block)
	{
		if (block.CharacterSet == null)
		{
			return false;
		}
		bool hasChickenUpgrade = base.HasChickenUpgradeEffect;
		using (HashSet<int>.Enumerator enumerator = block.CharacterSet.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				int charId = enumerator.Current;
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (HealActionCharacterFilter(character))
				{
					return true;
				}
				if (hasChickenUpgrade)
				{
					byte infection = character.GetXiangshuInfection();
					if (infection >= 100)
					{
						return true;
					}
				}
				return false;
			}
		}
		return false;
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId < 0 && (WorkData == null || WorkData.WorkType != 1) && base.AutoActionStates[4])
		{
			TryAddNextAutoTravelTarget(context, AutoActionBlockFilter);
			AutoCureForAuthorityAction(context);
		}
	}

	private bool AutoCureForAuthorityAction(DataContext context)
	{
		Location location = Character.GetLocation();
		sbyte targetGrade = InteractTargetGrade;
		MapBlockData block = DomainManager.Map.GetBlock(location);
		Span<sbyte> span = stackalloc sbyte[5];
		SpanList<sbyte> actionTypes = span;
		int docId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (block.CharacterSet == null)
		{
			return false;
		}
		foreach (int charId in block.CharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetInteractionGrade() <= targetGrade)
			{
				GetValidActionTypes(character, ref actionTypes);
				if (actionTypes.Count > 0)
				{
					EHealActionType actionType = (EHealActionType)actionTypes.GetRandom(context.Random);
					Character.DoHealAction(context, actionType, character);
					int income = AutoActionAuthorityIncome(character);
					DomainManager.Taiwu.AddResource(context, ItemSourceType.Resources, 7, income);
					lifeRecordCollection.AddVillagerTreatment0(docId, currDate, charId, location, income, 7);
					return true;
				}
			}
		}
		return false;
	}

	private void GetValidActionTypes(GameData.Domains.Character.Character character, ref SpanList<sbyte> actionTypes)
	{
		IReadOnlyList<EHealActionType> allActionTypes = GameData.Domains.Character.Character.AllHealActions;
		foreach (EHealActionType actionType in allActionTypes)
		{
			if (CanHeal(character, actionType))
			{
				actionTypes.Add((sbyte)actionType);
			}
		}
	}

	private bool AutoActionBlockFilter(MapBlockData blockData)
	{
		if (blockData.CharacterSet == null)
		{
			return false;
		}
		sbyte interactTargetGrade = InteractTargetGrade;
		foreach (int charId in blockData.CharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetInteractionGrade() > interactTargetGrade || !HealActionCharacterFilter(character))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private bool HealActionCharacterFilter(GameData.Domains.Character.Character character)
	{
		IReadOnlyList<EHealActionType> actionTypes = GameData.Domains.Character.Character.AllHealActions;
		foreach (EHealActionType actionType in actionTypes)
		{
			if (CanHeal(character, actionType))
			{
				return true;
			}
		}
		return false;
	}

	private bool CanHeal(GameData.Domains.Character.Character character, EHealActionType actionType)
	{
		if (1 == 0)
		{
		}
		int maxRequireAttainment = actionType switch
		{
			EHealActionType.Healing => character.GetInjuries().GetSum(), 
			EHealActionType.Detox => character.GetPoisonMarkCount(), 
			EHealActionType.Breathing => character.GetDisorderOfQi(), 
			EHealActionType.Recover => 100 - character.GetHealth() * 100 / Math.Max(1, (int)character.GetLeftMaxHealth()), 
			_ => throw new ArgumentOutOfRangeException("actionType", actionType, null), 
		};
		if (1 == 0)
		{
		}
		int value = maxRequireAttainment;
		return value >= VillagerRoleFormula.DefValue.DoctorCureRequirement.Calculate((int)actionType) && Character.CalcHealEffect(actionType, character, out maxRequireAttainment) > 0;
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new HealingDisplayData
		{
			InteractTargetGrade = InteractTargetGrade,
			HealXiangshuInfectionAmount = HealXiangshuInfectionAmount
		};
	}
}
