using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TravelSkeleton : ConfigData<TravelSkeletonItem, short>
{
	public static class DefKey
	{
		public const short NoCarrier = 55;

		public const short KidnappedCarrier = 56;
	}

	public static class DefValue
	{
		public static TravelSkeletonItem NoCarrier => Instance[(short)55];

		public static TravelSkeletonItem KidnappedCarrier => Instance[(short)56];
	}

	public static TravelSkeleton Instance = new TravelSkeleton();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"TemplateId", "Animation", "AnimationIdle", "SubAnimation", "SubAnimationIdle", "SimpleAnimation", "ComplexAnimation", "CarrierAnimation", "CarrierAnimationIdle", "CarrierAnimationPath",
		"Sound"
	};

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new TravelSkeletonItem(0, "car_1", "car_1_idle", null, null, "car_1", "car_1", anyCarrier: true, "car_1", "car_1_idle", "default", "car_1/car_1_SkeletonData", "se_carrier_car_1", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(1, "car_2", "car_2_idle", null, null, "car_2", "car_2", anyCarrier: true, "car_2", "car_2_idle", "default", "car_2/car_2_SkeletonData", "se_carrier_car_2", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(2, "car_3", "car_3_idle", null, null, "car_3", "car_3", anyCarrier: true, "car_3", "car_3_idle", "default", "car_3/car_3_SkeletonData", "se_carrier_car_2", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(3, "car_4", "car_4_idle", null, null, "car_4", "car_4", anyCarrier: true, "car_4", "car_4_idle", "default", "car_4/car_4_SkeletonData", "se_carrier_car_4", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(4, "car_5", "car_5_idle", null, null, "car_5", "car_5", anyCarrier: true, "car_5", "car_5_idle", "default", "car_5/car_5_SkeletonData", "se_carrier_car_4", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(5, "car_6", "car_6_idle", null, null, "car_6", "car_6", anyCarrier: true, "car_6", "car_6_idle", "default", "car_6/car_6_SkeletonData", "se_carrier_car_6", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(6, "car_7", "car_7_idle", null, null, "car_7", "car_7", anyCarrier: true, "car_7", "car_7_idle", "default", "car_7/car_7_SkeletonData", "se_carrier_car_7", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(7, "car_8", "car_8_idle", null, null, "car_8", "car_8", anyCarrier: true, "car_8", "car_8_idle", "default", "car_8/car_8_SkeletonData", "se_carrier_car_8", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(8, "car_9", "car_9_idle", null, null, "car_9", "car_9", anyCarrier: true, "car_9", "car_9_idle", "default", "car_9/car_9_SkeletonData", "se_carrier_car_9", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(9, "coach_1", "coach_1_idle", null, null, "coach_1", "coach_1", anyCarrier: true, "coach_1", "coach_1_idle", "default", "coach_1/coach_1_SkeletonData", "se_carrier_coach_1", 0.5f, 0f, -230f));
		_dataArray.Add(new TravelSkeletonItem(10, "coach_2", "coach_2_idle", null, null, "coach_2", "coach_2", anyCarrier: true, "coach_2", "coach_2_idle", "default", "coach_2/coach_2_SkeletonData", "se_carrier_car_2", 0.5f, 0f, -230f));
		_dataArray.Add(new TravelSkeletonItem(11, "coach_3", "coach_3_idle", null, null, "coach_3", "coach_3", anyCarrier: true, "coach_3", "coach_3_idle", "default", "coach_3/coach_3_SkeletonData", "se_carrier_car_2", 0.5f, 0f, -230f));
		_dataArray.Add(new TravelSkeletonItem(12, "coach_4", "coach_4_idle", null, null, "coach_4", "coach_4", anyCarrier: true, "coach_4", "coach_4_idle", "default", "coach_4/coach_4_SkeletonData", "se_carrier_coach_4", 0.5f, 0f, -230f));
		_dataArray.Add(new TravelSkeletonItem(13, "coach_5", "coach_5_idle", null, null, "coach_5", "coach_5", anyCarrier: true, "coach_5", "coach_5_idle", "default", "coach_5/coach_5_SkeletonData", "se_carrier_coach_5", 0.38f, -60f, -230f));
		_dataArray.Add(new TravelSkeletonItem(14, "coach_6", "coach_6_idle", null, null, "coach_6", "coach_6", anyCarrier: true, "coach_6", "coach_6_idle", "default", "coach_6/coach_6_SkeletonData", "se_carrier_coach_4", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(15, "coach_7", "coach_7_idle", null, null, "coach_7", "coach_7", anyCarrier: true, "coach_7", "coach_7_idle", "default", "coach_7/coach_7_SkeletonData", "se_carrier_coach_7", 0.4f, -100f, -260f));
		_dataArray.Add(new TravelSkeletonItem(16, "coach_8", "coach_8_idle", null, null, "coach_8", "coach_8", anyCarrier: true, "coach_8", "coach_8_idle", "default", "coach_8/coach_8_SkeletonData", "se_carrier_coach_8", 0.4f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(17, "coach_9", "coach_9_idle", null, null, "coach_9", "coach_9", anyCarrier: true, "coach_9", "coach_9_idle", "default", "coach_9/coach_9_SkeletonData", "se_carrier_car_7", 0.3f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(18, "horse_1", "horse_1_idle", null, null, "horse_1", "horse_1", anyCarrier: true, "horse_1", "horse_1_idle", "default", "horse_1/horse_1_SkeletonData", "se_carrier_horse_1", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(19, "horse_2", "horse_2_idle", null, null, "horse_2", "horse_2", anyCarrier: true, "horse_2", "horse_2_idle", "default", "horse_2/horse_2_SkeletonData", "se_carrier_horse_2", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(20, "horse_3", "horse_3_idle", null, null, "horse_3", "horse_3", anyCarrier: true, "horse_3", "horse_3_idle", "default", "horse_3/horse_3_SkeletonData", "se_carrier_horse_1", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(21, "horse_4", "horse_4_idle", null, null, "horse_4", "horse_4", anyCarrier: true, "horse_4", "horse_4_idle", "default", "horse_4/horse_4_SkeletonData", "se_carrier_bull", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(22, "horse_5", "horse_5_idle", null, null, "horse_5", "horse_5", anyCarrier: true, "horse_5", "horse_5_idle", "default", "horse_5/horse_5_SkeletonData", "se_carrier_horse_1", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(23, "horse_6", "horse_6_idle", null, null, "horse_6", "horse_6", anyCarrier: true, "horse_6", "horse_6_idle", "default", "horse_6/horse_6_SkeletonData", "se_carrier_horse_6", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(24, "horse_7", "horse_7_idle", null, null, "horse_7", "horse_7", anyCarrier: true, "horse_7", "horse_7_idle", "default", "horse_7/horse_7_SkeletonData", "se_carrier_horse_6", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(25, "horse_8", "horse_8_idle", null, null, "horse_8", "horse_8", anyCarrier: true, "horse_8", "horse_8_idle", "default", "horse_8/horse_8_SkeletonData", "se_carrier_horse_8", 0.45f, -100f, -260f));
		_dataArray.Add(new TravelSkeletonItem(26, "horse_9", "horse_9_idle", null, null, "horse_9", "horse_9", anyCarrier: true, "horse_9", "horse_9_idle", "default", "horse_9/horse_9_SkeletonData", "se_carrier_horse_6", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(27, "animal_monkey", "animal_monkey_idle", null, null, "animal_monkey", "animal_monkey", anyCarrier: true, "animal_monkey", "animal_monkey_idle", "default", "animal_monkey/animal_monkey_SkeletonData", "se_carrier_monkey", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(28, "animal_eagle", "animal_eagle_idle", null, null, "animal_eagle", "animal_eagle", anyCarrier: true, "animal_eagle", "animal_eagle_idle", "default", "animal_eagle/animal_eagle_SkeletonData", "se_carrier_eagle", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(29, "animal_pig", "animal_pig_idle", null, null, "animal_pig", "animal_pig", anyCarrier: true, "animal_pig", "animal_pig_idle", "default", "animal_pig/animal_pig_SkeletonData", "se_carrier_pig", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(30, "animal_bear", "animal_bear_idle", null, null, "animal_bear", "animal_bear", anyCarrier: true, "animal_bear", "animal_bear_idle", "default", "animal_bear/animal_bear_SkeletonData", "se_carrier_tiger", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(31, "animal_bull", "animal_bull_idle", null, null, "animal_bull", "animal_bull", anyCarrier: true, "animal_bull", "animal_bull_idle", "default", "animal_bull/animal_bull_SkeletonData", "se_carrier_bull", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(32, "animal_snake", "animal_snake_idle", null, null, "animal_snake", "animal_snake", anyCarrier: true, "animal_snake", "animal_snake_idle", "default", "animal_snake/animal_snake_SkeletonData", "se_carrier_snake", 0.42f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(33, "animal_jaguar", "animal_jaguar_idle", null, null, "animal_jaguar", "animal_jaguar", anyCarrier: true, "animal_jaguar", "animal_jaguar_idle", "default", "animal_jaguar/animal_jaguar_SkeletonData", "se_carrier_jaguar", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(34, "animal_lion", "animal_lion_idle", null, null, "animal_lion", "animal_lion", anyCarrier: true, "animal_lion", "animal_lion_idle", "default", "animal_lion/animal_lion_SkeletonData", "se_carrier_tiger", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(35, "animal_tiger", "animal_tiger_idle", null, null, "animal_tiger", "animal_tiger", anyCarrier: true, "animal_tiger", "animal_tiger_idle", "default", "animal_tiger/animal_tiger_SkeletonData", "se_carrier_tiger", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(36, "animal_monkey", "animal_monkey_idle", null, null, "animal_monkey", "animal_monkey", anyCarrier: true, "animal_monkey", "animal_monkey_idle", "default", "animal_monkey/animal_monkey_SkeletonData", "se_carrier_monkey", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(37, "animal_eagle", "animal_eagle_idle", null, null, "animal_eagle", "animal_eagle", anyCarrier: true, "animal_eagle", "animal_eagle_idle", "default", "animal_eagle/animal_eagle_SkeletonData", "se_carrier_eagle", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(38, "animal_pig", "animal_pig_idle", null, null, "animal_pig", "animal_pig", anyCarrier: true, "animal_pig", "animal_pig_idle", "default", "animal_pig/animal_pig_SkeletonData", "se_carrier_pig", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(39, "animal_bear", "animal_bear_idle", null, null, "animal_bear", "animal_bear", anyCarrier: true, "animal_bear", "animal_bear_idle", "default", "animal_bear/animal_bear_SkeletonData", "se_carrier_tiger", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(40, "animal_bull", "animal_bull_idle", null, null, "animal_bull", "animal_bull", anyCarrier: true, "animal_bull", "animal_bull_idle", "default", "animal_bull/animal_bull_SkeletonData", "se_carrier_bull", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(41, "animal_snake", "animal_snake_idle", null, null, "animal_snake", "animal_snake", anyCarrier: true, "animal_snake", "animal_snake_idle", "default", "animal_snake/animal_snake_SkeletonData", "se_carrier_snake", 0.42f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(42, "animal_jaguar", "animal_jaguar_idle", null, null, "animal_jaguar", "animal_jaguar", anyCarrier: true, "animal_jaguar", "animal_jaguar_idle", "default", "animal_jaguar/animal_jaguar_SkeletonData", "se_carrier_jaguar", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(43, "animal_lion", "animal_lion_idle", null, null, "animal_lion", "animal_lion", anyCarrier: true, "animal_lion", "animal_lion_idle", "default", "animal_lion/animal_lion_SkeletonData", "se_carrier_tiger", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(44, "animal_tiger", "animal_tiger_idle", null, null, "animal_tiger", "animal_tiger", anyCarrier: true, "animal_tiger", "animal_tiger_idle", "default", "animal_tiger/animal_tiger_SkeletonData", "se_carrier_tiger", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(45, "Loong", "Loong_idle", null, null, "Loong", "Loong_idle", anyCarrier: true, "Loong", "Loong_idle", "jiao", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(46, "dragon_qiuniu", "dragon_qiuniu_idle", null, null, "dragon_qiuniu", "dragon_qiuniu", anyCarrier: true, "dragon_qiuniu", "dragon_qiuniu_idle", "default", "dragon_qiuniu/dragon_qiuniu_SkeletonData", "se_carrier_dragon_qiuniu", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(47, "dragon_yazi", "dragon_yazi_idle", null, null, "dragon_yazi", "dragon_yazi", anyCarrier: true, "dragon_yazi", "dragon_yazi_idle", "default", "dragon_yazi/dragon_yazi_SkeletonData", "se_carrier_dragon_yazi", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(48, "dragon_chaofeng", "dragon_chaofeng_idle", null, null, "dragon_chaofeng", "dragon_chaofeng", anyCarrier: true, "dragon_chaofeng", "dragon_chaofeng_idle", "default", "dragon_chaofeng/dragon_chaofeng_SkeletonData", "se_carrier_dragon_chaofeng", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(49, "dragon_pulao", "dragon_pulao_idle", null, null, "dragon_pulao", "dragon_pulao", anyCarrier: true, "dragon_pulao", "dragon_pulao_idle", "default", "dragon_pulao/dragon_pulao_SkeletonData", "se_carrier_dragon_pulao", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(50, "dragon_suanni", "dragon_suanni_idle", null, null, "dragon_suanni", "dragon_suanni", anyCarrier: true, "dragon_suanni", "dragon_suanni_idle", "default", "dragon_suanni/dragon_suanni_SkeletonData", "se_carrier_dragon_suanni", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(51, "dragon_baxia", "dragon_baxia_idle", null, null, "dragon_baxia", "dragon_baxia", anyCarrier: true, "dragon_baxia", "dragon_baxia_idle", "default", "dragon_baxia/dragon_baxia_SkeletonData", "se_carrier_dragon_baxia", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(52, "dragon_bian", "dragon_bian_idle", null, null, "dragon_bian", "dragon_bian", anyCarrier: true, "dragon_bian", "dragon_bian_idle", "default", "dragon_bian/dragon_bian_SkeletonData", "se_carrier_dragon_bian", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(53, "Loong", "Loong_idle", null, null, "Loong", "Loong_idle", anyCarrier: true, "Loong", "Loong_idle", "fuxi", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(54, "dragon_chiwen", "dragon_chiwen_idle", null, null, "dragon_chiwen", "dragon_chiwen", anyCarrier: true, "dragon_chiwen", "dragon_chiwen_idle", "default", "dragon_chiwen/dragon_chiwen_SkeletonData", "se_carrier_dragon_chiwen", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(55, "animal_human", "animal_human_idle", null, null, "animal_human", "animal_human", anyCarrier: false, null, null, "default", null, "se_carrier_foot", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(56, "coach_prison_slave", "coach_prison_slave_idle", "coach_prison_master", "coach_prison_master_idle", "coach_prison", "coach_prison", anyCarrier: true, "coach_prison", "coach_prison_idle", "default", "coach_prison/coach_prison_SkeletonData", "se_carrier_car_prison", 0.5f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(57, "Loong", "Loong", null, null, "Loong", "Loong", anyCarrier: true, "Loong", "Loong", "white", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(58, "Loong", "Loong", null, null, "Loong", "Loong", anyCarrier: true, "Loong", "Loong", "black", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(59, "Loong", "Loong", null, null, "Loong", "Loong", anyCarrier: true, "Loong", "Loong", "blue", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TravelSkeletonItem(60, "Loong", "Loong", null, null, "Loong", "Loong", anyCarrier: true, "Loong", "Loong", "red", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
		_dataArray.Add(new TravelSkeletonItem(61, "Loong", "Loong", null, null, "Loong", "Loong", anyCarrier: true, "Loong", "Loong", "yellow", "Loong/Loong_SkeletonData", "se_carrier_Loong", 0.45f, 0f, -260f));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TravelSkeletonItem>(62);
		CreateItems0();
		CreateItems1();
	}
}
