using GameData.Common;

namespace GameData.Domains.Taiwu.VillagerRole;

public interface IVillagerRoleArrangementExecutor : IVillagerRoleSelectLocation
{
	void ExecuteArrangementAction(DataContext context);
}
