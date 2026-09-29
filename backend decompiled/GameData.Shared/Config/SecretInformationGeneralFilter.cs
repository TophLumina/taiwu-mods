using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationGeneralFilter : ConfigData<SecretInformationGeneralFilterItem, short>
{
	public static class DefKey
	{
		public const short Combat = 0;

		public const short Heinous = 1;

		public const short Learn = 2;

		public const short Relation = 3;

		public const short HumanAffairs = 4;

		public const short Birth = 5;

		public const short Kidnap = 6;

		public const short Fate = 7;

		public const short Funeral = 8;

		public const short Other = 9;
	}

	public static class DefValue
	{
		public static SecretInformationGeneralFilterItem Combat => Instance[(short)0];

		public static SecretInformationGeneralFilterItem Heinous => Instance[(short)1];

		public static SecretInformationGeneralFilterItem Learn => Instance[(short)2];

		public static SecretInformationGeneralFilterItem Relation => Instance[(short)3];

		public static SecretInformationGeneralFilterItem HumanAffairs => Instance[(short)4];

		public static SecretInformationGeneralFilterItem Birth => Instance[(short)5];

		public static SecretInformationGeneralFilterItem Kidnap => Instance[(short)6];

		public static SecretInformationGeneralFilterItem Fate => Instance[(short)7];

		public static SecretInformationGeneralFilterItem Funeral => Instance[(short)8];

		public static SecretInformationGeneralFilterItem Other => Instance[(short)9];
	}

	public static SecretInformationGeneralFilter Instance = new SecretInformationGeneralFilter();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "DetailedFilter", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SecretInformationGeneralFilterItem(0, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_0"), new List<short> { 0, 2, 19 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(1, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_1"), new List<short> { 6, 7, 8, 9, 10, 3, 4, 5, 43, 5 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(2, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_2"), new List<short> { 12, 13, 14, 16 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(3, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_3"), new List<short>
		{
			29, 30, 31, 32, 35, 33, 36, 37, 34, 38,
			39, 42, 44, 40, 41
		}));
		_dataArray.Add(new SecretInformationGeneralFilterItem(4, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_4"), new List<short> { 21, 22, 23 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(5, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_5"), new List<short> { 45, 46, 47, 48 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(6, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_6"), new List<short> { 1, 49, 50, 51, 52, 53, 54 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(7, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_7"), new List<short> { 55, 56, 57 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(8, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_8"), new List<short> { 17, 24, 18 }));
		_dataArray.Add(new SecretInformationGeneralFilterItem(9, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_9"), new List<short> { 20, 25, 26, 27, 28, 58 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationGeneralFilterItem>(10);
		CreateItems0();
	}
}
