using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddMaxPowerOrUseRequirement : CombatSkillEffectBase
{
	private const sbyte AddMaxPowerUnit = 3;

	private const sbyte CdFrameUnit = 60;

	protected sbyte AffectEquipType;

	private sbyte _maxSkillPower;

	protected AddMaxPowerOrUseRequirement()
	{
	}

	protected AddMaxPowerOrUseRequirement(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_maxSkillPower = 0;
		if (base.IsDirect)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 200, -1), EDataModifyType.Add);
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
		if (base.IsDirect)
		{
			if (power > _maxSkillPower)
			{
				_maxSkillPower = (sbyte)(power / 10);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 200);
				ShowSpecialEffectTips(0);
			}
			return;
		}
		CombatCharacter enemyChar = base.CurrEnemyChar;
		short silenceSkill = enemyChar.GetRandomBanableSkillId(context.Random, null, AffectEquipType);
		int cdFrame = 60 * power / 10;
		if (silenceSkill >= 0 && cdFrame > 0)
		{
			DomainManager.Combat.SilenceSkill(context, enemyChar, silenceSkill, (short)cdFrame);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != AffectEquipType)
		{
			return 0;
		}
		if (dataKey.FieldId == 200)
		{
			return 3 * _maxSkillPower;
		}
		return 0;
	}
}
