using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Posing : FeatureEffectBase
{
	private const sbyte ChangeFrameCost = -50;

	private const sbyte ChangeMoveCost = -50;

	public Posing()
	{
	}

	public Posing(int charId, short featureId)
		: base(charId, featureId, 41401)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(179, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(175, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 179)
		{
			return -50;
		}
		if (dataKey.FieldId == 175)
		{
			return -50;
		}
		return 0;
	}
}
