using System.Collections.Generic;
using Config;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商会类型
/// </summary>
public static class MerchantType
{
	/// <summary>
	/// 服牛帮
	/// </summary>
	public const sbyte Foods = 0;

	/// <summary>
	/// 文山书海阁
	/// </summary>
	public const sbyte Books = 1;

	/// <summary>
	/// 五湖商会
	/// </summary>
	public const sbyte Materials = 2;

	/// <summary>
	/// 大武魁商号
	/// </summary>
	public const sbyte Equipments = 3;

	/// <summary>
	/// 回春堂
	/// </summary>
	public const sbyte Medicines = 4;

	/// <summary>
	/// 公输坊
	/// </summary>
	public const sbyte Constructions = 5;

	/// <summary>
	/// 奇货斋
	/// </summary>
	public const sbyte Accessories = 6;

	/// <summary>
	/// 商会类型数量
	/// </summary>
	public const int Count = 7;

	/// <summary>
	/// 获取商会的等级化信息
	/// </summary>
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
