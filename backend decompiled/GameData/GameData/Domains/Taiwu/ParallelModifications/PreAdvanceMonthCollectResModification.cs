using System;
using System.Collections.Generic;

namespace GameData.Domains.Taiwu.ParallelModifications;

public class PreAdvanceMonthCollectResModification
{
	public int GetFood;

	public int GetWood;

	public int GetMetal;

	public int GetJade;

	public int GetFabric;

	public int GetHerb;

	public int GetMoney;

	public int GetAuthority;

	public List<(short, short, int)> AddBlockMalice;

	public PreAdvanceMonthCollectResModification()
	{
		AddBlockMalice = new List<(short, short, int)>();
	}

	public void AddResource(sbyte resourceType, int count)
	{
		switch (resourceType)
		{
		case 0:
			GetFood += count;
			break;
		case 1:
			GetWood += count;
			break;
		case 2:
			GetMetal += count;
			break;
		case 3:
			GetJade += count;
			break;
		case 4:
			GetFabric += count;
			break;
		case 5:
			GetHerb += count;
			break;
		case 6:
			GetMoney += count;
			break;
		case 7:
			GetAuthority += count;
			break;
		default:
			throw new Exception($"Unsupported resourceType: {resourceType}");
		}
	}

	public int GetResource(sbyte resourceType)
	{
		if (1 == 0)
		{
		}
		int result = resourceType switch
		{
			0 => GetFood, 
			1 => GetWood, 
			2 => GetMetal, 
			3 => GetJade, 
			4 => GetFabric, 
			5 => GetHerb, 
			6 => GetMoney, 
			7 => GetAuthority, 
			_ => throw new Exception($"Unsupported resourceType: {resourceType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
