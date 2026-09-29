using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class HotKeyDisplay : ConfigData<HotKeyDisplayItem, short>
{
	public static HotKeyDisplay Instance = new HotKeyDisplay();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayText", "TemplateId", "Type" };

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
		_dataArray.Add(new HotKeyDisplayItem(0, EHotKeyDisplayType.GetItem, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_0"), new List<HotkeyIndex>()));
		_dataArray.Add(new HotKeyDisplayItem(1, EHotKeyDisplayType.CGAnimation, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_1"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(2, EHotKeyDisplayType.DigAnimations, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_2"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(3, EHotKeyDisplayType.CBReadiness, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_3"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(4, EHotKeyDisplayType.CBMoveAutomaticallyTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_4"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(5, EHotKeyDisplayType.CBAttackTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_5"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(4, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(6, EHotKeyDisplayType.CBEquipmentTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_6"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 8)
		}));
		_dataArray.Add(new HotKeyDisplayItem(7, EHotKeyDisplayType.CBCombatSkillTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_7"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 8)
		}));
		_dataArray.Add(new HotKeyDisplayItem(8, EHotKeyDisplayType.AttentivelyTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_8"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(11, 18)
		}));
		_dataArray.Add(new HotKeyDisplayItem(9, EHotKeyDisplayType.DedicatedTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_9"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(11, 19)
		}));
		_dataArray.Add(new HotKeyDisplayItem(10, EHotKeyDisplayType.CompareEquipment, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_10"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 10)
		}));
		_dataArray.Add(new HotKeyDisplayItem(11, EHotKeyDisplayType.DetailAndCompareEquipment, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_11"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 9),
			new HotkeyIndex(1, 10)
		}));
		_dataArray.Add(new HotKeyDisplayItem(12, EHotKeyDisplayType.AllTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_12"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 4)
		}));
		_dataArray.Add(new HotKeyDisplayItem(13, EHotKeyDisplayType.Detail, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_13"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 9)
		}));
		_dataArray.Add(new HotKeyDisplayItem(14, EHotKeyDisplayType.PracticeCombatSkillTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_14"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(15, EHotKeyDisplayType.CancelDetail, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_15"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 9)
		}));
		_dataArray.Add(new HotKeyDisplayItem(16, EHotKeyDisplayType.CancelCompareEquipment, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_16"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 10)
		}));
		_dataArray.Add(new HotKeyDisplayItem(17, EHotKeyDisplayType.Interaction, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_17"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 8)
		}));
		_dataArray.Add(new HotKeyDisplayItem(18, EHotKeyDisplayType.CancelInteraction, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_18"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 8)
		}));
		_dataArray.Add(new HotKeyDisplayItem(19, EHotKeyDisplayType.CombatResult, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_19"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(20, EHotKeyDisplayType.ExtraordinaryCricket, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_20"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(21, EHotKeyDisplayType.TasterUltimateResult, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_21"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 2),
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(22, EHotKeyDisplayType.ProfessionSkillUnlockedSkip, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_22"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(23, EHotKeyDisplayType.ProfessionSkillUnlockedClose, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_23"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(24, EHotKeyDisplayType.InteractCheckUnlockedSkip, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_24"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(25, EHotKeyDisplayType.InteractCheckUnlockedClose, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_25"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(26, EHotKeyDisplayType.SectMainStoryUnlock, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_26"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 1),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(27, EHotKeyDisplayType.AnywhereContinue, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_27"), new List<HotkeyIndex>()));
		_dataArray.Add(new HotKeyDisplayItem(28, EHotKeyDisplayType.LoadingNext, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_28"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 1)
		}));
		_dataArray.Add(new HotKeyDisplayItem(29, EHotKeyDisplayType.LoadingLast, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_29"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(30, EHotKeyDisplayType.DigSkipAnimations, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_30"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(31, EHotKeyDisplayType.AnyKeyContinue, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_31"), new List<HotkeyIndex>()));
		_dataArray.Add(new HotKeyDisplayItem(32, EHotKeyDisplayType.LockItem, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_32"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 12)
		}));
		_dataArray.Add(new HotKeyDisplayItem(33, EHotKeyDisplayType.CombatSwapSkill, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_33"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 1)
		}));
		_dataArray.Add(new HotKeyDisplayItem(34, EHotKeyDisplayType.UnlockLegacyContinue, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_34"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(35, EHotKeyDisplayType.ViewEncyclopedia, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_35"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 11)
		}));
		_dataArray.Add(new HotKeyDisplayItem(36, EHotKeyDisplayType.CricketCatchClose, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_36"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(37, EHotKeyDisplayType.UnlockItem, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_37"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 12)
		}));
		_dataArray.Add(new HotKeyDisplayItem(38, EHotKeyDisplayType.CancelBattleCirclePanel, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_38"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 1)
		}));
		_dataArray.Add(new HotKeyDisplayItem(39, EHotKeyDisplayType.CancleByRightMouse, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_39"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(40, EHotKeyDisplayType.SystemOptionGlobalTipsHide, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_40"), new List<HotkeyIndex>
		{
			new HotkeyIndex(9, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(41, EHotKeyDisplayType.SystemOptionGlobalTipsShow, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_41"), new List<HotkeyIndex>
		{
			new HotkeyIndex(9, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(42, EHotKeyDisplayType.MainOperationTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_42"), new List<HotkeyIndex>
		{
			new HotkeyIndex(11, 1),
			new HotkeyIndex(1, 1),
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(43, EHotKeyDisplayType.PrevTabLevel1, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_43"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 1)
		}));
		_dataArray.Add(new HotKeyDisplayItem(44, EHotKeyDisplayType.NextTabLevel1, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_44"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 2)
		}));
		_dataArray.Add(new HotKeyDisplayItem(45, EHotKeyDisplayType.PrevTabLevel2, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_45"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(46, EHotKeyDisplayType.NextTabLevel2, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_46"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 4)
		}));
		_dataArray.Add(new HotKeyDisplayItem(47, EHotKeyDisplayType.PrevTabLevel3, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_47"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 5)
		}));
		_dataArray.Add(new HotKeyDisplayItem(48, EHotKeyDisplayType.NextTabLevel3, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_48"), new List<HotkeyIndex>
		{
			new HotkeyIndex(8, 6)
		}));
		_dataArray.Add(new HotKeyDisplayItem(49, EHotKeyDisplayType.BlockOperation, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_49"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 3),
			new HotkeyIndex(1, 1)
		}));
		_dataArray.Add(new HotKeyDisplayItem(50, EHotKeyDisplayType.ClearAllTips, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_50"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 6)
		}));
		_dataArray.Add(new HotKeyDisplayItem(51, EHotKeyDisplayType.XiangshuLevelChangedClose, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_51"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 2),
			new HotkeyIndex(1, 5),
			new HotkeyIndex(1, 3)
		}));
		_dataArray.Add(new HotKeyDisplayItem(52, EHotKeyDisplayType.EndTurn, LocalStringManager.GetConfig("HotKeyDisplay_language", "DisplayText_52"), new List<HotkeyIndex>
		{
			new HotkeyIndex(1, 2)
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<HotKeyDisplayItem>(53);
		CreateItems0();
	}
}
