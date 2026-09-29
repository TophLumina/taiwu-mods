using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationParameterType : ConfigData<SecretInformationParameterTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Character = 0;

		public const sbyte Location = 1;

		public const sbyte Resource = 2;

		public const sbyte ItemKey = 3;

		public const sbyte CombatSkill = 4;

		public const sbyte LifeSkill = 5;

		public const sbyte Integer = 6;
	}

	public static class DefValue
	{
		public static SecretInformationParameterTypeItem Character => Instance[(sbyte)0];

		public static SecretInformationParameterTypeItem Location => Instance[(sbyte)1];

		public static SecretInformationParameterTypeItem Resource => Instance[(sbyte)2];

		public static SecretInformationParameterTypeItem ItemKey => Instance[(sbyte)3];

		public static SecretInformationParameterTypeItem CombatSkill => Instance[(sbyte)4];

		public static SecretInformationParameterTypeItem LifeSkill => Instance[(sbyte)5];

		public static SecretInformationParameterTypeItem Integer => Instance[(sbyte)6];
	}

	public static SecretInformationParameterType Instance = new SecretInformationParameterType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SecretInformationParameterTypeItem(0, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_0")));
		_dataArray.Add(new SecretInformationParameterTypeItem(1, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_1")));
		_dataArray.Add(new SecretInformationParameterTypeItem(2, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_2")));
		_dataArray.Add(new SecretInformationParameterTypeItem(3, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_3")));
		_dataArray.Add(new SecretInformationParameterTypeItem(4, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_4")));
		_dataArray.Add(new SecretInformationParameterTypeItem(5, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_5")));
		_dataArray.Add(new SecretInformationParameterTypeItem(6, LocalStringManager.GetConfig("SecretInformationParameterType_language", "Name_6")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationParameterTypeItem>(7);
		CreateItems0();
	}
}
