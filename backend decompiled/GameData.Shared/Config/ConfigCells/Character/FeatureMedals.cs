using System;
using System.Collections.Generic;

namespace Config.ConfigCells.Character;

[Serializable]
public class FeatureMedals
{
	public readonly List<sbyte> Values;

	public FeatureMedals(params string[] values)
	{
		Values = new List<sbyte>(values.Length);
		int valuesLength = values.Length;
		for (int i = 0; i < valuesLength; i++)
		{
			switch (values[i])
			{
			case "pos":
				Values.Add(0);
				break;
			case "neg":
				Values.Add(1);
				break;
			case "inc":
				Values.Add(2);
				break;
			case "dec":
				Values.Add(3);
				break;
			default:
				throw new Exception("Unsupported FeatureMedalValue: " + values[i]);
			}
		}
	}
}
