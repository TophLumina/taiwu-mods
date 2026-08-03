using System.Collections.Generic;

namespace GameData.Domains.Organization;

public class SettlementCreatingInfo
{
	private readonly List<short> _villageRandomNameIds;

	private short _nextVillageRandomNameIndex;

	private readonly List<short> _townRandomNameIds;

	private short _nextTownRandomNameIndex;

	private readonly List<short> _walledTownRandomNameIds;

	private short _nextWalledTownRandomNameIndex;

	public SettlementCreatingInfo(List<short> villageRandomNameIds, List<short> townRandomNameIds, List<short> walledTownRandomNameIds)
	{
		_villageRandomNameIds = villageRandomNameIds;
		_nextVillageRandomNameIndex = 0;
		_townRandomNameIds = townRandomNameIds;
		_nextTownRandomNameIndex = 0;
		_walledTownRandomNameIds = walledTownRandomNameIds;
		_nextWalledTownRandomNameIndex = 0;
	}

	public short GenerateRandomName(sbyte orgTemplateId)
	{
		switch (orgTemplateId)
		{
		case 36:
		{
			short index3 = _nextVillageRandomNameIndex;
			_nextVillageRandomNameIndex++;
			return _villageRandomNameIds[index3];
		}
		case 37:
		{
			short index2 = _nextTownRandomNameIndex;
			_nextTownRandomNameIndex++;
			return _townRandomNameIds[index2];
		}
		case 38:
		{
			short index = _nextWalledTownRandomNameIndex;
			_nextWalledTownRandomNameIndex++;
			return _walledTownRandomNameIds[index];
		}
		default:
			return -1;
		}
	}
}
