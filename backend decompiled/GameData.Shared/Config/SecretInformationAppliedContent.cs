using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedContent : ConfigData<SecretInformationAppliedContentItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 重复使用
		/// </summary>
		public const short Repeat = 0;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 重复使用
		/// </summary>
		public static SecretInformationAppliedContentItem Repeat => Instance[(short)0];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SecretInformationAppliedContent Instance = new SecretInformationAppliedContent();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "LinkedResult", "Texts", "TemplateId" };

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
		_dataArray.Add(new SecretInformationAppliedContentItem(0, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_0_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_0_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_0_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_0_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_0_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(1, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_1_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_1_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_1_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_1_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_1_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(2, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_2_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_2_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_2_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_2_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_2_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(3, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_3_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_3_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_3_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_3_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_3_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(4, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_4_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_4_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_4_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_4_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_4_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(5, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_5_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_5_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_5_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_5_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_5_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(6, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_6_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_6_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_6_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_6_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_6_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(7, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_7_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_7_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_7_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_7_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_7_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(8, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_8_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_8_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_8_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_8_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_8_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(9, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_9_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_9_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_9_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_9_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_9_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(10, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_10_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_10_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_10_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_10_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_10_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(11, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_11_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_11_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_11_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_11_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_11_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(12, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_12_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_12_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_12_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_12_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_12_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(13, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_13_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_13_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_13_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_13_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_13_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(14, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_14_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_14_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_14_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_14_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_14_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(15, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_15_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_15_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_15_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_15_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_15_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(16, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_16_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_16_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_16_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_16_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_16_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(17, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_17_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_17_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_17_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_17_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_17_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(18, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_18_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_18_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_18_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_18_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_18_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(19, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_19_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_19_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_19_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_19_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_19_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(20, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_20_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_20_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_20_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_20_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_20_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(21, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_21_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_21_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_21_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_21_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_21_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(22, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_22_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_22_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_22_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_22_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_22_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(23, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_23_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_23_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_23_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_23_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_23_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(24, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_24_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_24_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_24_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_24_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_24_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(25, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_25_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_25_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_25_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_25_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_25_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(26, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_26_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_26_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_26_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_26_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_26_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(27, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_27_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_27_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_27_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_27_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_27_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(28, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_28_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_28_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_28_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_28_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_28_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(29, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_29_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_29_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_29_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_29_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_29_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(30, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_30_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_30_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_30_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_30_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_30_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(31, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_31_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_31_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_31_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_31_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_31_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(32, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_32_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_32_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_32_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_32_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_32_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(33, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_33_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_33_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_33_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_33_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_33_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(34, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_34_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_34_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_34_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_34_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_34_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(35, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_35_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_35_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_35_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_35_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_35_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(36, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_36_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_36_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_36_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_36_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_36_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(37, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_37_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_37_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_37_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_37_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_37_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(38, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_38_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_38_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_38_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_38_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_38_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(39, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_39_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_39_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_39_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_39_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_39_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(40, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_40_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_40_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_40_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_40_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_40_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(41, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_41_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_41_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_41_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_41_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_41_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(42, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_42_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_42_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_42_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_42_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_42_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(43, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_43_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_43_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_43_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_43_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_43_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(44, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_44_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_44_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_44_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_44_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_44_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(45, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_45_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_45_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_45_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_45_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_45_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(46, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_46_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_46_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_46_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_46_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_46_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(47, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_47_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_47_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_47_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_47_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_47_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(48, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_48_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_48_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_48_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_48_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_48_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(49, 232, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(50, -1, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(51, 232, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(52, 246, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(53, 246, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(54, 257, new string[0]));
		_dataArray.Add(new SecretInformationAppliedContentItem(55, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_55_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_55_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_55_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_55_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_55_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(56, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_56_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_56_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_56_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_56_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_56_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(57, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_57_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_57_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_57_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_57_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_57_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(58, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_58_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_58_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_58_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_58_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_58_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(59, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_59_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_59_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_59_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_59_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_59_4")
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationAppliedContentItem(60, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_60_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_60_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_60_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_60_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_60_4")
		}));
		_dataArray.Add(new SecretInformationAppliedContentItem(61, -1, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_61_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_61_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_61_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_61_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedContent_language", "Texts_61_4")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationAppliedContentItem>(62);
		CreateItems0();
		CreateItems1();
	}
}
