using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;

public class XiongBingChuangSanZhen : CombatSkillEffectBase
{
	private const sbyte AddAttribute = 100;

	public XiongBingChuangSanZhen()
	{
	}

	public XiongBingChuangSanZhen(CombatSkillKey skillKey)
		: base(skillKey, 17071, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: true);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: false);
		base.CombatChar.CanNormalAttackInPrepareSkill = true;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 9, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 14, -1), EDataModifyType.TotalPercent);
		ShowSpecialEffectTips(0);
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
			base.CombatChar.CanNormalAttackInPrepareSkill = false;
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return 100;
	}
}
