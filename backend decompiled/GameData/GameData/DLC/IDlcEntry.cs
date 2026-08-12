using GameData.Common;
using GameData.Serializer;

namespace GameData.DLC;

public interface IDlcEntry : ISerializableGameData
{
	void OnLoadedArchiveData(bool firstEnable);

	void OnEnterNewWorld();

	void OnPostAdvanceMonth(DataContext context);

	void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive);

	void FixAbnormalArchiveData(DataContext context)
	{
	}
}
