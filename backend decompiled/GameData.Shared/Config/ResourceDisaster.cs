using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceDisaster : ConfigData<ResourceDisasterItem, short>
{
	public static ResourceDisaster Instance = new ResourceDisaster();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TargetId", "ResourceType", "TemplateId" };

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
		_dataArray.Add(new ResourceDisasterItem(0, 406288043, 0));
		_dataArray.Add(new ResourceDisasterItem(1, 383994052, 1));
		_dataArray.Add(new ResourceDisasterItem(2, 260426491, 2));
		_dataArray.Add(new ResourceDisasterItem(3, 356503645, 3));
		_dataArray.Add(new ResourceDisasterItem(4, 463508467, 4));
		_dataArray.Add(new ResourceDisasterItem(5, 340190737, 5));
		_dataArray.Add(new ResourceDisasterItem(6, 413227228, 5));
		_dataArray.Add(new ResourceDisasterItem(7, 420244548, 5));
		_dataArray.Add(new ResourceDisasterItem(8, 452476079, 5));
		_dataArray.Add(new ResourceDisasterItem(9, 270813483, 5));
		_dataArray.Add(new ResourceDisasterItem(10, 437143835, 5));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ResourceDisasterItem>(11);
		CreateItems0();
	}
}
