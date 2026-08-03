namespace GameData.Domains.Map;

public static class TemplateEnemySourceType
{
	public const sbyte Unknown = 0;

	public const sbyte EnemyNest = 1;

	public const sbyte HeavenlyTree = 2;

	public const sbyte XiangshuInfectedDemon = 3;

	public const sbyte ShixiangStoryEnemy = 4;

	public const sbyte MainStoryChapter9 = 5;

	public static string GetName(sbyte type)
	{
		return type switch
		{
			1 => "EnemyNest", 
			2 => "HeavenlyTree", 
			3 => "XiangshuInfectedDemon", 
			4 => "ShixiangStoryEnemy", 
			5 => "MainStoryChapter9", 
			_ => "Unknown", 
		};
	}
}
