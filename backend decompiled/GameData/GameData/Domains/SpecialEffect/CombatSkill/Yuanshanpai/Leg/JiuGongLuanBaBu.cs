using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class JiuGongLuanBaBu : CombatSkillEffectBase
{
	private const sbyte MoveDistInPrepare = 30;

	private const int AffectDistanceUnit = 2;

	private short _distanceAccumulator;

	private DefeatMarkCollection _oldMarks;

	private DefeatMarkCollection _lastMarks;

	private DefeatMarkCollection _newMarks;

	private DataUid _defeatMarkUid;

	private readonly List<(sbyte, sbyte)> _typeRandomPool = new List<(sbyte, sbyte)>();

	public JiuGongLuanBaBu()
	{
	}

	public JiuGongLuanBaBu(CombatSkillKey skillKey)
		: base(skillKey, 5103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		_oldMarks = new DefeatMarkCollection(markCollection);
		_lastMarks = new DefeatMarkCollection(markCollection);
		_newMarks = new DefeatMarkCollection();
		_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 30, base.IsDirect);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		for (sbyte part = 0; part < 7; part++)
		{
			int flawCount = markCollection.FlawMarkList[part].Count;
			int lastFlawCount = _lastMarks.FlawMarkList[part].Count;
			int acupointCount = markCollection.AcupointMarkList[part].Count;
			int lastAcupointCount = _lastMarks.AcupointMarkList[part].Count;
			if (flawCount > lastFlawCount)
			{
				for (int i = 0; i < flawCount - lastFlawCount; i++)
				{
					_newMarks.FlawMarkList[part].Add(0);
				}
			}
			else if (flawCount < lastFlawCount)
			{
				for (int j = 0; j < lastFlawCount - flawCount; j++)
				{
					if (_oldMarks.FlawMarkList[part].Count > 0)
					{
						_oldMarks.FlawMarkList[part].RemoveAt(0);
					}
				}
				while (_newMarks.FlawMarkList[part].Count > flawCount)
				{
					_newMarks.FlawMarkList[part].RemoveAt(0);
				}
			}
			_lastMarks.FlawMarkList[part].Clear();
			_lastMarks.FlawMarkList[part].AddRange(markCollection.FlawMarkList[part]);
			if (acupointCount > lastAcupointCount)
			{
				for (int k = 0; k < acupointCount - lastAcupointCount; k++)
				{
					_newMarks.AcupointMarkList[part].Add(0);
				}
			}
			else if (acupointCount < lastAcupointCount)
			{
				for (int l = 0; l < lastAcupointCount - acupointCount; l++)
				{
					if (_oldMarks.AcupointMarkList[part].Count > 0)
					{
						_oldMarks.AcupointMarkList[part].RemoveAt(0);
					}
				}
				while (_newMarks.AcupointMarkList[part].Count > acupointCount)
				{
					_newMarks.AcupointMarkList[part].RemoveAt(0);
				}
			}
			_lastMarks.AcupointMarkList[part].Clear();
			_lastMarks.AcupointMarkList[part].AddRange(markCollection.AcupointMarkList[part]);
		}
		int mindCount = markCollection.MindMarkList.Count;
		int lastMindCount = _lastMarks.MindMarkList.Count;
		if (mindCount > lastMindCount)
		{
			for (int m = lastMindCount; m < mindCount; m++)
			{
				_newMarks.MindMarkList.Add(markCollection.MindMarkList[m]);
			}
		}
		else if (mindCount < lastMindCount)
		{
			for (int n = 0; n < lastMindCount - mindCount; n++)
			{
				if (_oldMarks.MindMarkList.Count <= 0)
				{
					break;
				}
				_oldMarks.MindMarkList.RemoveAt(0);
			}
			while (_newMarks.MindMarkList.Count > mindCount)
			{
				_newMarks.MindMarkList.RemoveAt(0);
			}
		}
		_lastMarks.MindMarkList.Clear();
		_lastMarks.MindMarkList.AddRange(markCollection.MindMarkList);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.GetId() != base.CharacterId || !isMove || isForced)
		{
			return;
		}
		if (base.IsDirect ? (distance < 0) : (distance > 0))
		{
			_distanceAccumulator += Math.Abs(distance);
		}
		while (_distanceAccumulator >= 2)
		{
			_distanceAccumulator -= 2;
			if (_newMarks.GetTotalFlawCount() + _newMarks.GetTotalAcupointCount() + _newMarks.MindMarkList.Count <= 0)
			{
				continue;
			}
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			_typeRandomPool.Clear();
			for (sbyte part = 0; part < 7; part++)
			{
				for (int i = 0; i < _newMarks.FlawMarkList[part].Count; i++)
				{
					_typeRandomPool.Add((0, part));
				}
				for (int j = 0; j < _newMarks.AcupointMarkList[part].Count; j++)
				{
					_typeRandomPool.Add((1, part));
				}
			}
			for (int k = 0; k < _newMarks.MindMarkList.Count; k++)
			{
				_typeRandomPool.Add((2, -1));
			}
			(sbyte, sbyte) transferMark = _typeRandomPool[context.Random.Next(0, _typeRandomPool.Count)];
			if (transferMark.Item1 == 0)
			{
				DomainManager.Combat.TransferFlaw(context, base.CombatChar, enemyChar, transferMark.Item2, context.Random.Next(_oldMarks.FlawMarkList[transferMark.Item2].Count, _lastMarks.FlawMarkList[transferMark.Item2].Count));
			}
			else if (transferMark.Item1 == 1)
			{
				DomainManager.Combat.TransferAcupoint(context, base.CombatChar, enemyChar, transferMark.Item2, context.Random.Next(_oldMarks.AcupointMarkList[transferMark.Item2].Count, _lastMarks.AcupointMarkList[transferMark.Item2].Count));
			}
			else
			{
				base.CombatChar.TransferMindMark(context, enemyChar, context.Random.Next(_oldMarks.MindMarkList.Count, _lastMarks.MindMarkList.Count));
			}
			OnDefeatMarkChanged(context, default(DataUid));
			DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
