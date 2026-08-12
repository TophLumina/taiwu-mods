using System;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class YunKuangShi : CombatSkillEffectBase
{
	private const sbyte MoveDistInPrepare = 30;

	private const int AffectDistanceUnit = 2;

	private const sbyte AttackRangeAddUnit = 2;

	private const sbyte AddPower = 40;

	private short _affectingSkillId;

	private short _movedDist;

	private short _addAttackRange;

	public YunKuangShi()
	{
	}

	public YunKuangShi(CombatSkillKey skillKey)
		: base(skillKey, 6106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affectingSkillId = -1;
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && IsSrcSkillPerformed && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			_affectingSkillId = skillId;
			_movedDist = 0;
			_addAttackRange = 0;
			DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 30, base.IsDirect);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			if (skillId == base.SkillTemplateId)
			{
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (skillId == base.SkillTemplateId)
			{
				IsSrcSkillPerformed = true;
				if (PowerMatchAffectRequire(power))
				{
					AppendAffectedData(context, base.CharacterId, 145, EDataModifyType.Add, skillId);
					AppendAffectedData(context, base.CharacterId, 146, EDataModifyType.Add, skillId);
					AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, skillId);
					AddMaxEffectCount();
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else if (_affectingSkillId >= 0)
		{
			_affectingSkillId = -1;
			_addAttackRange = 0;
			if (skillId == base.SkillTemplateId)
			{
				RemoveSelf(context);
			}
			else
			{
				ReduceEffectCount();
			}
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.GetId() == base.CharacterId && _affectingSkillId >= 0 && isMove)
		{
			_movedDist += distance;
			short addAttackRange = (short)(Math.Abs(_movedDist) / 2 * 2);
			if (_addAttackRange != addAttackRange)
			{
				_addAttackRange = addAttackRange;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return _addAttackRange;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == base.SkillTemplateId && _affectingSkillId == base.SkillTemplateId)
		{
			return 40;
		}
		return 0;
	}
}
