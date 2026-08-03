using System;
using System.Reflection;
using GameData.Utilities;

namespace Config.Common;

/// <summary>
/// 配置数据条目的接口
/// </summary>
[Serializable]
public abstract class ConfigItem<T, TKey>
{
	/// <summary>
	/// 获取配置数据Id
	/// </summary>
	public abstract int GetTemplateId();

	/// <summary>
	/// 复制配置
	/// </summary>
	/// <param name="id">需保证id可以转化为Ttemplate</param>
	/// <returns>复制的配置表，其TemplateId为(Ttemplate)id</returns>
	public abstract T Duplicate(int id);

	/// <summary>
	/// 修改配置
	/// </summary>
	public void Modify(string fieldName, object item)
	{
		FieldInfo field = GetType().GetField(fieldName);
		if ((object)field == null)
		{
			AdaptableLog.TagWarning("Modding", "`{GetType()}` has no field named `{fieldName}`", appendWarningMessage: true);
		}
		else if (field.FieldType.IsAssignableFrom(item.GetType()))
		{
			field.SetValue(this, item);
		}
		else
		{
			AdaptableLog.TagWarning("Modding", "`{field}` has type `{field.Type}` which is not assignable from `{item.GetType()}`", appendWarningMessage: true);
		}
	}
}
