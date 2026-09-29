using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BodyPart : ConfigData<BodyPartItem, sbyte>
{
	public static BodyPart Instance = new BodyPart();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "AcupointDesc", "TemplateId", "AcupointParam", "MouseTipIcon", "OuterInjuryIcon", "InnerInjuryIcon" };

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
		_dataArray.Add(new BodyPartItem(0, LocalStringManager.GetConfig("BodyPart_language", "Name_0"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_0"), new int[3] { 20, 40, 60 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_1", "sp_combat_icon_waishang_0", "sp_combat_icon_neishang_0"));
		_dataArray.Add(new BodyPartItem(1, LocalStringManager.GetConfig("BodyPart_language", "Name_1"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_1"), new int[3] { 20, 40, 60 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_2", "sp_combat_icon_waishang_1", "sp_combat_icon_neishang_1"));
		_dataArray.Add(new BodyPartItem(2, LocalStringManager.GetConfig("BodyPart_language", "Name_2"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_2"), new int[3] { 4, 6, 8 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_0", "sp_combat_icon_waishang_2", "sp_combat_icon_neishang_2"));
		_dataArray.Add(new BodyPartItem(3, LocalStringManager.GetConfig("BodyPart_language", "Name_3"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_3"), new int[3] { 50, 100, 150 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_3", "sp_combat_icon_waishang_3", "sp_combat_icon_neishang_3"));
		_dataArray.Add(new BodyPartItem(4, LocalStringManager.GetConfig("BodyPart_language", "Name_4"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_4"), new int[3] { 50, 100, 150 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_4", "sp_combat_icon_waishang_4", "sp_combat_icon_neishang_4"));
		_dataArray.Add(new BodyPartItem(5, LocalStringManager.GetConfig("BodyPart_language", "Name_5"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_5"), new int[3] { 50, 100, 150 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_5", "sp_combat_icon_waishang_5", "sp_combat_icon_neishang_5"));
		_dataArray.Add(new BodyPartItem(6, LocalStringManager.GetConfig("BodyPart_language", "Name_6"), LocalStringManager.GetConfig("BodyPart_language", "AcupointDesc_6"), new int[3] { 50, 100, 150 }, new int[3] { 0, 50, 75 }, "ui9_icon_bodyparts_small_0_6", "sp_combat_icon_waishang_6", "sp_combat_icon_neishang_6"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BodyPartItem>(7);
		CreateItems0();
	}
}
