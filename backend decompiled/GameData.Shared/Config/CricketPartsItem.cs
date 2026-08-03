using System;
using Config.Common;
using GameData.Combat.Cricket;

namespace Config;

[Serializable]
public class CricketPartsItem : ConfigItem<CricketPartsItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 第二名称
	/// - 仅组合促织使用，NameOrder 靠后时以此部分名称拼接最终名称
	/// </summary>
	public readonly string NameAtSecond;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly ECricketPartsType Type;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 促织化灵事件文本
	/// </summary>
	public readonly short CricketPolymorphEvent;

	/// <summary>
	/// 品级
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 优先
	/// </summary>
	public readonly sbyte NameOrder;

	/// <summary>
	/// 寿命
	/// </summary>
	public readonly sbyte Life;

	/// <summary>
	/// 好感变化
	/// - 赠送时对方对赠送者的好感变化量，底色和部件取最高。
	/// </summary>
	public readonly int FavorabilityChange;

	/// <summary>
	/// 心情变化
	/// - 赠送时对方的心情变化，底色部件取最高
	/// </summary>
	public readonly sbyte HappinessChange;

	/// <summary>
	/// 价值
	/// </summary>
	public readonly int Value;

	/// <summary>
	/// 售价
	/// </summary>
	public readonly int Price;

	/// <summary>
	/// 叫声音调
	/// </summary>
	public readonly sbyte SingPitch;

	/// <summary>
	/// 叫声范围
	/// </summary>
	public readonly short SingSize;

	/// <summary>
	/// 捕捉概率
	/// - 0~100
	/// </summary>
	public readonly sbyte Rate;

	/// <summary>
	/// 高鸣时必然成功
	/// </summary>
	public readonly bool MustSuccessLoud;

	/// <summary>
	/// Npc 决斗使用概率
	/// - 仅针对神一品，使用区别于捕捉概率的特殊概率
	/// </summary>
	public readonly sbyte NpcSpecialRate;

	/// <summary>
	/// 进化概率
	/// - 0~100
	/// </summary>
	public readonly sbyte AdvanceRate;

	/// <summary>
	/// 促织福缘
	/// </summary>
	public readonly short CatchInfluence;

	/// <summary>
	/// 颜色
	/// - 颜色对应RGB值，仅颜色类型配置
	/// </summary>
	public readonly string Color;

	/// <summary>
	/// 属性成长倾向
	/// </summary>
	public readonly short Affix;

	/// <summary>
	/// 体质
	/// </summary>
	public readonly short HP;

	/// <summary>
	/// 斗性
	/// </summary>
	public readonly short SP;

	/// <summary>
	/// 气势
	/// </summary>
	public readonly sbyte Vigor;

	/// <summary>
	/// 角力
	/// </summary>
	public readonly sbyte Strength;

	/// <summary>
	/// 牙咬
	/// </summary>
	public readonly sbyte Bite;

	/// <summary>
	/// 致命
	/// </summary>
	public readonly sbyte Deadliness;

	/// <summary>
	/// 伤害
	/// </summary>
	public readonly sbyte Damage;

	/// <summary>
	/// 伤残
	/// </summary>
	public readonly sbyte Cripple;

	/// <summary>
	/// 防御
	/// </summary>
	public readonly sbyte Defence;

	/// <summary>
	/// 减伤
	/// </summary>
	public readonly sbyte DamageReduce;

	/// <summary>
	/// 反击
	/// </summary>
	public readonly short Counter;

	/// <summary>
	/// 技能
	/// </summary>
	public readonly int Skill;

	/// <summary>
	/// 化形-男
	/// </summary>
	public readonly short CharacterMale;

	/// <summary>
	/// 化形-女
	/// </summary>
	public readonly short CharacterFemale;

	/// <summary>
	/// 喂给鸡的心情
	/// </summary>
	public readonly sbyte Taste;

	/// <summary>
	/// 加载页面可用
	/// - 0可用 1不可用
	/// </summary>
	public readonly byte AvailableOnLoading;

	/// <summary>
	/// 抓住时的诗
	/// </summary>
	public readonly string PoetryTexture;

	/// <summary>
	/// 抓住时的诗的类型
	/// - 0四句 1两句
	/// </summary>
	public readonly byte PoetryTextureLength;

	/// <summary>
	/// 名称贴图
	/// </summary>
	public readonly string NameTexture;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名字</param>
	/// <param name="nameAtSecond">第二名称 - 仅组合促织使用，NameOrder 靠后时以此部分名称拼接最终名称</param>
	/// <param name="type">类型</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">说明</param>
	/// <param name="cricketPolymorphEvent">促织化灵事件文本</param>
	/// <param name="level">品级</param>
	/// <param name="nameOrder">优先</param>
	/// <param name="life">寿命</param>
	/// <param name="favorabilityChange">好感变化 - 赠送时对方对赠送者的好感变化量，底色和部件取最高。</param>
	/// <param name="happinessChange">心情变化 - 赠送时对方的心情变化，底色部件取最高</param>
	/// <param name="value">价值</param>
	/// <param name="price">售价</param>
	/// <param name="singPitch">叫声音调</param>
	/// <param name="singSize">叫声范围</param>
	/// <param name="rate">捕捉概率 - 0~100</param>
	/// <param name="mustSuccessLoud">高鸣时必然成功</param>
	/// <param name="npcSpecialRate">Npc 决斗使用概率 - 仅针对神一品，使用区别于捕捉概率的特殊概率</param>
	/// <param name="advanceRate">进化概率 - 0~100</param>
	/// <param name="catchInfluence">促织福缘</param>
	/// <param name="color">颜色 - 颜色对应RGB值，仅颜色类型配置</param>
	/// <param name="affix">属性成长倾向</param>
	/// <param name="hP">体质</param>
	/// <param name="sP">斗性</param>
	/// <param name="vigor">气势</param>
	/// <param name="strength">角力</param>
	/// <param name="bite">牙咬</param>
	/// <param name="deadliness">致命</param>
	/// <param name="damage">伤害</param>
	/// <param name="cripple">伤残</param>
	/// <param name="defence">防御</param>
	/// <param name="damageReduce">减伤</param>
	/// <param name="counter">反击</param>
	/// <param name="skill">技能</param>
	/// <param name="characterMale">化形-男</param>
	/// <param name="characterFemale">化形-女</param>
	/// <param name="taste">喂给鸡的心情</param>
	/// <param name="availableOnLoading">加载页面可用 - 0可用 1不可用</param>
	/// <param name="poetryTexture">抓住时的诗</param>
	/// <param name="poetryTextureLength">抓住时的诗的类型 - 0四句 1两句</param>
	/// <param name="nameTexture">名称贴图</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
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
