using CompDevLib.Interpreter;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.ObjectInitializer;

public class ItemTemplateInitializer : IObjectInitializer
{
	public object CreateInstance()
	{
		return new UnmanagedVariant<TemplateKey>();
	}

	public void SetField(object instance, string fieldName, object value)
	{
		UnmanagedVariant<TemplateKey> templateKey = (UnmanagedVariant<TemplateKey>)instance;
		if (!(fieldName == "ItemType"))
		{
			if (fieldName == "TemplateId")
			{
				templateKey.Value = new TemplateKey(templateKey.Value.ItemType, (short)(int)value);
			}
		}
		else
		{
			templateKey.Value = new TemplateKey((sbyte)(int)value, templateKey.Value.TemplateId);
		}
	}
}
