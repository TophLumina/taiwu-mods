using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.World;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

/// <summary>
/// 模板数据相关辅助方法
/// </summary>
public static class ItemTemplateHelper
{
	/// <summary>
	/// 道具品级比较
	/// </summary>
	public static IComparer<ItemKey> ItemGradeComparer = Comparer<ItemKey>.Create(CompareItemByGrade);

	/// <summary>
	/// 获得模板数据所有 Keys
	/// </summary>
	public static IList<int> GetTemplateDataAllKeys(sbyte itemType)
	{
		return itemType switch
		{
			0 => new List<int>(((IEnumerable<short>)Weapon.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			1 => new List<int>(((IEnumerable<short>)Armor.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			2 => new List<int>(((IEnumerable<short>)Accessory.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			3 => new List<int>(((IEnumerable<short>)Clothing.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			4 => new List<int>(((IEnumerable<short>)Carrier.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			5 => new List<int>(((IEnumerable<short>)Material.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			6 => new List<int>(((IEnumerable<short>)CraftTool.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			7 => new List<int>(((IEnumerable<short>)Food.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			8 => new List<int>(((IEnumerable<short>)Medicine.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			9 => new List<int>(((IEnumerable<short>)TeaWine.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			10 => new List<int>(((IEnumerable<short>)SkillBook.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			11 => new List<int>(((IEnumerable<short>)Cricket.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			12 => new List<int>(((IEnumerable<short>)Misc.Instance.GetAllKeys()).Select((Func<short, int>)((short id) => id))), 
			_ => null, 
		};
	}

	/// <summary>
	/// 检测指定模板是否可用
	/// </summary>
	/// <param name="itemType">物品类型</param>
	/// <param name="templateId">对应物品类型下的模板ID</param>
	/// <returns>该物品配置是否存在</returns>
	public static bool CheckTemplateValid(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId] != null, 
			1 => Armor.Instance[templateId] != null, 
			2 => Accessory.Instance[templateId] != null, 
			3 => Clothing.Instance[templateId] != null, 
			4 => Carrier.Instance[templateId] != null, 
			5 => Material.Instance[templateId] != null, 
			6 => CraftTool.Instance[templateId] != null, 
			7 => Food.Instance[templateId] != null, 
			8 => Medicine.Instance[templateId] != null, 
			9 => TeaWine.Instance[templateId] != null, 
			10 => SkillBook.Instance[templateId] != null, 
			11 => Cricket.Instance[templateId] != null, 
			12 => Misc.Instance[templateId] != null, 
			_ => false, 
		};
	}

	/// <summary>
	/// 获取物品名
	/// </summary>
	public static string GetName(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Name, 
			1 => Armor.Instance[templateId].Name, 
			2 => Accessory.Instance[templateId].Name, 
			3 => Clothing.Instance[templateId].Name, 
			4 => Carrier.Instance[templateId].Name, 
			5 => Material.Instance[templateId].Name, 
			6 => CraftTool.Instance[templateId].Name, 
			7 => Food.Instance[templateId].Name, 
			8 => Medicine.Instance[templateId].Name, 
			9 => TeaWine.Instance[templateId].Name, 
			10 => SkillBook.Instance[templateId].Name, 
			11 => Cricket.Instance[templateId].Name, 
			12 => Misc.Instance[templateId].Name, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品在战斗中使用时的效果
	/// </summary>
	public static short GetItemCombatUseEffect(sbyte itemType, short itemTemplateId)
	{
		return itemType switch
		{
			8 => Medicine.Instance[itemTemplateId].CombatUseEffect, 
			12 => Misc.Instance[itemTemplateId].CombatUseEffect, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取物品在战斗准备阶段使用时的效果
	/// </summary>
	public static short GetItemCombatPrepareEffect(sbyte itemType, short itemTemplateId)
	{
		return itemType switch
		{
			8 => Medicine.Instance[itemTemplateId].CombatPrepareUseEffect, 
			12 => Misc.Instance[itemTemplateId].CombatPrepareUseEffect, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取物品子类
	/// </summary>
	public static short GetItemSubType(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].ItemSubType, 
			1 => Armor.Instance[templateId].ItemSubType, 
			2 => Accessory.Instance[templateId].ItemSubType, 
			3 => Clothing.Instance[templateId].ItemSubType, 
			4 => Carrier.Instance[templateId].ItemSubType, 
			5 => Material.Instance[templateId].ItemSubType, 
			6 => CraftTool.Instance[templateId].ItemSubType, 
			7 => Food.Instance[templateId].ItemSubType, 
			8 => Medicine.Instance[templateId].ItemSubType, 
			9 => TeaWine.Instance[templateId].ItemSubType, 
			10 => SkillBook.Instance[templateId].ItemSubType, 
			11 => Cricket.Instance[templateId].ItemSubType, 
			12 => Misc.Instance[templateId].ItemSubType, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品品级
	/// </summary>
	public static sbyte GetGrade(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Grade, 
			1 => Armor.Instance[templateId].Grade, 
			2 => Accessory.Instance[templateId].Grade, 
			3 => Clothing.Instance[templateId].Grade, 
			4 => Carrier.Instance[templateId].Grade, 
			5 => Material.Instance[templateId].Grade, 
			6 => CraftTool.Instance[templateId].Grade, 
			7 => Food.Instance[templateId].Grade, 
			8 => Medicine.Instance[templateId].Grade, 
			9 => TeaWine.Instance[templateId].Grade, 
			10 => SkillBook.Instance[templateId].Grade, 
			11 => Cricket.Instance[templateId].Grade, 
			12 => Misc.Instance[templateId].Grade, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取道具玄机效果引用
	/// </summary>
	public static sbyte GetBreakBonusEffect(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			5 => Material.Instance[templateId].BreakBonusEffect, 
			7 => Food.Instance[templateId].BreakBonusEffect, 
			8 => Medicine.Instance[templateId].BreakBonusEffect, 
			9 => TeaWine.Instance[templateId].BreakBonusEffect, 
			10 => SkillBook.Instance[templateId].BreakBonusEffect, 
			12 => Misc.Instance[templateId].BreakBonusEffect, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取促织品级
	/// </summary>
	public static sbyte GetCricketGrade(short colorId, short partId)
	{
		if (partId > 0)
		{
			CricketPartsItem cricketPartsItem = CricketParts.Instance[colorId];
			return Math.Max(val2: CricketParts.Instance[partId].Level, val1: cricketPartsItem.Level);
		}
		return CricketParts.Instance[colorId].Level;
	}

	/// <summary>
	/// 获取所属分组
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
	public static short GetGroupId(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].GroupId, 
			1 => Armor.Instance[templateId].GroupId, 
			2 => Accessory.Instance[templateId].GroupId, 
			3 => Clothing.Instance[templateId].GroupId, 
			4 => Carrier.Instance[templateId].GroupId, 
			5 => Material.Instance[templateId].GroupId, 
			6 => CraftTool.Instance[templateId].GroupId, 
			7 => Food.Instance[templateId].GroupId, 
			8 => Medicine.Instance[templateId].GroupId, 
			9 => TeaWine.Instance[templateId].GroupId, 
			10 => SkillBook.Instance[templateId].GroupId, 
			11 => Cricket.Instance[templateId].GroupId, 
			12 => Misc.Instance[templateId].GroupId, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品图标
	/// </summary>
	public static string GetIcon(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Icon, 
			1 => Armor.Instance[templateId].Icon, 
			2 => Accessory.Instance[templateId].Icon, 
			3 => Clothing.Instance[templateId].Icon, 
			4 => Carrier.Instance[templateId].Icon, 
			5 => Material.Instance[templateId].Icon, 
			6 => CraftTool.Instance[templateId].Icon, 
			7 => Food.Instance[templateId].Icon, 
			8 => Medicine.Instance[templateId].Icon, 
			9 => TeaWine.Instance[templateId].Icon, 
			10 => SkillBook.Instance[templateId].Icon, 
			11 => Cricket.Instance[templateId].Icon, 
			12 => Misc.Instance[templateId].Icon, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品描述
	/// </summary>
	public static string GetDesc(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Desc, 
			1 => Armor.Instance[templateId].Desc, 
			2 => Accessory.Instance[templateId].Desc, 
			3 => Clothing.Instance[templateId].Desc, 
			4 => Carrier.Instance[templateId].Desc, 
			5 => Material.Instance[templateId].Desc, 
			6 => CraftTool.Instance[templateId].Desc, 
			7 => Food.Instance[templateId].Desc, 
			8 => Medicine.Instance[templateId].Desc, 
			9 => TeaWine.Instance[templateId].Desc, 
			10 => SkillBook.Instance[templateId].Desc, 
			11 => Cricket.Instance[templateId].Desc, 
			12 => Misc.Instance[templateId].Desc, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品功能描述
	/// </summary>
	public static string GetFunctionDesc(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].FunctionDesc, 
			1 => Armor.Instance[templateId].FunctionDesc, 
			2 => Accessory.Instance[templateId].FunctionDesc, 
			3 => Clothing.Instance[templateId].FunctionDesc, 
			4 => Carrier.Instance[templateId].FunctionDesc, 
			5 => Material.Instance[templateId].FunctionDesc, 
			6 => CraftTool.Instance[templateId].FunctionDesc, 
			7 => Food.Instance[templateId].FunctionDesc, 
			8 => Medicine.Instance[templateId].FunctionDesc, 
			9 => TeaWine.Instance[templateId].FunctionDesc, 
			10 => SkillBook.Instance[templateId].FunctionDesc, 
			11 => string.Empty, 
			12 => Misc.Instance[templateId].FunctionDesc, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 道具是否允许交易.
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool AllowTrade(sbyte itemType, short templateId)
	{
		if (IsMiscResource(itemType, templateId))
		{
			return true;
		}
		if (!IsTransferable(itemType, templateId))
		{
			return false;
		}
		if (itemType == 12 && templateId == 267)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 获取物品是否可让渡
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsTransferable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Transferable, 
			1 => Armor.Instance[templateId].Transferable, 
			2 => Accessory.Instance[templateId].Transferable, 
			3 => Clothing.Instance[templateId].Transferable, 
			4 => Carrier.Instance[templateId].Transferable, 
			5 => Material.Instance[templateId].Transferable, 
			6 => CraftTool.Instance[templateId].Transferable, 
			7 => Food.Instance[templateId].Transferable, 
			8 => Medicine.Instance[templateId].Transferable, 
			9 => TeaWine.Instance[templateId].Transferable, 
			10 => SkillBook.Instance[templateId].Transferable, 
			11 => Cricket.Instance[templateId].Transferable, 
			12 => Misc.Instance[templateId].Transferable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可堆叠
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsStackable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Stackable, 
			1 => Armor.Instance[templateId].Stackable, 
			2 => Accessory.Instance[templateId].Stackable, 
			3 => Clothing.Instance[templateId].Stackable, 
			4 => Carrier.Instance[templateId].Stackable, 
			5 => Material.Instance[templateId].Stackable, 
			6 => CraftTool.Instance[templateId].Stackable, 
			7 => Food.Instance[templateId].Stackable, 
			8 => Medicine.Instance[templateId].Stackable, 
			9 => TeaWine.Instance[templateId].Stackable, 
			10 => SkillBook.Instance[templateId].Stackable, 
			11 => Cricket.Instance[templateId].Stackable, 
			12 => Misc.Instance[templateId].Stackable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可押注
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsWagerable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Wagerable, 
			1 => Armor.Instance[templateId].Wagerable, 
			2 => Accessory.Instance[templateId].Wagerable, 
			3 => Clothing.Instance[templateId].Wagerable, 
			4 => Carrier.Instance[templateId].Wagerable, 
			5 => Material.Instance[templateId].Wagerable, 
			6 => CraftTool.Instance[templateId].Wagerable, 
			7 => Food.Instance[templateId].Wagerable, 
			8 => Medicine.Instance[templateId].Wagerable, 
			9 => TeaWine.Instance[templateId].Wagerable, 
			10 => SkillBook.Instance[templateId].Wagerable, 
			11 => Cricket.Instance[templateId].Wagerable, 
			12 => Misc.Instance[templateId].Wagerable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可精制
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsRefinable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Refinable, 
			1 => Armor.Instance[templateId].Refinable, 
			2 => Accessory.Instance[templateId].Refinable, 
			3 => Clothing.Instance[templateId].Refinable, 
			4 => Carrier.Instance[templateId].Refinable, 
			5 => Material.Instance[templateId].Refinable, 
			6 => CraftTool.Instance[templateId].Refinable, 
			7 => Food.Instance[templateId].Refinable, 
			8 => Medicine.Instance[templateId].Refinable, 
			9 => TeaWine.Instance[templateId].Refinable, 
			10 => SkillBook.Instance[templateId].Refinable, 
			11 => Cricket.Instance[templateId].Refinable, 
			12 => Misc.Instance[templateId].Refinable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可下毒
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsPoisonable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Poisonable, 
			1 => Armor.Instance[templateId].Poisonable, 
			2 => Accessory.Instance[templateId].Poisonable, 
			3 => Clothing.Instance[templateId].Poisonable, 
			4 => Carrier.Instance[templateId].Poisonable, 
			5 => Material.Instance[templateId].Poisonable, 
			6 => CraftTool.Instance[templateId].Poisonable, 
			7 => Food.Instance[templateId].Poisonable, 
			8 => Medicine.Instance[templateId].Poisonable, 
			9 => TeaWine.Instance[templateId].Poisonable, 
			10 => SkillBook.Instance[templateId].Poisonable, 
			11 => Cricket.Instance[templateId].Poisonable, 
			12 => Misc.Instance[templateId].Poisonable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可修理 (同时控制是否会在耐久耗尽时自动销毁)
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsRepairable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Repairable, 
			1 => Armor.Instance[templateId].Repairable, 
			2 => Accessory.Instance[templateId].Repairable, 
			3 => Clothing.Instance[templateId].Repairable, 
			4 => Carrier.Instance[templateId].Repairable, 
			5 => Material.Instance[templateId].Repairable, 
			6 => CraftTool.Instance[templateId].Repairable, 
			7 => Food.Instance[templateId].Repairable, 
			8 => Medicine.Instance[templateId].Repairable, 
			9 => TeaWine.Instance[templateId].Repairable, 
			10 => SkillBook.Instance[templateId].Repairable, 
			11 => Cricket.Instance[templateId].Repairable, 
			12 => Misc.Instance[templateId].Repairable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品是否可继承（梦回时跨存档继承）
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsInheritable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Inheritable, 
			1 => Armor.Instance[templateId].Inheritable, 
			2 => Accessory.Instance[templateId].Inheritable, 
			3 => Clothing.Instance[templateId].Inheritable, 
			4 => Carrier.Instance[templateId].Inheritable, 
			5 => Material.Instance[templateId].Inheritable, 
			6 => CraftTool.Instance[templateId].Inheritable, 
			7 => Food.Instance[templateId].Inheritable, 
			8 => Medicine.Instance[templateId].Inheritable, 
			9 => TeaWine.Instance[templateId].Inheritable, 
			10 => SkillBook.Instance[templateId].Inheritable, 
			11 => Cricket.Instance[templateId].Inheritable, 
			12 => Misc.Instance[templateId].Inheritable, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <inheritdoc cref="M:GameData.Domains.Item.ItemTemplateHelper.CanUseMultiple(System.SByte,System.Int16)" />
	public static bool CanUseMultiple(ItemKey itemKey)
	{
		return CanUseMultiple(itemKey.ItemType, itemKey.TemplateId);
	}

	/// <summary>
	/// 获取物品是否可复数使用
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanUseMultiple(sbyte itemType, short templateId)
	{
		if (itemType == 8)
		{
			return Medicine.Instance[templateId].CanUseMultiple;
		}
		return true;
	}

	/// <summary>
	/// 获取物品的基础重量
	/// </summary>
	public static int GetBaseWeight(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].BaseWeight, 
			1 => Armor.Instance[templateId].BaseWeight, 
			2 => Accessory.Instance[templateId].BaseWeight, 
			3 => Clothing.Instance[templateId].BaseWeight, 
			4 => Carrier.Instance[templateId].BaseWeight, 
			5 => Material.Instance[templateId].BaseWeight, 
			6 => CraftTool.Instance[templateId].BaseWeight, 
			7 => Food.Instance[templateId].BaseWeight, 
			8 => Medicine.Instance[templateId].BaseWeight, 
			9 => TeaWine.Instance[templateId].BaseWeight, 
			10 => SkillBook.Instance[templateId].BaseWeight, 
			11 => Cricket.Instance[templateId].BaseWeight, 
			12 => Misc.Instance[templateId].BaseWeight, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品的基础价值
	/// </summary>
	public static int GetBaseValue(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].BaseValue, 
			1 => Armor.Instance[templateId].BaseValue, 
			2 => Accessory.Instance[templateId].BaseValue, 
			3 => Clothing.Instance[templateId].BaseValue, 
			4 => Carrier.Instance[templateId].BaseValue, 
			5 => Material.Instance[templateId].BaseValue, 
			6 => CraftTool.Instance[templateId].BaseValue, 
			7 => Food.Instance[templateId].BaseValue, 
			8 => Medicine.Instance[templateId].BaseValue, 
			9 => TeaWine.Instance[templateId].BaseValue, 
			10 => SkillBook.Instance[templateId].BaseValue, 
			11 => Cricket.Instance[templateId].BaseValue, 
			12 => Misc.Instance[templateId].BaseValue, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品让渡后的心情变化
	/// </summary>
	public static sbyte GetBaseHappinessChange(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].BaseHappinessChange, 
			1 => Armor.Instance[templateId].BaseHappinessChange, 
			2 => Accessory.Instance[templateId].BaseHappinessChange, 
			3 => Clothing.Instance[templateId].BaseHappinessChange, 
			4 => Carrier.Instance[templateId].BaseHappinessChange, 
			5 => Material.Instance[templateId].BaseHappinessChange, 
			6 => CraftTool.Instance[templateId].BaseHappinessChange, 
			7 => Food.Instance[templateId].BaseHappinessChange, 
			8 => Medicine.Instance[templateId].BaseHappinessChange, 
			9 => TeaWine.Instance[templateId].BaseHappinessChange, 
			10 => SkillBook.Instance[templateId].BaseHappinessChange, 
			11 => Cricket.Instance[templateId].BaseHappinessChange, 
			12 => Misc.Instance[templateId].BaseHappinessChange, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品让渡后的好感变化
	/// </summary>
	public static int GetBaseFavorabilityChange(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].BaseFavorabilityChange, 
			1 => Armor.Instance[templateId].BaseFavorabilityChange, 
			2 => Accessory.Instance[templateId].BaseFavorabilityChange, 
			3 => Clothing.Instance[templateId].BaseFavorabilityChange, 
			4 => Carrier.Instance[templateId].BaseFavorabilityChange, 
			5 => Material.Instance[templateId].BaseFavorabilityChange, 
			6 => CraftTool.Instance[templateId].BaseFavorabilityChange, 
			7 => Food.Instance[templateId].BaseFavorabilityChange, 
			8 => Medicine.Instance[templateId].BaseFavorabilityChange, 
			9 => TeaWine.Instance[templateId].BaseFavorabilityChange, 
			10 => SkillBook.Instance[templateId].BaseFavorabilityChange, 
			11 => Cricket.Instance[templateId].BaseFavorabilityChange, 
			12 => Misc.Instance[templateId].BaseFavorabilityChange, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品的掉落率
	/// </summary>
	public static sbyte GetDropRate(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].DropRate, 
			1 => Armor.Instance[templateId].DropRate, 
			2 => Accessory.Instance[templateId].DropRate, 
			3 => Clothing.Instance[templateId].DropRate, 
			4 => Carrier.Instance[templateId].DropRate, 
			5 => Material.Instance[templateId].DropRate, 
			6 => CraftTool.Instance[templateId].DropRate, 
			7 => Food.Instance[templateId].DropRate, 
			8 => Medicine.Instance[templateId].DropRate, 
			9 => TeaWine.Instance[templateId].DropRate, 
			10 => SkillBook.Instance[templateId].DropRate, 
			11 => Cricket.Instance[templateId].DropRate, 
			12 => Misc.Instance[templateId].DropRate, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品的材质 (对应的资源类型)
	/// </summary>
	public static sbyte GetResourceType(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].ResourceType, 
			1 => Armor.Instance[templateId].ResourceType, 
			2 => Accessory.Instance[templateId].ResourceType, 
			3 => Clothing.Instance[templateId].ResourceType, 
			4 => Carrier.Instance[templateId].ResourceType, 
			5 => Material.Instance[templateId].ResourceType, 
			6 => CraftTool.Instance[templateId].ResourceType, 
			7 => Food.Instance[templateId].ResourceType, 
			8 => Medicine.Instance[templateId].ResourceType, 
			9 => TeaWine.Instance[templateId].ResourceType, 
			10 => SkillBook.Instance[templateId].ResourceType, 
			11 => Cricket.Instance[templateId].ResourceType, 
			12 => Misc.Instance[templateId].ResourceType, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取无主物品的可保存时间
	/// </summary>
	public static short GetPreservationDuration(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].PreservationDuration, 
			1 => Armor.Instance[templateId].PreservationDuration, 
			2 => Accessory.Instance[templateId].PreservationDuration, 
			3 => Clothing.Instance[templateId].PreservationDuration, 
			4 => Carrier.Instance[templateId].PreservationDuration, 
			5 => Material.Instance[templateId].PreservationDuration, 
			6 => CraftTool.Instance[templateId].PreservationDuration, 
			7 => Food.Instance[templateId].PreservationDuration, 
			8 => Medicine.Instance[templateId].PreservationDuration, 
			9 => TeaWine.Instance[templateId].PreservationDuration, 
			10 => SkillBook.Instance[templateId].PreservationDuration, 
			11 => Cricket.Instance[templateId].PreservationDuration, 
			12 => Misc.Instance[templateId].PreservationDuration, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品的最大耐久
	/// </summary>
	public static short GetBaseMaxDurability(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].MaxDurability, 
			1 => Armor.Instance[templateId].MaxDurability, 
			2 => Accessory.Instance[templateId].MaxDurability, 
			3 => Clothing.Instance[templateId].MaxDurability, 
			4 => Carrier.Instance[templateId].MaxDurability, 
			5 => Material.Instance[templateId].MaxDurability, 
			6 => CraftTool.Instance[templateId].MaxDurability, 
			7 => Food.Instance[templateId].MaxDurability, 
			8 => Medicine.Instance[templateId].MaxDurability, 
			9 => TeaWine.Instance[templateId].MaxDurability, 
			10 => SkillBook.Instance[templateId].MaxDurability, 
			11 => Cricket.Instance[templateId].MaxDurability, 
			12 => Misc.Instance[templateId].MaxDurability, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取物品的礼物等级
	/// </summary>
	/// <param name="itemType">物品类型</param>
	/// <param name="templateId">物品模板id</param>
	/// <returns>物品的礼物品级</returns>
	public static sbyte GetGiftLevel(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].GiftLevel, 
			1 => Armor.Instance[templateId].GiftLevel, 
			2 => Accessory.Instance[templateId].GiftLevel, 
			3 => Clothing.Instance[templateId].GiftLevel, 
			4 => Carrier.Instance[templateId].GiftLevel, 
			5 => Material.Instance[templateId].GiftLevel, 
			6 => CraftTool.Instance[templateId].GiftLevel, 
			7 => Food.Instance[templateId].GiftLevel, 
			8 => Medicine.Instance[templateId].GiftLevel, 
			9 => TeaWine.Instance[templateId].GiftLevel, 
			10 => SkillBook.Instance[templateId].GiftLevel, 
			11 => 8, 
			12 => Misc.Instance[templateId].GiftLevel, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 从指定道具组中获取预期品级的道具
	/// </summary>
	public static short GetTemplateIdInGroup(sbyte itemType, short groupBeginId, sbyte expectedGrade)
	{
		short templateId = groupBeginId;
		sbyte currGrade = GetGrade(itemType, templateId);
		while (currGrade < expectedGrade)
		{
			short nextTemplateId = (short)(templateId + 1);
			sbyte nextGrade = GetGrade(itemType, nextTemplateId);
			if (nextGrade <= currGrade || nextGrade > expectedGrade || GetGroupId(itemType, nextTemplateId) != groupBeginId)
			{
				break;
			}
			currGrade = nextGrade;
			templateId = nextTemplateId;
		}
		return templateId;
	}

	/// <summary>
	/// 获取物品的商店等级
	/// </summary>
	public static sbyte GetMerchantLevel(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].MerchantLevel, 
			1 => Armor.Instance[templateId].MerchantLevel, 
			2 => Accessory.Instance[templateId].MerchantLevel, 
			3 => Clothing.Instance[templateId].MerchantLevel, 
			4 => Carrier.Instance[templateId].MerchantLevel, 
			5 => Material.Instance[templateId].MerchantLevel, 
			6 => CraftTool.Instance[templateId].MerchantLevel, 
			7 => Food.Instance[templateId].MerchantLevel, 
			8 => Medicine.Instance[templateId].MerchantLevel, 
			9 => TeaWine.Instance[templateId].MerchantLevel, 
			10 => SkillBook.Instance[templateId].MerchantLevel, 
			11 => Cricket.Instance[templateId].MerchantLevel, 
			12 => Misc.Instance[templateId].MerchantLevel, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 判断是否为特殊道具
	/// </summary>
	public static bool IsSpecial(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].IsSpecial, 
			1 => Armor.Instance[templateId].IsSpecial, 
			2 => Accessory.Instance[templateId].IsSpecial, 
			3 => Clothing.Instance[templateId].IsSpecial, 
			4 => Carrier.Instance[templateId].IsSpecial, 
			5 => Material.Instance[templateId].IsSpecial, 
			6 => CraftTool.Instance[templateId].IsSpecial, 
			7 => Food.Instance[templateId].IsSpecial, 
			8 => Medicine.Instance[templateId].IsSpecial, 
			9 => TeaWine.Instance[templateId].IsSpecial, 
			10 => SkillBook.Instance[templateId].IsSpecial, 
			11 => Cricket.Instance[templateId].IsSpecial, 
			12 => Misc.Instance[templateId].IsSpecial, 
			_ => throw CreateItemTypeException(itemType), 
		};
	}

	/// <summary>
	/// 获取装备类型
	/// </summary>
	public static int GetEquipmentType(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].EquipmentType, 
			1 => Armor.Instance[templateId].EquipmentType, 
			2 => Accessory.Instance[templateId].EquipmentType, 
			3 => Clothing.Instance[templateId].EquipmentType, 
			4 => Carrier.Instance[templateId].EquipmentType, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取装备是否可从装备栏中卸下
	/// 通常的使用方式为：itemData.UsingType != ItemDisplayData.ItemUsingType.Equiped || ItemTemplateHelper.IsDetachable(itemData.Key.ItemType, itemData.Key.TemplateId)
	/// </summary>
	public static bool IsDetachable(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].Detachable, 
			1 => Armor.Instance[templateId].Detachable, 
			2 => Accessory.Instance[templateId].Detachable, 
			3 => Clothing.Instance[templateId].Detachable, 
			4 => Carrier.Instance[templateId].Detachable, 
			_ => true, 
		};
	}

	/// <summary>
	/// 获得计算制造材料后该装备的基础属性百分比
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="itemType"></param>
	/// <param name="equipmentBonusType"></param>
	/// <param name="materialResources"></param>
	/// <returns></returns>
	public unsafe static int GetMaterialResourceBonusValuePercentage(sbyte itemType, short templateId, sbyte equipmentBonusType, MaterialResources materialResources)
	{
		short makeItemSubType = GetEquipmentMakeItemSubType(itemType, templateId);
		if (makeItemSubType < 0)
		{
			return 100;
		}
		MakeItemSubTypeItem makeItemSubTypeCfg = MakeItemSubType.Instance[makeItemSubType];
		if (makeItemSubTypeCfg.WoodEffect == equipmentBonusType && makeItemSubTypeCfg.MaxMaterialResources.Items[1] > 0)
		{
			return CalcMaterialResourceBonusPercentage(materialResources, makeItemSubTypeCfg.MaxMaterialResources, 1);
		}
		if (makeItemSubTypeCfg.MetalEffect == equipmentBonusType && makeItemSubTypeCfg.MaxMaterialResources.Items[2] > 0)
		{
			return CalcMaterialResourceBonusPercentage(materialResources, makeItemSubTypeCfg.MaxMaterialResources, 2);
		}
		if (makeItemSubTypeCfg.JadeEffect == equipmentBonusType && makeItemSubTypeCfg.MaxMaterialResources.Items[3] > 0)
		{
			return CalcMaterialResourceBonusPercentage(materialResources, makeItemSubTypeCfg.MaxMaterialResources, 3);
		}
		if (makeItemSubTypeCfg.FabricEffect == equipmentBonusType && makeItemSubTypeCfg.MaxMaterialResources.Items[4] > 0)
		{
			return CalcMaterialResourceBonusPercentage(materialResources, makeItemSubTypeCfg.MaxMaterialResources, 4);
		}
		return 100;
	}

	private unsafe static int CalcMaterialResourceBonusPercentage(MaterialResources resources, MaterialResources maxResources, sbyte resourceType)
	{
		return 70 + 30 * resources.Items[resourceType] / maxResources.Items[resourceType];
	}

	/// <summary>
	/// 获取一个装备的基础战力值（乘GlobalConfig.EquipmentSlotCombatPower对应项之后除以100为真实战力）
	/// </summary>
	/// <param name="equipment"></param>
	/// <returns>配置表中Grade字段的数值乘其对应的EquipmentCombatPowerValueFactor</returns>
	public static int GetBaseCombatPowerValue(sbyte itemType, short templateId)
	{
		switch (itemType)
		{
		case 0:
		{
			WeaponItem item2 = Weapon.Instance[templateId];
			return (item2 != null) ? ((item2.Grade + 1) * item2.EquipmentCombatPowerValueFactor) : 0;
		}
		case 1:
		{
			ArmorItem item4 = Armor.Instance[templateId];
			return (item4 != null) ? ((item4.Grade + 1) * item4.EquipmentCombatPowerValueFactor) : 0;
		}
		case 3:
		{
			ClothingItem item3 = Clothing.Instance[templateId];
			return (item3 != null) ? ((item3.Grade + 1) * item3.EquipmentCombatPowerValueFactor) : 0;
		}
		case 2:
		{
			AccessoryItem item5 = Accessory.Instance[templateId];
			return (item5 != null) ? ((item5.Grade + 1) * item5.EquipmentCombatPowerValueFactor) : 0;
		}
		case 4:
		{
			CarrierItem item = Carrier.Instance[templateId];
			return (item != null) ? ((item.Grade + 1) * item.EquipmentCombatPowerValueFactor) : 0;
		}
		default:
			return 0;
		}
	}

	/// <summary>
	/// 获取指定装备的制造物品子类 <see cref="T:Config.MakeItemSubTypeItem" />
	/// </summary>
	public static short GetEquipmentMakeItemSubType(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].MakeItemSubType, 
			1 => Armor.Instance[templateId].MakeItemSubType, 
			2 => Accessory.Instance[templateId].MakeItemSubType, 
			3 => Clothing.Instance[templateId].MakeItemSubType, 
			4 => Carrier.Instance[templateId].MakeItemSubType, 
			_ => throw new Exception($"item type {itemType} is not equipment."), 
		};
	}

	/// <summary>
	/// 获取物品的制造物品子类 <see cref="T:Config.MakeItemSubTypeItem" />
	/// </summary>
	public static short GetMakeItemSubType(sbyte itemType, short templateId)
	{
		if (ItemType.IsEquipmentItemType(itemType))
		{
			return GetEquipmentMakeItemSubType(itemType, templateId);
		}
		if (itemType == 12)
		{
			return Misc.Instance[templateId].MakeItemSubType;
		}
		if (itemType == 7)
		{
			FoodItem foodConfig = Food.Instance[templateId];
			MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance.FirstOrDefault((MakeItemSubTypeItem m) => m.Result.ItemType == itemType && m.Result.TemplateId == foodConfig.GroupId);
			if (makeItemSubTypeConfig != null)
			{
				return makeItemSubTypeConfig.TemplateId;
			}
		}
		if (itemType == 8)
		{
			MedicineItem medicineConfig = Medicine.Instance[templateId];
			MakeItemSubTypeItem makeItemSubTypeConfig2 = MakeItemSubType.Instance.FirstOrDefault((MakeItemSubTypeItem m) => m.Result.ItemType == itemType && m.Result.TemplateId == medicineConfig.GroupId);
			if (makeItemSubTypeConfig2 != null)
			{
				return makeItemSubTypeConfig2.TemplateId;
			}
		}
		return -1;
	}

	/// <summary>
	/// 指定道具是否可以预定.
	/// 除了该条件以外还需判断技艺类型 <see cref="M:GameData.Domains.Item.ItemTemplateHelper.GetCraftRequiredLifeSkillType(System.SByte,System.Int16)" />
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanMakeArtisanOrder(sbyte itemType, short templateId)
	{
		if (IsSpecial(itemType, templateId))
		{
			return false;
		}
		if (ItemType.IsEquipmentItemType(itemType))
		{
			return GetEquipmentMakeItemSubType(itemType, templateId) >= 0;
		}
		switch (itemType)
		{
		case 12:
			return Misc.Instance[templateId].MakeItemSubType >= 0;
		default:
			return itemType == 9;
		case 7:
		case 8:
			return true;
		}
	}

	/// <summary>
	/// 获取打造, 修理, 精制时需要的技艺类型
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Character.LifeSkillType" /></returns>
	public static sbyte GetCraftRequiredLifeSkillType(sbyte itemType, short templateId)
	{
		switch (itemType)
		{
		case 5:
			return Material.Instance[templateId].RequiredLifeSkillType;
		case 9:
			return 5;
		default:
			switch (GetResourceType(itemType, templateId))
			{
			case 0:
				return 14;
			case 1:
				return 7;
			case 2:
				return 6;
			case 3:
				return 11;
			case 4:
				return 10;
			case 5:
				switch (itemType)
				{
				case 0:
					if (Weapon.Instance[templateId].ItemSubType == 15)
					{
						return 9;
					}
					break;
				case 8:
					if (Medicine.Instance[templateId].EffectType == EMedicineEffectType.ApplyPoison)
					{
						return 9;
					}
					break;
				}
				return 8;
			default:
				return -1;
			}
		}
	}

	/// <summary>
	/// 获取修理需要的造诣值
	/// </summary>
	public static short GetRepairRequiredAttainment(sbyte itemType, short templateId, short currDurability)
	{
		sbyte grade = GetGrade(itemType, templateId);
		float refactor = ((currDurability == 0) ? 1f : 0.5f);
		return Convert.ToInt16((float)GlobalConfig.Instance.RepairAttainments[grade] * refactor);
	}

	/// <summary>
	/// 获取修理需要的资源
	/// </summary>
	/// <returns></returns>
	public unsafe static ResourceInts GetRepairNeedResources(MaterialResources materialResources, ItemKey itemKey, short curDurability)
	{
		ResourceInts needResources = default(ResourceInts);
		needResources.Initialize();
		if (ItemType.IsEquipmentItemType(itemKey.ItemType))
		{
			float factor = ((curDurability == 0) ? 1f : 0.5f);
			sbyte grade = GetGrade(itemKey.ItemType, itemKey.TemplateId);
			short baseResource = GlobalConfig.Instance.RepairBaseResourseRequirement[grade];
			for (int i = 0; i < 6; i++)
			{
				needResources.Items[i] = (int)((float)materialResources.Items[i] * factor * (float)baseResource);
			}
		}
		return needResources;
	}

	/// <summary>
	/// 获取修理时需要的金钱
	/// </summary>
	public static int GetRepairNeedResourceCount(MaterialResources materialResources, ItemKey itemKey, short curDurability)
	{
		return GetRepairNeedResources(materialResources, itemKey, curDurability).GetSum() * 5;
	}

	/// <summary>
	/// 获取淬毒（毒术）或解毒（医术）需要的造诣
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static short GetPoisonRequiredAttainment(sbyte itemType, short templateId)
	{
		sbyte grade = GetGrade(itemType, templateId);
		return GlobalConfig.Instance.PoisonAttainments[grade];
	}

	/// <summary>
	/// 获取打造, 修理, 精制时需要的资源类型
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Character.ResourceType" /></returns>
	public static sbyte GetCraftRequiredResourceType(sbyte itemType, short templateId)
	{
		return GetResourceType(itemType, templateId);
	}

	/// <summary>
	/// 获取制造、精制时材料需要的资源数量
	/// </summary>
	public static short GetCraftMaterialRequiredResourceAmount(short templateId)
	{
		return Material.Instance[templateId].RequiredResourceAmount;
	}

	/// <summary>
	/// 获取精制时需要的造诣值
	/// </summary>
	/// <returns></returns>
	public unsafe static LifeSkillShorts GetRefineRequiredAttainment(short[] materialTemplateIds)
	{
		LifeSkillShorts needLifeSkill = default(LifeSkillShorts);
		foreach (short curId in materialTemplateIds)
		{
			MaterialItem materialConfig = Material.Instance[curId];
			short lifeSkillAttainment = needLifeSkill.Items[materialConfig.RequiredLifeSkillType];
			needLifeSkill.Items[materialConfig.RequiredLifeSkillType] = Math.Max(lifeSkillAttainment, materialConfig.RequiredAttainment);
		}
		return needLifeSkill;
	}

	/// <summary>
	/// 获取精制时需要的资源
	/// </summary>
	/// <returns></returns>
	public unsafe static ResourceInts GetRefineRequiredResources(short[] oldMaterialTemplateIds, short[] materialTemplateIds)
	{
		ResourceInts needResources = default(ResourceInts);
		for (int i = 0; i < materialTemplateIds.Length; i++)
		{
			short curId = materialTemplateIds[i];
			short oldId = oldMaterialTemplateIds[i];
			if (curId != -1 || oldId != -1)
			{
				short id = curId;
				if (curId == -1)
				{
					id = oldId;
				}
				MaterialItem materialConfig = Material.Instance[id];
				if (oldId != curId && curId > 0)
				{
					ref int reference = ref needResources.Items[materialConfig.ResourceType];
					reference += materialConfig.RequiredResourceAmount;
				}
			}
		}
		return needResources;
	}

	/// <summary>
	/// 获取拆解时获取同级道具的概率
	/// </summary>
	/// <returns></returns>
	public static int GetDisassembleSameGradeRate(sbyte grade)
	{
		return grade switch
		{
			7 => 30, 
			8 => 40, 
			_ => 20, 
		};
	}

	/// <summary>
	/// 获取指定物品是否可进行生铸
	/// </summary>
	public static bool GetAllowRawCreate(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			0 => Weapon.Instance[templateId].AllowRawCreate, 
			1 => Armor.Instance[templateId].AllowRawCreate, 
			2 => Accessory.Instance[templateId].AllowRawCreate, 
			_ => false, 
		};
	}

	/// <summary>
	/// 获取指定物品可生铸的新物品模板 ID
	/// </summary>
	public static IEnumerable<short> GetRawCreateDestinations(sbyte itemType, short sourceTemplateId)
	{
		short itemSubType = GetItemSubType(itemType, sourceTemplateId);
		sbyte resourceType = GetResourceType(itemType, sourceTemplateId);
		switch (itemType)
		{
		case 0:
			foreach (WeaponItem item3 in (IEnumerable<WeaponItem>)Weapon.Instance)
			{
				if (item3.ItemSubType == itemSubType && item3.ResourceType == resourceType && item3.AllowRawCreate)
				{
					yield return item3.TemplateId;
				}
			}
			break;
		case 1:
			foreach (ArmorItem item2 in (IEnumerable<ArmorItem>)Armor.Instance)
			{
				if (item2.ItemSubType == itemSubType && item2.ResourceType == resourceType && item2.AllowRawCreate)
				{
					yield return item2.TemplateId;
				}
			}
			break;
		case 2:
			foreach (AccessoryItem item in (IEnumerable<AccessoryItem>)Accessory.Instance)
			{
				if (item.ItemSubType == itemSubType && item.ResourceType == resourceType && item.AllowRawCreate)
				{
					yield return item.TemplateId;
				}
			}
			break;
		}
	}

	/// <summary>
	/// 获取生铸需要的精制材料
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="oldTemplateId"></param>
	/// <param name="newTemplateId"></param>
	/// <returns></returns>
	public static short GetRawCreateMaterial(sbyte itemType, short oldTemplateId, short newTemplateId)
	{
		if (!ItemType.IsEquipmentItemType(itemType))
		{
			return -1;
		}
		short makeSubType = GetEquipmentMakeItemSubType(itemType, newTemplateId);
		if (makeSubType < 0)
		{
			return -1;
		}
		if (GetGrade(itemType, oldTemplateId) >= GetGrade(itemType, newTemplateId))
		{
			return -1;
		}
		sbyte resourceType = GetResourceType(itemType, newTemplateId);
		int grade = Math.Max(GetGrade(itemType, newTemplateId) - 2, 0);
		sbyte refiningEffect = MakeItemSubType.Instance[makeSubType].RefiningEffect;
		foreach (MaterialItem config in (IEnumerable<MaterialItem>)Material.Instance)
		{
			if (config.ResourceType == resourceType && config.Grade == grade && config.RefiningEffect >= 0 && config.RefiningEffect == refiningEffect)
			{
				return config.TemplateId;
			}
		}
		return -1;
	}

	/// <summary>
	/// 获取拆解获得的原料，不含装备上已经精制的
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="randomSource"></param>
	/// <param name="sameGradeRate"></param>
	/// <returns></returns>
	public static short GetDisassemblyMaterial(sbyte itemType, short templateId, IRandomSource randomSource, int sameGradeRate)
	{
		short result = -1;
		if (!ItemType.IsEquipmentItemType(itemType))
		{
			return result;
		}
		short makeSubType = GetEquipmentMakeItemSubType(itemType, templateId);
		if (makeSubType < 0)
		{
			return result;
		}
		sbyte refiningEffect = MakeItemSubType.Instance[makeSubType].RefiningEffect;
		int materialGrade;
		int targetGrade = (materialGrade = MathUtils.Clamp((int)GetGrade(itemType, templateId), 0, 6));
		if (randomSource.NextFloat() > (float)sameGradeRate)
		{
			materialGrade = (sbyte)Math.Max(0, targetGrade - 1);
		}
		sbyte resourceType = GetResourceType(itemType, templateId);
		List<short> keyList = Material.Instance.GetAllKeys();
		int index = keyList.FindIndex(delegate(short id)
		{
			MaterialItem materialItem = Material.Instance[id];
			return materialItem.ResourceType == resourceType && materialItem.Grade == materialGrade && materialItem.RefiningEffect >= 0 && materialItem.RefiningEffect == refiningEffect;
		});
		if (keyList.CheckIndex(index))
		{
			result = keyList[index];
		}
		return result;
	}

	/// <summary>
	/// 获取所有拆解可能获得的原料，用于前端显示，不含装备上已经精制的
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static List<short> GetAllDisassemblyMaterial(sbyte itemType, short templateId)
	{
		List<short> materialIdList = null;
		if (ItemType.IsEquipmentItemType(itemType))
		{
			sbyte itemGrade = GetGrade(itemType, templateId);
			short makeSubType = GetEquipmentMakeItemSubType(itemType, templateId);
			if (makeSubType < 0)
			{
				return null;
			}
			sbyte refiningEffect = MakeItemSubType.Instance[makeSubType].RefiningEffect;
			int materialGrade3;
			int materialGrade2 = MathUtils.Clamp((materialGrade3 = MathUtils.Clamp((int)itemGrade, 0, 6)) - 1, 0, 6);
			sbyte resourceType = GetResourceType(itemType, templateId);
			materialIdList = Material.Instance.GetAllKeys().FindAll(delegate(short id)
			{
				MaterialItem materialItem = Material.Instance[id];
				return materialItem.ResourceType == resourceType && materialItem.RefiningEffect >= 0 && materialItem.RefiningEffect == refiningEffect && (materialItem.Grade == materialGrade3 || materialItem.Grade == materialGrade2);
			});
		}
		else if (itemType == 5)
		{
			materialIdList = new List<short>();
			foreach (PresetInventoryItem disassembleResultItem in Material.Instance[templateId].DisassembleResultItemList)
			{
				materialIdList.Add(disassembleResultItem.TemplateId);
			}
		}
		return materialIdList;
	}

	/// <summary>
	/// 获得使用指定资源的指定品级的制造工具。
	/// </summary>
	/// <param name="resourceType"></param>
	/// <param name="grade"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
	public static CraftToolItem GetGradeCraftTool(sbyte resourceType, sbyte grade)
	{
		return resourceType switch
		{
			0 => CraftTool.Instance[36 + grade], 
			1 => CraftTool.Instance[(int)grade], 
			2 => CraftTool.Instance[9 + grade], 
			3 => CraftTool.Instance[18 + grade], 
			4 => CraftTool.Instance[27 + grade], 
			5 => CraftTool.Instance[45 + grade], 
			_ => throw new Exception($"Given resource type {resourceType} cannot be used for crafting."), 
		};
	}

	/// <summary>
	/// 获取制造药品（医术）时材料的计算品级
	/// </summary>
	/// <param name="isManual">是否手动选择子分类</param>
	/// <param name="isMain">是否选择主方</param>
	/// <param name="grade">材料原始级别</param>
	/// <returns></returns>
	public static sbyte GetMakeHerbMaterialTempGrade(bool isManual, bool isMain, sbyte grade)
	{
		return GameData.Domains.Building.SharedMethods.GetHerbMaterialTempGrade(grade, isManual, isMain);
	}

	/// <summary>
	/// 获取物品是否可以拆解
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool GetCanDisassemble(sbyte itemType, short itemTemplate)
	{
		if (!IsTransferable(itemType, itemTemplate))
		{
			return false;
		}
		if (GetResourceType(itemType, itemTemplate) == -1)
		{
			return false;
		}
		if (itemType == 4 && Carrier.Instance[itemTemplate].ItemSubType != 400)
		{
			return false;
		}
		if (itemType == 5 && Material.Instance[itemTemplate].ResourceAmount <= 0)
		{
			return false;
		}
		if (itemType == 12 && Misc.Instance[itemTemplate].ResourceAmount <= 0 && Misc.Instance[itemTemplate].MakeItemSubType < 0)
		{
			return false;
		}
		if (ItemType.IsEquipmentItemType(itemType))
		{
			return GetMakeItemSubType(itemType, itemTemplate) >= 0;
		}
		if (itemType == 5 || itemType == 12)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 获取拆解可获得的资源
	/// </summary>
	/// <param name="materialResources"></param>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="amount"></param>
	/// <returns></returns>
	public unsafe static ResourceInts GetDisassembleResources(MaterialResources materialResources, sbyte itemType, short templateId, int amount)
	{
		ResourceInts needResources = default(ResourceInts);
		needResources.Initialize();
		if (materialResources.GetSum() > 0)
		{
			sbyte factor = 1;
			sbyte grade = GetGrade(itemType, templateId);
			short baseResource = GlobalConfig.Instance.RepairBaseResourseRequirement[grade];
			for (int i = 0; i < 6; i++)
			{
				needResources.Items[i] = amount * materialResources.Get(i) * factor * baseResource * GameData.Domains.World.SharedMethods.GetGainResourcePercent(10) / 100;
			}
		}
		else
		{
			sbyte resourceType = GetResourceType(itemType, templateId);
			short resourceAmount = 0;
			switch (itemType)
			{
			case 5:
				resourceAmount = Material.Instance[templateId].ResourceAmount;
				break;
			case 12:
				resourceAmount = Misc.Instance[templateId].ResourceAmount;
				break;
			}
			needResources.Items[resourceType] = amount * resourceAmount * 3 * GameData.Domains.World.SharedMethods.GetGainResourcePercent(10) / 100;
		}
		return needResources;
	}

	/// <summary>
	/// 获取拆解所需的造诣
	/// </summary>
	/// <returns></returns>
	public static short GetDisassembleRequiredAttainment(sbyte itemType, short itemTemplate)
	{
		sbyte grade = GetGrade(itemType, itemTemplate);
		return GlobalConfig.Instance.DisassembleAttainments[grade];
	}

	/// <summary>
	/// 获取药品的毒类型
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static sbyte GetMedicineItemPoisonType(sbyte itemType, short itemTemplate)
	{
		if (itemType != 8)
		{
			return -1;
		}
		if (GetItemSubType(itemType, itemTemplate) != 801)
		{
			return -1;
		}
		return Medicine.Instance[itemTemplate].PoisonType;
	}

	/// <summary>
	/// 判断指定物品是否为纯可堆叠物品 (物品可堆叠, 且没有激活任何变动类型).
	/// 纯可堆叠物品没有自己独有的物品对象.
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static bool IsPureStackable(ItemKey itemKey)
	{
		if (IsStackable(itemKey.ItemType, itemKey.TemplateId))
		{
			return !ModificationStateHelper.IsAnyActive(itemKey.ModificationState);
		}
		return false;
	}

	/// <summary>
	/// 通过技能书的模板 ID 获取对应的技艺的模板 ID
	/// </summary>
	/// <param name="skillBookTemplateId"></param>
	/// <returns></returns>
	public static short GetLifeSkillTemplateIdFromSkillBook(int skillBookTemplateId)
	{
		return SkillBook.Instance[skillBookTemplateId].LifeSkillTemplateId;
	}

	/// <summary>
	/// 通过技能书的模板 ID 获取对应的功法的模板 ID
	/// </summary>
	/// <param name="skillBookTemplateId"></param>
	/// <returns></returns>
	public static short GetCombatSkillTemplateIdFromSkillBook(int skillBookTemplateId)
	{
		return SkillBook.Instance[skillBookTemplateId].CombatSkillTemplateId;
	}

	/// <summary>
	/// 根据衣服的表现 Id 获取衣服的模板 Id
	/// </summary>
	/// <param name="displayId"></param>
	/// <returns></returns>
	public static short GetClothingTemplateIdByDisplayId(byte displayId)
	{
		foreach (ClothingItem item in (IEnumerable<ClothingItem>)Clothing.Instance)
		{
			if (item.DisplayId == displayId)
			{
				return item.TemplateId;
			}
		}
		throw new Exception($"Failed to find the clothing with displayId {displayId}!");
	}

	public static bool TryGetClothingTemplateIdByDisplayId(byte displayId, out short templateId)
	{
		foreach (ClothingItem item in (IEnumerable<ClothingItem>)Clothing.Instance)
		{
			if (item.DisplayId == displayId)
			{
				templateId = item.TemplateId;
				return true;
			}
		}
		templateId = 0;
		return false;
	}

	/// <summary>
	/// 创建不支持的物品类型异常
	/// </summary>
	public static Exception CreateItemTypeException(sbyte itemType)
	{
		return new Exception($"Unsupported ItemType: {itemType}");
	}

	/// <summary>
	/// 检测是否为神木种子，包括剧情神木种子和普通神木种子
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool CheckIsHeavenlyTreeSeeds(sbyte itemType, short itemTemplate)
	{
		bool flag = itemType == 12;
		if (flag)
		{
			bool flag2;
			switch (itemTemplate)
			{
			case 304:
			case 305:
			case 306:
			case 307:
			case 308:
			case 309:
			case 310:
			case 311:
			case 312:
			case 313:
			case 314:
			case 315:
			case 316:
			case 317:
			case 318:
			case 319:
			case 320:
			case 321:
			case 322:
			case 323:
			case 324:
			case 325:
			case 326:
			case 327:
				flag2 = true;
				break;
			default:
				flag2 = false;
				break;
			}
			flag = flag2;
		}
		return flag;
	}

	/// <summary>
	/// 检测是否为普通神木种子
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool CheckIsHeavenlyNormalTreeSeeds(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			if (itemTemplate >= 304)
			{
				return itemTemplate <= 315;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 检测是否为孤鸾镜水谣
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool CheckIsSectMainStoryItemXuannvNotes(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 349;
		}
		return false;
	}

	/// <summary>
	/// 检测是否为五仙的蛊仙
	/// </summary>
	public static bool CheckIsSectMainStoryItemWuxianWugFairy(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 364;
		}
		return false;
	}

	/// <summary>
	/// 检测是否为神鸡图
	/// </summary>
	public static bool CheckIsSectMainStoryFulongChickenMap(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 370;
		}
		return false;
	}

	/// <summary>
	/// 是否为残损巨剑
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool CheckIsDamageHugeSword(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 510;
		}
		return false;
	}

	/// <summary>
	/// 检测是否为元山地主的化念珠
	/// </summary>
	public static bool CheckIsSectMainStoryItemYuanshanRosary(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 345;
		}
		return false;
	}

	/// <summary>
	/// 检查是否为界青主线道具
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplate"></param>
	/// <returns></returns>
	public static bool CheckIsSectMainStoryItemJieQingStars(sbyte itemType, short itemTemplate)
	{
		if (itemType == 12)
		{
			return itemTemplate == 366;
		}
		return false;
	}

	/// <summary>
	/// 道具是否可投喂
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsFeedingAble(sbyte itemType, short templateId)
	{
		if (itemType == 5)
		{
			return Material.Instance[templateId].ItemSubType == 500;
		}
		return false;
	}

	/// <summary>
	/// 是否可以喂食代步
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanFeedCarrier(sbyte itemType, short templateId)
	{
		if (itemType == 4)
		{
			bool num = HasCarrierTame(itemType, templateId);
			CarrierItem config = Carrier.Instance[templateId];
			if (!num)
			{
				return config.ItemSubType == 401;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否有代步驯服度
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool HasCarrierTame(sbyte itemType, short templateId)
	{
		if (itemType == 4)
		{
			return Carrier.Instance[templateId].CombatState >= 0;
		}
		return false;
	}

	/// <summary>
	/// 是不是蛟卵
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsJiaoEgg(sbyte itemType, short templateId)
	{
		if (itemType == 5)
		{
			if (templateId >= 278)
			{
				return templateId <= 308;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 是不是幼蛟
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsJiaoChild(sbyte itemType, short templateId)
	{
		if (itemType == 5)
		{
			if (templateId >= 309)
			{
				return templateId <= 339;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 是不是蛟代步
	/// </summary>
	/// <returns></returns>
	public static bool IsJiaoCarrier(sbyte itemType, short templateId)
	{
		if (itemType == 4)
		{
			if (templateId >= 46)
			{
				return templateId <= 76;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 是不是蛟
	/// </summary>
	/// <returns></returns>
	public static bool IsJiao(sbyte itemType, short templateId)
	{
		if (!IsJiaoEgg(itemType, templateId) && !IsJiaoChild(itemType, templateId))
		{
			return IsJiaoCarrier(itemType, templateId);
		}
		return true;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsJiaoLoong(sbyte itemType, short templateId)
	{
		if (itemType == 4)
		{
			if (templateId >= 46)
			{
				return templateId <= 85;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 是否为徒手工具
	/// </summary>
	public static bool IsEmptyTool(sbyte itemType, short templateId)
	{
		if (itemType == 6)
		{
			if (templateId != 54)
			{
				return templateId == -1;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否是资源道具
	/// </summary>
	public static bool IsMiscResource(sbyte itemType, short templateId)
	{
		if (itemType == 12)
		{
			if (templateId >= 0)
			{
				return templateId <= 7;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// 获取资源道具的资源类型
	/// </summary>
	public static sbyte GetMiscResourceType(sbyte itemType, short templateId)
	{
		if (itemType == 12)
		{
			return templateId switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				7 => 7, 
				_ => -1, 
			};
		}
		return -1;
	}

	/// <summary>
	/// 资源道具是否可以交换（精挑细选），银钱不能筛选，威望不能操作
	/// </summary>
	public static bool MiscResourceCanChoosy(sbyte itemType, short templateId)
	{
		if (!IsMiscResource(itemType, templateId))
		{
			return false;
		}
		sbyte resourceType = GetMiscResourceType(itemType, templateId);
		if (resourceType != 6)
		{
			return resourceType != 7;
		}
		return false;
	}

	/// <summary>
	/// 资源道具是否可以交换，威望不能操作
	/// </summary>
	public static bool MiscResourceCanExchange(sbyte itemType, short templateId)
	{
		if (!IsMiscResource(itemType, templateId))
		{
			return false;
		}
		return GetMiscResourceType(itemType, templateId) != 7;
	}

	/// <summary>
	/// 药品是否为奇方
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="makeItemSybTypeTemplateId"></param>
	/// <returns></returns>
	public static bool MedicineIsOdd(sbyte itemType, short templateId, out short makeItemSybTypeTemplateId)
	{
		makeItemSybTypeTemplateId = -1;
		if (templateId < 0 || itemType != 8)
		{
			return false;
		}
		MedicineItem medicineItemConfig = Medicine.Instance[templateId];
		if (medicineItemConfig.GroupId < 0)
		{
			return false;
		}
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance.FirstOrDefault((MakeItemSubTypeItem m) => m.Result.ItemType == 8 && m.Result.TemplateId == medicineItemConfig.GroupId);
		if (makeItemSubTypeConfig == null)
		{
			return false;
		}
		makeItemSybTypeTemplateId = makeItemSubTypeConfig.TemplateId;
		return makeItemSubTypeConfig.IsOdd;
	}

	/// <summary>
	/// 检查药品是否能够经过大夫技能合成
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="targetTemplateId"></param>
	/// <returns></returns>
	public static bool CanMedicineUpgrade(sbyte itemType, short templateId, out short targetTemplateId)
	{
		targetTemplateId = -1;
		if (templateId < 0 || itemType != 8)
		{
			return false;
		}
		MedicineItem medicineItemConfig = Medicine.Instance[templateId];
		if (medicineItemConfig.GroupId < 0)
		{
			return false;
		}
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance.FirstOrDefault((MakeItemSubTypeItem m) => m.Result.ItemType == 8 && m.Result.TemplateId == medicineItemConfig.GroupId);
		if (makeItemSubTypeConfig == null)
		{
			return false;
		}
		if (makeItemSubTypeConfig.IsOdd)
		{
			MedicineItem groupMedicineConfig = Medicine.Instance[medicineItemConfig.GroupId];
			int gradeOffset = medicineItemConfig.Grade - groupMedicineConfig.Grade;
			MakeItemTypeItem makeItemTypeConfig = MakeItemType.Instance.FirstOrDefault((MakeItemTypeItem m) => m.MakeItemSubTypes.Contains(makeItemSubTypeConfig.TemplateId));
			if (makeItemTypeConfig == null)
			{
				return false;
			}
			short targetSubTypeId = makeItemTypeConfig.MakeItemSubTypes.Find((short id) => id != makeItemSubTypeConfig.TemplateId);
			MakeItemSubTypeItem targetSubTypeConfig = MakeItemSubType.Instance[targetSubTypeId];
			MedicineItem targetGroupMedicineConfig = Medicine.Instance[targetSubTypeConfig.Result.TemplateId];
			int targetGrade = targetGroupMedicineConfig.Grade + gradeOffset;
			MedicineItem target = Medicine.Instance.FirstOrDefault((MedicineItem m) => m.GroupId == targetGroupMedicineConfig.TemplateId && m.Grade == targetGrade);
			if (target != null)
			{
				targetTemplateId = target.TemplateId;
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 获取可服食道具的持续时间
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static short GetEatableItemDuration(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			7 => Food.Instance[templateId].Duration, 
			9 => TeaWine.Instance[templateId].Duration, 
			8 => Medicine.Instance[templateId].Duration, 
			5 => Material.Instance[templateId].Duration, 
			12 => 0, 
			_ => throw new Exception($"ItemType {itemType} is not eatable."), 
		};
	}

	/// <summary>
	/// 指定道具是否为蛊
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="includeKing"></param>
	/// <returns></returns>
	public static bool IsWug(sbyte itemType, short templateId, bool includeKing)
	{
		if (itemType == 8 && Medicine.Instance[templateId].WugType != -1)
		{
			if (!includeKing)
			{
				return Medicine.Instance[templateId].WugGrowthType != 5;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 比较道具品级
	/// </summary>
	/// <returns></returns>
	public static int CompareItemByGrade(ItemKey itemKeyA, ItemKey itemKeyB)
	{
		sbyte gradeA = GetGrade(itemKeyA.ItemType, itemKeyA.TemplateId);
		sbyte gradeB = GetGrade(itemKeyB.ItemType, itemKeyB.TemplateId);
		return gradeA.CompareTo(gradeB);
	}

	/// <summary>
	/// 是否是天劫符箓
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool IsTianJieFuLu(sbyte itemType, short templateId)
	{
		if (itemType == 12)
		{
			return templateId == 265;
		}
		return false;
	}

	/// <summary>
	/// 获取天劫符箓单位
	/// </summary>
	/// <returns></returns>
	public static int GetTianJieFuLuCountUnit()
	{
		return 9;
	}

	/// <summary>
	/// 获取物品单位
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static int GetItemCountUnit(sbyte itemType, short templateId)
	{
		if (!IsMiscResource(itemType, templateId))
		{
			if (!IsTianJieFuLu(itemType, templateId))
			{
				return 1;
			}
			return GetTianJieFuLuCountUnit();
		}
		return GetResourceCountUnit();
	}

	/// <summary>
	/// 获取资源物品的单位
	/// </summary>
	/// <returns></returns>
	public static int GetResourceCountUnit()
	{
		return 10;
	}

	/// <summary>
	/// 可触发通用事件 - 操作行囊物品 <see cref="F:Config.EventTriggerType.DefKey.OperateInventoryItem" />
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanTriggerCommonEvent(sbyte itemType, short templateId)
	{
		if (itemType == 12)
		{
			return Misc.Instance[templateId].CanTriggerCommonEvent;
		}
		return false;
	}

	/// <summary>
	/// 是否是感谢信
	/// </summary>
	/// <returns></returns>
	public static bool IsThanksLetter(sbyte itemType, short templateId)
	{
		bool flag = itemType == 12;
		if (flag)
		{
			bool flag2 = (uint)(templateId - 295) <= 8u;
			flag = flag2;
		}
		return flag;
	}

	/// <summary>
	/// 物品是否符合槽位类型
	/// Note: 动物装备永远不符合任意槽位类型
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="slot"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public static bool IsItemMeetSlot(sbyte itemType, short templateId, sbyte slot)
	{
		short itemSubType = GetItemSubType(itemType, templateId);
		switch (slot)
		{
		case 0:
		case 1:
		case 2:
			if (itemType == 0)
			{
				return itemSubType != 17;
			}
			return false;
		case 3:
			return itemSubType == 100;
		case 4:
			return itemType == 3;
		case 5:
			return itemSubType == 101;
		case 6:
			return itemSubType == 102;
		case 7:
			return itemSubType == 103;
		case 8:
		case 9:
		case 10:
			if (itemType == 2)
			{
				return itemSubType != 201;
			}
			return false;
		case 14:
		case 15:
		case 16:
			return itemSubType == 201;
		case 11:
			return itemSubType == 400;
		case 12:
			if ((uint)(itemSubType - 401) <= 3u)
			{
				return true;
			}
			return false;
		case 13:
			if ((uint)(itemSubType - 402) <= 2u)
			{
				return true;
			}
			return false;
		default:
			throw new ArgumentOutOfRangeException("slot", slot, null);
		}
	}

	/// <summary>
	/// 目标物品是否匹配物品筛选规则配置表的筛选项
	/// 物品筛选规则配置表的解析函数
	/// </summary>
	/// <param name="itemType">物品类型</param>
	/// <param name="templateId">对应物品类型下的模板ID</param>
	/// <param name="rule"></param>
	/// <returns></returns>
	public static bool MatchItemFilterRule(sbyte itemType, short templateId, ItemFilterRulesItem rule)
	{
		if (rule == null)
		{
			return true;
		}
		if (rule.AppointId.TemplateId != -1)
		{
			if (itemType == rule.AppointId.ItemType)
			{
				return templateId == rule.AppointId.TemplateId;
			}
			return false;
		}
		List<PresetItemSubTypeWithGradeRange> appointOrSubTypeCore = rule.AppointOrSubTypeCore;
		if (appointOrSubTypeCore != null && appointOrSubTypeCore.Count > 0)
		{
			sbyte grade = GetGrade(itemType, templateId);
			short subType = GetItemSubType(itemType, templateId);
			foreach (PresetItemSubTypeWithGradeRange itemSubTypeWithGrade in rule.AppointOrSubTypeCore)
			{
				if (subType == itemSubTypeWithGrade.SubType && grade >= itemSubTypeWithGrade.GradeMin && grade <= itemSubTypeWithGrade.GradeMax)
				{
					return true;
				}
			}
		}
		if (rule.AppointOrIdCore != null && rule.AppointOrIdCore.Count > 0)
		{
			foreach (PresetItemTemplateIdGroup coreCell in rule.AppointOrIdCore)
			{
				if (itemType == coreCell.ItemType && templateId >= coreCell.StartId && templateId < coreCell.StartId + coreCell.GroupLength)
				{
					return true;
				}
			}
		}
		return false;
	}

	/// <summary>
	/// 获取机关人成长进度
	/// 书籍提供2 * (品级 + 1)的资质，其余物品提供5 * 2^物品品级的进度值
	/// </summary>
	public static int GetGearMateUpgradeProgress(sbyte itemType, short templateId)
	{
		sbyte grade = GetGrade(itemType, templateId);
		if (itemType == 10)
		{
			return 2 * (grade + 1);
		}
		int value = 1;
		for (int i = 0; i < grade; i++)
		{
			value *= 2;
		}
		return value * 5;
	}

	/// <summary>
	/// 获取物品在战斗中的最大投掷距离，-1表示不能投掷
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static sbyte GetMaxUseDistance(sbyte itemType, short templateId)
	{
		return itemType switch
		{
			12 => Misc.Instance[templateId].MaxUseDistance, 
			8 => Medicine.Instance[templateId].MaxUseDistance, 
			_ => -1, 
		};
	}

	public static string GetName(int nameId)
	{
		if (nameId < 0 || !ExternalDataBridge.Context.CustomTexts.TryGetValue(nameId, out var text))
		{
			return null;
		}
		return text;
	}
}
