using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowKing : AzureMarrowBase
{
	public AzureMarrowKing()
	{
	}

	public AzureMarrowKing(int charId)
		: base(charId, 12547, ItemDomain.GetWugTemplateId(7, 5), 476)
	{
	}
}
