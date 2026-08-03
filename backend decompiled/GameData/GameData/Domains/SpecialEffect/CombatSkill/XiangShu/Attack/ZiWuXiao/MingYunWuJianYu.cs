using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ZiWuXiao;

public class MingYunWuJianYu : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 40;

	private int _addPower;

	public MingYunWuJianYu()
	{
	}

	public MingYunWuJianYu(CombatSkillKey skillKey)
		: base(skillKey, 17115, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		SkillEffectKey effectKey = new SkillEffectKey(884, isDirect: true);
		Dictionary<SkillEffectKey, short> effectDict = base.CombatChar.GetSkillEffectCollection().EffectDict;
		short count;
		int effectCount = ((effectDict != null && effectDict.TryGetValue(effectKey, out count)) ? count : 0);
		_addPower = effectCount * 40;
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, effectKey, (short)(-effectCount));
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			SkillEffectKey effectKey = new SkillEffectKey(882, isDirect: true);
			Dictionary<SkillEffectKey, short> effectDict = base.CombatChar.GetSkillEffectCollection().EffectDict;
			if (effectDict != null && effectDict.ContainsKey(effectKey))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, 885);
				ShowSpecialEffectTips(1);
			}
			else if (base.EnemyChar.WorsenAllInjury(context, WorsenConstants.SpecialPercentMingYunWuJianYu))
			{
				ShowSpecialEffectTips(2);
			}
		}
		RemoveSelf(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey)
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
