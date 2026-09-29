using System.Collections.Generic;

namespace Config.Common;

public interface IConfigBuiltinItemLoader<T> where T : IConfigData
{
	void FillAll(List<T> dataArray);
}
