namespace GameData.Domains.Character.AvatarSystem;

public static class AvatarFeatureMirrorType
{
	public const sbyte Invalid = -1;

	public const sbyte Left = 0;

	public const sbyte Right = 1;

	public const sbyte Both = 2;

	public static sbyte ToggleToType(bool leftOn, bool rightOn)
	{
		if (leftOn && rightOn)
		{
			return 2;
		}
		if (rightOn)
		{
			return 1;
		}
		return 0;
	}
}
