using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanTerrain : ConfigData<TeaHorseCaravanTerrainItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 平原
		/// </summary>
		public const short Plain = 0;

		/// <summary>
		/// 山地
		/// </summary>
		public const short Mountain = 1;

		/// <summary>
		/// 林地
		/// </summary>
		public const short Woods = 2;

		/// <summary>
		/// 荒漠
		/// </summary>
		public const short Desert = 3;

		/// <summary>
		/// 水边
		/// </summary>
		public const short Marsh = 4;

		/// <summary>
		/// 村镇
		/// </summary>
		public const short Town = 5;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 平原
		/// </summary>
		public static TeaHorseCaravanTerrainItem Plain => Instance[(short)0];

		/// <summary>
		/// 山地
		/// </summary>
		public static TeaHorseCaravanTerrainItem Mountain => Instance[(short)1];

		/// <summary>
		/// 林地
		/// </summary>
		public static TeaHorseCaravanTerrainItem Woods => Instance[(short)2];

		/// <summary>
		/// 荒漠
		/// </summary>
		public static TeaHorseCaravanTerrainItem Desert => Instance[(short)3];

		/// <summary>
		/// 水边
		/// </summary>
		public static TeaHorseCaravanTerrainItem Marsh => Instance[(short)4];

		/// <summary>
		/// 村镇
		/// </summary>
		public static TeaHorseCaravanTerrainItem Town => Instance[(short)5];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TeaHorseCaravanTerrain Instance = new TeaHorseCaravanTerrain();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId" };

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
		_dataArray.Add(new TeaHorseCaravanTerrainItem(0, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_0"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_0"), 10));
		_dataArray.Add(new TeaHorseCaravanTerrainItem(1, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_1"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_1"), 10));
		_dataArray.Add(new TeaHorseCaravanTerrainItem(2, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_2"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_2"), 10));
		_dataArray.Add(new TeaHorseCaravanTerrainItem(3, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_3"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_3"), 7));
		_dataArray.Add(new TeaHorseCaravanTerrainItem(4, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_4"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_4"), 2));
		_dataArray.Add(new TeaHorseCaravanTerrainItem(5, LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Name_5"), LocalStringManager.GetConfig("TeaHorseCaravanTerrain_language", "Desc_5"), 5));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TeaHorseCaravanTerrainItem>(6);
		CreateItems0();
	}
}
