using System;
using GameData.Domains.SpecialEffect.Adventure.EnemyNest;
using GameData.Domains.SpecialEffect.Adventure.MainStory;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;
using GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;
using GameData.Domains.SpecialEffect.CombatSkill.NoSect.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.NoSect.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.NoSect.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.NoSect.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;
using GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ShuFang;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ZiWuXiao;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;
using GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.DefenseAndAssist;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;
using GameData.Domains.SpecialEffect.EquipmentEffect.Armor;
using GameData.Domains.SpecialEffect.EquipmentEffect.Armor.AddBounceDamage;
using GameData.Domains.SpecialEffect.EquipmentEffect.Armor.BreakReduceInjury;
using GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;
using GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;
using GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;
using GameData.Domains.SpecialEffect.EquipmentEffect.Weapon;
using GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.BreakAddInjury;
using GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;
using GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceBounceDamage;
using GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;
using GameData.Domains.SpecialEffect.LegendaryBook.Blade;
using GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic;
using GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot;
using GameData.Domains.SpecialEffect.LegendaryBook.Finger;
using GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm;
using GameData.Domains.SpecialEffect.LegendaryBook.Leg;
using GameData.Domains.SpecialEffect.LegendaryBook.Neigong;
using GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;
using GameData.Domains.SpecialEffect.LegendaryBook.Polearm;
using GameData.Domains.SpecialEffect.LegendaryBook.Posing;
using GameData.Domains.SpecialEffect.LegendaryBook.Special;
using GameData.Domains.SpecialEffect.LegendaryBook.Stunt;
using GameData.Domains.SpecialEffect.LegendaryBook.Sword;
using GameData.Domains.SpecialEffect.LegendaryBook.Throw;
using GameData.Domains.SpecialEffect.LegendaryBook.Whip;
using GameData.Domains.SpecialEffect.Misc;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;
using GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

namespace GameData.Domains.SpecialEffect;

public static class SpecialEffectType
{
	public const int NoSectNeigong0 = 0;

	public const int NoSectNeigong4 = 4;

	public const int NoSectFistAndPalm0 = 100;

	public const int NoSectAgile0 = 200;

	public const int NoSectDefense0 = 300;

	public const int ShaolinNeigong0 = 1000;

	public const int ShaolinNeigong1 = 1001;

	public const int ShaolinNeigong2 = 1002;

	public const int ShaolinNeigong3 = 1003;

	public const int ShaolinNeigong4 = 1004;

	public const int ShaolinNeigong5 = 1005;

	public const int ShaolinNeigong6 = 1006;

	public const int ShaolinNeigong7 = 1007;

	public const int ShaolinNeigong8 = 1008;

	public const int ShaolinFistAndPalm0 = 1100;

	public const int ShaolinFistAndPalm1 = 1101;

	public const int ShaolinFistAndPalm2 = 1102;

	public const int ShaolinFistAndPalm3 = 1103;

	public const int ShaolinFistAndPalm4 = 1104;

	public const int ShaolinFistAndPalm5 = 1105;

	public const int ShaolinFistAndPalm6 = 1106;

	public const int ShaolinFistAndPalm7 = 1107;

	public const int ShaolinFinger0 = 1200;

	public const int ShaolinFinger1 = 1201;

	public const int ShaolinFinger2 = 1202;

	public const int ShaolinFinger3 = 1203;

	public const int ShaolinFinger4 = 1204;

	public const int ShaolinFinger5 = 1205;

	public const int ShaolinPolearm0 = 1300;

	public const int ShaolinPolearm1 = 1301;

	public const int ShaolinPolearm2 = 1302;

	public const int ShaolinPolearm3 = 1303;

	public const int ShaolinPolearm4 = 1304;

	public const int ShaolinPolearm5 = 1305;

	public const int ShaolinPolearm6 = 1306;

	public const int ShaolinPolearm7 = 1307;

	public const int ShaolinPolearm8 = 1308;

	public const int ShaolinAgile0 = 1400;

	public const int ShaolinAgile1 = 1401;

	public const int ShaolinAgile2 = 1402;

	public const int ShaolinAgile3 = 1403;

	public const int ShaolinAgile4 = 1404;

	public const int ShaolinAgile5 = 1405;

	public const int ShaolinDefense1 = 1501;

	public const int ShaolinDefense2 = 1502;

	public const int ShaolinDefense4 = 1504;

	public const int ShaolinDefense7 = 1507;

	public const int ShaolinDefense8 = 1508;

	public const int ShaolinAssist0 = 1600;

	public const int ShaolinAssist3 = 1603;

	public const int ShaolinAssist5 = 1605;

	public const int ShaolinAssist6 = 1606;

	public const int EmeiNeigong0 = 2000;

	public const int EmeiNeigong1 = 2001;

	public const int EmeiNeigong2 = 2002;

	public const int EmeiNeigong3 = 2003;

	public const int EmeiNeigong4 = 2004;

	public const int EmeiNeigong5 = 2005;

	public const int EmeiNeigong6 = 2006;

	public const int EmeiNeigong7 = 2007;

	public const int EmeiFistAndPalm0 = 2100;

	public const int EmeiFistAndPalm1 = 2101;

	public const int EmeiFistAndPalm2 = 2102;

	public const int EmeiFistAndPalm3 = 2103;

	public const int EmeiFistAndPalm4 = 2104;

	public const int EmeiFistAndPalm5 = 2105;

	public const int EmeiFistAndPalm6 = 2106;

	public const int EmeiFinger0 = 2200;

	public const int EmeiFinger1 = 2201;

	public const int EmeiFinger2 = 2202;

	public const int EmeiFinger3 = 2203;

	public const int EmeiFinger4 = 2204;

	public const int EmeiFinger5 = 2205;

	public const int EmeiFinger6 = 2206;

	public const int EmeiFinger7 = 2207;

	public const int EmeiFinger8 = 2208;

	public const int EmeiSword0 = 2300;

	public const int EmeiSword1 = 2301;

	public const int EmeiSword2 = 2302;

	public const int EmeiSword3 = 2303;

	public const int EmeiSword4 = 2304;

	public const int EmeiSword5 = 2305;

	public const int EmeiSword6 = 2306;

	public const int EmeiSpecial0 = 2400;

	public const int EmeiSpecial1 = 2401;

	public const int EmeiSpecial2 = 2402;

	public const int EmeiSpecial3 = 2403;

	public const int EmeiSpecial4 = 2404;

	public const int EmeiSpecial5 = 2405;

	public const int EmeiSpecial6 = 2406;

	public const int EmeiSpecial7 = 2407;

	public const int EmeiAgile0 = 2500;

	public const int EmeiAgile1 = 2501;

	public const int EmeiAgile2 = 2502;

	public const int EmeiAgile3 = 2503;

	public const int EmeiAgile4 = 2504;

	public const int EmeiAgile5 = 2505;

	public const int EmeiAgile6 = 2506;

	public const int EmeiDefense3 = 2603;

	public const int EmeiDefense6 = 2606;

	public const int EmeiDefense8 = 2608;

	public const int EmeiAssist0 = 2700;

	public const int EmeiAssist1 = 2701;

	public const int EmeiAssist2 = 2702;

	public const int EmeiAssist4 = 2704;

	public const int EmeiAssist5 = 2705;

	public const int EmeiAssist7 = 2707;

	public const int BaihuaNeigong0 = 3000;

	public const int BaihuaNeigong1 = 3001;

	public const int BaihuaNeigong2 = 3002;

	public const int BaihuaNeigong3 = 3003;

	public const int BaihuaNeigong4 = 3004;

	public const int BaihuaFinger0 = 3100;

	public const int BaihuaFinger1 = 3101;

	public const int BaihuaFinger2 = 3102;

	public const int BaihuaFinger3 = 3103;

	public const int BaihuaFinger4 = 3104;

	public const int BaihuaFinger5 = 3105;

	public const int BaihuaFinger6 = 3106;

	public const int BaihuaFinger7 = 3107;

	public const int BaihuaFinger8 = 3108;

	public const int BaihuaShot0 = 3200;

	public const int BaihuaShot1 = 3201;

	public const int BaihuaShot2 = 3202;

	public const int BaihuaShot3 = 3203;

	public const int BaihuaShot4 = 3204;

	public const int BaihuaShot5 = 3205;

	public const int BaihuaShot6 = 3206;

	public const int BaihuaShot7 = 3207;

	public const int BaihuaShot8 = 3208;

	public const int BaihuaMusic0 = 3300;

	public const int BaihuaMusic1 = 3301;

	public const int BaihuaMusic2 = 3302;

	public const int BaihuaMusic3 = 3303;

	public const int BaihuaMusic4 = 3304;

	public const int BaihuaMusic5 = 3305;

	public const int BaihuaMusic6 = 3306;

	public const int BaihuaAgile0 = 3400;

	public const int BaihuaAgile1 = 3401;

	public const int BaihuaAgile2 = 3402;

	public const int BaihuaAgile3 = 3403;

	public const int BaihuaAgile4 = 3404;

	public const int BaihuaAgile5 = 3405;

	public const int BaihuaAgile6 = 3406;

	public const int BaihuaAgile7 = 3407;

	public const int BaihuaDefense4 = 3504;

	public const int BaihuaDefense5 = 3505;

	public const int BaihuaDefense7 = 3507;

	public const int BaihuaDefense8 = 3508;

	public const int BaihuaAssist0 = 3600;

	public const int BaihuaAssist1 = 3601;

	public const int BaihuaAssist2 = 3602;

	public const int BaihuaAssist3 = 3603;

	public const int BaihuaAssist6 = 3606;

	public const int WudangNeigong0 = 4000;

	public const int WudangNeigong1 = 4001;

	public const int WudangNeigong2 = 4002;

	public const int WudangNeigong3 = 4003;

	public const int WudangNeigong4 = 4004;

	public const int WudangNeigong5 = 4005;

	public const int WudangNeigong6 = 4006;

	public const int WudangNeigong7 = 4007;

	public const int WudangNeigong8 = 4008;

	public const int WudangFistAndPalm0 = 4100;

	public const int WudangFistAndPalm1 = 4101;

	public const int WudangFistAndPalm2 = 4102;

	public const int WudangFistAndPalm3 = 4103;

	public const int WudangFistAndPalm4 = 4104;

	public const int WudangFistAndPalm5 = 4105;

	public const int WudangFistAndPalm6 = 4106;

	public const int WudangFistAndPalm7 = 4107;

	public const int WudangFistAndPalm8 = 4108;

	public const int WudangSword0 = 4200;

	public const int WudangSword1 = 4201;

	public const int WudangSword2 = 4202;

	public const int WudangSword3 = 4203;

	public const int WudangSword4 = 4204;

	public const int WudangSword5 = 4205;

	public const int WudangSword6 = 4206;

	public const int WudangSword7 = 4207;

	public const int WudangSword8 = 4208;

	public const int WudangWhip0 = 4300;

	public const int WudangWhip1 = 4301;

	public const int WudangWhip2 = 4302;

	public const int WudangWhip3 = 4303;

	public const int WudangWhip4 = 4304;

	public const int WudangWhip5 = 4305;

	public const int WudangWhip6 = 4306;

	public const int WudangWhip7 = 4307;

	public const int WudangAgile0 = 4400;

	public const int WudangAgile1 = 4401;

	public const int WudangAgile2 = 4402;

	public const int WudangAgile3 = 4403;

	public const int WudangAgile4 = 4404;

	public const int WudangAgile5 = 4405;

	public const int WudangAgile6 = 4406;

	public const int WudangDefense0 = 4500;

	public const int WudangDefense2 = 4502;

	public const int WudangDefense4 = 4504;

	public const int WudangDefense6 = 4506;

	public const int WudangAssist1 = 4601;

	public const int WudangAssist3 = 4603;

	public const int WudangAssist5 = 4605;

	public const int WudangAssist7 = 4607;

	public const int YuanshanNeigong0 = 5000;

	public const int YuanshanNeigong1 = 5001;

	public const int YuanshanNeigong2 = 5002;

	public const int YuanshanNeigong3 = 5003;

	public const int YuanshanNeigong4 = 5004;

	public const int YuanshanLeg0 = 5100;

	public const int YuanshanLeg1 = 5101;

	public const int YuanshanLeg2 = 5102;

	public const int YuanshanLeg3 = 5103;

	public const int YuanshanLeg4 = 5104;

	public const int YuanshanLeg5 = 5105;

	public const int YuanshanLeg6 = 5106;

	public const int YuanshanLeg7 = 5107;

	public const int YuanshanLeg8 = 5108;

	public const int YuanshanSword0 = 5200;

	public const int YuanshanSword1 = 5201;

	public const int YuanshanSword2 = 5202;

	public const int YuanshanSword3 = 5203;

	public const int YuanshanSword4 = 5204;

	public const int YuanshanSword5 = 5205;

	public const int YuanshanSword6 = 5206;

	public const int YuanshanSword7 = 5207;

	public const int YuanshanBlade0 = 5300;

	public const int YuanshanBlade1 = 5301;

	public const int YuanshanBlade2 = 5302;

	public const int YuanshanBlade3 = 5303;

	public const int YuanshanBlade4 = 5304;

	public const int YuanshanBlade5 = 5305;

	public const int YuanshanBlade6 = 5306;

	public const int YuanshanBlade7 = 5307;

	public const int YuanshanAgile0 = 5400;

	public const int YuanshanAgile1 = 5401;

	public const int YuanshanAgile2 = 5402;

	public const int YuanshanAgile3 = 5403;

	public const int YuanshanDefense0 = 5500;

	public const int YuanshanDefense3 = 5503;

	public const int YuanshanDefense6 = 5506;

	public const int YuanshanAssist1 = 5601;

	public const int YuanshanAssist2 = 5602;

	public const int YuanshanAssist4 = 5604;

	public const int YuanshanAssist5 = 5605;

	public const int ShixiangNeigong0 = 6000;

	public const int ShixiangNeigong1 = 6001;

	public const int ShixiangNeigong2 = 6002;

	public const int ShixiangNeigong3 = 6003;

	public const int ShixiangNeigong4 = 6004;

	public const int ShixiangFistAndPalm0 = 6100;

	public const int ShixiangFistAndPalm1 = 6101;

	public const int ShixiangFistAndPalm2 = 6102;

	public const int ShixiangFistAndPalm3 = 6103;

	public const int ShixiangFistAndPalm4 = 6104;

	public const int ShixiangFistAndPalm5 = 6105;

	public const int ShixiangFistAndPalm6 = 6106;

	public const int ShixiangFistAndPalm7 = 6107;

	public const int ShixiangFistAndPalm8 = 6108;

	public const int ShixiangBlade0 = 6200;

	public const int ShixiangBlade1 = 6201;

	public const int ShixiangBlade2 = 6202;

	public const int ShixiangBlade3 = 6203;

	public const int ShixiangBlade4 = 6204;

	public const int ShixiangBlade5 = 6205;

	public const int ShixiangBlade6 = 6206;

	public const int ShixiangBlade7 = 6207;

	public const int ShixiangBlade8 = 6208;

	public const int ShixiangPolearm0 = 6300;

	public const int ShixiangPolearm1 = 6301;

	public const int ShixiangPolearm2 = 6302;

	public const int ShixiangPolearm3 = 6303;

	public const int ShixiangPolearm4 = 6304;

	public const int ShixiangPolearm5 = 6305;

	public const int ShixiangPolearm6 = 6306;

	public const int ShixiangPolearm7 = 6307;

	public const int ShixiangPolearm8 = 6308;

	public const int ShixiangAgile0 = 6400;

	public const int ShixiangAgile1 = 6401;

	public const int ShixiangAgile2 = 6402;

	public const int ShixiangAgile3 = 6403;

	public const int ShixiangDefense0 = 6500;

	public const int ShixiangDefense2 = 6502;

	public const int ShixiangDefense5 = 6505;

	public const int ShixiangAssist1 = 6601;

	public const int ShixiangAssist3 = 6603;

	public const int ShixiangAssist4 = 6604;

	public const int RanshanNeigong0 = 7000;

	public const int RanshanNeigong1 = 7001;

	public const int RanshanNeigong2 = 7002;

	public const int RanshanNeigong3 = 7003;

	public const int RanshanNeigong4 = 7004;

	public const int RanshanNeigong5 = 7005;

	public const int RanshanNeigong6 = 7006;

	public const int RanshanNeigong7 = 7007;

	public const int RanshanNeigong8 = 7008;

	public const int RanshanFinger0 = 7100;

	public const int RanshanFinger1 = 7101;

	public const int RanshanFinger2 = 7102;

	public const int RanshanFinger3 = 7103;

	public const int RanshanFinger4 = 7104;

	public const int RanshanFinger5 = 7105;

	public const int RanshanFinger6 = 7106;

	public const int RanshanSword0 = 7200;

	public const int RanshanSword1 = 7201;

	public const int RanshanSword2 = 7202;

	public const int RanshanSword3 = 7203;

	public const int RanshanSword4 = 7204;

	public const int RanshanSword5 = 7205;

	public const int RanshanSword6 = 7206;

	public const int RanshanSword7 = 7207;

	public const int RanshanSword8 = 7208;

	public const int RanshanSpecial0 = 7300;

	public const int RanshanSpecial1 = 7301;

	public const int RanshanSpecial2 = 7302;

	public const int RanshanSpecial3 = 7303;

	public const int RanshanSpecial4 = 7304;

	public const int RanshanSpecial5 = 7305;

	public const int RanshanSpecial6 = 7306;

	public const int RanshanSpecial7 = 7307;

	public const int RanshanSpecial8 = 7308;

	public const int RanshanAgile0 = 7400;

	public const int RanshanAgile1 = 7401;

	public const int RanshanAgile2 = 7402;

	public const int RanshanAgile3 = 7403;

	public const int RanshanAgile4 = 7404;

	public const int RanshanAgile5 = 7405;

	public const int RanshanAgile6 = 7406;

	public const int RanshanDefense0 = 7500;

	public const int RanshanDefense3 = 7503;

	public const int RanshanDefense5 = 7505;

	public const int RanshanDefense6 = 7506;

	public const int RanshanDefense7 = 7507;

	public const int RanshanAssist1 = 7601;

	public const int RanshanAssist2 = 7602;

	public const int RanshanAssist4 = 7604;

	public const int XuannvNeigong0 = 8000;

	public const int XuannvNeigong1 = 8001;

	public const int XuannvNeigong2 = 8002;

	public const int XuannvNeigong3 = 8003;

	public const int XuannvNeigong4 = 8004;

	public const int XuannvNeigong5 = 8005;

	public const int XuannvNeigong6 = 8006;

	public const int XuannvNeigong7 = 8007;

	public const int XuannvNeigong8 = 8008;

	public const int XuannvFistAndPalm0 = 8100;

	public const int XuannvFistAndPalm1 = 8101;

	public const int XuannvFistAndPalm2 = 8102;

	public const int XuannvFistAndPalm3 = 8103;

	public const int XuannvFistAndPalm4 = 8104;

	public const int XuannvFistAndPalm5 = 8105;

	public const int XuannvFistAndPalm6 = 8106;

	public const int XuannvFinger0 = 8200;

	public const int XuannvFinger1 = 8201;

	public const int XuannvFinger2 = 8202;

	public const int XuannvFinger3 = 8203;

	public const int XuannvFinger4 = 8204;

	public const int XuannvFinger5 = 8205;

	public const int XuannvFinger6 = 8206;

	public const int XuannvFinger7 = 8207;

	public const int XuannvMusic0 = 8300;

	public const int XuannvMusic1 = 8301;

	public const int XuannvMusic2 = 8302;

	public const int XuannvMusic3 = 8303;

	public const int XuannvMusic4 = 8304;

	public const int XuannvMusic5 = 8305;

	public const int XuannvMusic6 = 8306;

	public const int XuannvMusic7 = 8307;

	public const int XuannvMusic8 = 8308;

	public const int XuannvAgile0 = 8400;

	public const int XuannvAgile1 = 8401;

	public const int XuannvAgile2 = 8402;

	public const int XuannvAgile3 = 8403;

	public const int XuannvAgile4 = 8404;

	public const int XuannvAgile5 = 8405;

	public const int XuannvAgile6 = 8406;

	public const int XuannvAgile7 = 8407;

	public const int XuannvAgile8 = 8408;

	public const int XuannvDefense1 = 8501;

	public const int XuannvDefense5 = 8505;

	public const int XuannvDefense6 = 8506;

	public const int XuannvAssist0 = 8600;

	public const int XuannvAssist2 = 8602;

	public const int XuannvAssist3 = 8603;

	public const int XuannvAssist4 = 8604;

	public const int ZhujianNeigong0 = 9000;

	public const int ZhujianNeigong1 = 9001;

	public const int ZhujianNeigong2 = 9002;

	public const int ZhujianNeigong3 = 9003;

	public const int ZhujianNeigong4 = 9004;

	public const int ZhujianNeigong5 = 9005;

	public const int ZhujianSword0 = 9100;

	public const int ZhujianSword1 = 9101;

	public const int ZhujianSword2 = 9102;

	public const int ZhujianSword3 = 9103;

	public const int ZhujianSword4 = 9104;

	public const int ZhujianSword5 = 9105;

	public const int ZhujianSword6 = 9106;

	public const int ZhujianSword7 = 9107;

	public const int ZhujianBlade0 = 9200;

	public const int ZhujianBlade1 = 9201;

	public const int ZhujianBlade2 = 9202;

	public const int ZhujianBlade3 = 9203;

	public const int ZhujianBlade4 = 9204;

	public const int ZhujianBlade5 = 9205;

	public const int ZhujianBlade6 = 9206;

	public const int ZhujianBlade7 = 9207;

	public const int ZhujianPolearm0 = 9300;

	public const int ZhujianPolearm1 = 9301;

	public const int ZhujianPolearm2 = 9302;

	public const int ZhujianPolearm3 = 9303;

	public const int ZhujianPolearm4 = 9304;

	public const int ZhujianPolearm5 = 9305;

	public const int ZhujianPolearm6 = 9306;

	public const int ZhujianPolearm7 = 9307;

	public const int ZhujianShot0 = 9400;

	public const int ZhujianShot1 = 9401;

	public const int ZhujianShot2 = 9402;

	public const int ZhujianShot3 = 9403;

	public const int ZhujianShot4 = 9404;

	public const int ZhujianShot5 = 9405;

	public const int ZhujianShot6 = 9406;

	public const int ZhujianShot7 = 9407;

	public const int ZhujianShot8 = 9408;

	public const int ZhujianAgile0 = 9500;

	public const int ZhujianAgile1 = 9501;

	public const int ZhujianAgile2 = 9502;

	public const int ZhujianAgile3 = 9503;

	public const int ZhujianAgile4 = 9504;

	public const int ZhujianAgile5 = 9505;

	public const int ZhujianAgile6 = 9506;

	public const int ZhujianDefense1 = 9701;

	public const int ZhujianDefense4 = 9704;

	public const int ZhujianDefense5 = 9705;

	public const int ZhujianAssist0 = 9700;

	public const int ZhujianAssist2 = 9702;

	public const int ZhujianAssist3 = 9703;

	public const int ZhujianAssist6 = 9706;

	public const int KongsangNeigong0 = 10000;

	public const int KongsangNeigong1 = 10001;

	public const int KongsangNeigong2 = 10002;

	public const int KongsangNeigong3 = 10003;

	public const int KongsangNeigong4 = 10004;

	public const int KongsangFistAndPalm0 = 10100;

	public const int KongsangFistAndPalm1 = 10101;

	public const int KongsangFistAndPalm2 = 10102;

	public const int KongsangFistAndPalm3 = 10103;

	public const int KongsangFistAndPalm4 = 10104;

	public const int KongsangFistAndPalm5 = 10105;

	public const int KongsangFinger0 = 10200;

	public const int KongsangFinger1 = 10201;

	public const int KongsangFinger2 = 10202;

	public const int KongsangFinger3 = 10203;

	public const int KongsangFinger4 = 10204;

	public const int KongsangFinger5 = 10205;

	public const int KongsangLeg0 = 10300;

	public const int KongsangLeg1 = 10301;

	public const int KongsangLeg2 = 10302;

	public const int KongsangLeg3 = 10303;

	public const int KongsangLeg4 = 10304;

	public const int KongsangLeg5 = 10305;

	public const int KongsangLeg6 = 10306;

	public const int KongsangLeg7 = 10307;

	public const int KongsangThrow0 = 10400;

	public const int KongsangThrow1 = 10401;

	public const int KongsangThrow2 = 10402;

	public const int KongsangThrow3 = 10403;

	public const int KongsangThrow4 = 10404;

	public const int KongsangThrow5 = 10405;

	public const int KongsangThrow6 = 10406;

	public const int KongsangThrow7 = 10407;

	public const int KongsangThrow8 = 10408;

	public const int KongsangAgile0 = 10500;

	public const int KongsangAgile1 = 10501;

	public const int KongsangAgile2 = 10502;

	public const int KongsangAgile3 = 10503;

	public const int KongsangAgile4 = 10504;

	public const int KongsangDefense3 = 10603;

	public const int KongsangDefense7 = 10607;

	public const int KongsangAssist0 = 10700;

	public const int KongsangAssist1 = 10701;

	public const int KongsangAssist2 = 10702;

	public const int KongsangAssist4 = 10704;

	public const int KongsangAssist5 = 10705;

	public const int KongsangAssist6 = 10706;

	public const int KongsangAssist8 = 10708;

	public const int JingangNeigong0 = 11000;

	public const int JingangNeigong1 = 11001;

	public const int JingangNeigong2 = 11002;

	public const int JingangNeigong3 = 11003;

	public const int JingangNeigong4 = 11004;

	public const int JingangNeigong5 = 11005;

	public const int JingangNeigong6 = 11006;

	public const int JingangNeigong7 = 11007;

	public const int JingangNeigong8 = 11008;

	public const int JingangFistAndPalm0 = 11100;

	public const int JingangFistAndPalm1 = 11101;

	public const int JingangFistAndPalm2 = 11102;

	public const int JingangFistAndPalm3 = 11103;

	public const int JingangFistAndPalm4 = 11104;

	public const int JingangFistAndPalm5 = 11105;

	public const int JingangFistAndPalm6 = 11106;

	public const int JingangFistAndPalm7 = 11107;

	public const int JingangBlade0 = 11200;

	public const int JingangBlade1 = 11201;

	public const int JingangBlade2 = 11202;

	public const int JingangBlade3 = 11203;

	public const int JingangBlade4 = 11204;

	public const int JingangBlade5 = 11205;

	public const int JingangBlade6 = 11206;

	public const int JingangBlade7 = 11207;

	public const int JingangBlade8 = 11208;

	public const int JingangSpecial0 = 11300;

	public const int JingangSpecial1 = 11301;

	public const int JingangSpecial2 = 11302;

	public const int JingangSpecial3 = 11303;

	public const int JingangSpecial4 = 11304;

	public const int JingangSpecial5 = 11305;

	public const int JingangSpecial6 = 11306;

	public const int JingangSpecial7 = 11307;

	public const int JingangAgile0 = 11500;

	public const int JingangAgile1 = 11501;

	public const int JingangAgile2 = 11502;

	public const int JingangAgile3 = 11503;

	public const int JingangDefense1 = 11601;

	public const int JingangDefense2 = 11602;

	public const int JingangDefense4 = 11604;

	public const int JingangDefense5 = 11605;

	public const int JingangDefense7 = 11607;

	public const int JingangAssist0 = 11700;

	public const int JingangAssist3 = 11703;

	public const int JingangAssist6 = 11706;

	public const int WuxianNeigong0 = 12000;

	public const int WuxianNeigong1 = 12001;

	public const int WuxianNeigong2 = 12002;

	public const int WuxianNeigong3 = 12003;

	public const int WuxianNeigong4 = 12004;

	public const int WuxianNeigong5 = 12005;

	public const int WuxianNeigong6 = 12006;

	public const int WuxianFistAndPalm0 = 12100;

	public const int WuxianFistAndPalm1 = 12101;

	public const int WuxianFistAndPalm2 = 12102;

	public const int WuxianFistAndPalm3 = 12103;

	public const int WuxianFistAndPalm4 = 12104;

	public const int WuxianFistAndPalm5 = 12105;

	public const int WuxianFistAndPalm6 = 12106;

	public const int WuxianFistAndPalm7 = 12107;

	public const int WuxianFinger0 = 12200;

	public const int WuxianFinger1 = 12201;

	public const int WuxianFinger2 = 12202;

	public const int WuxianFinger3 = 12203;

	public const int WuxianFinger4 = 12204;

	public const int WuxianFinger5 = 12205;

	public const int WuxianFinger6 = 12206;

	public const int WuxianFinger7 = 12207;

	public const int WuxianFinger8 = 12208;

	public const int WuxianSword0 = 12300;

	public const int WuxianSword1 = 12301;

	public const int WuxianSword2 = 12302;

	public const int WuxianSword3 = 12303;

	public const int WuxianSword4 = 12304;

	public const int WuxianSword5 = 12305;

	public const int WuxianSword6 = 12306;

	public const int WuxianWhip0 = 12400;

	public const int WuxianWhip1 = 12401;

	public const int WuxianWhip2 = 12402;

	public const int WuxianWhip3 = 12403;

	public const int WuxianWhip4 = 12404;

	public const int WuxianWhip5 = 12405;

	public const int WuxianWhip6 = 12406;

	public const int WuxianWhip7 = 12407;

	public const int WuxianWhip8 = 12408;

	public const int WuXianRedEyeGrowingGood1 = 12500;

	public const int WuXianRedEyeGrowingGood2 = 12501;

	public const int WuXianRedEyeGrowingBad1 = 12502;

	public const int WuXianRedEyeGrowingBad2 = 12503;

	public const int WuXianRedEyeGrown = 12504;

	public const int WuXianForestSpiritGrowingGood1 = 12505;

	public const int WuXianForestSpiritGrowingGood2 = 12506;

	public const int WuXianForestSpiritGrowingBad1 = 12507;

	public const int WuXianForestSpiritGrowingBad2 = 12508;

	public const int WuXianForestSpiritGrown = 12509;

	public const int WuXianBlackBloodGrowingGood1 = 12510;

	public const int WuXianBlackBloodGrowingGood2 = 12511;

	public const int WuXianBlackBloodGrowingBad1 = 12512;

	public const int WuXianBlackBloodGrowingBad2 = 12513;

	public const int WuXianBlackBloodGrown = 12514;

	public const int WuXianDevilInsideGrowingGood1 = 12515;

	public const int WuXianDevilInsideGrowingGood2 = 12516;

	public const int WuXianDevilInsideGrowingBad1 = 12517;

	public const int WuXianDevilInsideGrowingBad2 = 12518;

	public const int WuXianDevilInsideGrown = 12519;

	public const int WuXianCorpseWormGrowingGood1 = 12520;

	public const int WuXianCorpseWormGrowingGood2 = 12521;

	public const int WuXianCorpseWormGrowingBad1 = 12522;

	public const int WuXianCorpseWormGrowingBad2 = 12523;

	public const int WuXianCorpseWormGrown = 12524;

	public const int WuXianIceSilkwormGrowingGood1 = 12525;

	public const int WuXianIceSilkwormGrowingGood2 = 12526;

	public const int WuXianIceSilkwormGrowingBad1 = 12527;

	public const int WuXianIceSilkwormGrowingBad2 = 12528;

	public const int WuXianIceSilkwormGrown = 12529;

	public const int WuXianGoldenSilkwormGrowingGood1 = 12530;

	public const int WuXianGoldenSilkwormGrowingGood2 = 12531;

	public const int WuXianGoldenSilkwormGrowingBad1 = 12532;

	public const int WuXianGoldenSilkwormGrowingBad2 = 12533;

	public const int WuXianGoldenSilkwormGrown = 12534;

	public const int WuXianAzureMarrowGrowingGood1 = 12535;

	public const int WuXianAzureMarrowGrowingGood2 = 12536;

	public const int WuXianAzureMarrowGrowingBad1 = 12537;

	public const int WuXianAzureMarrowGrowingBad2 = 12538;

	public const int WuXianAzureMarrowGrown = 12539;

	public const int WuXianRedEyeKing = 12540;

	public const int WuXianForestSpiritKing = 12541;

	public const int WuXianBlackBloodKing = 12542;

	public const int WuXianDevilInsideKing = 12543;

	public const int WuXianCorpseWormKing = 12544;

	public const int WuXianIceSilkwormKing = 12545;

	public const int WuXianGoldenSilkwormKing = 12546;

	public const int WuXianAzureMarrowKing = 12547;

	public const int WuxianAgile0 = 12600;

	public const int WuxianAgile1 = 12601;

	public const int WuxianAgile2 = 12602;

	public const int WuxianAgile3 = 12603;

	public const int WuxianAgile4 = 12604;

	public const int WuxianAgile5 = 12605;

	public const int WuxianAgile6 = 12606;

	public const int WuxianDefense1 = 12701;

	public const int WuxianDefense3 = 12703;

	public const int WuxianDefense4 = 12704;

	public const int WuxianDefense5 = 12705;

	public const int WuxianDefense7 = 12707;

	public const int WuxianAssist0 = 12800;

	public const int WuxianAssist2 = 12802;

	public const int WuxianAssist6 = 12806;

	public const int WuxianAssist8 = 12808;

	public const int JieqingNeigong0 = 13000;

	public const int JieqingNeigong1 = 13001;

	public const int JieqingNeigong2 = 13002;

	public const int JieqingNeigong3 = 13003;

	public const int JieqingNeigong4 = 13004;

	public const int JieqingNeigong5 = 13005;

	public const int JieqingNeigong6 = 13006;

	public const int JieqingFinger0 = 13100;

	public const int JieqingFinger1 = 13101;

	public const int JieqingFinger2 = 13102;

	public const int JieqingFinger3 = 13103;

	public const int JieqingFinger4 = 13104;

	public const int JieqingFinger5 = 13105;

	public const int JieqingFinger6 = 13106;

	public const int JieqingFinger7 = 13107;

	public const int JieqingFinger8 = 13108;

	public const int JieqingSword0 = 13200;

	public const int JieqingSword1 = 13201;

	public const int JieqingSword2 = 13202;

	public const int JieqingSword3 = 13203;

	public const int JieqingSword4 = 13204;

	public const int JieqingSword5 = 13205;

	public const int JieqingSword6 = 13206;

	public const int JieqingSword7 = 13207;

	public const int JieqingThrow0 = 13300;

	public const int JieqingThrow1 = 13301;

	public const int JieqingThrow2 = 13302;

	public const int JieqingThrow3 = 13303;

	public const int JieqingThrow4 = 13304;

	public const int JieqingThrow5 = 13305;

	public const int JieqingThrow6 = 13306;

	public const int JieqingThrow7 = 13307;

	public const int JieqingThrow8 = 13308;

	public const int JieqingAgile0 = 13400;

	public const int JieqingAgile1 = 13401;

	public const int JieqingAgile2 = 13402;

	public const int JieqingAgile3 = 13403;

	public const int JieqingAgile4 = 13404;

	public const int JieqingAgile5 = 13405;

	public const int JieqingAgile6 = 13406;

	public const int JieqingAgile7 = 13407;

	public const int JieqingAgile8 = 13408;

	public const int JieqingDefense1 = 13501;

	public const int JieqingDefense2 = 13502;

	public const int JieqingDefense3 = 13503;

	public const int JieqingDefense6 = 13506;

	public const int JieqingAssist0 = 13600;

	public const int JieqingAssist4 = 13604;

	public const int JieqingAssist5 = 13605;

	public const int FulongNeigong0 = 14000;

	public const int FulongNeigong1 = 14001;

	public const int FulongNeigong2 = 14002;

	public const int FulongNeigong3 = 14003;

	public const int FulongNeigong4 = 14004;

	public const int FulongNeigong5 = 14005;

	public const int FulongNeigong6 = 14006;

	public const int FulongNeigong7 = 14007;

	public const int FulongFistAndPalm0 = 14100;

	public const int FulongFistAndPalm1 = 14101;

	public const int FulongFistAndPalm2 = 14102;

	public const int FulongFistAndPalm3 = 14103;

	public const int FulongFistAndPalm4 = 14104;

	public const int FulongFistAndPalm5 = 14105;

	public const int FulongFistAndPalm6 = 14106;

	public const int FulongFistAndPalm7 = 14107;

	public const int FulongFistAndPalm8 = 14108;

	public const int FulongBlade0 = 14200;

	public const int FulongBlade1 = 14201;

	public const int FulongBlade2 = 14202;

	public const int FulongBlade3 = 14203;

	public const int FulongBlade4 = 14204;

	public const int FulongBlade5 = 14205;

	public const int FulongBlade6 = 14206;

	public const int FulongBlade7 = 14207;

	public const int FulongThrow0 = 14300;

	public const int FulongThrow1 = 14301;

	public const int FulongThrow2 = 14302;

	public const int FulongThrow3 = 14303;

	public const int FulongThrow4 = 14304;

	public const int FulongThrow5 = 14305;

	public const int FulongAgile0 = 14400;

	public const int FulongAgile1 = 14401;

	public const int FulongAgile2 = 14402;

	public const int FulongAgile3 = 14403;

	public const int FulongAgile4 = 14404;

	public const int FulongAgile5 = 14405;

	public const int FulongDefense1 = 14501;

	public const int FulongDefense2 = 14502;

	public const int FulongDefense4 = 14504;

	public const int FulongDefense7 = 14507;

	public const int FulongAssist0 = 14600;

	public const int FulongAssist3 = 14603;

	public const int FulongAssist5 = 14605;

	public const int FulongAssist6 = 14606;

	public const int XuehouNeigong0 = 15000;

	public const int XuehouNeigong1 = 15001;

	public const int XuehouNeigong2 = 15002;

	public const int XuehouNeigong3 = 15003;

	public const int XuehouNeigong4 = 15004;

	public const int XuehouNeigong5 = 15005;

	public const int XuehouNeigong6 = 15006;

	public const int XuehouNeigong7 = 15007;

	public const int XuehouNeigong8 = 15008;

	public const int XuehouFistAndPalm0 = 15100;

	public const int XuehouFistAndPalm1 = 15101;

	public const int XuehouFistAndPalm2 = 15102;

	public const int XuehouFistAndPalm3 = 15103;

	public const int XuehouFistAndPalm4 = 15104;

	public const int XuehouFistAndPalm5 = 15105;

	public const int XuehouFistAndPalm6 = 15106;

	public const int XuehouFistAndPalm7 = 15107;

	public const int XuehouFinger0 = 15200;

	public const int XuehouFinger1 = 15201;

	public const int XuehouFinger2 = 15202;

	public const int XuehouFinger3 = 15203;

	public const int XuehouFinger4 = 15204;

	public const int XuehouFinger5 = 15205;

	public const int XuehouFinger6 = 15206;

	public const int XuehouLeg0 = 15300;

	public const int XuehouLeg1 = 15301;

	public const int XuehouLeg2 = 15302;

	public const int XuehouLeg3 = 15303;

	public const int XuehouLeg4 = 15304;

	public const int XuehouLeg5 = 15305;

	public const int XuehouLeg6 = 15306;

	public const int XuehouLeg7 = 15307;

	public const int XuehouThrow0 = 15400;

	public const int XuehouThrow1 = 15401;

	public const int XuehouThrow2 = 15402;

	public const int XuehouThrow3 = 15403;

	public const int XuehouThrow4 = 15404;

	public const int XuehouThrow5 = 15405;

	public const int XuehouThrow6 = 15406;

	public const int XuehouChestCrash = 15500;

	public const int XuehouChestHurt = 15501;

	public const int XuehouBellyCrash = 15502;

	public const int XuehouBellyHurt = 15503;

	public const int XuehouHeadCrash = 15504;

	public const int XuehouHeadHurt = 15505;

	public const int XuehouHandCrash = 15506;

	public const int XuehouHandHurt = 15507;

	public const int XuehouLegCrash = 15508;

	public const int XuehouLegHurt = 15509;

	public const int XuehouAgile0 = 15600;

	public const int XuehouAgile1 = 15601;

	public const int XuehouAgile2 = 15602;

	public const int XuehouAgile3 = 15603;

	public const int XuehouAgile4 = 15604;

	public const int XuehouDefense0 = 15700;

	public const int XuehouDefense2 = 15702;

	public const int XuehouDefense4 = 15704;

	public const int XuehouDefense7 = 15707;

	public const int XuehouAssist1 = 15801;

	public const int XuehouAssist3 = 15803;

	public const int XuehouAssist5 = 15805;

	public const int XuehouAssist6 = 15806;

	public const int XuehouAssist8 = 15808;

	public const int XiangshuRandomEnemyNeigong0 = 16000;

	public const int XiangshuRandomEnemyNeigong1 = 16001;

	public const int XiangshuRandomEnemyNeigong2 = 16002;

	public const int XiangshuRandomEnemyNeigong3 = 16003;

	public const int XiangshuRandomEnemyNeigong4 = 16004;

	public const int XiangshuRandomEnemyNeigong5 = 16005;

	public const int XiangshuRandomEnemyNeigong6 = 16006;

	public const int XiangshuRandomEnemyNeigong7 = 16007;

	public const int XiangshuRandomEnemyNeigong8 = 16008;

	public const int XiangshuBossNeigong0 = 16100;

	public const int XiangshuBossNeigong1 = 16101;

	public const int XiangshuBossNeigong2 = 16102;

	public const int XiangshuBossNeigong3 = 16103;

	public const int XiangshuBossNeigong4 = 16104;

	public const int XiangshuBossNeigong5 = 16105;

	public const int XiangshuBossNeigong6 = 16106;

	public const int XiangshuBossNeigong7 = 16107;

	public const int XiangshuBossNeigong8 = 16108;

	public const int XiangshuBossNeigong9 = 16109;

	public const int XiangshuBossNeigong10 = 16110;

	public const int XiangshuBossNeigong11 = 16111;

	public const int XiangshuBossNeigong12 = 16112;

	public const int XiangshuBossNeigong13 = 16113;

	public const int XiangshuBossAgile0 = 16200;

	public const int XiangshuBossAgile1 = 16201;

	public const int XiangshuBossAgile2 = 16202;

	public const int XiangshuBossAgile3 = 16203;

	public const int XiangshuBossAgile4 = 16204;

	public const int XiangshuBossAgile5 = 16205;

	public const int XiangshuBossAgile6 = 16206;

	public const int XiangshuBossAgile7 = 16207;

	public const int XiangshuBossAgile8 = 16208;

	public const int XiangshuBossAgile9 = 16209;

	public const int XiangshuBossAgile10 = 16210;

	public const int XiangshuBossAgile11 = 16211;

	public const int XiangshuBossAgile12 = 16212;

	public const int XiangshuBossAgile13 = 16213;

	public const int XiangshuBossDefense0 = 16300;

	public const int XiangshuBossDefense1 = 16301;

	public const int XiangshuBossDefense2 = 16302;

	public const int XiangshuBossDefense3 = 16303;

	public const int XiangshuBossDefense4 = 16304;

	public const int XiangshuBossDefense5 = 16305;

	public const int XiangshuBossDefense6 = 16306;

	public const int XiangshuBossDefense7 = 16307;

	public const int XiangshuBossDefense8 = 16308;

	public const int XiangshuBossDefense9 = 16309;

	public const int XiangshuBossDefense10 = 16310;

	public const int XiangshuBossDefense11 = 16311;

	public const int XiangshuBossDefense12 = 16312;

	public const int XiangshuBossDefense13 = 16313;

	public const int XiangshuBossAssist0 = 16400;

	public const int XiangshuBossAssist1 = 16401;

	public const int XiangshuBossAssist2 = 16402;

	public const int XiangshuBossAssist3 = 16403;

	public const int XiangshuBossAssist4 = 16404;

	public const int XiangshuBossAssist5 = 16405;

	public const int XiangshuBossAssist6 = 16406;

	public const int XiangshuBossAssist7 = 16407;

	public const int XiangshuBossAssist8 = 16408;

	public const int XiangshuBossAssist9 = 16409;

	public const int XiangshuBossAssist10 = 16410;

	public const int XiangshuBossAssist11 = 16411;

	public const int XiangshuBossAssist12 = 16412;

	public const int XiangshuBossAssist13 = 16413;

	public const int XiangshuBossAssist14 = 16414;

	public const int XiangshuBossAssist15 = 16415;

	public const int XiangshuBossAssist16 = 16416;

	public const int XiangshuBossAssist17 = 16417;

	public const int XiangshuBossAssist18 = 16418;

	public const int XiangshuAttackMoNv0 = 17000;

	public const int XiangshuAttackMoNv1 = 17001;

	public const int XiangshuAttackMoNv2 = 17002;

	public const int XiangshuAttackMoNv3 = 17003;

	public const int XiangshuAttackMoNv4 = 17004;

	public const int XiangshuAttackMoNv5 = 17005;

	public const int XiangshuAttackDaYueYaoChang0 = 17010;

	public const int XiangshuAttackDaYueYaoChang1 = 17011;

	public const int XiangshuAttackDaYueYaoChang2 = 17012;

	public const int XiangshuAttackDaYueYaoChang3 = 17013;

	public const int XiangshuAttackDaYueYaoChang4 = 17014;

	public const int XiangshuAttackDaYueYaoChang5 = 17015;

	public const int XiangshuAttackJiuHan0 = 17020;

	public const int XiangshuAttackJiuHan1 = 17021;

	public const int XiangshuAttackJiuHan2 = 17022;

	public const int XiangshuAttackJiuHan3 = 17023;

	public const int XiangshuAttackJiuHan4 = 17024;

	public const int XiangshuAttackJiuHan5 = 17025;

	public const int XiangshuAttackJinHuangEr0 = 17030;

	public const int XiangshuAttackJinHuangEr1 = 17031;

	public const int XiangshuAttackJinHuangEr2 = 17032;

	public const int XiangshuAttackJinHuangEr3 = 17033;

	public const int XiangshuAttackJinHuangEr4 = 17034;

	public const int XiangshuAttackJinHuangEr5 = 17035;

	public const int XiangshuAttackYiYiHou0 = 17040;

	public const int XiangshuAttackYiYiHou1 = 17041;

	public const int XiangshuAttackYiYiHou2 = 17042;

	public const int XiangshuAttackYiYiHou3 = 17043;

	public const int XiangshuAttackYiYiHou4 = 17044;

	public const int XiangshuAttackYiYiHou5 = 17045;

	public const int XiangshuAttackWeiQi0 = 17050;

	public const int XiangshuAttackWeiQi1 = 17051;

	public const int XiangshuAttackWeiQi2 = 17052;

	public const int XiangshuAttackWeiQi3 = 17053;

	public const int XiangshuAttackWeiQi4 = 17054;

	public const int XiangshuAttackWeiQi5 = 17055;

	public const int XiangshuAttackYiXiang0 = 17060;

	public const int XiangshuAttackYiXiang1 = 17061;

	public const int XiangshuAttackYiXiang2 = 17062;

	public const int XiangshuAttackYiXiang3 = 17063;

	public const int XiangshuAttackYiXiang4 = 17064;

	public const int XiangshuAttackYiXiang5 = 17065;

	public const int XiangshuAttackXueFeng0 = 17070;

	public const int XiangshuAttackXueFeng1 = 17071;

	public const int XiangshuAttackXueFeng2 = 17072;

	public const int XiangshuAttackXueFeng3 = 17073;

	public const int XiangshuAttackXueFeng4 = 17074;

	public const int XiangshuAttackXueFeng5 = 17075;

	public const int XiangshuAttackShuFang0 = 17080;

	public const int XiangshuAttackShuFang1 = 17081;

	public const int XiangshuAttackShuFang2 = 17082;

	public const int XiangshuAttackShuFang3 = 17083;

	public const int XiangshuAttackShuFang4 = 17084;

	public const int XiangshuAttackShuFang5 = 17085;

	public const int XiangshuAttackXiangShu0 = 17090;

	public const int XiangshuAttackXiangShu1 = 17091;

	public const int XiangshuAttackXiangShu2 = 17092;

	public const int XiangshuAttackXiangShu3 = 17093;

	public const int XiangshuAttackXiangShu4 = 17094;

	public const int XiangshuAttackXiangShu5 = 17095;

	public const int XiangshuAttackHuanXin0 = 17100;

	public const int XiangshuAttackHuanXin1 = 17101;

	public const int XiangshuAttackHuanXin2 = 17102;

	public const int XiangshuAttackHuanXin3 = 17103;

	public const int XiangshuAttackHuanXin4 = 17104;

	public const int XiangshuAttackHuanXin5 = 17105;

	public const int XiangshuAttackZiWuXiao0 = 17110;

	public const int XiangshuAttackZiWuXiao1 = 17111;

	public const int XiangshuAttackZiWuXiao2 = 17112;

	public const int XiangshuAttackZiWuXiao3 = 17113;

	public const int XiangshuAttackZiWuXiao4 = 17114;

	public const int XiangshuAttackZiWuXiao5 = 17115;

	public const int XiangshuAttackLongYuFu0 = 17120;

	public const int XiangshuAttackLongYuFu1 = 17121;

	public const int XiangshuAttackLongYuFu2 = 17122;

	public const int XiangshuAttackLongYuFu3 = 17123;

	public const int XiangshuAttackLongYuFu4 = 17124;

	public const int XiangshuAttackLongYuFu5 = 17125;

	public const int XiangshuAttackRanChenZi0 = 17130;

	public const int XiangshuAttackRanChenZi1 = 17131;

	public const int XiangshuAttackRanChenZi2 = 17132;

	public const int XiangshuAttackRanChenZi3 = 17133;

	public const int XiangshuAttackRanChenZi4 = 17134;

	public const int XiangshuAttackRanChenZi5 = 17135;

	public const int XiangshuAttackRanChenZi3Assist = 17136;

	public const int TwelveImmortalsNeigong0 = 18000;

	public const int TwelveImmortalsNeigong1 = 18001;

	public const int TwelveImmortalsNeigong2 = 18002;

	public const int TwelveImmortalsNeigong3 = 18003;

	public const int TwelveImmortalsNeigong4 = 18004;

	public const int TwelveImmortalsNeigong5 = 18005;

	public const int TwelveImmortalsNeigong6 = 18006;

	public const int TwelveImmortalsNeigong7 = 18007;

	public const int TwelveImmortalsNeigong8 = 18008;

	public const int TwelveImmortalsNeigong9 = 18009;

	public const int TwelveImmortalsNeigong10 = 18010;

	public const int TwelveImmortalsNeigong11 = 18011;

	public const int ReduceEnemyAvoid0 = 30000;

	public const int ReduceEnemyAvoid1 = 30001;

	public const int ReduceEnemyAvoid2 = 30002;

	public const int ReduceEnemyAvoid3 = 30003;

	public const int ReduceEnemyAvoid4 = 30004;

	public const int ReduceEnemyAvoid5 = 30005;

	public const int ReduceEnemyAvoid6 = 30006;

	public const int ReduceEnemyAvoid7 = 30007;

	public const int ReduceEnemyAvoid8 = 30008;

	public const int ReduceEnemyPenetrateResist0 = 30009;

	public const int ReduceEnemyPenetrateResist1 = 30010;

	public const int ReduceEnemyPenetrateResist2 = 30011;

	public const int ReduceEnemyPenetrateResist3 = 30012;

	public const int ReduceBounceOuter = 30013;

	public const int ReduceBounceInner = 30014;

	public const int BreakAddOuterInjury = 30015;

	public const int BreakAddInnerInjury = 30016;

	public const int WeaponAddPoison = 30017;

	public const int ReduceEnemyHit0 = 30100;

	public const int ReduceEnemyHit1 = 30101;

	public const int ReduceEnemyHit2 = 30102;

	public const int ReduceEnemyHit3 = 30103;

	public const int ReduceEnemyHit4 = 30104;

	public const int ReduceEnemyHit5 = 30105;

	public const int ReduceEnemyHit6 = 30106;

	public const int ReduceEnemyHit7 = 30107;

	public const int ReduceEnemyHit8 = 30108;

	public const int ReduceEnemyPenetrate0 = 30109;

	public const int ReduceEnemyPenetrate1 = 30110;

	public const int ReduceEnemyPenetrate2 = 30111;

	public const int ReduceEnemyPenetrate3 = 30112;

	public const int AddBounceOuter = 30113;

	public const int AddBounceInner = 30114;

	public const int BreakReduceOuterInjury = 30115;

	public const int BreakReduceInnerInjury = 30116;

	public const int ArmorAddPoison = 30117;

	public const int RawCreate0 = 30200;

	public const int RawCreate1 = 30201;

	public const int RawCreate2 = 30202;

	public const int RawCreate3 = 30203;

	public const int RawCreate4 = 30204;

	public const int RawCreate5 = 30205;

	public const int LegendaryBookNeigongWeapon = 40000;

	public const int LegendaryBookNeigongSkill0 = 40001;

	public const int LegendaryBookNeigongSkill1 = 40002;

	public const int LegendaryBookNeigongSkill2 = 40003;

	public const int LegendaryBookNeigongSkill3 = 40004;

	public const int LegendaryBookNeigongSkill4 = 40005;

	public const int LegendaryBookNeigongSkill5 = 40006;

	public const int LegendaryBookNeigongSkill6 = 40007;

	public const int LegendaryBookNeigongSkill7 = 40008;

	public const int LegendaryBookNeigongSkill8 = 40009;

	public const int LegendaryBookPosingWeapon = 40100;

	public const int LegendaryBookPosingSkill0 = 40101;

	public const int LegendaryBookPosingSkill1 = 40102;

	public const int LegendaryBookPosingSkill2 = 40103;

	public const int LegendaryBookPosingSkill3 = 40104;

	public const int LegendaryBookPosingSkill4 = 40105;

	public const int LegendaryBookPosingSkill5 = 40106;

	public const int LegendaryBookPosingSkill6 = 40107;

	public const int LegendaryBookPosingSkill7 = 40108;

	public const int LegendaryBookPosingSkill8 = 40109;

	public const int LegendaryBookStuntWeapon = 40200;

	public const int LegendaryBookStuntSkill0 = 40201;

	public const int LegendaryBookStuntSkill1 = 40202;

	public const int LegendaryBookStuntSkill2 = 40203;

	public const int LegendaryBookStuntSkill3 = 40204;

	public const int LegendaryBookStuntSkill4 = 40205;

	public const int LegendaryBookStuntSkill5 = 40206;

	public const int LegendaryBookStuntSkill6 = 40207;

	public const int LegendaryBookStuntSkill7 = 40208;

	public const int LegendaryBookStuntSkill8 = 40209;

	public const int LegendaryBookFistAndPalmWeapon = 40300;

	public const int LegendaryBookFistAndPalmSkill0 = 40301;

	public const int LegendaryBookFistAndPalmSkill1 = 40302;

	public const int LegendaryBookFistAndPalmSkill2 = 40303;

	public const int LegendaryBookFistAndPalmSkill3 = 40304;

	public const int LegendaryBookFistAndPalmSkill4 = 40305;

	public const int LegendaryBookFistAndPalmSkill5 = 40306;

	public const int LegendaryBookFistAndPalmSkill6 = 40307;

	public const int LegendaryBookFistAndPalmSkill7 = 40308;

	public const int LegendaryBookFistAndPalmSkill8 = 40309;

	public const int LegendaryBookFingerWeapon = 40400;

	public const int LegendaryBookFingerSkill0 = 40401;

	public const int LegendaryBookFingerSkill1 = 40402;

	public const int LegendaryBookFingerSkill2 = 40403;

	public const int LegendaryBookFingerSkill3 = 40404;

	public const int LegendaryBookFingerSkill4 = 40405;

	public const int LegendaryBookFingerSkill5 = 40406;

	public const int LegendaryBookFingerSkill6 = 40407;

	public const int LegendaryBookFingerSkill7 = 40408;

	public const int LegendaryBookFingerSkill8 = 40409;

	public const int LegendaryBookLegWeapon = 40500;

	public const int LegendaryBookLegSkill0 = 40501;

	public const int LegendaryBookLegSkill1 = 40502;

	public const int LegendaryBookLegSkill2 = 40503;

	public const int LegendaryBookLegSkill3 = 40504;

	public const int LegendaryBookLegSkill4 = 40505;

	public const int LegendaryBookLegSkill5 = 40506;

	public const int LegendaryBookLegSkill6 = 40507;

	public const int LegendaryBookLegSkill7 = 40508;

	public const int LegendaryBookLegSkill8 = 40509;

	public const int LegendaryBookThrowWeapon = 40600;

	public const int LegendaryBookThrowSkill0 = 40601;

	public const int LegendaryBookThrowSkill1 = 40602;

	public const int LegendaryBookThrowSkill2 = 40603;

	public const int LegendaryBookThrowSkill3 = 40604;

	public const int LegendaryBookThrowSkill4 = 40605;

	public const int LegendaryBookThrowSkill5 = 40606;

	public const int LegendaryBookThrowSkill6 = 40607;

	public const int LegendaryBookThrowSkill7 = 40608;

	public const int LegendaryBookThrowSkill8 = 40609;

	public const int LegendaryBookSwordWeapon = 40700;

	public const int LegendaryBookSwordSkill0 = 40701;

	public const int LegendaryBookSwordSkill1 = 40702;

	public const int LegendaryBookSwordSkill2 = 40703;

	public const int LegendaryBookSwordSkill3 = 40704;

	public const int LegendaryBookSwordSkill4 = 40705;

	public const int LegendaryBookSwordSkill5 = 40706;

	public const int LegendaryBookSwordSkill6 = 40707;

	public const int LegendaryBookSwordSkill7 = 40708;

	public const int LegendaryBookSwordSkill8 = 40709;

	public const int LegendaryBookBladeWeapon = 40800;

	public const int LegendaryBookBladeSkill0 = 40801;

	public const int LegendaryBookBladeSkill1 = 40802;

	public const int LegendaryBookBladeSkill2 = 40803;

	public const int LegendaryBookBladeSkill3 = 40804;

	public const int LegendaryBookBladeSkill4 = 40805;

	public const int LegendaryBookBladeSkill5 = 40806;

	public const int LegendaryBookBladeSkill6 = 40807;

	public const int LegendaryBookBladeSkill7 = 40808;

	public const int LegendaryBookBladeSkill8 = 40809;

	public const int LegendaryBookPolearmWeapon = 40900;

	public const int LegendaryBookPolearmSkill0 = 40901;

	public const int LegendaryBookPolearmSkill1 = 40902;

	public const int LegendaryBookPolearmSkill2 = 40903;

	public const int LegendaryBookPolearmSkill3 = 40904;

	public const int LegendaryBookPolearmSkill4 = 40905;

	public const int LegendaryBookPolearmSkill5 = 40906;

	public const int LegendaryBookPolearmSkill6 = 40907;

	public const int LegendaryBookPolearmSkill7 = 40908;

	public const int LegendaryBookPolearmSkill8 = 40909;

	public const int LegendaryBookSpecialWeapon = 41000;

	public const int LegendaryBookSpecialSkill0 = 41001;

	public const int LegendaryBookSpecialSkill1 = 41002;

	public const int LegendaryBookSpecialSkill2 = 41003;

	public const int LegendaryBookSpecialSkill3 = 41004;

	public const int LegendaryBookSpecialSkill4 = 41005;

	public const int LegendaryBookSpecialSkill5 = 41006;

	public const int LegendaryBookSpecialSkill6 = 41007;

	public const int LegendaryBookSpecialSkill7 = 41008;

	public const int LegendaryBookSpecialSkill8 = 41009;

	public const int LegendaryBookWhipWeapon = 41100;

	public const int LegendaryBookWhipSkill0 = 41101;

	public const int LegendaryBookWhipSkill1 = 41102;

	public const int LegendaryBookWhipSkill2 = 41103;

	public const int LegendaryBookWhipSkill3 = 41104;

	public const int LegendaryBookWhipSkill4 = 41105;

	public const int LegendaryBookWhipSkill5 = 41106;

	public const int LegendaryBookWhipSkill6 = 41107;

	public const int LegendaryBookWhipSkill7 = 41108;

	public const int LegendaryBookWhipSkill8 = 41109;

	public const int LegendaryBookControllableShotWeapon = 41200;

	public const int LegendaryBookControllableShotSkill0 = 41201;

	public const int LegendaryBookControllableShotSkill1 = 41202;

	public const int LegendaryBookControllableShotSkill2 = 41203;

	public const int LegendaryBookControllableShotSkill3 = 41204;

	public const int LegendaryBookControllableShotSkill4 = 41205;

	public const int LegendaryBookControllableShotSkill5 = 41206;

	public const int LegendaryBookControllableShotSkill6 = 41207;

	public const int LegendaryBookControllableShotSkill7 = 41208;

	public const int LegendaryBookControllableShotSkill8 = 41209;

	public const int LegendaryBookCombatMusicWeapon = 41300;

	public const int LegendaryBookCombatMusicSkill0 = 41301;

	public const int LegendaryBookCombatMusicSkill1 = 41302;

	public const int LegendaryBookCombatMusicSkill2 = 41303;

	public const int LegendaryBookCombatMusicSkill3 = 41304;

	public const int LegendaryBookCombatMusicSkill4 = 41305;

	public const int LegendaryBookCombatMusicSkill5 = 41306;

	public const int LegendaryBookCombatMusicSkill6 = 41307;

	public const int LegendaryBookCombatMusicSkill7 = 41308;

	public const int LegendaryBookCombatMusicSkill8 = 41309;

	public const int LegendaryBookNpcNeigong = 41400;

	public const int LegendaryBookNpcPosing = 41401;

	public const int LegendaryBookNpcStunt = 41402;

	public const int LegendaryBookNpcFistAndPalm = 41403;

	public const int LegendaryBookNpcFinger = 41404;

	public const int LegendaryBookNpcLeg = 41405;

	public const int LegendaryBookNpcThrow = 41406;

	public const int LegendaryBookNpcSword = 41407;

	public const int LegendaryBookNpcBlade = 41408;

	public const int LegendaryBookNpcPolearm = 41409;

	public const int LegendaryBookNpcSpecial = 41410;

	public const int LegendaryBookNpcWhip = 41411;

	public const int LegendaryBookNpcControllableShot = 41412;

	public const int LegendaryBookNpcCombatMusic = 41413;

	public const int SectStoryMysteryEffectShaolin = 50000;

	public const int SectStoryMysteryEffectEmei = 50001;

	public const int SectStoryMysteryEffectBaihua = 50002;

	public const int SectStoryMysteryEffectWudang = 50003;

	public const int SectStoryMysteryEffectYuanshan = 50004;

	public const int SectStoryMysteryEffectShixiang = 50005;

	public const int SectStoryMysteryEffectRanshan = 50006;

	public const int SectStoryMysteryEffectXuannv = 50007;

	public const int SectStoryMysteryEffectZhujian = 50008;

	public const int SectStoryMysteryEffectKongsang = 50009;

	public const int SectStoryMysteryEffectJingang = 50010;

	public const int SectStoryMysteryEffectWuxian = 50011;

	public const int SectStoryMysteryEffectJieqing = 50012;

	public const int SectStoryMysteryEffectFulong = 50013;

	public const int SectStoryMysteryEffectXuehou = 50014;

	public const int SectStoryMysteryEffectShaolinSuper = 50100;

	public const int SectStoryMysteryEffectEmeiSuper = 50101;

	public const int SectStoryMysteryEffectBaihuaSuper = 50102;

	public const int SectStoryMysteryEffectWudangSuper = 50103;

	public const int SectStoryMysteryEffectYuanshanSuper = 50104;

	public const int SectStoryMysteryEffectShixiangSuper = 50105;

	public const int SectStoryMysteryEffectRanshanSuper = 50106;

	public const int SectStoryMysteryEffectXuannvSuper = 50107;

	public const int SectStoryMysteryEffectZhujianSuper = 50108;

	public const int SectStoryMysteryEffectKongsangSuper = 50109;

	public const int SectStoryMysteryEffectJingangSuper = 50110;

	public const int SectStoryMysteryEffectWuxianSuper = 50111;

	public const int SectStoryMysteryEffectJieqingSuper = 50112;

	public const int SectStoryMysteryEffectFulongSuper = 50113;

	public const int SectStoryMysteryEffectXuehouSuper = 50114;

	public const int AdventureFeature0 = 100000;

	public const int AdventureFeature1 = 100001;

	public const int AdventureFeature2 = 100002;

	public const int AdventureFeature3 = 100003;

	public const int AdventureFeature4 = 100004;

	public const int AddPenetrateAndPenetrateResist = 1000000;

	public const int AddMaxHealth = 1000001;

	public static SpecialEffectBase CreateEffectObj(int type)
	{
		if (type < 0)
		{
			return SpecialEffectBase.Invalid;
		}
		return type switch
		{
			0 => new PeiRanJue(), 
			100 => new TaiZuChangQuan(), 
			200 => new XiaoZongYueGong(), 
			300 => new ShuiHuoYingQiGong(), 
			1000 => new JingChanGong(), 
			1001 => new LuoHanGong(), 
			1002 => new XinYiQiHunYuanGong(), 
			1003 => new WuSeChanGong(), 
			1004 => new PuTiXinXiuFa(), 
			1005 => new ZaAHanJing(), 
			1006 => new ALuoHanShenGong(), 
			1007 => new YiJinJing(), 
			1008 => new XiSuiJing(), 
			1100 => new ShaoLinChangQuan(), 
			1101 => new ShaoLinJinGangZhang(), 
			1102 => new DaTongBiQuan(), 
			1103 => new LiuShiBaShiLuoHanQuan(), 
			1104 => new DaJinGangQuan(), 
			1105 => new DaMoShiBaShou(), 
			1106 => new JinGangBoReZhang(), 
			1107 => new XiangMoGuangMingQuan(), 
			1200 => new ShaoLinFuHuZhua(), 
			1201 => new ShaoLinYiZhiChan(), 
			1202 => new NianHuaZhiGong(), 
			1203 => new DaLiJinGangZhi(), 
			1204 => new NieZhuanJinGangQuan(), 
			1205 => new ShaoLinLongZhuaShou(), 
			1300 => new ShaoLinLiuHeGun(), 
			1301 => new ShaoLinYinYangGun(), 
			1302 => new ShiBaDianQiMeiGun(), 
			1303 => new DaXiaoYeChaGun(), 
			1304 => new WuHuQunYangGun(), 
			1305 => new ShaoLinFengMoGun(), 
			1306 => new WeiTuoXiangMoZhang(), 
			1307 => new DaZhiPuTiZhangFa(), 
			1308 => new DaMoZhangFa(), 
			1400 => new ChuanZongGong(), 
			1401 => new BiHuYouQiangGong(), 
			1402 => new QingShenShu(), 
			1403 => new DaFanTengShu(), 
			1404 => new JiuTuLiuZuoXiang(), 
			1405 => new YiWeiDuJiang(), 
			1501 => new ZhanYiShiBaDie(), 
			1502 => new QianJinZhui(), 
			1504 => new JinZhongZhao(), 
			1507 => new HunYuanYiQiGong(), 
			1508 => new JinGangHuTiShenGong(), 
			1600 => new WoHuGong(), 
			1603 => new BianTiTongRenFa(), 
			1605 => new XiaoLuoHanGunZhen(), 
			1606 => new FoMenShiZiHou(), 
			2000 => new DanTianKaiHeGong(), 
			2001 => new EMeiShiErZhuang(), 
			2002 => new XianTianYiYuanQiGong(), 
			2003 => new LingWuGong(), 
			2004 => new LianHuaTaiXuanGong(), 
			2005 => new PuXianXinJing(), 
			2006 => new ZuoWangXuanGong(), 
			2007 => new DaBoNiePanFa(), 
			2100 => new SanShiLiuBiShou(), 
			2101 => new YaXingQuan(), 
			2102 => new ShiErShouLanChanSiQuan(), 
			2103 => new BaiYuanTongBiQuan(), 
			2104 => new YiHuaJieMuShou(), 
			2105 => new TianGangLeiHongZhang(), 
			2106 => new JinGangSanMeiZhang(), 
			2200 => new EMeiYingZhuaGong(), 
			2201 => new EMeiYiZhiChan(), 
			2202 => new BoDaShiBaShi(), 
			2203 => new FenHuaFuLiuShi(), 
			2204 => new GuangXiangZhi(), 
			2205 => new TongShenQianShouFa(), 
			2206 => new DaGuangMingShanYiYuanZhi(), 
			2207 => new TianGangZhiXueFa(), 
			2300 => new FuHuaLveYingJian(), 
			2301 => new YuanGongJianFa(), 
			2302 => new BaiMeiJianFa(), 
			2303 => new LianHuaMiaoJian(), 
			2304 => new YueNvJianFa(), 
			2305 => new CanHongJianShi(), 
			2306 => new YuNvShenJian(), 
			2400 => new WuXingCi(), 
			2401 => new ShiHunCi(), 
			2402 => new MeiRenCi(), 
			2403 => new LingSheCi(), 
			2404 => new HuaYingCi(), 
			2405 => new DingHuiShenZhen(), 
			2406 => new YuNvCi(), 
			2407 => new JinDingXianZhen(), 
			2500 => new TanTuiSuoDi(), 
			2501 => new BaiYuanFeiZongShu(), 
			2502 => new XingWuDingZong(), 
			2503 => new YuNvNuoLian(), 
			2504 => new XingNvZhiLingSuo(), 
			2505 => new QianTanYinYueBu(), 
			2506 => new JinDingFeiXian(), 
			2603 => new JinWuGu(), 
			2606 => new YangXianGongJinShenFa(), 
			2608 => new ShengDengQiWuJue(), 
			2700 => new EMeiHuBuGong(), 
			2701 => new XinWuDingYi(), 
			2702 => new WuHuaBaMen(), 
			2704 => new QingJingGuiYi(), 
			2705 => new SiXiangLianHuaZhen(), 
			2707 => new QiXingHengLian(), 
			3000 => new TongRenShuXueTuJing(), 
			3001 => new JiuZhenShiErYuan(), 
			3002 => new JiaYiQuanPian(), 
			3003 => new NeiJingLingShuPian(), 
			3004 => new JinZhenFaMaiGong(), 
			3100 => new ZhiZhenGong(), 
			3101 => new ChangChunZhi(), 
			3102 => new YiZhiYiPinHong(), 
			3103 => new QingHuaYuMeiRen(), 
			3104 => new ManTianHuaYuShi(), 
			3105 => new DaHuaManTuoLuoZhi(), 
			3106 => new WanHuaLingYueZhi(), 
			3107 => new BaiHuaSha(), 
			3108 => new XueZhuHuaBaFa(), 
			3200 => new YuZhenShu(), 
			3201 => new WuXingMeiHuaZhen(), 
			3202 => new HanBingCiGuFa(), 
			3203 => new BianQueShenZhen(), 
			3204 => new PoYuanChangZhen(), 
			3205 => new ZhenSiBuZhenHuoFa(), 
			3206 => new LiuXianJiuZhenShu(), 
			3207 => new HuaMaiShenZhen(), 
			3208 => new ShiErXianQiZhenGong(), 
			3300 => new YunShuiYin(), 
			3301 => new BuSiGui(), 
			3302 => new FengLaiYi(), 
			3303 => new YuFeiYin(), 
			3304 => new QiongHuaTan(), 
			3305 => new ZangLuLan(), 
			3306 => new TianDiXiao(), 
			3400 => new TiZhenFa(), 
			3401 => new QianNiuHuanShenBu(), 
			3402 => new FeiZhenChuanSuoShu(), 
			3403 => new YuZhenXing(), 
			3404 => new TaXueXunMei(), 
			3405 => new JinZhanXuanSi(), 
			3406 => new ZhiLanYuBu(), 
			3407 => new WanHuaTingYuShi(), 
			3504 => new YinYangMaiNiZhuan(), 
			3505 => new ShiErJingDaNuoYi(), 
			3507 => new XueHaiNingBingShu(), 
			3508 => new WanBiBuPoFa(), 
			3600 => new SanShiLiuShouYiZhenFa(), 
			3601 => new JingYiBiXie(), 
			3602 => new BaiCaoQueZhuoZhi(), 
			3603 => new LuanZhenCuoXue(), 
			3606 => new ShengSiBaMen(), 
			4000 => new WuDangTaiHeGong(), 
			4001 => new BaoYuanShouYi(), 
			4002 => new YiZiHunYuanZhuang(), 
			4003 => new LuoTianZhenJueShiErZhuang(), 
			4004 => new XiSuiJinJing(), 
			4005 => new WuDangHunYuanGong(), 
			4006 => new TaiYiShenGong(), 
			4007 => new ChunYangWuJiGong(), 
			4100 => new WuDangChangQuan(), 
			4101 => new ZhuiFengYunHuanZhang(), 
			4102 => new WuDangMianZhang(), 
			4103 => new YouShenBaGuaZhang(), 
			4104 => new TaiYiXiaoYaoZhang(), 
			4105 => new XuanGongShenQuan(), 
			4106 => new WuDangChunYangQuan(), 
			4107 => new ZiYangZhengQiQuan(), 
			4108 => new TaiJiQuan(), 
			4200 => new WuDangDanJian(), 
			4201 => new WuDangXiaoYaoJian(), 
			4202 => new BaiHongJianFa(), 
			4203 => new TaiYiXuanMenJian(), 
			4204 => new ChunYangJianYi(), 
			4205 => new ZhenWuYouLongJian(), 
			4206 => new TaiJiJianFa(), 
			4207 => new XianTianShaoYangJianQi(), 
			4208 => new WuJiJianShi(), 
			4300 => new FuChenGong(), 
			4301 => new WuDangTieFuChen(), 
			4302 => new LiangYiFuChenGong(), 
			4303 => new LaoJunFuChenGong(), 
			4304 => new CuoDaoYinYangFuChen(), 
			4305 => new TaiYiYunFuGong(), 
			4306 => new WuLiangSaoChenGong(), 
			4307 => new XuanKongShenFu(), 
			4400 => new WuBuMeiHuaZhuang(), 
			4401 => new BaGuaBu(), 
			4402 => new YunHuanBu(), 
			4403 => new TianGangBeiDouBu(), 
			4404 => new TaiYiJiuGongBu(), 
			4405 => new ShangTianTi(), 
			4406 => new LingYunFeiDu(), 
			4500 => new WuDangTieBuShan(), 
			4502 => new YunChuangJiuLian(), 
			4504 => new WuQiChaoYuanGong(), 
			4506 => new WuJiJin(), 
			4601 => new SanCaiJianZhen(), 
			4603 => new YinYangZhouTianFa(), 
			4605 => new ZhenWuDangMoZhen(), 
			4607 => new SanHuaJuDing(), 
			5000 => new TuZhuoNaQingFa(), 
			5001 => new XiaoYuanShanJin(), 
			5002 => new DaYuanShanJin(), 
			5003 => new BuNianXinJue(), 
			5004 => new HunYuanWuXiangGong(), 
			5100 => new YuanShanTanTui(), 
			5101 => new YuanYangLianHuanJiao(), 
			5102 => new HuWeiGong(), 
			5103 => new JiuGongLuanBaBu(), 
			5104 => new DaLiJinGangTui(), 
			5105 => new WuDingKaiShanTui(), 
			5106 => new YunLongJiuXianTui(), 
			5107 => new AoWangShenTui(), 
			5108 => new LiuYaSiShenZu(), 
			5200 => new LuoHanJianFa(), 
			5201 => new PuDuJianFa(), 
			5202 => new QiShiErChenJian(), 
			5203 => new DaCiBeiJian(), 
			5204 => new WenShuDaZhiHuiJian(), 
			5205 => new WeiTuoFuMoJian(), 
			5206 => new WuShangPuTiJian(), 
			5207 => new DaMoJianFa(), 
			5300 => new BaGuaWuXingDao(), 
			5301 => new LiuHeDaoFa(), 
			5302 => new HuBuBaJiDao(), 
			5303 => new TaiYiJinDao(), 
			5304 => new QiXingDaoFa(), 
			5305 => new WuJiDaoFa(), 
			5306 => new TianGangDaoFa(), 
			5307 => new TaiXuanShenDao(), 
			5400 => new ShiZhuangGong(), 
			5401 => new MengHuXiaShanShi(), 
			5402 => new QianLiDuXing(), 
			5403 => new XuanJiaDing(), 
			5500 => new JiuGunShiBaDie(), 
			5503 => new JinDaoHuanZhangGong(), 
			5506 => new TaiChuGuiCangJue(), 
			5601 => new YiDaoYiJian(), 
			5602 => new YuanShanQiShaZhen(), 
			5604 => new ShiJiaZhiXiang(), 
			5605 => new TaiBuXuanDian(), 
			6000 => new FengKouGuQiFa(), 
			6001 => new ShiSanTaiBaoHengLianGong(), 
			6002 => new TieDingJinShenGong(), 
			6003 => new GuangMingShiZiJin(), 
			6100 => new TuiShanZhang(), 
			6101 => new ShiXiangTieDanShou(), 
			6102 => new DaKaiMenBaShi(), 
			6103 => new DaLiKaiBeiZhang(), 
			6104 => new ShiXiangJinShaZhang(), 
			6105 => new BaWangKaiGongShou(), 
			6106 => new YunKuangShi(), 
			6107 => new DaShenWeiZhang(), 
			6108 => new DaZhuoShou(), 
			6200 => new ShiXiangDiTangDao(), 
			6201 => new KaiShanKuaiDao(), 
			6202 => new ShiXiangPiGuaDao(), 
			6203 => new JiuNiuErHuDao(), 
			6204 => new ZhanAoDaoFa(), 
			6205 => new BaWangDao(), 
			6206 => new JinNiZhenMoDao(), 
			6207 => new GuiBaShiPanLongDao(), 
			6208 => new KuangDao(), 
			6300 => new EShaQiangFa(), 
			6301 => new WuHuDuanHunQiang(), 
			6302 => new ShiXiangBaMuQiang(), 
			6303 => new HuanHouShiLiuQiang(), 
			6304 => new QianKunQiangFa(), 
			6305 => new BaiShouZhenYueQiang(), 
			6306 => new KuangLongShiZiQiang(), 
			6307 => new TuoLongBaWangQiang(), 
			6400 => new ZhenShanBu(), 
			6401 => new TieQiaoGong(), 
			6402 => new HengJiangSuo(), 
			6403 => new ShiZiFenXun(), 
			6500 => new ShiXiangTieTouGong(), 
			6502 => new SunGangYiRou(), 
			6505 => new BaWangJieJiaGong(), 
			6601 => new BingWenZhuoSu(), 
			6603 => new BaWangJuDing(), 
			6604 => new ShiXiaoGong(), 
			7000 => new YangZhiFa(), 
			7001 => new ZhuanYuanFa(), 
			7002 => new ShiYiFa(), 
			7003 => new SunYueFa(), 
			7004 => new ShengShenFa(), 
			7005 => new FenWeiFa(), 
			7006 => new SanShiFa(), 
			7007 => new XuanWeiZhenShu(), 
			7100 => new SanQingZhi(), 
			7101 => new GouQianZhi(), 
			7102 => new WuYanWuTaiShou(), 
			7103 => new ChiShuShi(), 
			7104 => new LiHeZhi(), 
			7105 => new DaYinYangZongHengShou(), 
			7106 => new TianDiYuanYiZhi(), 
			7200 => new LaiQuJianFa(), 
			7201 => new SanQingJianFa(), 
			7202 => new FeiJianShu(), 
			7203 => new KaiHeJianShu(), 
			7204 => new FuMuCongZiJian(), 
			7205 => new TaiBaoJiuHuaJian(), 
			7206 => new YinYangNiJian(), 
			7207 => new TaiShiJianQi(), 
			7208 => new WanHuaShiSiJian(), 
			7300 => new DieDaMeiShanZhou(), 
			7301 => new DingShenFa(), 
			7302 => new JingGuiFu(), 
			7303 => new WuLeiZhaoLaiZhou(), 
			7304 => new JiuZiZhenYanZhou(), 
			7305 => new MuGongZhou(), 
			7306 => new QiBaiPoShenFa(), 
			7307 => new JiuXingJinGuangZhou(), 
			7308 => new FuJieShenTong(), 
			7400 => new WuGuiBu(), 
			7401 => new YuFengFu(), 
			7402 => new DaMiLuoBu(), 
			7403 => new XingYunQiWuFa(), 
			7404 => new XianZongBu(), 
			7405 => new WanLiShenXingZhou(), 
			7406 => new LingLiuXu(), 
			7500 => new WuGuiBanYunFa(), 
			7503 => new SheHunDaFa(), 
			7505 => new TianGangZhou(), 
			7506 => new XiangNiBiZhuanGong(), 
			7507 => new WanHuaGeGui(), 
			7601 => new ChangMuFeiErGong(), 
			7602 => new YinYangYanShu(), 
			7604 => new LiuDingLiuJiaZhen(), 
			8000 => new XuanNvXinJue(), 
			8001 => new YuGuGong(), 
			8002 => new WangShuYuYueGong(), 
			8003 => new ShaoYinYiMingJue(), 
			8004 => new XiHuaZhenJing(), 
			8005 => new DiNvShenGong(), 
			8006 => new YaoChiXianYuFa(), 
			8007 => new TaiYuanYuNvGong(), 
			8008 => new TaiYinYiMingJue(), 
			8100 => new YuNvDouLuoShou(), 
			8101 => new YuZhiShou(), 
			8102 => new HanYinZhang(), 
			8103 => new XiaoJiuTianJiuShi(), 
			8104 => new JinShangYuDingQuan(), 
			8105 => new YaoJiYunYuShi(), 
			8106 => new HanBingShenZhang(), 
			8200 => new YiXuanShou(), 
			8201 => new XuanBingZhiFa(), 
			8202 => new YuYunZhi(), 
			8203 => new LeiZuBoJianShi(), 
			8204 => new HanTanCangHuiShi(), 
			8205 => new ChangXiShiErShi(), 
			8206 => new XuanJiZhiXueFa(), 
			8207 => new DaTaiYinYiMingZhi(), 
			8300 => new QiQingQu(), 
			8301 => new QingPingDiao(), 
			8302 => new DuanHunYouYinQu(), 
			8303 => new HuangZhuGe(), 
			8304 => new XiangNvQiCangWu(), 
			8305 => new SanXiaoMiXianQu(), 
			8306 => new GuangHanGe(), 
			8307 => new HouRenXiYi(), 
			8308 => new SuNvTianYin(), 
			8400 => new MeiDianTou(), 
			8401 => new ShangYuGe(), 
			8402 => new BieLiBu(), 
			8403 => new WangXiaBaBu(), 
			8404 => new ChangEBenYue(), 
			8405 => new GuSheTaXue(), 
			8406 => new QingNvLvBing(), 
			8407 => new LuoShenLingBo(), 
			8408 => new YuYiGong(), 
			8501 => new JingWeiTianHaiShi(), 
			8505 => new JingHuaShuiYue(), 
			8506 => new NvWaBuTianShi(), 
			8600 => new BingQingYuJie(), 
			8602 => new MoYuGong(), 
			8603 => new TianNvSanHuaZhen(), 
			8604 => new XiaShuXianYiFa(), 
			9000 => new FanShiChuiDuanPian(), 
			9001 => new ZhangShiNaiFuPian(), 
			9002 => new WuJinJiaBingPian(), 
			9003 => new QianChuiBaiLianPian(), 
			9004 => new JiHunShengWeiPian(), 
			9005 => new FengJieChuYuanPian(), 
			9100 => new ShiErLuYuChangCiJian(), 
			9101 => new GongBuDuYiJian(), 
			9102 => new ShengXieCanJian(), 
			9103 => new JuQueQianJunJian(), 
			9104 => new LongYuanQiXingJianFa(), 
			9105 => new TaiEWuLiangJian(), 
			9106 => new ChunJunJianQi(), 
			9107 => new ZhanLuJianFa(), 
			9200 => new XinTingHouDaoFa(), 
			9201 => new RuanShiDaoFa(), 
			9202 => new DaXiaLongQueBaiZhanDao(), 
			9203 => new KunWuDaoFa(), 
			9204 => new GuiPaoDingDaoFa(), 
			9205 => new ChiDaoQiJue(), 
			9206 => new CanDaoShi(), 
			9207 => new MingHongJueDao(), 
			9300 => new XiangLongGunFa(), 
			9301 => new SaoXiaGunFa(), 
			9302 => new ShiFangShanHeZhang(), 
			9303 => new GuiTouBangFa(), 
			9304 => new JinJingXuanHuBangFa(), 
			9305 => new PengLaiXianChi(), 
			9306 => new JiaHaiShenZhang(), 
			9307 => new HunYuanTieBangFa(), 
			9400 => new XiuLiFeiYan(), 
			9401 => new CuoGuGou(), 
			9402 => new WuZiLianHuanKou(), 
			9403 => new QiXingLongZhuaSuo(), 
			9404 => new TianLuoDiWang(), 
			9405 => new TaiShanSuo(), 
			9406 => new HuangLongMuYuan(), 
			9407 => new TianShuXuanJi(), 
			9408 => new ShenGongRuYiTa(), 
			9500 => new MuLvGong(), 
			9501 => new YuChePian(), 
			9502 => new BaFangZhuShi(), 
			9503 => new HuQiuShiJian(), 
			9504 => new XingDouBiNu(), 
			9505 => new ChengLongShu(), 
			9506 => new TianKaiLiuYunShi(), 
			9701 => new MuJiaHuShenFa(), 
			9704 => new TianBingPiJiaShu(), 
			9705 => new LingLongJiuQiao(), 
			9700 => new QiShouBaJiaoGong(), 
			9702 => new PiJiaZhenGangShiSiJue(), 
			9703 => new ShenJiZhen(), 
			9706 => new TianZhuXuanTieCe(), 
			10000 => new QiHuangYaoLve(), 
			10001 => new ShenNongBenCaoMiYao(), 
			10002 => new ChaiShanQingNangJue(), 
			10003 => new JiaoZheSiFa(), 
			10004 => new JiuDingGong(), 
			10100 => new ChaiShanWuQinQuan(), 
			10101 => new DaXueShanZhangFa(), 
			10102 => new ZhangXueGong(), 
			10103 => new WeiLingXianHuaGuZhang(), 
			10104 => new DanShaShenZhang(), 
			10105 => new QingJiaoShenZhang(), 
			10200 => new ChaiShanQinDieShou(), 
			10201 => new GouWenZhua(), 
			10202 => new TieHuaFuGuZhua(), 
			10203 => new YuChanZhi(), 
			10204 => new QingJiaoTieXuZhi(), 
			10205 => new WuHuanShou(), 
			10300 => new DaoDaChongTianZi(), 
			10301 => new ChaiShanYiBuZhuan(), 
			10302 => new DuJuanZhuoZhuShi(), 
			10303 => new KeJinZhenYuXiaoBaShi(), 
			10304 => new QingJiaoBaiWeiGong(), 
			10305 => new QingJiaoFanTengTui(), 
			10306 => new FeiShanDuanHaiDaBaShi(), 
			10307 => new XuanDingBaiBu(), 
			10400 => new ZhenYuXiang(), 
			10401 => new BiAnBaXianZi(), 
			10402 => new JingMengXiang(), 
			10403 => new BiXueShuiXian(), 
			10405 => new HeiShuiDuanChangSan(), 
			10406 => new BaiXieXiaoGuXiang(), 
			10407 => new QingJiaoXue(), 
			10408 => new GuiGuXueHaiTang(), 
			10500 => new CaoShangFei(), 
			10501 => new WeiYaXuanHu(), 
			10502 => new ShaTangTaShui(), 
			10503 => new ChaiShanYiXianTian(), 
			10504 => new QingJiaoNaoHaiGong(), 
			10603 => new WuHuangBiDuShu(), 
			10607 => new WuHuangBiDuShu(), 
			10700 => new SiZhiQingGao(), 
			10701 => new SanBuJiuHouFa(), 
			10702 => new TouGuQiePouFa(), 
			10704 => new ZiWuAnXiXiang(), 
			10705 => new QuXueFa(), 
			10706 => new BaiShuiChangShengFa(), 
			10708 => new JiuSeYuChanFa(), 
			11000 => new JinGangSiJiaXingFa(), 
			11001 => new TuMuGong(), 
			11002 => new SanMiHeYingFa(), 
			11003 => new BaoPingQiGongFa(), 
			11004 => new JinGangGuanDingGong(), 
			11005 => new DaRiJing(), 
			11006 => new JinGangDingJing(), 
			11007 => new MoHeJiaLuoHuFaGong(), 
			11008 => new WuShangYuJiaFa(), 
			11100 => new JinGangChui(), 
			11101 => new WuNuShou(), 
			11102 => new BoLuoMiZhang(), 
			11103 => new JinGangHeiShaZhang(), 
			11104 => new LingReZhang(), 
			11105 => new JinGangZhuMieShou(), 
			11106 => new XuMiShanSiShenZhang(), 
			11107 => new DaRiRuLaiZhang(), 
			11200 => new JinGangDaoFa(), 
			11201 => new LuoChaDaoFa(), 
			11202 => new MoZhangDaoFa(), 
			11203 => new LingReDao(), 
			11204 => new JinGangXiangFuDao(), 
			11205 => new JinGangBoReDao(), 
			11206 => new RuYiBaoLunDao(), 
			11207 => new LiuShenWeiDao(), 
			11208 => new MoHeJiaLuoDao(), 
			11300 => new SuiShiChu(), 
			11301 => new HuFaJinGangChu(), 
			11302 => new LuoChaChuFa(), 
			11303 => new NuMuJinGangChu(), 
			11304 => new DaLunJinGangChu(), 
			11305 => new DaWeiDeJinGangChu(), 
			11306 => new RuYiBaoShuChu(), 
			11307 => new BuDongMingWangChu(), 
			11500 => new XianShiJiao(), 
			11501 => new DaDingJiao(), 
			11502 => new JinGangZuoFa(), 
			11503 => new ShenZuTong(), 
			11601 => new NaMaiGong(), 
			11602 => new YiJinSuoGuGong(), 
			11604 => new ManTuLuoZhenYan(), 
			11605 => new MingWangZhuoHuoDing(), 
			11607 => new JiShenChengFo(), 
			11700 => new SuiSuoYu(), 
			11703 => new QiLunGanYingFa(), 
			11706 => new DaShouYin(), 
			12000 => new YinDuShu(), 
			12001 => new HuangXianFa(), 
			12002 => new ChiXianFa(), 
			12003 => new HeiXianFa(), 
			12004 => new QingXianFa(), 
			12005 => new LiHunGong(), 
			12006 => new BaiXieTiDaFa(), 
			12100 => new YinFengXieZiShou(), 
			12101 => new FuSheQianZhenShou(), 
			12102 => new XueZhiZhang(), 
			12103 => new SanShiDuanHunZhang(), 
			12104 => new QingZhuChanHunShou(), 
			12105 => new ZhuChanDuZhang(), 
			12106 => new QingHuangChiHeiShenZhang(), 
			12107 => new JiuSiLiHunShou(), 
			12200 => new SheGuShou(), 
			12201 => new ChiMuGuJiang(), 
			12202 => new ChiMeiGuJiang(), 
			12203 => new HeiXueGuJiang(), 
			12204 => new XinMoGuJiang(), 
			12205 => new JiuYinShiChiGu(), 
			12206 => new BiYuBingCanGu(), 
			12207 => new WangGuJinCanJiang(), 
			12208 => new BaiCaiQingSuiGu(), 
			12300 => new LvRanJianFa(), 
			12301 => new GouLianJianFa(), 
			12302 => new GuiPoPoJian(), 
			12303 => new ShenMuBiXieJian(), 
			12304 => new GuiMianZhuiHunJian(), 
			12305 => new ShenChiZhanYaoJian(), 
			12306 => new QingZhuJianFa(), 
			12400 => new HuangLinBianFa(), 
			12401 => new WuGongSuo(), 
			12402 => new WuShengBianFa(), 
			12403 => new GouHunSuiGuBian(), 
			12404 => new ChiYouTieBian(), 
			12405 => new PoYuSuo(), 
			12406 => new XianZhuQinMangGong(), 
			12407 => new BaLongShenBian(), 
			12408 => new TianSheSuo(), 
			12500 => new RedEyeGrowingGood1(), 
			12501 => new RedEyeGrowingGood2(), 
			12502 => new RedEyeGrowingBad1(), 
			12503 => new RedEyeGrowingBad2(), 
			12504 => new RedEyeGrown(), 
			12505 => new ForestSpiritGrowingGood1(), 
			12506 => new ForestSpiritGrowingGood2(), 
			12507 => new ForestSpiritGrowingBad1(), 
			12508 => new ForestSpiritGrowingBad2(), 
			12509 => new ForestSpiritGrown(), 
			12510 => new BlackBloodGrowingGood1(), 
			12511 => new BlackBloodGrowingGood2(), 
			12512 => new BlackBloodGrowingBad1(), 
			12513 => new BlackBloodGrowingBad2(), 
			12514 => new BlackBloodGrown(), 
			12515 => new DevilInsideGrowingGood1(), 
			12516 => new DevilInsideGrowingGood2(), 
			12517 => new DevilInsideGrowingBad1(), 
			12518 => new DevilInsideGrowingBad2(), 
			12519 => new DevilInsideGrown(), 
			12520 => new CorpseWormGrowingGood1(), 
			12521 => new CorpseWormGrowingGood2(), 
			12522 => new CorpseWormGrowingBad1(), 
			12523 => new CorpseWormGrowingBad2(), 
			12524 => new CorpseWormGrown(), 
			12525 => new IceSilkwormGrowingGood1(), 
			12526 => new IceSilkwormGrowingGood2(), 
			12527 => new IceSilkwormGrowingBad1(), 
			12528 => new IceSilkwormGrowingBad2(), 
			12529 => new IceSilkwormGrown(), 
			12530 => new GoldenSilkwormGrowingGood1(), 
			12531 => new GoldenSilkwormGrowingGood2(), 
			12532 => new GoldenSilkwormGrowingBad1(), 
			12533 => new GoldenSilkwormGrowingBad2(), 
			12534 => new GoldenSilkwormGrown(), 
			12535 => new AzureMarrowGrowingGood1(), 
			12536 => new AzureMarrowGrowingGood2(), 
			12537 => new AzureMarrowGrowingBad1(), 
			12538 => new AzureMarrowGrowingBad2(), 
			12539 => new AzureMarrowGrown(), 
			12540 => new RedEyeKing(), 
			12541 => new ForestSpiritKing(), 
			12542 => new BlackBloodKing(), 
			12543 => new DevilInsideKing(), 
			12544 => new CorpseWormKing(), 
			12545 => new IceSilkwormKing(), 
			12546 => new GoldenSilkwormKing(), 
			12547 => new AzureMarrowKing(), 
			12600 => new SheXingGong(), 
			12601 => new ChuangNiTan(), 
			12602 => new HaMaZongTiaoGong(), 
			12603 => new FeiTouShu(), 
			12604 => new YuSuoDaoXuan(), 
			12605 => new DunDiBaiZuXian(), 
			12606 => new TianSheFan(), 
			12701 => new LuanQingZhang(), 
			12703 => new MieGuZhou(), 
			12704 => new XueOuPoShaFa(), 
			12705 => new SangHunXi(), 
			12707 => new GuiJiangDaFa(), 
			12800 => new MiChongXiang(), 
			12802 => new HongYuJiuXiangChong(), 
			12806 => new TianCanShiGu(), 
			12808 => new TianSheHuanGuGong(), 
			13000 => new JieQingSiXiangTu(), 
			13001 => new TianYuanYangQiFa(), 
			13002 => new DongBiShiErJuanShu(), 
			13003 => new BuTianGe(), 
			13004 => new XuanMingZhenJing(), 
			13005 => new YiSiYiCan(), 
			13006 => new HunTianXingTu(), 
			13100 => new WuXingXiaoQinNa(), 
			13101 => new ZhaiXingShi(), 
			13102 => new YuJingHuaMaiShou(), 
			13103 => new FuYinZhi(), 
			13104 => new TianJieQiYaoZhi(), 
			13105 => new XuanMingZhi(), 
			13106 => new TaiSuJueShou(), 
			13107 => new CuoShenZhi(), 
			13108 => new TaiYiLiuLiZhi(), 
			13200 => new JieQingKuaiJian(), 
			13201 => new JueYiJian(), 
			13202 => new XianChiJianQi(), 
			13203 => new JieQingAnShouKuaiJian(), 
			13204 => new ShaJian(), 
			13205 => new YouMingJianFa(), 
			13206 => new WuXiaQiJueJian(), 
			13207 => new XuanMingJianQi(), 
			13300 => new JieQingShiJue(), 
			13301 => new ZhaiYeFeiHuaShu(), 
			13302 => new WuYingLiuShou(), 
			13303 => new FeiXingShu(), 
			13304 => new LuanFeiHuang(), 
			13305 => new YaoTuQiShu(), 
			13306 => new MingLongZhi(), 
			13307 => new DingYingShenZhen(), 
			13308 => new WuXiangShenTong(), 
			13400 => new BaiChiZhuang(), 
			13401 => new WuZongLiuBu(), 
			13402 => new WuYouBu(), 
			13403 => new TianHeYouBu(), 
			13404 => new ChengWuChe(), 
			13405 => new ShenXianSuo(), 
			13406 => new QiXingFeiXuan(), 
			13407 => new TianYuanZong(), 
			13408 => new HunTianYiXingGong(), 
			13501 => new HeBoQuQi(), 
			13502 => new LiuZhuanTianHuang(), 
			13503 => new HanBingBaMai(), 
			13506 => new QiYuanJieEDaFa(), 
			13600 => new TianGuanTong(), 
			13604 => new NanDouLiuXingZhen(), 
			13605 => new JiuYaoXingJunYan(), 
			14000 => new BianTiHuoQiFa(), 
			14001 => new FuLongTunHuoGong(), 
			14002 => new LiHuoZhenQi(), 
			14003 => new XiaoYuYangShenGong(), 
			14004 => new KuangLongTunXiangGong(), 
			14005 => new JiuLongGuiYiGong(), 
			14006 => new RuMoGong(), 
			14007 => new DaYuYangShenGong(), 
			14100 => new DuanGuQuan(), 
			14101 => new FuLongZuiBaXianQuan(), 
			14102 => new HuoLianZhang(), 
			14103 => new FengMoZuiQuan(), 
			14104 => new DaXuanJueZhang(), 
			14105 => new XiaoYuYangShenQuan(), 
			14106 => new LiHuoLiuYangZhang(), 
			14107 => new DaYuYangShenQuan(), 
			14108 => new HuaLongZhang(), 
			14200 => new FuLongDaoFa(), 
			14201 => new JiuGongZuiDao(), 
			14202 => new LongYaSiZhan(), 
			14203 => new LiuXinSiYiDao(), 
			14204 => new KuangLongBaShiYiZhan(), 
			14205 => new DaLiangYiZuiDao(), 
			14206 => new ChiZiZhanLongDao(), 
			14207 => new JiuLongBaDao(), 
			14300 => new FeiShaZouShi(), 
			14301 => new LeiHuoDa(), 
			14302 => new LongTuZhu(), 
			14303 => new ChiQingShenHuoJin(), 
			14304 => new FenXueGong(), 
			14305 => new JiuLianJinWu(), 
			14400 => new ChiJiaoGong(), 
			14401 => new ZuiBaXianBu(), 
			14402 => new LongBaiWei(), 
			14403 => new FuLongFenYue(), 
			14404 => new FengHuoZhenXingJue(), 
			14405 => new ZuiWoDongHai(), 
			14501 => new LongHuiShou(), 
			14502 => new ShenHuoZhaoGong(), 
			14504 => new LeiGongZhuGu(), 
			14507 => new ZheTianBiRiGong(), 
			14600 => new NuXiangGong(), 
			14603 => new LongChuangZhen(), 
			14605 => new TianMangDanXinShu(), 
			14606 => new QianNianZui(), 
			15000 => new HouMuGong(), 
			15001 => new HeiShiSiJue(), 
			15002 => new XieGuiGong(), 
			15003 => new SanDuWuMingZhou(), 
			15004 => new TaiYinLianXing(), 
			15005 => new WuYinDaFa(), 
			15006 => new TongZiXueLianFa(), 
			15007 => new XueHouXieJing(), 
			15008 => new XueTongDaFa(), 
			15100 => new FengGouQuan(), 
			15101 => new CuiXinZhang(), 
			15102 => new QiShiErDiShaQuan(), 
			15103 => new FuShiDuZhang(), 
			15104 => new XueShaZhang(), 
			15105 => new BaiGuiHuaGuZhang(), 
			15106 => new TianMoCanHunZhang(), 
			15107 => new XueHouMoZhang(), 
			15200 => new ChuoYanXiaoErGong(), 
			15201 => new SuoHouYinShou(), 
			15202 => new FenJinCuoGuShou(), 
			15203 => new SanZhiDuoYinZhua(), 
			15204 => new DuLongZhua(), 
			15205 => new HuangQuanZhi(), 
			15206 => new XueChiGuiZhua(), 
			15300 => new LiaoYinTui(), 
			15301 => new HaMaDaoTiTui(), 
			15302 => new WuChangJiao(), 
			15303 => new XieZiGouHunJiao(), 
			15304 => new BianZouBianSha(), 
			15305 => new DaYinFengTui(), 
			15306 => new YanWangGuiJiao(), 
			15307 => new XueYingTui(), 
			15400 => new YeGuiDuSha(), 
			15401 => new FuChongSha(), 
			15402 => new ShiGuLanChangSha(), 
			15403 => new HuangFenSha(), 
			15404 => new JinChanWuDuSha(), 
			15405 => new DuNiangZiSha(), 
			15406 => new XueHouSha(), 
			15500 => new ChestCrash(), 
			15501 => new ChestHurt(), 
			15502 => new BellyCrash(), 
			15503 => new BellyHurt(), 
			15504 => new HeadCrash(), 
			15505 => new HeadHurt(), 
			15506 => new HandCrash(), 
			15507 => new HandHurt(), 
			15508 => new LegCrash(), 
			15509 => new LegHurt(), 
			15600 => new LiCuanShu(), 
			15601 => new FenTouDun(), 
			15602 => new YouHunGuiBu(), 
			15603 => new GuiHouRuDiZhenTianFa(), 
			15604 => new FeiShiDaNuoWu(), 
			15700 => new LanNiJueJi(), 
			15702 => new GuiYeKu(), 
			15704 => new YiHunDaFa(), 
			15707 => new TianMoTong(), 
			15801 => new LuanQiSha(), 
			15803 => new XueShiGong(), 
			15805 => new XinWoLiangMieZhou(), 
			15806 => new ShiErXueTongDaZhen(), 
			15808 => new XueTongBuSiShen(), 
			16000 => new WenESheng(), 
			16001 => new QuShan(), 
			16002 => new HuanMu(), 
			16003 => new YaoXinShiXian(), 
			16004 => new BaiXie(), 
			16005 => new DuoXinJiuBuZhong(), 
			16006 => new ZhongXiangSheng(), 
			16007 => new ShenDuanHuFa(), 
			16008 => new XuanYuJiuLao(), 
			16100 => new ShenNvHuanJian(), 
			16101 => new ZhenYuFuXie(), 
			16102 => new QiHanLingQi(), 
			16103 => new QiWenWuCai(), 
			16104 => new QingGuoJueShi(), 
			16105 => new ZhuYinHuaMing(), 
			16106 => new RongChenHuaYu(), 
			16107 => new BaHongBaZhi(), 
			16108 => new FangTianChiLing(), 
			16109 => new WanXiangHeShu(), 
			16110 => new ShiZhuanChenXin(), 
			16111 => new FuJunYouYu(), 
			16112 => new SuXinWuRan(), 
			16113 => new ChiXinWuGai(), 
			16200 => new JiangXian(), 
			16201 => new XieNiWuSheng(), 
			16202 => new CheDiBingTian(), 
			16203 => new LiuXiang(), 
			16204 => new YiFeiYan(), 
			16205 => new BaiLongQianYuan(), 
			16206 => new JingYingDunXiang(), 
			16207 => new XueLiuPiaoLu(), 
			16208 => new ChengGuangPiXia(), 
			16209 => new MoWoZiZai(), 
			16210 => new ChenRan(), 
			16211 => new HuaJian(), 
			16212 => new YaoYin(), 
			16213 => new ShenHuaJiuYao(), 
			16300 => new YunShuiHuaLingYi(), 
			16301 => new BuBai(), 
			16302 => new ShuangTaiBingPo(), 
			16303 => new JiuBao(), 
			16304 => new XinHuaLiaoMeng(), 
			16305 => new HaiLongJia(), 
			16306 => new XiTuShiLing(), 
			16307 => new FengShenZhaoMing(), 
			16308 => new SanYuanJiuDunTianDiBian(), 
			16309 => new XuanYuJueShen(), 
			16310 => new WuMieShiXin(), 
			16311 => new HuanXin(), 
			16312 => new XuHuaSheYue(), 
			16313 => new DiZhaoXuanHuoYin(), 
			16400 => new DongLaiYiQi(), 
			16401 => new JinGangDuanE(), 
			16402 => new JiuYinShiYou(), 
			16403 => new TianWaiZhenHuo(), 
			16404 => new XiangHuanMiZhen(), 
			16405 => new ShenWaiQiuFa(), 
			16406 => new XiGuiShouShen(), 
			16407 => new ShenTuFuSha(), 
			16408 => new FenShenJingJie(), 
			16409 => new JieWaiTunXin(), 
			16410 => new YinChen(), 
			16411 => new HuaShengLian(), 
			16412 => new LiDuanShenMo(), 
			16413 => new FuTianHuoZhao(), 
			16414 => new ChiEr(), 
			16415 => new ShiShiYiRen(), 
			16416 => new SiJie(), 
			16417 => new LiYouJinMeng(), 
			16418 => new PiXueGuaYan(), 
			17000 => new CunXinRuMeng(), 
			17001 => new YouTanQiShui(), 
			17002 => new WuSeYing(), 
			17003 => new CunXinDuanMeng(), 
			17004 => new XuanTanGuiDu(), 
			17005 => new LuanCaiYing(), 
			17010 => new PoYaoHui(), 
			17011 => new MieShaSanZhan(), 
			17012 => new TianMoXiangFu(), 
			17013 => new ZhanELong(), 
			17014 => new SheDuanSanZhan(), 
			17015 => new TianMoPoJin(), 
			17020 => new SuXue(), 
			17021 => new QingShenYouWu(), 
			17022 => new QiBeiQu(), 
			17023 => new NingHong(), 
			17024 => new QingShenSiWu(), 
			17025 => new SuSiGe(), 
			17030 => new GuiXiTiFu(), 
			17031 => new HuoZhiBaFeng(), 
			17032 => new ChiYuPoKong(), 
			17033 => new ShanZaiHeShi(), 
			17034 => new FengYinJiuChu(), 
			17035 => new JinLingPoKong(), 
			17040 => new XunHu(), 
			17041 => new CanHuTi(), 
			17042 => new SiXiangXueHuoShu(), 
			17043 => new GuiHu(), 
			17044 => new CanHuTong(), 
			17045 => new FenShenXueHuoShu(), 
			17050 => new LongTunShi(), 
			17051 => new LongXianShi(), 
			17052 => new LongZhuShi(), 
			17053 => new SheShenShi(), 
			17054 => new SheMingShi(), 
			17055 => new SheXinShi(), 
			17060 => new WuXinHuaXin(), 
			17061 => new WuJianHuaJian(), 
			17062 => new WuHunHuaHun(), 
			17063 => new XinHuaWuXin(), 
			17064 => new JianHuaWuJian(), 
			17065 => new HunHuaWuHun(), 
			17070 => new ZhanWuShu(), 
			17071 => new XiongBingChuangSanZhen(), 
			17072 => new XingFengSaoSiYe(), 
			17073 => new ShaWuShe(), 
			17074 => new BingZhuZhanLiuHe(), 
			17075 => new XueYuYuBaHuang(), 
			17080 => new KunLunShiErJinXianLing(), 
			17081 => new TianYanShu(), 
			17082 => new TianDiXuanYiLing(), 
			17083 => new KunLunShiErXieXianLing(), 
			17084 => new MoTongShu(), 
			17085 => new GuiShenXuanYiLing(), 
			17090 => new RuXinYuanXiang(), 
			17091 => new RuXuYanXiang(), 
			17092 => new RuWangMingXiang(), 
			17093 => new XinMiWuJue(), 
			17094 => new XieWangWuZheng(), 
			17095 => new BianRanWuJing(), 
			17100 => new JieFeng(), 
			17101 => new ChuQiao(), 
			17102 => new ShiFeng(), 
			17103 => new ChaiRen(), 
			17104 => new BiGuang(), 
			17105 => new DuoShen(), 
			17110 => new SanSanHuaLing(), 
			17111 => new QiQiShengHui(), 
			17112 => new JiuJiuZaoMing(), 
			17113 => new LingSanTianDiRen(), 
			17114 => new HuiWangQiJueZhi(), 
			17115 => new MingYunWuJianYu(), 
			17120 => new DanFengZhuoRui(), 
			17121 => new ChiNiZhengYi(), 
			17122 => new HuoLongFenXin(), 
			17123 => new HuoRuiShaJiaoFeng(), 
			17124 => new ChiYiXiangENi(), 
			17125 => new DanXinSheYaoLong(), 
			17130 => new YiJianRongChenYin(), 
			17131 => new ErJianMoNvYi(), 
			17132 => new SanJianFuXieTie(), 
			17133 => new SiWuJian(), 
			17134 => new LiuQiBaJian(), 
			17135 => new JiuJianGuiShenXia(), 
			18000 => new JieXinWuHuoShu(), 
			18001 => new JiuBaNiZhou(), 
			18002 => new ZhuiTianLuanFa(), 
			18003 => new QianKunShiBian(), 
			18004 => new FengYuanHuanSuGong(), 
			18005 => new MoTianPoJin(), 
			18006 => new QiXieDunFa(), 
			18007 => new SanShenDianFanJue(), 
			18008 => new MingSheShiYuanGong(), 
			18009 => new JueShengYiNian(), 
			18010 => new WangFaDanGong(), 
			18011 => new WanGuiYouZhao(), 
			30000 => new PoZhang(), 
			30001 => new PoJian(), 
			30002 => new PoDao(), 
			30003 => new PoDu(), 
			30004 => new PoChangBing(), 
			30005 => new PoRuanBing(), 
			30006 => new PoAnQi(), 
			30007 => new PoQiMen(), 
			30008 => new PoMoYin(), 
			30009 => new PoJin(), 
			30010 => new PoMu(), 
			30011 => new PoYu(), 
			30012 => new PoJin2(), 
			30013 => new HuaXue(), 
			30014 => new HuaQi(), 
			30015 => new XueSha(), 
			30016 => new QiSha(), 
			30017 => new GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.DuCi(), 
			30100 => new PiZhang(), 
			30101 => new PiJian(), 
			30102 => new PiDao(), 
			30103 => new PiDu(), 
			30104 => new PiChangBing(), 
			30105 => new PiRuanBing(), 
			30106 => new PiAnQi(), 
			30107 => new PiQiMen(), 
			30108 => new PiMoYin(), 
			30109 => new PiJin(), 
			30110 => new PiMu(), 
			30111 => new PiYu(), 
			30112 => new PiJin2(), 
			30113 => new ZhenXue(), 
			30114 => new ZhenQi(), 
			30115 => new HuXue(), 
			30116 => new HuQi(), 
			30117 => new GameData.Domains.SpecialEffect.EquipmentEffect.Armor.DuCi(), 
			30200 => new YanXiaShenZhu(), 
			30201 => new ShanHeShenJie(), 
			30202 => new GuiYanLingZhuo(), 
			30203 => new XuanHuShenJie(), 
			30204 => new XianYuanShenJie(), 
			30205 => new HunYuanShenZhu(), 
			40001 => new GameData.Domains.SpecialEffect.LegendaryBook.Neigong.ZhuanJie(), 
			40002 => new YongJi(), 
			40003 => new DaYing(), 
			40004 => new DaCheng(), 
			40005 => new GameData.Domains.SpecialEffect.LegendaryBook.Neigong.JueZhi(), 
			40006 => new GameData.Domains.SpecialEffect.LegendaryBook.Neigong.ShouZhi(), 
			40101 => new GameData.Domains.SpecialEffect.LegendaryBook.Posing.ZhuanJie(), 
			40102 => new FengShen(), 
			40103 => new YunYong(), 
			40104 => new JingShui(), 
			40105 => new GameData.Domains.SpecialEffect.LegendaryBook.Posing.JueZhi(), 
			40106 => new GameData.Domains.SpecialEffect.LegendaryBook.Posing.ShouZhi(), 
			40201 => new GameData.Domains.SpecialEffect.LegendaryBook.Stunt.ZhuanJie(), 
			40202 => new YuanLiu(), 
			40203 => new ChaNa(), 
			40204 => new ZhouQuan(), 
			40205 => new GameData.Domains.SpecialEffect.LegendaryBook.Stunt.JueZhi(), 
			40206 => new GameData.Domains.SpecialEffect.LegendaryBook.Stunt.ShouZhi(), 
			40300 => new KeDi(), 
			40301 => new GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm.ZhuanJie(), 
			40302 => new JinSha(), 
			40303 => new GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm.JiePo(), 
			40304 => new GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm.JueZhi(), 
			40305 => new GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm.ShouZhi(), 
			40400 => new DuanXue(), 
			40401 => new GameData.Domains.SpecialEffect.LegendaryBook.Finger.ZhuanJie(), 
			40402 => new SiXue(), 
			40403 => new GameData.Domains.SpecialEffect.LegendaryBook.Finger.JiePo(), 
			40404 => new GameData.Domains.SpecialEffect.LegendaryBook.Finger.JueZhi(), 
			40405 => new GameData.Domains.SpecialEffect.LegendaryBook.Finger.ShouZhi(), 
			40500 => new BingZu(), 
			40501 => new GameData.Domains.SpecialEffect.LegendaryBook.Leg.ZhuanJie(), 
			40502 => new XianSha(), 
			40503 => new GameData.Domains.SpecialEffect.LegendaryBook.Leg.JiePo(), 
			40504 => new GameData.Domains.SpecialEffect.LegendaryBook.Leg.JueZhi(), 
			40505 => new GameData.Domains.SpecialEffect.LegendaryBook.Leg.ShouZhi(), 
			40600 => new AnSha(), 
			40601 => new GameData.Domains.SpecialEffect.LegendaryBook.Throw.ZhuanJie(), 
			40602 => new YuanSha(), 
			40603 => new GameData.Domains.SpecialEffect.LegendaryBook.Throw.JiePo(), 
			40604 => new GameData.Domains.SpecialEffect.LegendaryBook.Throw.JueZhi(), 
			40605 => new GameData.Domains.SpecialEffect.LegendaryBook.Throw.ShouZhi(), 
			40700 => new HuaXi(), 
			40701 => new GameData.Domains.SpecialEffect.LegendaryBook.Sword.ZhuanJie(), 
			40702 => new ShiSha(), 
			40703 => new GameData.Domains.SpecialEffect.LegendaryBook.Sword.JiePo(), 
			40704 => new GameData.Domains.SpecialEffect.LegendaryBook.Sword.JueZhi(), 
			40705 => new GameData.Domains.SpecialEffect.LegendaryBook.Sword.ShouZhi(), 
			40800 => new ZhenLie(), 
			40801 => new GameData.Domains.SpecialEffect.LegendaryBook.Blade.ZhuanJie(), 
			40802 => new PoSha(), 
			40803 => new GameData.Domains.SpecialEffect.LegendaryBook.Blade.JiePo(), 
			40804 => new GameData.Domains.SpecialEffect.LegendaryBook.Blade.JueZhi(), 
			40805 => new GameData.Domains.SpecialEffect.LegendaryBook.Blade.ShouZhi(), 
			40900 => new ChuangZhen(), 
			40901 => new GameData.Domains.SpecialEffect.LegendaryBook.Polearm.ZhuanJie(), 
			40902 => new JueDou(), 
			40903 => new GameData.Domains.SpecialEffect.LegendaryBook.Polearm.JiePo(), 
			40904 => new GameData.Domains.SpecialEffect.LegendaryBook.Polearm.JueZhi(), 
			40905 => new GameData.Domains.SpecialEffect.LegendaryBook.Polearm.ShouZhi(), 
			41000 => new GuiJi(), 
			41001 => new GameData.Domains.SpecialEffect.LegendaryBook.Special.ZhuanJie(), 
			41002 => new QiShi(), 
			41003 => new GameData.Domains.SpecialEffect.LegendaryBook.Special.JiePo(), 
			41004 => new GameData.Domains.SpecialEffect.LegendaryBook.Special.JueZhi(), 
			41005 => new GameData.Domains.SpecialEffect.LegendaryBook.Special.ShouZhi(), 
			41100 => new YanSheng(), 
			41101 => new GameData.Domains.SpecialEffect.LegendaryBook.Whip.ZhuanJie(), 
			41102 => new JieQi(), 
			41103 => new GameData.Domains.SpecialEffect.LegendaryBook.Whip.JiePo(), 
			41104 => new GameData.Domains.SpecialEffect.LegendaryBook.Whip.JueZhi(), 
			41105 => new GameData.Domains.SpecialEffect.LegendaryBook.Whip.ShouZhi(), 
			41200 => new QiBian(), 
			41201 => new GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot.ZhuanJie(), 
			41202 => new BianJie(), 
			41203 => new GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot.JiePo(), 
			41204 => new GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot.JueZhi(), 
			41205 => new GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot.ShouZhi(), 
			41300 => new LuanXin(), 
			41301 => new GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic.ZhuanJie(), 
			41302 => new KuangSheng(), 
			41303 => new GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic.JiePo(), 
			41304 => new GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic.JueZhi(), 
			41305 => new GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic.ShouZhi(), 
			41400 => new Neigong(), 
			41401 => new Posing(), 
			41402 => new Stunt(), 
			41403 => new FistAndPalm(), 
			41404 => new Finger(), 
			41405 => new Leg(), 
			41406 => new Throw(), 
			41407 => new Sword(), 
			41408 => new Blade(), 
			41409 => new Polearm(), 
			41410 => new Special(), 
			41411 => new Whip(), 
			41412 => new ControllableShot(), 
			41413 => new CombatMusic(), 
			50000 => new FuMoFaYin(), 
			50001 => new SuiXinWuNian(), 
			50002 => new XuanLingDuanMai(), 
			50003 => new LiangYiZhenYuan(), 
			50004 => new ZhenShanHuaQi(), 
			50005 => new SuiGuFeiShi(), 
			50006 => new DaYanShuZhou(), 
			50007 => new YouShenAnRan(), 
			50008 => new OuZuShiJian(), 
			50009 => new BiENiWan(), 
			50010 => new MiJiFaYin(), 
			50011 => new DieMuYinYi(), 
			50012 => new XingLuoQiShu(), 
			50013 => new HuaLongZhangLi(), 
			50014 => new HuangXieGuiQi(), 
			50100 => new XiangMoJinShen(), 
			50101 => new XiaFengYiGu(), 
			50102 => new HuaXueHuanSheng(), 
			50103 => new XuanShenNeiGuan(), 
			50104 => new LiKuXiuJian(), 
			50105 => new FeiShiZhanZhen(), 
			50106 => new ZhiZaiQianLi(), 
			50107 => new BingHuiYueHua(), 
			50108 => new ShenGongFanZhu(), 
			50109 => new QingNangBanShen(), 
			50110 => new LunZhuanBuMie(), 
			50111 => new BaiDuGuiChao(), 
			50112 => new XingMingZaiShen(), 
			50113 => new BaiNiaoChaoFeng(), 
			50114 => new XieMoRuTi(), 
			100000 => new WuQiShengMie(), 
			100001 => new TianShuMiQiao(), 
			100002 => new BaReCiFu(), 
			100003 => new BaHanCiFu(), 
			100004 => new WuJianCiFu(), 
			1000000 => new AddPenetrateAndPenetrateResist(), 
			1000001 => new AddMaxHealth(), 
			_ => throw new Exception($"Cannot find special effect subclass of type {type}"), 
		};
	}
}
