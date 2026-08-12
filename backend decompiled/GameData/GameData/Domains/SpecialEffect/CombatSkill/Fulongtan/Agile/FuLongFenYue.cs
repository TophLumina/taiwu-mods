using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Agile;

public class FuLongFenYue : CheckHitEffect
{
	private const sbyte AddDamagePercent = 15;

	private const sbyte ReduceDamagePercent = -30;

	private bool _affecting;

	public FuLongFenYue()
	{
	}

	public FuLongFenYue(CombatSkillKey skillKey)
		: base(skillKey, 14403)
	{
		CheckHitType = 0;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 69 : 102), -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender))
		{
			_affecting = false;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if ((base.IsDirect ? (charId == base.CharacterId) : (isAlly != base.CombatChar.IsAlly)) && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			_affecting = false;
		}
	}

	protected override bool HitEffect(DataContext context)
	{
		_affecting = true;
		return true;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting)
		{
			return 0;
		}
		return base.IsDirect ? 15 : (-30);
	}
}
