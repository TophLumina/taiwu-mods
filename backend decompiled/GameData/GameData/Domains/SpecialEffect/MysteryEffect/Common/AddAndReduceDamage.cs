using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.Common;

public abstract class AddAndReduceDamage : MysteryEffectBase
{
	private const int NeiliProportionUnit = 10;

	private const int ChangeDamageUnit = 3;

	protected abstract sbyte FiveElementsType { get; }

	protected abstract ushort MakeDamageFieldId { get; }

	protected abstract ushort AcceptDamageFieldId { get; }

	private int AddPercent => CharObj.GetNeiliProportionOfFiveElements()[FiveElementsType] / 10 * 3;

	protected virtual bool IsAffect(AffectedDataKey dataKey)
	{
		return dataKey.FieldId == MakeDamageFieldId || dataKey.FieldId == AcceptDamageFieldId;
	}

	protected AddAndReduceDamage()
	{
	}

	protected AddAndReduceDamage(int charId, int itemId, int type)
		: base(charId, itemId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(MakeDamageFieldId, EDataModifyType.AddPercent, -1);
		CreateAffectedData(AcceptDamageFieldId, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && IsAffect(dataKey))
		{
			return AddPercent * ((dataKey.FieldId == MakeDamageFieldId) ? 1 : (-1));
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
