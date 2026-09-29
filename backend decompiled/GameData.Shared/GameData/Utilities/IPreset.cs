namespace GameData.Utilities;

public interface IPreset
{
	int CurrentPresetIndex { get; }

	bool CanAdd { get; }

	bool CanDelete { get; }

	int ActivePresetCount { get; }

	bool ChangePreset(int newPresetIndex);

	void AddPreset();

	void ClonePreset();

	void ClearPreset();

	void DeletePreset();
}
