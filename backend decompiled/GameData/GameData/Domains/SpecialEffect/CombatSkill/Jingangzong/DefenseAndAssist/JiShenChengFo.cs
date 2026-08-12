using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class JiShenChengFo : DefenseSkillBase
{
	private const sbyte RequireNeiliAllocation = 3;

	private const short AddQiDisorder = 200;

	private DataUid _defeatMarkUid;

	private DefeatMarkCollection _lastMarks;

	private readonly List<(sbyte, sbyte)> _newMarkList = new List<(sbyte, sbyte)>();

	public JiShenChengFo()
	{
	}

	public JiShenChengFo(CombatSkillKey skillKey)
		: base(skillKey, 11607)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(191, EDataModifyType.Custom, -1);
		CreateAffectedData(192, EDataModifyType.Custom, -1);
		_lastMarks = new DefeatMarkCollection(base.CombatChar.GetDefeatMarkCollection());
		_defeatMarkUid = ParseCombatCharacterDataUid(50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
	}

	private unsafe void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		if (!base.CanAffect)
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
		byte neiliAllocationType = 2;
		int canHealCount = neiliAllocation.Items[(int)neiliAllocationType] / 3;
		if (canHealCount <= 0)
		{
			UpdateLastDefeatMarks();
			return;
		}
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		_newMarkList.Clear();
		if (base.IsDirect)
		{
			Injuries newInjuries = base.CombatChar.GetInjuries().Subtract(base.CombatChar.GetOldInjuries());
			for (sbyte part = 0; part < 7; part++)
			{
				int outerCount = Math.Min(newInjuries.Get(part, isInnerInjury: false), markCollection.OuterInjuryMarkList[part] - _lastMarks.OuterInjuryMarkList[part]);
				for (int i = 0; i < outerCount; i++)
				{
					_newMarkList.Add((0, part));
				}
				int innerCount = Math.Min(newInjuries.Get(part, isInnerInjury: true), markCollection.InnerInjuryMarkList[part] - _lastMarks.InnerInjuryMarkList[part]);
				for (int j = 0; j < innerCount; j++)
				{
					_newMarkList.Add((1, part));
				}
			}
		}
		else
		{
			for (sbyte part2 = 0; part2 < 7; part2++)
			{
				int newFlawCount = markCollection.FlawMarkList[part2].Count - _lastMarks.FlawMarkList[part2].Count;
				for (int k = 0; k < newFlawCount; k++)
				{
					_newMarkList.Add((2, part2));
				}
				int newAcupointCount = markCollection.AcupointMarkList[part2].Count - _lastMarks.AcupointMarkList[part2].Count;
				for (int l = 0; l < newAcupointCount; l++)
				{
					_newMarkList.Add((3, part2));
				}
			}
			int newMindMarkCount = markCollection.MindMarkList.Count - _lastMarks.MindMarkList.Count;
			for (int m = 0; m < newMindMarkCount; m++)
			{
				_newMarkList.Add((4, -1));
			}
		}
		UpdateLastDefeatMarks();
		if (_newMarkList.Count == 0)
		{
			return;
		}
		for (int n = 0; n < canHealCount; n++)
		{
			if (_newMarkList.Count <= 0)
			{
				break;
			}
			int index = context.Random.Next(0, _newMarkList.Count);
			(sbyte, sbyte) markInfo = _newMarkList[index];
			_newMarkList.RemoveAt(index);
			base.CombatChar.ChangeNeiliAllocation(context, neiliAllocationType, -3);
			DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, 200);
			if (markInfo.Item1 == 0)
			{
				base.CombatChar.RemoveInjury(context, markInfo.Item2, inner: false);
			}
			else if (markInfo.Item1 == 1)
			{
				base.CombatChar.RemoveInjury(context, markInfo.Item2, inner: true);
			}
			else if (markInfo.Item1 == 2)
			{
				DomainManager.Combat.RemoveFlaw(context, base.CombatChar, markInfo.Item2, base.CombatChar.GetFlawCount()[markInfo.Item2] - 1);
			}
			else if (markInfo.Item1 == 3)
			{
				DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, markInfo.Item2, base.CombatChar.GetAcupointCount()[markInfo.Item2] - 1);
			}
			else if (markInfo.Item1 == 4)
			{
				base.CombatChar.RemoveMindMark(context, 1, random: false, base.CombatChar.GetMindMarkTime().MarkList.Count - 1);
			}
		}
		ShowSpecialEffectTips(0);
	}

	private void UpdateLastDefeatMarks()
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		if (base.IsDirect)
		{
			for (sbyte part = 0; part < 7; part++)
			{
				_lastMarks.OuterInjuryMarkList[part] = markCollection.OuterInjuryMarkList[part];
				_lastMarks.InnerInjuryMarkList[part] = markCollection.InnerInjuryMarkList[part];
			}
			return;
		}
		for (sbyte part2 = 0; part2 < 7; part2++)
		{
			_lastMarks.FlawMarkList[part2].Clear();
			_lastMarks.FlawMarkList[part2].AddRange(markCollection.FlawMarkList[part2]);
			_lastMarks.AcupointMarkList[part2].Clear();
			_lastMarks.AcupointMarkList[part2].AddRange(markCollection.AcupointMarkList[part2]);
		}
		_lastMarks.MindMarkList.Clear();
		_lastMarks.MindMarkList.AddRange(markCollection.MindMarkList);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || base.CombatChar.BeCriticalDuringCalcAddInjury)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 191) <= 1u)
		{
			return 0;
		}
		return dataValue;
	}
}
