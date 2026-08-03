namespace GameData.Domains.Character;

public struct CharacterMatcherArg
{
	public int AdventureId = -1;

	public static readonly CharacterMatcherArg Default = new CharacterMatcherArg();

	public CharacterMatcherArg()
	{
	}
}
