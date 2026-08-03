using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class YinYangYanShu : AssistSkillBase
{
	private const sbyte ReduceSpeedUnit = -2;

	private int _reduceSpeed;

	public YinYangYanShu()
	{
	}

	public YinYangYanShu(CombatSkillKey skillKey)
		: base(skillKey, 7602)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || !base.CanAffect)
		{
			return;
		}
		GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetCharacter();
		short selfSpeed = CharObj.GetCastSpeed();
		short enemySpeed = enemyChar.GetCastSpeed();
		if (base.IsDirect ? (selfSpeed > enemySpeed) : (selfSpeed < enemySpeed))
		{
			_reduceSpeed = -2 * Math.Abs(selfSpeed - enemySpeed);
			if (AffectDatas == null || AffectDatas.Count == 0)
			{
				AppendAffectedData(context, enemyChar.GetId(), 11, EDataModifyType.Add, -1);
			}
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId)
		{
			ClearAffectedData(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 11)
		{
			return _reduceSpeed;
		}
		return 0;
	}
}
