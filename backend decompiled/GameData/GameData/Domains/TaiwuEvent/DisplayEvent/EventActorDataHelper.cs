using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using Redzen.Random;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public static class EventActorDataHelper
{
	public static EventActorData CreateActor(IRandomSource random, short templateId)
	{
		EventActorData actor = new EventActorData();
		actor.TemplateId = templateId;
		EventActorsItem config = EventActors.Instance[templateId];
		if (string.IsNullOrEmpty(config.Name))
		{
			actor.FullName = CharacterDomain.GenerateRandomHanName(random, -1, -1, actor.Gender, -1);
		}
		actor.Gender = config.Gender;
		if (actor.Gender == -1)
		{
			actor.Gender = Gender.GetRandom(random);
		}
		actor.Age = (byte)random.Next(config.Age[0], config.Age[1] + 1);
		short attraction = (short)random.Next(config.Attraction[0], config.Attraction[1] + 1);
		actor.AvatarData = AvatarManager.Instance.GetRandomAvatar(random, actor.Gender, transgender: false, config.PresetBodyType, attraction);
		actor.UpdateDisplayName();
		if (!string.IsNullOrEmpty(config.Texture))
		{
			return actor;
		}
		actor.ClothDisplayId = AvatarManager.Instance.GetAvatarGroup(actor.AvatarData.AvatarId).GetRandomCloth(random, canCreateOnly: true);
		if (actor.Age < 16)
		{
			if (actor.Age < GlobalConfig.Instance.AgeBaby)
			{
				actor.ClothDisplayId = (short)random.Next(1, 10);
			}
			else
			{
				actor.ClothDisplayId = AvatarManager.Instance.GetRandomChildClothIdByAvatarId(random, actor.AvatarData.AvatarId);
			}
			actor.AvatarData.ClothDisplayId = actor.ClothDisplayId;
		}
		if (-1 != config.Clothing)
		{
			ClothingItem clothingItem = Clothing.Instance[config.Clothing];
			actor.ClothDisplayId = clothingItem.DisplayId;
		}
		if (!config.IsMonk)
		{
			actor.AvatarData.SetGrowableElementShowingState(0, show: true);
			actor.AvatarData.SetGrowableElementShowingAbility(0, showable: true);
		}
		bool canGrowBeard = actor.Gender == 1;
		actor.AvatarData.SetGrowableElementShowingState(1, canGrowBeard && actor.Age >= GlobalConfig.Instance.AgeShowBeard1);
		actor.AvatarData.SetGrowableElementShowingAbility(1, canGrowBeard);
		actor.AvatarData.SetGrowableElementShowingState(2, canGrowBeard && actor.Age >= GlobalConfig.Instance.AgeShowBeard2);
		actor.AvatarData.SetGrowableElementShowingAbility(2, canGrowBeard);
		actor.AvatarData.SetGrowableElementShowingState(3, actor.Age >= GlobalConfig.Instance.AgeShowWrinkle1);
		actor.AvatarData.SetGrowableElementShowingAbility(3, showable: true);
		actor.AvatarData.SetGrowableElementShowingState(4, actor.Age >= GlobalConfig.Instance.AgeShowWrinkle2);
		actor.AvatarData.SetGrowableElementShowingAbility(4, showable: true);
		actor.AvatarData.SetGrowableElementShowingState(5, actor.Age >= GlobalConfig.Instance.AgeShowWrinkle3);
		actor.AvatarData.SetGrowableElementShowingAbility(5, showable: true);
		return actor;
	}

	public static void SetSurName(this EventActorData actor, FullName fullName)
	{
		actor.FullName = DomainManager.Character.GenerateRandomChildName(DomainManager.TaiwuEvent.MainThreadDataContext, actor.Gender, fullName);
		actor.UpdateDisplayName();
	}

	private static void UpdateDisplayName(this EventActorData actor)
	{
		EventActorsItem config = EventActors.Instance[actor.TemplateId];
		if (!string.IsNullOrEmpty(config.Name))
		{
			actor.DisplayName = config.Name;
			return;
		}
		IReadOnlyDictionary<int, string> customTexts = DomainManager.World.GetCustomTexts();
		(string, string) name = actor.FullName.GetName(actor.Gender, customTexts);
		string surName = name.Item1;
		string givenName = name.Item2;
		actor.DisplayName = surName + givenName;
	}
}
