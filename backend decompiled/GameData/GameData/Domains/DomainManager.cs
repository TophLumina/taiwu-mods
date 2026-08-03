using GameData.Common;
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

public static class DomainManager
{
	public static readonly GlobalDomain Global = new GlobalDomain();

	public static WorldDomain World = new WorldDomain();

	public static MapDomain Map = new MapDomain();

	public static OrganizationDomain Organization = new OrganizationDomain();

	public static CharacterDomain Character = new CharacterDomain();

	public static TaiwuDomain Taiwu = new TaiwuDomain();

	public static ItemDomain Item = new ItemDomain();

	public static CombatSkillDomain CombatSkill = new CombatSkillDomain();

	public static CombatDomain Combat = new CombatDomain();

	public static BuildingDomain Building = new BuildingDomain();

	public static AdventureDomain Adventure = new AdventureDomain();

	public static LegendaryBookDomain LegendaryBook = new LegendaryBookDomain();

	public static TaiwuEventDomain TaiwuEvent = new TaiwuEventDomain();

	public static LifeRecordDomain LifeRecord = new LifeRecordDomain();

	public static MerchantDomain Merchant = new MerchantDomain();

	public static TutorialChapterDomain TutorialChapter = new TutorialChapterDomain();

	public static ModDomain Mod = new ModDomain();

	public static SpecialEffectDomain SpecialEffect = new SpecialEffectDomain();

	public static InformationDomain Information = new InformationDomain();

	public static ExtraDomain Extra = new ExtraDomain();

	public static StoryDomain Story = new StoryDomain();

	public static readonly BaseGameDataDomain[] Domains = new BaseGameDataDomain[21]
	{
		Global, World, Map, Organization, Character, Taiwu, Item, CombatSkill, Combat, Building,
		Adventure, LegendaryBook, TaiwuEvent, LifeRecord, Merchant, TutorialChapter, Mod, SpecialEffect, Information, Extra,
		Story
	};

	public static readonly ushort[] ArchiveAttachedDomainIds = new ushort[20]
	{
		1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
		11, 12, 13, 14, 15, 16, 17, 18, 19, 20
	};

	private static readonly BaseGameDataDomain[] ArchiveAttachedDomains = new BaseGameDataDomain[20];

	public static BaseGameDataDomain[] GetArchiveAttachedDomains()
	{
		ArchiveAttachedDomains[0] = World;
		ArchiveAttachedDomains[1] = Map;
		ArchiveAttachedDomains[2] = Organization;
		ArchiveAttachedDomains[3] = Character;
		ArchiveAttachedDomains[4] = Taiwu;
		ArchiveAttachedDomains[5] = Item;
		ArchiveAttachedDomains[6] = CombatSkill;
		ArchiveAttachedDomains[7] = Combat;
		ArchiveAttachedDomains[8] = Building;
		ArchiveAttachedDomains[9] = Adventure;
		ArchiveAttachedDomains[10] = LegendaryBook;
		ArchiveAttachedDomains[11] = TaiwuEvent;
		ArchiveAttachedDomains[12] = LifeRecord;
		ArchiveAttachedDomains[13] = Merchant;
		ArchiveAttachedDomains[14] = TutorialChapter;
		ArchiveAttachedDomains[15] = Mod;
		ArchiveAttachedDomains[16] = SpecialEffect;
		ArchiveAttachedDomains[17] = Information;
		ArchiveAttachedDomains[18] = Extra;
		ArchiveAttachedDomains[19] = Story;
		return ArchiveAttachedDomains;
	}

	public static void ResetArchiveAttachedDomains()
	{
		World = new WorldDomain();
		Map = new MapDomain();
		Organization = new OrganizationDomain();
		Character = new CharacterDomain();
		Taiwu = new TaiwuDomain();
		Item = new ItemDomain();
		CombatSkill = new CombatSkillDomain();
		Combat = new CombatDomain();
		Building = new BuildingDomain();
		Adventure = new AdventureDomain();
		LegendaryBook = new LegendaryBookDomain();
		TaiwuEvent = new TaiwuEventDomain();
		LifeRecord = new LifeRecordDomain();
		Merchant = new MerchantDomain();
		TutorialChapter = new TutorialChapterDomain();
		Mod = new ModDomain();
		SpecialEffect = new SpecialEffectDomain();
		Information = new InformationDomain();
		Extra = new ExtraDomain();
		Story = new StoryDomain();
		Domains[1] = World;
		Domains[2] = Map;
		Domains[3] = Organization;
		Domains[4] = Character;
		Domains[5] = Taiwu;
		Domains[6] = Item;
		Domains[7] = CombatSkill;
		Domains[8] = Combat;
		Domains[9] = Building;
		Domains[10] = Adventure;
		Domains[11] = LegendaryBook;
		Domains[12] = TaiwuEvent;
		Domains[13] = LifeRecord;
		Domains[14] = Merchant;
		Domains[15] = TutorialChapter;
		Domains[16] = Mod;
		Domains[17] = SpecialEffect;
		Domains[18] = Information;
		Domains[19] = Extra;
		Domains[20] = Story;
	}
}
