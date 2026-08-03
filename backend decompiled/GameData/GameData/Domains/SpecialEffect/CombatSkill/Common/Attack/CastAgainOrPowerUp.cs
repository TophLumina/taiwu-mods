using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class CastAgainOrPowerUp : CombatSkillEffectBase
{
	private const byte DirectCostTrickCount = 2;

	private const sbyte DirectAddPowerUnit = 10;

	private const sbyte ReverseAddPowerUnit = 10;

	private const sbyte PrepareProgressPercent = 50;

	protected sbyte RequireTrickType;

	private int _addPower;

	protected CastAgainOrPowerUp()
	{
	}

	protected CastAgainOrPowerUp(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 209, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (base.IsDirect)
		{
			if (_addPower > 0)
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
			}
			return;
		}
		int trickCount = base.CombatChar.ReplaceUsableTrick(context, RequireTrickType);
		if (trickCount > 0)
		{
			_addPower = trickCount * 10;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (base.IsDirect && PowerMatchAffectRequire(power) && base.CombatChar.GetTrickCount(RequireTrickType, useTrickEquals: true) >= 2 && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				_addPower += 10;
				List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				removeTricks.Clear();
				removeTricks.Add(new NeedTrick(RequireTrickType, 2));
				DomainManager.Combat.RemoveTrick(context, base.CombatChar, removeTricks);
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
				ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
			}
			else
			{
				ShowSpecialEffectTips(1);
				_addPower = 0;
				base.IsDirect = !base.IsDirect;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209)
		{
			return (!base.IsDirect) ? 1 : 0;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
