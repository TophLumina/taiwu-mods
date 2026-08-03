using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.Utilities;

namespace GameData.Domains.Map;

public static class MapPickupHelper
{
	public static IEnumerable<MapPickup> IterVisiblePickups(this MapPickupCollection collection, sbyte xiangshuLevel)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			MapPickup pickup = collection.Get(i);
			if (pickup != null && pickup.IsVisible() && pickup.Type != MapPickup.EMapPickupType.Event)
			{
				yield return pickup;
			}
		}
	}

	public static BoolArray32 CalcMapPickupBanReason(this MapPickup pickup)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		short taiwuLoopingNeigong = taiwuChar.GetLoopingNeigong();
		ItemKey taiwuReadingBookKey = DomainManager.Taiwu.GetCurReadingBook();
		BoolArray32 banReason = default(BoolArray32);
		switch (pickup.Type)
		{
		case MapPickup.EMapPickupType.LoopEffect:
			if (taiwuLoopingNeigong < 0)
			{
				banReason[0] = true;
			}
			break;
		case MapPickup.EMapPickupType.ReadEffect:
			if (!taiwuReadingBookKey.IsValid())
			{
				banReason[1] = true;
			}
			break;
		}
		return banReason;
	}

	public static short CalcXiangshuMinionTemplateId(this MapPickup pickup)
	{
		short enemyTemplateId = (short)(366 + pickup.XiangshuLevel);
		if (enemyTemplateId > 374)
		{
			enemyTemplateId = 374;
		}
		return enemyTemplateId;
	}

	public static bool CalcCanAutoBeatXiangshuMinion(this MapPickup pickup)
	{
		short enemyTemplateId = pickup.CalcXiangshuMinionTemplateId();
		CharacterItem characterConfig = Config.Character.Instance[enemyTemplateId];
		sbyte enemyConsummateLevel = characterConfig.ConsummateLevel;
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		return taiwuChar.GetConsummateLevel() - 6 >= enemyConsummateLevel;
	}

	public static bool CalcNeedBattle(this MapPickup pickup)
	{
		return pickup.HasXiangshuMinion && !pickup.CalcCanAutoBeatXiangshuMinion();
	}

	public static void ApplyMinionEscape(this MapPickup pickup, DataContext context, Location location)
	{
		short enemyId = pickup.CalcXiangshuMinionTemplateId();
		if (pickup.CalcCanAutoBeatXiangshuMinion())
		{
			InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
			collection.AddMapPickupsEnemyEscape(location, enemyId);
		}
		List<short> enemyIds = new List<short> { enemyId };
		DomainManager.Combat.GetExpAndAuthorityAndAreaSpiritualDebtOutOfCombat(context, enemyIds);
	}

	public static bool IsVisible(this MapPickup pickup)
	{
		if (pickup == null)
		{
			return false;
		}
		if (pickup.IsEventType)
		{
			return false;
		}
		if (pickup.State == MapPickup.EMapPickupState.Used)
		{
			return false;
		}
		if (!pickup.VisibleByResource)
		{
			return false;
		}
		if (pickup.Ignored)
		{
			return false;
		}
		MapPickupsItem config = pickup.Template;
		sbyte monthInYear = DomainManager.World.GetCurrMonthInYear();
		if (!config.CanShowMonths[monthInYear])
		{
			return false;
		}
		sbyte xiangshuProgress = DomainManager.World.GetXiangshuProgress();
		sbyte xiangshuLevel = GameData.Domains.World.SharedMethods.GetXiangshuLevel(xiangshuProgress);
		if (xiangshuLevel < pickup.XiangshuLevel)
		{
			return false;
		}
		if (!IsPickupInformationConditionMatched(config))
		{
			return false;
		}
		if (!IsPickupOrganizationConditionMatched(config))
		{
			return false;
		}
		return true;
	}

	private static bool IsPickupInformationConditionMatched(MapPickupsItem config)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwu().GetId();
		NormalInformationCollection collection = DomainManager.Information.GetCharacterNormalInformation(taiwuCharId);
		short informationId = config.ShowConditionInformation;
		if (informationId == -1)
		{
			return true;
		}
		return collection?.GetList().Any((NormalInformation i) => i.TemplateId == informationId) ?? false;
	}

	private static bool IsPickupOrganizationConditionMatched(MapPickupsItem config)
	{
		OrganizationApproving require = config.ShowConditionOrganizationApproving;
		if (require == null || !require.IsValid)
		{
			return true;
		}
		return DomainManager.Organization.GetSettlementByOrgTemplateId(require.OrgTemplateId).CalcApprovingRate() >= require.ApprovingValue;
	}

	public static int CompareVisiblePickups(MapPickup x, MapPickup y)
	{
		bool xHasBattle = x.HasXiangshuMinion && !x.CalcCanAutoBeatXiangshuMinion();
		bool yHasBattle = y.HasXiangshuMinion && !y.CalcCanAutoBeatXiangshuMinion();
		if (xHasBattle != yHasBattle)
		{
			return (!xHasBattle) ? 1 : (-1);
		}
		int xiangshuLevelCompare = y.XiangshuLevel.CompareTo(x.XiangshuLevel);
		if (xiangshuLevelCompare != 0)
		{
			return xiangshuLevelCompare;
		}
		MapPickup.EMapPickupType xType = x.Type;
		MapPickup.EMapPickupType yType = y.Type;
		int typeCompare = xType.CompareTo(yType);
		if (typeCompare != 0)
		{
			return typeCompare;
		}
		return x.GetHashCode().CompareTo(y.GetHashCode());
	}
}
