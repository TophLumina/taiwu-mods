using System;
using System.Reflection;
using GameData.Utilities;

namespace Config.Common;

[Serializable]
public abstract class ConfigItem<T, TKey>
{
	public abstract int GetTemplateId();

	public abstract T Duplicate(int id);

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
