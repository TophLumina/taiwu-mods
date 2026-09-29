using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SuccessorOfXiangshu : ConfigData<SuccessorOfXiangshuItem, sbyte>
{
	public static SuccessorOfXiangshu Instance = new SuccessorOfXiangshu();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "MapState", "Character", "CharacterFeature", "TemplateId" };

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
		_dataArray.Add(new SuccessorOfXiangshuItem(0, 1, new short[9] { 1348, 1363, 1364, 1365, 1366, 1367, 1368, 1369, 1370 }, 905));
		_dataArray.Add(new SuccessorOfXiangshuItem(1, 2, new short[9] { 1349, 1371, 1372, 1373, 1374, 1375, 1376, 1377, 1378 }, 929));
		_dataArray.Add(new SuccessorOfXiangshuItem(2, 3, new short[9] { 1350, 1379, 1380, 1381, 1382, 1383, 1384, 1385, 1386 }, 930));
		_dataArray.Add(new SuccessorOfXiangshuItem(3, 4, new short[9] { 1351, 1387, 1388, 1389, 1390, 1391, 1392, 1393, 1394 }, 931));
		_dataArray.Add(new SuccessorOfXiangshuItem(4, 5, new short[9] { 1352, 1395, 1396, 1397, 1398, 1399, 1400, 1401, 1402 }, 932));
		_dataArray.Add(new SuccessorOfXiangshuItem(5, 6, new short[9] { 1353, 1403, 1404, 1405, 1406, 1407, 1408, 1409, 1410 }, 933));
		_dataArray.Add(new SuccessorOfXiangshuItem(6, 7, new short[9] { 1354, 1411, 1412, 1413, 1414, 1415, 1416, 1417, 1418 }, 934));
		_dataArray.Add(new SuccessorOfXiangshuItem(7, 8, new short[9] { 1355, 1419, 1420, 1421, 1422, 1423, 1424, 1425, 1426 }, 935));
		_dataArray.Add(new SuccessorOfXiangshuItem(8, 9, new short[9] { 1356, 1427, 1428, 1429, 1430, 1431, 1432, 1433, 1434 }, 936));
		_dataArray.Add(new SuccessorOfXiangshuItem(9, 10, new short[9] { 1357, 1435, 1436, 1437, 1438, 1439, 1440, 1441, 1442 }, 937));
		_dataArray.Add(new SuccessorOfXiangshuItem(10, 11, new short[9] { 1358, 1443, 1444, 1445, 1446, 1447, 1448, 1449, 1450 }, 938));
		_dataArray.Add(new SuccessorOfXiangshuItem(11, 12, new short[9] { 1359, 1451, 1452, 1453, 1454, 1455, 1456, 1457, 1458 }, 939));
		_dataArray.Add(new SuccessorOfXiangshuItem(12, 13, new short[9] { 1360, 1459, 1460, 1461, 1462, 1463, 1464, 1465, 1466 }, 940));
		_dataArray.Add(new SuccessorOfXiangshuItem(13, 14, new short[9] { 1361, 1467, 1468, 1469, 1470, 1471, 1472, 1473, 1474 }, 941));
		_dataArray.Add(new SuccessorOfXiangshuItem(14, 15, new short[9] { 1362, 1475, 1476, 1477, 1478, 1479, 1480, 1481, 1482 }, 942));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SuccessorOfXiangshuItem>(15);
		CreateItems0();
	}
}
