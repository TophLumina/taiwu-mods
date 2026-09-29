using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapRoute : ConfigData<MapRouteItem, short>
{
	public static MapRoute Instance = new MapRoute();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "InternalName", "FromId", "ToId", "PathLoc", "Path", "ExtraFromId", "ExtraToId" };

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
		_dataArray.Add(new MapRouteItem(0, "1", 94, 100, new float[2] { 4230.5f, 2610.5f }, new float[7][]
		{
			new float[2] { 4082f, 2563f },
			new float[2] { 4119f, 2591f },
			new float[2] { 4160f, 2605f },
			new float[2] { 4274f, 2605f },
			new float[2] { 4311f, 2616f },
			new float[2] { 4374f, 2640f },
			new float[2] { 4392f, 2672f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(1, "2", 97, 98, new float[2] { 4046.5f, 1993.5f }, new float[9][]
		{
			new float[2] { 4018f, 2245f },
			new float[2] { 4048f, 2218f },
			new float[2] { 4075f, 2169f },
			new float[2] { 4086f, 2096f },
			new float[2] { 4085f, 2034f },
			new float[2] { 4065f, 1991f },
			new float[2] { 4037f, 1890f },
			new float[2] { 4040f, 1812f },
			new float[2] { 4053f, 1770f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(2, "3", 25, 94, new float[2] { 3880.5f, 2576f }, new float[6][]
		{
			new float[2] { 3763f, 2630f },
			new float[2] { 3771f, 2580f },
			new float[2] { 3792f, 2540f },
			new float[2] { 3850f, 2510f },
			new float[2] { 3956f, 2495f },
			new float[2] { 4029f, 2504f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(3, "3_1", 94, 97, new float[2] { 4033.5f, 2396f }, new float[6][]
		{
			new float[2] { 4073f, 2503f },
			new float[2] { 4053f, 2479f },
			new float[2] { 4028f, 2442f },
			new float[2] { 3993f, 2375f },
			new float[2] { 3999f, 2336f },
			new float[2] { 4012f, 2306f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(4, "4", 10, 97, new float[2] { 3589.5f, 2364f }, new float[9][]
		{
			new float[2] { 3259f, 2416f },
			new float[2] { 3320f, 2362f },
			new float[2] { 3547f, 2279f },
			new float[2] { 3616f, 2274f },
			new float[2] { 3675f, 2279f },
			new float[2] { 3753f, 2266f },
			new float[2] { 3841f, 2235f },
			new float[2] { 3915f, 2225f },
			new float[2] { 3969f, 2239f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(5, "5", 95, 96, new float[2] { 3431f, 2874f }, new float[7][]
		{
			new float[2] { 3621f, 2921f },
			new float[2] { 3576f, 2898f },
			new float[2] { 3533f, 2872f },
			new float[2] { 3497f, 2833f },
			new float[2] { 3436f, 2822f },
			new float[2] { 3368f, 2822f },
			new float[2] { 3300f, 2823f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(6, "5_1", 10, 96, new float[2] { 3212f, 2647f }, new float[5][]
		{
			new float[2] { 3183f, 2543f },
			new float[2] { 3188f, 2610f },
			new float[2] { 3205f, 2662f },
			new float[2] { 3232f, 2702f },
			new float[2] { 3244f, 2753f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(7, "6", 96, 99, new float[2] { 2803.5f, 2776.5f }, new float[9][]
		{
			new float[2] { 3153f, 2785f },
			new float[2] { 3106f, 2756f },
			new float[2] { 3028f, 2743f },
			new float[2] { 2900f, 2746f },
			new float[2] { 2821f, 2764f },
			new float[2] { 2725f, 2794f },
			new float[2] { 2609f, 2801f },
			new float[2] { 2527f, 2808f },
			new float[2] { 2436f, 2768f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(8, "7", 10, 73, new float[2] { 2794.5f, 2221f }, new float[9][]
		{
			new float[2] { 3184f, 2433f },
			new float[2] { 3163f, 2358f },
			new float[2] { 3110f, 2261f },
			new float[2] { 3071f, 2234f },
			new float[2] { 3028f, 2184f },
			new float[2] { 2899f, 2079f },
			new float[2] { 2785f, 2007f },
			new float[2] { 2634f, 1966f },
			new float[2] { 2474f, 1938f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(9, "8", 36, 99, new float[2] { 1999f, 2493f }, new float[10][]
		{
			new float[2] { 1703f, 2235f },
			new float[2] { 1793f, 2263f },
			new float[2] { 1838f, 2301f },
			new float[2] { 1917f, 2394f },
			new float[2] { 1978f, 2429f },
			new float[2] { 2071f, 2448f },
			new float[2] { 2102f, 2474f },
			new float[2] { 2206f, 2647f },
			new float[2] { 2279f, 2734f },
			new float[2] { 2324f, 2758f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(10, "9", 73, 75, new float[2] { 2124f, 1985.5f }, new float[7][]
		{
			new float[2] { 2327f, 1927f },
			new float[2] { 2276f, 1914f },
			new float[2] { 2231f, 1939f },
			new float[2] { 2197f, 1970f },
			new float[2] { 2086f, 1983f },
			new float[2] { 1955f, 1990f },
			new float[2] { 1902f, 2016f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(11, "10", 73, 76, new float[2] { 2352f, 1809.5f }, new float[5][]
		{
			new float[2] { 2382f, 1888f },
			new float[2] { 2393f, 1834f },
			new float[2] { 2382f, 1779f },
			new float[2] { 2352f, 1728f },
			new float[2] { 2324f, 1709f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(12, "11", 7, 76, new float[2] { 2428f, 1627.5f }, new float[6][]
		{
			new float[2] { 2507f, 1611f },
			new float[2] { 2473f, 1620f },
			new float[2] { 2416f, 1625f },
			new float[2] { 2358f, 1618f },
			new float[2] { 2315f, 1631f },
			new float[2] { 2298f, 1662f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(13, "12", 7, 22, new float[2] { 2700f, 1541f }, new float[4][]
		{
			new float[2] { 2589f, 1585f },
			new float[2] { 2656f, 1569f },
			new float[2] { 2716f, 1538f },
			new float[2] { 2774f, 1509f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(14, "13", 22, 77, new float[2] { 2995.5f, 1579.5f }, new float[6][]
		{
			new float[2] { 2876f, 1501f },
			new float[2] { 2907f, 1536f },
			new float[2] { 2933f, 1588f },
			new float[2] { 2970f, 1629f },
			new float[2] { 3021f, 1648f },
			new float[2] { 3080f, 1663f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(15, "14", 77, 79, new float[2] { 3203.5f, 1366.5f }, new float[12][]
		{
			new float[2] { 3187f, 1634f },
			new float[2] { 3220f, 1592f },
			new float[2] { 3223f, 1531f },
			new float[2] { 3198f, 1468f },
			new float[2] { 3168f, 1430f },
			new float[2] { 3153f, 1383f },
			new float[2] { 3144f, 1354f },
			new float[2] { 3185f, 1264f },
			new float[2] { 3202f, 1246f },
			new float[2] { 3227f, 1183f },
			new float[2] { 3246f, 1137f },
			new float[2] { 3246f, 1118f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(16, "15", 74, 76, new float[2] { 2250f, 1518f }, new float[8][]
		{
			new float[2] { 2210f, 1414f },
			new float[2] { 2201f, 1432f },
			new float[2] { 2202f, 1506f },
			new float[2] { 2210f, 1524f },
			new float[2] { 2247f, 1587f },
			new float[2] { 2273f, 1606f },
			new float[2] { 2292f, 1632f },
			new float[2] { 2293f, 1663f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(17, "16", 74, 138, new float[2] { 2155.5f, 1257f }, new float[4][]
		{
			new float[2] { 2217f, 1299f },
			new float[2] { 2210f, 1248f },
			new float[2] { 2192f, 1212f },
			new float[2] { 2168f, 1178f }
		}, null, new short[2] { 78, 132 }));
		_dataArray.Add(new MapRouteItem(18, "17", 78, 138, new float[2] { 1995f, 1146f }, new float[3][]
		{
			new float[2] { 1966f, 1134f },
			new float[2] { 2011f, 1125f },
			new float[2] { 2069f, 1127f }
		}, null, new short[2] { 74, 132 }));
		_dataArray.Add(new MapRouteItem(19, "18", 132, 138, new float[2] { 2045f, 890.5f }, new float[5][]
		{
			new float[2] { 1974f, 723f },
			new float[2] { 1992f, 829f },
			new float[2] { 2025f, 976f },
			new float[2] { 2049f, 1037f },
			new float[2] { 2084f, 1102f }
		}, null, new short[2] { 74, 78 }));
		_dataArray.Add(new MapRouteItem(20, "19", 132, 139, new float[2] { 1567.5f, 712f }, new float[13][]
		{
			new float[2] { 1932f, 641f },
			new float[2] { 1842f, 655f },
			new float[2] { 1783f, 673f },
			new float[2] { 1737f, 700f },
			new float[2] { 1682f, 731f },
			new float[2] { 1642f, 749f },
			new float[2] { 1606f, 750f },
			new float[2] { 1535f, 743f },
			new float[2] { 1454f, 717f },
			new float[2] { 1362f, 733f },
			new float[2] { 1268f, 721f },
			new float[2] { 1199f, 734f },
			new float[2] { 1188f, 764f }
		}, null, new short[3] { 1, 37, 117 }));
		_dataArray.Add(new MapRouteItem(21, "20", 1, 139, new float[2] { 1225f, 903f }, new float[3][]
		{
			new float[2] { 1293f, 1000f },
			new float[2] { 1303f, 949f },
			new float[2] { 1271f, 882f }
		}, null, new short[3] { 37, 117, 132 }));
		_dataArray.Add(new MapRouteItem(22, "21", 37, 139, new float[2] { 1034.5f, 827f }, new float[5][]
		{
			new float[2] { 1036f, 849f },
			new float[2] { 1049f, 832f },
			new float[2] { 1075f, 795f },
			new float[2] { 1112f, 773f },
			new float[2] { 1146f, 774f }
		}, null, new short[3] { 1, 117, 132 }));
		_dataArray.Add(new MapRouteItem(23, "22", 16, 37, new float[2] { 770f, 818f }, new float[7][]
		{
			new float[2] { 666f, 735f },
			new float[2] { 740f, 734f },
			new float[2] { 790f, 746f },
			new float[2] { 810f, 773f },
			new float[2] { 817f, 824f },
			new float[2] { 836f, 871f },
			new float[2] { 873f, 893f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(24, "23", 16, 31, new float[2] { 448.5f, 821.5f }, new float[6][]
		{
			new float[2] { 541f, 758f },
			new float[2] { 468f, 766f },
			new float[2] { 406f, 783f },
			new float[2] { 357f, 799f },
			new float[2] { 317f, 826f },
			new float[2] { 291f, 858f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(25, "24", 31, 35, new float[2] { 360.5f, 1047.5f }, new float[6][]
		{
			new float[2] { 272f, 946f },
			new float[2] { 281f, 991f },
			new float[2] { 306f, 1045f },
			new float[2] { 351f, 1116f },
			new float[2] { 377f, 1132f },
			new float[2] { 417f, 1147f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(26, "25", 35, 140, new float[2] { 502f, 1257.5f }, new float[1][] { new float[2] { 505f, 1250f } }, null, new short[2] { 5, 34 }));
		_dataArray.Add(new MapRouteItem(27, "26", 34, 140, new float[2] { 661.5f, 1303f }, new float[3][]
		{
			new float[2] { 665f, 1312f },
			new float[2] { 638f, 1330f },
			new float[2] { 598f, 1340f }
		}, null, new short[2] { 5, 35 }));
		_dataArray.Add(new MapRouteItem(28, "27", 1, 34, new float[2] { 1026f, 1154f }, new float[6][]
		{
			new float[2] { 1245f, 1045f },
			new float[2] { 1176f, 1060f },
			new float[2] { 1090f, 1114f },
			new float[2] { 988f, 1197f },
			new float[2] { 916f, 1226f },
			new float[2] { 810f, 1260f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(29, "28", 1, 32, new float[2] { 1368.5f, 1237f }, new float[6][]
		{
			new float[2] { 1295f, 1090f },
			new float[2] { 1315f, 1133f },
			new float[2] { 1371f, 1184f },
			new float[2] { 1451f, 1298f },
			new float[2] { 1464f, 1360f },
			new float[2] { 1453f, 1404f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(30, "29", 5, 140, new float[2] { 597.5f, 1600f }, new float[8][]
		{
			new float[2] { 634f, 1802f },
			new float[2] { 648f, 1762f },
			new float[2] { 638f, 1729f },
			new float[2] { 652f, 1700f },
			new float[2] { 614f, 1636f },
			new float[2] { 562f, 1581f },
			new float[2] { 541f, 1534f },
			new float[2] { 553f, 1382f }
		}, null, new short[2] { 34, 35 }));
		_dataArray.Add(new MapRouteItem(31, "30", 32, 36, new float[2] { 1540f, 1822f }, new float[16][]
		{
			new float[2] { 1448f, 1506f },
			new float[2] { 1453f, 1550f },
			new float[2] { 1476f, 1586f },
			new float[2] { 1487f, 1634f },
			new float[2] { 1507f, 1690f },
			new float[2] { 1511f, 1736f },
			new float[2] { 1485f, 1775f },
			new float[2] { 1457f, 1810f },
			new float[2] { 1454f, 1834f },
			new float[2] { 1471f, 1858f },
			new float[2] { 1483f, 1889f },
			new float[2] { 1481f, 1928f },
			new float[2] { 1485f, 1980f },
			new float[2] { 1511f, 2055f },
			new float[2] { 1546f, 2119f },
			new float[2] { 1590f, 2177f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(32, "31", 36, 75, new float[2] { 1756.5f, 2129.5f }, new float[5][]
		{
			new float[2] { 1634f, 2220f },
			new float[2] { 1657f, 2191f },
			new float[2] { 1693f, 2156f },
			new float[2] { 1746f, 2136f },
			new float[2] { 1802f, 2110f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(33, "32", 33, 36, new float[2] { 1485f, 2210.5f }, new float[2][]
		{
			new float[2] { 1457f, 2195f },
			new float[2] { 1539f, 2207f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(34, "32_1", 33, 61, new float[2] { 1183f, 2180.5f }, new float[3][]
		{
			new float[2] { 1259f, 2186f },
			new float[2] { 1158f, 2186f },
			new float[2] { 1084f, 2178f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(35, "33", 61, 62, new float[2] { 986.5f, 2015.5f }, new float[9][]
		{
			new float[2] { 1027f, 2107f },
			new float[2] { 1022f, 2082f },
			new float[2] { 1010f, 2058f },
			new float[2] { 983f, 2025f },
			new float[2] { 960f, 2002f },
			new float[2] { 944f, 1981f },
			new float[2] { 946f, 1954f },
			new float[2] { 960f, 1922f },
			new float[2] { 989f, 1893f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(36, "34", 5, 62, new float[2] { 827.5f, 1866.5f }, new float[8][]
		{
			new float[2] { 649f, 1860f },
			new float[2] { 699f, 1857f },
			new float[2] { 737f, 1870f },
			new float[2] { 860f, 1873f },
			new float[2] { 907f, 1872f },
			new float[2] { 945f, 1857f },
			new float[2] { 975f, 1856f },
			new float[2] { 1007f, 1861f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(37, "35", 60, 61, new float[2] { 907f, 2188f }, new float[7][]
		{
			new float[2] { 794f, 2205f },
			new float[2] { 818f, 2172f },
			new float[2] { 845f, 2161f },
			new float[2] { 882f, 2140f },
			new float[2] { 934f, 2137f },
			new float[2] { 986f, 2144f },
			new float[2] { 1009f, 2155f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(38, "36", 59, 60, new float[2] { 806f, 2355.5f }, new float[5][]
		{
			new float[2] { 814f, 2434f },
			new float[2] { 799f, 2413f },
			new float[2] { 785f, 2369f },
			new float[2] { 773f, 2321f },
			new float[2] { 774f, 2279f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(39, "38", 5, 20, new float[2] { 487.5f, 1942f }, new float[6][]
		{
			new float[2] { 609f, 1861f },
			new float[2] { 548f, 1861f },
			new float[2] { 476f, 1881f },
			new float[2] { 398f, 1905f },
			new float[2] { 347f, 1954f },
			new float[2] { 327f, 1995f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(40, "39", 20, 64, new float[2] { 327.5f, 1830f }, new float[9][]
		{
			new float[2] { 321f, 1993f },
			new float[2] { 324f, 1938f },
			new float[2] { 325f, 1895f },
			new float[2] { 339f, 1875f },
			new float[2] { 344f, 1851f },
			new float[2] { 362f, 1827f },
			new float[2] { 353f, 1758f },
			new float[2] { 333f, 1710f },
			new float[2] { 321f, 1680f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(41, "40", 20, 65, new float[2] { 103.5f, 2082.5f }, new float[9][]
		{
			new float[2] { 296f, 2040f },
			new float[2] { 225f, 2023f },
			new float[2] { 117f, 2016f },
			new float[2] { 53f, 2024f },
			new float[2] { -23f, 2037f },
			new float[2] { -60f, 2057f },
			new float[2] { -101f, 2083f },
			new float[2] { -118f, 2117f },
			new float[2] { -118f, 2142f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(42, "41", 63, 64, new float[2] { 139.5f, 1601.5f }, new float[5][]
		{
			new float[2] { 0f, 1579f },
			new float[2] { 35f, 1586f },
			new float[2] { 109f, 1588f },
			new float[2] { 205f, 1605f },
			new float[2] { 273f, 1621f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(43, "42", 63, 107, new float[2] { -480f, 1421f }, new float[14][]
		{
			new float[2] { -83f, 1564f },
			new float[2] { -131f, 1554f },
			new float[2] { -185f, 1521f },
			new float[2] { -217f, 1487f },
			new float[2] { -234f, 1462f },
			new float[2] { -225f, 1442f },
			new float[2] { -226f, 1415f },
			new float[2] { -231f, 1398f },
			new float[2] { -238f, 1384f },
			new float[2] { -261f, 1351f },
			new float[2] { -317f, 1323f },
			new float[2] { -342f, 1298f },
			new float[2] { -443f, 1288f },
			new float[2] { -662f, 1283f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(44, "43", 52, 104, new float[2] { -804.5f, 944f }, new float[7][]
		{
			new float[2] { -621f, 924f },
			new float[2] { -678f, 923f },
			new float[2] { -736f, 928f },
			new float[2] { -785f, 941f },
			new float[2] { -828f, 963f },
			new float[2] { -872f, 972f },
			new float[2] { -925f, 972f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(45, "43_1", 104, 107, new float[2] { -988.5f, 1135f }, new float[6][]
		{
			new float[2] { -1013f, 986f },
			new float[2] { -965f, 998f },
			new float[2] { -934f, 1026f },
			new float[2] { -920f, 1058f },
			new float[2] { -925f, 1098f },
			new float[2] { -937f, 1177f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(46, "44", 11, 107, new float[2] { -1090f, 1316.5f }, new float[5][]
		{
			new float[2] { -1205f, 1310f },
			new float[2] { -1163f, 1282f },
			new float[2] { -1111f, 1270f },
			new float[2] { -1046f, 1271f },
			new float[2] { -989f, 1281f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(47, "45", 11, 105, new float[2] { -1233f, 1527.5f }, new float[9][]
		{
			new float[2] { -1264f, 1413f },
			new float[2] { -1286f, 1462f },
			new float[2] { -1300f, 1485f },
			new float[2] { -1321f, 1500f },
			new float[2] { -1324f, 1519f },
			new float[2] { -1324f, 1563f },
			new float[2] { -1291f, 1594f },
			new float[2] { -1261f, 1652f },
			new float[2] { -1239f, 1669f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(48, "46", 105, 147, new float[2] { -1406.5f, 1753f }, new float[9][]
		{
			new float[2] { -1172f, 1721f },
			new float[2] { -1228f, 1726f },
			new float[2] { -1277f, 1714f },
			new float[2] { -1324f, 1720f },
			new float[2] { -1375f, 1728f },
			new float[2] { -1444f, 1714f },
			new float[2] { -1512f, 1714f },
			new float[2] { -1582f, 1724f },
			new float[2] { -1641f, 1746f }
		}, null, new short[1] { 103 }));
		_dataArray.Add(new MapRouteItem(49, "47", 103, 147, new float[2] { -1730f, 1828.5f }, new float[2][]
		{
			new float[2] { -1746f, 1832f },
			new float[2] { -1700f, 1816f }
		}, null, new short[1] { 105 }));
		_dataArray.Add(new MapRouteItem(50, "48", 101, 103, new float[2] { -1762.5f, 2141.5f }, new float[12][]
		{
			new float[2] { -1746f, 2365f },
			new float[2] { -1765f, 2350f },
			new float[2] { -1774f, 2303f },
			new float[2] { -1754f, 2275f },
			new float[2] { -1750f, 2246f },
			new float[2] { -1741f, 2175f },
			new float[2] { -1752f, 2133f },
			new float[2] { -1736f, 2073f },
			new float[2] { -1723f, 1999f },
			new float[2] { -1732f, 1971f },
			new float[2] { -1760f, 1927f },
			new float[2] { -1798f, 1895f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(51, "49", 103, 148, new float[2] { -2091.5f, 1910.5f }, new float[7][]
		{
			new float[2] { -1844f, 1855f },
			new float[2] { -1913f, 1848f },
			new float[2] { -1962f, 1851f },
			new float[2] { -2037f, 1854f },
			new float[2] { -2149f, 1883f },
			new float[2] { -2204f, 1917f },
			new float[2] { -2247f, 1949f }
		}, null, new short[2] { 26, 102 }));
		_dataArray.Add(new MapRouteItem(52, "50", 103, 106, new float[2] { -1940f, 1633f }, new float[14][]
		{
			new float[2] { -1706f, 1806f },
			new float[2] { -1753f, 1838f },
			new float[2] { -1781f, 1861f },
			new float[2] { -1809f, 1842f },
			new float[2] { -1827f, 1837f },
			new float[2] { -1864f, 1821f },
			new float[2] { -1879f, 1783f },
			new float[2] { -1906f, 1751f },
			new float[2] { -1922f, 1693f },
			new float[2] { -1958f, 1645f },
			new float[2] { -1982f, 1580f },
			new float[2] { -2010f, 1522f },
			new float[2] { -2047f, 1482f },
			new float[2] { -2066f, 1443f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(53, "51", 102, 148, new float[2] { -2321f, 2553.5f }, new float[23][]
		{
			new float[2] { -2108f, 3088f },
			new float[2] { -2106f, 3029f },
			new float[2] { -2125f, 2994f },
			new float[2] { -2167f, 2973f },
			new float[2] { -2205f, 2936f },
			new float[2] { -2246f, 2910f },
			new float[2] { -2284f, 2869f },
			new float[2] { -2296f, 2820f },
			new float[2] { -2274f, 2727f },
			new float[2] { -2304f, 2627f },
			new float[2] { -2343f, 2567f },
			new float[2] { -2401f, 2509f },
			new float[2] { -2422f, 2474f },
			new float[2] { -2472f, 2430f },
			new float[2] { -2510f, 2358f },
			new float[2] { -2538f, 2283f },
			new float[2] { -2535f, 2239f },
			new float[2] { -2527f, 2168f },
			new float[2] { -2495f, 2127f },
			new float[2] { -2479f, 2075f },
			new float[2] { -2445f, 2024f },
			new float[2] { -2397f, 2003f },
			new float[2] { -2367f, 1999f }
		}, null, new short[2] { 26, 103 }));
		_dataArray.Add(new MapRouteItem(54, "52", 26, 148, new float[2] { -2538f, 2078f }, new float[7][]
		{
			new float[2] { -2709f, 2134f },
			new float[2] { -2676f, 2102f },
			new float[2] { -2630f, 2074f },
			new float[2] { -2545f, 2053f },
			new float[2] { -2499f, 2026f },
			new float[2] { -2472f, 2013f },
			new float[2] { -2431f, 1990f }
		}, null, new short[2] { 102, 103 }));
		_dataArray.Add(new MapRouteItem(55, "53", 11, 42, new float[2] { -1297.5f, 1100.5f }, new float[11][]
		{
			new float[2] { -1238f, 1308f },
			new float[2] { -1223f, 1262f },
			new float[2] { -1202f, 1220f },
			new float[2] { -1200f, 1183f },
			new float[2] { -1225f, 1161f },
			new float[2] { -1321f, 1115f },
			new float[2] { -1363f, 1094f },
			new float[2] { -1381f, 1060f },
			new float[2] { -1395f, 981f },
			new float[2] { -1385f, 914f },
			new float[2] { -1369f, 886f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(56, "54", 42, 53, new float[2] { -887f, 693.5f }, new float[13][]
		{
			new float[2] { -1319f, 838f },
			new float[2] { -1263f, 845f },
			new float[2] { -1198f, 828f },
			new float[2] { -1156f, 817f },
			new float[2] { -1113f, 772f },
			new float[2] { -1067f, 751f },
			new float[2] { -967f, 741f },
			new float[2] { -857f, 715f },
			new float[2] { -808f, 635f },
			new float[2] { -721f, 553f },
			new float[2] { -645f, 539f },
			new float[2] { -557f, 549f },
			new float[2] { -478f, 575f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(57, "55", 41, 42, new float[2] { -1691.5f, 815.5f }, new float[7][]
		{
			new float[2] { -1956f, 805f },
			new float[2] { -1864f, 792f },
			new float[2] { -1793f, 794f },
			new float[2] { -1735f, 786f },
			new float[2] { -1594f, 789f },
			new float[2] { -1511f, 814f },
			new float[2] { -1421f, 848f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(58, "56", 39, 41, new float[2] { -2141f, 838.5f }, new float[5][]
		{
			new float[2] { -2255f, 843f },
			new float[2] { -2200f, 828f },
			new float[2] { -2161f, 829f },
			new float[2] { -2116f, 820f },
			new float[2] { -2061f, 824f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(59, "57", 2, 41, new float[2] { -2006.5f, 626f }, new float[9][]
		{
			new float[2] { -2046f, 516f },
			new float[2] { -1993f, 563f },
			new float[2] { -1951f, 612f },
			new float[2] { -1947f, 645f },
			new float[2] { -1959f, 675f },
			new float[2] { -1958f, 693f },
			new float[2] { -1976f, 722f },
			new float[2] { -1978f, 750f },
			new float[2] { -2000f, 789f }
		}, null, null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MapRouteItem(60, "58", 2, 38, new float[2] { -1904f, 442f }, new float[4][]
		{
			new float[2] { -2030f, 441f },
			new float[2] { -1967f, 435f },
			new float[2] { -1898f, 434f },
			new float[2] { -1812f, 439f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(61, "59", 38, 43, new float[2] { -1572f, 66.5f }, new float[24][]
		{
			new float[2] { -1706f, 422f },
			new float[2] { -1687f, 422f },
			new float[2] { -1610f, 399f },
			new float[2] { -1590f, 392f },
			new float[2] { -1553f, 382f },
			new float[2] { -1503f, 364f },
			new float[2] { -1504f, 342f },
			new float[2] { -1497f, 275f },
			new float[2] { -1442f, 264f },
			new float[2] { -1414f, 249f },
			new float[2] { -1412f, 232f },
			new float[2] { -1390f, 208f },
			new float[2] { -1384f, 174f },
			new float[2] { -1395f, 143f },
			new float[2] { -1405f, 116f },
			new float[2] { -1435f, 63f },
			new float[2] { -1467f, 44f },
			new float[2] { -1472f, 3f },
			new float[2] { -1503f, -27f },
			new float[2] { -1522f, -53f },
			new float[2] { -1532f, -105f },
			new float[2] { -1521f, -123f },
			new float[2] { -1517f, -183f },
			new float[2] { -1496f, -248f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(62, "60", 2, 40, new float[2] { -2230.5f, 519.5f }, new float[6][]
		{
			new float[2] { -2106f, 460f },
			new float[2] { -2131f, 476f },
			new float[2] { -2162f, 524f },
			new float[2] { -2210f, 562f },
			new float[2] { -2274f, 582f },
			new float[2] { -2327f, 592f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(63, "61", 2, 44, new float[2] { -2102.5f, 318f }, new float[8][]
		{
			new float[2] { -2068f, 420f },
			new float[2] { -2048f, 380f },
			new float[2] { -2031f, 340f },
			new float[2] { -2033f, 283f },
			new float[2] { -2048f, 264f },
			new float[2] { -2048f, 234f },
			new float[2] { -2085f, 216f },
			new float[2] { -2159f, 204f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(64, "62", 44, 151, new float[2] { -2206.5f, 96f }, new float[5][]
		{
			new float[2] { -2187f, 150f },
			new float[2] { -2178f, 125f },
			new float[2] { -2184f, 82f },
			new float[2] { -2221f, 39f },
			new float[2] { -2234f, 28f }
		}, null, new short[2] { 17, 114 }));
		_dataArray.Add(new MapRouteItem(65, "63", 17, 151, new float[2] { -2369.5f, -7.5f }, new float[3][]
		{
			new float[2] { -2442f, -17f },
			new float[2] { -2361f, -20f },
			new float[2] { -2294f, -7f }
		}, null, new short[2] { 44, 114 }));
		_dataArray.Add(new MapRouteItem(66, "64", 114, 151, new float[2] { -2350.5f, -504.5f }, new float[21][]
		{
			new float[2] { -2518f, -987f },
			new float[2] { -2508f, -945f },
			new float[2] { -2468f, -863f },
			new float[2] { -2548f, -753f },
			new float[2] { -2550f, -695f },
			new float[2] { -2530f, -632f },
			new float[2] { -2486f, -532f },
			new float[2] { -2434f, -510f },
			new float[2] { -2353f, -505f },
			new float[2] { -2322f, -497f },
			new float[2] { -2266f, -455f },
			new float[2] { -2175f, -416f },
			new float[2] { -2162f, -393f },
			new float[2] { -2152f, -338f },
			new float[2] { -2164f, -317f },
			new float[2] { -2147f, -261f },
			new float[2] { -2157f, -234f },
			new float[2] { -2206f, -129f },
			new float[2] { -2203f, -84f },
			new float[2] { -2218f, -54f },
			new float[2] { -2238f, -36f }
		}, null, new short[2] { 17, 44 }));
		_dataArray.Add(new MapRouteItem(67, "65", 43, 46, new float[2] { -1682.5f, -931f }, new float[24][]
		{
			new float[2] { -1527f, -314f },
			new float[2] { -1631f, -400f },
			new float[2] { -1694f, -458f },
			new float[2] { -1737f, -544f },
			new float[2] { -1777f, -599f },
			new float[2] { -1786f, -644f },
			new float[2] { -1766f, -724f },
			new float[2] { -1745f, -792f },
			new float[2] { -1718f, -843f },
			new float[2] { -1678f, -974f },
			new float[2] { -1672f, -1004f },
			new float[2] { -1644f, -1022f },
			new float[2] { -1639f, -1057f },
			new float[2] { -1634f, -1073f },
			new float[2] { -1632f, -1152f },
			new float[2] { -1614f, -1184f },
			new float[2] { -1609f, -1276f },
			new float[2] { -1632f, -1318f },
			new float[2] { -1670f, -1368f },
			new float[2] { -1721f, -1397f },
			new float[2] { -1745f, -1416f },
			new float[2] { -1776f, -1466f },
			new float[2] { -1806f, -1506f },
			new float[2] { -1863f, -1539f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(68, "66", 43, 86, new float[2] { -1083f, -423.5f }, new float[11][]
		{
			new float[2] { -1424f, -378f },
			new float[2] { -1323f, -521f },
			new float[2] { -1259f, -543f },
			new float[2] { -1177f, -536f },
			new float[2] { -1147f, -512f },
			new float[2] { -1111f, -507f },
			new float[2] { -1086f, -499f },
			new float[2] { -1036f, -492f },
			new float[2] { -963f, -504f },
			new float[2] { -901f, -524f },
			new float[2] { -813f, -533f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(69, "67", 63, 146, new float[2] { -75.5f, 1297f }, new float[9][]
		{
			new float[2] { -44f, 1532f },
			new float[2] { -74f, 1522f },
			new float[2] { -124f, 1472f },
			new float[2] { -133f, 1434f },
			new float[2] { -122f, 1376f },
			new float[2] { -102f, 1323f },
			new float[2] { -82f, 1279f },
			new float[2] { -98f, 1233f },
			new float[2] { -100f, 1162f }
		}, null, new short[2] { 31, 56 }));
		_dataArray.Add(new MapRouteItem(70, "67_1", 56, 146, new float[2] { -188.5f, 962.5f }, new float[4][]
		{
			new float[2] { -235f, 887f },
			new float[2] { -197f, 920f },
			new float[2] { -170f, 951f },
			new float[2] { -163f, 977f }
		}, null, new short[2] { 31, 63 }));
		_dataArray.Add(new MapRouteItem(71, "68", 52, 56, new float[2] { -406f, 888.5f }, new float[4][]
		{
			new float[2] { -501f, 894f },
			new float[2] { -432f, 897f },
			new float[2] { -370f, 894f },
			new float[2] { -326f, 874f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(72, "69", 31, 146, new float[2] { 70.5f, 982.5f }, new float[5][]
		{
			new float[2] { 123f, 955f },
			new float[2] { 75f, 988f },
			new float[2] { -9f, 1034f },
			new float[2] { -59f, 1039f },
			new float[2] { -101f, 1038f }
		}, null, new short[2] { 56, 63 }));
		_dataArray.Add(new MapRouteItem(73, "70", 19, 56, new float[2] { -209.5f, 640f }, new float[7][]
		{
			new float[2] { -156f, 448f },
			new float[2] { -182f, 510f },
			new float[2] { -219f, 565f },
			new float[2] { -249f, 592f },
			new float[2] { -269f, 633f },
			new float[2] { -270f, 688f },
			new float[2] { -247f, 723f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(74, "71", 4, 31, new float[2] { 198.5f, 584.5f }, new float[13][]
		{
			new float[2] { 219f, 326f },
			new float[2] { 194f, 394f },
			new float[2] { 143f, 467f },
			new float[2] { 133f, 508f },
			new float[2] { 148f, 558f },
			new float[2] { 167f, 626f },
			new float[2] { 210f, 676f },
			new float[2] { 210f, 676f },
			new float[2] { 216f, 698f },
			new float[2] { 206f, 727f },
			new float[2] { 212f, 747f },
			new float[2] { 199f, 801f },
			new float[2] { 235f, 858f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(75, "72", 19, 53, new float[2] { -281f, 495f }, new float[5][]
		{
			new float[2] { -187f, 447f },
			new float[2] { -232f, 504f },
			new float[2] { -292f, 549f },
			new float[2] { -342f, 573f },
			new float[2] { -382f, 589f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(76, "73", 4, 19, new float[2] { 28f, 327f }, new float[6][]
		{
			new float[2] { 179f, 268f },
			new float[2] { 127f, 272f },
			new float[2] { 47f, 272f },
			new float[2] { -35f, 265f },
			new float[2] { -91f, 282f },
			new float[2] { -131f, 320f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(77, "74", 4, 8, new float[2] { 103.5f, -12.5f }, new float[13][]
		{
			new float[2] { 207f, 232f },
			new float[2] { 199f, 194f },
			new float[2] { 171f, 179f },
			new float[2] { 108f, 160f },
			new float[2] { 50f, 100f },
			new float[2] { 37f, 55f },
			new float[2] { 50f, -15f },
			new float[2] { 63f, -58f },
			new float[2] { 75f, -85f },
			new float[2] { 70f, -141f },
			new float[2] { 60f, -211f },
			new float[2] { 35f, -248f },
			new float[2] { 14f, -265f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(78, "75", 4, 55, new float[2] { 289f, 92f }, new float[6][]
		{
			new float[2] { 239f, 211f },
			new float[2] { 231f, 167f },
			new float[2] { 234f, 100f },
			new float[2] { 247f, 67f },
			new float[2] { 290f, -4f },
			new float[2] { 314f, -37f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(79, "76", 55, 58, new float[2] { 515.5f, -65f }, new float[4][]
		{
			new float[2] { 391f, -71f },
			new float[2] { 463f, -50f },
			new float[2] { 553f, -50f },
			new float[2] { 617f, -55f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(80, "77", 54, 58, new float[2] { 742.5f, -265.5f }, new float[5][]
		{
			new float[2] { 801f, -381f },
			new float[2] { 782f, -302f },
			new float[2] { 761f, -220f },
			new float[2] { 737f, -153f },
			new float[2] { 704f, -102f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(81, "78", 54, 57, new float[2] { 785.5f, -566f }, new float[3][]
		{
			new float[2] { 826f, -487f },
			new float[2] { 811f, -540f },
			new float[2] { 784f, -588f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(82, "79", 57, 84, new float[2] { 460f, -610.5f }, new float[6][]
		{
			new float[2] { 572f, -642f },
			new float[2] { 529f, -620f },
			new float[2] { 475f, -582f },
			new float[2] { 324f, -535f },
			new float[2] { 258f, -546f },
			new float[2] { 209f, -561f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(83, "80", 28, 57, new float[2] { 949.5f, -958f }, new float[9][]
		{
			new float[2] { 1125f, -1219f },
			new float[2] { 989f, -1217f },
			new float[2] { 946f, -1201f },
			new float[2] { 892f, -1151f },
			new float[2] { 860f, -1088f },
			new float[2] { 845f, -1039f },
			new float[2] { 837f, -1008f },
			new float[2] { 779f, -928f },
			new float[2] { 752f, -836f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(84, "81", 23, 80, new float[2] { -420f, 5f }, new float[6][]
		{
			new float[2] { -313f, 3f },
			new float[2] { -362f, 7f },
			new float[2] { -410f, 10f },
			new float[2] { -482f, -8f },
			new float[2] { -530f, -12f },
			new float[2] { -565f, -2f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(85, "82", 8, 23, new float[2] { -145.5f, -136.5f }, new float[9][]
		{
			new float[2] { -54f, -264f },
			new float[2] { -70f, -227f },
			new float[2] { -94f, -213f },
			new float[2] { -113f, -199f },
			new float[2] { -139f, -190f },
			new float[2] { -165f, -172f },
			new float[2] { -196f, -151f },
			new float[2] { -247f, -97f },
			new float[2] { -250f, -23f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(86, "83", 8, 84, new float[2] { 80.5f, -408.5f }, new float[6][]
		{
			new float[2] { 18f, -304f },
			new float[2] { 53f, -323f },
			new float[2] { 121f, -394f },
			new float[2] { 142f, -423f },
			new float[2] { 163f, -458f },
			new float[2] { 168f, -487f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(87, "84", 83, 84, new float[2] { 94.5f, -647f }, new float[5][]
		{
			new float[2] { 16f, -723f },
			new float[2] { 23f, -656f },
			new float[2] { 38f, -627f },
			new float[2] { 80f, -579f },
			new float[2] { 138f, -557f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(88, "85", 83, 86, new float[2] { -341.5f, -696f }, new float[14][]
		{
			new float[2] { -32f, -765f },
			new float[2] { -83f, -794f },
			new float[2] { -168f, -833f },
			new float[2] { -239f, -854f },
			new float[2] { -338f, -865f },
			new float[2] { -448f, -842f },
			new float[2] { -499f, -812f },
			new float[2] { -505f, -779f },
			new float[2] { -526f, -752f },
			new float[2] { -520f, -732f },
			new float[2] { -529f, -653f },
			new float[2] { -578f, -614f },
			new float[2] { -582f, -593f },
			new float[2] { -647f, -562f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(89, "86", 81, 83, new float[2] { 42f, -897f }, new float[5][]
		{
			new float[2] { 46f, -994f },
			new float[2] { 6f, -936f },
			new float[2] { 2f, -889f },
			new float[2] { 18f, -823f },
			new float[2] { 12f, -790f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(90, "87", 81, 150, new float[2] { 68f, -1175f }, new float[7][]
		{
			new float[2] { 101f, -1049f },
			new float[2] { 102f, -1083f },
			new float[2] { 113f, -1108f },
			new float[2] { 110f, -1146f },
			new float[2] { 94f, -1191f },
			new float[2] { 47f, -1259f },
			new float[2] { 42f, -1288f }
		}, null, new short[2] { 82, 85 }));
		_dataArray.Add(new MapRouteItem(91, "88", 82, 150, new float[2] { 116.5f, -1358f }, new float[2][]
		{
			new float[2] { 175f, -1377f },
			new float[2] { 54f, -1338f }
		}, null, new short[2] { 81, 85 }));
		_dataArray.Add(new MapRouteItem(92, "89", 85, 150, new float[2] { -91.5f, -1427.5f }, new float[5][]
		{
			new float[2] { -179f, -1500f },
			new float[2] { -151f, -1459f },
			new float[2] { -101f, -1403f },
			new float[2] { -69f, -1375f },
			new float[2] { -16f, -1347f }
		}, null, new short[2] { 81, 82 }));
		_dataArray.Add(new MapRouteItem(93, "90", 49, 85, new float[2] { -466.5f, -1578.5f }, new float[8][]
		{
			new float[2] { -648f, -1617f },
			new float[2] { -595f, -1612f },
			new float[2] { -572f, -1599f },
			new float[2] { -536f, -1564f },
			new float[2] { -512f, -1556f },
			new float[2] { -471f, -1546f },
			new float[2] { -324f, -1545f },
			new float[2] { -286f, -1540f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(94, "91", 71, 85, new float[2] { -113.5f, -1847f }, new float[12][]
		{
			new float[2] { 10f, -2105f },
			new float[2] { -36f, -2056f },
			new float[2] { -89f, -2037f },
			new float[2] { -125f, -2035f },
			new float[2] { -149f, -2041f },
			new float[2] { -217f, -1998f },
			new float[2] { -235f, -1976f },
			new float[2] { -250f, -1924f },
			new float[2] { -254f, -1780f },
			new float[2] { -242f, -1707f },
			new float[2] { -228f, -1675f },
			new float[2] { -214f, -1603f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(95, "92", 117, 139, new float[2] { 1184f, 482f }, new float[11][]
		{
			new float[2] { 1211f, 231f },
			new float[2] { 1189f, 257f },
			new float[2] { 1159f, 291f },
			new float[2] { 1159f, 428f },
			new float[2] { 1178f, 471f },
			new float[2] { 1193f, 542f },
			new float[2] { 1184f, 579f },
			new float[2] { 1160f, 592f },
			new float[2] { 1140f, 632f },
			new float[2] { 1145f, 728f },
			new float[2] { 1180f, 745f }
		}, null, new short[3] { 1, 37, 132 }));
		_dataArray.Add(new MapRouteItem(96, "93", 13, 117, new float[2] { 1385f, 195f }, new float[4][]
		{
			new float[2] { 1505f, 166f },
			new float[2] { 1427f, 188f },
			new float[2] { 1327f, 193f },
			new float[2] { 1266f, 197f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(97, "94", 13, 130, new float[2] { 1815f, 83f }, new float[8][]
		{
			new float[2] { 1625f, 175f },
			new float[2] { 1673f, 190f },
			new float[2] { 1758f, 186f },
			new float[2] { 1822f, 167f },
			new float[2] { 1873f, 123f },
			new float[2] { 1921f, 38f },
			new float[2] { 1970f, -2f },
			new float[2] { 2027f, -16f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(98, "95", 13, 115, new float[2] { 1453f, 19.5f }, new float[5][]
		{
			new float[2] { 1518f, 136f },
			new float[2] { 1486f, 131f },
			new float[2] { 1416f, 66f },
			new float[2] { 1398f, 16f },
			new float[2] { 1376f, -58f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(99, "96", 115, 121, new float[2] { 1506f, -139.5f }, new float[4][]
		{
			new float[2] { 1407f, -119f },
			new float[2] { 1488f, -118f },
			new float[2] { 1554f, -131f },
			new float[2] { 1605f, -138f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(100, "97", 121, 123, new float[2] { 1918.5f, -367.5f }, new float[10][]
		{
			new float[2] { 1705f, -207f },
			new float[2] { 1784f, -269f },
			new float[2] { 1849f, -286f },
			new float[2] { 1874f, -289f },
			new float[2] { 1934f, -339f },
			new float[2] { 1961f, -395f },
			new float[2] { 1960f, -425f },
			new float[2] { 1987f, -477f },
			new float[2] { 2040f, -516f },
			new float[2] { 2060f, -539f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(101, "98", 115, 120, new float[2] { 1339.5f, -259f }, new float[3][]
		{
			new float[2] { 1358f, -164f },
			new float[2] { 1360f, -227f },
			new float[2] { 1346f, -300f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(102, "99", 119, 120, new float[2] { 1515.5f, -379.5f }, new float[7][]
		{
			new float[2] { 1662f, -397f },
			new float[2] { 1624f, -380f },
			new float[2] { 1580f, -385f },
			new float[2] { 1509f, -416f },
			new float[2] { 1438f, -430f },
			new float[2] { 1407f, -419f },
			new float[2] { 1350f, -386f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(103, "100", 120, 144, new float[2] { 1316.5f, -493.5f }, new float[5][]
		{
			new float[2] { 1311f, -375f },
			new float[2] { 1307f, -399f },
			new float[2] { 1294f, -430f },
			new float[2] { 1303f, -485f },
			new float[2] { 1327f, -578f }
		}, null, new short[2] { 116, 118 }));
		_dataArray.Add(new MapRouteItem(104, "101", 116, 144, new float[2] { 1423f, -648.5f }, new float[2][]
		{
			new float[2] { 1439f, -658f },
			new float[2] { 1380f, -653f }
		}, null, new short[2] { 118, 120 }));
		_dataArray.Add(new MapRouteItem(105, "102", 118, 144, new float[2] { 1233f, -767.5f }, new float[4][]
		{
			new float[2] { 1133f, -864f },
			new float[2] { 1174f, -831f },
			new float[2] { 1239f, -763f },
			new float[2] { 1298f, -706f }
		}, null, new short[2] { 116, 120 }));
		_dataArray.Add(new MapRouteItem(106, "103", 118, 127, new float[2] { 1434f, -915.5f }, new float[9][]
		{
			new float[2] { 1156f, -885f },
			new float[2] { 1259f, -850f },
			new float[2] { 1333f, -821f },
			new float[2] { 1407f, -818f },
			new float[2] { 1475f, -844f },
			new float[2] { 1594f, -922f },
			new float[2] { 1603f, -954f },
			new float[2] { 1630f, -990f },
			new float[2] { 1686f, -1004f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(107, "104", 28, 118, new float[2] { 1129.5f, -1049f }, new float[5][]
		{
			new float[2] { 1155f, -1189f },
			new float[2] { 1137f, -1167f },
			new float[2] { 1115f, -1110f },
			new float[2] { 1101f, -1056f },
			new float[2] { 1108f, -948f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(108, "105", 28, 145, new float[2] { 1080f, -1493.5f }, new float[11][]
		{
			new float[2] { 1146f, -1219f },
			new float[2] { 1156f, -1260f },
			new float[2] { 1143f, -1312f },
			new float[2] { 1134f, -1327f },
			new float[2] { 1094f, -1359f },
			new float[2] { 1093f, -1383f },
			new float[2] { 1072f, -1467f },
			new float[2] { 1072f, -1504f },
			new float[2] { 1039f, -1614f },
			new float[2] { 1013f, -1658f },
			new float[2] { 1000f, -1716f }
		}, null, new short[3] { 69, 82, 90 }));
		_dataArray.Add(new MapRouteItem(109, "106", 131, 132, new float[2] { 2109.5f, 568.5f }, new float[6][]
		{
			new float[2] { 2192f, 550f },
			new float[2] { 2168f, 579f },
			new float[2] { 2142f, 607f },
			new float[2] { 2096f, 636f },
			new float[2] { 2048f, 652f },
			new float[2] { 2007f, 649f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(110, "107", 131, 135, new float[2] { 2273.5f, 628f }, new float[5][]
		{
			new float[2] { 2257f, 508f },
			new float[2] { 2284f, 577f },
			new float[2] { 2301f, 615f },
			new float[2] { 2305f, 700f },
			new float[2] { 2303f, 743f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(111, "108", 131, 134, new float[2] { 2203f, 369.5f }, new float[5][]
		{
			new float[2] { 2209f, 438f },
			new float[2] { 2174f, 393f },
			new float[2] { 2161f, 357f },
			new float[2] { 2162f, 332f },
			new float[2] { 2179f, 269f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(112, "109", 30, 134, new float[2] { 2046.5f, 311.5f }, new float[9][]
		{
			new float[2] { 1895f, 351f },
			new float[2] { 1900f, 290f },
			new float[2] { 1922f, 265f },
			new float[2] { 1945f, 256f },
			new float[2] { 1995f, 263f },
			new float[2] { 2042f, 262f },
			new float[2] { 2056f, 246f },
			new float[2] { 2074f, 239f },
			new float[2] { 2155f, 242f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(113, "110", 130, 134, new float[2] { 2123f, 115.5f }, new float[7][]
		{
			new float[2] { 2068f, -3f },
			new float[2] { 2049f, 28f },
			new float[2] { 2051f, 84f },
			new float[2] { 2092f, 136f },
			new float[2] { 2154f, 176f },
			new float[2] { 2177f, 203f },
			new float[2] { 2182f, 227f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(114, "111", 15, 130, new float[2] { 2228.5f, -47.5f }, new float[6][]
		{
			new float[2] { 2345f, -70f },
			new float[2] { 2295f, -84f },
			new float[2] { 2213f, -80f },
			new float[2] { 2191f, -64f },
			new float[2] { 2141f, -42f },
			new float[2] { 2101f, -21f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(115, "112", 15, 129, new float[2] { 2754f, -189.5f }, new float[11][]
		{
			new float[2] { 2441f, -67f },
			new float[2] { 2514f, -30f },
			new float[2] { 2625f, -12f },
			new float[2] { 2741f, -18f },
			new float[2] { 2811f, -32f },
			new float[2] { 2847f, -63f },
			new float[2] { 2877f, -122f },
			new float[2] { 2942f, -194f },
			new float[2] { 3020f, -329f },
			new float[2] { 3046f, -366f },
			new float[2] { 3073f, -369f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(116, "113", 15, 133, new float[2] { 2308f, -198f }, new float[5][]
		{
			new float[2] { 2373f, -120f },
			new float[2] { 2360f, -165f },
			new float[2] { 2315f, -230f },
			new float[2] { 2274f, -279f },
			new float[2] { 2250f, -300f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(117, "114", 123, 133, new float[2] { 2195f, -453f }, new float[7][]
		{
			new float[2] { 2161f, -560f },
			new float[2] { 2146f, -530f },
			new float[2] { 2143f, -485f },
			new float[2] { 2150f, -450f },
			new float[2] { 2159f, -418f },
			new float[2] { 2182f, -378f },
			new float[2] { 2210f, -349f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(118, "115", 122, 123, new float[2] { 2306f, -626.5f }, new float[6][]
		{
			new float[2] { 2401f, -657f },
			new float[2] { 2345f, -669f },
			new float[2] { 2286f, -672f },
			new float[2] { 2227f, -666f },
			new float[2] { 2190f, -644f },
			new float[2] { 2176f, -602f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(119, "116", 29, 122, new float[2] { 2838f, -796f }, new float[21][]
		{
			new float[2] { 3187f, -939f },
			new float[2] { 3161f, -933f },
			new float[2] { 3127f, -931f },
			new float[2] { 3090f, -908f },
			new float[2] { 3075f, -881f },
			new float[2] { 3074f, -860f },
			new float[2] { 3055f, -840f },
			new float[2] { 3036f, -819f },
			new float[2] { 2996f, -800f },
			new float[2] { 2970f, -803f },
			new float[2] { 2935f, -815f },
			new float[2] { 2900f, -821f },
			new float[2] { 2842f, -812f },
			new float[2] { 2752f, -788f },
			new float[2] { 2716f, -783f },
			new float[2] { 2694f, -788f },
			new float[2] { 2661f, -788f },
			new float[2] { 2625f, -775f },
			new float[2] { 2604f, -744f },
			new float[2] { 2553f, -696f },
			new float[2] { 2490f, -661f }
		}, null, null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MapRouteItem(120, "117", 14, 122, new float[2] { 2436f, -817f }, new float[7][]
		{
			new float[2] { 2423f, -951f },
			new float[2] { 2445f, -905f },
			new float[2] { 2469f, -858f },
			new float[2] { 2471f, -817f },
			new float[2] { 2464f, -786f },
			new float[2] { 2446f, -736f },
			new float[2] { 2430f, -686f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(121, "118", 14, 125, new float[2] { 2234.5f, -907f }, new float[8][]
		{
			new float[2] { 2363f, -973f },
			new float[2] { 2308f, -955f },
			new float[2] { 2291f, -939f },
			new float[2] { 2261f, -917f },
			new float[2] { 2238f, -892f },
			new float[2] { 2194f, -869f },
			new float[2] { 2133f, -852f },
			new float[2] { 2092f, -846f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(122, "119", 14, 126, new float[2] { 2619.5f, -1053f }, new float[9][]
		{
			new float[2] { 2393f, -1001f },
			new float[2] { 2409f, -1041f },
			new float[2] { 2428f, -1068f },
			new float[2] { 2463f, -1088f },
			new float[2] { 2530f, -1106f },
			new float[2] { 2556f, -1103f },
			new float[2] { 2590f, -1107f },
			new float[2] { 2712f, -1102f },
			new float[2] { 2755f, -1103f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(123, "120", 14, 141, new float[2] { 2329.5f, -1073f }, new float[4][]
		{
			new float[2] { 2357f, -1024f },
			new float[2] { 2324f, -1052f },
			new float[2] { 2315f, -1083f },
			new float[2] { 2295f, -1128f }
		}, null, new short[2] { 124, 128 }));
		_dataArray.Add(new MapRouteItem(124, "121", 127, 128, new float[2] { 1869f, -1055f }, new float[7][]
		{
			new float[2] { 1752f, -1013f },
			new float[2] { 1761f, -1035f },
			new float[2] { 1791f, -1073f },
			new float[2] { 1807f, -1082f },
			new float[2] { 1852f, -1094f },
			new float[2] { 1910f, -1103f },
			new float[2] { 1965f, -1106f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(125, "122", 128, 141, new float[2] { 2132f, -1130f }, new float[2][]
		{
			new float[2] { 2131f, -1125f },
			new float[2] { 2224f, -1147f }
		}, null, new short[2] { 14, 124 }));
		_dataArray.Add(new MapRouteItem(126, "123", 124, 141, new float[2] { 2409f, -1230f }, new float[1][] { new float[2] { 2393f, -1211f } }, null, new short[2] { 14, 128 }));
		_dataArray.Add(new MapRouteItem(127, "124", 24, 128, new float[2] { 1901.5f, -1494.5f }, new float[18][]
		{
			new float[2] { 1754f, -1866f },
			new float[2] { 1760f, -1820f },
			new float[2] { 1767f, -1683f },
			new float[2] { 1780f, -1636f },
			new float[2] { 1788f, -1584f },
			new float[2] { 1812f, -1561f },
			new float[2] { 1854f, -1561f },
			new float[2] { 1895f, -1552f },
			new float[2] { 1932f, -1529f },
			new float[2] { 1939f, -1501f },
			new float[2] { 1959f, -1483f },
			new float[2] { 1965f, -1462f },
			new float[2] { 2012f, -1415f },
			new float[2] { 2037f, -1350f },
			new float[2] { 2056f, -1265f },
			new float[2] { 2043f, -1211f },
			new float[2] { 2027f, -1170f },
			new float[2] { 2014f, -1133f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(128, "125", 89, 93, new float[2] { 2079f, -1812f }, new float[5][]
		{
			new float[2] { 2071f, -1909f },
			new float[2] { 2091f, -1886f },
			new float[2] { 2106f, -1855f },
			new float[2] { 2109f, -1805f },
			new float[2] { 2094f, -1752f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(129, "126", 9, 89, new float[2] { 2017.5f, -2099.5f }, new float[9][]
		{
			new float[2] { 1971f, -2250f },
			new float[2] { 2015f, -2219f },
			new float[2] { 2063f, -2165f },
			new float[2] { 2083f, -2126f },
			new float[2] { 2076f, -2088f },
			new float[2] { 2051f, -2040f },
			new float[2] { 2052f, -2009f },
			new float[2] { 2043f, -1977f },
			new float[2] { 2047f, -1957f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(130, "127", 9, 143, new float[2] { 1935f, -2330.5f }, new float[2][]
		{
			new float[2] { 1924f, -2326f },
			new float[2] { 1924f, -2375f }
		}, null, new short[2] { 91, 92 }));
		_dataArray.Add(new MapRouteItem(131, "128", 91, 143, new float[2] { 2135f, -2508f }, new float[9][]
		{
			new float[2] { 2273f, -2606f },
			new float[2] { 2252f, -2589f },
			new float[2] { 2171f, -2545f },
			new float[2] { 2121f, -2526f },
			new float[2] { 2091f, -2526f },
			new float[2] { 2025f, -2512f },
			new float[2] { 1969f, -2486f },
			new float[2] { 1940f, -2458f },
			new float[2] { 1935f, -2435f }
		}, null, new short[2] { 9, 92 }));
		_dataArray.Add(new MapRouteItem(132, "129", 92, 143, new float[2] { 1811.5f, -2561f }, new float[11][]
		{
			new float[2] { 1750f, -2702f },
			new float[2] { 1711f, -2634f },
			new float[2] { 1715f, -2602f },
			new float[2] { 1718f, -2574f },
			new float[2] { 1756f, -2547f },
			new float[2] { 1803f, -2537f },
			new float[2] { 1821f, -2503f },
			new float[2] { 1816f, -2489f },
			new float[2] { 1830f, -2425f },
			new float[2] { 1859f, -2403f },
			new float[2] { 1886f, -2395f }
		}, null, new short[2] { 9, 91 }));
		_dataArray.Add(new MapRouteItem(133, "130", 9, 142, new float[2] { 1824.5f, -2260.5f }, new float[5][]
		{
			new float[2] { 1927f, -2257f },
			new float[2] { 1881f, -2247f },
			new float[2] { 1818f, -2248f },
			new float[2] { 1755f, -2258f },
			new float[2] { 1729f, -2250f }
		}, null, new short[2] { 24, 87 }));
		_dataArray.Add(new MapRouteItem(134, "131", 24, 89, new float[2] { 1901f, -1912f }, new float[3][]
		{
			new float[2] { 1772f, -1900f },
			new float[2] { 1835f, -1909f },
			new float[2] { 1942f, -1919f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(135, "132", 24, 90, new float[2] { 1593f, -1863.5f }, new float[4][]
		{
			new float[2] { 1728f, -1901f },
			new float[2] { 1642f, -1900f },
			new float[2] { 1521f, -1881f },
			new float[2] { 1483f, -1866f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(136, "133", 90, 145, new float[2] { 1229.5f, -1806.5f }, new float[5][]
		{
			new float[2] { 1364f, -1820f },
			new float[2] { 1330f, -1831f },
			new float[2] { 1254f, -1835f },
			new float[2] { 1155f, -1828f },
			new float[2] { 1044f, -1792f }
		}, null, new short[3] { 28, 69, 82 }));
		_dataArray.Add(new MapRouteItem(137, "134", 24, 142, new float[2] { 1724.5f, -2074f }, new float[6][]
		{
			new float[2] { 1747f, -1932f },
			new float[2] { 1757f, -1958f },
			new float[2] { 1760f, -2059f },
			new float[2] { 1767f, -2120f },
			new float[2] { 1752f, -2167f },
			new float[2] { 1712f, -2220f }
		}, null, new short[2] { 9, 87 }));
		_dataArray.Add(new MapRouteItem(138, "135", 87, 142, new float[2] { 1638.5f, -2299f }, new float[1][] { new float[2] { 1639f, -2299f } }, null, new short[2] { 9, 24 }));
		_dataArray.Add(new MapRouteItem(139, "136", 87, 88, new float[2] { 1391f, -2478.5f }, new float[12][]
		{
			new float[2] { 1465f, -2383f },
			new float[2] { 1441f, -2394f },
			new float[2] { 1394f, -2396f },
			new float[2] { 1352f, -2411f },
			new float[2] { 1330f, -2431f },
			new float[2] { 1308f, -2435f },
			new float[2] { 1252f, -2431f },
			new float[2] { 1237f, -2439f },
			new float[2] { 1220f, -2450f },
			new float[2] { 1202f, -2540f },
			new float[2] { 1213f, -2563f },
			new float[2] { 1217f, -2581f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(140, "137", 69, 88, new float[2] { 973.5f, -2497.5f }, new float[10][]
		{
			new float[2] { 760f, -2443f },
			new float[2] { 810f, -2446f },
			new float[2] { 885f, -2442f },
			new float[2] { 931f, -2454f },
			new float[2] { 974f, -2480f },
			new float[2] { 1024f, -2532f },
			new float[2] { 1050f, -2560f },
			new float[2] { 1093f, -2586f },
			new float[2] { 1132f, -2591f },
			new float[2] { 1164f, -2592f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(141, "138", 69, 145, new float[2] { 853f, -2087f }, new float[12][]
		{
			new float[2] { 745f, -2331f },
			new float[2] { 781f, -2239f },
			new float[2] { 795f, -2190f },
			new float[2] { 831f, -2139f },
			new float[2] { 892f, -2065f },
			new float[2] { 941f, -2009f },
			new float[2] { 968f, -1966f },
			new float[2] { 971f, -1942f },
			new float[2] { 990f, -1916f },
			new float[2] { 995f, -1866f },
			new float[2] { 971f, -1831f },
			new float[2] { 982f, -1791f }
		}, null, new short[3] { 28, 82, 90 }));
		_dataArray.Add(new MapRouteItem(142, "139", 82, 145, new float[2] { 601.5f, -1587.5f }, new float[12][]
		{
			new float[2] { 218f, -1450f },
			new float[2] { 253f, -1526f },
			new float[2] { 295f, -1562f },
			new float[2] { 353f, -1602f },
			new float[2] { 459f, -1637f },
			new float[2] { 526f, -1639f },
			new float[2] { 625f, -1665f },
			new float[2] { 682f, -1667f },
			new float[2] { 752f, -1673f },
			new float[2] { 790f, -1663f },
			new float[2] { 851f, -1680f },
			new float[2] { 915f, -1713f }
		}, null, new short[3] { 28, 69, 90 }));
		_dataArray.Add(new MapRouteItem(143, "140", 69, 70, new float[2] { 689.5f, -2527.5f }, new float[5][]
		{
			new float[2] { 701f, -2421f },
			new float[2] { 738f, -2482f },
			new float[2] { 735f, -2541f },
			new float[2] { 729f, -2599f },
			new float[2] { 669f, -2646f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(144, "141", 67, 70, new float[2] { 476.5f, -2731f }, new float[8][]
		{
			new float[2] { 337f, -2790f },
			new float[2] { 347f, -2763f },
			new float[2] { 352f, -2735f },
			new float[2] { 386f, -2696f },
			new float[2] { 428f, -2668f },
			new float[2] { 447f, -2671f },
			new float[2] { 497f, -2664f },
			new float[2] { 560f, -2648f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(145, "142", 6, 67, new float[2] { 179f, -2805f }, new float[5][]
		{
			new float[2] { 110f, -2799f },
			new float[2] { 160f, -2802f },
			new float[2] { 173f, -2813f },
			new float[2] { 209f, -2825f },
			new float[2] { 252f, -2825f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(146, "143", 6, 68, new float[2] { 116f, -2615.5f }, new float[9][]
		{
			new float[2] { 79f, -2769f },
			new float[2] { 111f, -2767f },
			new float[2] { 167f, -2740f },
			new float[2] { 176f, -2725f },
			new float[2] { 184f, -2700f },
			new float[2] { 172f, -2647f },
			new float[2] { 179f, -2601f },
			new float[2] { 196f, -2576f },
			new float[2] { 187f, -2494f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(147, "144", 68, 72, new float[2] { 16f, -2435f }, new float[8][]
		{
			new float[2] { 155f, -2472f },
			new float[2] { 88f, -2486f },
			new float[2] { 22f, -2493f },
			new float[2] { -31f, -2488f },
			new float[2] { -50f, -2471f },
			new float[2] { -87f, -2468f },
			new float[2] { -130f, -2433f },
			new float[2] { -131f, -2404f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(148, "145", 71, 72, new float[2] { -65.5f, -2265.5f }, new float[6][]
		{
			new float[2] { -28f, -2170f },
			new float[2] { -60f, -2195f },
			new float[2] { -115f, -2238f },
			new float[2] { -133f, -2268f },
			new float[2] { -150f, -2304f },
			new float[2] { -154f, -2329f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(149, "146", 47, 72, new float[2] { -556f, -2299.5f }, new float[12][]
		{
			new float[2] { -932f, -2219f },
			new float[2] { -891f, -2235f },
			new float[2] { -805f, -2307f },
			new float[2] { -768f, -2322f },
			new float[2] { -732f, -2346f },
			new float[2] { -675f, -2343f },
			new float[2] { -600f, -2369f },
			new float[2] { -554f, -2395f },
			new float[2] { -448f, -2398f },
			new float[2] { -361f, -2369f },
			new float[2] { -306f, -2372f },
			new float[2] { -234f, -2365f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(150, "147", 6, 21, new float[2] { -126.5f, -2713f }, new float[6][]
		{
			new float[2] { -24f, -2780f },
			new float[2] { -105f, -2788f },
			new float[2] { -154f, -2770f },
			new float[2] { -249f, -2738f },
			new float[2] { -282f, -2711f },
			new float[2] { -282f, -2671f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(151, "148", 6, 66, new float[2] { -26.5f, -2931f }, new float[6][]
		{
			new float[2] { 27f, -2801f },
			new float[2] { 33f, -2815f },
			new float[2] { 34f, -2869f },
			new float[2] { -24f, -2951f },
			new float[2] { -27f, -2991f },
			new float[2] { -47f, -3039f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(152, "149", 49, 51, new float[2] { -872f, -1577f }, new float[5][]
		{
			new float[2] { -760f, -1602f },
			new float[2] { -782f, -1583f },
			new float[2] { -879f, -1558f },
			new float[2] { -938f, -1545f },
			new float[2] { -994f, -1545f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(153, "150", 3, 51, new float[2] { -1119.5f, -1687.5f }, new float[10][]
		{
			new float[2] { -1111f, -1824f },
			new float[2] { -1165f, -1812f },
			new float[2] { -1194f, -1791f },
			new float[2] { -1208f, -1757f },
			new float[2] { -1209f, -1741f },
			new float[2] { -1194f, -1712f },
			new float[2] { -1126f, -1662f },
			new float[2] { -1101f, -1648f },
			new float[2] { -1080f, -1642f },
			new float[2] { -1050f, -1614f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(154, "151", 3, 18, new float[2] { -904f, -1890.5f }, new float[7][]
		{
			new float[2] { -1048f, -1837f },
			new float[2] { -992f, -1848f },
			new float[2] { -963f, -1871f },
			new float[2] { -948f, -1908f },
			new float[2] { -913f, -1929f },
			new float[2] { -833f, -1941f },
			new float[2] { -766f, -1939f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(155, "152", 47, 149, new float[2] { -1051f, -2180.5f }, new float[3][]
		{
			new float[2] { -980f, -2190f },
			new float[2] { -1027f, -2177f },
			new float[2] { -1084f, -2169f }
		}, null, new short[2] { 3, 50 }));
		_dataArray.Add(new MapRouteItem(156, "153", 3, 149, new float[2] { -1123f, -2003.5f }, new float[8][]
		{
			new float[2] { -1085f, -1865f },
			new float[2] { -1083f, -1899f },
			new float[2] { -1089f, -1920f },
			new float[2] { -1085f, -1945f },
			new float[2] { -1100f, -1983f },
			new float[2] { -1126f, -2031f },
			new float[2] { -1143f, -2099f },
			new float[2] { -1147f, -2131f }
		}, null, new short[2] { 47, 50 }));
		_dataArray.Add(new MapRouteItem(157, "154", 3, 46, new float[2] { -1493.5f, -1704f }, new float[16][]
		{
			new float[2] { -1212f, -1853f },
			new float[2] { -1317f, -1815f },
			new float[2] { -1362f, -1807f },
			new float[2] { -1384f, -1809f },
			new float[2] { -1473f, -1764f },
			new float[2] { -1496f, -1745f },
			new float[2] { -1536f, -1727f },
			new float[2] { -1553f, -1708f },
			new float[2] { -1575f, -1704f },
			new float[2] { -1601f, -1702f },
			new float[2] { -1669f, -1726f },
			new float[2] { -1715f, -1730f },
			new float[2] { -1758f, -1731f },
			new float[2] { -1804f, -1714f },
			new float[2] { -1842f, -1654f },
			new float[2] { -1872f, -1591f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(158, "155", 50, 149, new float[2] { -1305.5f, -2083f }, new float[7][]
		{
			new float[2] { -1449f, -2026f },
			new float[2] { -1449f, -2058f },
			new float[2] { -1399f, -2127f },
			new float[2] { -1361f, -2142f },
			new float[2] { -1313f, -2164f },
			new float[2] { -1257f, -2169f },
			new float[2] { -1200f, -2162f }
		}, null, new short[2] { 3, 47 }));
		_dataArray.Add(new MapRouteItem(159, "156", 45, 50, new float[2] { -1547f, -2142f }, new float[8][]
		{
			new float[2] { -1568f, -2264f },
			new float[2] { -1586f, -2226f },
			new float[2] { -1619f, -2175f },
			new float[2] { -1621f, -2138f },
			new float[2] { -1631f, -2094f },
			new float[2] { -1593f, -2040f },
			new float[2] { -1560f, -2025f },
			new float[2] { -1538f, -2006f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(160, "157", 45, 48, new float[2] { -1328f, -2721.5f }, new float[25][]
		{
			new float[2] { -1537f, -2332f },
			new float[2] { -1522f, -2352f },
			new float[2] { -1530f, -2381f },
			new float[2] { -1520f, -2446f },
			new float[2] { -1534f, -2465f },
			new float[2] { -1546f, -2537f },
			new float[2] { -1553f, -2556f },
			new float[2] { -1529f, -2617f },
			new float[2] { -1486f, -2673f },
			new float[2] { -1451f, -2699f },
			new float[2] { -1418f, -2750f },
			new float[2] { -1415f, -2775f },
			new float[2] { -1376f, -2813f },
			new float[2] { -1296f, -2830f },
			new float[2] { -1281f, -2828f },
			new float[2] { -1234f, -2840f },
			new float[2] { -1203f, -2891f },
			new float[2] { -1194f, -2965f },
			new float[2] { -1175f, -2997f },
			new float[2] { -1157f, -3031f },
			new float[2] { -1126f, -3045f },
			new float[2] { -1090f, -3106f },
			new float[2] { -1099f, -3142f },
			new float[2] { -1123f, -3153f },
			new float[2] { -1147f, -3152f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(161, "158", 27, 46, new float[2] { -2263.5f, -1455f }, new float[10][]
		{
			new float[2] { -2581f, -1354f },
			new float[2] { -2478f, -1348f },
			new float[2] { -2418f, -1356f },
			new float[2] { -2405f, -1378f },
			new float[2] { -2363f, -1392f },
			new float[2] { -2214f, -1401f },
			new float[2] { -2164f, -1399f },
			new float[2] { -2089f, -1415f },
			new float[2] { -2015f, -1456f },
			new float[2] { -1959f, -1496f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(162, "159", 27, 114, new float[2] { -2575.5f, -1191.5f }, new float[7][]
		{
			new float[2] { -2632f, -1348f },
			new float[2] { -2596f, -1317f },
			new float[2] { -2542f, -1281f },
			new float[2] { -2513f, -1213f },
			new float[2] { -2529f, -1150f },
			new float[2] { -2534f, -1130f },
			new float[2] { -2546f, -1070f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(163, "160", 12, 114, new float[2] { -2953.5f, -907f }, new float[13][]
		{
			new float[2] { -3345f, -798f },
			new float[2] { -3252f, -795f },
			new float[2] { -3187f, -809f },
			new float[2] { -3103f, -835f },
			new float[2] { -3057f, -853f },
			new float[2] { -3020f, -879f },
			new float[2] { -2952f, -882f },
			new float[2] { -2905f, -884f },
			new float[2] { -2772f, -921f },
			new float[2] { -2703f, -963f },
			new float[2] { -2674f, -986f },
			new float[2] { -2610f, -1005f },
			new float[2] { -2595f, -1014f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(164, "161", 12, 111, new float[2] { -3412.5f, -960f }, new float[6][]
		{
			new float[2] { -3363f, -895f },
			new float[2] { -3398f, -963f },
			new float[2] { -3397f, -978f },
			new float[2] { -3384f, -1003f },
			new float[2] { -3392f, -1028f },
			new float[2] { -3436f, -1079f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(165, "162", 111, 113, new float[2] { -3640f, -1201f }, new float[10][]
		{
			new float[2] { -3512f, -1120f },
			new float[2] { -3589f, -1120f },
			new float[2] { -3645f, -1126f },
			new float[2] { -3654f, -1136f },
			new float[2] { -3719f, -1146f },
			new float[2] { -3736f, -1136f },
			new float[2] { -3777f, -1137f },
			new float[2] { -3823f, -1191f },
			new float[2] { -3827f, -1209f },
			new float[2] { -3825f, -1273f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(166, "163", 110, 113, new float[2] { -3746.5f, -1455.5f }, new float[6][]
		{
			new float[2] { -3666f, -1589f },
			new float[2] { -3679f, -1536f },
			new float[2] { -3704f, -1458f },
			new float[2] { -3739f, -1398f },
			new float[2] { -3778f, -1337f },
			new float[2] { -3824f, -1307f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(167, "164", 110, 112, new float[2] { -3521f, -1665.5f }, new float[4][]
		{
			new float[2] { -3657f, -1646f },
			new float[2] { -3609f, -1679f },
			new float[2] { -3538f, -1710f },
			new float[2] { -3443f, -1711f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(168, "165", 108, 112, new float[2] { -3103.5f, -1803f }, new float[6][]
		{
			new float[2] { -2926f, -1878f },
			new float[2] { -3091f, -1877f },
			new float[2] { -3194f, -1870f },
			new float[2] { -3254f, -1843f },
			new float[2] { -3310f, -1797f },
			new float[2] { -3336f, -1747f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(169, "166", 108, 109, new float[2] { -2826.5f, -1737.5f }, new float[6][]
		{
			new float[2] { -2843f, -1860f },
			new float[2] { -2866f, -1835f },
			new float[2] { -2913f, -1764f },
			new float[2] { -2917f, -1678f },
			new float[2] { -2896f, -1650f },
			new float[2] { -2823f, -1613f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(170, "167", 27, 109, new float[2] { -2690f, -1474f }, new float[6][]
		{
			new float[2] { -2659f, -1412f },
			new float[2] { -2659f, -1462f },
			new float[2] { -2640f, -1498f },
			new float[2] { -2641f, -1529f },
			new float[2] { -2656f, -1565f },
			new float[2] { -2710f, -1583f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(171, "1i", 74, 78, null, new float[8][]
		{
			new float[2] { 2217f, 1299f },
			new float[2] { 2210f, 1248f },
			new float[2] { 2192f, 1212f },
			new float[2] { 2168f, 1178f },
			new float[2] { 2110f, 1141f },
			new float[2] { 2069f, 1127f },
			new float[2] { 2011f, 1125f },
			new float[2] { 1966f, 1134f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(172, "2i", 74, 132, null, new float[10][]
		{
			new float[2] { 2217f, 1299f },
			new float[2] { 2210f, 1248f },
			new float[2] { 2192f, 1212f },
			new float[2] { 2168f, 1178f },
			new float[2] { 2110f, 1141f },
			new float[2] { 2084f, 1102f },
			new float[2] { 2049f, 1037f },
			new float[2] { 2025f, 976f },
			new float[2] { 1992f, 829f },
			new float[2] { 1974f, 723f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(173, "3i", 78, 132, null, new float[9][]
		{
			new float[2] { 1966f, 1134f },
			new float[2] { 2011f, 1125f },
			new float[2] { 2069f, 1127f },
			new float[2] { 2110f, 1141f },
			new float[2] { 2084f, 1102f },
			new float[2] { 2049f, 1037f },
			new float[2] { 2025f, 976f },
			new float[2] { 1992f, 829f },
			new float[2] { 1974f, 723f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(174, "4i", 1, 132, null, new float[14][]
		{
			new float[2] { 1300f, 963f },
			new float[2] { 1302f, 929f },
			new float[2] { 1216f, 805f },
			new float[2] { 1193f, 772f },
			new float[2] { 1189f, 741f },
			new float[2] { 1255f, 722f },
			new float[2] { 1297f, 728f },
			new float[2] { 1371f, 733f },
			new float[2] { 1456f, 716f },
			new float[2] { 1526f, 740f },
			new float[2] { 1585f, 741f },
			new float[2] { 1639f, 747f },
			new float[2] { 1722f, 703f },
			new float[2] { 1796f, 663f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(175, "5i", 1, 37, null, new float[7][]
		{
			new float[2] { 1301f, 961f },
			new float[2] { 1300f, 925f },
			new float[2] { 1202f, 798f },
			new float[2] { 1158f, 779f },
			new float[2] { 1129f, 765f },
			new float[2] { 1078f, 791f },
			new float[2] { 1038f, 846f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(176, "6i", 1, 117, null, new float[13][]
		{
			new float[2] { 1304f, 954f },
			new float[2] { 1280f, 896f },
			new float[2] { 1202f, 791f },
			new float[2] { 1187f, 752f },
			new float[2] { 1147f, 737f },
			new float[2] { 1138f, 634f },
			new float[2] { 1158f, 597f },
			new float[2] { 1189f, 573f },
			new float[2] { 1198f, 543f },
			new float[2] { 1180f, 481f },
			new float[2] { 1160f, 432f },
			new float[2] { 1162f, 279f },
			new float[2] { 1223f, 232f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(177, "7i", 37, 132, null, new float[13][]
		{
			new float[2] { 1034f, 851f },
			new float[2] { 1068f, 799f },
			new float[2] { 1131f, 765f },
			new float[2] { 1175f, 742f },
			new float[2] { 1234f, 725f },
			new float[2] { 1370f, 731f },
			new float[2] { 1451f, 718f },
			new float[2] { 1533f, 743f },
			new float[2] { 1579f, 741f },
			new float[2] { 1636f, 748f },
			new float[2] { 1754f, 691f },
			new float[2] { 1784f, 666f },
			new float[2] { 1898f, 645f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(178, "8i", 37, 117, null, new float[13][]
		{
			new float[2] { 1027f, 857f },
			new float[2] { 1073f, 794f },
			new float[2] { 1136f, 763f },
			new float[2] { 1147f, 737f },
			new float[2] { 1139f, 701f },
			new float[2] { 1141f, 626f },
			new float[2] { 1157f, 591f },
			new float[2] { 1184f, 577f },
			new float[2] { 1194f, 542f },
			new float[2] { 1179f, 473f },
			new float[2] { 1160f, 437f },
			new float[2] { 1158f, 290f },
			new float[2] { 1208f, 242f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(179, "9i", 117, 132, null, new float[17][]
		{
			new float[2] { 1162f, 285f },
			new float[2] { 1158f, 427f },
			new float[2] { 1182f, 482f },
			new float[2] { 1187f, 546f },
			new float[2] { 1172f, 587f },
			new float[2] { 1139f, 630f },
			new float[2] { 1146f, 738f },
			new float[2] { 1184f, 745f },
			new float[2] { 1259f, 721f },
			new float[2] { 1361f, 728f },
			new float[2] { 1456f, 718f },
			new float[2] { 1531f, 743f },
			new float[2] { 1584f, 742f },
			new float[2] { 1643f, 749f },
			new float[2] { 1768f, 686f },
			new float[2] { 1794f, 662f },
			new float[2] { 1905f, 645f }
		}, null, null));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MapRouteItem(180, "10i", 34, 35, null, new float[5][]
		{
			new float[2] { 665f, 1312f },
			new float[2] { 638f, 1330f },
			new float[2] { 598f, 1340f },
			new float[2] { 555f, 1334f },
			new float[2] { 505f, 1250f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(181, "11i", 5, 35, null, new float[10][]
		{
			new float[2] { 634f, 1802f },
			new float[2] { 648f, 1762f },
			new float[2] { 638f, 1729f },
			new float[2] { 652f, 1700f },
			new float[2] { 614f, 1636f },
			new float[2] { 562f, 1581f },
			new float[2] { 541f, 1534f },
			new float[2] { 553f, 1382f },
			new float[2] { 555f, 1334f },
			new float[2] { 505f, 1250f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(182, "12i", 5, 34, null, new float[12][]
		{
			new float[2] { 634f, 1802f },
			new float[2] { 648f, 1762f },
			new float[2] { 638f, 1729f },
			new float[2] { 652f, 1700f },
			new float[2] { 614f, 1636f },
			new float[2] { 562f, 1581f },
			new float[2] { 541f, 1534f },
			new float[2] { 553f, 1382f },
			new float[2] { 555f, 1334f },
			new float[2] { 598f, 1340f },
			new float[2] { 638f, 1330f },
			new float[2] { 665f, 1312f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(183, "13i", 103, 106, null, new float[9][]
		{
			new float[2] { -1864f, 1821f },
			new float[2] { -1879f, 1783f },
			new float[2] { -1906f, 1751f },
			new float[2] { -1922f, 1693f },
			new float[2] { -1958f, 1645f },
			new float[2] { -1982f, 1580f },
			new float[2] { -2010f, 1522f },
			new float[2] { -2047f, 1482f },
			new float[2] { -2066f, 1443f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(184, "14i", 103, 105, null, new float[11][]
		{
			new float[2] { -1746f, 1832f },
			new float[2] { -1700f, 1816f },
			new float[2] { -1641f, 1746f },
			new float[2] { -1582f, 1724f },
			new float[2] { -1512f, 1714f },
			new float[2] { -1444f, 1714f },
			new float[2] { -1375f, 1728f },
			new float[2] { -1324f, 1720f },
			new float[2] { -1277f, 1714f },
			new float[2] { -1228f, 1726f },
			new float[2] { -1172f, 1721f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(185, "15i", 101, 106, null, new float[23][]
		{
			new float[2] { -1746f, 2365f },
			new float[2] { -1765f, 2350f },
			new float[2] { -1774f, 2303f },
			new float[2] { -1754f, 2275f },
			new float[2] { -1750f, 2246f },
			new float[2] { -1741f, 2175f },
			new float[2] { -1752f, 2133f },
			new float[2] { -1736f, 2073f },
			new float[2] { -1723f, 1999f },
			new float[2] { -1732f, 1971f },
			new float[2] { -1760f, 1927f },
			new float[2] { -1798f, 1895f },
			new float[2] { -1790f, 1867f },
			new float[2] { -1827f, 1837f },
			new float[2] { -1864f, 1821f },
			new float[2] { -1879f, 1783f },
			new float[2] { -1906f, 1751f },
			new float[2] { -1922f, 1693f },
			new float[2] { -1958f, 1645f },
			new float[2] { -1982f, 1580f },
			new float[2] { -2010f, 1522f },
			new float[2] { -2047f, 1482f },
			new float[2] { -2066f, 1443f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(186, "16i", 26, 102, null, new float[32][]
		{
			new float[2] { -2709f, 2134f },
			new float[2] { -2676f, 2102f },
			new float[2] { -2630f, 2074f },
			new float[2] { -2545f, 2053f },
			new float[2] { -2499f, 2026f },
			new float[2] { -2472f, 2013f },
			new float[2] { -2431f, 1990f },
			new float[2] { -2360f, 1977f },
			new float[2] { -2371f, 1998f },
			new float[2] { -2418f, 2007f },
			new float[2] { -2460f, 2045f },
			new float[2] { -2488f, 2087f },
			new float[2] { -2504f, 2145f },
			new float[2] { -2525f, 2168f },
			new float[2] { -2536f, 2240f },
			new float[2] { -2538f, 2283f },
			new float[2] { -2528f, 2323f },
			new float[2] { -2497f, 2383f },
			new float[2] { -2468f, 2434f },
			new float[2] { -2427f, 2469f },
			new float[2] { -2354f, 2555f },
			new float[2] { -2312f, 2609f },
			new float[2] { -2283f, 2693f },
			new float[2] { -2276f, 2753f },
			new float[2] { -2294f, 2815f },
			new float[2] { -2284f, 2860f },
			new float[2] { -2257f, 2906f },
			new float[2] { -2202f, 2936f },
			new float[2] { -2163f, 2974f },
			new float[2] { -2127f, 2989f },
			new float[2] { -2104f, 3025f },
			new float[2] { -2104f, 3096f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(187, "17i", 44, 114, null, new float[27][]
		{
			new float[2] { -2187f, 150f },
			new float[2] { -2178f, 125f },
			new float[2] { -2184f, 82f },
			new float[2] { -2221f, 39f },
			new float[2] { -2234f, 28f },
			new float[2] { -2246f, 0f },
			new float[2] { -2238f, -36f },
			new float[2] { -2218f, -54f },
			new float[2] { -2203f, -84f },
			new float[2] { -2206f, -129f },
			new float[2] { -2157f, -234f },
			new float[2] { -2147f, -261f },
			new float[2] { -2164f, -317f },
			new float[2] { -2152f, -338f },
			new float[2] { -2162f, -393f },
			new float[2] { -2175f, -416f },
			new float[2] { -2266f, -455f },
			new float[2] { -2322f, -497f },
			new float[2] { -2353f, -505f },
			new float[2] { -2434f, -510f },
			new float[2] { -2486f, -532f },
			new float[2] { -2530f, -632f },
			new float[2] { -2550f, -695f },
			new float[2] { -2548f, -753f },
			new float[2] { -2468f, -863f },
			new float[2] { -2508f, -945f },
			new float[2] { -2518f, -987f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(188, "18i", 17, 44, null, new float[9][]
		{
			new float[2] { -2442f, -17f },
			new float[2] { -2361f, -20f },
			new float[2] { -2294f, -7f },
			new float[2] { -2246f, 0f },
			new float[2] { -2234f, 28f },
			new float[2] { -2221f, 39f },
			new float[2] { -2184f, 82f },
			new float[2] { -2178f, 125f },
			new float[2] { -2187f, 150f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(189, "19i", 17, 114, null, new float[25][]
		{
			new float[2] { -2442f, -17f },
			new float[2] { -2361f, -20f },
			new float[2] { -2294f, -7f },
			new float[2] { -2246f, 0f },
			new float[2] { -2238f, -36f },
			new float[2] { -2218f, -54f },
			new float[2] { -2203f, -84f },
			new float[2] { -2206f, -129f },
			new float[2] { -2157f, -234f },
			new float[2] { -2147f, -261f },
			new float[2] { -2164f, -317f },
			new float[2] { -2152f, -338f },
			new float[2] { -2162f, -393f },
			new float[2] { -2175f, -416f },
			new float[2] { -2266f, -455f },
			new float[2] { -2322f, -497f },
			new float[2] { -2353f, -505f },
			new float[2] { -2434f, -510f },
			new float[2] { -2486f, -532f },
			new float[2] { -2530f, -632f },
			new float[2] { -2550f, -695f },
			new float[2] { -2548f, -753f },
			new float[2] { -2468f, -863f },
			new float[2] { -2508f, -945f },
			new float[2] { -2518f, -987f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(190, "20i", 56, 63, null, new float[14][]
		{
			new float[2] { -235f, 887f },
			new float[2] { -197f, 920f },
			new float[2] { -170f, 951f },
			new float[2] { -163f, 977f },
			new float[2] { -119f, 1053f },
			new float[2] { -100f, 1162f },
			new float[2] { -98f, 1233f },
			new float[2] { -82f, 1279f },
			new float[2] { -102f, 1323f },
			new float[2] { -122f, 1376f },
			new float[2] { -133f, 1434f },
			new float[2] { -124f, 1472f },
			new float[2] { -74f, 1522f },
			new float[2] { -44f, 1532f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(191, "21i", 31, 63, null, new float[15][]
		{
			new float[2] { 123f, 955f },
			new float[2] { 75f, 988f },
			new float[2] { -9f, 1034f },
			new float[2] { -59f, 1039f },
			new float[2] { -101f, 1038f },
			new float[2] { -119f, 1053f },
			new float[2] { -100f, 1162f },
			new float[2] { -98f, 1233f },
			new float[2] { -82f, 1279f },
			new float[2] { -102f, 1323f },
			new float[2] { -122f, 1376f },
			new float[2] { -133f, 1434f },
			new float[2] { -124f, 1472f },
			new float[2] { -74f, 1522f },
			new float[2] { -44f, 1532f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(192, "22i", 31, 56, null, new float[10][]
		{
			new float[2] { 123f, 955f },
			new float[2] { 75f, 988f },
			new float[2] { -9f, 1034f },
			new float[2] { -59f, 1039f },
			new float[2] { -101f, 1038f },
			new float[2] { -119f, 1053f },
			new float[2] { -163f, 977f },
			new float[2] { -170f, 951f },
			new float[2] { -197f, 920f },
			new float[2] { -235f, 887f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(193, "23i", 81, 82, null, new float[10][]
		{
			new float[2] { 101f, -1049f },
			new float[2] { 102f, -1083f },
			new float[2] { 113f, -1108f },
			new float[2] { 110f, -1146f },
			new float[2] { 94f, -1191f },
			new float[2] { 47f, -1259f },
			new float[2] { 42f, -1288f },
			new float[2] { 29f, -1310f },
			new float[2] { 54f, -1338f },
			new float[2] { 175f, -1377f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(194, "24i", 81, 85, null, new float[13][]
		{
			new float[2] { 101f, -1049f },
			new float[2] { 102f, -1083f },
			new float[2] { 113f, -1108f },
			new float[2] { 110f, -1146f },
			new float[2] { 94f, -1191f },
			new float[2] { 47f, -1259f },
			new float[2] { 42f, -1288f },
			new float[2] { 29f, -1310f },
			new float[2] { -16f, -1347f },
			new float[2] { -69f, -1375f },
			new float[2] { -101f, -1403f },
			new float[2] { -151f, -1459f },
			new float[2] { -179f, -1500f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(195, "25i", 82, 85, null, new float[8][]
		{
			new float[2] { 175f, -1377f },
			new float[2] { 54f, -1338f },
			new float[2] { 29f, -1310f },
			new float[2] { -16f, -1347f },
			new float[2] { -69f, -1375f },
			new float[2] { -101f, -1403f },
			new float[2] { -151f, -1459f },
			new float[2] { -179f, -1500f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(196, "26i", 116, 120, null, new float[8][]
		{
			new float[2] { 1439f, -658f },
			new float[2] { 1380f, -653f },
			new float[2] { 1337f, -639f },
			new float[2] { 1327f, -578f },
			new float[2] { 1303f, -485f },
			new float[2] { 1294f, -430f },
			new float[2] { 1307f, -399f },
			new float[2] { 1311f, -375f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(197, "27i", 116, 118, null, new float[7][]
		{
			new float[2] { 1439f, -658f },
			new float[2] { 1380f, -653f },
			new float[2] { 1337f, -639f },
			new float[2] { 1298f, -706f },
			new float[2] { 1239f, -763f },
			new float[2] { 1174f, -831f },
			new float[2] { 1133f, -864f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(198, "28i", 118, 120, null, new float[10][]
		{
			new float[2] { 1133f, -864f },
			new float[2] { 1174f, -831f },
			new float[2] { 1239f, -763f },
			new float[2] { 1298f, -706f },
			new float[2] { 1337f, -639f },
			new float[2] { 1327f, -578f },
			new float[2] { 1303f, -485f },
			new float[2] { 1294f, -430f },
			new float[2] { 1307f, -399f },
			new float[2] { 1311f, -375f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(199, "29i", 28, 90, null, new float[17][]
		{
			new float[2] { 1146f, -1219f },
			new float[2] { 1156f, -1260f },
			new float[2] { 1143f, -1312f },
			new float[2] { 1134f, -1327f },
			new float[2] { 1094f, -1359f },
			new float[2] { 1093f, -1383f },
			new float[2] { 1072f, -1467f },
			new float[2] { 1072f, -1504f },
			new float[2] { 1039f, -1614f },
			new float[2] { 1013f, -1658f },
			new float[2] { 1000f, -1716f },
			new float[2] { 1001f, -1768f },
			new float[2] { 1044f, -1792f },
			new float[2] { 1155f, -1828f },
			new float[2] { 1254f, -1835f },
			new float[2] { 1330f, -1831f },
			new float[2] { 1364f, -1820f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(200, "30i", 28, 69, null, new float[24][]
		{
			new float[2] { 1146f, -1219f },
			new float[2] { 1156f, -1260f },
			new float[2] { 1143f, -1312f },
			new float[2] { 1134f, -1327f },
			new float[2] { 1094f, -1359f },
			new float[2] { 1093f, -1383f },
			new float[2] { 1072f, -1467f },
			new float[2] { 1072f, -1504f },
			new float[2] { 1039f, -1614f },
			new float[2] { 1013f, -1658f },
			new float[2] { 1000f, -1716f },
			new float[2] { 1001f, -1768f },
			new float[2] { 982f, -1791f },
			new float[2] { 971f, -1831f },
			new float[2] { 995f, -1866f },
			new float[2] { 990f, -1916f },
			new float[2] { 971f, -1942f },
			new float[2] { 968f, -1966f },
			new float[2] { 941f, -2009f },
			new float[2] { 892f, -2065f },
			new float[2] { 831f, -2139f },
			new float[2] { 795f, -2190f },
			new float[2] { 781f, -2239f },
			new float[2] { 745f, -2331f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(201, "31i", 28, 82, null, new float[24][]
		{
			new float[2] { 1146f, -1219f },
			new float[2] { 1156f, -1260f },
			new float[2] { 1143f, -1312f },
			new float[2] { 1134f, -1327f },
			new float[2] { 1094f, -1359f },
			new float[2] { 1093f, -1383f },
			new float[2] { 1072f, -1467f },
			new float[2] { 1072f, -1504f },
			new float[2] { 1039f, -1614f },
			new float[2] { 1013f, -1658f },
			new float[2] { 1000f, -1716f },
			new float[2] { 1001f, -1768f },
			new float[2] { 915f, -1713f },
			new float[2] { 851f, -1680f },
			new float[2] { 790f, -1663f },
			new float[2] { 752f, -1673f },
			new float[2] { 682f, -1667f },
			new float[2] { 625f, -1665f },
			new float[2] { 526f, -1639f },
			new float[2] { 459f, -1637f },
			new float[2] { 353f, -1602f },
			new float[2] { 295f, -1562f },
			new float[2] { 253f, -1526f },
			new float[2] { 218f, -1450f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(202, "32i", 69, 90, null, new float[18][]
		{
			new float[2] { 745f, -2331f },
			new float[2] { 781f, -2239f },
			new float[2] { 795f, -2190f },
			new float[2] { 831f, -2139f },
			new float[2] { 892f, -2065f },
			new float[2] { 941f, -2009f },
			new float[2] { 968f, -1966f },
			new float[2] { 971f, -1942f },
			new float[2] { 990f, -1916f },
			new float[2] { 995f, -1866f },
			new float[2] { 971f, -1831f },
			new float[2] { 982f, -1791f },
			new float[2] { 1001f, -1768f },
			new float[2] { 1044f, -1792f },
			new float[2] { 1155f, -1828f },
			new float[2] { 1254f, -1835f },
			new float[2] { 1330f, -1831f },
			new float[2] { 1364f, -1820f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(203, "33i", 69, 82, null, new float[25][]
		{
			new float[2] { 745f, -2331f },
			new float[2] { 781f, -2239f },
			new float[2] { 795f, -2190f },
			new float[2] { 831f, -2139f },
			new float[2] { 892f, -2065f },
			new float[2] { 941f, -2009f },
			new float[2] { 968f, -1966f },
			new float[2] { 971f, -1942f },
			new float[2] { 990f, -1916f },
			new float[2] { 995f, -1866f },
			new float[2] { 971f, -1831f },
			new float[2] { 982f, -1791f },
			new float[2] { 1001f, -1768f },
			new float[2] { 915f, -1713f },
			new float[2] { 851f, -1680f },
			new float[2] { 790f, -1663f },
			new float[2] { 752f, -1673f },
			new float[2] { 682f, -1667f },
			new float[2] { 625f, -1665f },
			new float[2] { 526f, -1639f },
			new float[2] { 459f, -1637f },
			new float[2] { 353f, -1602f },
			new float[2] { 295f, -1562f },
			new float[2] { 253f, -1526f },
			new float[2] { 218f, -1450f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(204, "34i", 82, 90, null, new float[18][]
		{
			new float[2] { 218f, -1450f },
			new float[2] { 253f, -1526f },
			new float[2] { 295f, -1562f },
			new float[2] { 353f, -1602f },
			new float[2] { 459f, -1637f },
			new float[2] { 526f, -1639f },
			new float[2] { 625f, -1665f },
			new float[2] { 682f, -1667f },
			new float[2] { 752f, -1673f },
			new float[2] { 790f, -1663f },
			new float[2] { 851f, -1680f },
			new float[2] { 915f, -1713f },
			new float[2] { 1001f, -1768f },
			new float[2] { 1044f, -1792f },
			new float[2] { 1155f, -1828f },
			new float[2] { 1254f, -1835f },
			new float[2] { 1330f, -1831f },
			new float[2] { 1364f, -1820f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(205, "35i", 14, 128, null, new float[7][]
		{
			new float[2] { 2357f, -1024f },
			new float[2] { 2324f, -1052f },
			new float[2] { 2315f, -1083f },
			new float[2] { 2295f, -1128f },
			new float[2] { 2267f, -1160f },
			new float[2] { 2224f, -1147f },
			new float[2] { 2131f, -1125f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(206, "36i", 14, 124, null, new float[6][]
		{
			new float[2] { 2357f, -1024f },
			new float[2] { 2324f, -1052f },
			new float[2] { 2315f, -1083f },
			new float[2] { 2295f, -1128f },
			new float[2] { 2267f, -1160f },
			new float[2] { 2393f, -1211f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(207, "37i", 124, 128, null, new float[4][]
		{
			new float[2] { 2393f, -1211f },
			new float[2] { 2267f, -1160f },
			new float[2] { 2224f, -1147f },
			new float[2] { 2131f, -1125f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(208, "38i", 9, 91, null, new float[12][]
		{
			new float[2] { 1924f, -2326f },
			new float[2] { 1924f, -2375f },
			new float[2] { 1910f, -2400f },
			new float[2] { 1935f, -2435f },
			new float[2] { 1940f, -2458f },
			new float[2] { 1969f, -2486f },
			new float[2] { 2025f, -2512f },
			new float[2] { 2091f, -2526f },
			new float[2] { 2121f, -2526f },
			new float[2] { 2171f, -2545f },
			new float[2] { 2252f, -2589f },
			new float[2] { 2273f, -2606f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(209, "39i", 9, 92, null, new float[14][]
		{
			new float[2] { 1924f, -2326f },
			new float[2] { 1924f, -2375f },
			new float[2] { 1910f, -2400f },
			new float[2] { 1886f, -2395f },
			new float[2] { 1859f, -2403f },
			new float[2] { 1830f, -2425f },
			new float[2] { 1816f, -2489f },
			new float[2] { 1821f, -2503f },
			new float[2] { 1803f, -2537f },
			new float[2] { 1756f, -2547f },
			new float[2] { 1718f, -2574f },
			new float[2] { 1715f, -2602f },
			new float[2] { 1711f, -2634f },
			new float[2] { 1750f, -2702f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(210, "40i", 91, 92, null, new float[21][]
		{
			new float[2] { 2273f, -2606f },
			new float[2] { 2252f, -2589f },
			new float[2] { 2171f, -2545f },
			new float[2] { 2121f, -2526f },
			new float[2] { 2091f, -2526f },
			new float[2] { 2025f, -2512f },
			new float[2] { 1969f, -2486f },
			new float[2] { 1940f, -2458f },
			new float[2] { 1935f, -2435f },
			new float[2] { 1910f, -2400f },
			new float[2] { 1886f, -2395f },
			new float[2] { 1859f, -2403f },
			new float[2] { 1830f, -2425f },
			new float[2] { 1816f, -2489f },
			new float[2] { 1821f, -2503f },
			new float[2] { 1803f, -2537f },
			new float[2] { 1756f, -2547f },
			new float[2] { 1718f, -2574f },
			new float[2] { 1715f, -2602f },
			new float[2] { 1711f, -2634f },
			new float[2] { 1750f, -2702f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(211, "41i", 9, 24, null, new float[12][]
		{
			new float[2] { 1927f, -2257f },
			new float[2] { 1881f, -2247f },
			new float[2] { 1818f, -2248f },
			new float[2] { 1755f, -2258f },
			new float[2] { 1729f, -2250f },
			new float[2] { 1703f, -2230f },
			new float[2] { 1712f, -2220f },
			new float[2] { 1752f, -2167f },
			new float[2] { 1767f, -2120f },
			new float[2] { 1760f, -2059f },
			new float[2] { 1757f, -1958f },
			new float[2] { 1747f, -1932f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(212, "42i", 9, 87, null, new float[5][]
		{
			new float[2] { 1786f, -2261f },
			new float[2] { 1733f, -2256f },
			new float[2] { 1705f, -2234f },
			new float[2] { 1644f, -2300f },
			new float[2] { 1589f, -2365f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(213, "43i", 24, 87, null, new float[6][]
		{
			new float[2] { 1756f, -1976f },
			new float[2] { 1756f, -2067f },
			new float[2] { 1763f, -2120f },
			new float[2] { 1754f, -2158f },
			new float[2] { 1710f, -2218f },
			new float[2] { 1630f, -2304f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(214, "44i", 47, 50, null, new float[11][]
		{
			new float[2] { -980f, -2190f },
			new float[2] { -1027f, -2177f },
			new float[2] { -1084f, -2169f },
			new float[2] { -1146f, -2160f },
			new float[2] { -1200f, -2162f },
			new float[2] { -1257f, -2169f },
			new float[2] { -1313f, -2164f },
			new float[2] { -1361f, -2142f },
			new float[2] { -1399f, -2127f },
			new float[2] { -1449f, -2058f },
			new float[2] { -1449f, -2026f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(215, "45i", 3, 47, null, new float[12][]
		{
			new float[2] { -1085f, -1865f },
			new float[2] { -1083f, -1899f },
			new float[2] { -1089f, -1920f },
			new float[2] { -1085f, -1945f },
			new float[2] { -1100f, -1983f },
			new float[2] { -1126f, -2031f },
			new float[2] { -1143f, -2099f },
			new float[2] { -1147f, -2131f },
			new float[2] { -1146f, -2160f },
			new float[2] { -1084f, -2169f },
			new float[2] { -1027f, -2177f },
			new float[2] { -980f, -2190f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(216, "46i", 3, 50, null, new float[16][]
		{
			new float[2] { -1085f, -1865f },
			new float[2] { -1083f, -1899f },
			new float[2] { -1089f, -1920f },
			new float[2] { -1085f, -1945f },
			new float[2] { -1100f, -1983f },
			new float[2] { -1126f, -2031f },
			new float[2] { -1143f, -2099f },
			new float[2] { -1147f, -2131f },
			new float[2] { -1146f, -2160f },
			new float[2] { -1200f, -2162f },
			new float[2] { -1257f, -2169f },
			new float[2] { -1313f, -2164f },
			new float[2] { -1361f, -2142f },
			new float[2] { -1399f, -2127f },
			new float[2] { -1449f, -2058f },
			new float[2] { -1449f, -2026f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(217, "47i", 101, 102, null, new float[38][]
		{
			new float[2] { -1780f, 2308f },
			new float[2] { -1758f, 2282f },
			new float[2] { -1757f, 2252f },
			new float[2] { -1739f, 2181f },
			new float[2] { -1754f, 2138f },
			new float[2] { -1734f, 2065f },
			new float[2] { -1727f, 1985f },
			new float[2] { -1751f, 1939f },
			new float[2] { -1801f, 1896f },
			new float[2] { -1841f, 1862f },
			new float[2] { -1918f, 1849f },
			new float[2] { -2032f, 1854f },
			new float[2] { -2123f, 1878f },
			new float[2] { -2170f, 1897f },
			new float[2] { -2220f, 1935f },
			new float[2] { -2263f, 1955f },
			new float[2] { -2337f, 1978f },
			new float[2] { -2369f, 2000f },
			new float[2] { -2398f, 2006f },
			new float[2] { -2443f, 2024f },
			new float[2] { -2490f, 2086f },
			new float[2] { -2499f, 2125f },
			new float[2] { -2530f, 2180f },
			new float[2] { -2541f, 2287f },
			new float[2] { -2516f, 2362f },
			new float[2] { -2469f, 2435f },
			new float[2] { -2428f, 2472f },
			new float[2] { -2407f, 2502f },
			new float[2] { -2381f, 2528f },
			new float[2] { -2320f, 2597f },
			new float[2] { -2291f, 2665f },
			new float[2] { -2278f, 2758f },
			new float[2] { -2290f, 2795f },
			new float[2] { -2290f, 2839f },
			new float[2] { -2260f, 2908f },
			new float[2] { -2196f, 2945f },
			new float[2] { -2130f, 2994f },
			new float[2] { -2106f, 3038f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(218, "48i", 102, 103, null, new float[29][]
		{
			new float[2] { -2106f, 3038f },
			new float[2] { -2130f, 2994f },
			new float[2] { -2196f, 2945f },
			new float[2] { -2260f, 2908f },
			new float[2] { -2290f, 2839f },
			new float[2] { -2290f, 2795f },
			new float[2] { -2278f, 2758f },
			new float[2] { -2291f, 2665f },
			new float[2] { -2320f, 2597f },
			new float[2] { -2381f, 2528f },
			new float[2] { -2407f, 2502f },
			new float[2] { -2428f, 2472f },
			new float[2] { -2469f, 2435f },
			new float[2] { -2516f, 2362f },
			new float[2] { -2541f, 2287f },
			new float[2] { -2530f, 2180f },
			new float[2] { -2499f, 2125f },
			new float[2] { -2490f, 2086f },
			new float[2] { -2443f, 2024f },
			new float[2] { -2398f, 2006f },
			new float[2] { -2369f, 2000f },
			new float[2] { -2337f, 1978f },
			new float[2] { -2263f, 1955f },
			new float[2] { -2220f, 1935f },
			new float[2] { -2170f, 1897f },
			new float[2] { -2123f, 1878f },
			new float[2] { -2032f, 1854f },
			new float[2] { -1918f, 1849f },
			new float[2] { -1841f, 1862f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(219, "49i", 102, 106, null, new float[43][]
		{
			new float[2] { -2104f, 3096f },
			new float[2] { -2104f, 3025f },
			new float[2] { -2127f, 2989f },
			new float[2] { -2163f, 2974f },
			new float[2] { -2202f, 2936f },
			new float[2] { -2257f, 2906f },
			new float[2] { -2284f, 2860f },
			new float[2] { -2294f, 2815f },
			new float[2] { -2276f, 2753f },
			new float[2] { -2283f, 2693f },
			new float[2] { -2312f, 2609f },
			new float[2] { -2354f, 2555f },
			new float[2] { -2427f, 2469f },
			new float[2] { -2468f, 2434f },
			new float[2] { -2497f, 2383f },
			new float[2] { -2528f, 2323f },
			new float[2] { -2538f, 2283f },
			new float[2] { -2536f, 2240f },
			new float[2] { -2525f, 2168f },
			new float[2] { -2504f, 2145f },
			new float[2] { -2488f, 2087f },
			new float[2] { -2460f, 2045f },
			new float[2] { -2418f, 2007f },
			new float[2] { -2371f, 1998f },
			new float[2] { -2360f, 1977f },
			new float[2] { -2247f, 1949f },
			new float[2] { -2204f, 1917f },
			new float[2] { -2149f, 1883f },
			new float[2] { -2037f, 1854f },
			new float[2] { -1962f, 1851f },
			new float[2] { -1913f, 1848f },
			new float[2] { -1844f, 1855f },
			new float[2] { -1790f, 1867f },
			new float[2] { -1827f, 1837f },
			new float[2] { -1864f, 1821f },
			new float[2] { -1879f, 1783f },
			new float[2] { -1906f, 1751f },
			new float[2] { -1922f, 1693f },
			new float[2] { -1958f, 1645f },
			new float[2] { -1982f, 1580f },
			new float[2] { -2010f, 1522f },
			new float[2] { -2047f, 1482f },
			new float[2] { -2066f, 1443f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(220, "50i", 26, 103, null, new float[11][]
		{
			new float[2] { -2631f, 2073f },
			new float[2] { -2567f, 2060f },
			new float[2] { -2497f, 2028f },
			new float[2] { -2437f, 1989f },
			new float[2] { -2333f, 1975f },
			new float[2] { -2238f, 1944f },
			new float[2] { -2145f, 1881f },
			new float[2] { -2048f, 1851f },
			new float[2] { -1979f, 1847f },
			new float[2] { -1889f, 1844f },
			new float[2] { -1829f, 1861f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(221, "51i", 26, 101, null, new float[28][]
		{
			new float[2] { -2709f, 2134f },
			new float[2] { -2676f, 2102f },
			new float[2] { -2630f, 2074f },
			new float[2] { -2545f, 2053f },
			new float[2] { -2499f, 2026f },
			new float[2] { -2472f, 2013f },
			new float[2] { -2431f, 1990f },
			new float[2] { -2360f, 1977f },
			new float[2] { -2247f, 1949f },
			new float[2] { -2204f, 1917f },
			new float[2] { -2149f, 1883f },
			new float[2] { -2037f, 1854f },
			new float[2] { -1962f, 1851f },
			new float[2] { -1913f, 1848f },
			new float[2] { -1844f, 1855f },
			new float[2] { -1790f, 1867f },
			new float[2] { -1798f, 1895f },
			new float[2] { -1760f, 1927f },
			new float[2] { -1732f, 1971f },
			new float[2] { -1723f, 1999f },
			new float[2] { -1736f, 2073f },
			new float[2] { -1752f, 2133f },
			new float[2] { -1741f, 2175f },
			new float[2] { -1750f, 2246f },
			new float[2] { -1754f, 2275f },
			new float[2] { -1774f, 2303f },
			new float[2] { -1765f, 2350f },
			new float[2] { -1746f, 2365f }
		}, null, null));
		_dataArray.Add(new MapRouteItem(222, "52i", 26, 106, null, new float[26][]
		{
			new float[2] { -2709f, 2134f },
			new float[2] { -2676f, 2102f },
			new float[2] { -2630f, 2074f },
			new float[2] { -2545f, 2053f },
			new float[2] { -2499f, 2026f },
			new float[2] { -2472f, 2013f },
			new float[2] { -2431f, 1990f },
			new float[2] { -2360f, 1977f },
			new float[2] { -2247f, 1949f },
			new float[2] { -2204f, 1917f },
			new float[2] { -2149f, 1883f },
			new float[2] { -2037f, 1854f },
			new float[2] { -1962f, 1851f },
			new float[2] { -1913f, 1848f },
			new float[2] { -1844f, 1855f },
			new float[2] { -1790f, 1867f },
			new float[2] { -1827f, 1837f },
			new float[2] { -1864f, 1821f },
			new float[2] { -1879f, 1783f },
			new float[2] { -1906f, 1751f },
			new float[2] { -1922f, 1693f },
			new float[2] { -1958f, 1645f },
			new float[2] { -1982f, 1580f },
			new float[2] { -2010f, 1522f },
			new float[2] { -2047f, 1482f },
			new float[2] { -2066f, 1443f }
		}, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapRouteItem>(223);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
	}
}
