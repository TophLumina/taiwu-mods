using System.Collections.Generic;
using GameData.Common;
using GameData.DLC;
using GameData.DomainEvents;
using GameData.Domains.Map;

namespace GameData.Domains.Character;

public static class PolymorphHelper
{
	public static int CreatePolymorphCharacter(DataContext context, short characterTemplateId)
	{
		Character character = DomainManager.Character.CreateFixedCharacter(context, characterTemplateId);
		int charId = character.GetId();
		DomainManager.Character.CompleteCreatingCharacter(charId);
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		DomainManager.Character.ConvertFixedCharacter(context, character, location, recreateAttributesAndQualifications: false);
		return charId;
	}

	public static void ResetPolymorphCharacter(DataContext context, int charId)
	{
		Character character = DomainManager.Character.GetElement_Objects(charId);
		character.ChangeCurrAge(context, 16 - character.GetCurrAge());
		Events.RaisePolymorphCharacterResetStatus(context, character);
		character.ChangeHealth(context, int.MaxValue);
		character.SetDisorderOfQi(DisorderLevelOfQi.MinValue, context);
		Injuries injuries = character.GetInjuries();
		injuries.Initialize();
		character.SetInjuries(injuries, context);
		PoisonInts poisoned = character.GetPoisoned();
		poisoned.Initialize();
		character.SetPoisoned(ref poisoned, context);
		character.ChangeXiangshuInfection(context, -2147483647);
		character.UpdateXiangshuInfectionState(context);
	}

	public static void PolymorphCharacterReturnToVoid(DataContext context, Character character)
	{
		DomainManager.Character.HideCharacterOnMap(context, character, 128uL, bringWards: false);
		ClearLegendaryBookStatus(context, character);
		ClearOrganizationStatus(context, character);
		ClearKidnapStatus(context, character);
	}

	public static void ClearLegendaryBookStatus(DataContext context, Character character)
	{
		DomainManager.LegendaryBook.OnCharacterDead(context, character);
		character.RemoveFeatureGroup(context, 214);
	}

	public static bool ClearOrganizationStatus(DataContext context, Character character)
	{
		if (character.GetOrganizationInfo().OrgTemplateId == 0)
		{
			return false;
		}
		DomainManager.Organization.ClearOrganizationStatus(context, character, charIsDead: false);
		character.SetOrganizationInfo(new OrganizationInfo(0, 0, principal: true, -1), context);
		return true;
	}

	public static void ClearKidnapStatus(DataContext context, Character character)
	{
		DomainManager.Character.RemoveAllKidnappedChars(context, character, isEscaped: true);
		int charId = character.GetId();
		int kidnapperId = character.GetKidnapperId();
		if (kidnapperId >= 0)
		{
			DomainManager.Character.RemoveKidnappedCharacter(context, charId, kidnapperId, isEscaped: true);
		}
		if (character.GetLeaderId() >= 0)
		{
			DomainManager.Character.LeaveGroup(context, character, bringWards: false);
		}
	}

	public static IEnumerable<Character> IterCharacters(this IEnumerable<IPolymorphRuntime> runtimes)
	{
		foreach (IPolymorphRuntime polymorph in runtimes)
		{
			if (DomainManager.Character.TryGetElement_Objects(polymorph.MaleCharacterId, out var male))
			{
				yield return male;
			}
			if (DomainManager.Character.TryGetElement_Objects(polymorph.FemaleCharacterId, out var female))
			{
				yield return female;
			}
			male = null;
			female = null;
		}
	}

	public static IEnumerable<Character> IterDeadCharacters(this IEnumerable<IPolymorphRuntime> runtimes)
	{
		foreach (IPolymorphRuntime polymorph in runtimes)
		{
			if (!polymorph.ContainsState(EPolymorphState.Male) && DomainManager.Character.TryGetElement_Objects(polymorph.MaleCharacterId, out var male))
			{
				yield return male;
			}
			if (!polymorph.ContainsState(EPolymorphState.Female) && DomainManager.Character.TryGetElement_Objects(polymorph.FemaleCharacterId, out var female))
			{
				yield return female;
			}
			male = null;
			female = null;
		}
	}
}
