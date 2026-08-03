using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class XuMiShanSiShenZhang : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private const sbyte AddAttackRange = 30;

	private ushort _attackRangeFieldId;

	private int _costBreathOrStance;

	public XuMiShanSiShenZhang()
	{
	}

	public XuMiShanSiShenZhang(CombatSkillKey skillKey)
		: base(skillKey, 11106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_attackRangeFieldId = (ushort)(base.IsDirect ? 146 : 145);
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(_attackRangeFieldId, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(325, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (base.EffectCount == base.MaxEffectCount && _costBreathOrStance > 0)
		{
			if (base.IsDirect)
			{
				ChangeStanceValue(context, base.CombatChar, _costBreathOrStance);
			}
			else
			{
				ChangeBreathValue(context, base.CombatChar, _costBreathOrStance);
			}
			_costBreathOrStance = 0;
			ShowSpecialEffectTips(3);
		}
		if (PowerMatchAffectRequire(power) && base.EffectCount < base.MaxEffectCount)
		{
			SkillEffectKey key = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
			if (base.EffectCount == 0)
			{
				DomainManager.Combat.AddSkillEffect(context, base.CombatChar, key, 1, base.MaxEffectCount, autoRemoveOnNoCount: true);
			}
			else
			{
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, key, 1);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId != base.CharacterId || key.SkillId != base.SkillTemplateId || key.IsDirect != base.IsDirect)
		{
			return;
		}
		if (oldCount < 1 != newCount < 1)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
		if (newCount > oldCount)
		{
			for (int i = 1; i < 4; i++)
			{
				if (oldCount < i != newCount < i)
				{
					ShowSpecialEffectTips((byte)(i - 1));
				}
			}
		}
		if (newCount <= 0 && !removed)
		{
			DomainManager.Combat.RemoveSkillEffect(context, base.CombatChar, key);
		}
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (base.CharacterId == charId && skillId == base.SkillTemplateId && base.EffectCount >= base.MaxEffectCount)
		{
			_costBreathOrStance = (base.IsDirect ? costStance : costBreath);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || base.EffectCount == 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && base.EffectCount >= 1)
		{
			return 40;
		}
		if (dataKey.FieldId == _attackRangeFieldId && base.EffectCount >= 2)
		{
			return 30;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 325 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && base.EffectCount >= 3 && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
