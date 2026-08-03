using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Puppet : ConfigData<PuppetItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 陈旧的木偶
		/// </summary>
		public const short Default = 0;

		/// <summary>
		/// 莫女的木偶
		/// </summary>
		public const short Monv = 1;

		/// <summary>
		/// 大岳瑶常的木偶
		/// </summary>
		public const short DayueYaochang = 2;

		/// <summary>
		/// 九寒的木偶
		/// </summary>
		public const short Jiuhan = 3;

		/// <summary>
		/// 金凰儿的木偶
		/// </summary>
		public const short JinHuanger = 4;

		/// <summary>
		/// 衣以候的木偶
		/// </summary>
		public const short YiYihou = 5;

		/// <summary>
		/// 卫起的木偶
		/// </summary>
		public const short WeiQi = 6;

		/// <summary>
		/// 以向的木偶
		/// </summary>
		public const short Yixiang = 7;

		/// <summary>
		/// 血枫的木偶
		/// </summary>
		public const short Xuefeng = 8;

		/// <summary>
		/// 术方的木偶
		/// </summary>
		public const short ShuFang = 9;

		/// <summary>
		/// 红衣僵尸的木偶
		/// </summary>
		public const short SectXuehou0 = 10;

		/// <summary>
		/// 幼年姬穸的木偶
		/// </summary>
		public const short SectXuehou1 = 11;

		/// <summary>
		/// 少年姬穸的木偶
		/// </summary>
		public const short XuehouJixi2 = 12;

		/// <summary>
		/// 成年姬穸的木偶
		/// </summary>
		public const short XuehouJixi3 = 13;

		/// <summary>
		/// 达摩的木偶
		/// </summary>
		public const short SectShaolin = 14;

		/// <summary>
		/// 邋遢道长的木偶
		/// </summary>
		public const short SectWudang = 15;

		/// <summary>
		/// 筠儿的木偶
		/// </summary>
		public const short SectXuannv = 16;

		/// <summary>
		/// 雷坤的木偶
		/// </summary>
		public const short SectShixiang = 17;

		/// <summary>
		/// 苒心毒的木偶
		/// </summary>
		public const short SectWuxian0 = 18;

		/// <summary>
		/// 圣姑的木偶
		/// </summary>
		public const short SectWuxian1 = 19;

		/// <summary>
		/// 石候酒的木偶
		/// </summary>
		public const short SectEmei0 = 20;

		/// <summary>
		/// 白猿的木偶
		/// </summary>
		public const short SectEmei1 = 21;

		/// <summary>
		/// 烛仙的木偶
		/// </summary>
		public const short SectRanshan = 22;

		/// <summary>
		/// 尸陀林骷髅僧的木偶
		/// </summary>
		public const short SectJingang = 23;

		/// <summary>
		/// 白无恙的木偶
		/// </summary>
		public const short SectBaihua0 = 24;

		/// <summary>
		/// 玄无忧的木偶
		/// </summary>
		public const short SectBaihua1 = 25;

		/// <summary>
		/// 复生之人的木偶
		/// </summary>
		public const short SectBaihua2 = 26;

		/// <summary>
		/// 第七十七的木偶
		/// </summary>
		public const short SectFulong = 27;

		/// <summary>
		/// 偃师的木偶
		/// </summary>
		public const short SectZhujian = 28;

		/// <summary>
		/// 廖无命的木偶
		/// </summary>
		public const short SectKongsang = 29;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 陈旧的木偶
		/// </summary>
		public static PuppetItem Default => Instance[(short)0];

		/// <summary>
		/// 莫女的木偶
		/// </summary>
		public static PuppetItem Monv => Instance[(short)1];

		/// <summary>
		/// 大岳瑶常的木偶
		/// </summary>
		public static PuppetItem DayueYaochang => Instance[(short)2];

		/// <summary>
		/// 九寒的木偶
		/// </summary>
		public static PuppetItem Jiuhan => Instance[(short)3];

		/// <summary>
		/// 金凰儿的木偶
		/// </summary>
		public static PuppetItem JinHuanger => Instance[(short)4];

		/// <summary>
		/// 衣以候的木偶
		/// </summary>
		public static PuppetItem YiYihou => Instance[(short)5];

		/// <summary>
		/// 卫起的木偶
		/// </summary>
		public static PuppetItem WeiQi => Instance[(short)6];

		/// <summary>
		/// 以向的木偶
		/// </summary>
		public static PuppetItem Yixiang => Instance[(short)7];

		/// <summary>
		/// 血枫的木偶
		/// </summary>
		public static PuppetItem Xuefeng => Instance[(short)8];

		/// <summary>
		/// 术方的木偶
		/// </summary>
		public static PuppetItem ShuFang => Instance[(short)9];

		/// <summary>
		/// 红衣僵尸的木偶
		/// </summary>
		public static PuppetItem SectXuehou0 => Instance[(short)10];

		/// <summary>
		/// 幼年姬穸的木偶
		/// </summary>
		public static PuppetItem SectXuehou1 => Instance[(short)11];

		/// <summary>
		/// 少年姬穸的木偶
		/// </summary>
		public static PuppetItem XuehouJixi2 => Instance[(short)12];

		/// <summary>
		/// 成年姬穸的木偶
		/// </summary>
		public static PuppetItem XuehouJixi3 => Instance[(short)13];

		/// <summary>
		/// 达摩的木偶
		/// </summary>
		public static PuppetItem SectShaolin => Instance[(short)14];

		/// <summary>
		/// 邋遢道长的木偶
		/// </summary>
		public static PuppetItem SectWudang => Instance[(short)15];

		/// <summary>
		/// 筠儿的木偶
		/// </summary>
		public static PuppetItem SectXuannv => Instance[(short)16];

		/// <summary>
		/// 雷坤的木偶
		/// </summary>
		public static PuppetItem SectShixiang => Instance[(short)17];

		/// <summary>
		/// 苒心毒的木偶
		/// </summary>
		public static PuppetItem SectWuxian0 => Instance[(short)18];

		/// <summary>
		/// 圣姑的木偶
		/// </summary>
		public static PuppetItem SectWuxian1 => Instance[(short)19];

		/// <summary>
		/// 石候酒的木偶
		/// </summary>
		public static PuppetItem SectEmei0 => Instance[(short)20];

		/// <summary>
		/// 白猿的木偶
		/// </summary>
		public static PuppetItem SectEmei1 => Instance[(short)21];

		/// <summary>
		/// 烛仙的木偶
		/// </summary>
		public static PuppetItem SectRanshan => Instance[(short)22];

		/// <summary>
		/// 尸陀林骷髅僧的木偶
		/// </summary>
		public static PuppetItem SectJingang => Instance[(short)23];

		/// <summary>
		/// 白无恙的木偶
		/// </summary>
		public static PuppetItem SectBaihua0 => Instance[(short)24];

		/// <summary>
		/// 玄无忧的木偶
		/// </summary>
		public static PuppetItem SectBaihua1 => Instance[(short)25];

		/// <summary>
		/// 复生之人的木偶
		/// </summary>
		public static PuppetItem SectBaihua2 => Instance[(short)26];

		/// <summary>
		/// 第七十七的木偶
		/// </summary>
		public static PuppetItem SectFulong => Instance[(short)27];

		/// <summary>
		/// 偃师的木偶
		/// </summary>
		public static PuppetItem SectZhujian => Instance[(short)28];

		/// <summary>
		/// 廖无命的木偶
		/// </summary>
		public static PuppetItem SectKongsang => Instance[(short)29];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Puppet Instance = new Puppet();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "SectId", "CharacterId", "TemplateId", "Avatar", "Difficulties" };

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
		_dataArray.Add(new PuppetItem(0, LocalStringManager.GetConfig("Puppet_language", "Name_0"), LocalStringManager.GetConfig("Puppet_language", "Desc_0"), EPuppetType.Normal, "NpcFace_mutouren", 0, 958, new List<sbyte> { 2 }));
		_dataArray.Add(new PuppetItem(1, LocalStringManager.GetConfig("Puppet_language", "Name_1"), LocalStringManager.GetConfig("Puppet_language", "Desc_1"), EPuppetType.Xiangshu, "NpcFace_murenmonv", 0, 39, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(2, LocalStringManager.GetConfig("Puppet_language", "Name_2"), LocalStringManager.GetConfig("Puppet_language", "Desc_2"), EPuppetType.Xiangshu, "NpcFace_murendayueyaochang", 0, 48, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(3, LocalStringManager.GetConfig("Puppet_language", "Name_3"), LocalStringManager.GetConfig("Puppet_language", "Desc_3"), EPuppetType.Xiangshu, "NpcFace_murenjiuhan", 0, 57, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(4, LocalStringManager.GetConfig("Puppet_language", "Name_4"), LocalStringManager.GetConfig("Puppet_language", "Desc_4"), EPuppetType.Xiangshu, "NpcFace_murenjinhuanger", 0, 66, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(5, LocalStringManager.GetConfig("Puppet_language", "Name_5"), LocalStringManager.GetConfig("Puppet_language", "Desc_5"), EPuppetType.Xiangshu, "NpcFace_murenyiyihou", 0, 75, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(6, LocalStringManager.GetConfig("Puppet_language", "Name_6"), LocalStringManager.GetConfig("Puppet_language", "Desc_6"), EPuppetType.Xiangshu, "NpcFace_murenweiqi", 0, 84, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(7, LocalStringManager.GetConfig("Puppet_language", "Name_7"), LocalStringManager.GetConfig("Puppet_language", "Desc_7"), EPuppetType.Xiangshu, "NpcFace_murenyixiang", 0, 93, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(8, LocalStringManager.GetConfig("Puppet_language", "Name_8"), LocalStringManager.GetConfig("Puppet_language", "Desc_8"), EPuppetType.Xiangshu, "NpcFace_murenxuefeng", 0, 102, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(9, LocalStringManager.GetConfig("Puppet_language", "Name_9"), LocalStringManager.GetConfig("Puppet_language", "Desc_9"), EPuppetType.Xiangshu, "NpcFace_murenshufang", 0, 111, new List<sbyte> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(10, LocalStringManager.GetConfig("Puppet_language", "Name_10"), LocalStringManager.GetConfig("Puppet_language", "Desc_10"), EPuppetType.Sect, "NpcFace_murenhongyijiangshi_2", 15, 1272, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(11, LocalStringManager.GetConfig("Puppet_language", "Name_11"), LocalStringManager.GetConfig("Puppet_language", "Desc_11"), EPuppetType.Sect, "NpcFace_murenjixiyounian", 15, 1277, new List<sbyte> { 14 }));
		_dataArray.Add(new PuppetItem(12, LocalStringManager.GetConfig("Puppet_language", "Name_12"), LocalStringManager.GetConfig("Puppet_language", "Desc_12"), EPuppetType.Sect, "NpcFace_murenjixishaonian", 15, 1278, new List<sbyte> { 16 }));
		_dataArray.Add(new PuppetItem(13, LocalStringManager.GetConfig("Puppet_language", "Name_13"), LocalStringManager.GetConfig("Puppet_language", "Desc_13"), EPuppetType.Sect, "NpcFace_murenjixichengnian", 15, 1279, new List<sbyte> { 18 }));
		_dataArray.Add(new PuppetItem(14, LocalStringManager.GetConfig("Puppet_language", "Name_14"), LocalStringManager.GetConfig("Puppet_language", "Desc_14"), EPuppetType.Sect, "NpcFace_murendamo", 1, 1185, new List<sbyte> { 4, 10, 16 }));
		_dataArray.Add(new PuppetItem(15, LocalStringManager.GetConfig("Puppet_language", "Name_15"), LocalStringManager.GetConfig("Puppet_language", "Desc_15"), EPuppetType.Sect, "NpcFace_murenwudangshanren", 4, 1208, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(16, LocalStringManager.GetConfig("Puppet_language", "Name_16"), LocalStringManager.GetConfig("Puppet_language", "Desc_16"), EPuppetType.Sect, "NpcFace_murenchangshengxuannv", 8, 1224, new List<sbyte> { 4, 10, 16 }));
		_dataArray.Add(new PuppetItem(17, LocalStringManager.GetConfig("Puppet_language", "Name_17"), LocalStringManager.GetConfig("Puppet_language", "Desc_17"), EPuppetType.Sect, "NpcFace_murenleikun", 6, 1216, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(18, LocalStringManager.GetConfig("Puppet_language", "Name_18"), LocalStringManager.GetConfig("Puppet_language", "Desc_18"), EPuppetType.Sect, "NpcFace_murenranxindu", 12, 1242, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(19, LocalStringManager.GetConfig("Puppet_language", "Name_19"), LocalStringManager.GetConfig("Puppet_language", "Desc_19"), EPuppetType.Sect, "NpcFace_murenshenggu", 12, 1247, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(20, LocalStringManager.GetConfig("Puppet_language", "Name_20"), LocalStringManager.GetConfig("Puppet_language", "Desc_20"), EPuppetType.Sect, "NpcFace_murenshihoujiu", 2, 1193, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(21, LocalStringManager.GetConfig("Puppet_language", "Name_21"), LocalStringManager.GetConfig("Puppet_language", "Desc_21"), EPuppetType.Sect, "NpcFace_murenemeibaiyuan", 2, 1188, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(22, LocalStringManager.GetConfig("Puppet_language", "Name_22"), LocalStringManager.GetConfig("Puppet_language", "Desc_22"), EPuppetType.Sect, "NpcFace_murenzhuxian", 7, 1221, new List<sbyte> { 14, 16, 18 }));
		_dataArray.Add(new PuppetItem(23, LocalStringManager.GetConfig("Puppet_language", "Name_23"), LocalStringManager.GetConfig("Puppet_language", "Desc_23"), EPuppetType.Sect, "NpcFace_murenjingangkulouseng", 11, 1237, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(24, LocalStringManager.GetConfig("Puppet_language", "Name_24"), LocalStringManager.GetConfig("Puppet_language", "Desc_24"), EPuppetType.Sect, "NpcFace_murenbaiwuyang", 3, 1198, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(25, LocalStringManager.GetConfig("Puppet_language", "Name_25"), LocalStringManager.GetConfig("Puppet_language", "Desc_25"), EPuppetType.Sect, "NpcFace_murenxuanwuyou", 3, 1203, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(26, LocalStringManager.GetConfig("Puppet_language", "Name_26"), LocalStringManager.GetConfig("Puppet_language", "Desc_26"), EPuppetType.Sect, null, 3, -1, new List<sbyte> { 18 }));
		_dataArray.Add(new PuppetItem(27, LocalStringManager.GetConfig("Puppet_language", "Name_27"), LocalStringManager.GetConfig("Puppet_language", "Desc_27"), EPuppetType.Sect, "NpcFace_murendiqishiqi", 14, 1267, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(28, LocalStringManager.GetConfig("Puppet_language", "Name_28"), LocalStringManager.GetConfig("Puppet_language", "Desc_28"), EPuppetType.Sect, "NpcFace_murenyanshi", 9, 1227, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(29, LocalStringManager.GetConfig("Puppet_language", "Name_29"), LocalStringManager.GetConfig("Puppet_language", "Desc_29"), EPuppetType.Sect, "NpcFace_murenliaowuming", 10, 1232, new List<sbyte> { 8, 10, 12, 14, 16 }));
		_dataArray.Add(new PuppetItem(30, LocalStringManager.GetConfig("Puppet_language", "Name_30"), LocalStringManager.GetConfig("Puppet_language", "Desc_30"), EPuppetType.Sect, "NpcFace_yuanshantianmomuren", 5, 1213, new List<sbyte> { 16 }));
		_dataArray.Add(new PuppetItem(31, LocalStringManager.GetConfig("Puppet_language", "Name_31"), LocalStringManager.GetConfig("Puppet_language", "Desc_31"), EPuppetType.Sect, "NpcFace_yuanshandimomuren", 5, 1214, new List<sbyte> { 16 }));
		_dataArray.Add(new PuppetItem(32, LocalStringManager.GetConfig("Puppet_language", "Name_32"), LocalStringManager.GetConfig("Puppet_language", "Desc_32"), EPuppetType.Sect, "NpcFace_yuanshanrenmomuren", 5, 1215, new List<sbyte> { 16 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PuppetItem>(33);
		CreateItems0();
	}
}
