using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSectPunishItem : ConfigItem<SecretInformationSectPunishItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 免罪条件
	/// - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号
	/// </summary>
	public readonly List<ShortList> ActorSectPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// - 触发基础处罚的条件
	/// </summary>
	public readonly List<ShortList> ActorSectPunishCondition;

	/// <summary>
	/// 基础处罚
	/// - 满足条件后的基础处罚，数量不可少于前面的条件
	/// </summary>
	public readonly List<ShortList> ActorSectPunishBase;

	/// <summary>
	/// 特殊条件
	/// - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。
	/// </summary>
	public readonly List<ShortList> ActorSectPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// - 满足条件后的特殊处罚，数量不可少于前面的条件
	/// </summary>
	public readonly List<ShortList> ActorSectPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> ReactorSectPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> ReactorSectPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> ReactorSectPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> ReactorSectPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> ReactorSectPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> SecactorSectPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> SecactorSectPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> SecactorSectPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> SecactorSectPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> SecactorSectPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号
	/// </summary>
	public readonly List<ShortList> ActorCityPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> ActorCityPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> ActorCityPunishBase;

	/// <summary>
	/// 特殊条件
	/// - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。
	/// </summary>
	public readonly List<ShortList> ActorCityPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// - 满足条件后的特殊处罚，数量不可少于前面的条件
	/// </summary>
	public readonly List<ShortList> ActorCityPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> ReactorCityPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> ReactorCityPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> ReactorCityPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> ReactorCityPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> ReactorCityPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> SecactorCityPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> SecactorCityPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> SecactorCityPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> SecactorCityPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> SecactorCityPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号
	/// </summary>
	public readonly List<ShortList> ActorTaiwuPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> ActorTaiwuPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> ActorTaiwuPunishBase;

	/// <summary>
	/// 特殊条件
	/// - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。
	/// </summary>
	public readonly List<ShortList> ActorTaiwuPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// - 满足条件后的特殊处罚，数量不可少于前面的条件
	/// </summary>
	public readonly List<ShortList> ActorTaiwuPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> ReactorTaiwuPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> ReactorTaiwuPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> ReactorTaiwuPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> ReactorTaiwuPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> ReactorTaiwuPunishSpecial;

	/// <summary>
	/// 免罪条件
	/// </summary>
	public readonly List<ShortList> SecactorTaiwuPunishFreeCondition;

	/// <summary>
	/// 基础处罚条件
	/// </summary>
	public readonly List<ShortList> SecactorTaiwuPunishCondition;

	/// <summary>
	/// 基础处罚
	/// </summary>
	public readonly List<ShortList> SecactorTaiwuPunishBase;

	/// <summary>
	/// 特殊条件
	/// </summary>
	public readonly List<ShortList> SecactorTaiwuPunishSpecialCondition;

	/// <summary>
	/// 特殊处罚
	/// </summary>
	public readonly List<ShortList> SecactorTaiwuPunishSpecial;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="actorSectPunishFreeCondition">免罪条件 - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号</param>
	/// <param name="actorSectPunishCondition">基础处罚条件 - 触发基础处罚的条件</param>
	/// <param name="actorSectPunishBase">基础处罚 - 满足条件后的基础处罚，数量不可少于前面的条件</param>
	/// <param name="actorSectPunishSpecialCondition">特殊条件 - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。</param>
	/// <param name="actorSectPunishSpecial">特殊处罚 - 满足条件后的特殊处罚，数量不可少于前面的条件</param>
	/// <param name="reactorSectPunishFreeCondition">免罪条件</param>
	/// <param name="reactorSectPunishCondition">基础处罚条件</param>
	/// <param name="reactorSectPunishBase">基础处罚</param>
	/// <param name="reactorSectPunishSpecialCondition">特殊条件</param>
	/// <param name="reactorSectPunishSpecial">特殊处罚</param>
	/// <param name="secactorSectPunishFreeCondition">免罪条件</param>
	/// <param name="secactorSectPunishCondition">基础处罚条件</param>
	/// <param name="secactorSectPunishBase">基础处罚</param>
	/// <param name="secactorSectPunishSpecialCondition">特殊条件</param>
	/// <param name="secactorSectPunishSpecial">特殊处罚</param>
	/// <param name="actorCityPunishFreeCondition">免罪条件 - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号</param>
	/// <param name="actorCityPunishCondition">基础处罚条件</param>
	/// <param name="actorCityPunishBase">基础处罚</param>
	/// <param name="actorCityPunishSpecialCondition">特殊条件 - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。</param>
	/// <param name="actorCityPunishSpecial">特殊处罚 - 满足条件后的特殊处罚，数量不可少于前面的条件</param>
	/// <param name="reactorCityPunishFreeCondition">免罪条件</param>
	/// <param name="reactorCityPunishCondition">基础处罚条件</param>
	/// <param name="reactorCityPunishBase">基础处罚</param>
	/// <param name="reactorCityPunishSpecialCondition">特殊条件</param>
	/// <param name="reactorCityPunishSpecial">特殊处罚</param>
	/// <param name="secactorCityPunishFreeCondition">免罪条件</param>
	/// <param name="secactorCityPunishCondition">基础处罚条件</param>
	/// <param name="secactorCityPunishBase">基础处罚</param>
	/// <param name="secactorCityPunishSpecialCondition">特殊条件</param>
	/// <param name="secactorCityPunishSpecial">特殊处罚</param>
	/// <param name="actorTaiwuPunishFreeCondition">免罪条件 - 满足此条件可最高优先级地免除门派处罚，有多个条件时只要满足其一就可以免罪。不支持逻辑符号</param>
	/// <param name="actorTaiwuPunishCondition">基础处罚条件</param>
	/// <param name="actorTaiwuPunishBase">基础处罚</param>
	/// <param name="actorTaiwuPunishSpecialCondition">特殊条件 - {{条件1，关联人1},{条件2,关联人2}}特殊条件与后面的特殊处罚一一对应，越靠前的优先级越高。</param>
	/// <param name="actorTaiwuPunishSpecial">特殊处罚 - 满足条件后的特殊处罚，数量不可少于前面的条件</param>
	/// <param name="reactorTaiwuPunishFreeCondition">免罪条件</param>
	/// <param name="reactorTaiwuPunishCondition">基础处罚条件</param>
	/// <param name="reactorTaiwuPunishBase">基础处罚</param>
	/// <param name="reactorTaiwuPunishSpecialCondition">特殊条件</param>
	/// <param name="reactorTaiwuPunishSpecial">特殊处罚</param>
	/// <param name="secactorTaiwuPunishFreeCondition">免罪条件</param>
	/// <param name="secactorTaiwuPunishCondition">基础处罚条件</param>
	/// <param name="secactorTaiwuPunishBase">基础处罚</param>
	/// <param name="secactorTaiwuPunishSpecialCondition">特殊条件</param>
	/// <param name="secactorTaiwuPunishSpecial">特殊处罚</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationSectPunishItem Duplicate(int templateId)
	{
		return new SecretInformationSectPunishItem((short)templateId, this);
	}
}
