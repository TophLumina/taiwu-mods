using System;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.World.Notification;

namespace GameData.Domains.TaiwuEvent.EventOption;

public static class OptionConsumeHelper
{
	public static bool HasConsumeResource(this OptionConsumeInfo info, int taiwuId, int targetId)
	{
		if (info.ConsumeType == 8)
		{
			return DomainManager.World.GetLeftDaysInCurrMonth() >= info.ConsumeCount;
		}
		if (info.ConsumeType == 18)
		{
			return DomainManager.Extra.GetTotalActionPointsRemaining() >= info.ConsumeCount;
		}
		if (info.ConsumeType == 9 && DomainManager.Character.TryGetElement_Objects(targetId, out var target) && target != null)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(target.GetOrganizationInfo().SettlementId);
			return DomainManager.Extra.GetAreaSpiritualDebt(settlement.GetLocation().AreaId) >= info.ConsumeCount;
		}
		if (DomainManager.Character.TryGetElement_Objects(taiwuId, out var taiwu))
		{
			if (info.ConsumeType == 10)
			{
				return DomainManager.Extra.GetAreaSpiritualDebt(taiwu.GetLocation().AreaId) >= info.ConsumeCount;
			}
			sbyte consumeType = info.ConsumeType;
			if (consumeType >= 0 && consumeType < 8)
			{
				return taiwu.GetResource(info.ConsumeType) >= info.ConsumeCount;
			}
			if (info.ConsumeType == 11)
			{
				return taiwu.GetExp() >= info.ConsumeCount;
			}
			consumeType = info.ConsumeType;
			if (consumeType >= 12 && consumeType <= 17)
			{
				return taiwu.GetCurrMainAttribute((sbyte)(info.ConsumeType - 12)) >= info.ConsumeCount;
			}
			throw new Exception($"ConsumeType is  {info.ConsumeType}");
		}
		throw new Exception($"character {taiwuId} not found exception");
	}

	public static int GetHoldCount(this OptionConsumeInfo info, int taiwuId, int targetId)
	{
		if (info.ConsumeType == 8)
		{
			return DomainManager.World.GetLeftDaysInCurrMonth();
		}
		if (info.ConsumeType == 18)
		{
			return DomainManager.Extra.GetTotalActionPointsRemaining();
		}
		if (info.ConsumeType == 9 && DomainManager.Character.TryGetElement_Objects(targetId, out var target) && target != null)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(target.GetOrganizationInfo().SettlementId);
			return DomainManager.Extra.GetAreaSpiritualDebt(settlement.GetLocation().AreaId);
		}
		if (DomainManager.Character.TryGetElement_Objects(taiwuId, out var taiwu))
		{
			if (info.ConsumeType == 10)
			{
				return DomainManager.Extra.GetAreaSpiritualDebt(taiwu.GetLocation().AreaId);
			}
			sbyte consumeType = info.ConsumeType;
			if (consumeType >= 0 && consumeType < 8)
			{
				return taiwu.GetResource(info.ConsumeType);
			}
			if (info.ConsumeType == 11)
			{
				return taiwu.GetExp();
			}
			consumeType = info.ConsumeType;
			if (consumeType >= 12 && consumeType <= 17)
			{
				return taiwu.GetCurrMainAttribute((sbyte)(info.ConsumeType - 12));
			}
		}
		throw new Exception($"character {taiwuId} not found exception");
	}

	public static bool DoConsume(this OptionConsumeInfo info, int taiwuId, int targetId)
	{
		if (!info.AutoConsume)
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (info.ConsumeType == 8)
		{
			DomainManager.World.AdvanceDaysInMonth(context, info.ConsumeCount);
			return true;
		}
		if (info.ConsumeType == 18)
		{
			DomainManager.World.ConsumeActionPoint(context, info.ConsumeCount);
			return true;
		}
		if (info.ConsumeType == 9 && DomainManager.Character.TryGetElement_Objects(targetId, out var characterB) && characterB != null)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(characterB.GetOrganizationInfo().SettlementId);
			DataContext dataContext = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Extra.ChangeAreaSpiritualDebt(dataContext, settlement.GetLocation().AreaId, -info.ConsumeCount);
			return true;
		}
		if (DomainManager.Character.TryGetElement_Objects(taiwuId, out var taiwu))
		{
			if (info.ConsumeType == 10)
			{
				DataContext dataContext2 = DomainManager.TaiwuEvent.MainThreadDataContext;
				DomainManager.Extra.ChangeAreaSpiritualDebt(dataContext2, taiwu.GetLocation().AreaId, -info.ConsumeCount);
				return true;
			}
			if (info.ConsumeType <= 7)
			{
				taiwu.ChangeResource(context, info.ConsumeType, -info.ConsumeCount);
				return true;
			}
			if (info.ConsumeType == 11)
			{
				taiwu.ChangeExp(context, -info.ConsumeCount);
				return true;
			}
			sbyte consumeType = info.ConsumeType;
			if (consumeType >= 12 && consumeType <= 17)
			{
				taiwu.ChangeCurrMainAttribute(context, (sbyte)(info.ConsumeType - 12), -info.ConsumeCount);
				InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
				collection.AddMainAttributeConsumed(taiwu.GetId(), (short)(info.ConsumeType - 12 + 0), info.ConsumeCount);
			}
		}
		return false;
	}

	public static OptionConsumeInfo ModifyOptionConsumeInfo(OptionConsumeInfo consumeInfo, EventArgBox argBox, string expression)
	{
		if (expression != null)
		{
			consumeInfo.ConsumeCount = DomainManager.TaiwuEvent.ScriptRuntime.Evaluate<int>(expression);
		}
		switch (consumeInfo.ConsumeType)
		{
		case 9:
		{
			GameData.Domains.Character.Character character = argBox.GetCharacter();
			short settlementId2 = character.GetOrganizationInfo().SettlementId;
			consumeInfo.ConsumeCount = DomainManager.Taiwu.GetSpiritualDebtFinalCost(settlementId2, (short)consumeInfo.ConsumeCount);
			break;
		}
		case 10:
		{
			Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
			location = DomainManager.Map.GetBlock(location).GetRootBlock().GetLocation();
			Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
			if (settlement == null)
			{
				return consumeInfo;
			}
			short settlementId = settlement.GetId();
			consumeInfo.ConsumeCount = DomainManager.Taiwu.GetSpiritualDebtFinalCost(settlementId, (short)consumeInfo.ConsumeCount);
			break;
		}
		}
		return consumeInfo;
	}
}
