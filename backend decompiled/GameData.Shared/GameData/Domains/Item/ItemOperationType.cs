using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class ItemOperationType
{
	public enum EItemOperationType
	{
		Invalid = -1,
		Repair,
		Disassemble,
		Transfer,
		Take,
		Discard,
		SpecialBreakConvertToExp,
		Feeding,
		Confiscate,
		PutPoisonMaterial,
		ExchangeTools,
		FixItem,
		VillagerCraft,
		PutCraftResource,
		KongsangSpecialInteract,
		UpgradeAnimal,
		HostileInteraction,
		ProfessionDoctorSkill0
	}

	private static List<EItemOperationType> _consumeTypeList = new List<EItemOperationType>
	{
		EItemOperationType.Disassemble,
		EItemOperationType.Transfer,
		EItemOperationType.Discard,
		EItemOperationType.SpecialBreakConvertToExp,
		EItemOperationType.Feeding,
		EItemOperationType.PutPoisonMaterial,
		EItemOperationType.ExchangeTools,
		EItemOperationType.VillagerCraft,
		EItemOperationType.PutCraftResource,
		EItemOperationType.KongsangSpecialInteract,
		EItemOperationType.ProfessionDoctorSkill0
	};

	public const sbyte Invalid = -1;

	public const sbyte Repair = 0;

	public const sbyte Disassemble = 1;

	public const sbyte Transfer = 2;

	public const sbyte Take = 3;

	public const sbyte Discard = 4;

	public const sbyte SpecialBreakConvertToExp = 5;

	public const sbyte Feeding = 6;

	public const sbyte Confiscate = 7;

	public const sbyte PutPoisonMaterial = 8;

	public const sbyte ExchangeTools = 9;

	public const sbyte FixItem = 10;

	public const sbyte VillagerCraft = 11;

	public const sbyte PutCraftResource = 12;

	public const sbyte KongsangSpecialInteract = 13;

	public const sbyte HostileInteraction = 15;

	public const sbyte ProfessionDoctorSkill0 = 16;

	public static bool IsConsume(EItemOperationType type)
	{
		return _consumeTypeList.Contains(type);
	}
}
