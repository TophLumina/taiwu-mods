using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class LuoChaChuFa : CombatSkillEffectBase
{
	private const sbyte AddDamageUnit = 10;

	private int _addDamage;

	public LuoChaChuFa()
	{
	}

	public LuoChaChuFa(CombatSkillKey skillKey)
		: base(skillKey, 11302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		List<SkillEffectKey> pestleEffects = DomainManager.Combat.GetUsingWeaponData(base.CombatChar).GetPestleEffect();
		int gradeSum = 0;
		foreach (SkillEffectKey effectKey in pestleEffects)
		{
			if (effectKey.SkillId >= 0)
			{
				gradeSum += Config.CombatSkill.Instance[effectKey.SkillId].Grade + 1;
			}
		}
		_addDamage = 10 * gradeSum;
		if (_addDamage > 0)
		{
			ShowSpecialEffectTips(0);
		}
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (!interrupted)
			{
				DomainManager.Combat.GetUsingWeaponData(base.CombatChar).RemovePestleEffect(context);
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return _addDamage;
		}
		return 0;
	}
}
