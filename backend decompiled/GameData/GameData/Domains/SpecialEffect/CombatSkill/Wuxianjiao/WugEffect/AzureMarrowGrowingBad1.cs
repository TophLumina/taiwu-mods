using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowGrowingBad1 : AzureMarrowBase
{
	public AzureMarrowGrowingBad1()
	{
	}

	public AzureMarrowGrowingBad1(int charId)
		: base(charId, 12537, ItemDomain.GetWugTemplateId(7, 2), 476)
	{
	}
}
