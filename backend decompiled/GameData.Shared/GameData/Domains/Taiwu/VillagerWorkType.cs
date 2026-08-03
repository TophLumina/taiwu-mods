namespace GameData.Domains.Taiwu;

/// <summary>
/// 村民工作类型
/// </summary>
public class VillagerWorkType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 建造建筑（包括扩建、撤除、太吾村产业采集）
	/// </summary>
	public const sbyte Build = 0;

	/// <summary>
	/// 经营建筑
	/// </summary>
	public const sbyte ShopManage = 1;

	/// <summary>
	/// 村民职位
	/// </summary>
	public const sbyte Job = 2;

	/// <summary>
	/// 野外采集
	/// </summary>
	public const sbyte CollectResource = 10;

	/// <summary>
	/// 野外收取敌人巢穴的贡品
	/// </summary>
	public const sbyte CollectTribute = 11;

	/// <summary>
	/// 守墓
	/// </summary>
	public const sbyte KeepGrave = 12;

	/// <summary>
	/// 野外就地待机
	/// </summary>
	public const sbyte Idle = 13;

	/// <summary>
	/// 迁移资源
	/// </summary>
	public const sbyte Migrate = 14;

	/// <summary>
	/// 开化资源
	/// </summary>
	public const sbyte Develop = 15;

	/// <summary>
	/// 野外任务分割线
	/// </summary>
	public const sbyte WorkTypeOnMapStart = 10;

	/// <summary>
	/// 指定工作类型是否为在地图上的野外工作
	/// </summary>
	/// <param name="workType"></param>
	/// <returns></returns>
	public static bool IsWorkOnMap(sbyte workType)
	{
		return workType >= 10;
	}

	/// <summary>
	/// 指定工作类型是否为在地图上的野外工作
	/// </summary>
	/// <param name="workType"></param>
	/// <returns></returns>
	public static bool IsWorkOnMapAndNeedMark(sbyte workType)
	{
		if (workType >= 10 && workType != 10)
		{
			return workType != 14;
		}
		return false;
	}

	/// <summary>
	/// 指定工作类型是否与村民身份绑定
	/// </summary>
	/// <param name="workType"></param>
	/// <returns></returns>
	public static bool IsVillagerRoleSpecificType(sbyte workType)
	{
		if (workType != 10)
		{
			return workType == 14;
		}
		return true;
	}
}
