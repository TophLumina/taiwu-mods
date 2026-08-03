using System.Collections.Generic;
using Config;

namespace GameData.Domains.Item;

public class ItemDomain_Calc_Drop
{
	private static Dictionary<short, List<short>[]>[] _categorizedDroppableItems;

	private static void InitializeCategorizedDroppableItems()
	{
		if (_categorizedDroppableItems == null)
		{
			_categorizedDroppableItems = new Dictionary<short, List<short>[]>[13];
		}
		int itemType = 0;
		Dictionary<short, List<short>[]>[] categorizedDroppableItems = _categorizedDroppableItems;
		int num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (WeaponItem config in (IEnumerable<WeaponItem>)Config.Weapon.Instance)
		{
			if (config.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config.ItemSubType, out var droppable))
				{
					droppable = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config.ItemSubType, droppable);
				}
				List<short>[] array = droppable;
				num = config.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable[config.ItemSubType].Add(config.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (ArmorItem config2 in (IEnumerable<ArmorItem>)Config.Armor.Instance)
		{
			if (config2.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config2.ItemSubType, out var droppable2))
				{
					droppable2 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config2.ItemSubType, droppable2);
				}
				List<short>[] array = droppable2;
				num = config2.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable2[config2.ItemSubType].Add(config2.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (AccessoryItem config3 in (IEnumerable<AccessoryItem>)Config.Accessory.Instance)
		{
			if (config3.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config3.ItemSubType, out var droppable3))
				{
					droppable3 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config3.ItemSubType, droppable3);
				}
				List<short>[] array = droppable3;
				num = config3.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable3[config3.ItemSubType].Add(config3.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (ClothingItem config4 in (IEnumerable<ClothingItem>)Config.Clothing.Instance)
		{
			if (config4.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config4.ItemSubType, out var droppable4))
				{
					droppable4 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config4.ItemSubType, droppable4);
				}
				List<short>[] array = droppable4;
				num = config4.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable4[config4.ItemSubType].Add(config4.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (CarrierItem config5 in (IEnumerable<CarrierItem>)Config.Carrier.Instance)
		{
			if (config5.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config5.ItemSubType, out var droppable5))
				{
					droppable5 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config5.ItemSubType, droppable5);
				}
				List<short>[] array = droppable5;
				num = config5.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable5[config5.ItemSubType].Add(config5.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (MaterialItem config6 in (IEnumerable<MaterialItem>)Config.Material.Instance)
		{
			if (config6.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config6.ItemSubType, out var droppable6))
				{
					droppable6 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config6.ItemSubType, droppable6);
				}
				List<short>[] array = droppable6;
				num = config6.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable6[config6.ItemSubType].Add(config6.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (CraftToolItem config7 in (IEnumerable<CraftToolItem>)Config.CraftTool.Instance)
		{
			if (config7.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config7.ItemSubType, out var droppable7))
				{
					droppable7 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config7.ItemSubType, droppable7);
				}
				List<short>[] array = droppable7;
				num = config7.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable7[config7.ItemSubType].Add(config7.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (FoodItem config8 in (IEnumerable<FoodItem>)Config.Food.Instance)
		{
			if (config8.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config8.ItemSubType, out var droppable8))
				{
					droppable8 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config8.ItemSubType, droppable8);
				}
				List<short>[] array = droppable8;
				num = config8.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable8[config8.ItemSubType].Add(config8.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (MedicineItem config9 in (IEnumerable<MedicineItem>)Config.Medicine.Instance)
		{
			if (config9.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config9.ItemSubType, out var droppable9))
				{
					droppable9 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config9.ItemSubType, droppable9);
				}
				List<short>[] array = droppable9;
				num = config9.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable9[config9.ItemSubType].Add(config9.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (TeaWineItem config10 in (IEnumerable<TeaWineItem>)Config.TeaWine.Instance)
		{
			if (config10.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config10.ItemSubType, out var droppable10))
				{
					droppable10 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config10.ItemSubType, droppable10);
				}
				List<short>[] array = droppable10;
				num = config10.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable10[config10.ItemSubType].Add(config10.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (SkillBookItem config11 in (IEnumerable<SkillBookItem>)Config.SkillBook.Instance)
		{
			if (config11.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config11.ItemSubType, out var droppable11))
				{
					droppable11 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config11.ItemSubType, droppable11);
				}
				List<short>[] array = droppable11;
				num = config11.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable11[config11.ItemSubType].Add(config11.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (CricketItem config12 in (IEnumerable<CricketItem>)Config.Cricket.Instance)
		{
			if (config12.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config12.ItemSubType, out var droppable12))
				{
					droppable12 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config12.ItemSubType, droppable12);
				}
				List<short>[] array = droppable12;
				num = config12.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable12[config12.ItemSubType].Add(config12.TemplateId);
			}
		}
		itemType++;
		categorizedDroppableItems = _categorizedDroppableItems;
		num = itemType;
		if (categorizedDroppableItems[num] == null)
		{
			categorizedDroppableItems[num] = new Dictionary<short, List<short>[]>();
		}
		_categorizedDroppableItems[itemType].Clear();
		foreach (MiscItem config13 in (IEnumerable<MiscItem>)Config.Misc.Instance)
		{
			if (config13.DropRate > 0)
			{
				if (!_categorizedDroppableItems[itemType].TryGetValue(config13.ItemSubType, out var droppable13))
				{
					droppable13 = new List<short>[9];
					_categorizedDroppableItems[itemType].Add(config13.ItemSubType, droppable13);
				}
				List<short>[] array = droppable13;
				num = config13.ItemSubType;
				if (array[num] == null)
				{
					array[num] = new List<short>();
				}
				droppable13[config13.ItemSubType].Add(config13.TemplateId);
			}
		}
	}
}
