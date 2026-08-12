using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class LongXianShi : CombatSkillEffectBase
{
	private const sbyte MaxReduceMark = 3;

	private DataUid _defeatMarkUid;

	private DefeatMarkCollection _lastMarks;

	private readonly List<(sbyte type, sbyte part)> _markRandomPool = new List<(sbyte, sbyte)>();

	public LongXianShi()
	{
	}

	public LongXianShi(CombatSkillKey skillKey)
		: base(skillKey, 17051, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		if (IsSrcSkillPerformed)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		DefeatMarkCollection markCollection = enemyChar.GetDefeatMarkCollection();
		_markRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			int flawCount = markCollection.FlawMarkList[part].Count;
			int acupointCount = markCollection.AcupointMarkList[part].Count;
			for (int i = 0; i < flawCount; i++)
			{
				_markRandomPool.Add((0, part));
			}
			for (int j = 0; j < acupointCount; j++)
			{
				_markRandomPool.Add((1, part));
			}
		}
		int mindCount = markCollection.MindMarkList.Count;
		for (int k = 0; k < mindCount; k++)
		{
			_markRandomPool.Add((2, -1));
		}
		if (!IsSrcSkillPerformed)
		{
			if (_markRandomPool.Count > 0 && PowerMatchAffectRequire(power))
			{
				while (_markRandomPool.Count > 3)
				{
					_markRandomPool.RemoveAt(context.Random.Next(_markRandomPool.Count));
				}
				for (int l = 0; l < _markRandomPool.Count; l++)
				{
					RemoveDefeatMark(context, enemyChar, _markRandomPool[l], markCollection, randomRemove: true);
				}
				enemyChar.SetDefeatMarkCollection(markCollection, context);
				IsSrcSkillPerformed = true;
				short effectCount = (short)(_markRandomPool.Count * 2);
				DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), effectCount, effectCount, autoRemoveOnNoCount: true);
				_lastMarks = new DefeatMarkCollection(base.CombatChar.GetDefeatMarkCollection());
				_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (_markRandomPool.Count > 0 && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		_markRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			int newFlawCount = markCollection.FlawMarkList[part].Count - _lastMarks.FlawMarkList[part].Count;
			int newAcupointCount = markCollection.AcupointMarkList[part].Count - _lastMarks.AcupointMarkList[part].Count;
			for (int i = 0; i < newFlawCount; i++)
			{
				_markRandomPool.Add((0, part));
			}
			for (int j = 0; j < newAcupointCount; j++)
			{
				_markRandomPool.Add((1, part));
			}
		}
		int newMindCount = markCollection.MindMarkList.Count - markCollection.MindMarkList.Count;
		for (int k = 0; k < newMindCount; k++)
		{
			_markRandomPool.Add((2, -1));
		}
		_lastMarks = new DefeatMarkCollection(base.CombatChar.GetDefeatMarkCollection());
		if (_markRandomPool.Count > 0)
		{
			while (_markRandomPool.Count > base.EffectCount)
			{
				_markRandomPool.RemoveAt(context.Random.Next(_markRandomPool.Count));
			}
			for (int l = 0; l < _markRandomPool.Count; l++)
			{
				RemoveDefeatMark(context, base.CombatChar, _markRandomPool[l], markCollection, randomRemove: false);
			}
			base.CombatChar.SetDefeatMarkCollection(markCollection, context);
			ReduceEffectCount(_markRandomPool.Count);
			ShowSpecialEffectTips(0);
		}
	}

	private void RemoveDefeatMark(DataContext context, CombatCharacter combatChar, (sbyte type, sbyte part) markInfo, DefeatMarkCollection markCollection, bool randomRemove)
	{
		if (markInfo.type == 0)
		{
			int flawCount = markCollection.FlawMarkList[markInfo.part].Count;
			int flawIndex = (randomRemove ? context.Random.Next(flawCount) : (flawCount - 1));
			markCollection.FlawMarkList[markInfo.part].RemoveAt(flawIndex);
			DomainManager.Combat.RemoveFlaw(context, combatChar, markInfo.part, flawIndex, raiseEvent: false, updateMark: false);
		}
		else if (markInfo.type == 1)
		{
			int acupointCount = markCollection.AcupointMarkList[markInfo.part].Count;
			int acupointIndex = (randomRemove ? context.Random.Next(acupointCount) : (acupointCount - 1));
			markCollection.AcupointMarkList[markInfo.part].RemoveAt(acupointIndex);
			DomainManager.Combat.RemoveAcupoint(context, combatChar, markInfo.part, acupointIndex, raiseEvent: false, updateMark: false);
		}
		else if (markInfo.type == 2)
		{
			combatChar.RemoveMindMark(context, 1, randomRemove, context.Random.Next(markCollection.MindMarkList.Count));
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}
