using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.MysteryEffect;

public abstract class MysteryEffectBase : SpecialEffectBase
{
	protected int ItemId { get; private set; }

	protected abstract short SpecialEffectId { get; }

	protected MysteryEffectBase()
	{
	}

	protected MysteryEffectBase(int charId, int itemId, int type)
		: base(charId, type)
	{
		ItemId = itemId;
	}

	protected void ShowSpecialEffect(byte index = 0)
	{
		CombatCharacter character = DomainManager.Combat.GetCombatCharacter(base.CombatChar.IsAlly);
		DomainManager.Combat.ShowSpecialEffectTips(character.GetId(), SpecialEffectId, index);
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 4;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.SerializeSubClass(pCurrData);
		*(int*)pCurrData = ItemId;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.DeserializeSubClass(pCurrData);
		ItemId = *(int*)pCurrData;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}
}
