using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class JinJingXuanHuBangFa : RawCreateUnlockEffectBase
{
	private int AddHitOdds => base.IsDirectOrReverseEffectDoubling ? 300 : 150;

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[2] { 0, 2 };

	protected override int RequireMainAttributeValue => 65;

	public JinJingXuanHuBangFa()
	{
	}

	public JinJingXuanHuBangFa(CombatSkillKey skillKey)
		: base(skillKey, 9304)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(74, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (SkillKey.IsMatch(attacker.GetId(), skillId) && base.IsReverseOrUsingDirectWeapon)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 74 || !base.IsReverseOrUsingDirectWeapon)
		{
			return 0;
		}
		return AddHitOdds;
	}
}
