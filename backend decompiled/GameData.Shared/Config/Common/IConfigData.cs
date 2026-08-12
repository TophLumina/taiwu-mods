using System;
using System.Collections.Generic;

namespace Config.Common;

/// <summary>
/// 配置数据类的接口
/// </summary>
public interface IConfigData
{
	/// <summary>
	/// 引用名 =&gt; 模板ID 映射
	/// </summary>
	IReadOnlyDictionary<string, int> RefNameMap { get; }

	/// <summary>
	/// 初始化配置数据, 把数据重置为原始值
	/// </summary>
	void Init();

	/// <summary>
	/// 获取引用名对应的条目 Id
	/// </summary>
	int GetItemId(string refName);

	/// <summary>
	/// 添加扩展配置项
	/// </summary>
	int AddExtraItem(string identifier, string refName, object configItem);

	/// <summary>
	/// 获取引用名
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	string GetRefName(int templateId)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 导出到文件
	/// </summary>
	/// <param name="directory">导出的目标目录</param>
	void ExportToFiles(string directory)
	{
	}

	/// <summary>
	/// 从文件导入
	/// </summary>
	/// <param name="directory">数据文件所在的目录</param>
	void ImportFromFiles(string directory)
	{
	}

	/// <summary>
	/// 直接创建.
	/// </summary>
	void CreateItems()
	{
	}
}
