using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public static class CombatResultHelper
{
	public static void Reset(this CombatResultDisplayData displayData)
	{
		displayData.CombatStatus = -1;
		displayData.SnapshotBeforeCombat = CreateSnapshot();
		displayData.Exp = 0;
		displayData.Resource.Initialize();
		displayData.AreaSpiritualDebt = 0;
		displayData.ShowReadingEvent = false;
		displayData.EvaluationList?.Clear();
		displayData.ItemList?.Clear();
		displayData.CharList?.Clear();
		displayData.LegacyTemplateIds?.Clear();
		displayData.ChangedProficiencies?.Clear();
		displayData.ChangedProficienciesDelta?.Clear();
		displayData.ItemSrcCharDict?.Clear();
	}

	public static CombatResultSnapshot CreateSnapshot()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuId = taiwu.GetId();
		short areaId = (taiwu.GetLocation().IsValid() ? taiwu.GetLocation().AreaId : taiwu.GetValidLocation().AreaId);
		return new CombatResultSnapshot
		{
			Exp = taiwu.GetExp(),
			Resource = taiwu.GetResources(),
			AreaSpiritualDebt = DomainManager.Extra.GetAreaSpiritualDebt(areaId),
			CanEatingMaxCount = taiwu.GetCurrMaxEatingSlotsCount(),
			EatingItemList = taiwu.GetEatingItems(),
			Injuries = taiwu.GetInjuries(),
			Poisons = taiwu.GetPoisoned(),
			PoisonResists = taiwu.GetPoisonResists(),
			ImmunePoisonExtra = DomainManager.Extra.GetPoisonImmunities(taiwuId),
			MainAttribute = taiwu.GetMainAttributesRecoveries(),
			DisorderOfQi = taiwu.GetDisorderOfQi(),
			ChangeOfQiDisorder = taiwu.GetChangeOfQiDisorder().total,
			TemplateId = taiwu.Template.TemplateId,
			DisplayAge = DomainManager.Character.GetDisplayingAge(taiwuId),
			ActualAge = taiwu.GetActualAge(),
			BirthMonth = taiwu.GetBirthMonth(),
			Health = taiwu.GetHealth(),
			LeftMaxHealth = taiwu.GetLeftMaxHealth(),
			HealthRecovery = taiwu.GetHealthRecovery(taiwu.IsCompletelyInfected()).total,
			CreatingType = taiwu.GetCreatingType()
		};
	}
}
