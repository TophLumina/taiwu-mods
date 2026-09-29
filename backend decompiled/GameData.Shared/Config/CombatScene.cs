using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatScene : ConfigData<CombatSceneItem, short>
{
	public static class DefKey
	{
		public const short EasterEgg = 42;
	}

	public static class DefValue
	{
		public static CombatSceneItem EasterEgg => Instance[(short)42];
	}

	public static CombatScene Instance = new CombatScene();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "PrefabPath" };

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
		_dataArray.Add(new CombatSceneItem(0, new List<string> { "combat_scene_101/combat_scene_101", "combat_scene_101/combat_scene_101_1", "combat_scene_101/combat_scene_101_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_0"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(1, new List<string> { "combat_scene_102/combat_scene_102", "combat_scene_102/combat_scene_102_1", "combat_scene_102/combat_scene_102_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_1"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(2, new List<string> { "combat_scene_103/combat_scene_103", "combat_scene_103/combat_scene_103_1", "combat_scene_103/combat_scene_103_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_2"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(3, new List<string> { "combat_scene_104/combat_scene_104", "combat_scene_104/combat_scene_104_1", "combat_scene_104/combat_scene_104_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_3"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(4, new List<string> { "combat_scene_105/combat_scene_105", "combat_scene_105/combat_scene_105_1", "combat_scene_105/combat_scene_105_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_4"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(5, new List<string> { "combat_scene_106/combat_scene_106", "combat_scene_106/combat_scene_106_1", "combat_scene_106/combat_scene_106_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_5"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(6, new List<string> { "combat_scene_107/combat_scene_107", "combat_scene_107/combat_scene_107_1", "combat_scene_107/combat_scene_107_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_6"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(7, new List<string> { "combat_scene_108/combat_scene_108", "combat_scene_108/combat_scene_108_1", "combat_scene_108/combat_scene_108_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_7"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(8, new List<string> { "combat_scene_109/combat_scene_109", "combat_scene_109/combat_scene_109_1", "combat_scene_109/combat_scene_109_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_8"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(9, new List<string> { "combat_scene_110/combat_scene_110", "combat_scene_110/combat_scene_110_1", "combat_scene_110/combat_scene_110_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_9"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(10, new List<string> { "combat_scene_112/combat_scene_112", "combat_scene_112/combat_scene_112_1", "combat_scene_112/combat_scene_112_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_10"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(11, new List<string> { "combat_scene_113/combat_scene_113", "combat_scene_113/combat_scene_113_1", "combat_scene_113/combat_scene_113_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_11"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(12, new List<string> { "combat_scene_114/combat_scene_114", "combat_scene_114/combat_scene_114_1", "combat_scene_114/combat_scene_114_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_12"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(13, new List<string> { "combat_scene_115/combat_scene_115", "combat_scene_115/combat_scene_115_1", "combat_scene_115/combat_scene_115_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_13"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(14, new List<string> { "combat_scene_117/combat_scene_117", "combat_scene_117/combat_scene_117_1", "combat_scene_117/combat_scene_117_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_14"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(15, new List<string> { "combat_scene_118/combat_scene_118", "combat_scene_118/combat_scene_118_1", "combat_scene_118/combat_scene_118_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_15"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(16, new List<string> { "combat_scene_119/combat_scene_119", "combat_scene_119/combat_scene_119_1", "combat_scene_119/combat_scene_119_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_16"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(17, new List<string> { "combat_scene_120/combat_scene_120", "combat_scene_120/combat_scene_120_1", "combat_scene_120/combat_scene_120_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_17"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(18, new List<string> { "combat_scene_121/combat_scene_121", "combat_scene_121/combat_scene_121_1", "combat_scene_121/combat_scene_121_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_18"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(19, new List<string> { "combat_scene_122/combat_scene_122", "combat_scene_122/combat_scene_122_1", "combat_scene_122/combat_scene_122_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_19"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(20, new List<string> { "combat_scene_123/combat_scene_123", "combat_scene_123/combat_scene_123_1", "combat_scene_123/combat_scene_123_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_20"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(21, new List<string> { "combat_scene_124/combat_scene_124", "combat_scene_124/combat_scene_124_1", "combat_scene_124/combat_scene_124_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_21"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(22, new List<string> { "combat_scene_125/combat_scene_125", "combat_scene_125/combat_scene_125_1", "combat_scene_125/combat_scene_125_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_22"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(23, new List<string> { "combat_scene_111/combat_scene_111_0" }, LocalStringManager.GetConfig("CombatScene_language", "Name_23"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(24, new List<string> { "combat_scene_111/combat_scene_111_1" }, LocalStringManager.GetConfig("CombatScene_language", "Name_24"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(25, new List<string> { "combat_scene_111/combat_scene_111_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_25"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(26, new List<string> { "combat_scene_111/combat_scene_111_3" }, LocalStringManager.GetConfig("CombatScene_language", "Name_26"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(27, new List<string> { "combat_scene_111/combat_scene_111_4" }, LocalStringManager.GetConfig("CombatScene_language", "Name_27"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(28, new List<string> { "combat_scene_111/combat_scene_111_5" }, LocalStringManager.GetConfig("CombatScene_language", "Name_28"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(29, new List<string> { "combat_scene_111/combat_scene_111_6" }, LocalStringManager.GetConfig("CombatScene_language", "Name_29"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(30, new List<string> { "combat_scene_111/combat_scene_111_7" }, LocalStringManager.GetConfig("CombatScene_language", "Name_30"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(31, new List<string> { "combat_scene_111/combat_scene_111_8" }, LocalStringManager.GetConfig("CombatScene_language", "Name_31"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(32, new List<string> { "combat_scene_126/combat_scene_126" }, LocalStringManager.GetConfig("CombatScene_language", "Name_32"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(33, new List<string> { "combat_scene_127/combat_scene_127" }, LocalStringManager.GetConfig("CombatScene_language", "Name_33"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(34, new List<string> { "combat_scene_128/combat_scene_128" }, LocalStringManager.GetConfig("CombatScene_language", "Name_34"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(35, new List<string> { "combat_scene_129/combat_scene_129" }, LocalStringManager.GetConfig("CombatScene_language", "Name_35"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(36, new List<string> { "combat_scene_130/combat_scene_130", "combat_scene_130/combat_scene_130_1", "combat_scene_130/combat_scene_130_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_36"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(37, new List<string> { "combat_scene_131/combat_scene_131", "combat_scene_131/combat_scene_131_1", "combat_scene_131/combat_scene_131_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_37"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(38, new List<string> { "combat_scene_132/combat_scene_132", "combat_scene_132/combat_scene_132_1", "combat_scene_132/combat_scene_132_2" }, LocalStringManager.GetConfig("CombatScene_language", "Name_38"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(39, new List<string> { "combat_scene_133/combat_scene_133" }, LocalStringManager.GetConfig("CombatScene_language", "Name_39"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(40, new List<string> { "combat_scene_143/combat_scene_143" }, LocalStringManager.GetConfig("CombatScene_language", "Name_40"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(41, new List<string> { "combat_scene_145/combat_scene_145" }, LocalStringManager.GetConfig("CombatScene_language", "Name_41"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(42, new List<string> { "combat_scene_146/combat_scene_146" }, LocalStringManager.GetConfig("CombatScene_language", "Name_42"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(43, new List<string> { "combat_scene_147/combat_scene_147" }, LocalStringManager.GetConfig("CombatScene_language", "Name_43"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(44, new List<string> { "combat_scene_148/combat_scene_148" }, LocalStringManager.GetConfig("CombatScene_language", "Name_44"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(45, new List<string> { "combat_scene_155/combat_scene_155_lei" }, LocalStringManager.GetConfig("CombatScene_language", "Name_45"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(46, new List<string> { "combat_scene_155/combat_scene_155_shui" }, LocalStringManager.GetConfig("CombatScene_language", "Name_46"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(47, new List<string> { "combat_scene_155/combat_scene_155_feng" }, LocalStringManager.GetConfig("CombatScene_language", "Name_47"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(48, new List<string> { "combat_scene_155/combat_scene_155_huo" }, LocalStringManager.GetConfig("CombatScene_language", "Name_48"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(49, new List<string> { "combat_scene_155/combat_scene_155" }, LocalStringManager.GetConfig("CombatScene_language", "Name_49"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(50, new List<string> { "combat_scene_156/combat_scene_156" }, LocalStringManager.GetConfig("CombatScene_language", "Name_50"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(51, new List<string> { "combat_scene_151/combat_scene_151" }, LocalStringManager.GetConfig("CombatScene_language", "Name_51"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(52, new List<string> { "combat_scene_149/combat_scene_149" }, LocalStringManager.GetConfig("CombatScene_language", "Name_52"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(53, new List<string> { "combat_scene_152/combat_scene_152" }, LocalStringManager.GetConfig("CombatScene_language", "Name_53"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(54, new List<string> { "combat_scene_150/combat_scene_150" }, LocalStringManager.GetConfig("CombatScene_language", "Name_54"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(55, new List<string> { "combat_scene_157/combat_scene_157" }, LocalStringManager.GetConfig("CombatScene_language", "Name_55"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(56, new List<string> { "combat_scene_160/combat_scene_160", "combat_scene_160/combat_scene_160_1" }, LocalStringManager.GetConfig("CombatScene_language", "Name_56"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(57, new List<string> { "combat_scene_200/combat_scene_200" }, LocalStringManager.GetConfig("CombatScene_language", "Name_57"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(58, new List<string> { "combat_scene_161/combat_scene_161" }, LocalStringManager.GetConfig("CombatScene_language", "Name_58"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(59, new List<string> { "combat_scene_162/combat_scene_162" }, LocalStringManager.GetConfig("CombatScene_language", "Name_59"), hasWinterResource: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CombatSceneItem(60, new List<string> { "combat_scene_163/combat_scene_163" }, LocalStringManager.GetConfig("CombatScene_language", "Name_60"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(61, new List<string> { "combat_scene_164/combat_scene_164" }, LocalStringManager.GetConfig("CombatScene_language", "Name_61"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(62, new List<string> { "combat_scene_165/combat_scene_165" }, LocalStringManager.GetConfig("CombatScene_language", "Name_62"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(63, new List<string> { "combat_scene_166/combat_scene_166" }, LocalStringManager.GetConfig("CombatScene_language", "Name_63"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(64, new List<string> { "combat_scene_167/combat_scene_167" }, LocalStringManager.GetConfig("CombatScene_language", "Name_64"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(65, new List<string> { "combat_scene_168/combat_scene_168" }, LocalStringManager.GetConfig("CombatScene_language", "Name_65"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(66, new List<string> { "combat_scene_169/combat_scene_169" }, LocalStringManager.GetConfig("CombatScene_language", "Name_66"), hasWinterResource: false));
		_dataArray.Add(new CombatSceneItem(67, new List<string> { "combat_scene_170/combat_scene_170" }, LocalStringManager.GetConfig("CombatScene_language", "Name_67"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(68, new List<string> { "combat_scene_171/combat_scene_171" }, LocalStringManager.GetConfig("CombatScene_language", "Name_68"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(69, new List<string> { "combat_scene_172/combat_scene_172" }, LocalStringManager.GetConfig("CombatScene_language", "Name_69"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(70, new List<string> { "combat_scene_173/combat_scene_173" }, LocalStringManager.GetConfig("CombatScene_language", "Name_70"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(71, new List<string> { "combat_scene_174/combat_scene_174" }, LocalStringManager.GetConfig("CombatScene_language", "Name_71"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(72, new List<string> { "combat_scene_175/combat_scene_175" }, LocalStringManager.GetConfig("CombatScene_language", "Name_72"), hasWinterResource: true));
		_dataArray.Add(new CombatSceneItem(73, new List<string> { "combat_scene_176/combat_scene_176" }, LocalStringManager.GetConfig("CombatScene_language", "Name_73"), hasWinterResource: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatSceneItem>(74);
		CreateItems0();
		CreateItems1();
	}
}
