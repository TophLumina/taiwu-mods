using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Information;
using GameData.Domains.Item;

namespace GameData.Domains.TaiwuEvent.EventLog;

public class EventLogCharacterData
{
	public int Happiness;

	public sbyte Fame;

	public byte Infection;

	public short InfectionStatus;

	public Dictionary<ItemKey, int> Item;

	public ItemKey[] Equip;

	public int[] Resource;

	public int Exp;

	public short Health;

	public MainAttributes MainAttribute;

	public Injuries Injury;

	public PoisonInts Poison;

	public short DisorderOfQi;

	public List<short> CombatSkills;

	public List<LifeSkillItem> LifeSkills;

	public List<short> Feature;

	public short FavorabilityToTaiwu;

	public int ApprovedTaiwu;

	public List<int> SecretInformation;

	public List<NormalInformation> NormalInformation;

	public (sbyte, int) Combat;

	public Dictionary<short, int> SpiritualDebt;

	public (bool, int) Teammate;

	public Dictionary<int, int> Profession;

	public List<(bool, int, int, ushort)> Relation;

	public EventLogCharacterData(bool isTaiwu)
	{
		Happiness = 0;
		Fame = 0;
		Infection = 0;
		InfectionStatus = 209;
		Item = new Dictionary<ItemKey, int>();
		Equip = new ItemKey[17];
		Array.Fill(Equip, ItemKey.Invalid);
		Resource = new int[8];
		Exp = 0;
		Health = 0;
		MainAttribute = default(MainAttributes);
		Injury = default(Injuries);
		Poison = default(PoisonInts);
		DisorderOfQi = 0;
		CombatSkills = new List<short>();
		LifeSkills = new List<LifeSkillItem>();
		Relation = new List<(bool, int, int, ushort)>();
		Feature = new List<short>();
		if (isTaiwu)
		{
			SecretInformation = new List<int>();
			NormalInformation = new List<NormalInformation>();
			Teammate = (false, -1);
			Profession = new Dictionary<int, int>();
		}
	}
}
