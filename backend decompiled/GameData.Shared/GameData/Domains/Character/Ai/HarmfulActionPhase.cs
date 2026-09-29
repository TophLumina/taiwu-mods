namespace GameData.Domains.Character.Ai;

public static class HarmfulActionPhase
{
	public const sbyte RecognizeTarget = 0;

	public const sbyte StayHidden = 1;

	public const sbyte WaitForGoodTiming = 2;

	public const sbyte TakeAction = 3;

	public const sbyte OnTheWayOut = 4;

	public const sbyte Count = 5;

	public static readonly sbyte[] ToPersonalityType = new sbyte[5] { 1, 4, 0, 2, 3 };
}
