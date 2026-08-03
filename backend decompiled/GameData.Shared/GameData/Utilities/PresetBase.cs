using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

/// <summary>
/// 预设基类
/// </summary>
public abstract class PresetBase<T> : IPreset, ISerializableGameData where T : PresetItemBase<T>, new()
{
	/// <summary>
	/// 当前版本号
	/// </summary>
	private const int Version = 0;

	/// <summary>
	/// 默认预设数量
	/// </summary>
	public const int DefaultPresetCount = 3;

	/// <summary>
	/// 最小预设数量
	/// </summary>
	public const int MinPresetCount = 1;

	/// <summary>
	/// 预设数据
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private readonly List<T> _presets = new List<T>();

	/// <summary>
	/// 最大预设数量
	/// </summary>
	public virtual int MaxPresetCount => 9;

	/// <summary>
	/// 预设数据 - 只读
	/// </summary>
	public IReadOnlyList<T> Presets => _presets;

	/// <inheritdoc />
	[SerializableGameDataField(FieldIndex = 1)]
	public int CurrentPresetIndex { get; private set; }

	/// <inheritdoc />
	public bool CanAdd => _presets.Count < MaxPresetCount;

	/// <inheritdoc />
	public bool CanDelete => _presets.Count > 1;

	/// <inheritdoc />
	public int ActivePresetCount => Presets.Count;

	/// <summary>
	/// 构造方法
	/// </summary>
	protected PresetBase(int defaultPresetCount = 3)
	{
		for (int i = 0; i < defaultPresetCount; i++)
		{
			_presets.Add(new T());
		}
	}

	/// <summary>
	/// 单独将某个预设覆盖为指定预设，成功时返回克隆后的预设，失败时返回 null
	/// </summary>
	public T OverwritePreset(T preset, int presetIndex)
	{
		if (presetIndex < 0 || presetIndex >= ActivePresetCount)
		{
			return null;
		}
		_presets[presetIndex] = preset.Clone();
		return Presets[presetIndex];
	}

	/// <summary>
	/// 覆盖预设数据，仅用于存档修复
	/// </summary>
	public void OverwritePresets(IReadOnlyList<T> presets, int presetIndex)
	{
		if (presets != null && presets.Count > 0)
		{
			_presets.Clear();
			_presets.AddRange(presets);
			CurrentPresetIndex = _presets.GetClampedIndex(presetIndex);
		}
	}

	/// <inheritdoc />
	public bool ChangePreset(int newPresetIndex)
	{
		bool num = _presets.CheckIndex(newPresetIndex);
		if (num)
		{
			CurrentPresetIndex = newPresetIndex;
		}
		return num;
	}

	/// <inheritdoc />
	public void AddPreset()
	{
		if (CanAdd)
		{
			CurrentPresetIndex = _presets.Count;
			_presets.Add(new T());
		}
	}

	/// <inheritdoc />
	public void ClonePreset()
	{
		if (CanAdd)
		{
			T preset = _presets[CurrentPresetIndex];
			CurrentPresetIndex = _presets.Count;
			_presets.Add(preset.Clone());
		}
	}

	/// <inheritdoc />
	public void ClearPreset()
	{
		_presets[CurrentPresetIndex].Clear();
	}

	/// <inheritdoc />
	public void DeletePreset()
	{
		if (CanDelete)
		{
			_presets.RemoveAt(CurrentPresetIndex);
			if (CurrentPresetIndex == _presets.Count)
			{
				CurrentPresetIndex--;
			}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		List<T> presets = _presets;
		if (presets != null && presets.Count > 0)
		{
			foreach (T preset in _presets)
			{
				totalSize += preset.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = 0;
		pCurrData += 4;
		*(int*)pCurrData = _presets?.Count ?? 0;
		pCurrData += 4;
		List<T> presets = _presets;
		if (presets != null && presets.Count > 0)
		{
			foreach (T preset in _presets)
			{
				pCurrData += preset.Serialize(pCurrData);
			}
		}
		*(int*)pCurrData = CurrentPresetIndex;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += 4;
		int presetCount = *(int*)pCurrData;
		pCurrData += 4;
		_presets.Clear();
		for (int i = 0; i < presetCount; i++)
		{
			T preset = new T();
			pCurrData += preset.Deserialize(pCurrData);
			_presets.Add(preset);
		}
		CurrentPresetIndex = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
