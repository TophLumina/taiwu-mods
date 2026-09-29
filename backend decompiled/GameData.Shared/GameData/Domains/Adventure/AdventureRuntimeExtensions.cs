using GameData.Adventure;

namespace GameData.Domains.Adventure;

public static class AdventureRuntimeExtensions
{
	public static bool ContainsCharacter(this IAdventureRuntime runtime, int charId)
	{
		if (!runtime.IsTemporaryCharacter(charId))
		{
			return runtime.IsCalledCharacter(charId);
		}
		return true;
	}

	public static bool CallCharacters(this IAdventureRuntime runtime, IAdventureContextBridge context)
	{
		if (runtime.StatusType == EAdventureStatusType.Entered)
		{
			return false;
		}
		if (runtime.GetParameterOrDefault("ConchShipPresetKey_RemoveAfterCallCharacters", false).AsBool)
		{
			return false;
		}
		bool anyChanged = false;
		if (runtime.StatusType == EAdventureStatusType.Hide)
		{
			int autoStopDate = runtime.GetParameterOrDefault("ConchShipPresetKey_AutoStopHideDate", -1).Current;
			if (autoStopDate >= 0 && autoStopDate <= ExternalDataBridge.Context.CurrDate)
			{
				runtime.SetStatusType(context, EAdventureStatusType.Preparing);
				runtime.RemoveParameter("ConchShipPresetKey_AutoStopHideDate");
				anyChanged = true;
			}
		}
		if (runtime.StatusType == EAdventureStatusType.Hide && runtime.GetParameterOrDefault("ConchShipPresetKey_CallCharactersExceptHide", false).AsBool)
		{
			return anyChanged;
		}
		if (runtime.CallCharacters(context, EAdventureCharacterType.Necessary) && runtime.StatusType == EAdventureStatusType.Preparing)
		{
			runtime.SetStatusType(context, EAdventureStatusType.Ready);
		}
		runtime.CallCharacters(context, EAdventureCharacterType.NecessaryAutoCreate);
		runtime.CallCharacters(context, EAdventureCharacterType.Optional);
		return true;
	}

	public static bool AutoCheckSatisfied(this IAdventureRuntime runtime, IAdventureContextBridge context)
	{
		if (runtime.StatusType.IsActive())
		{
			return false;
		}
		int checkDate = runtime.GetParameterOrDefault("ConchShipPresetKey_AutoCheckSatisfiedDate", -1).Current;
		if (checkDate < 0 || checkDate > ExternalDataBridge.Context.CurrDate)
		{
			return false;
		}
		if (runtime.Satisfied)
		{
			AdventureParameterValue? param = runtime.GetParameterOrNull("ConchShipPresetKey_HidePrevStatus");
			EAdventureStatusType prevStatus = ((!param.HasValue) ? EAdventureStatusType.Ready : ((EAdventureStatusType)param.Value.Current));
			EAdventureStatusType currStatus = ((!prevStatus.IsActive()) ? EAdventureStatusType.Ready : prevStatus);
			runtime.SetStatusType(context, currStatus);
			runtime.RemoveParameter("ConchShipPresetKey_HidePrevStatus");
			runtime.RemoveParameter("ConchShipPresetKey_AutoCheckSatisfiedDate");
		}
		else
		{
			runtime.SetParameter("ConchShipPresetKey_RemoveAfterCallCharacters", true);
		}
		return true;
	}

	public static bool OfflineHide(this IAdventureRuntime runtime, IAdventureContextBridge context)
	{
		EAdventureStatusType statusType = runtime.StatusType;
		if (statusType - 3 <= EAdventureStatusType.Ready)
		{
			return false;
		}
		runtime.SetParameter("ConchShipPresetKey_HidePrevStatus", (int)runtime.StatusType);
		runtime.SetStatusType(context, EAdventureStatusType.Hide);
		return true;
	}

	public static bool OfflineUnhide(this IAdventureRuntime runtime, IAdventureContextBridge context)
	{
		if (runtime.StatusType != EAdventureStatusType.Hide)
		{
			return false;
		}
		if (runtime.TryGetParameter("ConchShipPresetKey_HidePrevStatus", out var prevStatus))
		{
			runtime.SetStatusType(context, (EAdventureStatusType)prevStatus.Current);
			runtime.RemoveParameter("ConchShipPresetKey_HidePrevStatus");
			return true;
		}
		return false;
	}
}
