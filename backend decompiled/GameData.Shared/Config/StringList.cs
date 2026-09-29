using System;
using System.Collections.Generic;

namespace Config;

[Serializable]
public class StringList : List<string>
{
	public StringList(params string[] sources)
	{
		AddRange(sources);
	}

	public StringList()
	{
	}
}
