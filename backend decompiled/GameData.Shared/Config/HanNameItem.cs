using System;

namespace Config;

[Serializable]
public class HanNameItem
{
	public readonly short TemplateId;

	public readonly string MiddleChar;

	public readonly string[] ApartMan;

	public readonly string[] ApartWoman;

	public readonly string[] ApartNeutral;

	public readonly string[] SerialMan;

	public readonly string[] SerialWoman;

	public readonly string[] SerialNeutral;

	public HanNameItem(short id, string middleChar, string[] apartMan, string[] apartWoman, string[] apartNeutral, string[] serialMan, string[] serialWoman, string[] serialNeutral)
	{
		TemplateId = id;
		MiddleChar = middleChar;
		ApartMan = apartMan;
		ApartWoman = apartWoman;
		ApartNeutral = apartNeutral;
		SerialMan = serialMan;
		SerialWoman = serialWoman;
		SerialNeutral = serialNeutral;
	}
}
