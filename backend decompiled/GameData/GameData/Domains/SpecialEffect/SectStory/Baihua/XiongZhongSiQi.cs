using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class XiongZhongSiQi : CombatStateEffectBase
{
	protected override short CombatStateId => 224;

	public XiongZhongSiQi(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(8, EDataModifyType.Custom, -1);
		CreateAffectedData(7, EDataModifyType.Custom, -1);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 7) <= 1u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return dataValue;
		}
		return 0;
	}
}
