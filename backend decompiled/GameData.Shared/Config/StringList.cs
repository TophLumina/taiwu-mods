using System;
using System.Collections.Generic;

namespace Config;

/// <summary>
/// <see cref="T:System.String" /> 类型列表
/// </summary>
[Serializable]
public class StringList : List<string>
{
	/// <summary>
	/// 构造数据列表
	/// </summary>
	public StringList(params string[] sources)
	{
		AddRange(sources);
	}

	public StringList()
	{
	}
}
