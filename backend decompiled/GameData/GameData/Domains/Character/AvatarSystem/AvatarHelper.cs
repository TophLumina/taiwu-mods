namespace GameData.Domains.Character.AvatarSystem;

public static class AvatarHelper
{
	public static void InitializeGrowableElementsShowingAbilitiesAndStates(this AvatarData avatarData, Character character)
	{
		avatarData.ClearGrowableElementShowingAbilities();
		if (character.IsAbleToGrowHair())
		{
			avatarData.SetGrowableElementShowingAbility(0);
		}
		short physiologicalAge = character.GetPhysiologicalAge();
		var (canGrowBeard1, canGrowBeard2) = character.IsAbleToGrowBeards(physiologicalAge);
		if (canGrowBeard1)
		{
			avatarData.SetGrowableElementShowingAbility(1);
		}
		if (canGrowBeard2)
		{
			avatarData.SetGrowableElementShowingAbility(2);
		}
		if (character.IsAbleToGrowWrinkle1(physiologicalAge))
		{
			avatarData.SetGrowableElementShowingAbility(3);
		}
		if (character.IsAbleToGrowWrinkle2(physiologicalAge))
		{
			avatarData.SetGrowableElementShowingAbility(4);
		}
		if (character.IsAbleToGrowWrinkle3(physiologicalAge))
		{
			avatarData.SetGrowableElementShowingAbility(5);
		}
		if (Character.IsAbleToGrowEyebrow())
		{
			avatarData.SetGrowableElementShowingAbility(6);
		}
		avatarData.FillGrowableElementsShowingStates();
	}

	public static bool UpdateGrowableElementsShowingAbilities(this AvatarData avatarData, Character character)
	{
		byte oriAbilities = avatarData.GetGrowableElementShowingAbilities();
		short physiologicalAge = character.GetPhysiologicalAge();
		var (canGrowBeard1, canGrowBeard2) = character.IsAbleToGrowBeards(physiologicalAge);
		avatarData.SetGrowableElementShowingAbility(1, canGrowBeard1);
		avatarData.SetGrowableElementShowingAbility(2, canGrowBeard2);
		avatarData.SetGrowableElementShowingAbility(3, character.IsAbleToGrowWrinkle1(physiologicalAge));
		avatarData.SetGrowableElementShowingAbility(4, character.IsAbleToGrowWrinkle2(physiologicalAge));
		avatarData.SetGrowableElementShowingAbility(5, character.IsAbleToGrowWrinkle3(physiologicalAge));
		return oriAbilities != avatarData.GetGrowableElementShowingAbilities();
	}
}
