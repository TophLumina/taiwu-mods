using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

public interface IMarkAppearHandler
{
	void OnMarkAppear(DataContext context, CombatCharacter combatChar, int appearCount);
}
