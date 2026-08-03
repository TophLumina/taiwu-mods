using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ZiWuXiao;

public class JiuJiuZaoMing : CombatSkillEffectBase
{
	private DataUid _selfMarkUid;

	private readonly byte[] _selfLastPoisonMark = new byte[6];

	private DataUid _enemyInjuriesUid;

	private Injuries _enemyLastInjuries;

	public JiuJiuZaoMing()
	{
	}

	public JiuJiuZaoMing(CombatSkillKey skillKey)
		: base(skillKey, 17112, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Array.Copy(base.CombatChar.GetDefeatMarkCollection().PoisonMarkList, _selfLastPoisonMark, 6);
		_selfMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_selfMarkUid, base.DataHandlerKey, OnSelfMarkChanged);
		UpdateEnemyUid(init: true);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_selfMarkUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (base.EffectCount <= 0)
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			UpdateEnemyUid(init: false);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnSelfMarkChanged(DataContext context, DataUid dataUid)
	{
		byte[] poisonMarks = base.CombatChar.GetDefeatMarkCollection().PoisonMarkList;
		for (sbyte type = 0; type < 6; type++)
		{
			byte newCount = poisonMarks[type];
			if (newCount > _selfLastPoisonMark[type])
			{
				ReduceEffectCount(newCount - _selfLastPoisonMark[type]);
				if (base.EffectCount <= 0)
				{
					break;
				}
			}
			_selfLastPoisonMark[type] = newCount;
		}
	}

	private void OnEnemyInjuriesChanged(DataContext context, DataUid dataUid)
	{
		Injuries selfInjuries = base.CombatChar.GetInjuries();
		Injuries newInjuries = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetInjuries();
		bool affected = false;
		for (sbyte part = 0; part < 7; part++)
		{
			(sbyte, sbyte) selfInjury = selfInjuries.Get(part);
			if (selfInjury.Item1 != 0 || selfInjury.Item2 != 0)
			{
				(sbyte, sbyte) newInjury = newInjuries.Get(part);
				(sbyte, sbyte) lastInjury = _enemyLastInjuries.Get(part);
				int healCount = 0;
				if (newInjury.Item1 != lastInjury.Item1)
				{
					healCount += Math.Abs(newInjury.Item1 - lastInjury.Item1);
				}
				if (newInjury.Item2 != lastInjury.Item2)
				{
					healCount += Math.Abs(newInjury.Item2 - lastInjury.Item2);
				}
				if (healCount != 0)
				{
					while (selfInjury.Item1 + selfInjury.Item2 > healCount)
					{
						if (selfInjury.Item1 > 0 && (selfInjury.Item2 == 0 || context.Random.CheckPercentProb(50)))
						{
							selfInjury.Item1--;
						}
						else
						{
							selfInjury.Item2--;
						}
					}
					if (selfInjury.Item1 > 0)
					{
						base.CombatChar.RemoveInjury(context, part, inner: false, selfInjury.Item1);
					}
					if (selfInjury.Item2 > 0)
					{
						base.CombatChar.RemoveInjury(context, part, inner: true, selfInjury.Item2);
					}
					affected = true;
				}
			}
		}
		_enemyLastInjuries = newInjuries;
		if (affected)
		{
			DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
			ShowSpecialEffectTips(0);
		}
	}

	private void UpdateEnemyUid(bool init)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		_enemyLastInjuries = currEnemy.GetInjuries();
		if (!init)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey);
		}
		_enemyInjuriesUid = new DataUid(8, 10, (ulong)currEnemy.GetId(), 29u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey, OnEnemyInjuriesChanged);
	}
}
