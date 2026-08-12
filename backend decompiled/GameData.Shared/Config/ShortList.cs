using System;
using System.Collections.Generic;

namespace Config;

[Serializable]
public class ShortList
{
	public List<short> DataList = new List<short>();

	public ShortList(params short[] args)
	{
		DataList.AddRange(args);
	}
}
