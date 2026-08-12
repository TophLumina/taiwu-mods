using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowGrowingGood1 : AzureMarrowBase
{
	public AzureMarrowGrowingGood1()
	{
	}

	public AzureMarrowGrowingGood1(int charId)
		: base(charId, 12535, ItemDomain.GetWugTemplateId(7, 0), 1202)
	{
	}
}
