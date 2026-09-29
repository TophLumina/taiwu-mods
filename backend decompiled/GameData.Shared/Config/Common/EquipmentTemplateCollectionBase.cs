using System.Collections;
using System.Collections.Generic;

namespace Config.Common;

public abstract class EquipmentTemplateCollectionBase<T> : ItemTemplateCollectionBase<T>, IEnumerable<EquipmentTemplateBase>, IEnumerable where T : EquipmentTemplateBase
{
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
