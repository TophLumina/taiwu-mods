using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class WeiYan : AutoCollectEffectBase
{
	private const int AffectCount = 3;

	private static readonly IReadOnlyList<ushort> MinorAttributeFieldIds = new ushort[10] { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

	public WeiYan(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		foreach (ushort fieldId in RandomUtils.GetRandomUnrepeated(context.Random, 3, MinorAttributeFieldIds))
		{
			CreateAffectedAllEnemyData(fieldId, EDataModifyType.Custom, -1);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		return 0;
	}
}
