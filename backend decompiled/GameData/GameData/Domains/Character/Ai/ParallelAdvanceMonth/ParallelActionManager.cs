using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Common.WorkerThread;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth;

public class ParallelActionManager
{
	private const int MonitorIntervalOfAdvancingMonth = 100;

	private static ICharacterParallelAction _currAction;

	private static ICharacterParallelActionWithTarget _currActionWithTarget;

	public static void Execute(DataMonitorManager monitor, ICharacterParallelAction action)
	{
		if (action.IsEnabled)
		{
			_currAction = action;
			WorkerThreadManager.Run(OfflineExecuteCurrentAction, action.BeginAreaId, action.EndAreaId, monitor, 100);
			_currAction = null;
		}
	}

	public static void Execute(DataMonitorManager monitor, ICharacterParallelActionWithTarget action)
	{
		if (action.IsEnabled)
		{
			_currActionWithTarget = action;
			WorkerThreadManager.Run(OfflineExecuteCurrentActionWithTarget, action.BeginAreaId, action.EndAreaId, monitor, 100);
			_currActionWithTarget = null;
		}
	}

	private static void OfflineExecuteCurrentAction(DataContext context, int areaId)
	{
		OfflineExecuteCharacterActionsInArea(context, areaId, _currAction);
	}

	private static void OfflineExecuteCurrentActionWithTarget(DataContext context, int areaId)
	{
		OfflineExecuteCharacterActionsInArea(context, areaId, _currActionWithTarget);
	}

	private static void OfflineExecuteCharacterActionsInArea(DataContext context, int areaId, ICharacterParallelActionWithTarget action)
	{
		if (areaId < 0 || areaId >= 141)
		{
			throw new Exception($"Invalid area id for character parallel action with target: {areaId}");
		}
		Location taiwuLocation = (DomainManager.Adventure.GetAdventureTaiwu().InAdventure ? Location.Invalid : DomainManager.Taiwu.GetTaiwu().GetLocation());
		HashSet<int> interactableBlockCharSet = context.AdvanceMonthRelatedData.BlockCharSet.Occupy();
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks((short)areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			MapBlockData blockData = blocks[i];
			HashSet<int> charIds = blockData.CharacterSet;
			interactableBlockCharSet.Clear();
			if (charIds != null)
			{
				CharacterDomain.UnionWithInteractableCharacters(interactableBlockCharSet, charIds);
			}
			if (taiwuLocation.AreaId == blockData.AreaId && taiwuLocation.BlockId == blockData.BlockId)
			{
				HashSet<int> taiwuGroupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
				CharacterDomain.UnionWithInteractableCharacters(interactableBlockCharSet, taiwuGroupCharIds);
				foreach (int charId in taiwuGroupCharIds)
				{
					Character character = DomainManager.Character.GetElement_Objects(charId);
					if (!character.IsTaiwu())
					{
						action.Execute(context, character, interactableBlockCharSet);
					}
				}
			}
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId2 in charIds)
			{
				Character character2 = DomainManager.Character.GetElement_Objects(charId2);
				action.Execute(context, character2, interactableBlockCharSet);
			}
		}
		context.AdvanceMonthRelatedData.BlockCharSet.Release(ref interactableBlockCharSet);
	}

	private static void OfflineExecuteCharacterActionsInArea(DataContext context, int areaId, ICharacterParallelAction action)
	{
		if (areaId < 0)
		{
			switch (areaId)
			{
			case -1:
				OfflineExecuteCharacterActionsInArea_TaiwuGroup(context, action);
				break;
			case -2:
				OfflineExecuteCharacterActionsInArea_HiddenCharacters(context, action);
				break;
			default:
				throw new Exception($"Invalid area id for character parallel action: {areaId}");
			}
			return;
		}
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks((short)areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].CharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				Character character = DomainManager.Character.GetElement_Objects(charId);
				action.Execute(context, character);
				if (character.IsActiveExternalRelationState(2uL))
				{
					OfflineExecuteCharacterActionsInArea_KidnappedChars(context, charId, action);
				}
			}
		}
	}

	private static void OfflineExecuteCharacterActionsInArea_TaiwuGroup(DataContext context, ICharacterParallelAction action)
	{
		HashSet<int> charIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int charId in charIds)
		{
			Character character = DomainManager.Character.GetElement_Objects(charId);
			if (charId != DomainManager.Taiwu.GetTaiwuCharId())
			{
				action.TaiwuGroupExecute(context, character);
			}
			else
			{
				action.TaiwuExecute(context, character);
			}
			if (character.IsActiveExternalRelationState(2uL))
			{
				OfflineExecuteCharacterActionsInArea_KidnappedChars(context, charId, action);
			}
		}
		Dictionary<int, GearMate>.KeyCollection gearMateIds = DomainManager.Extra.GetAllGearMateId();
		foreach (int charId2 in gearMateIds)
		{
			Character character2 = DomainManager.Character.GetElement_Objects(charId2);
			action.GearMateExecute(context, character2);
		}
	}

	private static void OfflineExecuteCharacterActionsInArea_HiddenCharacters(DataContext context, ICharacterParallelAction action)
	{
		List<int> charIdList = new List<int>();
		DomainManager.Character.GetCrossAreaTravelingCharacterIds(charIdList);
		foreach (int charId in charIdList)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			if (character.GetLeaderId() == charId)
			{
				OfflineExecuteCharacterActionsInArea_HiddenGroupChars(context, charId, action);
			}
			if (!character.IsActiveExternalRelationState(188uL))
			{
				action.HiddenExecute(context, character);
				if (character.IsActiveExternalRelationState(2uL))
				{
					OfflineExecuteCharacterActionsInArea_KidnappedChars(context, charId, action);
				}
			}
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<int> charIdSet = new HashSet<int>();
		DomainManager.Adventure.CollectAllCharactersInAdventure(charIdSet);
		foreach (int charId2 in charIdSet)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId2, out var character2) || !character2.IsActiveExternalRelationState(188uL) || character2.GetKidnapperId() >= 0 || character2.GetLeaderId() == taiwuCharId)
			{
				continue;
			}
			Location location = character2.GetLocation();
			if (location.IsValid())
			{
				MapBlockData block = DomainManager.Map.GetBlock(location);
				if ((block.CharacterSet != null && block.CharacterSet.Contains(charId2)) || (block.InfectedCharacterSet != null && block.InfectedCharacterSet.Contains(charId2)))
				{
					continue;
				}
			}
			action.HiddenExecute(context, character2);
			if (character2.IsActiveExternalRelationState(2uL))
			{
				OfflineExecuteCharacterActionsInArea_KidnappedChars(context, charId2, action);
			}
		}
		for (sbyte i = 0; i < 15; i++)
		{
			sbyte orgTemplateId = OrganizationDomain.GetLargeSectTemplateId(i);
			Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
			for (int index = sect.Prison.Prisoners.Count - 1; index >= 0; index--)
			{
				SettlementPrisoner prisoner = sect.Prison.Prisoners[index];
				if (DomainManager.Character.TryGetElement_Objects(prisoner.CharId, out var character3))
				{
					action.PrisonerExecute(context, character3);
				}
			}
		}
	}

	private static void OfflineExecuteCharacterActionsInArea_HiddenGroupChars(DataContext context, int charId, ICharacterParallelAction action)
	{
		Tester.Assert(!DomainManager.Character.GetElement_Objects(charId).GetLocation().IsValid());
		HashSet<int> groupCharSet = DomainManager.Character.GetGroup(charId).GetCollection();
		foreach (int groupCharId in groupCharSet)
		{
			if (groupCharId == charId)
			{
				continue;
			}
			Character groupChar = DomainManager.Character.GetElement_Objects(groupCharId);
			if (!groupChar.IsActiveExternalRelationState(188uL))
			{
				action.HiddenExecute(context, groupChar);
				if (groupChar.IsActiveExternalRelationState(2uL))
				{
					OfflineExecuteCharacterActionsInArea_KidnappedChars(context, groupCharId, action);
				}
			}
		}
	}

	private static void OfflineExecuteCharacterActionsInArea_KidnappedChars(DataContext context, int kidnapperCharId, ICharacterParallelAction action)
	{
		List<KidnappedCharacter> kidnappedChars = DomainManager.Character.GetKidnappedCharacters(kidnapperCharId).GetCollection();
		int i = 0;
		for (int count = kidnappedChars.Count; i < count; i++)
		{
			int kidnappedCharId = kidnappedChars[i].CharId;
			Character kidnappedChar = DomainManager.Character.GetElement_Objects(kidnappedCharId);
			action.KidnappedExecute(context, kidnappedChar);
		}
	}
}
