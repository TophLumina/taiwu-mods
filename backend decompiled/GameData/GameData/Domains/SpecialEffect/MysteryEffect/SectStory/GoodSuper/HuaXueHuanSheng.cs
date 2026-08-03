using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;

public class HuaXueHuanSheng : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	protected override short SpecialEffectId => 1770;

	public HuaXueHuanSheng()
	{
	}

	public HuaXueHuanSheng(int charId, int itemId)
		: base(charId, itemId, 50102)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(328, EDataModifyType.Custom, -1);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 328)
		{
			return 500;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
