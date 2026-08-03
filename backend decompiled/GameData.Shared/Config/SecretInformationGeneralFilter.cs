using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationGeneralFilter : ConfigData<SecretInformationGeneralFilterItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 战斗
		/// </summary>
		public const short Combat = 0;

		/// <summary>
		/// 恶行
		/// </summary>
		public const short Heinous = 1;

		/// <summary>
		/// 修习
		/// </summary>
		public const short Learn = 2;

		/// <summary>
		/// 关系
		/// </summary>
		public const short Relation = 3;

		/// <summary>
		/// 人情
		/// </summary>
		public const short HumanAffairs = 4;

		/// <summary>
		/// 生育
		/// </summary>
		public const short Birth = 5;

		/// <summary>
		/// 关押
		/// </summary>
		public const short Kidnap = 6;

		/// <summary>
		/// 福祸
		/// </summary>
		public const short Fate = 7;

		/// <summary>
		/// 丧葬
		/// </summary>
		public const short Funeral = 8;

		/// <summary>
		/// 其它
		/// </summary>
		public const short Other = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 战斗
		/// </summary>
		public static SecretInformationGeneralFilterItem Combat => Instance[(short)0];

		/// <summary>
		/// 恶行
		/// </summary>
		public static SecretInformationGeneralFilterItem Heinous => Instance[(short)1];

		/// <summary>
		/// 修习
		/// </summary>
		public static SecretInformationGeneralFilterItem Learn => Instance[(short)2];

		/// <summary>
		/// 关系
		/// </summary>
		public static SecretInformationGeneralFilterItem Relation => Instance[(short)3];

		/// <summary>
		/// 人情
		/// </summary>
		public static SecretInformationGeneralFilterItem HumanAffairs => Instance[(short)4];

		/// <summary>
		/// 生育
		/// </summary>
		public static SecretInformationGeneralFilterItem Birth => Instance[(short)5];

		/// <summary>
		/// 关押
		/// </summary>
		public static SecretInformationGeneralFilterItem Kidnap => Instance[(short)6];

		/// <summary>
		/// 福祸
		/// </summary>
		public static SecretInformationGeneralFilterItem Fate => Instance[(short)7];

		/// <summary>
		/// 丧葬
		/// </summary>
		public static SecretInformationGeneralFilterItem Funeral => Instance[(short)8];

		/// <summary>
		/// 其它
		/// </summary>
		public static SecretInformationGeneralFilterItem Other => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
		_dataArray.Add(new SecretInformationGeneralFilterItem(9, LocalStringManager.GetConfig("SecretInformationGeneralFilter_language", "Name_9"), new List<short> { 20, 25, 26, 27, 28 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationGeneralFilterItem>(10);
		CreateItems0();
	}
}
