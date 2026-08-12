using System.Collections;
using System.Collections.Generic;

namespace Config.Common;

/// <summary>
/// 物品配置数据集合基类
/// </summary>
public abstract class ItemTemplateCollectionBase<T> : IEnumerable<ItemTemplateBase>, IEnumerable where T : ItemTemplateBase
{
	/// <summary>
	/// 获取物品数据个数
	/// </summary>
	public abstract int Count { get; }

	/// <summary>
	/// 获取指定模板 ID 对应的物品基类数据
	/// </summary>
	public abstract ItemTemplateBase GetItemBase(short templateId);

	IEnumerator<ItemTemplateBase> IEnumerable<ItemTemplateBase>.GetEnumerator()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current as ItemTemplateBase;
		}
	}

	public abstract IEnumerator GetEnumerator();
}
