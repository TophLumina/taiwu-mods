using System;
using Config;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.LifeSkillRandom;

public class LifeSkillCraftingAction : IGeneralAction
{
	public ItemKey ToolUsed;

	public ItemKey Material;

	public int RequiredMoney;

	public sbyte TargetItemType;

	public short TargetItemTemplateId;

	public sbyte LifeSkillType;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		Inventory inventory = selfChar.GetInventory();
		return inventory.Items.ContainsKey(ToolUsed) && inventory.Items.ContainsKey(Material) && selfChar.GetResource(6) >= RequiredMoney;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int selfCharId = selfChar.GetId();
		selfChar.ChangeResource(context, 6, -RequiredMoney);
		selfChar.RemoveInventoryItem(context, Material, 1, deleteItem: true);
		GameData.Domains.Item.CraftTool tool = DomainManager.Item.GetElement_CraftTools(ToolUsed.Id);
		CraftToolItem toolConfig = Config.CraftTool.Instance[ToolUsed.TemplateId];
		MaterialItem materialConfig = Config.Material.Instance[Material.TemplateId];
		short durabilityCost = toolConfig.DurabilityCost[materialConfig.Grade];
		short currDurability = tool.GetCurrDurability();
		if (currDurability <= durabilityCost)
		{
			selfChar.RemoveInventoryItem(context, ToolUsed, 1, deleteItem: true);
		}
		else
		{
			tool.ChangeCurrDurability(context, -durabilityCost);
		}
		ItemKey item = DomainManager.Item.CreateItem(context, TargetItemType, TargetItemTemplateId);
		selfChar.AddInventoryItem(context, item, 1);
		sbyte targetItemGrade = ItemTemplateHelper.GetGrade(TargetItemType, TargetItemTemplateId);
		if (targetItemGrade >= 6)
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications.AddMakeFamousItem(selfCharId, location, TargetItemType, TargetItemTemplateId);
			selfChar.RecordFameAction(context, 77, -1, 1);
		}
		lifeRecordCollection.AddMakeItem(selfCharId, currDate, location, TargetItemType, TargetItemTemplateId);
	}
}
