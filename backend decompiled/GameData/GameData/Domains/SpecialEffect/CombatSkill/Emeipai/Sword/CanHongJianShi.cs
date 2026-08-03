using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class CanHongJianShi : CombatSkillEffectBase
{
	private const int AddPowerUnit = 5;

	private int _lastTrickCount;

	public CanHongJianShi()
	{
	}

	public CanHongJianShi(CombatSkillKey skillKey)
		: base(skillKey, 2305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_lastTrickCount = 0;
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		if (base.IsDirect)
		{
			Events.RegisterHandler_GetTrick(OnGetTrick);
		}
		else
		{
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(new DataUid(8, 10, (ulong)base.CharacterId, 28u), base.DataHandlerKey, OnTricksChanged);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_GetTrick(OnGetTrick);
		}
		else
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(new DataUid(8, 10, (ulong)base.CharacterId, 28u), base.DataHandlerKey);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (base.CharacterId == charId && base.EffectCount < base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			ShowSpecialEffectTips(0);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	private void OnTricksChanged(DataContext context, DataUid dataUid)
	{
		int trickCount = base.CombatChar.GetTricks().Tricks.Count;
		if (trickCount < _lastTrickCount && base.EffectCount < base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), (short)Math.Min(_lastTrickCount - trickCount, base.MaxEffectCount - base.EffectCount));
			ShowSpecialEffectTips(0);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
		_lastTrickCount = trickCount;
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && power >= 100)
		{
			DomainManager.Combat.ChangeSkillEffectToMinCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 5 * base.EffectCount;
		}
		return 0;
	}
}
