using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowGrowingGood2 : AzureMarrowBase
{
	public AzureMarrowGrowingGood2()
	{
	}

	public AzureMarrowGrowingGood2(int charId)
		: base(charId, 12536, ItemDomain.GetWugTemplateId(7, 1), 1202)
	{
	}
}
