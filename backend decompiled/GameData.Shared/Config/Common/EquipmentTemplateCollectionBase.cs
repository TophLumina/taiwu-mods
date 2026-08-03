using System.Collections;
using System.Collections.Generic;

namespace Config.Common;

/// <summary>
/// 装备品配置数据集合基类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class EquipmentTemplateCollectionBase<T> : ItemTemplateCollectionBase<T>, IEnumerable<EquipmentTemplateBase>, IEnumerable where T : EquipmentTemplateBase
{
	/// <summary>
	/// 获取指定模板 ID 对应的装备品基类数据
	/// </summary>
	public abstract EquipmentTemplateBase GetItemEquipmentBase(short templateId);

	IEnumerator<EquipmentTemplateBase> IEnumerable<EquipmentTemplateBase>.GetEnumerator()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current as EquipmentTemplateBase;
		}
	}
}
