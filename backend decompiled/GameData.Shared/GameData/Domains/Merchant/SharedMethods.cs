namespace GameData.Domains.Merchant;

public static class SharedMethods
{
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

	public static int GetFavorLevel(int favor)
	{
		float remainRate;
		return GetFavorLevel(favor, out remainRate);
	}

	public static int GetBuildingMerchantCaravanId(sbyte type, bool isHead)
	{
		int rate = (isHead ? 1 : 2);
		return type - 7 * rate - 1;
	}

	public static int GetCaravanRobbedRate(int originRate, bool isInBrokenArea)
	{
		if (!isInBrokenArea)
		{
			return originRate;
		}
		return originRate * 2;
	}

	public static int RealFavorabilityGain(int buyMoney)
	{
		if (buyMoney <= 0 || !ExternalDataBridge.Context.IsProfessionalSkillUnlockedAndEquipped(63))
		{
			return buyMoney;
		}
		return buyMoney * 3;
	}
}
