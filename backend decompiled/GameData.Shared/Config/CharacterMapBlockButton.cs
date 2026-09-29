using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMapBlockButton : ConfigData<CharacterMapBlockButtonItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Rename = 0;

		public const sbyte Delete = 1;

		public const sbyte Todo = 2;

		public const sbyte Change = 3;

		public const sbyte Close = 4;

		public const sbyte ShowInfo = 5;

		public const sbyte NotMetYet = 6;

		public const sbyte SpiritualDebtInteractionShaolin = 7;

		public const sbyte SpiritualDebtInteractionEmei = 8;

		public const sbyte SpiritualDebtInteractionBaihua = 9;

		public const sbyte SpiritualDebtInteractionWudang = 10;

		public const sbyte SpiritualDebtInteractionYuanshan = 11;

		public const sbyte SpiritualDebtInteractionShixiang = 12;

		public const sbyte SpiritualDebtInteractionRanshan = 13;

		public const sbyte SpiritualDebtInteractionXuannv = 14;

		public const sbyte SpiritualDebtInteractionZhujian = 15;

		public const sbyte SpiritualDebtInteractionKongsang = 16;

		public const sbyte SpiritualDebtInteractionJingang = 17;

		public const sbyte SpiritualDebtInteractionWuxian = 18;

		public const sbyte SpiritualDebtInteractionJieqing = 19;

		public const sbyte SpiritualDebtInteractionFulong = 20;

		public const sbyte SpiritualDebtInteractionXuehou = 21;

		public const sbyte IdentityAdoptChicken = 22;

		public const sbyte ExtendFavor = 23;

		public const sbyte IdentityMatchmaker = 24;

		public const sbyte MerchantPraise = 25;

		public const sbyte PoemAndImage = 26;

		public const sbyte IdentityBrowseGoods = 27;

		public const sbyte IdentityDoctorHeal = 28;

		public const sbyte IdentityRepairMan = 29;

		public const sbyte IdentityFarmer = 30;

		public const sbyte IdentityHairCutter = 31;

		public const sbyte IdentityMoneyCharity = 32;

		public const sbyte ExchangeSkillBook = 33;
	}

	public static class DefValue
	{
		public static CharacterMapBlockButtonItem Rename => Instance[(sbyte)0];

		public static CharacterMapBlockButtonItem Delete => Instance[(sbyte)1];

		public static CharacterMapBlockButtonItem Todo => Instance[(sbyte)2];

		public static CharacterMapBlockButtonItem Change => Instance[(sbyte)3];

		public static CharacterMapBlockButtonItem Close => Instance[(sbyte)4];

		public static CharacterMapBlockButtonItem ShowInfo => Instance[(sbyte)5];

		public static CharacterMapBlockButtonItem NotMetYet => Instance[(sbyte)6];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionShaolin => Instance[(sbyte)7];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionEmei => Instance[(sbyte)8];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionBaihua => Instance[(sbyte)9];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionWudang => Instance[(sbyte)10];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionYuanshan => Instance[(sbyte)11];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionShixiang => Instance[(sbyte)12];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionRanshan => Instance[(sbyte)13];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionXuannv => Instance[(sbyte)14];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionZhujian => Instance[(sbyte)15];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionKongsang => Instance[(sbyte)16];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionJingang => Instance[(sbyte)17];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionWuxian => Instance[(sbyte)18];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionJieqing => Instance[(sbyte)19];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionFulong => Instance[(sbyte)20];

		public static CharacterMapBlockButtonItem SpiritualDebtInteractionXuehou => Instance[(sbyte)21];

		public static CharacterMapBlockButtonItem IdentityAdoptChicken => Instance[(sbyte)22];

		public static CharacterMapBlockButtonItem ExtendFavor => Instance[(sbyte)23];

		public static CharacterMapBlockButtonItem IdentityMatchmaker => Instance[(sbyte)24];

		public static CharacterMapBlockButtonItem MerchantPraise => Instance[(sbyte)25];

		public static CharacterMapBlockButtonItem PoemAndImage => Instance[(sbyte)26];

		public static CharacterMapBlockButtonItem IdentityBrowseGoods => Instance[(sbyte)27];

		public static CharacterMapBlockButtonItem IdentityDoctorHeal => Instance[(sbyte)28];

		public static CharacterMapBlockButtonItem IdentityRepairMan => Instance[(sbyte)29];

		public static CharacterMapBlockButtonItem IdentityFarmer => Instance[(sbyte)30];

		public static CharacterMapBlockButtonItem IdentityHairCutter => Instance[(sbyte)31];

		public static CharacterMapBlockButtonItem IdentityMoneyCharity => Instance[(sbyte)32];

		public static CharacterMapBlockButtonItem ExchangeSkillBook => Instance[(sbyte)33];
	}

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
