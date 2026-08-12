using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public abstract class LionBase : CombatStateEffectBase
{
	protected abstract int AddOrReduceCostPercent { get; }

	protected LionBase()
	{
	}

	protected LionBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 254, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 255, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 150, -1), EDataModifyType.TotalPercent);
	}

	public override void OnDataAdded(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 254, EDataModifyType.TotalPercent, -1);
		AppendAffectedAllEnemyData(context, 255, EDataModifyType.TotalPercent, -1);
		AppendAffectedAllEnemyData(context, 150, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		bool flag = ((fieldId == 150 || (uint)(fieldId - 254) <= 1u) ? true : false);
		if (!flag || !base.IsCurrent)
		{
			return 0;
		}
		return (dataKey.CharId == base.CharacterId) ? (-AddOrReduceCostPercent) : AddOrReduceCostPercent;
	}
}
