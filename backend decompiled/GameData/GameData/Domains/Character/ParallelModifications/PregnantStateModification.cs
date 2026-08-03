namespace GameData.Domains.Character.ParallelModifications;

public class PregnantStateModification
{
	public enum ChildState
	{
		Invalid,
		Dead,
		AliveHuman,
		AliveCricket
	}

	public ChildState State = ChildState.Invalid;

	public bool Dystocia;

	public bool LostMother;

	public bool DreamedOfCricket;

	public bool PrenatalEvent;
}
