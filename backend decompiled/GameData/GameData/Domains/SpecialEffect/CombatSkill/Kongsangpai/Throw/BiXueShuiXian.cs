using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class BiXueShuiXian : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 10;

	private const sbyte AddRangeUnit = 10;

	private int _addPower;

	private int _addRange;

	public BiXueShuiXian()
	{
	}

	public BiXueShuiXian(CombatSkillKey skillKey)
		: base(skillKey, 10403, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				_addPower = 0;
				_addRange = 0;
				AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.Add, base.SkillTemplateId);
				AppendAffectedData(context, base.CharacterId, 145, EDataModifyType.Add, base.SkillTemplateId);
				AppendAffectedData(context, base.CharacterId, 146, EDataModifyType.Add, base.SkillTemplateId);
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (!IsSrcSkillPerformed || base.EffectCount <= 0 || (base.IsDirect && combatSkillId == base.SkillTemplateId))
		{
			return;
		}
		bool num;
		if ((outerMarkCount <= 0 && innerMarkCount <= 0) || !base.IsDirect)
		{
			if (defenderId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).IsAlly != base.CombatChar.IsAlly;
		}
		else
		{
			if (attackerId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly;
		}
		if (num)
		{
			_addPower += 10 * (outerMarkCount + innerMarkCount);
			_addRange += 10 * (outerMarkCount + innerMarkCount);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			ShowSpecialEffectTips(0);
			ReduceEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!IsSrcSkillPerformed || dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return _addRange;
		}
		return 0;
	}
}
