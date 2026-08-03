using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class QiXingHengLian : AssistSkillBase
{
	private const sbyte RequireTrickCount = 7;

	private static readonly CValuePercent CostPercent = 50;

	private static readonly CValuePercent PrepareProgressPercent = 50;

	private static readonly CValuePercent FixedPrepareProgress = 15;

	private DataUid _tricksUid;

	private bool _affecting;

	private short _preparingSkillId;

	private CValuePercent _preparingPercent;

	public QiXingHengLian()
	{
	}

	public QiXingHengLian(CombatSkillKey skillKey)
		: base(skillKey, 2707)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 228 : 227), -1), EDataModifyType.Custom);
		_tricksUid = new DataUid(8, 10, (ulong)base.CharacterId, 28u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_tricksUid, base.DataHandlerKey, OnTrickChanged);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_tricksUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateCanAffect(context);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (charId != base.CharacterId || !_affecting || skillId < 0 || Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			UpdateCanAffect(context);
			return;
		}
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId));
		_preparingSkillId = skillId;
		_preparingPercent = FixedPrepareProgress + (base.IsDirect ? skill.GetCostStancePercent() : skill.GetCostBreathPercent()) * CostPercent * PrepareProgressPercent;
		ShowSpecialEffectTips(0);
		ShowSpecialEffectTips(1);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == _preparingSkillId && !(_preparingPercent <= 0) && !base.CombatChar.GetAutoCastingSkill())
		{
			int addProgress = base.CombatChar.SkillPrepareTotalProgress * _preparingPercent;
			int maxProgress = base.CombatChar.SkillPrepareTotalProgress;
			base.CombatChar.SkillPrepareCurrProgress = Math.Max(base.CombatChar.SkillPrepareCurrProgress, Math.Min(base.CombatChar.SkillPrepareCurrProgress + addProgress, maxProgress));
			base.CombatChar.SetSkillPreparePercent((byte)(base.CombatChar.SkillPrepareCurrProgress * 100 / base.CombatChar.SkillPrepareTotalProgress), context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			UpdateCanAffect(context);
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context);
	}

	private void OnTrickChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context);
	}

	private void UpdateCanAffect(DataContext context)
	{
		IReadOnlyDictionary<int, sbyte> trickDict = base.CombatChar.GetTricks().Tricks;
		bool canAffect = base.CanAffect && trickDict.Count >= 7;
		if (canAffect)
		{
			canAffect = base.CombatChar.UsableTrickCount >= 7;
		}
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			SetConstAffecting(context, canAffect);
			DomainManager.Combat.UpdateSkillCostBreathStanceCanUse(context, base.CombatChar);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 1)
		{
			return dataValue;
		}
		if (dataKey.FieldId == (base.IsDirect ? 228 : 227))
		{
			return dataValue * CostPercent;
		}
		return 0;
	}
}
