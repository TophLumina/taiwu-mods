namespace GameData.DLC;

public interface IPolymorphRuntime
{
	int MaleCharacterId { get; }

	int FemaleCharacterId { get; }

	EPolymorphState State { get; set; }
}
