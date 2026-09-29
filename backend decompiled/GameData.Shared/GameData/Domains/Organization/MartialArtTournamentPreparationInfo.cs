using System;
using GameData.Serializer;

namespace GameData.Domains.Organization;

public struct MartialArtTournamentPreparationInfo : IComparable<MartialArtTournamentPreparationInfo>, ISerializableGameData
{
	[SerializableGameDataField]
	public short SettlementId;

	[SerializableGameDataField]
	public int TotalScore;

	[SerializableGameDataField]
	public int CombatPowerPreparation;

	[SerializableGameDataField]
	public int AuthorityPreparation;

	[SerializableGameDataField]
	public int ResourcePreparation;

	public int CompareTo(MartialArtTournamentPreparationInfo other)
	{
		if (TotalScore != other.TotalScore)
		{
			return TotalScore.CompareTo(other.TotalScore);
		}
		if (CombatPowerPreparation != other.CombatPowerPreparation)
		{
			return CombatPowerPreparation.CompareTo(other.CombatPowerPreparation);
		}
		if (ResourcePreparation != other.ResourcePreparation)
		{
			return ResourcePreparation.CompareTo(other.ResourcePreparation);
		}
		if (AuthorityPreparation != other.AuthorityPreparation)
		{
			return AuthorityPreparation.CompareTo(other.AuthorityPreparation);
		}
		return SettlementId.CompareTo(other.SettlementId);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = SettlementId;
		byte* num = pData + 2;
		*(int*)num = TotalScore;
		byte* num2 = num + 4;
		*(int*)num2 = CombatPowerPreparation;
		byte* num3 = num2 + 4;
		*(int*)num3 = AuthorityPreparation;
		byte* num4 = num3 + 4;
		*(int*)num4 = ResourcePreparation;
		int totalSize = (int)(num4 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SettlementId = *(short*)pCurrData;
		pCurrData += 2;
		TotalScore = *(int*)pCurrData;
		pCurrData += 4;
		CombatPowerPreparation = *(int*)pCurrData;
		pCurrData += 4;
		AuthorityPreparation = *(int*)pCurrData;
		pCurrData += 4;
		ResourcePreparation = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
