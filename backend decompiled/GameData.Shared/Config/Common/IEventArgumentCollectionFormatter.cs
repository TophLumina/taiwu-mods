namespace Config.Common;

public interface IEventArgumentCollectionFormatter
{
	int ToTemplateId(string str);

	string ToArgString(int templateId);
}
