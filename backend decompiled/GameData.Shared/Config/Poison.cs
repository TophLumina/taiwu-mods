using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Poison : ConfigData<PoisonItem, sbyte>
{
	public static Poison Instance = new Poison();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ShortName", "Desc", "ProduceType", "TemplateId", "FontColor", "Icon", "TipsIcon" };

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
		_dataArray.Add(new PoisonItem(0, LocalStringManager.GetConfig("Poison_language", "Name_0"), LocalStringManager.GetConfig("Poison_language", "ShortName_0"), LocalStringManager.GetConfig("Poison_language", "Desc_0"), 3, 5, new byte[3] { 30, 15, 0 }, "hotpoison", "sp_icon_poison_0", "mousetip_duxing_0", 4, -1, -1));
		_dataArray.Add(new PoisonItem(1, LocalStringManager.GetConfig("Poison_language", "Name_1"), LocalStringManager.GetConfig("Poison_language", "ShortName_1"), LocalStringManager.GetConfig("Poison_language", "Desc_1"), 2, 5, new byte[3] { 30, 15, 0 }, "gloomypoison", "sp_icon_poison_1", "mousetip_duxing_1", 40, -1, -1));
		_dataArray.Add(new PoisonItem(2, LocalStringManager.GetConfig("Poison_language", "Name_2"), LocalStringManager.GetConfig("Poison_language", "ShortName_2"), LocalStringManager.GetConfig("Poison_language", "Desc_2"), 5, 10, new byte[3] { 20, 10, 0 }, "coldpoison", "sp_icon_poison_2", "mousetip_duxing_2", 75, -1, -1));
		_dataArray.Add(new PoisonItem(3, LocalStringManager.GetConfig("Poison_language", "Name_3"), LocalStringManager.GetConfig("Poison_language", "ShortName_3"), LocalStringManager.GetConfig("Poison_language", "Desc_3"), 4, 10, new byte[3] { 20, 10, 0 }, "redpoison", "sp_icon_poison_3", "mousetip_duxing_3", 75, -1, -1));
		_dataArray.Add(new PoisonItem(4, LocalStringManager.GetConfig("Poison_language", "Name_4"), LocalStringManager.GetConfig("Poison_language", "ShortName_4"), LocalStringManager.GetConfig("Poison_language", "Desc_4"), 0, 5, new byte[3] { 10, 5, 0 }, "rottenpoison", "sp_icon_poison_4", "mousetip_duxing_4", 600, 15, -1));
		_dataArray.Add(new PoisonItem(5, LocalStringManager.GetConfig("Poison_language", "Name_5"), LocalStringManager.GetConfig("Poison_language", "ShortName_5"), LocalStringManager.GetConfig("Poison_language", "Desc_5"), 1, 5, new byte[3] { 10, 5, 0 }, "illusorypoison", "sp_icon_poison_5", "mousetip_duxing_5", 600, -1, 15));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PoisonItem>(6);
		CreateItems0();
	}
}
