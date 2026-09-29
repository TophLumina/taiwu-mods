namespace GameData.Domains.Character.Display;

public interface ISelectCharacterData
{
	int CharacterId { get; }

	CharacterDisplayDataForGeneralScrollList GetGeneralScrollListData();
}
