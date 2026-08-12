namespace GameData.Utilities;

/// <summary>
/// 预设接口
/// </summary>
public interface IPreset
{
	/// <summary>
	/// 当前预设索引
	/// </summary>
	int CurrentPresetIndex { get; }

	/// <summary>
	/// 能否新增预设
	/// </summary>
	bool CanAdd { get; }

	/// <summary>
	/// 能否删除预设
	/// </summary>
	bool CanDelete { get; }

	/// <summary>
	/// 激活预设数量
	/// </summary>
	int ActivePresetCount { get; }

	/// <summary>
	/// 改变当前预设
	/// </summary>
	bool ChangePreset(int newPresetIndex);

	/// <summary>
	/// 新增空白预设
	/// </summary>
	void AddPreset();

	/// <summary>
	/// 克隆当前预设
	/// </summary>
	void ClonePreset();

	/// <summary>
	/// 清空当前预设
	/// </summary>
	void ClearPreset();

	/// <summary>
	/// 删除当前预设
	/// </summary>
	void DeletePreset();
}
