namespace GameData.Domains.Organization.ParallelModifications;

public readonly struct ParallelSettlementModification(short culture, short safety, int population)
{
	public readonly short Culture = culture;

	public readonly short Safety = safety;

	public readonly int Population = population;
}
