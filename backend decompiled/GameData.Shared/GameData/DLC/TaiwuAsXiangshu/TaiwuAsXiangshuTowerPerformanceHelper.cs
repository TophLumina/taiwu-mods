namespace GameData.DLC.TaiwuAsXiangshu;

public static class TaiwuAsXiangshuTowerPerformanceHelper
{
	public static bool IsThreeRealmsPowerCharacter(short characterTemplateId)
	{
		switch (characterTemplateId)
		{
		case 913:
		case 914:
		case 916:
		case 1313:
		case 1314:
		case 1315:
		case 1340:
		case 1341:
		case 1342:
			return true;
		default:
			return false;
		}
	}

	public static short GetPowerCharacterTemplateId(short characterTemplateId)
	{
		switch (characterTemplateId)
		{
		case 1313:
		case 1340:
			return 913;
		case 1315:
		case 1342:
			return 916;
		case 1314:
		case 1341:
			return 914;
		default:
			return characterTemplateId;
		}
	}
}
