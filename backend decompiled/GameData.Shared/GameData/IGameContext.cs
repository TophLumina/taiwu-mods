using System.Collections.Generic;
using GameData.Adventure;
using GameData.Combat.Math;
using GameData.Domains.Adventure;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.World;
using Redzen.Random;

namespace GameData;

public interface IGameContext
{
	IRandomSource Random { get; }

	string Language { get; }

	string DataPath { get; }

	bool DevOnlyPredefinedLog { get; }

	bool HideTaiwuOriginalSurname { get; }

	uint WorldId { get; }

	int TaiwuCharId { get; }

	sbyte TaiwuGender { get; }

	sbyte TaiwuDisplayingGender { get; }

	Location TaiwuLocation { get; }

	int CurrDate { get; }

	short MainStoryLineProgress { get; }

	byte WorldResourceAmountType { get; }

	sbyte XiangshuProgress { get; }

	bool NoProfessionSkillCooldown { get; }

	CValuePercent MoveTimeCostPercent { get; }

	TwelveImmortalsCacheData TwelveImmortalsCache { get; }

	ChallengeModeData ChallengeModeData { get; }

	short StockadeInStoryNameId => -2;

	IReadOnlyDictionary<int, string> CustomTexts { get; }

	AdventureCore AdventureCore { get; }

	bool IsProfessionalSkillUnlockedAndEquipped(int professionSkillTemplateId);

	ProfessionData GetProfessionData(int professionSkillTemplateId);

	bool GetWorldFunctionsStatus(byte worldFunctionType);

	byte GetAreaSize(short areaId);

	MapBlockData GetBlockData(Location location);

	IEnumerable<short> GetGroupBlockIds(Location rootLocation, MapBlockData rootBlock);

	bool IsTaskFinished(int taskInfoId);

	bool IsTaskInProgress(int taskInfoId);

	AdventureRuntime GetAdventure(int adventureId);

	AdventureMajorEvent GetMajorEvent(int majorEventId);

	IAdventureRuntime GetAny(int runtimeId)
	{
		IAdventureRuntime runtime = GetAdventure(runtimeId);
		if (runtime == null)
		{
			runtime = GetMajorEvent(runtimeId);
		}
		return runtime;
	}
}
