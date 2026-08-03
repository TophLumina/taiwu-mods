using System;
using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Item;

public static class CricketGenerator
{
	public delegate sbyte GeneratorDelegate(sbyte orgGrade, sbyte wagerGrade, int eclecticAttainment);

	private static readonly List<GeneratorDelegate> GeneratorMethods = new List<GeneratorDelegate> { Generator1, Generator2, Generator3 };

	private static sbyte GeneratorClamp(int grade)
	{
		return (sbyte)Math.Clamp(grade, 0, 8);
	}

	private static sbyte Generator1(sbyte orgGrade, sbyte wagerGrade, int eclecticAttainment)
	{
		return GeneratorClamp(wagerGrade);
	}

	private static sbyte Generator2(sbyte orgGrade, sbyte wagerGrade, int eclecticAttainment)
	{
		return GeneratorClamp(orgGrade);
	}

	private static sbyte Generator3(sbyte orgGrade, sbyte wagerGrade, int eclecticAttainment)
	{
		return GeneratorClamp(orgGrade - 3 + eclecticAttainment / 150);
	}

	public static IEnumerable<sbyte> Generate(sbyte orgGrade, sbyte wagerGrade, int eclectic)
	{
		return GeneratorMethods.Select((GeneratorDelegate method) => method(orgGrade, wagerGrade, eclectic));
	}
}
