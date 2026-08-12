using System.Collections.Generic;

namespace Config.Common;

/// <summary>
/// 配置数据加载器接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IConfigBuiltinItemLoader<T> where T : IConfigData
{
	void FillAll(List<T> dataArray);
}
