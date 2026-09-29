using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSectPunishItem : ConfigItem<SecretInformationSectPunishItem, short>
{
	public readonly short TemplateId;

	public readonly List<ShortList> ActorSectPunishFreeCondition;

	public readonly List<ShortList> ActorSectPunishCondition;

	public readonly List<ShortList> ActorSectPunishBase;

	public readonly List<ShortList> ActorSectPunishSpecialCondition;

	public readonly List<ShortList> ActorSectPunishSpecial;

	public readonly List<ShortList> ReactorSectPunishFreeCondition;

	public readonly List<ShortList> ReactorSectPunishCondition;

	public readonly List<ShortList> ReactorSectPunishBase;

	public readonly List<ShortList> ReactorSectPunishSpecialCondition;

	public readonly List<ShortList> ReactorSectPunishSpecial;

	public readonly List<ShortList> SecactorSectPunishFreeCondition;

	public readonly List<ShortList> SecactorSectPunishCondition;

	public readonly List<ShortList> SecactorSectPunishBase;

	public readonly List<ShortList> SecactorSectPunishSpecialCondition;

	public readonly List<ShortList> SecactorSectPunishSpecial;

	public readonly List<ShortList> ActorCityPunishFreeCondition;

	public readonly List<ShortList> ActorCityPunishCondition;

	public readonly List<ShortList> ActorCityPunishBase;

	public readonly List<ShortList> ActorCityPunishSpecialCondition;

	public readonly List<ShortList> ActorCityPunishSpecial;

	public readonly List<ShortList> ReactorCityPunishFreeCondition;

	public readonly List<ShortList> ReactorCityPunishCondition;

	public readonly List<ShortList> ReactorCityPunishBase;

	public readonly List<ShortList> ReactorCityPunishSpecialCondition;

	public readonly List<ShortList> ReactorCityPunishSpecial;

	public readonly List<ShortList> SecactorCityPunishFreeCondition;

	public readonly List<ShortList> SecactorCityPunishCondition;

	public readonly List<ShortList> SecactorCityPunishBase;

	public readonly List<ShortList> SecactorCityPunishSpecialCondition;

	public readonly List<ShortList> SecactorCityPunishSpecial;

	public readonly List<ShortList> ActorTaiwuPunishFreeCondition;

	public readonly List<ShortList> ActorTaiwuPunishCondition;

	public readonly List<ShortList> ActorTaiwuPunishBase;

	public readonly List<ShortList> ActorTaiwuPunishSpecialCondition;

	public readonly List<ShortList> ActorTaiwuPunishSpecial;

	public readonly List<ShortList> ReactorTaiwuPunishFreeCondition;

	public readonly List<ShortList> ReactorTaiwuPunishCondition;

	public readonly List<ShortList> ReactorTaiwuPunishBase;

	public readonly List<ShortList> ReactorTaiwuPunishSpecialCondition;

	public readonly List<ShortList> ReactorTaiwuPunishSpecial;

	public readonly List<ShortList> SecactorTaiwuPunishFreeCondition;

	public readonly List<ShortList> SecactorTaiwuPunishCondition;

	public readonly List<ShortList> SecactorTaiwuPunishBase;

	public readonly List<ShortList> SecactorTaiwuPunishSpecialCondition;

	public readonly List<ShortList> SecactorTaiwuPunishSpecial;

	public SecretInformationSectPunishItem(short templateId, List<ShortList> actorSectPunishFreeCondition, List<ShortList> actorSectPunishCondition, List<ShortList> actorSectPunishBase, List<ShortList> actorSectPunishSpecialCondition, List<ShortList> actorSectPunishSpecial, List<ShortList> reactorSectPunishFreeCondition, List<ShortList> reactorSectPunishCondition, List<ShortList> reactorSectPunishBase, List<ShortList> reactorSectPunishSpecialCondition, List<ShortList> reactorSectPunishSpecial, List<ShortList> secactorSectPunishFreeCondition, List<ShortList> secactorSectPunishCondition, List<ShortList> secactorSectPunishBase, List<ShortList> secactorSectPunishSpecialCondition, List<ShortList> secactorSectPunishSpecial, List<ShortList> actorCityPunishFreeCondition, List<ShortList> actorCityPunishCondition, List<ShortList> actorCityPunishBase, List<ShortList> actorCityPunishSpecialCondition, List<ShortList> actorCityPunishSpecial, List<ShortList> reactorCityPunishFreeCondition, List<ShortList> reactorCityPunishCondition, List<ShortList> reactorCityPunishBase, List<ShortList> reactorCityPunishSpecialCondition, List<ShortList> reactorCityPunishSpecial, List<ShortList> secactorCityPunishFreeCondition, List<ShortList> secactorCityPunishCondition, List<ShortList> secactorCityPunishBase, List<ShortList> secactorCityPunishSpecialCondition, List<ShortList> secactorCityPunishSpecial, List<ShortList> actorTaiwuPunishFreeCondition, List<ShortList> actorTaiwuPunishCondition, List<ShortList> actorTaiwuPunishBase, List<ShortList> actorTaiwuPunishSpecialCondition, List<ShortList> actorTaiwuPunishSpecial, List<ShortList> reactorTaiwuPunishFreeCondition, List<ShortList> reactorTaiwuPunishCondition, List<ShortList> reactorTaiwuPunishBase, List<ShortList> reactorTaiwuPunishSpecialCondition, List<ShortList> reactorTaiwuPunishSpecial, List<ShortList> secactorTaiwuPunishFreeCondition, List<ShortList> secactorTaiwuPunishCondition, List<ShortList> secactorTaiwuPunishBase, List<ShortList> secactorTaiwuPunishSpecialCondition, List<ShortList> secactorTaiwuPunishSpecial)
	{
		TemplateId = templateId;
		ActorSectPunishFreeCondition = actorSectPunishFreeCondition;
		ActorSectPunishCondition = actorSectPunishCondition;
		ActorSectPunishBase = actorSectPunishBase;
		ActorSectPunishSpecialCondition = actorSectPunishSpecialCondition;
		ActorSectPunishSpecial = actorSectPunishSpecial;
		ReactorSectPunishFreeCondition = reactorSectPunishFreeCondition;
		ReactorSectPunishCondition = reactorSectPunishCondition;
		ReactorSectPunishBase = reactorSectPunishBase;
		ReactorSectPunishSpecialCondition = reactorSectPunishSpecialCondition;
		ReactorSectPunishSpecial = reactorSectPunishSpecial;
		SecactorSectPunishFreeCondition = secactorSectPunishFreeCondition;
		SecactorSectPunishCondition = secactorSectPunishCondition;
		SecactorSectPunishBase = secactorSectPunishBase;
		SecactorSectPunishSpecialCondition = secactorSectPunishSpecialCondition;
		SecactorSectPunishSpecial = secactorSectPunishSpecial;
		ActorCityPunishFreeCondition = actorCityPunishFreeCondition;
		ActorCityPunishCondition = actorCityPunishCondition;
		ActorCityPunishBase = actorCityPunishBase;
		ActorCityPunishSpecialCondition = actorCityPunishSpecialCondition;
		ActorCityPunishSpecial = actorCityPunishSpecial;
		ReactorCityPunishFreeCondition = reactorCityPunishFreeCondition;
		ReactorCityPunishCondition = reactorCityPunishCondition;
		ReactorCityPunishBase = reactorCityPunishBase;
		ReactorCityPunishSpecialCondition = reactorCityPunishSpecialCondition;
		ReactorCityPunishSpecial = reactorCityPunishSpecial;
		SecactorCityPunishFreeCondition = secactorCityPunishFreeCondition;
		SecactorCityPunishCondition = secactorCityPunishCondition;
		SecactorCityPunishBase = secactorCityPunishBase;
		SecactorCityPunishSpecialCondition = secactorCityPunishSpecialCondition;
		SecactorCityPunishSpecial = secactorCityPunishSpecial;
		ActorTaiwuPunishFreeCondition = actorTaiwuPunishFreeCondition;
		ActorTaiwuPunishCondition = actorTaiwuPunishCondition;
		ActorTaiwuPunishBase = actorTaiwuPunishBase;
		ActorTaiwuPunishSpecialCondition = actorTaiwuPunishSpecialCondition;
		ActorTaiwuPunishSpecial = actorTaiwuPunishSpecial;
		ReactorTaiwuPunishFreeCondition = reactorTaiwuPunishFreeCondition;
		ReactorTaiwuPunishCondition = reactorTaiwuPunishCondition;
		ReactorTaiwuPunishBase = reactorTaiwuPunishBase;
		ReactorTaiwuPunishSpecialCondition = reactorTaiwuPunishSpecialCondition;
		ReactorTaiwuPunishSpecial = reactorTaiwuPunishSpecial;
		SecactorTaiwuPunishFreeCondition = secactorTaiwuPunishFreeCondition;
		SecactorTaiwuPunishCondition = secactorTaiwuPunishCondition;
		SecactorTaiwuPunishBase = secactorTaiwuPunishBase;
		SecactorTaiwuPunishSpecialCondition = secactorTaiwuPunishSpecialCondition;
		SecactorTaiwuPunishSpecial = secactorTaiwuPunishSpecial;
	}

	public SecretInformationSectPunishItem()
	{
		TemplateId = 0;
		ActorSectPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorSectPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorSectPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ActorSectPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorSectPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		ReactorSectPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorSectPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorSectPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ReactorSectPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorSectPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		SecactorSectPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorSectPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorSectPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		SecactorSectPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorSectPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		ActorCityPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorCityPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorCityPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ActorCityPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorCityPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		ReactorCityPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorCityPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorCityPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ReactorCityPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorCityPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		SecactorCityPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorCityPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorCityPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		SecactorCityPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorCityPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		ActorTaiwuPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorTaiwuPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorTaiwuPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ActorTaiwuPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorTaiwuPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		ReactorTaiwuPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorTaiwuPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorTaiwuPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		ReactorTaiwuPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorTaiwuPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
		SecactorTaiwuPunishFreeCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorTaiwuPunishCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorTaiwuPunishBase = new List<ShortList>
		{
			new ShortList()
		};
		SecactorTaiwuPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorTaiwuPunishSpecial = new List<ShortList>
		{
			new ShortList()
		};
	}

	public SecretInformationSectPunishItem(short templateId, SecretInformationSectPunishItem other)
	{
		TemplateId = templateId;
		ActorSectPunishFreeCondition = other.ActorSectPunishFreeCondition;
		ActorSectPunishCondition = other.ActorSectPunishCondition;
		ActorSectPunishBase = other.ActorSectPunishBase;
		ActorSectPunishSpecialCondition = other.ActorSectPunishSpecialCondition;
		ActorSectPunishSpecial = other.ActorSectPunishSpecial;
		ReactorSectPunishFreeCondition = other.ReactorSectPunishFreeCondition;
		ReactorSectPunishCondition = other.ReactorSectPunishCondition;
		ReactorSectPunishBase = other.ReactorSectPunishBase;
		ReactorSectPunishSpecialCondition = other.ReactorSectPunishSpecialCondition;
		ReactorSectPunishSpecial = other.ReactorSectPunishSpecial;
		SecactorSectPunishFreeCondition = other.SecactorSectPunishFreeCondition;
		SecactorSectPunishCondition = other.SecactorSectPunishCondition;
		SecactorSectPunishBase = other.SecactorSectPunishBase;
		SecactorSectPunishSpecialCondition = other.SecactorSectPunishSpecialCondition;
		SecactorSectPunishSpecial = other.SecactorSectPunishSpecial;
		ActorCityPunishFreeCondition = other.ActorCityPunishFreeCondition;
		ActorCityPunishCondition = other.ActorCityPunishCondition;
		ActorCityPunishBase = other.ActorCityPunishBase;
		ActorCityPunishSpecialCondition = other.ActorCityPunishSpecialCondition;
		ActorCityPunishSpecial = other.ActorCityPunishSpecial;
		ReactorCityPunishFreeCondition = other.ReactorCityPunishFreeCondition;
		ReactorCityPunishCondition = other.ReactorCityPunishCondition;
		ReactorCityPunishBase = other.ReactorCityPunishBase;
		ReactorCityPunishSpecialCondition = other.ReactorCityPunishSpecialCondition;
		ReactorCityPunishSpecial = other.ReactorCityPunishSpecial;
		SecactorCityPunishFreeCondition = other.SecactorCityPunishFreeCondition;
		SecactorCityPunishCondition = other.SecactorCityPunishCondition;
		SecactorCityPunishBase = other.SecactorCityPunishBase;
		SecactorCityPunishSpecialCondition = other.SecactorCityPunishSpecialCondition;
		SecactorCityPunishSpecial = other.SecactorCityPunishSpecial;
		ActorTaiwuPunishFreeCondition = other.ActorTaiwuPunishFreeCondition;
		ActorTaiwuPunishCondition = other.ActorTaiwuPunishCondition;
		ActorTaiwuPunishBase = other.ActorTaiwuPunishBase;
		ActorTaiwuPunishSpecialCondition = other.ActorTaiwuPunishSpecialCondition;
		ActorTaiwuPunishSpecial = other.ActorTaiwuPunishSpecial;
		ReactorTaiwuPunishFreeCondition = other.ReactorTaiwuPunishFreeCondition;
		ReactorTaiwuPunishCondition = other.ReactorTaiwuPunishCondition;
		ReactorTaiwuPunishBase = other.ReactorTaiwuPunishBase;
		ReactorTaiwuPunishSpecialCondition = other.ReactorTaiwuPunishSpecialCondition;
		ReactorTaiwuPunishSpecial = other.ReactorTaiwuPunishSpecial;
		SecactorTaiwuPunishFreeCondition = other.SecactorTaiwuPunishFreeCondition;
		SecactorTaiwuPunishCondition = other.SecactorTaiwuPunishCondition;
		SecactorTaiwuPunishBase = other.SecactorTaiwuPunishBase;
		SecactorTaiwuPunishSpecialCondition = other.SecactorTaiwuPunishSpecialCondition;
		SecactorTaiwuPunishSpecial = other.SecactorTaiwuPunishSpecial;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationSectPunishItem Duplicate(int templateId)
	{
		return new SecretInformationSectPunishItem((short)templateId, this);
	}
}
