using System;
using Config.Common;
using GameData.Combat.Cricket;

namespace Config;

[Serializable]
public class CricketPartsItem : ConfigItem<CricketPartsItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string NameAtSecond;

	public readonly ECricketPartsType Type;

	public readonly string Icon;

	public readonly string Desc;

	public readonly short CricketPolymorphEvent;

	public readonly sbyte Level;

	public readonly sbyte NameOrder;

	public readonly sbyte Life;

	public readonly int FavorabilityChange;

	public readonly sbyte HappinessChange;

	public readonly int Value;

	public readonly int Price;

	public readonly sbyte SingPitch;

	public readonly short SingSize;

	public readonly sbyte Rate;

	public readonly bool MustSuccessLoud;

	public readonly sbyte NpcSpecialRate;

	public readonly sbyte AdvanceRate;

	public readonly short CatchInfluence;

	public readonly string Color;

	public readonly short Affix;

	public readonly short HP;

	public readonly short SP;

	public readonly sbyte Vigor;

	public readonly sbyte Strength;

	public readonly sbyte Bite;

	public readonly sbyte Deadliness;

	public readonly sbyte Damage;

	public readonly sbyte Cripple;

	public readonly sbyte Defence;

	public readonly sbyte DamageReduce;

	public readonly short Counter;

	public readonly int Skill;

	public readonly short CharacterMale;

	public readonly short CharacterFemale;

	public readonly sbyte Taste;

	public readonly byte AvailableOnLoading;

	public readonly string PoetryTexture;

	public readonly byte PoetryTextureLength;

	public readonly string NameTexture;

	public CricketPartsItem(short templateId, string name, string nameAtSecond, ECricketPartsType type, string icon, string desc, short cricketPolymorphEvent, sbyte level, sbyte nameOrder, sbyte life, int favorabilityChange, sbyte happinessChange, int value, int price, sbyte singPitch, short singSize, sbyte rate, bool mustSuccessLoud, sbyte npcSpecialRate, sbyte advanceRate, short catchInfluence, string color, short affix, short hP, short sP, sbyte vigor, sbyte strength, sbyte bite, sbyte deadliness, sbyte damage, sbyte cripple, sbyte defence, sbyte damageReduce, short counter, int skill, short characterMale, short characterFemale, sbyte taste, byte availableOnLoading, string poetryTexture, byte poetryTextureLength, string nameTexture)
	{
		TemplateId = templateId;
		Name = name;
		NameAtSecond = nameAtSecond;
		Type = type;
		Icon = icon;
		Desc = desc;
		CricketPolymorphEvent = cricketPolymorphEvent;
		Level = level;
		NameOrder = nameOrder;
		Life = life;
		FavorabilityChange = favorabilityChange;
		HappinessChange = happinessChange;
		Value = value;
		Price = price;
		SingPitch = singPitch;
		SingSize = singSize;
		Rate = rate;
		MustSuccessLoud = mustSuccessLoud;
		NpcSpecialRate = npcSpecialRate;
		AdvanceRate = advanceRate;
		CatchInfluence = catchInfluence;
		Color = color;
		Affix = affix;
		HP = hP;
		SP = sP;
		Vigor = vigor;
		Strength = strength;
		Bite = bite;
		Deadliness = deadliness;
		Damage = damage;
		Cripple = cripple;
		Defence = defence;
		DamageReduce = damageReduce;
		Counter = counter;
		Skill = skill;
		CharacterMale = characterMale;
		CharacterFemale = characterFemale;
		Taste = taste;
		AvailableOnLoading = availableOnLoading;
		PoetryTexture = poetryTexture;
		PoetryTextureLength = poetryTextureLength;
		NameTexture = nameTexture;
	}

	public CricketPartsItem()
	{
		TemplateId = 0;
		Name = null;
		NameAtSecond = null;
		Type = ECricketPartsType.Trash;
		Icon = null;
		Desc = null;
		CricketPolymorphEvent = 0;
		Level = 0;
		NameOrder = 0;
		Life = 0;
		FavorabilityChange = 0;
		HappinessChange = 0;
		Value = 0;
		Price = 0;
		SingPitch = 0;
		SingSize = 0;
		Rate = 0;
		MustSuccessLoud = false;
		NpcSpecialRate = 0;
		AdvanceRate = 0;
		CatchInfluence = 0;
		Color = null;
		Affix = 0;
		HP = 0;
		SP = 0;
		Vigor = 0;
		Strength = 0;
		Bite = 0;
		Deadliness = 0;
		Damage = 0;
		Cripple = 0;
		Defence = 0;
		DamageReduce = 0;
		Counter = 0;
		Skill = 0;
		CharacterMale = 0;
		CharacterFemale = 0;
		Taste = 0;
		AvailableOnLoading = 0;
		PoetryTexture = null;
		PoetryTextureLength = 0;
		NameTexture = null;
	}

	public CricketPartsItem(short templateId, CricketPartsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		NameAtSecond = other.NameAtSecond;
		Type = other.Type;
		Icon = other.Icon;
		Desc = other.Desc;
		CricketPolymorphEvent = other.CricketPolymorphEvent;
		Level = other.Level;
		NameOrder = other.NameOrder;
		Life = other.Life;
		FavorabilityChange = other.FavorabilityChange;
		HappinessChange = other.HappinessChange;
		Value = other.Value;
		Price = other.Price;
		SingPitch = other.SingPitch;
		SingSize = other.SingSize;
		Rate = other.Rate;
		MustSuccessLoud = other.MustSuccessLoud;
		NpcSpecialRate = other.NpcSpecialRate;
		AdvanceRate = other.AdvanceRate;
		CatchInfluence = other.CatchInfluence;
		Color = other.Color;
		Affix = other.Affix;
		HP = other.HP;
		SP = other.SP;
		Vigor = other.Vigor;
		Strength = other.Strength;
		Bite = other.Bite;
		Deadliness = other.Deadliness;
		Damage = other.Damage;
		Cripple = other.Cripple;
		Defence = other.Defence;
		DamageReduce = other.DamageReduce;
		Counter = other.Counter;
		Skill = other.Skill;
		CharacterMale = other.CharacterMale;
		CharacterFemale = other.CharacterFemale;
		Taste = other.Taste;
		AvailableOnLoading = other.AvailableOnLoading;
		PoetryTexture = other.PoetryTexture;
		PoetryTextureLength = other.PoetryTextureLength;
		NameTexture = other.NameTexture;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CricketPartsItem Duplicate(int templateId)
	{
		return new CricketPartsItem((short)templateId, this);
	}

	public static implicit operator CricketCore(CricketPartsItem config)
	{
		return new CricketCore
		{
			Hp = config.HP,
			Sp = config.SP,
			Vigor = config.Vigor,
			Strength = config.Strength,
			Bite = config.Bite,
			Deadliness = config.Deadliness,
			Damage = config.Damage,
			Cripple = config.Cripple,
			Defense = config.Defence,
			DamageReduce = config.DamageReduce,
			Counter = config.Counter
		};
	}
}
