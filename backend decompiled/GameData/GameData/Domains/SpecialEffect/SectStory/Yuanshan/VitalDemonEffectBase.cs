using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.SectStory.Yuanshan;

public class VitalDemonEffectBase : AutoCollectEffectBase
{
	private readonly short _effectId;

	protected VitalDemonEffectBase(int charId, short effectId)
		: base(charId)
	{
		_effectId = effectId;
	}

	protected void ShowSpecialEffect(byte index = 0)
	{
		CombatCharacter character = DomainManager.Combat.GetCombatCharacter(base.CombatChar.IsAlly);
		DomainManager.Combat.ShowSpecialEffectTips(character.GetId(), _effectId, index);
	}
}
