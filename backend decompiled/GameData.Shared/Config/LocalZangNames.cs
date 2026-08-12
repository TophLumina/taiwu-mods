using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LocalZangNames : IConfigData
{
	public static LocalZangNames Instance = new LocalZangNames();

	public short SoloStart = 1;

	public short SoloEnd = 15;

	public short MixStart = 100;

	public short MixEnd = 168;

	public short MaleStart = 300;

	public short MaleEnd = 319;

	public short FemaleStart = 400;

	public short FemaleEnd = 423;

	public ZangNameItem[] ZangNameCore;

	public IReadOnlyDictionary<string, int> RefNameMap
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public int GetItemId(string refName)
	{
		throw new NotImplementedException();
	}

	public int AddExtraItem(string identifier, string refName, object configItem)
	{
		throw new NotImplementedException();
	}

	public void Init()
	{
		ZangNameItem[] array = new ZangNameItem[424];
		array[1] = new ZangNameItem(1, LocalStringManager.GetConfig("Name_language", "Zang_1"));
		array[2] = new ZangNameItem(2, LocalStringManager.GetConfig("Name_language", "Zang_2"));
		array[3] = new ZangNameItem(3, LocalStringManager.GetConfig("Name_language", "Zang_3"));
		array[4] = new ZangNameItem(4, LocalStringManager.GetConfig("Name_language", "Zang_4"));
		array[5] = new ZangNameItem(5, LocalStringManager.GetConfig("Name_language", "Zang_5"));
		array[6] = new ZangNameItem(6, LocalStringManager.GetConfig("Name_language", "Zang_6"));
		array[7] = new ZangNameItem(7, LocalStringManager.GetConfig("Name_language", "Zang_7"));
		array[8] = new ZangNameItem(8, LocalStringManager.GetConfig("Name_language", "Zang_8"));
		array[9] = new ZangNameItem(9, LocalStringManager.GetConfig("Name_language", "Zang_9"));
		array[10] = new ZangNameItem(10, LocalStringManager.GetConfig("Name_language", "Zang_10"));
		array[11] = new ZangNameItem(11, LocalStringManager.GetConfig("Name_language", "Zang_11"));
		array[12] = new ZangNameItem(12, LocalStringManager.GetConfig("Name_language", "Zang_12"));
		array[13] = new ZangNameItem(13, LocalStringManager.GetConfig("Name_language", "Zang_13"));
		array[14] = new ZangNameItem(14, LocalStringManager.GetConfig("Name_language", "Zang_14"));
		array[15] = new ZangNameItem(15, LocalStringManager.GetConfig("Name_language", "Zang_15"));
		array[100] = new ZangNameItem(100, LocalStringManager.GetConfig("Name_language", "Zang_100"));
		array[101] = new ZangNameItem(101, LocalStringManager.GetConfig("Name_language", "Zang_101"));
		array[102] = new ZangNameItem(102, LocalStringManager.GetConfig("Name_language", "Zang_102"));
		array[103] = new ZangNameItem(103, LocalStringManager.GetConfig("Name_language", "Zang_103"));
		array[104] = new ZangNameItem(104, LocalStringManager.GetConfig("Name_language", "Zang_104"));
		array[105] = new ZangNameItem(105, LocalStringManager.GetConfig("Name_language", "Zang_105"));
		array[106] = new ZangNameItem(106, LocalStringManager.GetConfig("Name_language", "Zang_106"));
		array[107] = new ZangNameItem(107, LocalStringManager.GetConfig("Name_language", "Zang_107"));
		array[108] = new ZangNameItem(108, LocalStringManager.GetConfig("Name_language", "Zang_108"));
		array[109] = new ZangNameItem(109, LocalStringManager.GetConfig("Name_language", "Zang_109"));
		array[110] = new ZangNameItem(110, LocalStringManager.GetConfig("Name_language", "Zang_110"));
		array[111] = new ZangNameItem(111, LocalStringManager.GetConfig("Name_language", "Zang_111"));
		array[112] = new ZangNameItem(112, LocalStringManager.GetConfig("Name_language", "Zang_112"));
		array[113] = new ZangNameItem(113, LocalStringManager.GetConfig("Name_language", "Zang_113"));
		array[114] = new ZangNameItem(114, LocalStringManager.GetConfig("Name_language", "Zang_114"));
		array[115] = new ZangNameItem(115, LocalStringManager.GetConfig("Name_language", "Zang_115"));
		array[116] = new ZangNameItem(116, LocalStringManager.GetConfig("Name_language", "Zang_116"));
		array[117] = new ZangNameItem(117, LocalStringManager.GetConfig("Name_language", "Zang_117"));
		array[118] = new ZangNameItem(118, LocalStringManager.GetConfig("Name_language", "Zang_118"));
		array[119] = new ZangNameItem(119, LocalStringManager.GetConfig("Name_language", "Zang_119"));
		array[120] = new ZangNameItem(120, LocalStringManager.GetConfig("Name_language", "Zang_120"));
		array[121] = new ZangNameItem(121, LocalStringManager.GetConfig("Name_language", "Zang_121"));
		array[122] = new ZangNameItem(122, LocalStringManager.GetConfig("Name_language", "Zang_122"));
		array[123] = new ZangNameItem(123, LocalStringManager.GetConfig("Name_language", "Zang_123"));
		array[124] = new ZangNameItem(124, LocalStringManager.GetConfig("Name_language", "Zang_124"));
		array[125] = new ZangNameItem(125, LocalStringManager.GetConfig("Name_language", "Zang_125"));
		array[126] = new ZangNameItem(126, LocalStringManager.GetConfig("Name_language", "Zang_126"));
		array[127] = new ZangNameItem(127, LocalStringManager.GetConfig("Name_language", "Zang_127"));
		array[128] = new ZangNameItem(128, LocalStringManager.GetConfig("Name_language", "Zang_128"));
		array[129] = new ZangNameItem(129, LocalStringManager.GetConfig("Name_language", "Zang_129"));
		array[130] = new ZangNameItem(130, LocalStringManager.GetConfig("Name_language", "Zang_130"));
		array[131] = new ZangNameItem(131, LocalStringManager.GetConfig("Name_language", "Zang_131"));
		array[132] = new ZangNameItem(132, LocalStringManager.GetConfig("Name_language", "Zang_132"));
		array[133] = new ZangNameItem(133, LocalStringManager.GetConfig("Name_language", "Zang_133"));
		array[134] = new ZangNameItem(134, LocalStringManager.GetConfig("Name_language", "Zang_134"));
		array[135] = new ZangNameItem(135, LocalStringManager.GetConfig("Name_language", "Zang_135"));
		array[136] = new ZangNameItem(136, LocalStringManager.GetConfig("Name_language", "Zang_136"));
		array[137] = new ZangNameItem(137, LocalStringManager.GetConfig("Name_language", "Zang_137"));
		array[138] = new ZangNameItem(138, LocalStringManager.GetConfig("Name_language", "Zang_138"));
		array[139] = new ZangNameItem(139, LocalStringManager.GetConfig("Name_language", "Zang_139"));
		array[140] = new ZangNameItem(140, LocalStringManager.GetConfig("Name_language", "Zang_140"));
		array[141] = new ZangNameItem(141, LocalStringManager.GetConfig("Name_language", "Zang_141"));
		array[142] = new ZangNameItem(142, LocalStringManager.GetConfig("Name_language", "Zang_142"));
		array[143] = new ZangNameItem(143, LocalStringManager.GetConfig("Name_language", "Zang_143"));
		array[144] = new ZangNameItem(144, LocalStringManager.GetConfig("Name_language", "Zang_144"));
		array[145] = new ZangNameItem(145, LocalStringManager.GetConfig("Name_language", "Zang_145"));
		array[146] = new ZangNameItem(146, LocalStringManager.GetConfig("Name_language", "Zang_146"));
		array[147] = new ZangNameItem(147, LocalStringManager.GetConfig("Name_language", "Zang_147"));
		array[148] = new ZangNameItem(148, LocalStringManager.GetConfig("Name_language", "Zang_148"));
		array[149] = new ZangNameItem(149, LocalStringManager.GetConfig("Name_language", "Zang_149"));
		array[150] = new ZangNameItem(150, LocalStringManager.GetConfig("Name_language", "Zang_150"));
		array[151] = new ZangNameItem(151, LocalStringManager.GetConfig("Name_language", "Zang_151"));
		array[152] = new ZangNameItem(152, LocalStringManager.GetConfig("Name_language", "Zang_152"));
		array[153] = new ZangNameItem(153, LocalStringManager.GetConfig("Name_language", "Zang_153"));
		array[154] = new ZangNameItem(154, LocalStringManager.GetConfig("Name_language", "Zang_154"));
		array[155] = new ZangNameItem(155, LocalStringManager.GetConfig("Name_language", "Zang_155"));
		array[156] = new ZangNameItem(156, LocalStringManager.GetConfig("Name_language", "Zang_156"));
		array[157] = new ZangNameItem(157, LocalStringManager.GetConfig("Name_language", "Zang_157"));
		array[158] = new ZangNameItem(158, LocalStringManager.GetConfig("Name_language", "Zang_158"));
		array[159] = new ZangNameItem(159, LocalStringManager.GetConfig("Name_language", "Zang_159"));
		array[160] = new ZangNameItem(160, LocalStringManager.GetConfig("Name_language", "Zang_160"));
		array[161] = new ZangNameItem(161, LocalStringManager.GetConfig("Name_language", "Zang_161"));
		array[162] = new ZangNameItem(162, LocalStringManager.GetConfig("Name_language", "Zang_162"));
		array[163] = new ZangNameItem(163, LocalStringManager.GetConfig("Name_language", "Zang_163"));
		array[164] = new ZangNameItem(164, LocalStringManager.GetConfig("Name_language", "Zang_164"));
		array[165] = new ZangNameItem(165, LocalStringManager.GetConfig("Name_language", "Zang_165"));
		array[166] = new ZangNameItem(166, LocalStringManager.GetConfig("Name_language", "Zang_166"));
		array[167] = new ZangNameItem(167, LocalStringManager.GetConfig("Name_language", "Zang_167"));
		array[168] = new ZangNameItem(168, LocalStringManager.GetConfig("Name_language", "Zang_168"));
		array[300] = new ZangNameItem(300, LocalStringManager.GetConfig("Name_language", "Zang_300"));
		array[301] = new ZangNameItem(301, LocalStringManager.GetConfig("Name_language", "Zang_301"));
		array[302] = new ZangNameItem(302, LocalStringManager.GetConfig("Name_language", "Zang_302"));
		array[303] = new ZangNameItem(303, LocalStringManager.GetConfig("Name_language", "Zang_303"));
		array[304] = new ZangNameItem(304, LocalStringManager.GetConfig("Name_language", "Zang_304"));
		array[305] = new ZangNameItem(305, LocalStringManager.GetConfig("Name_language", "Zang_305"));
		array[306] = new ZangNameItem(306, LocalStringManager.GetConfig("Name_language", "Zang_306"));
		array[307] = new ZangNameItem(307, LocalStringManager.GetConfig("Name_language", "Zang_307"));
		array[308] = new ZangNameItem(308, LocalStringManager.GetConfig("Name_language", "Zang_308"));
		array[309] = new ZangNameItem(309, LocalStringManager.GetConfig("Name_language", "Zang_309"));
		array[310] = new ZangNameItem(310, LocalStringManager.GetConfig("Name_language", "Zang_310"));
		array[311] = new ZangNameItem(311, LocalStringManager.GetConfig("Name_language", "Zang_311"));
		array[312] = new ZangNameItem(312, LocalStringManager.GetConfig("Name_language", "Zang_312"));
		array[313] = new ZangNameItem(313, LocalStringManager.GetConfig("Name_language", "Zang_313"));
		array[314] = new ZangNameItem(314, LocalStringManager.GetConfig("Name_language", "Zang_314"));
		array[315] = new ZangNameItem(315, LocalStringManager.GetConfig("Name_language", "Zang_315"));
		array[316] = new ZangNameItem(316, LocalStringManager.GetConfig("Name_language", "Zang_316"));
		array[317] = new ZangNameItem(317, LocalStringManager.GetConfig("Name_language", "Zang_317"));
		array[318] = new ZangNameItem(318, LocalStringManager.GetConfig("Name_language", "Zang_318"));
		array[319] = new ZangNameItem(319, LocalStringManager.GetConfig("Name_language", "Zang_319"));
		array[400] = new ZangNameItem(400, LocalStringManager.GetConfig("Name_language", "Zang_400"));
		array[401] = new ZangNameItem(401, LocalStringManager.GetConfig("Name_language", "Zang_401"));
		array[402] = new ZangNameItem(402, LocalStringManager.GetConfig("Name_language", "Zang_402"));
		array[403] = new ZangNameItem(403, LocalStringManager.GetConfig("Name_language", "Zang_403"));
		array[404] = new ZangNameItem(404, LocalStringManager.GetConfig("Name_language", "Zang_404"));
		array[405] = new ZangNameItem(405, LocalStringManager.GetConfig("Name_language", "Zang_405"));
		array[406] = new ZangNameItem(406, LocalStringManager.GetConfig("Name_language", "Zang_406"));
		array[407] = new ZangNameItem(407, LocalStringManager.GetConfig("Name_language", "Zang_407"));
		array[408] = new ZangNameItem(408, LocalStringManager.GetConfig("Name_language", "Zang_408"));
		array[409] = new ZangNameItem(409, LocalStringManager.GetConfig("Name_language", "Zang_409"));
		array[410] = new ZangNameItem(410, LocalStringManager.GetConfig("Name_language", "Zang_410"));
		array[411] = new ZangNameItem(411, LocalStringManager.GetConfig("Name_language", "Zang_411"));
		array[412] = new ZangNameItem(412, LocalStringManager.GetConfig("Name_language", "Zang_412"));
		array[413] = new ZangNameItem(413, LocalStringManager.GetConfig("Name_language", "Zang_413"));
		array[414] = new ZangNameItem(414, LocalStringManager.GetConfig("Name_language", "Zang_414"));
		array[415] = new ZangNameItem(415, LocalStringManager.GetConfig("Name_language", "Zang_415"));
		array[416] = new ZangNameItem(416, LocalStringManager.GetConfig("Name_language", "Zang_416"));
		array[417] = new ZangNameItem(417, LocalStringManager.GetConfig("Name_language", "Zang_417"));
		array[418] = new ZangNameItem(418, LocalStringManager.GetConfig("Name_language", "Zang_418"));
		array[419] = new ZangNameItem(419, LocalStringManager.GetConfig("Name_language", "Zang_419"));
		array[420] = new ZangNameItem(420, LocalStringManager.GetConfig("Name_language", "Zang_420"));
		array[421] = new ZangNameItem(421, LocalStringManager.GetConfig("Name_language", "Zang_421"));
		array[422] = new ZangNameItem(422, LocalStringManager.GetConfig("Name_language", "Zang_422"));
		array[423] = new ZangNameItem(423, LocalStringManager.GetConfig("Name_language", "Zang_423"));
		ZangNameCore = array;
	}
}
