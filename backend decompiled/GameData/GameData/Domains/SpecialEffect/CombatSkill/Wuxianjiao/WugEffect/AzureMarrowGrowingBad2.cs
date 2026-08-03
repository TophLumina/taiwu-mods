using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowGrowingBad2 : AzureMarrowBase
{
	public AzureMarrowGrowingBad2()
	{
	}

	public AzureMarrowGrowingBad2(int charId)
		: base(charId, 12538, ItemDomain.GetWugTemplateId(7, 3), 476)
	{
	}
}
