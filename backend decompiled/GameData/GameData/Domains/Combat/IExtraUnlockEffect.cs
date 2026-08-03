using GameData.Common;

namespace GameData.Domains.Combat;

public interface IExtraUnlockEffect
{
	bool IsDirect { get; }

	void DoAffectAfterCost(DataContext context, int weaponIndex);
}
