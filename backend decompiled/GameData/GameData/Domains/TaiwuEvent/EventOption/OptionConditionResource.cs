using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionResource : TaiwuEventOptionConditionBase
{
	public readonly sbyte _resourceType;

	public readonly int _count;

	private Func<sbyte, int, bool> _conditionMatcher;

	private readonly string[] ResourceTypeName = new string[8] { "LK_Resource_Name_Food", "LK_Resource_Name_Wood", "LK_Resource_Name_Metal", "LK_Resource_Name_Jade", "LK_Resource_Name_Fabric", "LK_Resource_Name_Herb", "LK_Resource_Name_Money", "LK_Resource_Name_Authority" };

	public OptionConditionResource(short id, sbyte resourceType, int count, Func<sbyte, int, bool> conditionMatcher)
		: base(id)
	{
		_resourceType = resourceType;
		_count = count;
		_conditionMatcher = conditionMatcher;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		return _conditionMatcher(_resourceType, _count);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[2]
		{
			"<Language Key=" + ResourceTypeName[_resourceType] + "/>",
			_count.ToString()
		});
	}
}
