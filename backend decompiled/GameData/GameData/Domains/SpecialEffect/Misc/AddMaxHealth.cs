using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;

namespace GameData.Domains.SpecialEffect.Misc;

public class AddMaxHealth : SpecialEffectBase
{
	private int _addFinalHealth;

	public AddMaxHealth()
	{
	}

	public AddMaxHealth(int charId, int addFinalHealth)
		: base(charId, 1000001)
	{
		_addFinalHealth = addFinalHealth;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(53, EDataModifyType.Add, -1);
		Events.RegisterHandler_PolymorphCharacterResetStatus(OnPolymorphCharacterResetStatus);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PolymorphCharacterResetStatus(OnPolymorphCharacterResetStatus);
		base.OnDisable(context);
	}

	private void OnPolymorphCharacterResetStatus(DataContext context, GameData.Domains.Character.Character character)
	{
		if (character.GetId() == base.CharacterId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 53)
		{
			return 0;
		}
		return _addFinalHealth;
	}

	protected override int GetSubClassSerializedSize()
	{
		return 4;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _addFinalHealth;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		_addFinalHealth = *(int*)pCurrData;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}
}
