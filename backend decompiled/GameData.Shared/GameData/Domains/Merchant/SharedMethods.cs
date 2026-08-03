namespace GameData.Domains.Merchant;

public static class SharedMethods
{
	/// <summary>
	///     根据商店的好感度获得好感等级
	/// </summary>
	public static int GetFavorLevel(int favor, out float remainRate)
	{
		if (favor < 60)
		{
			if (favor >= 20)
			{
				if (favor < 40)
				{
					remainRate = (float)(favor - 20) / 20f;
					return 1;
				}
				remainRate = (float)(favor - 40) / 20f;
				return 2;
			}
			remainRate = (float)favor / 20f;
			return 0;
		}
		if (favor < 90)
		{
			if (favor < 80)
			{
				remainRate = (float)(favor - 60) / 20f;
				return 3;
			}
			remainRate = (float)(favor - 80) / 10f;
			return 4;
		}
		if (favor < 100)
		{
			remainRate = (float)(favor - 90) / 10f;
			return 5;
		}
		remainRate = 0f;
		return 6;
	}

	/// <summary>
	///     根据商店的好感度获得好感等级
	/// </summary>
	public static int GetFavorLevel(int favor)
	{
		float remainRate;
		return GetFavorLevel(favor, out remainRate);
	}

	/// <summary>
	///     获取商会总部和分部的商队的固定ID，总部[-2, -8]，分部[-9,-15]，-1是临时商队
	/// </summary>
	/// <param name="type"></param>
	/// <param name="isHead"></param>
	/// <returns></returns>
	public static int GetBuildingMerchantCaravanId(sbyte type, bool isHead)
	{
		int rate = (isHead ? 1 : 2);
		return type - 7 * rate - 1;
	}

	/// <summary>
	///     计算商店被抢的概率，处于毁坏地块时翻倍
	/// </summary>
	/// <param name="originRate"></param>
	/// <param name="isInBrokenArea"></param>
	/// <returns></returns>
	public static int GetCaravanRobbedRate(int originRate, bool isInBrokenArea)
	{
		if (!isInBrokenArea)
		{
			return originRate;
		}
		return originRate * 2;
	}

	/// <summary>
	///     使用buyMoney计算商会好感变化（考虑商人技能加成）
	/// </summary>
	/// <param name="buyMoney"></param>
	/// <returns></returns>
	public static int RealFavorabilityGain(int buyMoney)
	{
		if (buyMoney <= 0 || !ExternalDataBridge.Context.IsProfessionalSkillUnlockedAndEquipped(63))
		{
			return buyMoney;
		}
		return buyMoney * 3;
	}
}
