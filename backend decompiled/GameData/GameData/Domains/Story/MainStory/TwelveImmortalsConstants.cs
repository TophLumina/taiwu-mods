using System.Collections.Generic;

namespace GameData.Domains.Story.MainStory;

public static class TwelveImmortalsConstants
{
	public static readonly IReadOnlyDictionary<short, sbyte> JiaoCharacterToPoisonTypes = new Dictionary<short, sbyte>
	{
		{ 1103, 0 },
		{ 1104, 1 },
		{ 1106, 2 },
		{ 1105, 3 },
		{ 1107, 4 },
		{ 1108, 5 }
	};

	public static readonly IReadOnlyList<short> MirrorCharacters = new _003C_003Ez__ReadOnlyArray<short>(new short[3] { 1109, 1110, 1111 });

	public static readonly IReadOnlyList<short> DivineFlameAssistCharacters = new _003C_003Ez__ReadOnlyArray<short>(new short[9] { 201, 202, 203, 204, 205, 206, 207, 208, 209 });
}
