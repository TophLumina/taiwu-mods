using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;

namespace GameData.Domains.Organization;

public class SettlementMembersCreationInfo
{
	public readonly sbyte OrgTemplateId;

	public readonly short SettlementId;

	public readonly sbyte MapStateTemplateId;

	public readonly short AreaId;

	public readonly List<short> BlockIds;

	public readonly List<short> NearbyBlockIds;

	public OrganizationMemberItem CoreMemberConfig;

	public AvatarData CoreMotherAvatar;

	public AvatarData CoreFatherAvatar;

	public Genome CoreMotherGenome;

	public Genome CoreFatherGenome;

	public int CoreCharId;

	public GameData.Domains.Character.Character CoreChar;

	public bool IsCoreCharInfertile;

	public int SpouseCharId;

	public GameData.Domains.Character.Character SpouseChar;

	public readonly List<int> CreatedCharIds;

	public SettlementMembersCreationInfo(sbyte orgTemplateId, short settlementId, sbyte mapStateTemplateId, short areaId, List<short> blockIds, List<short> nearbyBlockIds)
	{
		OrgTemplateId = orgTemplateId;
		SettlementId = settlementId;
		MapStateTemplateId = mapStateTemplateId;
		AreaId = areaId;
		BlockIds = blockIds;
		NearbyBlockIds = nearbyBlockIds;
		CoreMemberConfig = null;
		CoreMotherAvatar = null;
		CoreFatherAvatar = null;
		CoreMotherGenome = default(Genome);
		CoreFatherGenome = default(Genome);
		CoreCharId = -1;
		CoreChar = null;
		IsCoreCharInfertile = false;
		SpouseCharId = -1;
		SpouseChar = null;
		CreatedCharIds = new List<int>();
	}

	public void CompleteCreatingCharacters()
	{
		for (int i = CreatedCharIds.Count - 1; i >= 0; i--)
		{
			int charId = CreatedCharIds[i];
			DomainManager.Character.CompleteCreatingCharacter(charId);
		}
		Reset();
	}

	private void Reset()
	{
		CoreMotherAvatar = null;
		CoreFatherAvatar = null;
		CoreMotherGenome = default(Genome);
		CoreFatherGenome = default(Genome);
		CoreCharId = -1;
		CoreChar = null;
		IsCoreCharInfertile = false;
		SpouseCharId = -1;
		SpouseChar = null;
		CreatedCharIds.Clear();
	}
}
