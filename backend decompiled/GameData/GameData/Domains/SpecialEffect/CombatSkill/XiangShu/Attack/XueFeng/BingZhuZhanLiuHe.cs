using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;

public class BingZhuZhanLiuHe : CombatSkillEffectBase
{
	private const sbyte AddAttribute = 100;

	private const sbyte ChangeDamagePercent = 60;

	public BingZhuZhanLiuHe()
	{
	}

	public BingZhuZhanLiuHe(CombatSkillKey skillKey)
		: base(skillKey, 17074, -1)
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
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
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
		if (dataKey.FieldId == 9 || dataKey.FieldId == 14)
		{
			return 100;
		}
		if (dataKey.FieldId == 69)
		{
			return 60;
		}
		if (dataKey.FieldId == 102)
		{
			return -60;
		}
		return 0;
	}
}
