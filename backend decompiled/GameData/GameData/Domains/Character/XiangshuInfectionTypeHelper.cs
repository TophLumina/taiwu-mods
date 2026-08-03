namespace GameData.Domains.Character;

public class XiangshuInfectionTypeHelper
{
	public static short GetInfectionFeatureIdThatShouldBe(byte xiangshuInfection)
	{
		if (xiangshuInfection < 100)
		{
			return 209;
		}
		if (xiangshuInfection < 200)
		{
			return 210;
		}
		return 211;
	}
}
