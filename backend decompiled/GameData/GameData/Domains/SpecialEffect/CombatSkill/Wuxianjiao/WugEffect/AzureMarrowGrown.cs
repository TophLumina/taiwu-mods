using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowGrown : AzureMarrowBase
{
	public AzureMarrowGrown()
	{
	}

	public AzureMarrowGrown(int charId)
		: base(charId, 12539, ItemDomain.GetWugTemplateId(7, 4), 476)
	{
	}
}
