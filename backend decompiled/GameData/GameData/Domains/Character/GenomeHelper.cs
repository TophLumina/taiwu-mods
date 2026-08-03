using Redzen.Random;

namespace GameData.Domains.Character;

public static class GenomeHelper
{
	public static void Inherit(IRandomSource randomSource, Character mother, Character father, ref Genome offspringGenome)
	{
		if (mother != null && father != null)
		{
			Genome.Inherit(randomSource, ref mother.GetGenome(), ref father.GetGenome(), ref offspringGenome);
			return;
		}
		if (mother == null && father == null)
		{
			Genome.CreateRandom(randomSource, ref offspringGenome);
			return;
		}
		Genome virtualParentGenome = default(Genome);
		Genome.CreateRandom(randomSource, ref virtualParentGenome);
		Genome.Inherit(randomSource, ref mother != null ? ref mother.GetGenome() : ref virtualParentGenome, ref father != null ? ref father.GetGenome() : ref virtualParentGenome, ref offspringGenome);
	}
}
