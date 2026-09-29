using System.Collections.Generic;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.LegendaryBook;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Merchant;
using GameData.Domains.Mod;
using GameData.Domains.Organization;
using GameData.Domains.SpecialEffect;
using GameData.Domains.Story;
using GameData.Domains.Taiwu;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TutorialChapter;
using GameData.Domains.World;

namespace GameData.Domains;

public static class DomainHelper
{
	public static class DomainIds
	{
		public const ushort Global = 0;

		public const ushort World = 1;

		public const ushort Map = 2;

		public const ushort Organization = 3;

		public const ushort Character = 4;

		public const ushort Taiwu = 5;

		public const ushort Item = 6;

		public const ushort CombatSkill = 7;

		public const ushort Combat = 8;

		public const ushort Building = 9;

		public const ushort Adventure = 10;

		public const ushort LegendaryBook = 11;

		public const ushort TaiwuEvent = 12;

		public const ushort LifeRecord = 13;

		public const ushort Merchant = 14;

		public const ushort TutorialChapter = 15;

		public const ushort Mod = 16;

		public const ushort SpecialEffect = 17;

		public const ushort Information = 18;

		public const ushort Extra = 19;

		public const ushort Story = 20;

		public const int Count = 21;
	}

	public static readonly Dictionary<string, ushort> DomainName2DomainId = new Dictionary<string, ushort>
	{
		{ "Global", 0 },
		{ "World", 1 },
		{ "Map", 2 },
		{ "Organization", 3 },
		{ "Character", 4 },
		{ "Taiwu", 5 },
		{ "Item", 6 },
		{ "CombatSkill", 7 },
		{ "Combat", 8 },
		{ "Building", 9 },
		{ "Adventure", 10 },
		{ "LegendaryBook", 11 },
		{ "TaiwuEvent", 12 },
		{ "LifeRecord", 13 },
		{ "Merchant", 14 },
		{ "TutorialChapter", 15 },
		{ "Mod", 16 },
		{ "SpecialEffect", 17 },
		{ "Information", 18 },
		{ "Extra", 19 },
		{ "Story", 20 }
	};

	public static readonly string[] DomainId2DomainName = new string[21]
	{
		"Global", "World", "Map", "Organization", "Character", "Taiwu", "Item", "CombatSkill", "Combat", "Building",
		"Adventure", "LegendaryBook", "TaiwuEvent", "LifeRecord", "Merchant", "TutorialChapter", "Mod", "SpecialEffect", "Information", "Extra",
		"Story"
	};

	public static readonly string[][] DomainId2DataId2FieldName = new string[21][]
	{
		GlobalDomainHelper.DataId2FieldName,
		WorldDomainHelper.DataId2FieldName,
		MapDomainHelper.DataId2FieldName,
		OrganizationDomainHelper.DataId2FieldName,
		CharacterDomainHelper.DataId2FieldName,
		TaiwuDomainHelper.DataId2FieldName,
		ItemDomainHelper.DataId2FieldName,
		CombatSkillDomainHelper.DataId2FieldName,
		CombatDomainHelper.DataId2FieldName,
		BuildingDomainHelper.DataId2FieldName,
		AdventureDomainHelper.DataId2FieldName,
		LegendaryBookDomainHelper.DataId2FieldName,
		TaiwuEventDomainHelper.DataId2FieldName,
		LifeRecordDomainHelper.DataId2FieldName,
		MerchantDomainHelper.DataId2FieldName,
		TutorialChapterDomainHelper.DataId2FieldName,
		ModDomainHelper.DataId2FieldName,
		SpecialEffectDomainHelper.DataId2FieldName,
		InformationDomainHelper.DataId2FieldName,
		ExtraDomainHelper.DataId2FieldName,
		StoryDomainHelper.DataId2FieldName
	};

	public static readonly string[][][] DomainId2DataId2ObjectFieldId2FieldName = new string[21][][]
	{
		GlobalDomainHelper.DataId2ObjectFieldId2FieldName,
		WorldDomainHelper.DataId2ObjectFieldId2FieldName,
		MapDomainHelper.DataId2ObjectFieldId2FieldName,
		OrganizationDomainHelper.DataId2ObjectFieldId2FieldName,
		CharacterDomainHelper.DataId2ObjectFieldId2FieldName,
		TaiwuDomainHelper.DataId2ObjectFieldId2FieldName,
		ItemDomainHelper.DataId2ObjectFieldId2FieldName,
		CombatSkillDomainHelper.DataId2ObjectFieldId2FieldName,
		CombatDomainHelper.DataId2ObjectFieldId2FieldName,
		BuildingDomainHelper.DataId2ObjectFieldId2FieldName,
		AdventureDomainHelper.DataId2ObjectFieldId2FieldName,
		LegendaryBookDomainHelper.DataId2ObjectFieldId2FieldName,
		TaiwuEventDomainHelper.DataId2ObjectFieldId2FieldName,
		LifeRecordDomainHelper.DataId2ObjectFieldId2FieldName,
		MerchantDomainHelper.DataId2ObjectFieldId2FieldName,
		TutorialChapterDomainHelper.DataId2ObjectFieldId2FieldName,
		ModDomainHelper.DataId2ObjectFieldId2FieldName,
		SpecialEffectDomainHelper.DataId2ObjectFieldId2FieldName,
		InformationDomainHelper.DataId2ObjectFieldId2FieldName,
		ExtraDomainHelper.DataId2ObjectFieldId2FieldName,
		StoryDomainHelper.DataId2ObjectFieldId2FieldName
	};
}
