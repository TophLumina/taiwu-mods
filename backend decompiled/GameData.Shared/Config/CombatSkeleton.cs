using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkeleton : ConfigData<CombatSkeletonItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatSkeleton Instance = new CombatSkeleton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "SkinName", "SpecialRightWeapon" };

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
		_dataArray.Add(new CombatSkeletonItem(0, "kid", 1f, 0.85f, 1.2f, isNotStandard: false, new string[7] { "hairup", "bangs", "hairup_double_l", "hairup_double_r", "skirt/skirt", "equip_shank_r", "equip_shank_l" }, new string[7] { "hair/huanxin_flag", "bangs/huanxin_bangs", "hair/huanxin_hair2", "hair/huanxin_hair", "skirt/huanxin_skirt", "equip_shank_r/equip_shank_r_315", "equip_shank_l/equip_shank_l_315" }, "W_huanxin"));
		_dataArray.Add(new CombatSkeletonItem(1, "ape", 1f, 1f, 1f, isNotStandard: false, new string[8] { "bangs", "hair", "collar/collar", "peplum/peplum", "skirt/skirt", "skirt_back/skirt_back", "sleeve_l/sleeve_l", "sleeve_r/sleeve_r" }, new string[8] { "bangs/bangs_00", "hair/hair_37", "collar/collar_331", "peplum/peplum_331", "skirt/skirt_331", "skirt_back/skirt_back_331", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r_331" }, null));
		_dataArray.Add(new CombatSkeletonItem(2, "white", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(3, "black", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(4, "blue", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(5, "red", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(6, "yellow", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(7, "white", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(8, "black", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(9, "blue", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(10, "red", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(11, "yellow", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(12, "fuxi", 0.7f, 0.7f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(13, "jiao", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(14, "TS_doll", 1f, 1f, 1f, isNotStandard: false, new string[2] { "skirt/skirt", "skirt_back/skirt_back" }, new string[2] { "doll/TS_skirt", "doll/TS_skirt_back" }, null));
		_dataArray.Add(new CombatSkeletonItem(15, "skeleton", 1f, 1f, 1f, isNotStandard: false, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(16, "qingjiao", 0.8f, 0.8f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(17, "yifu", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(18, "xuxiangong", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
		_dataArray.Add(new CombatSkeletonItem(19, "linghou", 1f, 1f, 1f, isNotStandard: true, new string[0], new string[0], null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatSkeletonItem>(20);
		CreateItems0();
	}
}
