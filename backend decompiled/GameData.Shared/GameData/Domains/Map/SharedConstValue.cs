using System.Collections.Generic;

namespace GameData.Domains.Map;

public class SharedConstValue
{
	public static readonly List<List<short>> AnimalCharIdGroups = new List<List<short>>
	{
		new List<short> { 231, 240 },
		new List<short> { 232, 241 },
		new List<short> { 229, 238 },
		new List<short> { 234, 243 },
		new List<short> { 235, 244 },
		new List<short> { 228, 237 },
		new List<short> { 230, 239 },
		new List<short> { 233, 242 },
		new List<short> { 236, 245 }
	};

	public static (int, int)[] TaiwuEnsuredSurroundingBlockOffsets = new(int, int)[16]
	{
		(5, 0),
		(-5, 0),
		(0, 5),
		(0, -5),
		(2, 4),
		(2, -4),
		(-2, 4),
		(-2, -4),
		(4, 2),
		(4, -2),
		(-4, 2),
		(-2, -2),
		(4, 6),
		(4, -6),
		(-4, 6),
		(-4, -6)
	};

	public static List<short> MainStoryCreatedCharTemplateIds = new List<short> { 521, 522, 520, 519 };

	public static readonly int FreeTravelCostTimeRate = 3;

	public static Dictionary<sbyte, short> XiangshuId2BlockConfigId = new Dictionary<sbyte, short>
	{
		{ 0, 128 },
		{ 1, 129 },
		{ 2, 130 },
		{ 3, 131 },
		{ 4, 132 },
		{ 5, 133 },
		{ 6, 134 },
		{ 7, 135 },
		{ 8, 136 }
	};

	public static Dictionary<short, sbyte> SwordTombId2XiangshuId = new Dictionary<short, sbyte>
	{
		{ 128, 0 },
		{ 129, 1 },
		{ 130, 2 },
		{ 131, 3 },
		{ 132, 4 },
		{ 133, 5 },
		{ 134, 6 },
		{ 135, 7 },
		{ 136, 8 }
	};
}
