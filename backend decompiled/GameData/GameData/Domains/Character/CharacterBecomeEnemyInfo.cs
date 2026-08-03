using System;
using GameData.Domains.Map;

namespace GameData.Domains.Character;

public struct CharacterBecomeEnemyInfo
{
	public int Date;

	public Location Location;

	public short SecretInformationTemplateId;

	public short WugTemplateId;

	[Obsolete("Become enemy info must be created with a character.", true)]
	public CharacterBecomeEnemyInfo()
	{
		throw new NotImplementedException("Become enemy info must be created with a character.");
	}

	public CharacterBecomeEnemyInfo(Character selfChar)
	{
		Date = DomainManager.World.GetCurrDate();
		Location = selfChar.GetValidLocation();
		SecretInformationTemplateId = -1;
		WugTemplateId = -1;
	}
}
