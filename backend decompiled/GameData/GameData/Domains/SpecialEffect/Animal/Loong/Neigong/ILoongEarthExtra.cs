using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public interface ILoongEarthExtra
{
	void OnSilenced(DataContext context, CombatCharacter combatChar, short skillId);
}
