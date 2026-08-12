using System.Collections.Generic;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthRelationsUpdateModification
{
	public readonly Character Character;

	public List<Character> NewlyMetCharacters;

	public List<(Character targetChar, ushort relationType, bool succeed)> NewRegularRelations;

	public List<(Character targetChar, ushort relationType, bool targetStillHasRelation)> RemovedRegularRelations;

	public (Character targetChar, bool succeed) NewBoyOrGirlFriend;

	public PeriAdvanceMonthRelationsUpdateModification(Character character)
	{
		Character = character;
		NewBoyOrGirlFriend = (targetChar: null, succeed: false);
	}
}
