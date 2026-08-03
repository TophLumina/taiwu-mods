using System.Collections.Generic;
using GameData.Adventure;
using GameData.Combat.Math;
using GameData.Domains;
using GameData.Domains.Adventure;
using GameData.Domains.Global;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.World;
using Redzen.Random;

namespace GameData.Common;

public class GameContext : IGameContext
{
	public IRandomSource Random => DataContextManager.GetCurrentThreadDataContext().Random;

	public string Language => GlobalDomain.Settings.Language;

	public bool DevOnlyPredefinedLog => Program.IsTestBranch;

	public bool NoProfessionSkillCooldown => DomainManager.Extra.NoProfessionSkillCooldown;

	public ChallengeModeData ChallengeModeData => DomainManager.World.GetChallengeModeData();

	public uint WorldId => DomainManager.World.GetWorldId();

	public IReadOnlyDictionary<int, string> CustomTexts => DomainManager.World.GetCustomTexts();

	public string DataPath => "../The Scroll of Taiwu_Data";

	public bool HideTaiwuOriginalSurname => DomainManager.World.GetHideTaiwuOriginalSurname();

	public int TaiwuCharId => DomainManager.Taiwu.GetTaiwuCharId();

	public Location TaiwuLocation => DomainManager.Taiwu.GetTaiwu().GetLocation();

	public sbyte TaiwuGender => DomainManager.Taiwu.GetTaiwu().GetGender();

	public sbyte TaiwuDisplayingGender => DomainManager.Taiwu.GetTaiwu().GetDisplayingGender();

	public int CurrDate => DomainManager.World.GetCurrDate();

	public short MainStoryLineProgress => DomainManager.World.GetMainStoryLineProgress();

	public byte WorldResourceAmountType => DomainManager.World.GetWorldResourceAmountType();

	public sbyte XiangshuProgress => DomainManager.World.GetXiangshuProgress();

	public CValuePercent MoveTimeCostPercent => DomainManager.Taiwu.GetMoveTimeCostPercent();

	public TwelveImmortalsCacheData TwelveImmortalsCache => DomainManager.Character.GetTwelveImmortalsCache();

	public AdventureCore AdventureCore => AdventureDomain.Core;

	public bool IsProfessionalSkillUnlockedAndEquipped(int professionSkillTemplateId)
	{
		return DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(professionSkillTemplateId);
	}

	public ProfessionData GetProfessionData(int professionSkillTemplateId)
	{
		return DomainManager.Extra.GetProfessionData(professionSkillTemplateId);
	}

	public bool GetWorldFunctionsStatus(byte worldFunctionType)
	{
		return DomainManager.World.GetWorldFunctionsStatus(worldFunctionType);
	}

	public byte GetAreaSize(short areaId)
	{
		return DomainManager.Map.GetAreaSize(areaId);
	}

	public MapBlockData GetBlockData(Location location)
	{
		MapBlockData data;
		return DomainManager.Map.TryGetBlock(location, out data) ? data : null;
	}

	public IEnumerable<short> GetGroupBlockIds(Location rootLocation, MapBlockData rootBlock)
	{
		if (rootBlock.GroupBlockList == null)
		{
			yield break;
		}
		foreach (MapBlockData groupBlock in rootBlock.GroupBlockList)
		{
			yield return groupBlock.BlockId;
		}
	}

	public bool IsTaskFinished(int taskInfoId)
	{
		return DomainManager.World.IsTaskFinished(taskInfoId);
	}

	public bool IsTaskInProgress(int taskInfoId)
	{
		return DomainManager.World.IsTaskInProgress(taskInfoId);
	}

	public AdventureRuntime GetAdventure(int adventureId)
	{
		AdventureRuntime adventure;
		return DomainManager.Adventure.TryGetElement_Adventures(adventureId, out adventure) ? adventure : null;
	}

	public AdventureMajorEvent GetMajorEvent(int majorEventId)
	{
		AdventureMajorEvent majorEvent;
		return DomainManager.Adventure.TryGetElement_AdventureMajorEvents(majorEventId, out majorEvent) ? majorEvent : null;
	}
}
