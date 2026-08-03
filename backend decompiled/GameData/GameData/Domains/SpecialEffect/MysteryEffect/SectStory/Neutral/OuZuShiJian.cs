using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;

public class OuZuShiJian : MysteryEffectBase
{
	private const int PowerMaxAddPercent = 50;

	protected override short SpecialEffectId => 1761;

	public OuZuShiJian()
	{
	}

	public OuZuShiJian(int charId, int itemId)
		: base(charId, itemId, 50008)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(313, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 313)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		int itemId = dataKey.CustomParam0;
		EquipmentBase equipment = DomainManager.Item.GetEquipmentById(itemId);
		if (equipment == null)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		CValuePercent durabilityPercent = CValuePercent.Parse(equipment.GetCurrDurability(), equipment.GetMaxDurability());
		return 50 * durabilityPercent;
	}
}
