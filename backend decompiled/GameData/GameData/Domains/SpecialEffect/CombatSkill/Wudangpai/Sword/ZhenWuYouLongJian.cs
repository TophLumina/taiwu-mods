using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class ZhenWuYouLongJian : CombatSkillEffectBase
{
	private const sbyte AddNeedDist = 10;

	private const sbyte ReduceNeedDist = 20;

	private const sbyte CostMobilityReducePercent = 50;

	private short _addMovedDist;

	private short _reduceMovedDist;

	public ZhenWuYouLongJian()
	{
	}

	public ZhenWuYouLongJian(CombatSkillKey skillKey)
		: base(skillKey, 4205, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (AffectDatas == null)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType> { 
			{
				new AffectedDataKey(base.CharacterId, 175, -1),
				EDataModifyType.AddPercent
			} };
		}
		_addMovedDist = 0;
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover != base.CombatChar || !isMove || isForced)
		{
			return;
		}
		if ((base.IsDirect ? (distance < 0) : (distance > 0)) && base.EffectCount < base.MaxEffectCount && mover.GetPreparingSkillId() < 0)
		{
			_addMovedDist += Math.Abs(distance);
			while (_addMovedDist >= 10 && base.EffectCount < base.MaxEffectCount)
			{
				_addMovedDist -= 10;
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			}
		}
		else if (base.EffectCount > 0 && (base.IsDirect ? (distance > 0) : (distance < 0)) && mover.GetPreparingSkillId() >= 0 && Config.CombatSkill.Instance[mover.GetPreparingSkillId()].EquipType == 1)
		{
			_reduceMovedDist += Math.Abs(distance);
			while (_reduceMovedDist >= 20 && base.EffectCount > 0)
			{
				_reduceMovedDist -= 20;
				ReduceEffectCount();
			}
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && base.EffectCount > 0 && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			_reduceMovedDist = 0;
			DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, (short)(base.EffectCount * 10), !base.IsDirect);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || base.CombatChar.GetPreparingSkillId() < 0 || Config.CombatSkill.Instance[base.CombatChar.GetPreparingSkillId()].EquipType != 1)
		{
			return 0;
		}
		if (dataKey.FieldId == 175)
		{
			return 50;
		}
		return 0;
	}
}
