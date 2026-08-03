using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class LiuYaSiShenZu : CombatSkillEffectBase
{
	private const int AddEffectCountFrame = 600;

	private const int CastAddCount = 2;

	private const int MarkAddCount = 1;

	private bool IsAffect4 => base.EffectCount >= 4;

	private bool IsAffect8 => base.EffectCount >= 8;

	public LiuYaSiShenZu()
	{
	}

	public LiuYaSiShenZu(CombatSkillKey skillKey)
		: base(skillKey, 5108, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(217, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(215, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(251, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_AddInjury(OnAddInjury);
		Events.RegisterHandler_AddFatalDamageMark(OnAddFatalOrMindMark);
		Events.RegisterHandler_AddMindMark(OnAddFatalOrMindMark);
		Events.RegisterHandler_FlawAdded(OnFlawAdded);
		Events.RegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_AddInjury(OnAddInjury);
		Events.UnRegisterHandler_AddFatalDamageMark(OnAddFatalOrMindMark);
		Events.UnRegisterHandler_AddMindMark(OnAddFatalOrMindMark);
		Events.UnRegisterHandler_FlawAdded(OnFlawAdded);
		Events.UnRegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 600;
	}

	public override bool IsOn(int counterType)
	{
		return IsAffect8;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		AddEffectCount();
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId == base.CharacterId && !(key != base.EffectKey) && base.EffectCount == base.MaxEffectCount)
		{
			DoChangeMark(context);
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, key, (short)(-base.EffectCount), raiseEvent: false);
		}
	}

	private void OnAddInjury(DataContext context, CombatCharacter character, sbyte bodyPart, bool isInner, int value, bool changeToOld)
	{
		if (character.GetId() == base.CharacterId && isInner != base.IsDirect)
		{
			AddMarkEffectCount();
		}
	}

	private void OnAddFatalOrMindMark(DataContext context, CombatCharacter combatChar, int count)
	{
		if (combatChar.GetId() == base.CharacterId && count > 0)
		{
			AddMarkEffectCount();
		}
	}

	private void OnFlawAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (combatChar.GetId() == base.CharacterId && base.IsDirect)
		{
			AddMarkEffectCount();
		}
	}

	private void OnAcuPointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (combatChar.GetId() == base.CharacterId && !base.IsDirect)
		{
			AddMarkEffectCount();
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddEffectCount(2);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}

	private void AddMarkEffectCount()
	{
		if (base.EffectCount > 0 && base.SkillData.GetLeftCdFrame() == 0)
		{
			AddEffectCount();
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}

	private void DoChangeMark(DataContext context)
	{
		DomainManager.Combat.RemoveHalfFlawOrAcupoint(context, base.CombatChar, base.IsDirect);
		base.CombatChar.RemoveHalfInjury(context, !base.IsDirect);
		base.CombatChar.RemoveHalfFatalMark(context);
		base.CombatChar.RemoveHalfMindMark(context);
		ShowSpecialEffectTips(1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 281)
		{
			return dataValue || IsAffect8;
		}
		if (dataKey.SkillKey != SkillKey || !IsAffect4)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 251)
		{
			return true;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 215 || fieldId == 217) ? true : false)
		{
			return false;
		}
		return dataValue;
	}
}
