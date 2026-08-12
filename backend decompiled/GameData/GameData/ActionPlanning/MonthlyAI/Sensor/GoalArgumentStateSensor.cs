using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class GoalArgumentStateSensor : CharacterStateSensorBase
{
	public override int Sense(ContextArgGroupHandle args, Character selfChar, StateKey stateKey)
	{
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		Grave grave;
		Grave grave2;
		int result = stateTemplateId switch
		{
			0 => args.Amount, 
			1 => args.Amount, 
			3 => args.Amount, 
			4 => args.Amount, 
			2 => ItemTemplateHelper.GetBaseValue(args.ItemType, args.ItemTemplateId) * 2 * selfChar.GetOrganizationInfo().GetOrgMemberConfig().PurchaseItemDiscount / 100, 
			602 => (ItemTemplateHelper.CanMakeArtisanOrder(args.ItemType, args.ItemTemplateId) && ItemTemplateHelper.GetCraftRequiredLifeSkillType(args.ItemType, args.ItemTemplateId) >= 0).ToInt(), 
			603 => DomainManager.Extra.IsItemSubTypeSubscribed(selfChar.GetId(), ItemTemplateHelper.GetItemSubType(args.ItemType, args.ItemTemplateId)).ToInt(), 
			432 => DomainManager.Character.TryGetElement_Graves(args.GraveId, out grave) ? grave.GetDurability() : int.MinValue, 
			433 => DomainManager.Character.TryGetElement_Graves(args.GraveId, out grave2) ? GlobalConfig.Instance.GraveDurabilities[grave2.GetLevel()] : int.MinValue, 
			394 => ((int?)DomainManager.Item.TryGetBaseItem(args.ItemType, args.ItemId)?.GetCurrDurability()) ?? int.MinValue, 
			395 => ((int?)DomainManager.Item.TryGetBaseItem(args.ItemType, args.ItemId)?.GetMaxDurability()) ?? int.MinValue, 
			392 => ((int?)DomainManager.Item.TryGetBaseItem(args.ItemType, args.ItemId)?.GetGrade()) ?? int.MinValue, 
			610 => ((DomainManager.Item.TryGetBaseItem(args.ItemType, args.ItemId)?.GetItemSubType() ?? (-1)) == 1001).ToInt(), 
			611 => ((DomainManager.Item.TryGetBaseItem(args.ItemType, args.ItemId)?.GetItemSubType() ?? (-1)) == 1000).ToInt(), 
			_ => throw new ActionPlanningException($"Unimplemented planning state: {stateKey}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
