using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class CharacterAttributeDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public MainAttributes CurMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MaxMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MainAttributeRecoveries;

	[SerializableGameDataField]
	public HitOrAvoidInts AtkHitAttribute;

	[SerializableGameDataField]
	public OuterAndInnerInts AtkPenetrability;

	[SerializableGameDataField]
	public HitOrAvoidInts DefHitAttribute;

	[SerializableGameDataField]
	public OuterAndInnerInts DefPenetrability;

	[SerializableGameDataField]
	public OuterAndInnerShorts RecoveryOfStanceAndBreath;

	[SerializableGameDataField]
	public short MoveSpeed;

	[SerializableGameDataField]
	public short RecoveryOfFlaw;

	[SerializableGameDataField]
	public short CastSpeed;

	[SerializableGameDataField]
	public short RecoveryOfBlockedAcupoint;

	[SerializableGameDataField]
	public short WeaponSwitchSpeed;

	[SerializableGameDataField]
	public short AttackSpeed;

	[SerializableGameDataField]
	public short InnerRatio;

	[SerializableGameDataField]
	public short RecoveryOfQiDisorder;

	[SerializableGameDataField]
	public PoisonInts PoisonResists;

	[SerializableGameDataField]
	public bool CanAffectedByCombatDifficulty;

	public CharacterAttributeDisplayData()
	{
	}

	public CharacterAttributeDisplayData(CharacterAttributeDisplayData other)
	{
		CurMainAttributes = other.CurMainAttributes;
		MaxMainAttributes = other.MaxMainAttributes;
		MainAttributeRecoveries = other.MainAttributeRecoveries;
		AtkHitAttribute = other.AtkHitAttribute;
		AtkPenetrability = other.AtkPenetrability;
		DefHitAttribute = other.DefHitAttribute;
		DefPenetrability = other.DefPenetrability;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
		CanAffectedByCombatDifficulty = other.CanAffectedByCombatDifficulty;
	}

	public void Assign(CharacterAttributeDisplayData other)
	{
		CurMainAttributes = other.CurMainAttributes;
		MaxMainAttributes = other.MaxMainAttributes;
		MainAttributeRecoveries = other.MainAttributeRecoveries;
		AtkHitAttribute = other.AtkHitAttribute;
		AtkPenetrability = other.AtkPenetrability;
		DefHitAttribute = other.DefHitAttribute;
		DefPenetrability = other.DefPenetrability;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
		CanAffectedByCombatDifficulty = other.CanAffectedByCombatDifficulty;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 129;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += CurMainAttributes.Serialize(pCurrData);
		pCurrData += MaxMainAttributes.Serialize(pCurrData);
		pCurrData += MainAttributeRecoveries.Serialize(pCurrData);
		pCurrData += AtkHitAttribute.Serialize(pCurrData);
		pCurrData += AtkPenetrability.Serialize(pCurrData);
		pCurrData += DefHitAttribute.Serialize(pCurrData);
		pCurrData += DefPenetrability.Serialize(pCurrData);
		pCurrData += RecoveryOfStanceAndBreath.Serialize(pCurrData);
		*(short*)pCurrData = MoveSpeed;
		pCurrData += 2;
		*(short*)pCurrData = RecoveryOfFlaw;
		pCurrData += 2;
		*(short*)pCurrData = CastSpeed;
		pCurrData += 2;
		*(short*)pCurrData = RecoveryOfBlockedAcupoint;
		pCurrData += 2;
		*(short*)pCurrData = WeaponSwitchSpeed;
		pCurrData += 2;
		*(short*)pCurrData = AttackSpeed;
		pCurrData += 2;
		*(short*)pCurrData = InnerRatio;
		pCurrData += 2;
		*(short*)pCurrData = RecoveryOfQiDisorder;
		pCurrData += 2;
		pCurrData += PoisonResists.Serialize(pCurrData);
		*pCurrData = (CanAffectedByCombatDifficulty ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += CurMainAttributes.Deserialize(pCurrData);
		pCurrData += MaxMainAttributes.Deserialize(pCurrData);
		pCurrData += MainAttributeRecoveries.Deserialize(pCurrData);
		pCurrData += AtkHitAttribute.Deserialize(pCurrData);
		pCurrData += AtkPenetrability.Deserialize(pCurrData);
		pCurrData += DefHitAttribute.Deserialize(pCurrData);
		pCurrData += DefPenetrability.Deserialize(pCurrData);
		pCurrData += RecoveryOfStanceAndBreath.Deserialize(pCurrData);
		MoveSpeed = *(short*)pCurrData;
		pCurrData += 2;
		RecoveryOfFlaw = *(short*)pCurrData;
		pCurrData += 2;
		CastSpeed = *(short*)pCurrData;
		pCurrData += 2;
		RecoveryOfBlockedAcupoint = *(short*)pCurrData;
		pCurrData += 2;
		WeaponSwitchSpeed = *(short*)pCurrData;
		pCurrData += 2;
		AttackSpeed = *(short*)pCurrData;
		pCurrData += 2;
		InnerRatio = *(short*)pCurrData;
		pCurrData += 2;
		RecoveryOfQiDisorder = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += PoisonResists.Deserialize(pCurrData);
		CanAffectedByCombatDifficulty = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
