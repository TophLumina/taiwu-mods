using System.Collections.Generic;
using Config;
using GameData.Domains.Item;

namespace GameData.Domains.Character.Ai;

public static class EatingItemComparer
{
	public static Comparer<(GameData.Domains.Item.Medicine item, int amount)> MedicineInjury = Comparer<(GameData.Domains.Item.Medicine, int)>.Create(CompareInjuryMedicines);

	public static Comparer<(GameData.Domains.Item.Medicine item, int amount)> MedicineEffect = Comparer<(GameData.Domains.Item.Medicine, int)>.Create(CompareMedicines);

	public static Comparer<(GameData.Domains.Item.Medicine item, int amount)> MedicineGrade = Comparer<(GameData.Domains.Item.Medicine, int)>.Create(CompareMedicinesByGrade);

	public static Comparer<(GameData.Domains.Item.Medicine item, int amount)> MedicineQiDisorder = Comparer<(GameData.Domains.Item.Medicine, int)>.Create(CompareQiDisorderMedicines);

	public static Comparer<(GameData.Domains.Item.Misc item, int amount)> MiscNeili = Comparer<(GameData.Domains.Item.Misc, int)>.Create(CompareItemsForNeili);

	public static Comparer<(GameData.Domains.Item.Food item, int amount)>[] FoodMainAttributes = new Comparer<(GameData.Domains.Item.Food, int)>[6]
	{
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 0)),
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 1)),
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 2)),
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 3)),
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 4)),
		Comparer<(GameData.Domains.Item.Food, int)>.Create(((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b) => CompareFoodForMainAttributes(a, b, 5))
	};

	public static Comparer<(GameData.Domains.Item.TeaWine item, int amount)> TeaWineHappiness = Comparer<(GameData.Domains.Item.TeaWine, int)>.Create(CompareTeaWineForHappiness);

	private static int CompareInjuryMedicines((GameData.Domains.Item.Medicine item, int amount) a, (GameData.Domains.Item.Medicine item, int amount) b)
	{
		int aEffect = a.item.GetEffectValue() * a.item.GetInjuryRecoveryTimes() * a.item.GetDuration();
		int bEffect = b.item.GetEffectValue() * b.item.GetInjuryRecoveryTimes() * b.item.GetDuration();
		return aEffect.CompareTo(bEffect);
	}

	private static int CompareMedicines((GameData.Domains.Item.Medicine item, int amount) a, (GameData.Domains.Item.Medicine item, int amount) b)
	{
		short aEffect = a.item.GetEffectValue();
		short bEffect = b.item.GetEffectValue();
		return aEffect.CompareTo(bEffect);
	}

	private static int CompareMedicinesByGrade((GameData.Domains.Item.Medicine item, int amount) a, (GameData.Domains.Item.Medicine item, int amount) b)
	{
		return a.item.GetGrade().CompareTo(b.item.GetGrade());
	}

	private static int CompareQiDisorderMedicines((GameData.Domains.Item.Medicine item, int amount) a, (GameData.Domains.Item.Medicine item, int amount) b)
	{
		int aEffect = -a.item.GetEffectValue();
		int bEffect = -b.item.GetEffectValue();
		return aEffect.CompareTo(bEffect);
	}

	private static int CompareItemsForNeili((GameData.Domains.Item.Misc item, int amount) a, (GameData.Domains.Item.Misc item, int amount) b)
	{
		return a.item.GetNeili().CompareTo(b.item.GetNeili());
	}

	private unsafe static int CompareFoodForMainAttributes((GameData.Domains.Item.Food item, int amount) a, (GameData.Domains.Item.Food item, int amount) b, sbyte attrType)
	{
		FoodItem aConfig = Config.Food.Instance[a.item.GetTemplateId()];
		short aRegen = aConfig.MainAttributesRegen.Items[attrType];
		FoodItem bConfig = Config.Food.Instance[b.item.GetTemplateId()];
		short bRegen = bConfig.MainAttributesRegen.Items[attrType];
		return aRegen.CompareTo(bRegen);
	}

	private static int CompareTeaWineForHappiness((GameData.Domains.Item.TeaWine item, int amount) a, (GameData.Domains.Item.TeaWine item, int amount) b)
	{
		sbyte aHappiness = a.item.GetHappinessChange();
		sbyte bHappiness = b.item.GetHappinessChange();
		return aHappiness.CompareTo(bHappiness);
	}
}
