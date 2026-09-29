using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public abstract class PresetBase<T> : IPreset, ISerializableGameData where T : PresetItemBase<T>, new()
{
	private const int Version = 0;

	public const int DefaultPresetCount = 3;

	public const int MinPresetCount = 1;

	[SerializableGameDataField(FieldIndex = 0)]
	private readonly List<T> _presets = new List<T>();

	public virtual int MaxPresetCount => 9;

	public IReadOnlyList<T> Presets => _presets;

	[SerializableGameDataField(FieldIndex = 1)]
	public int CurrentPresetIndex { get; private set; }

	public T CurrentPreset => _presets.GetOrDefault(CurrentPresetIndex);

	public bool CanAdd => _presets.Count < MaxPresetCount;

	public bool CanDelete => _presets.Count > 1;

	public int ActivePresetCount => Presets.Count;

	protected PresetBase(int defaultPresetCount = 3)
	{
		for (int i = 0; i < defaultPresetCount; i++)
		{
			_presets.Add(new T());
		}
	}

	public T OverwritePreset(T preset, int presetIndex)
	{
		if (presetIndex < 0 || presetIndex >= ActivePresetCount)
		{
			return null;
		}
		_presets[presetIndex] = preset.Clone();
		return Presets[presetIndex];
	}

	public void OverwritePresets(IReadOnlyList<T> presets, int presetIndex)
	{
		if (presets != null && presets.Count > 0)
		{
			_presets.Clear();
			_presets.AddRange(presets);
			CurrentPresetIndex = _presets.GetClampedIndex(presetIndex);
		}
	}

	public bool ChangePreset(int newPresetIndex)
	{
		bool num = _presets.CheckIndex(newPresetIndex);
		if (num)
		{
			CurrentPresetIndex = newPresetIndex;
		}
		return num;
	}

	public void AddPreset()
	{
		if (CanAdd)
		{
			CurrentPresetIndex = _presets.Count;
			_presets.Add(new T());
		}
	}

	public void ClonePreset()
	{
		if (CanAdd)
		{
			T preset = _presets[CurrentPresetIndex];
			CurrentPresetIndex = _presets.Count;
			_presets.Add(preset.Clone());
		}
	}

	public void ClearPreset()
	{
		_presets[CurrentPresetIndex].Clear();
	}

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
