using GameData.Common;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

public class DebateStrategyActionParams
{
	public DataContext Context;

	public bool IsCastedByTaiwu;

	public int PawnId;

	public int PawnId2;

	public int Value;

	public sbyte Grade;

	public IntPair Coordinate;

	public int UsingCard;

	public int Card;

	public short StrategyTemplateId;

	public DebateNodeEffectState NodeEffect = DebateNodeEffectState.Invalid;
}
