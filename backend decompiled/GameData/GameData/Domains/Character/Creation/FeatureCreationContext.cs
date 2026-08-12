using System.Collections.Generic;
using Config;

namespace GameData.Domains.Character.Creation;

public struct FeatureCreationContext
{
	public List<short> FeatureIds;

	public List<short> PotentialFeatureIds;

	public sbyte Gender;

	public sbyte BirthMonth;

	public short CurrAge;

	public PregnantState PregnantState;

	public Character Mother;

	public Character Father;

	public DeadCharacter DeadFather;

	public bool RandomFeaturesAtCreating;

	public short PotentialFeaturesAge;

	public int DestinyType;

	public bool AllGoodBasicFeature;

	public bool IsProtagonist;

	public FeatureCreationContext(Character character, ref IntelligentCharacterCreationInfo charCreationInfo)
	{
		FeatureIds = character.GetFeatureIds();
		PotentialFeatureIds = character.GetPotentialFeatureIds();
		Mother = charCreationInfo.Mother;
		Father = charCreationInfo.ActualFather;
		DeadFather = charCreationInfo.ActualDeadFather;
		PregnantState = charCreationInfo.PregnantState;
		Gender = character.GetGender();
		BirthMonth = character.GetBirthMonth();
		CurrAge = character.GetCurrAge();
		PotentialFeaturesAge = (short)((AgeGroup.GetAgeGroup(CurrAge) != 2) ? CurrAge : (-1));
		DestinyType = charCreationInfo.DestinyType;
		RandomFeaturesAtCreating = Config.Character.Instance[charCreationInfo.CharTemplateId].RandomFeaturesAtCreating;
		AllGoodBasicFeature = false;
		IsProtagonist = false;
	}

	public FeatureCreationContext(Character character)
	{
		FeatureIds = character.GetFeatureIds();
		PotentialFeatureIds = character.GetPotentialFeatureIds();
		Mother = null;
		Father = null;
		DeadFather = null;
		PregnantState = null;
		Gender = character.GetGender();
		BirthMonth = character.GetBirthMonth();
		CurrAge = character.GetCurrAge();
		PotentialFeaturesAge = (short)((AgeGroup.GetAgeGroup(CurrAge) != 2) ? CurrAge : (-1));
		RandomFeaturesAtCreating = Config.Character.Instance[character.GetTemplateId()].RandomFeaturesAtCreating;
		DestinyType = -1;
		AllGoodBasicFeature = false;
		IsProtagonist = false;
	}
}
