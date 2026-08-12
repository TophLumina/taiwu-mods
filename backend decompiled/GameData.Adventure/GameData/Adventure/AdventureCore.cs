using System.Collections.Generic;
using System.IO;

namespace GameData.Adventure;

public class AdventureCore
{
	private readonly Dictionary<int, AdventureData> _adventureData = new Dictionary<int, AdventureData>();

	private readonly Dictionary<int, AdventureElementData> _adventureElementData = new Dictionary<int, AdventureElementData>();

	private readonly Dictionary<int, AdventureMajorEventData> _adventureMajorEventData = new Dictionary<int, AdventureMajorEventData>();

	public IEnumerable<AdventureData> AllAdventures => _adventureData.Values;

	public IEnumerable<AdventureElementData> AllAdventureElements => _adventureElementData.Values;

	public IEnumerable<AdventureMajorEventData> AllAdventureMajorEvents => _adventureMajorEventData.Values;

	public AdventureData GetAdventureData(int id)
	{
		return _adventureData[id];
	}

	public bool TryGetAdventureData(int id, out AdventureData adventureData)
	{
		return _adventureData.TryGetValue(id, out adventureData);
	}

	public AdventureElementData GetAdventureElementData(int id)
	{
		return _adventureElementData[id];
	}

	public bool TryGetAdventureElementData(int id, out AdventureElementData adventureElementData)
	{
		return _adventureElementData.TryGetValue(id, out adventureElementData);
	}

	public AdventureMajorEventData GetAdventureMajorEventData(int id)
	{
		return _adventureMajorEventData[id];
	}

	public bool TryGetAdventureMajorEventData(int id, out AdventureMajorEventData adventureMajorEventData)
	{
		return _adventureMajorEventData.TryGetValue(id, out adventureMajorEventData);
	}

	public IAdventureData GetAdventureAny(int id)
	{
		AdventureMajorEventData majorEventData;
		if (!TryGetAdventureData(id, out var data))
		{
			return TryGetAdventureMajorEventData(id, out majorEventData) ? majorEventData : null;
		}
		return data;
	}

	public void LoadFrom(string root)
	{
		if (!Directory.Exists(root))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(root).GetFiles("*.*", SearchOption.AllDirectories);
		foreach (FileInfo path in files)
		{
			switch (path.Extension)
			{
			case ".advd":
			{
				if (AdventureData.TryLoad(path.FullName, out var data2))
				{
					_adventureData[data2.Id] = data2;
				}
				break;
			}
			case ".adved":
			{
				if (AdventureElementData.TryLoad(path.FullName, out var element))
				{
					_adventureElementData[element.Id] = element;
				}
				break;
			}
			case ".advmed":
			{
				if (AdventureMajorEventData.TryLoad(path.FullName, out var data))
				{
					_adventureMajorEventData[data.Id] = data;
				}
				break;
			}
			}
		}
	}

	public void UnitTestAppendData(AdventureData data)
	{
		if (data != null)
		{
			_adventureData[data.Id] = data;
		}
	}
}
