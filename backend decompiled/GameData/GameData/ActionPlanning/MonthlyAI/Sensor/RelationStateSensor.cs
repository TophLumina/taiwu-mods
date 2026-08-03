using GameData.Domains;
using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class RelationStateSensor : CharacterStateSensorBase
{
	public override int Sense(ContextArgGroupHandle args, Character selfChar, StateKey stateKey)
	{
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		CharacterSet faction;
		int result = stateTemplateId switch
		{
			287 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 8192), 
			607 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 1) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 64) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 8), 
			609 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 2) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 128) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 16), 
			608 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 4) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 256) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 32), 
			289 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 64) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 128) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 256), 
			290 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 1024), 
			291 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 512), 
			292 => DomainManager.Character.GetTwoWayRelatedCharacterCount(selfChar.GetId(), 16384), 
			293 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 16384), 
			294 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 32768), 
			288 => DomainManager.Organization.TryGetElement_Factions(selfChar.GetFactionId(), out faction) ? (faction.GetCount() - 1) : 0, 
			295 => DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 2048) + DomainManager.Character.GetRelatedCharacterCount(selfChar.GetId(), 4096), 
			_ => throw new ActionPlanningException($"Unimplemented planning state: {stateKey}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
