namespace GameData.Domains.Character.Ai;

public static class ActionEnergyType
{
	public const sbyte HealthRequest = 0;

	public const sbyte WealthRequest = 1;

	public const sbyte StudyRequest = 2;

	public const sbyte BehaviorAction = 3;

	public const sbyte FreeAction = 4;

	public const sbyte Count = 5;

	public const byte MaxEnergy = 200;

	public const byte EnergyCost = 100;

	public static readonly sbyte[] ToPersonalityType = new sbyte[5] { 4, 0, 1, 3, 2 };
}
