using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMapBlockButton : ConfigData<CharacterMapBlockButtonItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 改名
		/// </summary>
		public const sbyte Rename = 0;

		/// <summary>
		/// 取消关注
		/// </summary>
		public const sbyte Delete = 1;

		/// <summary>
		/// 交互
		/// </summary>
		public const sbyte Todo = 2;

		/// <summary>
		/// 特别关注-改名
		/// </summary>
		public const sbyte Change = 3;

		/// <summary>
		/// 特别关注-取消
		/// </summary>
		public const sbyte Close = 4;

		/// <summary>
		/// 人物信息
		/// </summary>
		public const sbyte ShowInfo = 5;

		/// <summary>
		/// 结识
		/// </summary>
		public const sbyte NotMetYet = 6;

		/// <summary>
		/// 面壁阅经
		/// </summary>
		public const sbyte SpiritualDebtInteractionShaolin = 7;

		/// <summary>
		/// 天府之国
		/// </summary>
		public const sbyte SpiritualDebtInteractionEmei = 8;

		/// <summary>
		/// 起死回生
		/// </summary>
		public const sbyte SpiritualDebtInteractionBaihua = 9;

		/// <summary>
		/// 七星调元
		/// </summary>
		public const sbyte SpiritualDebtInteractionWudang = 10;

		/// <summary>
		/// 石牢静坐
		/// </summary>
		public const sbyte SpiritualDebtInteractionYuanshan = 11;

		/// <summary>
		/// 散播威名
		/// </summary>
		public const sbyte SpiritualDebtInteractionShixiang = 12;

		/// <summary>
		/// 王禅典籍
		/// </summary>
		public const sbyte SpiritualDebtInteractionRanshan = 13;

		/// <summary>
		/// 玉镜沉思
		/// </summary>
		public const sbyte SpiritualDebtInteractionXuannv = 14;

		/// <summary>
		/// 欧冶古具
		/// </summary>
		public const sbyte SpiritualDebtInteractionZhujian = 15;

		/// <summary>
		/// 秘药延寿
		/// </summary>
		public const sbyte SpiritualDebtInteractionKongsang = 16;

		/// <summary>
		/// 金刚秘法
		/// </summary>
		public const sbyte SpiritualDebtInteractionJingang = 17;

		/// <summary>
		/// 五圣秘浴
		/// </summary>
		public const sbyte SpiritualDebtInteractionWuxian = 18;

		/// <summary>
		/// 委托暗杀
		/// </summary>
		public const sbyte SpiritualDebtInteractionJieqing = 19;

		/// <summary>
		/// 龙岛忠仆
		/// </summary>
		public const sbyte SpiritualDebtInteractionFulong = 20;

		/// <summary>
		/// 血池秘法
		/// </summary>
		public const sbyte SpiritualDebtInteractionXuehou = 21;

		/// <summary>
		/// 收养元鸡
		/// </summary>
		public const sbyte IdentityAdoptChicken = 22;

		/// <summary>
		/// 推恩施义
		/// </summary>
		public const sbyte ExtendFavor = 23;

		/// <summary>
		/// 牵线搭桥
		/// </summary>
		public const sbyte IdentityMatchmaker = 24;

		/// <summary>
		/// 商会赞誉
		/// </summary>
		public const sbyte MerchantPraise = 25;

		/// <summary>
		/// 诗画怡情
		/// </summary>
		public const sbyte PoemAndImage = 26;

		/// <summary>
		/// 浏览货物
		/// </summary>
		public const sbyte IdentityBrowseGoods = 27;

		/// <summary>
		/// 疗伤驱毒
		/// </summary>
		public const sbyte IdentityDoctorHeal = 28;

		/// <summary>
		/// 修补物品
		/// </summary>
		public const sbyte IdentityRepairMan = 29;

		/// <summary>
		/// 采买鲜果
		/// </summary>
		public const sbyte IdentityFarmer = 30;

		/// <summary>
		/// 梳头修面
		/// </summary>
		public const sbyte IdentityHairCutter = 31;

		/// <summary>
		/// 施舍银钱
		/// </summary>
		public const sbyte IdentityMoneyCharity = 32;

		/// <summary>
		/// 交换藏书
		/// </summary>
		public const sbyte ExchangeSkillBook = 33;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 改名
		/// </summary>
		public static CharacterMapBlockButtonItem Rename => Instance[(sbyte)0];

		/// <summary>
		/// 取消关注
		/// </summary>
		public static CharacterMapBlockButtonItem Delete => Instance[(sbyte)1];

		/// <summary>
		/// 交互
		/// </summary>
		public static CharacterMapBlockButtonItem Todo => Instance[(sbyte)2];

		/// <summary>
		/// 特别关注-改名
		/// </summary>
		public static CharacterMapBlockButtonItem Change => Instance[(sbyte)3];

		/// <summary>
		/// 特别关注-取消
		/// </summary>
		public static CharacterMapBlockButtonItem Close => Instance[(sbyte)4];

		/// <summary>
		/// 人物信息
		/// </summary>
		public static CharacterMapBlockButtonItem ShowInfo => Instance[(sbyte)5];

		/// <summary>
		/// 结识
		/// </summary>
		public static CharacterMapBlockButtonItem NotMetYet => Instance[(sbyte)6];

		/// <summary>
		/// 面壁阅经
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionShaolin => Instance[(sbyte)7];

		/// <summary>
		/// 天府之国
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionEmei => Instance[(sbyte)8];

		/// <summary>
		/// 起死回生
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionBaihua => Instance[(sbyte)9];

		/// <summary>
		/// 七星调元
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionWudang => Instance[(sbyte)10];

		/// <summary>
		/// 石牢静坐
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionYuanshan => Instance[(sbyte)11];

		/// <summary>
		/// 散播威名
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionShixiang => Instance[(sbyte)12];

		/// <summary>
		/// 王禅典籍
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionRanshan => Instance[(sbyte)13];

		/// <summary>
		/// 玉镜沉思
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionXuannv => Instance[(sbyte)14];

		/// <summary>
		/// 欧冶古具
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionZhujian => Instance[(sbyte)15];

		/// <summary>
		/// 秘药延寿
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionKongsang => Instance[(sbyte)16];

		/// <summary>
		/// 金刚秘法
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionJingang => Instance[(sbyte)17];

		/// <summary>
		/// 五圣秘浴
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionWuxian => Instance[(sbyte)18];

		/// <summary>
		/// 委托暗杀
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionJieqing => Instance[(sbyte)19];

		/// <summary>
		/// 龙岛忠仆
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionFulong => Instance[(sbyte)20];

		/// <summary>
		/// 血池秘法
		/// </summary>
		public static CharacterMapBlockButtonItem SpiritualDebtInteractionXuehou => Instance[(sbyte)21];

		/// <summary>
		/// 收养元鸡
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityAdoptChicken => Instance[(sbyte)22];

		/// <summary>
		/// 推恩施义
		/// </summary>
		public static CharacterMapBlockButtonItem ExtendFavor => Instance[(sbyte)23];

		/// <summary>
		/// 牵线搭桥
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityMatchmaker => Instance[(sbyte)24];

		/// <summary>
		/// 商会赞誉
		/// </summary>
		public static CharacterMapBlockButtonItem MerchantPraise => Instance[(sbyte)25];

		/// <summary>
		/// 诗画怡情
		/// </summary>
		public static CharacterMapBlockButtonItem PoemAndImage => Instance[(sbyte)26];

		/// <summary>
		/// 浏览货物
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityBrowseGoods => Instance[(sbyte)27];

		/// <summary>
		/// 疗伤驱毒
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityDoctorHeal => Instance[(sbyte)28];

		/// <summary>
		/// 修补物品
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityRepairMan => Instance[(sbyte)29];

		/// <summary>
		/// 采买鲜果
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityFarmer => Instance[(sbyte)30];

		/// <summary>
		/// 梳头修面
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityHairCutter => Instance[(sbyte)31];

		/// <summary>
		/// 施舍银钱
		/// </summary>
		public static CharacterMapBlockButtonItem IdentityMoneyCharity => Instance[(sbyte)32];

		/// <summary>
		/// 交换藏书
		/// </summary>
		public static CharacterMapBlockButtonItem ExchangeSkillBook => Instance[(sbyte)33];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterMapBlockButton Instance = new CharacterMapBlockButton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "InteractionEventOption", "TemplateId", "IconNormal", "IconHighLight", "IconPressed", "IconDisable" };

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
		_dataArray.Add(new CharacterMapBlockButtonItem(0, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_0"), "ui9_btn_map_block_character_shortcut_button_rename_0", "ui9_btn_map_block_character_shortcut_button_rename_1", "ui9_btn_map_block_character_shortcut_button_rename_2", "ui9_btn_map_block_character_shortcut_button_rename_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(1, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_1"), "ui9_btn_map_block_character_shortcut_button_delete_0", "ui9_btn_map_block_character_shortcut_button_delete_1", "ui9_btn_map_block_character_shortcut_button_delete_2", "ui9_btn_map_block_character_shortcut_button_delete_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(2, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_2"), "ui9_btn_map_block_character_shortcut_button_todo_0", "ui9_btn_map_block_character_shortcut_button_todo_1", "ui9_btn_map_block_character_shortcut_button_todo_2", "ui9_btn_map_block_character_shortcut_button_todo_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(3, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_3"), "ui9_btn_map_block_character_shortcut_button_change_0", "ui9_btn_map_block_character_shortcut_button_change_1", "ui9_btn_map_block_character_shortcut_button_change_2", "ui9_btn_map_block_character_shortcut_button_change_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(4, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_4"), "ui9_btn_map_block_character_shortcut_button_close_0", "ui9_btn_map_block_character_shortcut_button_close_1", "ui9_btn_map_block_character_shortcut_button_close_2", "ui9_btn_map_block_character_shortcut_button_close_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(5, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_5"), "ui9_btn_map_block_character_shortcut_button_showinfo_0", "ui9_btn_map_block_character_shortcut_button_showinfo_1", "ui9_btn_map_block_character_shortcut_button_showinfo_2", "ui9_btn_map_block_character_shortcut_button_showinfo_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(6, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_6"), "ui9_btn_map_block_character_shortcut_button_notmetyet_0", "ui9_btn_map_block_character_shortcut_button_notmetyet_1", "ui9_btn_map_block_character_shortcut_button_notmetyet_2", "ui9_btn_map_block_character_shortcut_button_notmetyet_3", -1));
		_dataArray.Add(new CharacterMapBlockButtonItem(7, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_7"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshaolin_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshaolin_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshaolin_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshaolin_3", 64));
		_dataArray.Add(new CharacterMapBlockButtonItem(8, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_8"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionemei_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionemei_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionemei_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionemei_3", 65));
		_dataArray.Add(new CharacterMapBlockButtonItem(9, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_9"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionbaihua_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionbaihua_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionbaihua_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionbaihua_3", 66));
		_dataArray.Add(new CharacterMapBlockButtonItem(10, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_10"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwudang_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwudang_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwudang_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwudang_3", 67));
		_dataArray.Add(new CharacterMapBlockButtonItem(11, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_11"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionyuanshan_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionyuanshan_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionyuanshan_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionyuanshan_3", 68));
		_dataArray.Add(new CharacterMapBlockButtonItem(12, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_12"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshixiang_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshixiang_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshixiang_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionshixiang_3", 69));
		_dataArray.Add(new CharacterMapBlockButtonItem(13, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_13"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionranshan_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionranshan_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionranshan_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionranshan_3", 70));
		_dataArray.Add(new CharacterMapBlockButtonItem(14, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_14"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuannv_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuannv_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuannv_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuannv_3", 71));
		_dataArray.Add(new CharacterMapBlockButtonItem(15, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_15"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionzhujian_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionzhujian_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionzhujian_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionzhujian_3", 72));
		_dataArray.Add(new CharacterMapBlockButtonItem(16, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_16"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionkongsang_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionkongsang_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionkongsang_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionkongsang_3", 74));
		_dataArray.Add(new CharacterMapBlockButtonItem(17, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_17"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjingang_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjingang_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjingang_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjingang_3", 75));
		_dataArray.Add(new CharacterMapBlockButtonItem(18, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_18"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwuxian_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwuxian_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwuxian_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionwuxian_3", 76));
		_dataArray.Add(new CharacterMapBlockButtonItem(19, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_19"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjieqing_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjieqing_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjieqing_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionjieqing_3", 77));
		_dataArray.Add(new CharacterMapBlockButtonItem(20, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_20"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionfulong_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionfulong_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionfulong_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionfulong_3", 78));
		_dataArray.Add(new CharacterMapBlockButtonItem(21, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_21"), "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuehou_0", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuehou_1", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuehou_2", "ui9_btn_map_block_character_shortcut_button_spiritualdebtinteractionxuehou_3", 79));
		_dataArray.Add(new CharacterMapBlockButtonItem(22, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_22"), "ui9_btn_map_block_character_shortcut_button_identityadoptchicken_0", "ui9_btn_map_block_character_shortcut_button_identityadoptchicken_1", "ui9_btn_map_block_character_shortcut_button_identityadoptchicken_2", "ui9_btn_map_block_character_shortcut_button_identityadoptchicken_3", 53));
		_dataArray.Add(new CharacterMapBlockButtonItem(23, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_23"), "ui9_btn_map_block_character_shortcut_button_extendfavor_0", "ui9_btn_map_block_character_shortcut_button_extendfavor_1", "ui9_btn_map_block_character_shortcut_button_extendfavor_2", "ui9_btn_map_block_character_shortcut_button_extendfavor_3", 128));
		_dataArray.Add(new CharacterMapBlockButtonItem(24, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_24"), "ui9_btn_map_block_character_shortcut_button_identitymatchmaker_0", "ui9_btn_map_block_character_shortcut_button_identitymatchmaker_1", "ui9_btn_map_block_character_shortcut_button_identitymatchmaker_2", "ui9_btn_map_block_character_shortcut_button_identitymatchmaker_3", 129));
		_dataArray.Add(new CharacterMapBlockButtonItem(25, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_25"), "ui9_btn_map_block_character_shortcut_button_merchantpraise_0", "ui9_btn_map_block_character_shortcut_button_merchantpraise_1", "ui9_btn_map_block_character_shortcut_button_merchantpraise_2", "ui9_btn_map_block_character_shortcut_button_merchantpraise_3", 132));
		_dataArray.Add(new CharacterMapBlockButtonItem(26, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_26"), "ui9_btn_map_block_character_shortcut_button_poemandimage_0", "ui9_btn_map_block_character_shortcut_button_poemandimage_1", "ui9_btn_map_block_character_shortcut_button_poemandimage_2", "ui9_btn_map_block_character_shortcut_button_poemandimage_3", 131));
		_dataArray.Add(new CharacterMapBlockButtonItem(27, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_27"), "ui9_btn_map_block_character_shortcut_button_identitybrowsegoods_0", "ui9_btn_map_block_character_shortcut_button_identitybrowsegoods_1", "ui9_btn_map_block_character_shortcut_button_identitybrowsegoods_2", "ui9_btn_map_block_character_shortcut_button_identitybrowsegoods_3", 57));
		_dataArray.Add(new CharacterMapBlockButtonItem(28, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_28"), "ui9_btn_map_block_character_shortcut_button_identitydoctorheal_0", "ui9_btn_map_block_character_shortcut_button_identitydoctorheal_1", "ui9_btn_map_block_character_shortcut_button_identitydoctorheal_2", "ui9_btn_map_block_character_shortcut_button_identitydoctorheal_3", 58));
		_dataArray.Add(new CharacterMapBlockButtonItem(29, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_29"), "ui9_btn_map_block_character_shortcut_button_identityrepairman_0", "ui9_btn_map_block_character_shortcut_button_identityrepairman_1", "ui9_btn_map_block_character_shortcut_button_identityrepairman_2", "ui9_btn_map_block_character_shortcut_button_identityrepairman_3", 59));
		_dataArray.Add(new CharacterMapBlockButtonItem(30, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_30"), "ui9_btn_map_block_character_shortcut_button_identityfarmer_0", "ui9_btn_map_block_character_shortcut_button_identityfarmer_1", "ui9_btn_map_block_character_shortcut_button_identityfarmer_2", "ui9_btn_map_block_character_shortcut_button_identityfarmer_3", 141));
		_dataArray.Add(new CharacterMapBlockButtonItem(31, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_31"), "ui9_btn_map_block_character_shortcut_button_identityhaircutter_0", "ui9_btn_map_block_character_shortcut_button_identityhaircutter_1", "ui9_btn_map_block_character_shortcut_button_identityhaircutter_2", "ui9_btn_map_block_character_shortcut_button_identityhaircutter_3", 60));
		_dataArray.Add(new CharacterMapBlockButtonItem(32, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_32"), "ui9_btn_map_block_character_shortcut_button_identitymoneycharity_0", "ui9_btn_map_block_character_shortcut_button_identitymoneycharity_1", "ui9_btn_map_block_character_shortcut_button_identitymoneycharity_2", "ui9_btn_map_block_character_shortcut_button_identitymoneycharity_3", 142));
		_dataArray.Add(new CharacterMapBlockButtonItem(33, LocalStringManager.GetConfig("CharacterMapBlockButton_language", "Name_33"), "ui9_btn_map_block_character_shortcut_button_exchangeskillbook_0", "ui9_btn_map_block_character_shortcut_button_exchangeskillbook_1", "ui9_btn_map_block_character_shortcut_button_exchangeskillbook_2", "ui9_btn_map_block_character_shortcut_button_exchangeskillbook_3", 21));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterMapBlockButtonItem>(34);
		CreateItems0();
	}
}
