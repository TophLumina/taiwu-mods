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

	/// <summary>
	/// The Scroll of Taiwu_Data 的路径.
	/// </summary>
	string DataPath { get; }

	/// <summary>
	/// 显示内部开发版本的预设异常调试Log
	/// </summary>
	bool DevOnlyPredefinedLog { get; }

	bool HideTaiwuOriginalSurname { get; }

	/// <summary>
	/// 世界Id，用于获取一些世界相关的随机表现（比如毁坏地区样式）
	/// </summary>
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

	/// <summary>
	/// 玄狱数据
	/// </summary>
	ChallengeModeData ChallengeModeData { get; }

	/// <summary>
	/// 亡流寨name id，用于判定要不要优先返回“亡流寨”
	/// </summary>
	short StockadeInStoryNameId => -2;

	IReadOnlyDictionary<int, string> CustomTexts { get; }

	AdventureCore AdventureCore { get; }

	bool IsProfessionalSkillUnlockedAndEquipped(int professionSkillTemplateId);

	/// <summary>
	/// 志向数据
	/// </summary>
	/// <param name="professionSkillTemplateId"></param>
	/// <returns></returns>
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
