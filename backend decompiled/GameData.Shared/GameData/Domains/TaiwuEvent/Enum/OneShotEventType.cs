using System;

namespace GameData.Domains.TaiwuEvent.Enum;

public static class OneShotEventType
{
	[Obsolete]
	public const int AristocratSkill1IsHinted = 1;

	[Obsolete]
	public const int AristocratSkill2IsHinted = 2;

	[Obsolete]
	public const int SavageSkill1IsHinted = 3;

	[Obsolete]
	public const int SavageSkill2IsHinted = 4;

	[Obsolete]
	public const int LiteratiSkill1IsHinted = 5;

	[Obsolete]
	public const int LiteratiSkill2IsHinted = 6;

	[Obsolete]
	public const int MartialArtistSkill2IsHinted = 7;

	[Obsolete]
	public const int CraftSkill1IsHinted = 8;

	[Obsolete]
	public const int CraftSkill2IsHinted = 9;

	[Obsolete]
	public const int CivilianSkill1IsHinted = 10;

	[Obsolete]
	public const int CivilianSkill2IsHinted = 11;

	[Obsolete]
	public const int TravelerSkill1IsHinted = 12;

	[Obsolete]
	public const int TravelerSkill2IsHinted = 13;

	[Obsolete]
	public const int WineTasterSkill1IsHinted = 14;

	[Obsolete]
	public const int WineTasterSkill2IsHinted = 15;

	[Obsolete]
	public const int TeaTasterSkill1IsHinted = 16;

	[Obsolete]
	public const int TeaTasterSkill3IsHinted = 17;

	[Obsolete]
	public const int TravelingBuddhistMonkSkill1IsHinted = 18;

	[Obsolete]
	public const int TravelingBuddhistMonkSkill2IsHinted = 19;

	[Obsolete]
	public const int TravelingTaoistMonkSkill1IsHinted = 20;

	[Obsolete]
	public const int TravelingTaoistMonkSkill2IsHinted = 21;

	[Obsolete]
	public const int TravelingTaoistMonkSkill3IsHinted = 22;

	[Obsolete]
	public const int HunterSkill1IsHinted = 23;

	[Obsolete]
	public const int HunterSkill2IsHinted = 24;

	[Obsolete]
	public const int TaoistMonkSkill1IsHinted = 25;

	[Obsolete]
	public const int TaoistMonkSkill2IsHinted = 26;

	[Obsolete]
	public const int BuddhistMonkSkill1IsHinted = 27;

	[Obsolete]
	public const int BuddhistMonkSkill2IsHinted = 28;

	[Obsolete]
	public const int BeggarSkill1IsHinted = 29;

	[Obsolete]
	public const int BeggarSkill2IsHinted = 30;

	[Obsolete]
	public const int DoctorSkill1IsHinted = 31;

	[Obsolete]
	public const int DoctorSkill2IsHinted = 32;

	[Obsolete]
	public const int CapitalistSkill1IsHinted = 33;

	[Obsolete]
	public const int CapitalistSkill2IsHinted = 34;

	[Obsolete]
	public const int DukeSkill1IsHinted = 35;

	[Obsolete]
	public const int DukeSkill2IsHinted = 36;

	public const int TaoistMonkGetTianJieFuLu1 = 37;

	public const int TaoistMonkGetTianJieFuLu2 = 38;

	[Obsolete]
	public const int TaoistMonkGetTianJieFuLu3 = 39;

	[Obsolete]
	public const int SavedCountReachHundred = 40;

	[Obsolete]
	public const int MartialArtistSkill1IsHinted = 41;

	[Obsolete]
	public const int TravelingBuddhistMonkSkill3IsHinted = 42;

	private const int ProfessionRelatedOneShotEventBegin = 1;

	private const int ProfessionRelatedOneShotEventEnd = 42;

	public const int MirrorCreatedImpostureXiangshuInfected = 43;

	public const int MainStoryExorcism = 44;

	public static bool IsProfessionRelatedOneShotEvent(int oneShotEventType)
	{
		if (oneShotEventType >= 1)
		{
			return oneShotEventType <= 42;
		}
		return false;
	}
}
