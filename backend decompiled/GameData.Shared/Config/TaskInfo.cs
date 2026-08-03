using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskInfo : ConfigData<TaskInfoItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 回村寻船
		/// </summary>
		public const int ReturnToGetBoat = 13;

		/// <summary>
		/// 以船渡河
		/// </summary>
		public const int TakeBoatToLeave = 14;

		/// <summary>
		/// 亡流驿站
		/// </summary>
		public const int BrokenAreaTravel = 19;

		/// <summary>
		/// 寻路太吾
		/// </summary>
		public const int FirstArriveTaiwuArea = 20;

		/// <summary>
		/// 振兴太吾
		/// </summary>
		public const int SideQuest_ConstructTaiwuVillage = 23;

		/// <summary>
		/// 派遣村民
		/// </summary>
		public const int SideQuest_AssignVillagers = 24;

		/// <summary>
		/// 耳闻仙人
		/// </summary>
		public const int HearsayOfImmortal = 25;

		/// <summary>
		/// 古墓仙人
		/// </summary>
		public const int VisitTombImmortal = 26;

		/// <summary>
		/// 仙人疑云
		/// </summary>
		public const int ReturnToTaiwuVillage = 27;

		/// <summary>
		/// 太吾驿站
		/// </summary>
		public const int MainStory_TaiwuVillageStation = 31;

		/// <summary>
		/// 以向化身1
		/// </summary>
		public const int PurpleBambooYixiangChp2 = 616;

		/// <summary>
		/// 等待盟会
		/// </summary>
		public const int MartialArtTournamentWait = 64;

		/// <summary>
		/// 筹备盟会
		/// </summary>
		public const int MartialArtTournamentPrepare = 65;

		/// <summary>
		/// 武林盟会
		/// </summary>
		public const int MartialArtTournamentReady = 66;

		/// <summary>
		/// 语茯来访
		/// </summary>
		public const int YufuArrivesAtTaiwuVillage = 67;

		/// <summary>
		/// 玄竹降世
		/// </summary>
		public const int DarkBambooAppeared = 74;

		/// <summary>
		/// 出神之法
		/// </summary>
		public const int MainStory_SpiritualWanderPlace0 = 82;

		/// <summary>
		/// 出神之地
		/// </summary>
		public const int MainStory_SpiritualWanderPlace1 = 83;

		/// <summary>
		/// 邪魔线前置-初遇魔血
		/// </summary>
		public const int PreEvilFirstDemonBlood = 644;

		/// <summary>
		/// 邪魔线前置-一念魔血
		/// </summary>
		public const int PreEvilDemonBloodSurge = 645;

		/// <summary>
		/// 邪魔线前置-欲念侵心-贪
		/// </summary>
		public const int PreEvilRaga = 646;

		/// <summary>
		/// 邪魔线前置-欲念侵心-嗔
		/// </summary>
		public const int PreEvilDvesa = 647;

		/// <summary>
		/// 邪魔线前置-欲念侵心-痴
		/// </summary>
		public const int PreEvilMoha = 648;

		/// <summary>
		/// 邪魔线前置-魔血玄石
		/// </summary>
		public const int PreEvilDemonBloodDarkstone = 649;

		/// <summary>
		/// 邪魔线前置-静待机缘
		/// </summary>
		public const int PreEvilWaitForChance = 650;

		/// <summary>
		/// 探听消息
		/// </summary>
		public const int MainStory_Investigate = 677;

		/// <summary>
		/// 流民之忧
		/// </summary>
		public const int MainStory_RefugeeDistress = 678;

		/// <summary>
		/// 寻找食物
		/// </summary>
		public const int MainStory_FindFood = 679;

		/// <summary>
		/// 医者之忧
		/// </summary>
		public const int MainStory_DoctorDistress = 680;

		/// <summary>
		/// 寻找药材
		/// </summary>
		public const int MainStory_FindHerbs = 681;

		/// <summary>
		/// 宁氏之忧
		/// </summary>
		public const int MainStory_NingDistress = 682;

		/// <summary>
		/// 寻找衣物
		/// </summary>
		public const int MainStory_FindClothes = 683;

		/// <summary>
		/// 无名伤者
		/// </summary>
		public const int MainStory_UnknownPatient = 684;

		/// <summary>
		/// 前往柴山
		/// </summary>
		public const int MainStory_GoToChaiMountain = 685;

		/// <summary>
		/// 柴山异变
		/// </summary>
		public const int MainStory_ChaiShanMutation = 686;

		/// <summary>
		/// 十二邪仙0
		/// </summary>
		public const int MainStory_TwelveEvilImmortals0 = 687;

		/// <summary>
		/// 十二邪仙1
		/// </summary>
		public const int MainStory_TwelveEvilImmortals1 = 688;

		/// <summary>
		/// 十二邪仙2
		/// </summary>
		public const int MainStory_TwelveEvilImmortals2 = 689;

		/// <summary>
		/// 十二邪仙3
		/// </summary>
		public const int MainStory_TwelveEvilImmortals3 = 690;

		/// <summary>
		/// 十二邪仙4
		/// </summary>
		public const int MainStory_TwelveEvilImmortals4 = 691;

		/// <summary>
		/// 十二邪仙5
		/// </summary>
		public const int MainStory_TwelveEvilImmortals5 = 692;

		/// <summary>
		/// 十二邪仙6
		/// </summary>
		public const int MainStory_TwelveEvilImmortals6 = 693;

		/// <summary>
		/// 十二邪仙7
		/// </summary>
		public const int MainStory_TwelveEvilImmortals7 = 694;

		/// <summary>
		/// 十二邪仙8
		/// </summary>
		public const int MainStory_TwelveEvilImmortals8 = 695;

		/// <summary>
		/// 十二邪仙9
		/// </summary>
		public const int MainStory_TwelveEvilImmortals9 = 696;

		/// <summary>
		/// 十二邪仙10
		/// </summary>
		public const int MainStory_TwelveEvilImmortals10 = 697;

		/// <summary>
		/// 十二邪仙11
		/// </summary>
		public const int MainStory_TwelveEvilImmortals11 = 698;

		/// <summary>
		/// 无绡去向
		/// </summary>
		public const int MainStory_WhereaboutsofZiwuxiao = 701;

		/// <summary>
		/// 子夜生变
		/// </summary>
		public const int MainStory_MidnightUpheaval = 702;

		/// <summary>
		/// 仙公踪迹
		/// </summary>
		public const int MainStory_WhereaboutsofXuxiangong = 703;

		/// <summary>
		/// 决战神魔
		/// </summary>
		public const int MainStory_ShowdownofGodsandDemons = 704;

		/// <summary>
		/// 空桑主线奇毒绝方
		/// </summary>
		public const int Kongsang_MissionUnaccepted = 101;

		/// <summary>
		/// 空桑主线无命寻人0
		/// </summary>
		public const int Kongsang_SearchTarget0 = 102;

		/// <summary>
		/// 空桑主线无命试毒0
		/// </summary>
		public const int Kongsang_PoisonTest0 = 103;

		/// <summary>
		/// 空桑主线上复掌门0
		/// </summary>
		public const int Kongsang_ReplySect0 = 104;

		/// <summary>
		/// 空桑主线无命寻人1
		/// </summary>
		public const int Kongsang_SearchTarget1 = 105;

		/// <summary>
		/// 空桑主线无命试毒1
		/// </summary>
		public const int Kongsang_PoisonTest1 = 106;

		/// <summary>
		/// 空桑主线上复掌门1
		/// </summary>
		public const int Kongsang_ReplySect1 = 107;

		/// <summary>
		/// 空桑主线无命寻人2
		/// </summary>
		public const int Kongsang_SearchTarget2 = 108;

		/// <summary>
		/// 空桑主线无命试毒2
		/// </summary>
		public const int Kongsang_PoisonTest2 = 109;

		/// <summary>
		/// 空桑主线上复掌门3
		/// </summary>
		public const int Kongsang_ReplySect3 = 110;

		/// <summary>
		/// 空桑主线寻找无命
		/// </summary>
		public const int Kongsang_FindWLiao = 111;

		/// <summary>
		/// 空桑主线上复掌门2
		/// </summary>
		public const int Kongsang_ReplySect2 = 112;

		/// <summary>
		/// 空桑主线百年奇遇
		/// </summary>
		public const int Kongsang_WaitForAdventure = 113;

		/// <summary>
		/// 空桑主线长生之死
		/// </summary>
		public const int Kongsang_AdventureAppeared = 114;

		/// <summary>
		/// 血犼主线调查血犼
		/// </summary>
		public const int Xuehou_GraveDigging = 115;

		/// <summary>
		/// 血犼主线破旧铃铛
		/// </summary>
		public const int Xuehou_RustBell = 116;

		/// <summary>
		/// 血犼主线老人异相
		/// </summary>
		public const int Xuehou_OldmanMyth = 117;

		/// <summary>
		/// 血犼主线红衣老人
		/// </summary>
		public const int Xuehou_Oldman = 118;

		/// <summary>
		/// 血犼主线调查血光
		/// </summary>
		public const int Xuehou_CheckBloodBlock = 119;

		/// <summary>
		/// 血犼主线墓地邂逅
		/// </summary>
		public const int Xuehou_AdventureGrave = 120;

		/// <summary>
		/// 血犼主线姬穸回村
		/// </summary>
		public const int Xuehou_BringJixiBack = 121;

		/// <summary>
		/// 血犼主线留在村中
		/// </summary>
		public const int Xuehou_StayWithJixi = 122;

		/// <summary>
		/// 血犼主线村中异事
		/// </summary>
		public const int Xuehou_MythInVillage = 123;

		/// <summary>
		/// 血犼主线真相线索1
		/// </summary>
		public const int Xuehou_TruthClue1 = 124;

		/// <summary>
		/// 血犼主线假象线索1
		/// </summary>
		public const int Xuehou_FalsityClue1 = 125;

		/// <summary>
		/// 血犼主线真相线索2
		/// </summary>
		public const int Xuehou_TruthClue2 = 126;

		/// <summary>
		/// 血犼主线假象线索2
		/// </summary>
		public const int Xuehou_FalsityClue2 = 127;

		/// <summary>
		/// 血犼主线真相线索3
		/// </summary>
		public const int Xuehou_TruthClue3 = 128;

		/// <summary>
		/// 血犼主线假象线索3
		/// </summary>
		public const int Xuehou_FalsityClue3 = 129;

		/// <summary>
		/// 血犼主线调查姬穸
		/// </summary>
		public const int Xuehou_InterrogateJixi = 130;

		/// <summary>
		/// 血犼主线传剑交谈
		/// </summary>
		public const int Xuehou_PassLegacy = 131;

		/// <summary>
		/// 少林主线少林异动
		/// </summary>
		public const int Shaolin_MythinShaolin = 132;

		/// <summary>
		/// 少林主线肮脏雕像
		/// </summary>
		public const int Shaolin_MuddyStatue = 133;

		/// <summary>
		/// 少林主线归还雕像
		/// </summary>
		public const int Shaolin_ReturnStatue = 134;

		/// <summary>
		/// 少林主线留在少林
		/// </summary>
		public const int Shaolin_StayAndWait = 135;

		/// <summary>
		/// 少林主线老僧相会
		/// </summary>
		public const int Shaolin_BodhidharmaInDream = 136;

		/// <summary>
		/// 少林主线雕像碎裂
		/// </summary>
		public const int Shaolin_BrokenStatue = 137;

		/// <summary>
		/// 少林主线禅武之争
		/// </summary>
		public const int Shaolin_Conflict = 138;

		/// <summary>
		/// 少林主线努力修习
		/// </summary>
		public const int Shaolin_Endeavor = 139;

		/// <summary>
		/// 少林主线老僧再临
		/// </summary>
		public const int Shaolin_WaitForBodhidharma = 140;

		/// <summary>
		/// 少林主线挖掘宝物
		/// </summary>
		public const int Shaolin_DiggingSutra = 141;

		/// <summary>
		/// 少林主线老僧传授
		/// </summary>
		public const int Shaolin_StudyForBodhidharmaChallenge = 142;

		/// <summary>
		/// 少林主线佛学书籍
		/// </summary>
		public const int Shaolin_ObtainedSutra = 143;

		/// <summary>
		/// 少林主线阅读佛经
		/// </summary>
		public const int Shaolin_ReadSutra = 144;

		/// <summary>
		/// 少林主线少林众塔
		/// </summary>
		public const int Shaolin_VisitShaolin = 145;

		/// <summary>
		/// 少林主线藏经阁楼
		/// </summary>
		public const int Shaolin_SutraLibrary = 146;

		/// <summary>
		/// 璇女主线璇女异动
		/// </summary>
		public const int Xuannv_QinAndQing = 147;

		/// <summary>
		/// 璇女主线询问古曲
		/// </summary>
		public const int Xuannv_WaitForLetters = 148;

		/// <summary>
		/// 璇女主线古曲旋律
		/// </summary>
		public const int Xuannv_SeekLetterSender = 149;

		/// <summary>
		/// 璇女主线镜里孤鸾
		/// </summary>
		public const int Xuannv_SeekXuannv = 150;

		/// <summary>
		/// 璇女主线寻人请求
		/// </summary>
		public const int Xuannv_AdventureSoulInMirror = 151;

		/// <summary>
		/// 璇女主线修习功法
		/// </summary>
		public const int Xuannv_RefusedToSearch = 152;

		/// <summary>
		/// 璇女新主线修习功法
		/// </summary>
		public const int Xuannv_Study = 153;

		/// <summary>
		/// 璇女新主线返回一明
		/// </summary>
		public const int Xuannv_ReturnToMirror = 154;

		/// <summary>
		/// 璇女新主线回璇女峰
		/// </summary>
		public const int Xuannv_TakeShiToXuannv = 155;

		/// <summary>
		/// 璇女新主线静待消息
		/// </summary>
		public const int Xuannv_WaitForMessage = 156;

		/// <summary>
		/// 璇女新主线查问天女
		/// </summary>
		public const int Xuannv_AskShadow = 157;

		/// <summary>
		/// 璇女新主线查问筠儿
		/// </summary>
		public const int Xuannv_AskJuner = 158;

		/// <summary>
		/// 璇女新主线查问璇女
		/// </summary>
		public const int Xuannv_AskXuannvSect = 159;

		/// <summary>
		/// 璇女新主线考试挂科
		/// </summary>
		public const int Xuannv_FailAndRetake = 160;

		/// <summary>
		/// 璇女新主线准备学习
		/// </summary>
		public const int Xuannv_ReadyToStudy = 161;

		/// <summary>
		/// 璇女主线前往寻人
		/// </summary>
		public const int Xuannv_AcceptedToSearch = 162;

		/// <summary>
		/// 璇女主线等候会面
		/// </summary>
		public const int Xuannv_AdventureIllusionOfMirror = 163;

		/// <summary>
		/// 璇女主线探访璇女
		/// </summary>
		public const int Xuannv_SeekLove = 164;

		/// <summary>
		/// 璇女主线回复掌门
		/// </summary>
		public const int Xuannv_WaitForReturn = 165;

		/// <summary>
		/// 孤鸾镜水
		/// </summary>
		public const int PlayerShadowInMirror = 166;

		/// <summary>
		/// 武当主线逆练功法
		/// </summary>
		public const int Wudang_Prologue = 167;

		/// <summary>
		/// 武当主线等待道长
		/// </summary>
		public const int Wudang_WaitForSlobbyTaoistMonk = 168;

		/// <summary>
		/// 武当主线道长探查
		/// </summary>
		public const int Wudang_SloppyTaoistMonkRequest = 169;

		/// <summary>
		/// 武当主线探访洞天
		/// </summary>
		public const int Wudang_SeekSite = 170;

		/// <summary>
		/// 武当主线回复道长
		/// </summary>
		public const int Wudang_ReturnToSloppyTaoistMonk = 171;

		/// <summary>
		/// 武当主线养护神树
		/// </summary>
		public const int Wudang_CultivateHeavenlyTreeMain = 172;

		/// <summary>
		/// 武当主线种植神树
		/// </summary>
		public const int Wudang_PlantHeavenlyTree = 173;

		/// <summary>
		/// 武当主线守卫神树
		/// </summary>
		public const int Wudang_ProtectHeavenlyTree = 174;

		/// <summary>
		/// 武当主线研修道法
		/// </summary>
		public const int Wudang_ReadTaoistBook = 175;

		/// <summary>
		/// 武当主线取神木种
		/// </summary>
		public const int Wudang_GetHeavenlyTreeSeed = 176;

		/// <summary>
		/// 武当主线道长做法
		/// </summary>
		public const int Wudang_TaoistMonkSacrifices = 177;

		/// <summary>
		/// 武当主线最终作法
		/// </summary>
		public const int Wudang_WaitForTimePassing = 178;

		/// <summary>
		/// 武当主线前往武当
		/// </summary>
		public const int Wudang_VisitWudang = 179;

		/// <summary>
		/// 武当主线等待仙缘
		/// </summary>
		public const int Wudang_WaitForImmortals = 180;

		/// <summary>
		/// 武当主线查问武当
		/// </summary>
		public const int Wudang_AskWudang = 181;

		/// <summary>
		/// 狮相主线狮相流言
		/// </summary>
		public const int Shixiang_Anecdote = 182;

		/// <summary>
		/// 狮相主线前往狮相
		/// </summary>
		public const int Shixiang_ArriveSect = 183;

		/// <summary>
		/// 狮相主线狮相传言
		/// </summary>
		public const int Shixiang_AskForJokes = 184;

		/// <summary>
		/// 狮相主线狮相异动
		/// </summary>
		public const int Shixiang_Myth = 185;

		/// <summary>
		/// 狮相主线狮相绝技
		/// </summary>
		public const int Shixiang_PoemAdventure = 186;

		/// <summary>
		/// 狮相主线静观其变
		/// </summary>
		public const int Shixiang_WaitforLetters = 187;

		/// <summary>
		/// 狮相主线探查狮相
		/// </summary>
		public const int Shixiang_Arrive = 188;

		/// <summary>
		/// 狮相主线消灭外道
		/// </summary>
		public const int Shixiang_Heretics = 189;

		/// <summary>
		/// 狮相主线上复门主
		/// </summary>
		public const int Shixiang_ReplyHead = 190;

		/// <summary>
		/// 狮相主线狮相异相
		/// </summary>
		public const int Shixiang_Stay = 191;

		/// <summary>
		/// 狮相主线剿灭叛徒
		/// </summary>
		public const int Shixiang_Traitors = 192;

		/// <summary>
		/// 狮相主线驱逐异族
		/// </summary>
		public const int Shixiang_Barbarians = 193;

		/// <summary>
		/// 狮相主线等待清理
		/// </summary>
		public const int Shixiang_WaitForBattles = 194;

		/// <summary>
		/// 狮相主线静待后续
		/// </summary>
		public const int Shixiang_Ending = 195;

		/// <summary>
		/// 金刚主线民不聊生
		/// </summary>
		public const int Jingang_Poverty = 196;

		/// <summary>
		/// 金刚主线前往金刚
		/// </summary>
		public const int Jingang_ToJingang = 197;

		/// <summary>
		/// 金刚剧情古刹何在
		/// </summary>
		public const int Jingang_AdventureAppeared = 198;

		/// <summary>
		/// 金刚主线古经迷踪
		/// </summary>
		public const int Jingang_Adventure = 199;

		/// <summary>
		/// 金刚主线解读残经
		/// </summary>
		public const int Jingang_Haunted = 200;

		/// <summary>
		/// 金刚主线高僧写经
		/// </summary>
		public const int Jingang_AssistReincarnation = 201;

		/// <summary>
		/// 金刚主线回复高僧
		/// </summary>
		public const int Jingang_WaitForReincarnation = 202;

		/// <summary>
		/// 金刚主线秦州换经
		/// </summary>
		public const int Jingang_ToKunlun = 203;

		/// <summary>
		/// 金刚主线襄阳换经
		/// </summary>
		public const int Jingang_SearchMonk = 204;

		/// <summary>
		/// 金刚主线太原换经
		/// </summary>
		public const int Jingang_SecInfoSpreading = 205;

		/// <summary>
		/// 金刚主线京城换经
		/// </summary>
		public const int Jingang_RefuseAndFailing = 206;

		/// <summary>
		/// 金刚主线高僧何往
		/// </summary>
		public const int Jingang_MonkEnding = 207;

		/// <summary>
		/// 金刚剧情高僧消失
		/// </summary>
		public const int Jingang_MonkKilled = 208;

		/// <summary>
		/// 金刚剧情中原僧人
		/// </summary>
		public const int Jingang_SutraDiscussion = 209;

		/// <summary>
		/// 金刚剧情疑问重重
		/// </summary>
		public const int Jingang_SutraFeedback = 210;

		/// <summary>
		/// 金刚剧情高僧写经
		/// </summary>
		public const int Jingang_SutraExplaining = 211;

		/// <summary>
		/// 金刚主线了结此事
		/// </summary>
		public const int Jingang_BackToJingang = 212;

		/// <summary>
		/// 金刚主线交还经文
		/// </summary>
		public const int Jingang_ReturnSutra = 213;

		/// <summary>
		/// 金刚主线真经无字
		/// </summary>
		public const int Jingang_Ending = 214;

		/// <summary>
		/// 五仙主线常来洗澡
		/// </summary>
		public const int Wuxian_Bath = 215;

		/// <summary>
		/// 五仙主线前往百花
		/// </summary>
		public const int Wuxian_ToBaihua = 216;

		/// <summary>
		/// 五仙主线五仙请求
		/// </summary>
		public const int Wuxian_AcceptRequest = 217;

		/// <summary>
		/// 五仙主线前往空桑
		/// </summary>
		public const int Wuxian_ToKongsang = 218;

		/// <summary>
		/// 五仙主线回到五仙
		/// </summary>
		public const int Wuxian_BackHome = 219;

		/// <summary>
		/// 五仙主线心愿未了
		/// </summary>
		public const int Wuxian_WishComeTrue = 220;

		/// <summary>
		/// 五仙主线五圣心毒
		/// </summary>
		public const int Wuxian_Adventure = 221;

		/// <summary>
		/// 峨眉主线峨眉凶案
		/// </summary>
		public const int Emei_HomocideCases = 222;

		/// <summary>
		/// 峨眉主线凶案线索
		/// </summary>
		public const int Emei_Clues = 223;

		/// <summary>
		/// 峨眉主线调查白猿
		/// </summary>
		public const int Emei_InvestigateWhiteGibbon = 224;

		/// <summary>
		/// 峨眉主线峨眉正宗
		/// </summary>
		public const int Emei_Orthrodox = 225;

		/// <summary>
		/// 峨眉主线何为正宗
		/// </summary>
		public const int Emei_OrthrodoxAdventure = 226;

		/// <summary>
		/// 峨眉主线等待奇遇
		/// </summary>
		public const int Emei_WaitForAdventure = 227;

		/// <summary>
		/// 峨眉主线寻找白猿
		/// </summary>
		public const int Emei_SeekWhiteGibbon = 228;

		/// <summary>
		/// 峨眉主线白猿消失
		/// </summary>
		public const int Emei_WhiteGibbonsDisappeared = 229;

		/// <summary>
		/// 峨眉主线小石消失
		/// </summary>
		public const int Emei_ShiHoujiuDisappeared = 230;

		/// <summary>
		/// 峨眉新主线初探风波
		/// </summary>
		public const int Emei_Prologue = 709;

		/// <summary>
		/// 峨眉新主线峨眉动向
		/// </summary>
		public const int Emei_StormApproaches = 710;

		/// <summary>
		/// 峨眉新主线峨眉山月
		/// </summary>
		public const int Emei_Midnight = 711;

		/// <summary>
		/// 峨眉新主线掌门密信
		/// </summary>
		public const int Emei_SecretLetter = 712;

		/// <summary>
		/// 峨眉新主线急赴峨眉
		/// </summary>
		public const int Emei_Crisis = 713;

		/// <summary>
		/// 峨眉新主线预备比武
		/// </summary>
		public const int Emei_Preparing = 714;

		/// <summary>
		/// 峨眉新主线预备比武0
		/// </summary>
		public const int Emei_TeachingMember = 715;

		/// <summary>
		/// 峨眉新主线预备比武1
		/// </summary>
		public const int Emei_SeekForWhiteGibbon = 716;

		/// <summary>
		/// 峨眉新主线预备比武2
		/// </summary>
		public const int Emei_SeekForXiaoshi = 717;

		/// <summary>
		/// 峨眉新主线预备比武3
		/// </summary>
		public const int Emei_TalkToMember = 718;

		/// <summary>
		/// 峨眉新主线预备比武4
		/// </summary>
		public const int Emei_TalkToVillager = 719;

		/// <summary>
		/// 峨眉新主线金顶比武
		/// </summary>
		public const int Emei_Tournament = 720;

		/// <summary>
		/// 峨眉新主线等待休养
		/// </summary>
		public const int Emei_TakeBreak = 731;

		/// <summary>
		/// 峨眉新主线峨眉现状
		/// </summary>
		public const int Emei_NowStates = 721;

		/// <summary>
		/// 峨眉新主线暂离峨眉
		/// </summary>
		public const int Emei_Leaving = 722;

		/// <summary>
		/// 峨眉新主线再寻白猿
		/// </summary>
		public const int Emei_SeekWhiteGibbonAgain = 723;

		/// <summary>
		/// 峨眉新主线追踪恶妖
		/// </summary>
		public const int Emei_SeekForEvil = 724;

		/// <summary>
		/// 峨眉新主线寻找恶妖0
		/// </summary>
		public const int Emei_Chat = 725;

		/// <summary>
		/// 峨眉新主线追击真凶
		/// </summary>
		public const int Emei_Pursuit = 726;

		/// <summary>
		/// 峨眉新主线别过群侠
		/// </summary>
		public const int Emei_Farewell = 727;

		/// <summary>
		/// 峨眉新主线漫步峨眉
		/// </summary>
		public const int Emei_WalkInMountains = 728;

		/// <summary>
		/// 峨眉新主线静待了结
		/// </summary>
		public const int Emei_Finale = 729;

		/// <summary>
		/// 梦回剧情跟上伏虞
		/// </summary>
		public const int CrossArchive_FollowFuyu = 231;

		/// <summary>
		/// 梦回剧情取回行囊
		/// </summary>
		public const int CrossArchive_Items = 232;

		/// <summary>
		/// 梦回剧情取回技艺
		/// </summary>
		public const int CrossArchive_LifeSkills = 233;

		/// <summary>
		/// 梦回剧情取回功法
		/// </summary>
		public const int CrossArchive_CombatSkills = 234;

		/// <summary>
		/// 五方神龙回太吾村
		/// </summary>
		public const int LoongDLCToVillage = 235;

		/// <summary>
		/// 五方神龙前往抓龙
		/// </summary>
		public const int LoongDLCCaptureLoong = 236;

		/// <summary>
		/// 五方神龙养育蛟卵
		/// </summary>
		public const int LoongDLCNurtureJiao = 237;

		/// <summary>
		/// 挑战白龙
		/// </summary>
		public const int ChallengeWhiteLoong = 238;

		/// <summary>
		/// 挑战黑龙
		/// </summary>
		public const int ChallengeBlackLoong = 239;

		/// <summary>
		/// 挑战青龙
		/// </summary>
		public const int ChallengeBlueLoong = 240;

		/// <summary>
		/// 挑战赤龙
		/// </summary>
		public const int ChallengeRedLoong = 241;

		/// <summary>
		/// 挑战黄龙
		/// </summary>
		public const int ChallengeYellowLoong = 242;

		/// <summary>
		/// 养育长蛟
		/// </summary>
		public const int NurtureJiao = 243;

		/// <summary>
		/// 繁育长蛟
		/// </summary>
		public const int ReproductJiao = 244;

		/// <summary>
		/// 五仙剧情此地危险
		/// </summary>
		public const int Wuxian_InWugDanger = 245;

		/// <summary>
		/// 五仙剧情查问五仙
		/// </summary>
		public const int Wuxian_SeekWuxian = 246;

		/// <summary>
		/// 五仙剧情前去洗澡
		/// </summary>
		public const int Wuxian_TakeBath = 247;

		/// <summary>
		/// 五仙剧情许下心愿
		/// </summary>
		public const int Wuxian_MakeAWish = 248;

		/// <summary>
		/// 五仙剧情五仙衰落
		/// </summary>
		public const int Wuxian_RefuseRequest = 249;

		/// <summary>
		/// 五仙剧情共跳盘王
		/// </summary>
		public const int Wuxian_BaihuaAdventure = 250;

		/// <summary>
		/// 五仙剧情找百花人
		/// </summary>
		public const int Wuxian_SeekBaihua = 251;

		/// <summary>
		/// 五仙剧情共祭星典
		/// </summary>
		public const int Wuxian_KongsangAdventure = 252;

		/// <summary>
		/// 五仙剧情找空桑人
		/// </summary>
		public const int Wuxian_SeekKongsang = 253;

		/// <summary>
		/// 五仙剧情跟随鸳虫
		/// </summary>
		public const int Wuxian_FollowLove = 254;

		/// <summary>
		/// 五仙剧情心愿已了
		/// </summary>
		public const int Wuxian_FailingWish = 255;

		/// <summary>
		/// 五仙剧情身中蛊毒
		/// </summary>
		public const int Wuxian_Wugged = 256;

		/// <summary>
		/// 五仙剧情见苒心毒
		/// </summary>
		public const int Wuxian_MeetWithRan = 257;

		/// <summary>
		/// 然山剧情前往然山
		/// </summary>
		public const int Ranshan_ToRanshan = 258;

		/// <summary>
		/// 然山剧情青琅一梦
		/// </summary>
		public const int Ranshan_QinglangDream = 259;

		/// <summary>
		/// 然山剧情迁思回虑
		/// </summary>
		public const int Ranshan_AfterQinglang = 260;

		/// <summary>
		/// 然山剧情准备比武
		/// </summary>
		public const int Ranshan_LeaveRanshan = 261;

		/// <summary>
		/// 然山剧情教导华居
		/// </summary>
		public const int Ranshan_TeachHuaju = 262;

		/// <summary>
		/// 然山剧情教导玄质
		/// </summary>
		public const int Ranshan_TeachXuanzhi = 263;

		/// <summary>
		/// 然山剧情教导迎娇
		/// </summary>
		public const int Ranshan_TeachYingjiao = 264;

		/// <summary>
		/// 然山剧情回到然山
		/// </summary>
		public const int Ranshan_BackToRanshan = 265;

		/// <summary>
		/// 然山剧情等待比武
		/// </summary>
		public const int Ranshan_WaitForBiWu = 266;

		/// <summary>
		/// 然山剧情三宗比武
		/// </summary>
		public const int Ranshan_SanZongBiWu = 267;

		/// <summary>
		/// 然山剧情无问仙踪
		/// </summary>
		public const int Ranshan_End = 268;

		/// <summary>
		/// 然山剧情进入青琅阁
		/// </summary>
		public const int Ranshan_EnterQinglangge = 269;

		/// <summary>
		/// 然山剧情仙途渺渺
		/// </summary>
		public const int Ranshan_EndInAdvance = 270;

		/// <summary>
		/// 百花剧情探查疯病
		/// </summary>
		public const int Baihua_Manic = 271;

		/// <summary>
		/// 百花剧情乡村怪病
		/// </summary>
		public const int Baihua_AdventureVillageEndemic = 272;

		/// <summary>
		/// 百花剧情寻医问诊
		/// </summary>
		public const int Baihua_SeekMedCare = 273;

		/// <summary>
		/// 百花剧情百花祖师
		/// </summary>
		public const int Baihua_WaitForGurus = 274;

		/// <summary>
		/// 百花剧情等待无忧
		/// </summary>
		public const int Baihua_WaitForMelano = 275;

		/// <summary>
		/// 百花剧情寻找祖师
		/// </summary>
		public const int Baihua_SeekGuru = 276;

		/// <summary>
		/// 百花剧情等待消息
		/// </summary>
		public const int Baihua_WaitForGuruLetter = 277;

		/// <summary>
		/// 百花剧情埋伏白一
		/// </summary>
		public const int Baihua_SearchInfectedLeuko = 278;

		/// <summary>
		/// 百花剧情埋伏白二
		/// </summary>
		public const int Baihua_AmbushLeuko = 279;

		/// <summary>
		/// 百花剧情埋伏玄一
		/// </summary>
		public const int Baihua_SearchInfectedMelano = 280;

		/// <summary>
		/// 百花剧情埋伏玄二
		/// </summary>
		public const int Baihua_AmbushMelano = 281;

		/// <summary>
		/// 百花剧情玄白回村
		/// </summary>
		public const int Baihua_BringAnimalsBack = 282;

		/// <summary>
		/// 百花剧情修复关系
		/// </summary>
		public const int Baihua_RepairLMRelationship = 283;

		/// <summary>
		/// 百花剧情关系白一
		/// </summary>
		public const int Baihua_LeukoFav = 284;

		/// <summary>
		/// 百花剧情关系白二
		/// </summary>
		public const int Baihua_LeukoClose = 285;

		/// <summary>
		/// 百花剧情关系白三
		/// </summary>
		public const int Baihua_LHelpsM = 286;

		/// <summary>
		/// 百花剧情关系玄一
		/// </summary>
		public const int Baihua_MelanoFav = 287;

		/// <summary>
		/// 百花剧情关系玄二
		/// </summary>
		public const int Baihua_MelanoClose = 288;

		/// <summary>
		/// 百花剧情关系玄三
		/// </summary>
		public const int Baihua_MHelpsL = 289;

		/// <summary>
		/// 百花剧情留守太吾
		/// </summary>
		public const int Baihua_PandemicStart = 290;

		/// <summary>
		/// 百花剧情谨慎留守
		/// </summary>
		public const int Baihua_WaitForAdventure = 291;

		/// <summary>
		/// 百花剧情复生之人
		/// </summary>
		public const int Baihua_AdventureFinale = 292;

		/// <summary>
		/// 百花剧情玄白复生
		/// </summary>
		public const int Baihua_Finale = 293;

		/// <summary>
		/// 伏龙剧情伏龙天灾
		/// </summary>
		public const int Fulong_Diaster = 294;

		/// <summary>
		/// 伏龙剧情伏龙祭典
		/// </summary>
		public const int Fulong_Sacrifice = 295;

		/// <summary>
		/// 伏龙剧情星陨坠火
		/// </summary>
		public const int Fulong_Comet = 296;

		/// <summary>
		/// 伏龙剧情返回伏龙
		/// </summary>
		public const int Fulong_ReturnToFulong = 297;

		/// <summary>
		/// 伏龙剧情停留伏龙
		/// </summary>
		public const int Fulong_StayFulong = 298;

		/// <summary>
		/// 伏龙剧情查问怪事
		/// </summary>
		public const int Fulong_Mystery = 299;

		/// <summary>
		/// 伏龙剧情查问琉璃
		/// </summary>
		public const int Fulong_AskLazuli = 300;

		/// <summary>
		/// 伏龙剧情游历天下
		/// </summary>
		public const int Fulong_TravelWithLazuli = 301;

		/// <summary>
		/// 伏龙剧情再返伏龙
		/// </summary>
		public const int Fulong_BackToFulong = 302;

		/// <summary>
		/// 伏龙剧情寻找鸡毛
		/// </summary>
		public const int Fulong_SeekFeather = 303;

		/// <summary>
		/// 伏龙剧情缝制羽衣
		/// </summary>
		public const int Fulong_SewFeatherCoat = 304;

		/// <summary>
		/// 伏龙剧情敌潜伏龙
		/// </summary>
		public const int Fulong_FinaleAdventure = 305;

		/// <summary>
		/// 伏龙剧情琉璃唤归
		/// </summary>
		public const int Fulong_BackHome = 306;

		/// <summary>
		/// 神鸡寻羽
		/// </summary>
		public const int SideQuest_ChickenMap = 307;

		/// <summary>
		/// 伏龙剧情扑灭天火
		/// </summary>
		public const int Fulong_FireFighting = 308;

		/// <summary>
		/// 伏龙剧情陪伴琉璃
		/// </summary>
		public const int Fulong_StayWithLazuli = 309;

		/// <summary>
		/// 伏龙剧情琉璃回村
		/// </summary>
		public const int Fulong_TakeLazuliBackToTaiwuVillage = 310;

		/// <summary>
		/// 伏龙剧情天火连绵
		/// </summary>
		public const int Fulong_FireSeeking = 311;

		/// <summary>
		/// 铸剑剧情砸锅卖铁
		/// </summary>
		public const int Zhujian_Poverty = 312;

		/// <summary>
		/// 铸剑剧情暗巷匠人
		/// </summary>
		public const int Zhujian_Crisis = 313;

		/// <summary>
		/// 铸剑剧情火照长空
		/// </summary>
		public const int Zhujian_Furnace = 314;

		/// <summary>
		/// 铸剑剧情烟雨湛卢
		/// </summary>
		public const int Zhujian_MistyZhanlu = 315;

		/// <summary>
		/// 铸剑剧情青铜开口
		/// </summary>
		public const int Zhujian_TongshengTalking = 316;

		/// <summary>
		/// 铸剑剧情杭州奇商
		/// </summary>
		public const int Zhujian_AccessoryMerchant = 317;

		/// <summary>
		/// 铸剑剧情劝导奇商
		/// </summary>
		public const int Zhujian_ConvinceAccessory = 318;

		/// <summary>
		/// 铸剑剧情找奇货斋
		/// </summary>
		public const int Zhujian_ReplyAccessoryMerchant = 319;

		/// <summary>
		/// 铸剑剧情文山书海
		/// </summary>
		public const int Zhujian_BookMerchant = 320;

		/// <summary>
		/// 铸剑剧情劝导商人
		/// </summary>
		public const int Zhujian_ConvinceMerchants = 321;

		/// <summary>
		/// 铸剑剧情答复伏牛
		/// </summary>
		public const int Zhujian_ReplyFoodsMerchant = 322;

		/// <summary>
		/// 铸剑剧情回春药堂
		/// </summary>
		public const int Zhujian_MedicineMerchant = 323;

		/// <summary>
		/// 铸剑剧情前往五湖
		/// </summary>
		public const int Zhujian_SeekMaterialMerchant = 324;

		/// <summary>
		/// 铸剑剧情建设分会
		/// </summary>
		public const int Zhujian_ConstructBranch = 325;

		/// <summary>
		/// 铸剑剧情手足俱全
		/// </summary>
		public const int Zhujian_AdventureBodyCompelete = 326;

		/// <summary>
		/// 铸剑剧情传承技艺
		/// </summary>
		public const int Zhujian_Heir = 327;

		/// <summary>
		/// 铸剑剧情铜生好感
		/// </summary>
		public const int Zhujian_TongshengFav = 328;

		/// <summary>
		/// 铸剑剧情等待器成
		/// </summary>
		public const int Zhujian_History = 329;

		/// <summary>
		/// 铸剑剧情前往湛庐
		/// </summary>
		public const int Zhujian_ToZhanlu = 330;

		/// <summary>
		/// 铸剑剧情湛卢夜色
		/// </summary>
		public const int Zhujian_MidnightZhujian = 331;

		/// <summary>
		/// 铸剑剧情试剑大典
		/// </summary>
		public const int Zhujian_AdventureFinale = 332;

		/// <summary>
		/// 铸剑剧情太原传艺
		/// </summary>
		public const int Zhujian_TaiyuanHeirtage = 333;

		/// <summary>
		/// 铸剑剧情襄阳传艺
		/// </summary>
		public const int Zhujian_XiangyangHeritage = 334;

		/// <summary>
		/// 铸剑剧情江陵传艺
		/// </summary>
		public const int Zhujian_JianglingHeritage = 335;

		/// <summary>
		/// 铸剑剧情江陵擒贼
		/// </summary>
		public const int Zhujian_JianglingThief = 336;

		/// <summary>
		/// 铸剑剧情襄阳擒贼
		/// </summary>
		public const int Zhujian_XiangyangThief = 337;

		/// <summary>
		/// 铸剑剧情秦州擒贼
		/// </summary>
		public const int Zhujian_QinzhouThief = 338;

		/// <summary>
		/// 铸剑剧情离开湛卢
		/// </summary>
		public const int Zhujian_End = 339;

		/// <summary>
		/// 新元山剧情拜访元山
		/// </summary>
		public const int RemakeYuanshan_VisitYuanshan = 340;

		/// <summary>
		/// 新元山剧情前往静坐
		/// </summary>
		public const int RemakeYuanshan_Meditation = 341;

		/// <summary>
		/// 新元山剧情定居点村
		/// </summary>
		public const int RemakeYuanshan_Village = 342;

		/// <summary>
		/// 新元山剧情试炼一村
		/// </summary>
		public const int RemakeYuanshan_TrialVillage = 343;

		/// <summary>
		/// 新元山剧情定居点寨
		/// </summary>
		public const int RemakeYuanshan_Stockade = 344;

		/// <summary>
		/// 新元山剧情寻找阿念
		/// </summary>
		public const int RemakeYuanshan_SearchNian = 345;

		/// <summary>
		/// 新元山剧情试炼二寨
		/// </summary>
		public const int RemakeYuanshan_TrialStockade = 346;

		/// <summary>
		/// 新元山剧情定居点镇
		/// </summary>
		public const int RemakeYuanshan_Town = 347;

		/// <summary>
		/// 新元山剧情试炼三镇
		/// </summary>
		public const int RemakeYuanshan_TrialTown = 348;

		/// <summary>
		/// 新元山剧情再临元山
		/// </summary>
		public const int RemakeYuanshan_RevisitYuanshan = 349;

		/// <summary>
		/// 新元山剧情静待参悟
		/// </summary>
		public const int RemakeYuanshan_WaitForEnlightment = 350;

		/// <summary>
		/// 新元山剧情镇魔大阵
		/// </summary>
		public const int RemakeYuanshan_Adventure = 351;

		/// <summary>
		/// 新元山剧情尘埃落定
		/// </summary>
		public const int RemakeYuanshan_Finale = 352;

		/// <summary>
		/// 新元山剧情冷月孤影
		/// </summary>
		public const int RemakeYuanshan_EasterEgg = 353;

		/// <summary>
		/// 界青剧情荒野破庙
		/// </summary>
		public const int Jieqing_Temple = 354;

		/// <summary>
		/// 界青剧情七星血光
		/// </summary>
		public const int Jieqing_BloodBeiDou = 355;

		/// <summary>
		/// 界青剧情慈祥老人
		/// </summary>
		public const int Jieqing_KindOldMan = 356;

		/// <summary>
		/// 界青剧情下无生渊
		/// </summary>
		public const int Jieqing_WuShengYuan = 357;

		/// <summary>
		/// 界青剧情无名秘信
		/// </summary>
		public const int Jieqing_Message = 358;

		/// <summary>
		/// 界青剧情摔珠之期
		/// </summary>
		public const int Jieqing_SmashPearl = 359;

		/// <summary>
		/// 界青剧情最终决战
		/// </summary>
		public const int Jieqing_FinalBattle = 360;

		/// <summary>
		/// 界青剧情界青故人
		/// </summary>
		public const int Jieqing_Recovery = 361;

		/// <summary>
		/// 界青剧情探访玉蝉
		/// </summary>
		public const int Jieqing_VisitYuChan = 362;

		/// <summary>
		/// 界青剧情善恶无生
		/// </summary>
		public const int Jieqing_End = 363;

		/// <summary>
		/// 通用任务神木种植
		/// </summary>
		public const int PlantTrees = 364;

		/// <summary>
		/// 铸剑升级互动湛卢观戏
		/// </summary>
		public const int ZhujianUpgrade_drama = 365;

		/// <summary>
		/// 铸剑升级互动竹鹊传信
		/// </summary>
		public const int ZhujianUpgrade_Start = 366;

		/// <summary>
		/// 铸剑升级互动铜生观戏
		/// </summary>
		public const int ZhujianUpgrade_Prelude = 367;

		/// <summary>
		/// 铸剑升级互动山庄探秘
		/// </summary>
		public const int ZhujianUpgrade_Epitasis = 368;

		/// <summary>
		/// 铸剑升级互动玄机之谜
		/// </summary>
		public const int ZhujianUpgrade_Adventure = 369;

		/// <summary>
		/// 铸剑升级互动小童观戏
		/// </summary>
		public const int ZhujianUpgrade_Ending = 370;

		/// <summary>
		/// 武当升级互动白鹤寄书
		/// </summary>
		public const int WudangUpgrade_Crane = 371;

		/// <summary>
		/// 武当升级互动探查黑蛇
		/// </summary>
		public const int WudangUpgrade_ExploreBlackSnake = 372;

		/// <summary>
		/// 武当升级互动一言相期
		/// </summary>
		public const int WudangUpgrade_Promise = 373;

		/// <summary>
		/// 武当升级互动探望黑蛇
		/// </summary>
		public const int WudangUpgrade_VisitBlackSnake = 374;

		/// <summary>
		/// 璇女升级互动筠儿托梦
		/// </summary>
		public const int UpgradeXuannv_Dreaming = 375;

		/// <summary>
		/// 璇女升级互动再访璇女
		/// </summary>
		public const int UpgradeXuannv_ToXuannv = 376;

		/// <summary>
		/// 璇女升级互动再探宝珏
		/// </summary>
		public const int UpgradeXuannv_CrackedMirror = 377;

		/// <summary>
		/// 五仙升级互动思望苗疆
		/// </summary>
		public const int WuxianUpgrade_Homesick = 378;

		/// <summary>
		/// 五仙升级互动前往黑水
		/// </summary>
		public const int WuxianUpgrade_Heishui = 379;

		/// <summary>
		/// 五仙升级互动苗鼓之声
		/// </summary>
		public const int WuxianUpgrade_Drum = 380;

		/// <summary>
		/// 血犼升级互动鬼事渐息
		/// </summary>
		public const int XuehouUpgrade_Begin = 381;

		/// <summary>
		/// 血犼升级互动故人无音
		/// </summary>
		public const int XuehouUpgrade_FollowLetter = 382;

		/// <summary>
		/// 血犼升级互动扬州今事
		/// </summary>
		public const int XuehouUpgrade_Yangzhou = 383;

		/// <summary>
		/// 血犼升级互动寻墓而出
		/// </summary>
		public const int XuehouUpgrade_Search = 384;

		/// <summary>
		/// 空桑升级互动心毒问鼎
		/// </summary>
		public const int KongsangUpgrade_Ask = 385;

		/// <summary>
		/// 空桑升级互动观鼎生灰
		/// </summary>
		public const int KongsangUpgrade_Check = 386;

		/// <summary>
		/// 空桑升级互动药灰绽隙
		/// </summary>
		public const int KongsangUpgrade_Cauldron = 387;

		/// <summary>
		/// 空桑升级互动青鼎流辉
		/// </summary>
		public const int KongsangUpgrade_View = 388;

		/// <summary>
		/// 狮相升级互动前往村中
		/// </summary>
		public const int ShixiangUpgrade_Village = 389;

		/// <summary>
		/// 狮相升级互动等待回音
		/// </summary>
		public const int ShixiangUpgrade_Echo = 390;

		/// <summary>
		/// 狮相升级互动静待消息
		/// </summary>
		public const int ShixiangUpgrade_Message = 391;

		/// <summary>
		/// 狮相升级互动尘埃落定
		/// </summary>
		public const int ShixiangUpgrade_End = 392;

		/// <summary>
		/// 元山升级互动三气入梦
		/// </summary>
		public const int YuanshanUpgrade_Dream = 393;

		/// <summary>
		/// 元山升级互动行抵元山
		/// </summary>
		public const int YuanshanUpgrade_Journey = 394;

		/// <summary>
		/// 元山升级互动山谷妖踪
		/// </summary>
		public const int YuanshanUpgrade_Valley = 395;

		/// <summary>
		/// 然山升级互动纸鹤传书
		/// </summary>
		public const int RanShan_message = 396;

		/// <summary>
		/// 然山升级互动然山邪祟
		/// </summary>
		public const int RanShan_Ghost = 397;

		/// <summary>
		/// 然山升级互动众魂比武
		/// </summary>
		public const int RanShan_ZhongHunBiWu = 398;

		/// <summary>
		/// 然山升级互动心境深处
		/// </summary>
		public const int RanShan_XinJing = 399;

		/// <summary>
		/// 金刚升级互动村人异事
		/// </summary>
		public const int JingangUpgrade_SupernaturalEvent = 400;

		/// <summary>
		/// 金刚升级互动夜半惊魂
		/// </summary>
		public const int JingangUpgrade_Ghost = 401;

		/// <summary>
		/// 金刚升级互动一问究竟
		/// </summary>
		public const int JingangUpgrade_Ask = 402;

		/// <summary>
		/// 伏龙升级互动元鸡落羽
		/// </summary>
		public const int FulongUpgrade_Chicken = 403;

		/// <summary>
		/// 伏龙升级互动探查大王
		/// </summary>
		public const int FulongUpgrade_Dawang = 404;

		/// <summary>
		/// 伏龙升级互动琉璃制衣
		/// </summary>
		public const int FulongUpgrade_GarmentManufacturing = 405;

		/// <summary>
		/// 伏龙升级互动羽衣已成
		/// </summary>
		public const int FulongUpgrade_Clothing = 406;

		/// <summary>
		/// 百花升级互动风起故尘
		/// </summary>
		public const int BaihuaUpgrade_Start = 407;

		/// <summary>
		/// 百花升级互动白鹿解骨
		/// </summary>
		public const int BaihuaUpgrade_LeukoHealer = 408;

		/// <summary>
		/// 百花升级互动玄鸮定脉
		/// </summary>
		public const int BaihuaUpgrade_MelanoHealer = 409;

		/// <summary>
		/// 百花升级互动聚首齐论
		/// </summary>
		public const int BaihuaUpgrade_Gather = 410;

		/// <summary>
		/// 百花升级互动河谷追凶
		/// </summary>
		public const int BaihuaUpgrade_Ending = 411;

		/// <summary>
		/// 少林升级互动静待佛缘
		/// </summary>
		public const int ShaolinUpgrade_Fate = 412;

		/// <summary>
		/// 少林升级互动探访无字
		/// </summary>
		public const int ShaolinUpgrade_Wuzi = 413;

		/// <summary>
		/// 少林升级互动一探究竟
		/// </summary>
		public const int ShaolinUpgrade_Investigate = 414;

		/// <summary>
		/// 少林升级互动尘埃落定
		/// </summary>
		public const int ShaolinUpgrade_Finale = 415;

		/// <summary>
		/// 峨眉升级互动山间奇闻
		/// </summary>
		public const int EmeiUpgrade_Start = 671;

		/// <summary>
		/// 峨眉升级互动峨眉仙猿
		/// </summary>
		public const int EmeiUpgrade_Xiaobaiyuan = 672;

		/// <summary>
		/// 峨眉升级互动寻找白猿
		/// </summary>
		public const int EmeiUpgrade_Baiyuan = 673;

		/// <summary>
		/// 峨眉升级互动静待修行
		/// </summary>
		public const int EmeiUpgrade_Study = 674;

		/// <summary>
		/// 峨眉升级互动心猿已生
		/// </summary>
		public const int EmeiUpgrade_Xinyuan = 675;

		/// <summary>
		/// 峨眉升级互动静待消息
		/// </summary>
		public const int EmeiUpgrade_Ending = 676;

		/// <summary>
		/// 界青升级互动静待玉蝉
		/// </summary>
		public const int JieqingUpgrade_Start = 705;

		/// <summary>
		/// 界青升级互动渊底怪声
		/// </summary>
		public const int JieqingUpgrade_Noise = 706;

		/// <summary>
		/// 界青升级互动深渊异变
		/// </summary>
		public const int JieqingUpgrade_Abyss = 707;

		/// <summary>
		/// 界青升级互动天外寂星
		/// </summary>
		public const int JieqingUpgrade_End = 708;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 回村寻船
		/// </summary>
		public static TaskInfoItem ReturnToGetBoat => Instance[13];

		/// <summary>
		/// 以船渡河
		/// </summary>
		public static TaskInfoItem TakeBoatToLeave => Instance[14];

		/// <summary>
		/// 亡流驿站
		/// </summary>
		public static TaskInfoItem BrokenAreaTravel => Instance[19];

		/// <summary>
		/// 寻路太吾
		/// </summary>
		public static TaskInfoItem FirstArriveTaiwuArea => Instance[20];

		/// <summary>
		/// 振兴太吾
		/// </summary>
		public static TaskInfoItem SideQuest_ConstructTaiwuVillage => Instance[23];

		/// <summary>
		/// 派遣村民
		/// </summary>
		public static TaskInfoItem SideQuest_AssignVillagers => Instance[24];

		/// <summary>
		/// 耳闻仙人
		/// </summary>
		public static TaskInfoItem HearsayOfImmortal => Instance[25];

		/// <summary>
		/// 古墓仙人
		/// </summary>
		public static TaskInfoItem VisitTombImmortal => Instance[26];

		/// <summary>
		/// 仙人疑云
		/// </summary>
		public static TaskInfoItem ReturnToTaiwuVillage => Instance[27];

		/// <summary>
		/// 太吾驿站
		/// </summary>
		public static TaskInfoItem MainStory_TaiwuVillageStation => Instance[31];

		/// <summary>
		/// 以向化身1
		/// </summary>
		public static TaskInfoItem PurpleBambooYixiangChp2 => Instance[616];

		/// <summary>
		/// 等待盟会
		/// </summary>
		public static TaskInfoItem MartialArtTournamentWait => Instance[64];

		/// <summary>
		/// 筹备盟会
		/// </summary>
		public static TaskInfoItem MartialArtTournamentPrepare => Instance[65];

		/// <summary>
		/// 武林盟会
		/// </summary>
		public static TaskInfoItem MartialArtTournamentReady => Instance[66];

		/// <summary>
		/// 语茯来访
		/// </summary>
		public static TaskInfoItem YufuArrivesAtTaiwuVillage => Instance[67];

		/// <summary>
		/// 玄竹降世
		/// </summary>
		public static TaskInfoItem DarkBambooAppeared => Instance[74];

		/// <summary>
		/// 出神之法
		/// </summary>
		public static TaskInfoItem MainStory_SpiritualWanderPlace0 => Instance[82];

		/// <summary>
		/// 出神之地
		/// </summary>
		public static TaskInfoItem MainStory_SpiritualWanderPlace1 => Instance[83];

		/// <summary>
		/// 邪魔线前置-初遇魔血
		/// </summary>
		public static TaskInfoItem PreEvilFirstDemonBlood => Instance[644];

		/// <summary>
		/// 邪魔线前置-一念魔血
		/// </summary>
		public static TaskInfoItem PreEvilDemonBloodSurge => Instance[645];

		/// <summary>
		/// 邪魔线前置-欲念侵心-贪
		/// </summary>
		public static TaskInfoItem PreEvilRaga => Instance[646];

		/// <summary>
		/// 邪魔线前置-欲念侵心-嗔
		/// </summary>
		public static TaskInfoItem PreEvilDvesa => Instance[647];

		/// <summary>
		/// 邪魔线前置-欲念侵心-痴
		/// </summary>
		public static TaskInfoItem PreEvilMoha => Instance[648];

		/// <summary>
		/// 邪魔线前置-魔血玄石
		/// </summary>
		public static TaskInfoItem PreEvilDemonBloodDarkstone => Instance[649];

		/// <summary>
		/// 邪魔线前置-静待机缘
		/// </summary>
		public static TaskInfoItem PreEvilWaitForChance => Instance[650];

		/// <summary>
		/// 探听消息
		/// </summary>
		public static TaskInfoItem MainStory_Investigate => Instance[677];

		/// <summary>
		/// 流民之忧
		/// </summary>
		public static TaskInfoItem MainStory_RefugeeDistress => Instance[678];

		/// <summary>
		/// 寻找食物
		/// </summary>
		public static TaskInfoItem MainStory_FindFood => Instance[679];

		/// <summary>
		/// 医者之忧
		/// </summary>
		public static TaskInfoItem MainStory_DoctorDistress => Instance[680];

		/// <summary>
		/// 寻找药材
		/// </summary>
		public static TaskInfoItem MainStory_FindHerbs => Instance[681];

		/// <summary>
		/// 宁氏之忧
		/// </summary>
		public static TaskInfoItem MainStory_NingDistress => Instance[682];

		/// <summary>
		/// 寻找衣物
		/// </summary>
		public static TaskInfoItem MainStory_FindClothes => Instance[683];

		/// <summary>
		/// 无名伤者
		/// </summary>
		public static TaskInfoItem MainStory_UnknownPatient => Instance[684];

		/// <summary>
		/// 前往柴山
		/// </summary>
		public static TaskInfoItem MainStory_GoToChaiMountain => Instance[685];

		/// <summary>
		/// 柴山异变
		/// </summary>
		public static TaskInfoItem MainStory_ChaiShanMutation => Instance[686];

		/// <summary>
		/// 十二邪仙0
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals0 => Instance[687];

		/// <summary>
		/// 十二邪仙1
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals1 => Instance[688];

		/// <summary>
		/// 十二邪仙2
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals2 => Instance[689];

		/// <summary>
		/// 十二邪仙3
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals3 => Instance[690];

		/// <summary>
		/// 十二邪仙4
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals4 => Instance[691];

		/// <summary>
		/// 十二邪仙5
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals5 => Instance[692];

		/// <summary>
		/// 十二邪仙6
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals6 => Instance[693];

		/// <summary>
		/// 十二邪仙7
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals7 => Instance[694];

		/// <summary>
		/// 十二邪仙8
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals8 => Instance[695];

		/// <summary>
		/// 十二邪仙9
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals9 => Instance[696];

		/// <summary>
		/// 十二邪仙10
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals10 => Instance[697];

		/// <summary>
		/// 十二邪仙11
		/// </summary>
		public static TaskInfoItem MainStory_TwelveEvilImmortals11 => Instance[698];

		/// <summary>
		/// 无绡去向
		/// </summary>
		public static TaskInfoItem MainStory_WhereaboutsofZiwuxiao => Instance[701];

		/// <summary>
		/// 子夜生变
		/// </summary>
		public static TaskInfoItem MainStory_MidnightUpheaval => Instance[702];

		/// <summary>
		/// 仙公踪迹
		/// </summary>
		public static TaskInfoItem MainStory_WhereaboutsofXuxiangong => Instance[703];

		/// <summary>
		/// 决战神魔
		/// </summary>
		public static TaskInfoItem MainStory_ShowdownofGodsandDemons => Instance[704];

		/// <summary>
		/// 空桑主线奇毒绝方
		/// </summary>
		public static TaskInfoItem Kongsang_MissionUnaccepted => Instance[101];

		/// <summary>
		/// 空桑主线无命寻人0
		/// </summary>
		public static TaskInfoItem Kongsang_SearchTarget0 => Instance[102];

		/// <summary>
		/// 空桑主线无命试毒0
		/// </summary>
		public static TaskInfoItem Kongsang_PoisonTest0 => Instance[103];

		/// <summary>
		/// 空桑主线上复掌门0
		/// </summary>
		public static TaskInfoItem Kongsang_ReplySect0 => Instance[104];

		/// <summary>
		/// 空桑主线无命寻人1
		/// </summary>
		public static TaskInfoItem Kongsang_SearchTarget1 => Instance[105];

		/// <summary>
		/// 空桑主线无命试毒1
		/// </summary>
		public static TaskInfoItem Kongsang_PoisonTest1 => Instance[106];

		/// <summary>
		/// 空桑主线上复掌门1
		/// </summary>
		public static TaskInfoItem Kongsang_ReplySect1 => Instance[107];

		/// <summary>
		/// 空桑主线无命寻人2
		/// </summary>
		public static TaskInfoItem Kongsang_SearchTarget2 => Instance[108];

		/// <summary>
		/// 空桑主线无命试毒2
		/// </summary>
		public static TaskInfoItem Kongsang_PoisonTest2 => Instance[109];

		/// <summary>
		/// 空桑主线上复掌门3
		/// </summary>
		public static TaskInfoItem Kongsang_ReplySect3 => Instance[110];

		/// <summary>
		/// 空桑主线寻找无命
		/// </summary>
		public static TaskInfoItem Kongsang_FindWLiao => Instance[111];

		/// <summary>
		/// 空桑主线上复掌门2
		/// </summary>
		public static TaskInfoItem Kongsang_ReplySect2 => Instance[112];

		/// <summary>
		/// 空桑主线百年奇遇
		/// </summary>
		public static TaskInfoItem Kongsang_WaitForAdventure => Instance[113];

		/// <summary>
		/// 空桑主线长生之死
		/// </summary>
		public static TaskInfoItem Kongsang_AdventureAppeared => Instance[114];

		/// <summary>
		/// 血犼主线调查血犼
		/// </summary>
		public static TaskInfoItem Xuehou_GraveDigging => Instance[115];

		/// <summary>
		/// 血犼主线破旧铃铛
		/// </summary>
		public static TaskInfoItem Xuehou_RustBell => Instance[116];

		/// <summary>
		/// 血犼主线老人异相
		/// </summary>
		public static TaskInfoItem Xuehou_OldmanMyth => Instance[117];

		/// <summary>
		/// 血犼主线红衣老人
		/// </summary>
		public static TaskInfoItem Xuehou_Oldman => Instance[118];

		/// <summary>
		/// 血犼主线调查血光
		/// </summary>
		public static TaskInfoItem Xuehou_CheckBloodBlock => Instance[119];

		/// <summary>
		/// 血犼主线墓地邂逅
		/// </summary>
		public static TaskInfoItem Xuehou_AdventureGrave => Instance[120];

		/// <summary>
		/// 血犼主线姬穸回村
		/// </summary>
		public static TaskInfoItem Xuehou_BringJixiBack => Instance[121];

		/// <summary>
		/// 血犼主线留在村中
		/// </summary>
		public static TaskInfoItem Xuehou_StayWithJixi => Instance[122];

		/// <summary>
		/// 血犼主线村中异事
		/// </summary>
		public static TaskInfoItem Xuehou_MythInVillage => Instance[123];

		/// <summary>
		/// 血犼主线真相线索1
		/// </summary>
		public static TaskInfoItem Xuehou_TruthClue1 => Instance[124];

		/// <summary>
		/// 血犼主线假象线索1
		/// </summary>
		public static TaskInfoItem Xuehou_FalsityClue1 => Instance[125];

		/// <summary>
		/// 血犼主线真相线索2
		/// </summary>
		public static TaskInfoItem Xuehou_TruthClue2 => Instance[126];

		/// <summary>
		/// 血犼主线假象线索2
		/// </summary>
		public static TaskInfoItem Xuehou_FalsityClue2 => Instance[127];

		/// <summary>
		/// 血犼主线真相线索3
		/// </summary>
		public static TaskInfoItem Xuehou_TruthClue3 => Instance[128];

		/// <summary>
		/// 血犼主线假象线索3
		/// </summary>
		public static TaskInfoItem Xuehou_FalsityClue3 => Instance[129];

		/// <summary>
		/// 血犼主线调查姬穸
		/// </summary>
		public static TaskInfoItem Xuehou_InterrogateJixi => Instance[130];

		/// <summary>
		/// 血犼主线传剑交谈
		/// </summary>
		public static TaskInfoItem Xuehou_PassLegacy => Instance[131];

		/// <summary>
		/// 少林主线少林异动
		/// </summary>
		public static TaskInfoItem Shaolin_MythinShaolin => Instance[132];

		/// <summary>
		/// 少林主线肮脏雕像
		/// </summary>
		public static TaskInfoItem Shaolin_MuddyStatue => Instance[133];

		/// <summary>
		/// 少林主线归还雕像
		/// </summary>
		public static TaskInfoItem Shaolin_ReturnStatue => Instance[134];

		/// <summary>
		/// 少林主线留在少林
		/// </summary>
		public static TaskInfoItem Shaolin_StayAndWait => Instance[135];

		/// <summary>
		/// 少林主线老僧相会
		/// </summary>
		public static TaskInfoItem Shaolin_BodhidharmaInDream => Instance[136];

		/// <summary>
		/// 少林主线雕像碎裂
		/// </summary>
		public static TaskInfoItem Shaolin_BrokenStatue => Instance[137];

		/// <summary>
		/// 少林主线禅武之争
		/// </summary>
		public static TaskInfoItem Shaolin_Conflict => Instance[138];

		/// <summary>
		/// 少林主线努力修习
		/// </summary>
		public static TaskInfoItem Shaolin_Endeavor => Instance[139];

		/// <summary>
		/// 少林主线老僧再临
		/// </summary>
		public static TaskInfoItem Shaolin_WaitForBodhidharma => Instance[140];

		/// <summary>
		/// 少林主线挖掘宝物
		/// </summary>
		public static TaskInfoItem Shaolin_DiggingSutra => Instance[141];

		/// <summary>
		/// 少林主线老僧传授
		/// </summary>
		public static TaskInfoItem Shaolin_StudyForBodhidharmaChallenge => Instance[142];

		/// <summary>
		/// 少林主线佛学书籍
		/// </summary>
		public static TaskInfoItem Shaolin_ObtainedSutra => Instance[143];

		/// <summary>
		/// 少林主线阅读佛经
		/// </summary>
		public static TaskInfoItem Shaolin_ReadSutra => Instance[144];

		/// <summary>
		/// 少林主线少林众塔
		/// </summary>
		public static TaskInfoItem Shaolin_VisitShaolin => Instance[145];

		/// <summary>
		/// 少林主线藏经阁楼
		/// </summary>
		public static TaskInfoItem Shaolin_SutraLibrary => Instance[146];

		/// <summary>
		/// 璇女主线璇女异动
		/// </summary>
		public static TaskInfoItem Xuannv_QinAndQing => Instance[147];

		/// <summary>
		/// 璇女主线询问古曲
		/// </summary>
		public static TaskInfoItem Xuannv_WaitForLetters => Instance[148];

		/// <summary>
		/// 璇女主线古曲旋律
		/// </summary>
		public static TaskInfoItem Xuannv_SeekLetterSender => Instance[149];

		/// <summary>
		/// 璇女主线镜里孤鸾
		/// </summary>
		public static TaskInfoItem Xuannv_SeekXuannv => Instance[150];

		/// <summary>
		/// 璇女主线寻人请求
		/// </summary>
		public static TaskInfoItem Xuannv_AdventureSoulInMirror => Instance[151];

		/// <summary>
		/// 璇女主线修习功法
		/// </summary>
		public static TaskInfoItem Xuannv_RefusedToSearch => Instance[152];

		/// <summary>
		/// 璇女新主线修习功法
		/// </summary>
		public static TaskInfoItem Xuannv_Study => Instance[153];

		/// <summary>
		/// 璇女新主线返回一明
		/// </summary>
		public static TaskInfoItem Xuannv_ReturnToMirror => Instance[154];

		/// <summary>
		/// 璇女新主线回璇女峰
		/// </summary>
		public static TaskInfoItem Xuannv_TakeShiToXuannv => Instance[155];

		/// <summary>
		/// 璇女新主线静待消息
		/// </summary>
		public static TaskInfoItem Xuannv_WaitForMessage => Instance[156];

		/// <summary>
		/// 璇女新主线查问天女
		/// </summary>
		public static TaskInfoItem Xuannv_AskShadow => Instance[157];

		/// <summary>
		/// 璇女新主线查问筠儿
		/// </summary>
		public static TaskInfoItem Xuannv_AskJuner => Instance[158];

		/// <summary>
		/// 璇女新主线查问璇女
		/// </summary>
		public static TaskInfoItem Xuannv_AskXuannvSect => Instance[159];

		/// <summary>
		/// 璇女新主线考试挂科
		/// </summary>
		public static TaskInfoItem Xuannv_FailAndRetake => Instance[160];

		/// <summary>
		/// 璇女新主线准备学习
		/// </summary>
		public static TaskInfoItem Xuannv_ReadyToStudy => Instance[161];

		/// <summary>
		/// 璇女主线前往寻人
		/// </summary>
		public static TaskInfoItem Xuannv_AcceptedToSearch => Instance[162];

		/// <summary>
		/// 璇女主线等候会面
		/// </summary>
		public static TaskInfoItem Xuannv_AdventureIllusionOfMirror => Instance[163];

		/// <summary>
		/// 璇女主线探访璇女
		/// </summary>
		public static TaskInfoItem Xuannv_SeekLove => Instance[164];

		/// <summary>
		/// 璇女主线回复掌门
		/// </summary>
		public static TaskInfoItem Xuannv_WaitForReturn => Instance[165];

		/// <summary>
		/// 孤鸾镜水
		/// </summary>
		public static TaskInfoItem PlayerShadowInMirror => Instance[166];

		/// <summary>
		/// 武当主线逆练功法
		/// </summary>
		public static TaskInfoItem Wudang_Prologue => Instance[167];

		/// <summary>
		/// 武当主线等待道长
		/// </summary>
		public static TaskInfoItem Wudang_WaitForSlobbyTaoistMonk => Instance[168];

		/// <summary>
		/// 武当主线道长探查
		/// </summary>
		public static TaskInfoItem Wudang_SloppyTaoistMonkRequest => Instance[169];

		/// <summary>
		/// 武当主线探访洞天
		/// </summary>
		public static TaskInfoItem Wudang_SeekSite => Instance[170];

		/// <summary>
		/// 武当主线回复道长
		/// </summary>
		public static TaskInfoItem Wudang_ReturnToSloppyTaoistMonk => Instance[171];

		/// <summary>
		/// 武当主线养护神树
		/// </summary>
		public static TaskInfoItem Wudang_CultivateHeavenlyTreeMain => Instance[172];

		/// <summary>
		/// 武当主线种植神树
		/// </summary>
		public static TaskInfoItem Wudang_PlantHeavenlyTree => Instance[173];

		/// <summary>
		/// 武当主线守卫神树
		/// </summary>
		public static TaskInfoItem Wudang_ProtectHeavenlyTree => Instance[174];

		/// <summary>
		/// 武当主线研修道法
		/// </summary>
		public static TaskInfoItem Wudang_ReadTaoistBook => Instance[175];

		/// <summary>
		/// 武当主线取神木种
		/// </summary>
		public static TaskInfoItem Wudang_GetHeavenlyTreeSeed => Instance[176];

		/// <summary>
		/// 武当主线道长做法
		/// </summary>
		public static TaskInfoItem Wudang_TaoistMonkSacrifices => Instance[177];

		/// <summary>
		/// 武当主线最终作法
		/// </summary>
		public static TaskInfoItem Wudang_WaitForTimePassing => Instance[178];

		/// <summary>
		/// 武当主线前往武当
		/// </summary>
		public static TaskInfoItem Wudang_VisitWudang => Instance[179];

		/// <summary>
		/// 武当主线等待仙缘
		/// </summary>
		public static TaskInfoItem Wudang_WaitForImmortals => Instance[180];

		/// <summary>
		/// 武当主线查问武当
		/// </summary>
		public static TaskInfoItem Wudang_AskWudang => Instance[181];

		/// <summary>
		/// 狮相主线狮相流言
		/// </summary>
		public static TaskInfoItem Shixiang_Anecdote => Instance[182];

		/// <summary>
		/// 狮相主线前往狮相
		/// </summary>
		public static TaskInfoItem Shixiang_ArriveSect => Instance[183];

		/// <summary>
		/// 狮相主线狮相传言
		/// </summary>
		public static TaskInfoItem Shixiang_AskForJokes => Instance[184];

		/// <summary>
		/// 狮相主线狮相异动
		/// </summary>
		public static TaskInfoItem Shixiang_Myth => Instance[185];

		/// <summary>
		/// 狮相主线狮相绝技
		/// </summary>
		public static TaskInfoItem Shixiang_PoemAdventure => Instance[186];

		/// <summary>
		/// 狮相主线静观其变
		/// </summary>
		public static TaskInfoItem Shixiang_WaitforLetters => Instance[187];

		/// <summary>
		/// 狮相主线探查狮相
		/// </summary>
		public static TaskInfoItem Shixiang_Arrive => Instance[188];

		/// <summary>
		/// 狮相主线消灭外道
		/// </summary>
		public static TaskInfoItem Shixiang_Heretics => Instance[189];

		/// <summary>
		/// 狮相主线上复门主
		/// </summary>
		public static TaskInfoItem Shixiang_ReplyHead => Instance[190];

		/// <summary>
		/// 狮相主线狮相异相
		/// </summary>
		public static TaskInfoItem Shixiang_Stay => Instance[191];

		/// <summary>
		/// 狮相主线剿灭叛徒
		/// </summary>
		public static TaskInfoItem Shixiang_Traitors => Instance[192];

		/// <summary>
		/// 狮相主线驱逐异族
		/// </summary>
		public static TaskInfoItem Shixiang_Barbarians => Instance[193];

		/// <summary>
		/// 狮相主线等待清理
		/// </summary>
		public static TaskInfoItem Shixiang_WaitForBattles => Instance[194];

		/// <summary>
		/// 狮相主线静待后续
		/// </summary>
		public static TaskInfoItem Shixiang_Ending => Instance[195];

		/// <summary>
		/// 金刚主线民不聊生
		/// </summary>
		public static TaskInfoItem Jingang_Poverty => Instance[196];

		/// <summary>
		/// 金刚主线前往金刚
		/// </summary>
		public static TaskInfoItem Jingang_ToJingang => Instance[197];

		/// <summary>
		/// 金刚剧情古刹何在
		/// </summary>
		public static TaskInfoItem Jingang_AdventureAppeared => Instance[198];

		/// <summary>
		/// 金刚主线古经迷踪
		/// </summary>
		public static TaskInfoItem Jingang_Adventure => Instance[199];

		/// <summary>
		/// 金刚主线解读残经
		/// </summary>
		public static TaskInfoItem Jingang_Haunted => Instance[200];

		/// <summary>
		/// 金刚主线高僧写经
		/// </summary>
		public static TaskInfoItem Jingang_AssistReincarnation => Instance[201];

		/// <summary>
		/// 金刚主线回复高僧
		/// </summary>
		public static TaskInfoItem Jingang_WaitForReincarnation => Instance[202];

		/// <summary>
		/// 金刚主线秦州换经
		/// </summary>
		public static TaskInfoItem Jingang_ToKunlun => Instance[203];

		/// <summary>
		/// 金刚主线襄阳换经
		/// </summary>
		public static TaskInfoItem Jingang_SearchMonk => Instance[204];

		/// <summary>
		/// 金刚主线太原换经
		/// </summary>
		public static TaskInfoItem Jingang_SecInfoSpreading => Instance[205];

		/// <summary>
		/// 金刚主线京城换经
		/// </summary>
		public static TaskInfoItem Jingang_RefuseAndFailing => Instance[206];

		/// <summary>
		/// 金刚主线高僧何往
		/// </summary>
		public static TaskInfoItem Jingang_MonkEnding => Instance[207];

		/// <summary>
		/// 金刚剧情高僧消失
		/// </summary>
		public static TaskInfoItem Jingang_MonkKilled => Instance[208];

		/// <summary>
		/// 金刚剧情中原僧人
		/// </summary>
		public static TaskInfoItem Jingang_SutraDiscussion => Instance[209];

		/// <summary>
		/// 金刚剧情疑问重重
		/// </summary>
		public static TaskInfoItem Jingang_SutraFeedback => Instance[210];

		/// <summary>
		/// 金刚剧情高僧写经
		/// </summary>
		public static TaskInfoItem Jingang_SutraExplaining => Instance[211];

		/// <summary>
		/// 金刚主线了结此事
		/// </summary>
		public static TaskInfoItem Jingang_BackToJingang => Instance[212];

		/// <summary>
		/// 金刚主线交还经文
		/// </summary>
		public static TaskInfoItem Jingang_ReturnSutra => Instance[213];

		/// <summary>
		/// 金刚主线真经无字
		/// </summary>
		public static TaskInfoItem Jingang_Ending => Instance[214];

		/// <summary>
		/// 五仙主线常来洗澡
		/// </summary>
		public static TaskInfoItem Wuxian_Bath => Instance[215];

		/// <summary>
		/// 五仙主线前往百花
		/// </summary>
		public static TaskInfoItem Wuxian_ToBaihua => Instance[216];

		/// <summary>
		/// 五仙主线五仙请求
		/// </summary>
		public static TaskInfoItem Wuxian_AcceptRequest => Instance[217];

		/// <summary>
		/// 五仙主线前往空桑
		/// </summary>
		public static TaskInfoItem Wuxian_ToKongsang => Instance[218];

		/// <summary>
		/// 五仙主线回到五仙
		/// </summary>
		public static TaskInfoItem Wuxian_BackHome => Instance[219];

		/// <summary>
		/// 五仙主线心愿未了
		/// </summary>
		public static TaskInfoItem Wuxian_WishComeTrue => Instance[220];

		/// <summary>
		/// 五仙主线五圣心毒
		/// </summary>
		public static TaskInfoItem Wuxian_Adventure => Instance[221];

		/// <summary>
		/// 峨眉主线峨眉凶案
		/// </summary>
		public static TaskInfoItem Emei_HomocideCases => Instance[222];

		/// <summary>
		/// 峨眉主线凶案线索
		/// </summary>
		public static TaskInfoItem Emei_Clues => Instance[223];

		/// <summary>
		/// 峨眉主线调查白猿
		/// </summary>
		public static TaskInfoItem Emei_InvestigateWhiteGibbon => Instance[224];

		/// <summary>
		/// 峨眉主线峨眉正宗
		/// </summary>
		public static TaskInfoItem Emei_Orthrodox => Instance[225];

		/// <summary>
		/// 峨眉主线何为正宗
		/// </summary>
		public static TaskInfoItem Emei_OrthrodoxAdventure => Instance[226];

		/// <summary>
		/// 峨眉主线等待奇遇
		/// </summary>
		public static TaskInfoItem Emei_WaitForAdventure => Instance[227];

		/// <summary>
		/// 峨眉主线寻找白猿
		/// </summary>
		public static TaskInfoItem Emei_SeekWhiteGibbon => Instance[228];

		/// <summary>
		/// 峨眉主线白猿消失
		/// </summary>
		public static TaskInfoItem Emei_WhiteGibbonsDisappeared => Instance[229];

		/// <summary>
		/// 峨眉主线小石消失
		/// </summary>
		public static TaskInfoItem Emei_ShiHoujiuDisappeared => Instance[230];

		/// <summary>
		/// 峨眉新主线初探风波
		/// </summary>
		public static TaskInfoItem Emei_Prologue => Instance[709];

		/// <summary>
		/// 峨眉新主线峨眉动向
		/// </summary>
		public static TaskInfoItem Emei_StormApproaches => Instance[710];

		/// <summary>
		/// 峨眉新主线峨眉山月
		/// </summary>
		public static TaskInfoItem Emei_Midnight => Instance[711];

		/// <summary>
		/// 峨眉新主线掌门密信
		/// </summary>
		public static TaskInfoItem Emei_SecretLetter => Instance[712];

		/// <summary>
		/// 峨眉新主线急赴峨眉
		/// </summary>
		public static TaskInfoItem Emei_Crisis => Instance[713];

		/// <summary>
		/// 峨眉新主线预备比武
		/// </summary>
		public static TaskInfoItem Emei_Preparing => Instance[714];

		/// <summary>
		/// 峨眉新主线预备比武0
		/// </summary>
		public static TaskInfoItem Emei_TeachingMember => Instance[715];

		/// <summary>
		/// 峨眉新主线预备比武1
		/// </summary>
		public static TaskInfoItem Emei_SeekForWhiteGibbon => Instance[716];

		/// <summary>
		/// 峨眉新主线预备比武2
		/// </summary>
		public static TaskInfoItem Emei_SeekForXiaoshi => Instance[717];

		/// <summary>
		/// 峨眉新主线预备比武3
		/// </summary>
		public static TaskInfoItem Emei_TalkToMember => Instance[718];

		/// <summary>
		/// 峨眉新主线预备比武4
		/// </summary>
		public static TaskInfoItem Emei_TalkToVillager => Instance[719];

		/// <summary>
		/// 峨眉新主线金顶比武
		/// </summary>
		public static TaskInfoItem Emei_Tournament => Instance[720];

		/// <summary>
		/// 峨眉新主线等待休养
		/// </summary>
		public static TaskInfoItem Emei_TakeBreak => Instance[731];

		/// <summary>
		/// 峨眉新主线峨眉现状
		/// </summary>
		public static TaskInfoItem Emei_NowStates => Instance[721];

		/// <summary>
		/// 峨眉新主线暂离峨眉
		/// </summary>
		public static TaskInfoItem Emei_Leaving => Instance[722];

		/// <summary>
		/// 峨眉新主线再寻白猿
		/// </summary>
		public static TaskInfoItem Emei_SeekWhiteGibbonAgain => Instance[723];

		/// <summary>
		/// 峨眉新主线追踪恶妖
		/// </summary>
		public static TaskInfoItem Emei_SeekForEvil => Instance[724];

		/// <summary>
		/// 峨眉新主线寻找恶妖0
		/// </summary>
		public static TaskInfoItem Emei_Chat => Instance[725];

		/// <summary>
		/// 峨眉新主线追击真凶
		/// </summary>
		public static TaskInfoItem Emei_Pursuit => Instance[726];

		/// <summary>
		/// 峨眉新主线别过群侠
		/// </summary>
		public static TaskInfoItem Emei_Farewell => Instance[727];

		/// <summary>
		/// 峨眉新主线漫步峨眉
		/// </summary>
		public static TaskInfoItem Emei_WalkInMountains => Instance[728];

		/// <summary>
		/// 峨眉新主线静待了结
		/// </summary>
		public static TaskInfoItem Emei_Finale => Instance[729];

		/// <summary>
		/// 梦回剧情跟上伏虞
		/// </summary>
		public static TaskInfoItem CrossArchive_FollowFuyu => Instance[231];

		/// <summary>
		/// 梦回剧情取回行囊
		/// </summary>
		public static TaskInfoItem CrossArchive_Items => Instance[232];

		/// <summary>
		/// 梦回剧情取回技艺
		/// </summary>
		public static TaskInfoItem CrossArchive_LifeSkills => Instance[233];

		/// <summary>
		/// 梦回剧情取回功法
		/// </summary>
		public static TaskInfoItem CrossArchive_CombatSkills => Instance[234];

		/// <summary>
		/// 五方神龙回太吾村
		/// </summary>
		public static TaskInfoItem LoongDLCToVillage => Instance[235];

		/// <summary>
		/// 五方神龙前往抓龙
		/// </summary>
		public static TaskInfoItem LoongDLCCaptureLoong => Instance[236];

		/// <summary>
		/// 五方神龙养育蛟卵
		/// </summary>
		public static TaskInfoItem LoongDLCNurtureJiao => Instance[237];

		/// <summary>
		/// 挑战白龙
		/// </summary>
		public static TaskInfoItem ChallengeWhiteLoong => Instance[238];

		/// <summary>
		/// 挑战黑龙
		/// </summary>
		public static TaskInfoItem ChallengeBlackLoong => Instance[239];

		/// <summary>
		/// 挑战青龙
		/// </summary>
		public static TaskInfoItem ChallengeBlueLoong => Instance[240];

		/// <summary>
		/// 挑战赤龙
		/// </summary>
		public static TaskInfoItem ChallengeRedLoong => Instance[241];

		/// <summary>
		/// 挑战黄龙
		/// </summary>
		public static TaskInfoItem ChallengeYellowLoong => Instance[242];

		/// <summary>
		/// 养育长蛟
		/// </summary>
		public static TaskInfoItem NurtureJiao => Instance[243];

		/// <summary>
		/// 繁育长蛟
		/// </summary>
		public static TaskInfoItem ReproductJiao => Instance[244];

		/// <summary>
		/// 五仙剧情此地危险
		/// </summary>
		public static TaskInfoItem Wuxian_InWugDanger => Instance[245];

		/// <summary>
		/// 五仙剧情查问五仙
		/// </summary>
		public static TaskInfoItem Wuxian_SeekWuxian => Instance[246];

		/// <summary>
		/// 五仙剧情前去洗澡
		/// </summary>
		public static TaskInfoItem Wuxian_TakeBath => Instance[247];

		/// <summary>
		/// 五仙剧情许下心愿
		/// </summary>
		public static TaskInfoItem Wuxian_MakeAWish => Instance[248];

		/// <summary>
		/// 五仙剧情五仙衰落
		/// </summary>
		public static TaskInfoItem Wuxian_RefuseRequest => Instance[249];

		/// <summary>
		/// 五仙剧情共跳盘王
		/// </summary>
		public static TaskInfoItem Wuxian_BaihuaAdventure => Instance[250];

		/// <summary>
		/// 五仙剧情找百花人
		/// </summary>
		public static TaskInfoItem Wuxian_SeekBaihua => Instance[251];

		/// <summary>
		/// 五仙剧情共祭星典
		/// </summary>
		public static TaskInfoItem Wuxian_KongsangAdventure => Instance[252];

		/// <summary>
		/// 五仙剧情找空桑人
		/// </summary>
		public static TaskInfoItem Wuxian_SeekKongsang => Instance[253];

		/// <summary>
		/// 五仙剧情跟随鸳虫
		/// </summary>
		public static TaskInfoItem Wuxian_FollowLove => Instance[254];

		/// <summary>
		/// 五仙剧情心愿已了
		/// </summary>
		public static TaskInfoItem Wuxian_FailingWish => Instance[255];

		/// <summary>
		/// 五仙剧情身中蛊毒
		/// </summary>
		public static TaskInfoItem Wuxian_Wugged => Instance[256];

		/// <summary>
		/// 五仙剧情见苒心毒
		/// </summary>
		public static TaskInfoItem Wuxian_MeetWithRan => Instance[257];

		/// <summary>
		/// 然山剧情前往然山
		/// </summary>
		public static TaskInfoItem Ranshan_ToRanshan => Instance[258];

		/// <summary>
		/// 然山剧情青琅一梦
		/// </summary>
		public static TaskInfoItem Ranshan_QinglangDream => Instance[259];

		/// <summary>
		/// 然山剧情迁思回虑
		/// </summary>
		public static TaskInfoItem Ranshan_AfterQinglang => Instance[260];

		/// <summary>
		/// 然山剧情准备比武
		/// </summary>
		public static TaskInfoItem Ranshan_LeaveRanshan => Instance[261];

		/// <summary>
		/// 然山剧情教导华居
		/// </summary>
		public static TaskInfoItem Ranshan_TeachHuaju => Instance[262];

		/// <summary>
		/// 然山剧情教导玄质
		/// </summary>
		public static TaskInfoItem Ranshan_TeachXuanzhi => Instance[263];

		/// <summary>
		/// 然山剧情教导迎娇
		/// </summary>
		public static TaskInfoItem Ranshan_TeachYingjiao => Instance[264];

		/// <summary>
		/// 然山剧情回到然山
		/// </summary>
		public static TaskInfoItem Ranshan_BackToRanshan => Instance[265];

		/// <summary>
		/// 然山剧情等待比武
		/// </summary>
		public static TaskInfoItem Ranshan_WaitForBiWu => Instance[266];

		/// <summary>
		/// 然山剧情三宗比武
		/// </summary>
		public static TaskInfoItem Ranshan_SanZongBiWu => Instance[267];

		/// <summary>
		/// 然山剧情无问仙踪
		/// </summary>
		public static TaskInfoItem Ranshan_End => Instance[268];

		/// <summary>
		/// 然山剧情进入青琅阁
		/// </summary>
		public static TaskInfoItem Ranshan_EnterQinglangge => Instance[269];

		/// <summary>
		/// 然山剧情仙途渺渺
		/// </summary>
		public static TaskInfoItem Ranshan_EndInAdvance => Instance[270];

		/// <summary>
		/// 百花剧情探查疯病
		/// </summary>
		public static TaskInfoItem Baihua_Manic => Instance[271];

		/// <summary>
		/// 百花剧情乡村怪病
		/// </summary>
		public static TaskInfoItem Baihua_AdventureVillageEndemic => Instance[272];

		/// <summary>
		/// 百花剧情寻医问诊
		/// </summary>
		public static TaskInfoItem Baihua_SeekMedCare => Instance[273];

		/// <summary>
		/// 百花剧情百花祖师
		/// </summary>
		public static TaskInfoItem Baihua_WaitForGurus => Instance[274];

		/// <summary>
		/// 百花剧情等待无忧
		/// </summary>
		public static TaskInfoItem Baihua_WaitForMelano => Instance[275];

		/// <summary>
		/// 百花剧情寻找祖师
		/// </summary>
		public static TaskInfoItem Baihua_SeekGuru => Instance[276];

		/// <summary>
		/// 百花剧情等待消息
		/// </summary>
		public static TaskInfoItem Baihua_WaitForGuruLetter => Instance[277];

		/// <summary>
		/// 百花剧情埋伏白一
		/// </summary>
		public static TaskInfoItem Baihua_SearchInfectedLeuko => Instance[278];

		/// <summary>
		/// 百花剧情埋伏白二
		/// </summary>
		public static TaskInfoItem Baihua_AmbushLeuko => Instance[279];

		/// <summary>
		/// 百花剧情埋伏玄一
		/// </summary>
		public static TaskInfoItem Baihua_SearchInfectedMelano => Instance[280];

		/// <summary>
		/// 百花剧情埋伏玄二
		/// </summary>
		public static TaskInfoItem Baihua_AmbushMelano => Instance[281];

		/// <summary>
		/// 百花剧情玄白回村
		/// </summary>
		public static TaskInfoItem Baihua_BringAnimalsBack => Instance[282];

		/// <summary>
		/// 百花剧情修复关系
		/// </summary>
		public static TaskInfoItem Baihua_RepairLMRelationship => Instance[283];

		/// <summary>
		/// 百花剧情关系白一
		/// </summary>
		public static TaskInfoItem Baihua_LeukoFav => Instance[284];

		/// <summary>
		/// 百花剧情关系白二
		/// </summary>
		public static TaskInfoItem Baihua_LeukoClose => Instance[285];

		/// <summary>
		/// 百花剧情关系白三
		/// </summary>
		public static TaskInfoItem Baihua_LHelpsM => Instance[286];

		/// <summary>
		/// 百花剧情关系玄一
		/// </summary>
		public static TaskInfoItem Baihua_MelanoFav => Instance[287];

		/// <summary>
		/// 百花剧情关系玄二
		/// </summary>
		public static TaskInfoItem Baihua_MelanoClose => Instance[288];

		/// <summary>
		/// 百花剧情关系玄三
		/// </summary>
		public static TaskInfoItem Baihua_MHelpsL => Instance[289];

		/// <summary>
		/// 百花剧情留守太吾
		/// </summary>
		public static TaskInfoItem Baihua_PandemicStart => Instance[290];

		/// <summary>
		/// 百花剧情谨慎留守
		/// </summary>
		public static TaskInfoItem Baihua_WaitForAdventure => Instance[291];

		/// <summary>
		/// 百花剧情复生之人
		/// </summary>
		public static TaskInfoItem Baihua_AdventureFinale => Instance[292];

		/// <summary>
		/// 百花剧情玄白复生
		/// </summary>
		public static TaskInfoItem Baihua_Finale => Instance[293];

		/// <summary>
		/// 伏龙剧情伏龙天灾
		/// </summary>
		public static TaskInfoItem Fulong_Diaster => Instance[294];

		/// <summary>
		/// 伏龙剧情伏龙祭典
		/// </summary>
		public static TaskInfoItem Fulong_Sacrifice => Instance[295];

		/// <summary>
		/// 伏龙剧情星陨坠火
		/// </summary>
		public static TaskInfoItem Fulong_Comet => Instance[296];

		/// <summary>
		/// 伏龙剧情返回伏龙
		/// </summary>
		public static TaskInfoItem Fulong_ReturnToFulong => Instance[297];

		/// <summary>
		/// 伏龙剧情停留伏龙
		/// </summary>
		public static TaskInfoItem Fulong_StayFulong => Instance[298];

		/// <summary>
		/// 伏龙剧情查问怪事
		/// </summary>
		public static TaskInfoItem Fulong_Mystery => Instance[299];

		/// <summary>
		/// 伏龙剧情查问琉璃
		/// </summary>
		public static TaskInfoItem Fulong_AskLazuli => Instance[300];

		/// <summary>
		/// 伏龙剧情游历天下
		/// </summary>
		public static TaskInfoItem Fulong_TravelWithLazuli => Instance[301];

		/// <summary>
		/// 伏龙剧情再返伏龙
		/// </summary>
		public static TaskInfoItem Fulong_BackToFulong => Instance[302];

		/// <summary>
		/// 伏龙剧情寻找鸡毛
		/// </summary>
		public static TaskInfoItem Fulong_SeekFeather => Instance[303];

		/// <summary>
		/// 伏龙剧情缝制羽衣
		/// </summary>
		public static TaskInfoItem Fulong_SewFeatherCoat => Instance[304];

		/// <summary>
		/// 伏龙剧情敌潜伏龙
		/// </summary>
		public static TaskInfoItem Fulong_FinaleAdventure => Instance[305];

		/// <summary>
		/// 伏龙剧情琉璃唤归
		/// </summary>
		public static TaskInfoItem Fulong_BackHome => Instance[306];

		/// <summary>
		/// 神鸡寻羽
		/// </summary>
		public static TaskInfoItem SideQuest_ChickenMap => Instance[307];

		/// <summary>
		/// 伏龙剧情扑灭天火
		/// </summary>
		public static TaskInfoItem Fulong_FireFighting => Instance[308];

		/// <summary>
		/// 伏龙剧情陪伴琉璃
		/// </summary>
		public static TaskInfoItem Fulong_StayWithLazuli => Instance[309];

		/// <summary>
		/// 伏龙剧情琉璃回村
		/// </summary>
		public static TaskInfoItem Fulong_TakeLazuliBackToTaiwuVillage => Instance[310];

		/// <summary>
		/// 伏龙剧情天火连绵
		/// </summary>
		public static TaskInfoItem Fulong_FireSeeking => Instance[311];

		/// <summary>
		/// 铸剑剧情砸锅卖铁
		/// </summary>
		public static TaskInfoItem Zhujian_Poverty => Instance[312];

		/// <summary>
		/// 铸剑剧情暗巷匠人
		/// </summary>
		public static TaskInfoItem Zhujian_Crisis => Instance[313];

		/// <summary>
		/// 铸剑剧情火照长空
		/// </summary>
		public static TaskInfoItem Zhujian_Furnace => Instance[314];

		/// <summary>
		/// 铸剑剧情烟雨湛卢
		/// </summary>
		public static TaskInfoItem Zhujian_MistyZhanlu => Instance[315];

		/// <summary>
		/// 铸剑剧情青铜开口
		/// </summary>
		public static TaskInfoItem Zhujian_TongshengTalking => Instance[316];

		/// <summary>
		/// 铸剑剧情杭州奇商
		/// </summary>
		public static TaskInfoItem Zhujian_AccessoryMerchant => Instance[317];

		/// <summary>
		/// 铸剑剧情劝导奇商
		/// </summary>
		public static TaskInfoItem Zhujian_ConvinceAccessory => Instance[318];

		/// <summary>
		/// 铸剑剧情找奇货斋
		/// </summary>
		public static TaskInfoItem Zhujian_ReplyAccessoryMerchant => Instance[319];

		/// <summary>
		/// 铸剑剧情文山书海
		/// </summary>
		public static TaskInfoItem Zhujian_BookMerchant => Instance[320];

		/// <summary>
		/// 铸剑剧情劝导商人
		/// </summary>
		public static TaskInfoItem Zhujian_ConvinceMerchants => Instance[321];

		/// <summary>
		/// 铸剑剧情答复伏牛
		/// </summary>
		public static TaskInfoItem Zhujian_ReplyFoodsMerchant => Instance[322];

		/// <summary>
		/// 铸剑剧情回春药堂
		/// </summary>
		public static TaskInfoItem Zhujian_MedicineMerchant => Instance[323];

		/// <summary>
		/// 铸剑剧情前往五湖
		/// </summary>
		public static TaskInfoItem Zhujian_SeekMaterialMerchant => Instance[324];

		/// <summary>
		/// 铸剑剧情建设分会
		/// </summary>
		public static TaskInfoItem Zhujian_ConstructBranch => Instance[325];

		/// <summary>
		/// 铸剑剧情手足俱全
		/// </summary>
		public static TaskInfoItem Zhujian_AdventureBodyCompelete => Instance[326];

		/// <summary>
		/// 铸剑剧情传承技艺
		/// </summary>
		public static TaskInfoItem Zhujian_Heir => Instance[327];

		/// <summary>
		/// 铸剑剧情铜生好感
		/// </summary>
		public static TaskInfoItem Zhujian_TongshengFav => Instance[328];

		/// <summary>
		/// 铸剑剧情等待器成
		/// </summary>
		public static TaskInfoItem Zhujian_History => Instance[329];

		/// <summary>
		/// 铸剑剧情前往湛庐
		/// </summary>
		public static TaskInfoItem Zhujian_ToZhanlu => Instance[330];

		/// <summary>
		/// 铸剑剧情湛卢夜色
		/// </summary>
		public static TaskInfoItem Zhujian_MidnightZhujian => Instance[331];

		/// <summary>
		/// 铸剑剧情试剑大典
		/// </summary>
		public static TaskInfoItem Zhujian_AdventureFinale => Instance[332];

		/// <summary>
		/// 铸剑剧情太原传艺
		/// </summary>
		public static TaskInfoItem Zhujian_TaiyuanHeirtage => Instance[333];

		/// <summary>
		/// 铸剑剧情襄阳传艺
		/// </summary>
		public static TaskInfoItem Zhujian_XiangyangHeritage => Instance[334];

		/// <summary>
		/// 铸剑剧情江陵传艺
		/// </summary>
		public static TaskInfoItem Zhujian_JianglingHeritage => Instance[335];

		/// <summary>
		/// 铸剑剧情江陵擒贼
		/// </summary>
		public static TaskInfoItem Zhujian_JianglingThief => Instance[336];

		/// <summary>
		/// 铸剑剧情襄阳擒贼
		/// </summary>
		public static TaskInfoItem Zhujian_XiangyangThief => Instance[337];

		/// <summary>
		/// 铸剑剧情秦州擒贼
		/// </summary>
		public static TaskInfoItem Zhujian_QinzhouThief => Instance[338];

		/// <summary>
		/// 铸剑剧情离开湛卢
		/// </summary>
		public static TaskInfoItem Zhujian_End => Instance[339];

		/// <summary>
		/// 新元山剧情拜访元山
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_VisitYuanshan => Instance[340];

		/// <summary>
		/// 新元山剧情前往静坐
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Meditation => Instance[341];

		/// <summary>
		/// 新元山剧情定居点村
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Village => Instance[342];

		/// <summary>
		/// 新元山剧情试炼一村
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_TrialVillage => Instance[343];

		/// <summary>
		/// 新元山剧情定居点寨
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Stockade => Instance[344];

		/// <summary>
		/// 新元山剧情寻找阿念
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_SearchNian => Instance[345];

		/// <summary>
		/// 新元山剧情试炼二寨
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_TrialStockade => Instance[346];

		/// <summary>
		/// 新元山剧情定居点镇
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Town => Instance[347];

		/// <summary>
		/// 新元山剧情试炼三镇
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_TrialTown => Instance[348];

		/// <summary>
		/// 新元山剧情再临元山
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_RevisitYuanshan => Instance[349];

		/// <summary>
		/// 新元山剧情静待参悟
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_WaitForEnlightment => Instance[350];

		/// <summary>
		/// 新元山剧情镇魔大阵
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Adventure => Instance[351];

		/// <summary>
		/// 新元山剧情尘埃落定
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_Finale => Instance[352];

		/// <summary>
		/// 新元山剧情冷月孤影
		/// </summary>
		public static TaskInfoItem RemakeYuanshan_EasterEgg => Instance[353];

		/// <summary>
		/// 界青剧情荒野破庙
		/// </summary>
		public static TaskInfoItem Jieqing_Temple => Instance[354];

		/// <summary>
		/// 界青剧情七星血光
		/// </summary>
		public static TaskInfoItem Jieqing_BloodBeiDou => Instance[355];

		/// <summary>
		/// 界青剧情慈祥老人
		/// </summary>
		public static TaskInfoItem Jieqing_KindOldMan => Instance[356];

		/// <summary>
		/// 界青剧情下无生渊
		/// </summary>
		public static TaskInfoItem Jieqing_WuShengYuan => Instance[357];

		/// <summary>
		/// 界青剧情无名秘信
		/// </summary>
		public static TaskInfoItem Jieqing_Message => Instance[358];

		/// <summary>
		/// 界青剧情摔珠之期
		/// </summary>
		public static TaskInfoItem Jieqing_SmashPearl => Instance[359];

		/// <summary>
		/// 界青剧情最终决战
		/// </summary>
		public static TaskInfoItem Jieqing_FinalBattle => Instance[360];

		/// <summary>
		/// 界青剧情界青故人
		/// </summary>
		public static TaskInfoItem Jieqing_Recovery => Instance[361];

		/// <summary>
		/// 界青剧情探访玉蝉
		/// </summary>
		public static TaskInfoItem Jieqing_VisitYuChan => Instance[362];

		/// <summary>
		/// 界青剧情善恶无生
		/// </summary>
		public static TaskInfoItem Jieqing_End => Instance[363];

		/// <summary>
		/// 通用任务神木种植
		/// </summary>
		public static TaskInfoItem PlantTrees => Instance[364];

		/// <summary>
		/// 铸剑升级互动湛卢观戏
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_drama => Instance[365];

		/// <summary>
		/// 铸剑升级互动竹鹊传信
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_Start => Instance[366];

		/// <summary>
		/// 铸剑升级互动铜生观戏
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_Prelude => Instance[367];

		/// <summary>
		/// 铸剑升级互动山庄探秘
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_Epitasis => Instance[368];

		/// <summary>
		/// 铸剑升级互动玄机之谜
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_Adventure => Instance[369];

		/// <summary>
		/// 铸剑升级互动小童观戏
		/// </summary>
		public static TaskInfoItem ZhujianUpgrade_Ending => Instance[370];

		/// <summary>
		/// 武当升级互动白鹤寄书
		/// </summary>
		public static TaskInfoItem WudangUpgrade_Crane => Instance[371];

		/// <summary>
		/// 武当升级互动探查黑蛇
		/// </summary>
		public static TaskInfoItem WudangUpgrade_ExploreBlackSnake => Instance[372];

		/// <summary>
		/// 武当升级互动一言相期
		/// </summary>
		public static TaskInfoItem WudangUpgrade_Promise => Instance[373];

		/// <summary>
		/// 武当升级互动探望黑蛇
		/// </summary>
		public static TaskInfoItem WudangUpgrade_VisitBlackSnake => Instance[374];

		/// <summary>
		/// 璇女升级互动筠儿托梦
		/// </summary>
		public static TaskInfoItem UpgradeXuannv_Dreaming => Instance[375];

		/// <summary>
		/// 璇女升级互动再访璇女
		/// </summary>
		public static TaskInfoItem UpgradeXuannv_ToXuannv => Instance[376];

		/// <summary>
		/// 璇女升级互动再探宝珏
		/// </summary>
		public static TaskInfoItem UpgradeXuannv_CrackedMirror => Instance[377];

		/// <summary>
		/// 五仙升级互动思望苗疆
		/// </summary>
		public static TaskInfoItem WuxianUpgrade_Homesick => Instance[378];

		/// <summary>
		/// 五仙升级互动前往黑水
		/// </summary>
		public static TaskInfoItem WuxianUpgrade_Heishui => Instance[379];

		/// <summary>
		/// 五仙升级互动苗鼓之声
		/// </summary>
		public static TaskInfoItem WuxianUpgrade_Drum => Instance[380];

		/// <summary>
		/// 血犼升级互动鬼事渐息
		/// </summary>
		public static TaskInfoItem XuehouUpgrade_Begin => Instance[381];

		/// <summary>
		/// 血犼升级互动故人无音
		/// </summary>
		public static TaskInfoItem XuehouUpgrade_FollowLetter => Instance[382];

		/// <summary>
		/// 血犼升级互动扬州今事
		/// </summary>
		public static TaskInfoItem XuehouUpgrade_Yangzhou => Instance[383];

		/// <summary>
		/// 血犼升级互动寻墓而出
		/// </summary>
		public static TaskInfoItem XuehouUpgrade_Search => Instance[384];

		/// <summary>
		/// 空桑升级互动心毒问鼎
		/// </summary>
		public static TaskInfoItem KongsangUpgrade_Ask => Instance[385];

		/// <summary>
		/// 空桑升级互动观鼎生灰
		/// </summary>
		public static TaskInfoItem KongsangUpgrade_Check => Instance[386];

		/// <summary>
		/// 空桑升级互动药灰绽隙
		/// </summary>
		public static TaskInfoItem KongsangUpgrade_Cauldron => Instance[387];

		/// <summary>
		/// 空桑升级互动青鼎流辉
		/// </summary>
		public static TaskInfoItem KongsangUpgrade_View => Instance[388];

		/// <summary>
		/// 狮相升级互动前往村中
		/// </summary>
		public static TaskInfoItem ShixiangUpgrade_Village => Instance[389];

		/// <summary>
		/// 狮相升级互动等待回音
		/// </summary>
		public static TaskInfoItem ShixiangUpgrade_Echo => Instance[390];

		/// <summary>
		/// 狮相升级互动静待消息
		/// </summary>
		public static TaskInfoItem ShixiangUpgrade_Message => Instance[391];

		/// <summary>
		/// 狮相升级互动尘埃落定
		/// </summary>
		public static TaskInfoItem ShixiangUpgrade_End => Instance[392];

		/// <summary>
		/// 元山升级互动三气入梦
		/// </summary>
		public static TaskInfoItem YuanshanUpgrade_Dream => Instance[393];

		/// <summary>
		/// 元山升级互动行抵元山
		/// </summary>
		public static TaskInfoItem YuanshanUpgrade_Journey => Instance[394];

		/// <summary>
		/// 元山升级互动山谷妖踪
		/// </summary>
		public static TaskInfoItem YuanshanUpgrade_Valley => Instance[395];

		/// <summary>
		/// 然山升级互动纸鹤传书
		/// </summary>
		public static TaskInfoItem RanShan_message => Instance[396];

		/// <summary>
		/// 然山升级互动然山邪祟
		/// </summary>
		public static TaskInfoItem RanShan_Ghost => Instance[397];

		/// <summary>
		/// 然山升级互动众魂比武
		/// </summary>
		public static TaskInfoItem RanShan_ZhongHunBiWu => Instance[398];

		/// <summary>
		/// 然山升级互动心境深处
		/// </summary>
		public static TaskInfoItem RanShan_XinJing => Instance[399];

		/// <summary>
		/// 金刚升级互动村人异事
		/// </summary>
		public static TaskInfoItem JingangUpgrade_SupernaturalEvent => Instance[400];

		/// <summary>
		/// 金刚升级互动夜半惊魂
		/// </summary>
		public static TaskInfoItem JingangUpgrade_Ghost => Instance[401];

		/// <summary>
		/// 金刚升级互动一问究竟
		/// </summary>
		public static TaskInfoItem JingangUpgrade_Ask => Instance[402];

		/// <summary>
		/// 伏龙升级互动元鸡落羽
		/// </summary>
		public static TaskInfoItem FulongUpgrade_Chicken => Instance[403];

		/// <summary>
		/// 伏龙升级互动探查大王
		/// </summary>
		public static TaskInfoItem FulongUpgrade_Dawang => Instance[404];

		/// <summary>
		/// 伏龙升级互动琉璃制衣
		/// </summary>
		public static TaskInfoItem FulongUpgrade_GarmentManufacturing => Instance[405];

		/// <summary>
		/// 伏龙升级互动羽衣已成
		/// </summary>
		public static TaskInfoItem FulongUpgrade_Clothing => Instance[406];

		/// <summary>
		/// 百花升级互动风起故尘
		/// </summary>
		public static TaskInfoItem BaihuaUpgrade_Start => Instance[407];

		/// <summary>
		/// 百花升级互动白鹿解骨
		/// </summary>
		public static TaskInfoItem BaihuaUpgrade_LeukoHealer => Instance[408];

		/// <summary>
		/// 百花升级互动玄鸮定脉
		/// </summary>
		public static TaskInfoItem BaihuaUpgrade_MelanoHealer => Instance[409];

		/// <summary>
		/// 百花升级互动聚首齐论
		/// </summary>
		public static TaskInfoItem BaihuaUpgrade_Gather => Instance[410];

		/// <summary>
		/// 百花升级互动河谷追凶
		/// </summary>
		public static TaskInfoItem BaihuaUpgrade_Ending => Instance[411];

		/// <summary>
		/// 少林升级互动静待佛缘
		/// </summary>
		public static TaskInfoItem ShaolinUpgrade_Fate => Instance[412];

		/// <summary>
		/// 少林升级互动探访无字
		/// </summary>
		public static TaskInfoItem ShaolinUpgrade_Wuzi => Instance[413];

		/// <summary>
		/// 少林升级互动一探究竟
		/// </summary>
		public static TaskInfoItem ShaolinUpgrade_Investigate => Instance[414];

		/// <summary>
		/// 少林升级互动尘埃落定
		/// </summary>
		public static TaskInfoItem ShaolinUpgrade_Finale => Instance[415];

		/// <summary>
		/// 峨眉升级互动山间奇闻
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Start => Instance[671];

		/// <summary>
		/// 峨眉升级互动峨眉仙猿
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Xiaobaiyuan => Instance[672];

		/// <summary>
		/// 峨眉升级互动寻找白猿
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Baiyuan => Instance[673];

		/// <summary>
		/// 峨眉升级互动静待修行
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Study => Instance[674];

		/// <summary>
		/// 峨眉升级互动心猿已生
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Xinyuan => Instance[675];

		/// <summary>
		/// 峨眉升级互动静待消息
		/// </summary>
		public static TaskInfoItem EmeiUpgrade_Ending => Instance[676];

		/// <summary>
		/// 界青升级互动静待玉蝉
		/// </summary>
		public static TaskInfoItem JieqingUpgrade_Start => Instance[705];

		/// <summary>
		/// 界青升级互动渊底怪声
		/// </summary>
		public static TaskInfoItem JieqingUpgrade_Noise => Instance[706];

		/// <summary>
		/// 界青升级互动深渊异变
		/// </summary>
		public static TaskInfoItem JieqingUpgrade_Abyss => Instance[707];

		/// <summary>
		/// 界青升级互动天外寂星
		/// </summary>
		public static TaskInfoItem JieqingUpgrade_End => Instance[708];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaskInfo Instance = new TaskInfo();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"TaskTitle", "TaskOverview", "TaskDescription", "TaskBubblesContent", "TaskDescriptionMeet", "RunCondition", "FinishCondition", "BlockCondition", "StartTaskChainsWhenFinish", "RequireFinishedTask",
		"RequireUntriggeredTask", "CharacterTemplateId", "MonthlyNotifications", "MonthlyEvents", "TemplateId", "EventArgBoxKey", "CombatSkillIdsEventArgBoxKey", "SkillIdsEventArgBoxKey", "FrontEndKey", "StringArrayEventArgBoxKey"
	};

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new TaskInfoItem(0, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_0"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_0"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_0"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_0"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_0"), 180, new List<int>(), new List<int> { 4 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(1, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_1"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_1"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_1"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_1"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_1"), 120, new List<int> { 1 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(2, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_2"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_2"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_2"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_2"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_2"), 180, new List<int> { 0 }, new List<int> { 3 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(3, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_3"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_3"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_3"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_3"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_3"), 180, new List<int> { 228 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(4, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_4"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_4"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_4"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_4"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_4"), 180, new List<int> { 5 }, new List<int> { 6 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(5, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_5"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_5"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_5"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_5"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_5"), 180, new List<int> { 6 }, new List<int> { 223 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(6, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_6"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_6"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_6"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_6"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_6"), 180, new List<int> { 229 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(7, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_7"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_7"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_7"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_7"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_7"), 120, new List<int> { 13 }, new List<int> { 225 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(8, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_8"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_8"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_8"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_8"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_8"), 120, new List<int> { 27 }, new List<int> { 226 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(9, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_9"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_9"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_9"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_9"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_9"), 120, new List<int> { 12, 16 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(10, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_10"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_10"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_10"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_10"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_10"), 120, new List<int>(), new List<int> { 227 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(11, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_11"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_11"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_11"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_11"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_11"), 120, new List<int> { 21, 11 }, new List<int> { 9 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(12, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_12"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_12"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_12"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_12"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_12"), 120, new List<int> { 9 }, new List<int> { 224 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(13, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_13"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_13"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_13"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_13"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_13"), 180, new List<int> { 8, 10 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(14, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_14"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_14"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_14"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_14"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_14"), 180, new List<int> { 9 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(15, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_15"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_15"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_15"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_15"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_15"), 120, new List<int> { 14 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(16, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_16"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_16"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_16"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_16"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_16"), 120, new List<int> { 15 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(17, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_17"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_17"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_17"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_17"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_17"), 120, new List<int>(), new List<int> { 8 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(18, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_18"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_18"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_18"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_18"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_18"), 180, new List<int> { 20 }, new List<int> { 222 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(19, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_19"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_19"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_19"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_19"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_19"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(20, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_20"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_20"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_20"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_20"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_20"), 180, new List<int>(), new List<int> { 253 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(21, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_21"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_21"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_21"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_21"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_21"), 180, new List<int> { 26 }, new List<int> { 25 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(22, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_22"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_22"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_22"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_22"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_22"), 240, new List<int> { 25, 248 }, new List<int> { 25, 29 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(23, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_23"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_23"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_23"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_23"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_23"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(24, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_24"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_24"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_24"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_24"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_24"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(25, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_25"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_25"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_25"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_25"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_25"), 120, new List<int>(), new List<int> { 30 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(26, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_26"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_26"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_26"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_26"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_26"), 180, new List<int> { 30 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(27, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_27"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_27"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_27"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_27"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_27"), 120, new List<int>(), new List<int> { 62 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(28, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_28"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_28"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_28"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_28"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_28"), 180, new List<int> { 62, 74 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(29, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_29"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_29"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_29"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_29"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_29"), 180, new List<int> { 62, 73 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(30, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_30"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_30"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_30"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_30"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_30"), 180, new List<int> { 62 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), 31, 75, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(31, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_31"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_31"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_31"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_31"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_31"), 180, new List<int> { 75 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(32, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_32"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_32"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_32"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_32"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_32"), 180, new List<int>(), new List<int> { 28 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(33, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_33"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_33"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_33"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_33"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_33"), 120, new List<int> { 117 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(34, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_34"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_34"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_34"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_34"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_34"), 180, new List<int>(), new List<int> { 107 }, new List<int> { 97 }, isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(35, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_35"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_35"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_35"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_35"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_35"), 180, new List<int> { 77 }, new List<int> { 98 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(36, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_36"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_36"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_36"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_36"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_36"), 180, new List<int> { 78 }, new List<int> { 99 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(37, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_37"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_37"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_37"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_37"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_37"), 180, new List<int> { 79 }, new List<int> { 100 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(38, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_38"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_38"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_38"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_38"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_38"), 180, new List<int> { 80 }, new List<int> { 101 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(39, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_39"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_39"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_39"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_39"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_39"), 180, new List<int> { 81 }, new List<int> { 102 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(40, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_40"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_40"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_40"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_40"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_40"), 180, new List<int> { 82 }, new List<int> { 103 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(41, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_41"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_41"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_41"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_41"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_41"), 180, new List<int> { 83 }, new List<int> { 104 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(42, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_42"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_42"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_42"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_42"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_42"), 180, new List<int> { 84 }, new List<int> { 105 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(43, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_43"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_43"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_43"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_43"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_43"), 180, new List<int> { 85 }, new List<int> { 106 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 75, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(44, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_44"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_44"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_44"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_44"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_44"), 180, new List<int> { 217 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(45, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_45"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_45"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_45"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_45"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_45"), 180, new List<int> { 121 }, new List<int> { 215 }, new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), 31, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(46, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_46"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_46"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_46"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_46"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_46"), 180, new List<int> { 215 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), 31, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(47, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_47"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_47"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_47"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_47"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_47"), 180, new List<int> { 218 }, new List<int> { 204 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(48, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_48"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_48"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_48"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_48"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_48"), 120, new List<int> { 126 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 31, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(49, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_49"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_49"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_49"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_49"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_49"), 180, new List<int> { 219 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(50, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_50"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_50"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_50"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_50"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_50"), 180, new List<int> { 130 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), 49, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(51, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_51"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_51"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_51"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_51"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_51"), 180, new List<int> { 141 }, new List<int> { 181 }, new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), 49, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 0));
		_dataArray.Add(new TaskInfoItem(52, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_52"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_52"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_52"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_52"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_52"), 120, new List<int> { 163 }, new List<int> { 172 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(53, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_53"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_53"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_53"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_53"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_53"), 120, new List<int> { 164 }, new List<int> { 173 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(54, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_54"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_54"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_54"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_54"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_54"), 120, new List<int> { 165 }, new List<int> { 174 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(55, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_55"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_55"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_55"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_55"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_55"), 120, new List<int> { 166 }, new List<int> { 175 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(56, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_56"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_56"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_56"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_56"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_56"), 120, new List<int> { 167 }, new List<int> { 176 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(57, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_57"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_57"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_57"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_57"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_57"), 120, new List<int> { 168 }, new List<int> { 177 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(58, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_58"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_58"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_58"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_58"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_58"), 120, new List<int> { 169 }, new List<int> { 178 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(59, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_59"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_59"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_59"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_59"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_59"), 120, new List<int> { 170 }, new List<int> { 179 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TaskInfoItem(60, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_60"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_60"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_60"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_60"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_60"), 120, new List<int> { 171 }, new List<int> { 180 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(61, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_61"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_61"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_61"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_61"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_61"), 180, new List<int>(), new List<int> { 221 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(62, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_62"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_62"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_62"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_62"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_62"), 180, new List<int> { 182, 184 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 61, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(63, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_63"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_63"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_63"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_63"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_63"), 120, new List<int> { 128, 162 }, new List<int> { 214 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), 61, 83, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(64, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_64"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_64"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_64"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_64"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_64"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(65, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_65"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_65"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_65"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_65"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_65"), 180, new List<int> { 203 }, new List<int> { 76 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(66, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_66"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_66"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_66"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_66"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_66"), 180, new List<int>(), new List<int> { 247 }, new List<int> { 87 }, isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(67, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_67"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_67"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_67"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_67"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_67"), 180, new List<int> { 247 }, new List<int> { 86 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(68, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_68"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_68"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_68"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_68"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_68"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), "MainStoryGoldenLineLoc", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(69, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_69"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_69"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_69"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_69"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_69"), 180, new List<int> { 86 }, new List<int> { 187 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(70, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_70"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_70"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_70"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_70"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_70"), 120, new List<int> { 187, 250, 251 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(396, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(71, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_71"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_71"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_71"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_71"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_71"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(397, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(72, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_72"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_72"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_72"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_72"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_72"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[3]
		{
			new AutoTriggerMonthlyEvent(398, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(399, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(400, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(73, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_73"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_73"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_73"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_73"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_73"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(74, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_74"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_74"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_74"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_74"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_74"), 180, new List<int> { 187, 188 }, new List<int> { 187, 86 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(75, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_75"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_75"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_75"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_75"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_75"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(405, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(76, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_76"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_76"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_76"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_76"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_76"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(401)
		}, 1));
		_dataArray.Add(new TaskInfoItem(77, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_77"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_77"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_77"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_77"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_77"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 0));
		_dataArray.Add(new TaskInfoItem(78, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_78"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_78"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_78"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_78"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_78"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "MainStoryFireDemonBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(79, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_79"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_79"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_79"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_79"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_79"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "MainStoryBloodDemonBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(80, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_80"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_80"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_80"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_80"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_80"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "MainStoryMeleeDemonBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(81, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_81"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_81"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_81"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_81"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_81"), 180, new List<int> { 191 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(82, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_82"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_82"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_82"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_82"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_82"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(83, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_83"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_83"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_83"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_83"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_83"), 180, new List<int>(), new List<int> { 193 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(84, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_84"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_84"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_84"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_84"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_84"), 180, new List<int> { 193 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(85, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_85"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_85"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_85"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_85"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_85"), 180, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(86, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_86"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_86"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_86"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_86"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_86"), 180, new List<int>(), new List<int> { 231 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(87, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_87"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_87"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_87"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_87"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_87"), 180, new List<int>(), new List<int> { 232 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(88, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_88"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_88"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_88"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_88"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_88"), 180, new List<int>(), new List<int> { 233 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(89, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_89"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_89"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_89"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_89"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_89"), 180, new List<int>(), new List<int> { 234 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(90, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_90"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_90"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_90"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_90"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_90"), 180, new List<int>(), new List<int> { 235 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(91, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_91"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_91"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_91"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_91"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_91"), 180, new List<int>(), new List<int> { 236 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(92, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_92"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_92"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_92"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_92"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_92"), 180, new List<int>(), new List<int> { 237 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(93, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_93"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_93"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_93"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_93"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_93"), 180, new List<int>(), new List<int> { 238 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(94, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_94"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_94"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_94"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_94"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_94"), 180, new List<int>(), new List<int> { 239 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(95, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_95"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_95"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_95"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_95"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_95"), 180, new List<int>(), new List<int> { 240 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(96, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_96"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_96"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_96"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_96"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_96"), 180, new List<int>(), new List<int> { 241 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(97, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_97"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_97"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_97"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_97"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_97"), 180, new List<int>(), new List<int> { 242 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(98, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_98"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_98"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_98"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_98"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_98"), 180, new List<int>(), new List<int> { 243 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(99, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_99"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_99"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_99"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_99"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_99"), 180, new List<int>(), new List<int> { 244 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(100, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_100"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_100"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_100"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_100"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_100"), 180, new List<int>(), new List<int> { 245 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(101, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_101"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_101"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_101"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_101"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_101"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(102, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_102"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_102"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_102"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_102"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_102"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(168)
		}, 1));
		_dataArray.Add(new TaskInfoItem(103, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_103"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_103"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_103"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_103"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_103"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short> { 749 }, null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(104, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_104"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_104"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_104"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_104"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_104"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(105, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_105"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_105"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_105"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_105"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_105"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(168)
		}, 1));
		_dataArray.Add(new TaskInfoItem(106, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_106"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_106"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_106"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_106"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_106"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short> { 749 }, null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(107, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_107"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_107"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_107"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_107"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_107"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(108, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_108"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_108"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_108"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_108"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_108"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(168)
		}, 1));
		_dataArray.Add(new TaskInfoItem(109, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_109"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_109"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_109"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_109"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_109"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short> { 749 }, null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(110, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_110"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_110"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_110"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_110"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_110"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(111, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_111"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_111"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_111"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_111"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_111"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(112, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_112"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_112"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_112"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_112"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_112"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(113, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_113"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_113"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_113"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_113"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_113"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(169)
		}, 1));
		_dataArray.Add(new TaskInfoItem(114, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_114"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_114"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_114"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_114"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_114"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(115, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_115"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_115"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_115"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_115"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_115"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(116, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_116"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_116"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_116"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_116"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_116"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(117, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_117"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_117"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_117"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_117"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_117"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(118, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_118"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_118"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_118"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_118"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_118"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(119, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_119"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_119"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_119"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_119"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_119"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new TaskInfoItem(120, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_120"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_120"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_120"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_120"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_120"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(121, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_121"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_121"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_121"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_121"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_121"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(122, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_122"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_122"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_122"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_122"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_122"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(123, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_123"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_123"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_123"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_123"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_123"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(124, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_124"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_124"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_124"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_124"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_124"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(125, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_125"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_125"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_125"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_125"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_125"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(126, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_126"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_126"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_126"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_126"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_126"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(127, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_127"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_127"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_127"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_127"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_127"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(128, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_128"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_128"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_128"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_128"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_128"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(129, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_129"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_129"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_129"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_129"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_129"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(130, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_130"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_130"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_130"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_130"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_130"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(131, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_131"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_131"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_131"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_131"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_131"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short> { 877, 878, 879 }, null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(132, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_132"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_132"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_132"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_132"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_132"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(133, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_133"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_133"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_133"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_133"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_133"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(192)
		}, 1));
		_dataArray.Add(new TaskInfoItem(134, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_134"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_134"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_134"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_134"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_134"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(135, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_135"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_135"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_135"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_135"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_135"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(191)
		}, 1));
		_dataArray.Add(new TaskInfoItem(136, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_136"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_136"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_136"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_136"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_136"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(247),
			new AutoTriggerMonthlyEvent(193)
		}, 1));
		_dataArray.Add(new TaskInfoItem(137, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_137"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_137"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_137"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_137"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_137"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(138, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_138"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_138"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_138"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_138"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_138"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(139, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_139"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_139"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_139"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_139"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_139"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, new string[3] { "ConchShip_PresetKey_Shaolin_LearningSkill0", "ConchShip_PresetKey_Shaolin_LearningSkill1", "ConchShip_PresetKey_Shaolin_LearningSkill2" }, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(247)
		}, 1));
		_dataArray.Add(new TaskInfoItem(140, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_140"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_140"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_140"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_140"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_140"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(247)
		}, 1));
		_dataArray.Add(new TaskInfoItem(141, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_141"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_141"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_141"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_141"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_141"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(142, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_142"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_142"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_142"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_142"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_142"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_StudyForBodhidharmaChallenge", null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(247)
		}, 1));
		_dataArray.Add(new TaskInfoItem(143, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_143"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_143"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_143"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_143"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_143"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(247),
			new AutoTriggerMonthlyEvent(246)
		}, 1));
		_dataArray.Add(new TaskInfoItem(144, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_144"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_144"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_144"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_144"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_144"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, new string[1] { "ConchShip_PresetKey_ShaolinReadingMaxGradeSutra" }, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(247)
		}, 1));
		_dataArray.Add(new TaskInfoItem(145, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_145"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_145"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_145"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_145"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_145"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(146, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_146"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_146"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_146"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_146"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_146"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(147, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_147"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_147"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_147"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_147"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_147"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(268, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(148, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_148"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_148"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_148"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_148"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_148"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[3]
		{
			new AutoTriggerMonthlyEvent(268, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(270, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(269, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(149, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_149"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_149"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_149"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_149"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_149"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(150, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_150"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_150"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_150"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_150"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_150"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(151, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_151"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_151"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_151"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_151"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_151"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(152, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_152"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_152"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_152"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_152"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_152"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(153, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_153"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_153"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_153"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_153"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_153"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, new string[3] { "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_0", "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_1", "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_2" }, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(154, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_154"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_154"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_154"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_154"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_154"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(155, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_155"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_155"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_155"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_155"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_155"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[3]
		{
			new AutoTriggerMonthlyEvent(275, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(272, "RoleTaiwu"),
			new AutoTriggerMonthlyEvent(201)
		}, 1));
		_dataArray.Add(new TaskInfoItem(156, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_156"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_156"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_156"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_156"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_156"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(273)
		}, 1));
		_dataArray.Add(new TaskInfoItem(157, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_157"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_157"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_157"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_157"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_157"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(158, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_158"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_158"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_158"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_158"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_158"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(159, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_159"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_159"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_159"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_159"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_159"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(160, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_160"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_160"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_160"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_160"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_160"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(161, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_161"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_161"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_161"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_161"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_161"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(162, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_162"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_162"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_162"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_162"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_162"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(163, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_163"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_163"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_163"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_163"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_163"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(271)
		}, 1));
		_dataArray.Add(new TaskInfoItem(164, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_164"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_164"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_164"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_164"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_164"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_Xuannv_LoverReincarnateLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(165, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_165"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_165"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_165"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_165"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_165"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, new string[1] { "ConchShip_PresetKey_Xuannv_WaitLoverNameKey" }, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(202, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(166, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_166"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_166"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_166"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_166"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_166"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(167, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_167"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_167"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_167"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_167"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_167"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(168, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_168"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_168"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_168"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_168"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_168"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(206, "RoleTaiwu", "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(169, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_169"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_169"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_169"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_169"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_169"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(170, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_170"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_170"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_170"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_170"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_170"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, "HeavenlyCaveLocations", null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(171, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_171"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_171"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_171"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_171"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_171"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(172, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_172"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_172"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_172"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_172"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_172"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(264, "RoleTaiwu", "TaiwuLocation"),
			new AutoTriggerMonthlyEvent(205)
		}, 1));
		_dataArray.Add(new TaskInfoItem(173, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_173"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_173"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_173"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_173"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_173"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(174, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_174"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_174"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_174"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_174"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_174"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(175, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_175"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_175"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_175"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_175"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_175"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(176, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_176"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_176"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_176"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_176"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_176"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(177, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_177"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_177"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_177"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_177"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_177"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(205)
		}, 1));
		_dataArray.Add(new TaskInfoItem(178, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_178"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_178"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_178"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_178"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_178"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(264, "RoleTaiwu", "TaiwuLocation"),
			new AutoTriggerMonthlyEvent(267, "RoleTaiwu", "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(179, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_179"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_179"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_179"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_179"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_179"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new TaskInfoItem(180, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_180"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_180"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_180"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_180"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_180"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(181, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_181"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_181"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_181"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_181"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_181"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(182, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_182"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_182"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_182"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_182"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_182"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(183, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_183"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_183"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_183"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_183"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_183"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(184, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_184"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_184"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_184"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_184"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_184"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(185, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_185"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_185"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_185"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_185"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_185"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(186, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_186"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_186"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_186"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_186"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_186"), 120, new List<int>(), new List<int>(), new List<int> { 249 }, isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(187, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_187"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_187"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_187"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_187"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_187"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(216, "TaiwuLocation"),
			new AutoTriggerMonthlyEvent(215, "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(188, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_188"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_188"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_188"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_188"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_188"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(189, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_189"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_189"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_189"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_189"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_189"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(190, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_190"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_190"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_190"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_190"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_190"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(261)
		}, 1));
		_dataArray.Add(new TaskInfoItem(191, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_191"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_191"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_191"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_191"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_191"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(214)
		}, 1));
		_dataArray.Add(new TaskInfoItem(192, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_192"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_192"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_192"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_192"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_192"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(193, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_193"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_193"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_193"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_193"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_193"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(194, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_194"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_194"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_194"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_194"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_194"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(195, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_195"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_195"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_195"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_195"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_195"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(196, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_196"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_196"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_196"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_196"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_196"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(197, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_197"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_197"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_197"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_197"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_197"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(198, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_198"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_198"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_198"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_198"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_198"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(199, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_199"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_199"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_199"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_199"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_199"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_JingangAdventureNearestSettlementId", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(200, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_200"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_200"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_200"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_200"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_200"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(201, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_201"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_201"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_201"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_201"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_201"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(202, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_202"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_202"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_202"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_202"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_202"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(203, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_203"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_203"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_203"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_203"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_203"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(204, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_204"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_204"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_204"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_204"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_204"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(205, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_205"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_205"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_205"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_205"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_205"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(206, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_206"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_206"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_206"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_206"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_206"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(303)
		}, 1));
		_dataArray.Add(new TaskInfoItem(207, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_207"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_207"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_207"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_207"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_207"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(208, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_208"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_208"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_208"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_208"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_208"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(302, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(209, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_209"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_209"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_209"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_209"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_209"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(210, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_210"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_210"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_210"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_210"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_210"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(211, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_211"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_211"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_211"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_211"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_211"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(300)
		}, 1));
		_dataArray.Add(new TaskInfoItem(212, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_212"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_212"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_212"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_212"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_212"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(213, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_213"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_213"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_213"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_213"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_213"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(214, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_214"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_214"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_214"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_214"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_214"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(215, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_215"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_215"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_215"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_215"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_215"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(216, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_216"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_216"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_216"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_216"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_216"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(217, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_217"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_217"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_217"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_217"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_217"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(218, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_218"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_218"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_218"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_218"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_218"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(219, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_219"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_219"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_219"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_219"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_219"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(220, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_220"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_220"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_220"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_220"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_220"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(221, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_221"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_221"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_221"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_221"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_221"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(222, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_222"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_222"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_222"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_222"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_222"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(223, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_223"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_223"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_223"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_223"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_223"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(224, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_224"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_224"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_224"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_224"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_224"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(225, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_225"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_225"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_225"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_225"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_225"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(226, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_226"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_226"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_226"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_226"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_226"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(227, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_227"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_227"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_227"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_227"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_227"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(228, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_228"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_228"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_228"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_228"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_228"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(229, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_229"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_229"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_229"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_229"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_229"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(230, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_230"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_230"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_230"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_230"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_230"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(231, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_231"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_231"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_231"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_231"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_231"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(232, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_232"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_232"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_232"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_232"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_232"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(233, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_233"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_233"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_233"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_233"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_233"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(234, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_234"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_234"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_234"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_234"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_234"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(235, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_235"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_235"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_235"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_235"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_235"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(236, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_236"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_236"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_236"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_236"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_236"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(237, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_237"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_237"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_237"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_237"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_237"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(238, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_238"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_238"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_238"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_238"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_238"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(239, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_239"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_239"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_239"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_239"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_239"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new TaskInfoItem(240, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_240"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_240"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_240"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_240"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_240"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(241, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_241"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_241"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_241"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_241"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_241"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(242, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_242"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_242"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_242"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_242"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_242"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(243, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_243"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_243"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_243"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_243"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_243"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(244, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_244"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_244"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_244"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_244"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_244"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(245, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_245"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_245"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_245"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_245"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_245"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(246, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_246"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_246"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_246"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_246"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_246"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(247, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_247"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_247"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_247"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_247"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_247"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(248, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_248"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_248"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_248"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_248"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_248"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(249, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_249"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_249"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_249"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_249"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_249"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(250, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_250"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_250"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_250"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_250"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_250"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(251, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_251"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_251"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_251"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_251"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_251"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(252, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_252"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_252"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_252"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_252"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_252"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(253, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_253"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_253"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_253"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_253"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_253"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(254, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_254"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_254"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_254"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_254"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_254"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(255, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_255"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_255"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_255"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_255"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_255"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(256, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_256"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_256"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_256"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_256"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_256"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(257, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_257"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_257"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_257"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_257"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_257"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(258, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_258"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_258"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_258"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_258"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_258"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(259, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_259"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_259"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_259"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_259"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_259"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(260, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_260"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_260"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_260"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_260"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_260"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(261, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_261"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_261"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_261"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_261"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_261"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_SanZongBiWuCountDown", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(262, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_262"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_262"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_262"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_262"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_262"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(263, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_263"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_263"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_263"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_263"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_263"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(264, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_264"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_264"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_264"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_264"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_264"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(265, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_265"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_265"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_265"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_265"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_265"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(266, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_266"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_266"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_266"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_266"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_266"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(267, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_267"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_267"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_267"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_267"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_267"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(268, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_268"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_268"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_268"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_268"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_268"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(269, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_269"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_269"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_269"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_269"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_269"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(270, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_270"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_270"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_270"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_270"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_270"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(271, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_271"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_271"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_271"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_271"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_271"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(272, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_272"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_272"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_272"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_272"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_272"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(273, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_273"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_273"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_273"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_273"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_273"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(274, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_274"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_274"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_274"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_274"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_274"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(312, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(275, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_275"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_275"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_275"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_275"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_275"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(314, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(276, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_276"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_276"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_276"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_276"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_276"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaVillageSettlementIdSelection", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(277, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_277"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_277"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_277"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_277"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_277"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(278, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_278"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_278"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_278"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_278"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_278"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementId", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(279, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_279"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_279"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_279"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_279"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_279"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementId", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(280, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_280"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_280"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_280"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_280"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_280"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementId", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(281, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_281"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_281"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_281"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_281"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_281"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementId", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(282, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_282"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_282"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_282"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_282"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_282"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(283, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_283"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_283"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_283"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_283"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_283"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(284, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_284"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_284"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_284"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_284"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_284"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(285, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_285"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_285"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_285"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_285"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_285"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(286, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_286"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_286"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_286"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_286"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_286"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(323)
		}, 1));
		_dataArray.Add(new TaskInfoItem(287, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_287"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_287"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_287"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_287"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_287"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(288, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_288"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_288"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_288"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_288"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_288"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(289, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_289"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_289"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_289"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_289"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_289"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(324)
		}, 1));
		_dataArray.Add(new TaskInfoItem(290, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_290"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_290"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_290"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_290"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_290"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(291, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_291"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_291"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_291"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_291"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_291"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(292, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_292"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_292"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_292"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_292"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_292"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(293, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_293"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_293"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_293"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_293"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_293"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(327, "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(294, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_294"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_294"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_294"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_294"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_294"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(295, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_295"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_295"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_295"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_295"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_295"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_FulongAdventureOneCountDown", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(296, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_296"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_296"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_296"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_296"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_296"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(342)
		}, 1));
		_dataArray.Add(new TaskInfoItem(297, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_297"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_297"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_297"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_297"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_297"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(298, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_298"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_298"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_298"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_298"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_298"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(332)
		}, 1));
		_dataArray.Add(new TaskInfoItem(299, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_299"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_299"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_299"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_299"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_299"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new TaskInfoItem(300, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_300"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_300"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_300"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_300"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_300"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(301, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_301"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_301"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_301"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_301"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_301"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(302, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_302"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_302"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_302"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_302"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_302"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(303, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_303"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_303"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_303"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_303"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_303"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, new string[1] { "ConchShip_PresetKey_FulongChickenFeatherLackCount" }, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(304, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_304"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_304"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_304"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_304"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_304"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(305, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_305"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_305"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_305"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_305"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_305"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_FulongAdventureThreeCountDown", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(306, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_306"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_306"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_306"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_306"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_306"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(307, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_307"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_307"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_307"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_307"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_307"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(308, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_308"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_308"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_308"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_308"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_308"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(309, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_309"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_309"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_309"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_309"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_309"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(310, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_310"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_310"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_310"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_310"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_310"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(311, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_311"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_311"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_311"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_311"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_311"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(312, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_312"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_312"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_312"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_312"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_312"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(313, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_313"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_313"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_313"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_313"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_313"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_ZhanluLocationSecond", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(314, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_314"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_314"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_314"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_314"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_314"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(315, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_315"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_315"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_315"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_315"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_315"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(348, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(316, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_316"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_316"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_316"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_316"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_316"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(349, "RoleTaiwu", "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(317, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_317"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_317"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_317"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_317"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_317"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(318, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_318"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_318"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_318"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_318"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_318"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(319, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_319"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_319"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_319"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_319"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_319"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(320, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_320"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_320"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_320"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_320"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_320"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(321, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_321"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_321"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_321"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_321"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_321"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(322, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_322"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_322"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_322"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_322"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_322"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(323, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_323"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_323"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_323"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_323"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_323"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(350, "RoleTaiwu", "TaiwuLocation")
		}, 1));
		_dataArray.Add(new TaskInfoItem(324, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_324"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_324"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_324"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_324"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_324"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(325, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_325"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_325"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_325"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_325"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_325"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(326, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_326"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_326"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_326"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_326"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_326"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(327, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_327"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_327"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_327"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_327"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_327"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(328, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_328"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_328"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_328"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_328"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_328"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(329, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_329"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_329"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_329"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_329"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_329"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(330, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_330"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_330"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_330"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_330"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_330"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(331, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_331"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_331"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_331"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_331"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_331"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(332, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_332"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_332"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_332"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_332"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_332"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(333, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_333"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_333"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_333"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_333"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_333"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(334, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_334"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_334"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_334"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_334"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_334"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(335, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_335"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_335"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_335"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_335"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_335"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(336, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_336"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_336"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_336"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_336"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_336"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(337, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_337"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_337"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_337"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_337"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_337"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(338, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_338"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_338"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_338"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_338"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_338"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(339, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_339"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_339"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_339"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_339"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_339"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(340, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_340"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_340"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_340"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_340"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_340"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(341, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_341"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_341"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_341"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_341"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_341"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(342, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_342"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_342"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_342"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_342"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_342"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "VillageLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(343, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_343"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_343"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_343"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_343"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_343"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "VillageLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(344, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_344"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_344"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_344"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_344"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_344"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "StockadeLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(345, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_345"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_345"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_345"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_345"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_345"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "NianLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(346, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_346"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_346"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_346"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_346"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_346"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "StockadeLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(347, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_347"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_347"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_347"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_347"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_347"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "TownLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(348, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_348"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_348"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_348"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_348"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_348"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "TownLocation", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(349, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_349"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_349"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_349"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_349"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_349"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(350, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_350"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_350"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_350"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_350"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_350"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(361, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(351, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_351"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_351"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_351"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_351"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_351"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(352, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_352"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_352"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_352"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_352"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_352"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(362)
		}, 1));
		_dataArray.Add(new TaskInfoItem(353, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_353"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_353"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_353"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_353"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_353"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(365)
		}, 1));
		_dataArray.Add(new TaskInfoItem(354, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_354"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_354"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_354"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_354"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_354"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(355, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_355"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_355"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_355"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_355"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_355"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(408)
		}, 1));
		_dataArray.Add(new TaskInfoItem(356, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_356"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_356"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_356"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_356"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_356"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(412)
		}, 1));
		_dataArray.Add(new TaskInfoItem(357, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_357"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_357"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_357"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_357"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_357"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(412)
		}, 1));
		_dataArray.Add(new TaskInfoItem(358, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_358"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_358"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_358"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_358"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_358"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(409)
		}, 1));
		_dataArray.Add(new TaskInfoItem(359, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_359"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_359"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_359"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_359"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_359"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(410)
		}, 1));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new TaskInfoItem(360, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_360"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_360"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_360"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_360"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_360"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(361, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_361"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_361"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_361"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_361"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_361"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(411)
		}, 1));
		_dataArray.Add(new TaskInfoItem(362, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_362"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_362"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_362"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_362"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_362"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(363, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_363"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_363"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_363"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_363"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_363"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(364, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_364"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_364"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_364"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_364"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_364"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(365, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_365"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_365"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_365"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_365"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_365"), 120, new List<int> { 324, 257, 259, 303 }, new List<int> { 258 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(366, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_366"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_366"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_366"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_366"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_366"), 120, new List<int> { 324, 257, 259, 304 }, new List<int> { 258 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(369)
		}, 1));
		_dataArray.Add(new TaskInfoItem(367, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_367"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_367"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_367"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_367"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_367"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(368, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_368"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_368"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_368"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_368"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_368"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(369, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_369"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_369"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_369"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_369"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_369"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(370, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_370"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_370"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_370"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_370"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_370"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(370)
		}, 1));
		_dataArray.Add(new TaskInfoItem(371, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_371"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_371"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_371"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_371"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_371"), 120, new List<int> { 319, 260, 262 }, new List<int> { 261 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(366)
		}, 1));
		_dataArray.Add(new TaskInfoItem(372, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_372"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_372"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_372"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_372"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_372"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(373, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_373"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_373"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_373"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_373"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_373"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(367)
		}, 1));
		_dataArray.Add(new TaskInfoItem(374, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_374"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_374"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_374"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_374"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_374"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(375, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_375"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_375"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_375"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_375"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_375"), 120, new List<int> { 323, 254, 255 }, new List<int> { 256 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(368)
		}, 1));
		_dataArray.Add(new TaskInfoItem(376, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_376"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_376"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_376"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_376"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_376"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(377, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_377"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_377"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_377"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_377"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_377"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(378, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_378"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_378"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_378"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_378"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_378"), 120, new List<int> { 327, 263, 265 }, new List<int> { 264 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(371)
		}, 1));
		_dataArray.Add(new TaskInfoItem(379, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_379"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_379"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_379"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_379"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_379"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(380, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_380"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_380"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_380"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_380"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_380"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(372)
		}, 1));
		_dataArray.Add(new TaskInfoItem(381, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_381"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_381"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_381"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_381"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_381"), 120, new List<int> { 330, 266, 268, 288 }, new List<int> { 267 }, new List<int> { 284 }, isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[2]
		{
			new AutoTriggerMonthlyEvent(375),
			new AutoTriggerMonthlyEvent(376)
		}, 1));
		_dataArray.Add(new TaskInfoItem(382, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_382"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_382"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_382"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_382"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_382"), 120, new List<int>(), new List<int>(), new List<int> { 284 }, isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(377)
		}, 1));
		_dataArray.Add(new TaskInfoItem(383, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_383"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_383"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_383"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_383"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_383"), 120, new List<int>(), new List<int>(), new List<int> { 284 }, isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(384, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_384"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_384"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_384"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_384"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_384"), 120, new List<int>(), new List<int>(), new List<int> { 284 }, isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(385, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_385"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_385"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_385"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_385"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_385"), 120, new List<int> { 325, 269, 271, 263 }, new List<int> { 270 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(379)
		}, 1));
		_dataArray.Add(new TaskInfoItem(386, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_386"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_386"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_386"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_386"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_386"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(387, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_387"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_387"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_387"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_387"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_387"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(388, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_388"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_388"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_388"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_388"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_388"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(389, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_389"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_389"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_389"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_389"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_389"), 120, new List<int> { 272, 274 }, new List<int> { 273 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(390, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_390"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_390"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_390"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_390"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_390"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(380)
		}, 1));
		_dataArray.Add(new TaskInfoItem(391, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_391"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_391"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_391"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_391"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_391"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(392, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_392"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_392"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_392"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_392"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_392"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(381)
		}, 1));
		_dataArray.Add(new TaskInfoItem(393, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_393"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_393"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_393"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_393"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_393"), 120, new List<int> { 275, 277 }, new List<int> { 276 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(382)
		}, 1));
		_dataArray.Add(new TaskInfoItem(394, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_394"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_394"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_394"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_394"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_394"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(395, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_395"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_395"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_395"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_395"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_395"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(396, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_396"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_396"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_396"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_396"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_396"), 120, new List<int> { 322, 278, 280 }, new List<int> { 279 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(383)
		}, 1));
		_dataArray.Add(new TaskInfoItem(397, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_397"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_397"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_397"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_397"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_397"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(384)
		}, 1));
		_dataArray.Add(new TaskInfoItem(398, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_398"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_398"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_398"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_398"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_398"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(399, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_399"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_399"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_399"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_399"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_399"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(385)
		}, 1));
		_dataArray.Add(new TaskInfoItem(400, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_400"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_400"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_400"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_400"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_400"), 120, new List<int> { 326, 289, 291 }, new List<int> { 290 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(386)
		}, 1));
		_dataArray.Add(new TaskInfoItem(401, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_401"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_401"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_401"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_401"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_401"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(387)
		}, 1));
		_dataArray.Add(new TaskInfoItem(402, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_402"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_402"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_402"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_402"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_402"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(403, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_403"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_403"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_403"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_403"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_403"), 120, new List<int> { 329, 292, 294 }, new List<int> { 293 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(388)
		}, 1));
		_dataArray.Add(new TaskInfoItem(404, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_404"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_404"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_404"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_404"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_404"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(405, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_405"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_405"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_405"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_405"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_405"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(389)
		}, 1));
		_dataArray.Add(new TaskInfoItem(406, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_406"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_406"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_406"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_406"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_406"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(407, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_407"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_407"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_407"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_407"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_407"), 120, new List<int> { 318, 295, 297 }, new List<int> { 302 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(390)
		}, 1));
		_dataArray.Add(new TaskInfoItem(408, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_408"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_408"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_408"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_408"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_408"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "BaiSettlement", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(409, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_409"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_409"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_409"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_409"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_409"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "ConchShip_PresetKey_BaihuaVillageSettlementIdSelection", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(410, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_410"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_410"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_410"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_410"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_410"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(411, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_411"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_411"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_411"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_411"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_411"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), "XingshiSettlement", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(412, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_412"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_412"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_412"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_412"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_412"), 120, new List<int> { 316, 298, 300 }, new List<int> { 299 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(391)
		}, 1));
		_dataArray.Add(new TaskInfoItem(413, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_413"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_413"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_413"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_413"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_413"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(414, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_414"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_414"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_414"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_414"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_414"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(415, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_415"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_415"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_415"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_415"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_415"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(392)
		}, 1));
		_dataArray.Add(new TaskInfoItem(416, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_416"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_416"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_416"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_416"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_416"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(417, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_417"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_417"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_417"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_417"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_417"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(418, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_418"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_418"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_418"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_418"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_418"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(419, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_419"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_419"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_419"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_419"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_419"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new TaskInfoItem(420, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_420"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_420"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_420"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_420"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_420"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(421, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_421"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_421"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_421"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_421"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_421"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(422, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_422"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_422"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_422"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_422"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_422"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(423, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_423"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_423"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_423"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_423"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_423"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(424, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_424"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_424"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_424"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_424"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_424"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(425, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_425"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_425"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_425"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_425"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_425"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(426, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_426"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_426"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_426"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_426"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_426"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(427, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_427"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_427"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_427"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_427"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_427"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(428, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_428"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_428"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_428"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_428"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_428"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(429, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_429"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_429"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_429"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_429"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_429"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(430, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_430"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_430"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_430"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_430"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_430"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(431, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_431"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_431"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_431"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_431"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_431"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(432, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_432"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_432"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_432"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_432"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_432"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(433, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_433"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_433"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_433"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_433"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_433"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(434, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_434"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_434"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_434"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_434"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_434"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(435, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_435"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_435"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_435"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_435"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_435"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(436, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_436"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_436"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_436"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_436"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_436"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(437, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_437"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_437"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_437"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_437"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_437"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(438, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_438"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_438"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_438"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_438"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_438"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(439, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_439"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_439"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_439"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_439"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_439"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(440, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_440"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_440"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_440"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_440"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_440"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(441, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_441"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_441"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_441"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_441"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_441"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(442, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_442"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_442"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_442"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_442"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_442"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(443, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_443"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_443"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_443"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_443"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_443"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(444, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_444"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_444"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_444"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_444"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_444"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(445, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_445"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_445"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_445"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_445"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_445"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(446, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_446"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_446"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_446"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_446"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_446"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(447, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_447"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_447"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_447"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_447"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_447"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(448, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_448"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_448"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_448"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_448"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_448"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(449, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_449"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_449"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_449"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_449"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_449"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(450, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_450"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_450"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_450"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_450"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_450"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(451, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_451"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_451"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_451"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_451"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_451"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(452, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_452"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_452"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_452"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_452"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_452"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(453, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_453"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_453"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_453"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_453"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_453"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(454, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_454"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_454"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_454"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_454"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_454"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(455, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_455"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_455"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_455"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_455"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_455"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(456, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_456"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_456"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_456"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_456"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_456"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(457, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_457"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_457"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_457"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_457"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_457"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(458, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_458"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_458"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_458"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_458"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_458"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(459, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_459"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_459"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_459"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_459"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_459"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(460, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_460"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_460"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_460"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_460"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_460"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(461, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_461"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_461"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_461"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_461"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_461"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(462, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_462"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_462"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_462"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_462"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_462"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(463, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_463"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_463"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_463"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_463"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_463"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(464, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_464"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_464"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_464"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_464"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_464"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(465, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_465"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_465"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_465"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_465"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_465"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(466, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_466"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_466"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_466"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_466"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_466"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(467, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_467"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_467"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_467"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_467"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_467"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(468, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_468"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_468"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_468"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_468"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_468"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(469, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_469"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_469"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_469"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_469"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_469"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(470, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_470"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_470"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_470"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_470"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_470"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(471, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_471"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_471"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_471"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_471"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_471"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(472, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_472"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_472"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_472"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_472"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_472"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(473, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_473"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_473"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_473"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_473"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_473"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(474, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_474"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_474"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_474"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_474"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_474"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(475, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_475"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_475"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_475"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_475"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_475"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(476, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_476"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_476"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_476"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_476"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_476"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(477, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_477"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_477"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_477"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_477"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_477"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(478, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_478"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_478"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_478"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_478"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_478"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(479, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_479"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_479"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_479"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_479"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_479"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new TaskInfoItem(480, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_480"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_480"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_480"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_480"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_480"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(481, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_481"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_481"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_481"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_481"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_481"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(482, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_482"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_482"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_482"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_482"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_482"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(483, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_483"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_483"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_483"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_483"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_483"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(484, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_484"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_484"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_484"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_484"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_484"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(485, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_485"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_485"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_485"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_485"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_485"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(486, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_486"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_486"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_486"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_486"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_486"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(487, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_487"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_487"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_487"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_487"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_487"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(488, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_488"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_488"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_488"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_488"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_488"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(489, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_489"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_489"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_489"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_489"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_489"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(490, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_490"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_490"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_490"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_490"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_490"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(491, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_491"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_491"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_491"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_491"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_491"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(492, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_492"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_492"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_492"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_492"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_492"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(493, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_493"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_493"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_493"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_493"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_493"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(494, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_494"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_494"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_494"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_494"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_494"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(495, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_495"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_495"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_495"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_495"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_495"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(496, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_496"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_496"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_496"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_496"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_496"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(497, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_497"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_497"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_497"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_497"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_497"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(498, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_498"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_498"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_498"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_498"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_498"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(499, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_499"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_499"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_499"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_499"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_499"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(500, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_500"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_500"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_500"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_500"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_500"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(501, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_501"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_501"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_501"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_501"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_501"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(502, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_502"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_502"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_502"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_502"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_502"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(503, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_503"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_503"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_503"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_503"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_503"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(504, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_504"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_504"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_504"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_504"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_504"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(505, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_505"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_505"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_505"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_505"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_505"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(506, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_506"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_506"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_506"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_506"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_506"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(507, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_507"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_507"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_507"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_507"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_507"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(508, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_508"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_508"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_508"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_508"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_508"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(509, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_509"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_509"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_509"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_509"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_509"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(510, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_510"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_510"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_510"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_510"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_510"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(511, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_511"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_511"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_511"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_511"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_511"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(512, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_512"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_512"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_512"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_512"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_512"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(513, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_513"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_513"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_513"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_513"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_513"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(514, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_514"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_514"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_514"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_514"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_514"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(515, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_515"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_515"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_515"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_515"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_515"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(516, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_516"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_516"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_516"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_516"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_516"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(517, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_517"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_517"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_517"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_517"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_517"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(518, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_518"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_518"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_518"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_518"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_518"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(519, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_519"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_519"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_519"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_519"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_519"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(520, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_520"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_520"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_520"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_520"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_520"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(521, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_521"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_521"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_521"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_521"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_521"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(522, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_522"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_522"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_522"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_522"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_522"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(523, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_523"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_523"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_523"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_523"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_523"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(524, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_524"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_524"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_524"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_524"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_524"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(525, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_525"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_525"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_525"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_525"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_525"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(526, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_526"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_526"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_526"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_526"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_526"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(527, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_527"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_527"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_527"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_527"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_527"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(528, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_528"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_528"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_528"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_528"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_528"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(529, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_529"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_529"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_529"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_529"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_529"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(530, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_530"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_530"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_530"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_530"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_530"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(531, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_531"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_531"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_531"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_531"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_531"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(532, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_532"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_532"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_532"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_532"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_532"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(533, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_533"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_533"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_533"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_533"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_533"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(534, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_534"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_534"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_534"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_534"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_534"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(535, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_535"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_535"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_535"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_535"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_535"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(536, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_536"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_536"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_536"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_536"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_536"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(537, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_537"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_537"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_537"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_537"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_537"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(538, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_538"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_538"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_538"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_538"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_538"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(539, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_539"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_539"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_539"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_539"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_539"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new TaskInfoItem(540, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_540"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_540"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_540"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_540"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_540"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(541, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_541"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_541"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_541"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_541"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_541"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(542, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_542"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_542"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_542"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_542"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_542"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(543, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_543"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_543"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_543"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_543"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_543"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(544, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_544"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_544"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_544"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_544"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_544"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(545, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_545"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_545"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_545"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_545"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_545"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(546, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_546"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_546"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_546"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_546"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_546"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(547, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_547"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_547"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_547"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_547"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_547"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(548, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_548"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_548"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_548"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_548"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_548"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(549, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_549"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_549"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_549"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_549"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_549"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(550, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_550"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_550"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_550"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_550"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_550"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(551, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_551"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_551"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_551"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_551"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_551"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(552, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_552"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_552"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_552"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_552"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_552"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(553, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_553"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_553"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_553"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_553"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_553"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(554, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_554"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_554"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_554"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_554"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_554"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(555, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_555"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_555"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_555"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_555"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_555"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(556, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_556"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_556"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_556"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_556"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_556"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(557, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_557"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_557"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_557"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_557"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_557"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(558, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_558"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_558"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_558"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_558"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_558"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(559, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_559"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_559"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_559"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_559"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_559"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(560, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_560"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_560"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_560"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_560"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_560"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(561, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_561"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_561"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_561"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_561"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_561"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(562, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_562"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_562"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_562"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_562"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_562"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(563, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_563"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_563"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_563"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_563"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_563"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(564, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_564"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_564"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_564"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_564"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_564"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(565, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_565"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_565"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_565"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_565"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_565"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(566, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_566"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_566"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_566"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_566"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_566"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(567, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_567"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_567"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_567"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_567"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_567"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(568, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_568"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_568"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_568"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_568"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_568"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(569, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_569"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_569"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_569"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_569"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_569"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(570, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_570"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_570"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_570"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_570"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_570"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(571, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_571"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_571"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_571"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_571"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_571"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(572, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_572"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_572"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_572"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_572"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_572"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(573, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_573"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_573"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_573"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_573"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_573"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(574, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_574"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_574"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_574"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_574"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_574"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(575, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_575"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_575"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_575"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_575"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_575"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(576, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_576"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_576"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_576"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_576"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_576"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(577, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_577"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_577"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_577"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_577"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_577"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(578, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_578"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_578"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_578"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_578"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_578"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(579, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_579"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_579"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_579"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_579"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_579"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(580, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_580"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_580"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_580"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_580"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_580"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(581, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_581"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_581"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_581"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_581"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_581"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(582, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_582"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_582"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_582"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_582"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_582"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(583, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_583"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_583"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_583"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_583"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_583"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(584, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_584"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_584"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_584"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_584"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_584"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(585, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_585"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_585"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_585"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_585"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_585"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(586, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_586"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_586"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_586"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_586"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_586"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(587, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_587"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_587"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_587"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_587"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_587"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(588, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_588"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_588"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_588"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_588"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_588"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(589, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_589"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_589"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_589"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_589"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_589"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(590, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_590"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_590"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_590"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_590"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_590"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(591, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_591"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_591"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_591"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_591"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_591"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(592, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_592"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_592"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_592"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_592"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_592"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(593, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_593"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_593"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_593"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_593"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_593"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(594, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_594"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_594"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_594"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_594"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_594"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(595, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_595"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_595"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_595"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_595"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_595"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(596, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_596"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_596"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_596"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_596"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_596"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(597, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_597"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_597"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_597"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_597"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_597"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(598, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_598"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_598"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_598"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_598"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_598"), 120, new List<int> { 163 }, new List<int> { 172 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(599, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_599"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_599"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_599"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_599"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_599"), 120, new List<int> { 163 }, new List<int> { 172 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new TaskInfoItem(600, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_600"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_600"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_600"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_600"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_600"), 120, new List<int> { 163 }, new List<int> { 172 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(601, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_601"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_601"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_601"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_601"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_601"), 120, new List<int> { 164 }, new List<int> { 173 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(602, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_602"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_602"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_602"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_602"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_602"), 120, new List<int> { 164 }, new List<int> { 173 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(603, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_603"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_603"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_603"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_603"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_603"), 120, new List<int> { 164 }, new List<int> { 173 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(604, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_604"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_604"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_604"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_604"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_604"), 120, new List<int> { 165 }, new List<int> { 174 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(605, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_605"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_605"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_605"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_605"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_605"), 120, new List<int> { 165 }, new List<int> { 174 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(606, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_606"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_606"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_606"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_606"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_606"), 120, new List<int> { 165 }, new List<int> { 174 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(607, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_607"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_607"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_607"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_607"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_607"), 120, new List<int> { 166 }, new List<int> { 175 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(608, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_608"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_608"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_608"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_608"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_608"), 120, new List<int> { 166 }, new List<int> { 175 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(609, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_609"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_609"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_609"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_609"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_609"), 120, new List<int> { 166 }, new List<int> { 175 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(610, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_610"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_610"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_610"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_610"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_610"), 120, new List<int> { 167 }, new List<int> { 176 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(611, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_611"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_611"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_611"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_611"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_611"), 120, new List<int> { 167 }, new List<int> { 176 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(612, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_612"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_612"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_612"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_612"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_612"), 120, new List<int> { 167 }, new List<int> { 176 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(613, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_613"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_613"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_613"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_613"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_613"), 120, new List<int> { 168 }, new List<int> { 177 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(614, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_614"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_614"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_614"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_614"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_614"), 120, new List<int> { 168 }, new List<int> { 177 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(615, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_615"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_615"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_615"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_615"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_615"), 120, new List<int> { 168 }, new List<int> { 177 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(616, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_616"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_616"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_616"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_616"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_616"), 120, new List<int> { 169 }, new List<int> { 178 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(617, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_617"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_617"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_617"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_617"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_617"), 120, new List<int> { 169 }, new List<int> { 178 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(618, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_618"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_618"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_618"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_618"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_618"), 120, new List<int> { 169 }, new List<int> { 178 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(619, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_619"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_619"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_619"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_619"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_619"), 120, new List<int> { 170 }, new List<int> { 179 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(620, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_620"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_620"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_620"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_620"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_620"), 120, new List<int> { 170 }, new List<int> { 179 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(621, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_621"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_621"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_621"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_621"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_621"), 120, new List<int> { 170 }, new List<int> { 179 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(622, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_622"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_622"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_622"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_622"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_622"), 120, new List<int> { 171 }, new List<int> { 180 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(623, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_623"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_623"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_623"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_623"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_623"), 120, new List<int> { 171 }, new List<int> { 180 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(624, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_624"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_624"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_624"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_624"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_624"), 120, new List<int> { 171 }, new List<int> { 180 }, new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(625, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_625"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_625"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_625"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_625"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_625"), 120, new List<int> { 305, 309 }, new List<int> { 349 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(417)
		}, 0));
		_dataArray.Add(new TaskInfoItem(626, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_626"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_626"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_626"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_626"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_626"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(627, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_627"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_627"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_627"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_627"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_627"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(628, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_628"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_628"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_628"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_628"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_628"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(629, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_629"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_629"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_629"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_629"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_629"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(630, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_630"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_630"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_630"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_630"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_630"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(631, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_631"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_631"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_631"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_631"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_631"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(632, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_632"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_632"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_632"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_632"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_632"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(633, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_633"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_633"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_633"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_633"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_633"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(634, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_634"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_634"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_634"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_634"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_634"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(635, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_635"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_635"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_635"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_635"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_635"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(636, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_636"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_636"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_636"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_636"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_636"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(637, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_637"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_637"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_637"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_637"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_637"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(638, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_638"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_638"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_638"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_638"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_638"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(639, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_639"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_639"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_639"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_639"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_639"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(640, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_640"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_640"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_640"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_640"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_640"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(641, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_641"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_641"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_641"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_641"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_641"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(418)
		}, 1));
		_dataArray.Add(new TaskInfoItem(642, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_642"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_642"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_642"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_642"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_642"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(643, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_643"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_643"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_643"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_643"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_643"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(644, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_644"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_644"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_644"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_644"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_644"), 120, new List<int> { 314, 346, 350 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: false, new List<int>(), -1, 645, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(419, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(645, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_645"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_645"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_645"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_645"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_645"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(646, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_646"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_646"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_646"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_646"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_646"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(647, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_647"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_647"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_647"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_647"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_647"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(648, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_648"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_648"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_648"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_648"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_648"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(420, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(649, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_649"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_649"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_649"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_649"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_649"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "PreEvilDesireAdvBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(650, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_650"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_650"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_650"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_650"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_650"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(651, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_651"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_651"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_651"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_651"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_651"), 120, new List<int> { 315 }, new List<int> { 310 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 0));
		_dataArray.Add(new TaskInfoItem(652, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_652"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_652"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_652"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_652"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_652"), 120, new List<int> { 173 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 653, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(422)
		}, 1));
		_dataArray.Add(new TaskInfoItem(653, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_653"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_653"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_653"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_653"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_653"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, 654, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(654, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_654"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_654"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_654"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_654"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_654"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(655, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_655"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_655"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_655"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_655"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_655"), 120, new List<int> { 177 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 656, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(423)
		}, 1));
		_dataArray.Add(new TaskInfoItem(656, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_656"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_656"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_656"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_656"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_656"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(657, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_657"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_657"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_657"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_657"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_657"), 120, new List<int> { 174 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 658, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(424)
		}, 1));
		_dataArray.Add(new TaskInfoItem(658, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_658"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_658"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_658"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_658"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_658"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(659, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_659"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_659"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_659"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_659"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_659"), 120, new List<int> { 179 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 660, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(425)
		}, 1));
	}

	private void CreateItems11()
	{
		_dataArray.Add(new TaskInfoItem(660, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_660"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_660"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_660"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_660"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_660"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(661, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_661"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_661"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_661"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_661"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_661"), 120, new List<int> { 176 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 662, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(426)
		}, 1));
		_dataArray.Add(new TaskInfoItem(662, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_662"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_662"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_662"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_662"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_662"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(663, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_663"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_663"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_663"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_663"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_663"), 120, new List<int> { 178 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 664, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(427)
		}, 1));
		_dataArray.Add(new TaskInfoItem(664, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_664"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_664"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_664"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_664"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_664"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(665, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_665"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_665"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_665"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_665"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_665"), 120, new List<int> { 175 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 666, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(428)
		}, 1));
		_dataArray.Add(new TaskInfoItem(666, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_666"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_666"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_666"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_666"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_666"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(667, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_667"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_667"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_667"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_667"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_667"), 120, new List<int> { 180 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 668, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(429)
		}, 1));
		_dataArray.Add(new TaskInfoItem(668, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_668"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_668"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_668"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_668"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_668"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(669, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_669"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_669"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_669"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_669"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_669"), 120, new List<int> { 172 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, 670, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(430)
		}, 1));
		_dataArray.Add(new TaskInfoItem(670, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_670"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_670"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_670"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_670"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_670"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(671, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_671"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_671"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_671"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_671"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_671"), 120, new List<int> { 317, 311, 313 }, new List<int> { 312 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(431)
		}, 1));
		_dataArray.Add(new TaskInfoItem(672, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_672"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_672"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_672"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_672"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_672"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(673, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_673"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_673"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_673"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_673"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_673"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(674, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_674"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_674"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_674"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_674"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_674"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(432)
		}, 1));
		_dataArray.Add(new TaskInfoItem(675, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_675"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_675"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_675"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_675"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_675"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(676, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_676"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_676"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_676"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_676"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_676"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(433, "RoleTaiwu")
		}, 1));
		_dataArray.Add(new TaskInfoItem(677, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_677"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_677"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_677"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_677"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_677"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(678, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_678"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_678"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_678"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_678"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_678"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(679, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_679"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_679"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_679"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_679"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_679"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(680, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_680"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_680"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_680"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_680"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_680"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(681, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_681"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_681"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_681"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_681"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_681"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(682, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_682"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_682"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_682"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_682"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_682"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(683, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_683"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_683"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_683"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_683"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_683"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(684, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_684"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_684"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_684"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_684"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_684"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(685, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_685"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_685"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_685"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_685"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_685"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(686, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_686"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_686"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_686"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_686"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_686"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(687, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_687"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_687"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_687"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_687"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_687"), 120, new List<int> { 331 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(688, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_688"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_688"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_688"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_688"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_688"), 120, new List<int> { 332 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(689, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_689"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_689"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_689"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_689"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_689"), 120, new List<int> { 333 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(690, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_690"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_690"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_690"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_690"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_690"), 120, new List<int> { 334 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(691, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_691"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_691"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_691"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_691"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_691"), 120, new List<int> { 335 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(692, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_692"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_692"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_692"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_692"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_692"), 120, new List<int> { 336 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(693, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_693"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_693"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_693"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_693"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_693"), 120, new List<int> { 337 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(694, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_694"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_694"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_694"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_694"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_694"), 120, new List<int> { 338 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(695, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_695"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_695"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_695"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_695"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_695"), 120, new List<int> { 339 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(696, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_696"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_696"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_696"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_696"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_696"), 120, new List<int> { 340 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(697, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_697"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_697"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_697"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_697"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_697"), 120, new List<int> { 341 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(698, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_698"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_698"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_698"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_698"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_698"), 120, new List<int> { 342 }, new List<int>(), new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(699, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_699"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_699"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_699"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_699"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_699"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 2, new List<short>(), "MainStoryGoldenLineLoc", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(700, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_700"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_700"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_700"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_700"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_700"), 120, new List<int> { 347 }, new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 0));
		_dataArray.Add(new TaskInfoItem(701, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_701"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_701"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_701"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_701"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_701"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "WushaoAdvBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(702, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_702"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_702"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_702"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_702"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_702"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "LetterAdvBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(703, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_703"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_703"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_703"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_703"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_703"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), "TrailAdvBlock", null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(704, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_704"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_704"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_704"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_704"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_704"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(705, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_705"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_705"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_705"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_705"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_705"), 120, new List<int> { 328, 343, 345 }, new List<int> { 344 }, new List<int>(), isTriggeredTask: false, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(463)
		}, 1));
		_dataArray.Add(new TaskInfoItem(706, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_706"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_706"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_706"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_706"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_706"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(707, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_707"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_707"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_707"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_707"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_707"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(708, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_708"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_708"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_708"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_708"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_708"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(464)
		}, 1));
		_dataArray.Add(new TaskInfoItem(709, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_709"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_709"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_709"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_709"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_709"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(466)
		}, 1));
		_dataArray.Add(new TaskInfoItem(710, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_710"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_710"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_710"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_710"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_710"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 452 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(711, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_711"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_711"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_711"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_711"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_711"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 452 }, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(467)
		}, 1));
		_dataArray.Add(new TaskInfoItem(712, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_712"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_712"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_712"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_712"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_712"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 452 }, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(468)
		}, 1));
		_dataArray.Add(new TaskInfoItem(713, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_713"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_713"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_713"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_713"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_713"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 452 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(714, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_714"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_714"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_714"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_714"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_714"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(715, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_715"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_715"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_715"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_715"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_715"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(716, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_716"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_716"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_716"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_716"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_716"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(717, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_717"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_717"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_717"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_717"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_717"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(718, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_718"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_718"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_718"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_718"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_718"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(719, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_719"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_719"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_719"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_719"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_719"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	private void CreateItems12()
	{
		_dataArray.Add(new TaskInfoItem(720, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_720"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_720"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_720"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_720"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_720"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(469)
		}, 1));
		_dataArray.Add(new TaskInfoItem(721, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_721"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_721"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_721"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_721"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_721"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 453 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(722, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_722"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_722"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_722"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_722"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_722"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 453 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(723, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_723"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_723"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_723"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_723"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_723"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 453 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(724, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_724"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_724"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_724"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_724"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_724"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[3] { 453, 455, 454 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(725, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_725"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_725"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_725"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_725"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_725"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[3] { 453, 455, 454 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(726, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_726"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_726"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_726"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_726"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_726"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 454 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(727, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_727"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_727"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_727"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_727"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_727"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 454 }, new AutoTriggerMonthlyEvent[1]
		{
			new AutoTriggerMonthlyEvent(472)
		}, 1));
		_dataArray.Add(new TaskInfoItem(728, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_728"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_728"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_728"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_728"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_728"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(729, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_729"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_729"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_729"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_729"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_729"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(730, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_730"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_730"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_730"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_730"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_730"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[3]
		{
			new AutoTriggerMonthlyEvent(460),
			new AutoTriggerMonthlyEvent(461),
			new AutoTriggerMonthlyEvent(462)
		}, 1));
		_dataArray.Add(new TaskInfoItem(731, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_731"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_731"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_731"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_731"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_731"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 1, new List<short>(), null, null, null, null, null, new short[1] { 453 }, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(732, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_732"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_732"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_732"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_732"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_732"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(733, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_733"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_733"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_733"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_733"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_733"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(734, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_734"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_734"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_734"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_734"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_734"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(735, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_735"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_735"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_735"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_735"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_735"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(736, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_736"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_736"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_736"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_736"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_736"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(737, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_737"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_737"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_737"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_737"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_737"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(738, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_738"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_738"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_738"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_738"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_738"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(739, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_739"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_739"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_739"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_739"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_739"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(740, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_740"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_740"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_740"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_740"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_740"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(741, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_741"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_741"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_741"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_741"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_741"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(742, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_742"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_742"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_742"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_742"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_742"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
		_dataArray.Add(new TaskInfoItem(743, LocalStringManager.GetConfig("TaskInfo_language", "TaskTitle_743"), LocalStringManager.GetConfig("TaskInfo_language", "TaskOverview_743"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescription_743"), LocalStringManager.GetConfig("TaskInfo_language", "TaskBubblesContent_743"), LocalStringManager.GetConfig("TaskInfo_language", "TaskDescriptionMeet_743"), 120, new List<int>(), new List<int>(), new List<int>(), isTriggeredTask: true, unableRepeat: true, new List<int>(), -1, -1, 0, new List<short>(), null, null, null, null, null, null, new AutoTriggerMonthlyEvent[0], 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaskInfoItem>(744);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
		CreateItems10();
		CreateItems11();
		CreateItems12();
	}
}
