using System;
using System.Collections.Generic;

namespace Config.Common;

public interface IConfigData
{
	IReadOnlyDictionary<string, int> RefNameMap { get; }

	void Init();

	int GetItemId(string refName);

	int AddExtraItem(string identifier, string refName, object configItem);

	string GetRefName(int templateId)
	{
		throw new NotImplementedException();
	}

	void ExportToFiles(string directory)
	{
	}

	void ImportFromFiles(string directory)
	{
	}

	void CreateItems()
	{
	}
}
