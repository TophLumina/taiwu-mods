namespace GameData.Domains.Adventure;

public static class AdventureConstants
{
	public const string AdventureId = "ConchShipPresetKey_AdventureId";

	public const string ElementId = "ConchShipPresetKey_ElementId";

	public const string TemporaryItemKey = "ConchShipPresetKey_TemporaryItemKey";

	public const string BlockIndex = "ConchShipPresetKey_BlockIndex";

	public const string TimeCosted = "ConchShipPresetKey_CostedTime";

	public const string FinishedAction = "ConchShipPresetKey_FinishedAction";

	public const string MajorCharacter = "MajorCharacter_";

	public const string ParticipateCharacter = "ParticipateCharacter_";

	public const string EnterItems = "EnterItems_";

	public const string MajorEvent = "ConchShipPresetKey_MajorEvent";

	public const string MajorEventAtmosphereType = "ConchShipPresetKey_MajorEventAtmosphereType";

	public const string IsTimeout = "ConchShipPresetKey_IsTimeout";

	public const string IsRunning = "ConchShipPresetKey_IsRunning";

	public const string RemoveType = "ConchShipPresetKey_RemoveType";

	public const string AdventureGlobalParticle = "ConchShipPresetKey_Adventure_Global_Particle";

	public const string ViewType = "view_range_";

	public const string ViewTypeNear = "view_range_0";

	public const string ViewTypeFar = "view_range_1";

	public const string CustomTextInvoked = "ConchShipPresetKey_CustomTextInvoked_";

	public const string CharacterDefineGrade = "ConchShipPresetKey_CharacterDefineGrade";

	public const string MartialArtTournamentHost = "MainOrg";

	public const int ViewTypeDefaultValueNear = 1;

	public const int ViewTypeDefaultValueFar = 3;

	public const int ParameterStyleTaiwu = 0;

	public const int ParameterStyleGlobal = 1;

	public const int ParameterStyleGlobalReverse = 2;

	public const int ParameterStyleInfluenceManhattan = 0;

	public const int ParameterStyleInfluenceRegionBox = 1;

	public const string CallCharacterCountLimit = "ConchShipPresetKey_CallCharacterCountLimit";

	public const string CallCharactersExceptHide = "ConchShipPresetKey_CallCharactersExceptHide";

	public const string AutoStopHideDate = "ConchShipPresetKey_AutoStopHideDate";

	public const string AutoCheckSatisfiedDate = "ConchShipPresetKey_AutoCheckSatisfiedDate";

	public const string RemoveAfterCallCharacters = "ConchShipPresetKey_RemoveAfterCallCharacters";

	public const string HidePrevStatus = "ConchShipPresetKey_HidePrevStatus";

	public const string FollowTargetBlockIndex = "ConchShipPresetKey_FollowTargetBlockIndex";

	public const string FollowTargetElementId = "ConchShipPresetKey_FollowTargetElementId";

	public const string TaskCount = "ConchShipPresetKey_Task_Count";

	public const string KidnappingElement = "CSPreset_Kidnapping";

	public const string AvoidDeathElement = "AvoidDeathInAdvanceMonth";

	public const string BlockIconDefault = "adventure_block_default";

	public const string LocalStringPackName = "AdventureCore_language";

	public static string TaskKey(int index)
	{
		return "ConchShipPresetKey_Task_" + index;
	}
}
