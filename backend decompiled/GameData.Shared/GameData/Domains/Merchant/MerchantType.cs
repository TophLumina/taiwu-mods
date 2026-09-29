using System.Collections.Generic;
using Config;

namespace GameData.Domains.Merchant;

public static class MerchantType
{
	public const sbyte Foods = 0;

	public const sbyte Books = 1;

	public const sbyte Materials = 2;

	public const sbyte Equipments = 3;

	public const sbyte Medicines = 4;

	public const sbyte Constructions = 5;

	public const sbyte Accessories = 6;

	public const int Count = 7;

	public static MerchantItem GetMerchantLevelData(sbyte groupId, sbyte level)
	{
		foreach (MerchantItem data in (IEnumerable<MerchantItem>)Config.Merchant.Instance)
		{
			if (data.GroupId == groupId && data.Level == level)
			{
				return data;
			}
		}
		return null;
	}
}
