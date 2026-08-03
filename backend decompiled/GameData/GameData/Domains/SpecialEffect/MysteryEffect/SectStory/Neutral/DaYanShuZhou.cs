using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;

public class DaYanShuZhou : ChangeMark
{
	protected override short SpecialEffectId => 1759;

	protected override ushort FieldId => 336;

	public DaYanShuZhou()
	{
	}

	public DaYanShuZhou(int charId, int itemId)
		: base(charId, itemId, 50006)
	{
	}
}
