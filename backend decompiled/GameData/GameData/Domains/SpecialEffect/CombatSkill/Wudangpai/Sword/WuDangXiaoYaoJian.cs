using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class WuDangXiaoYaoJian : CombatSkillEffectBase
{
	private const sbyte MoveDistInCast = 20;

	public WuDangXiaoYaoJian()
	{
	}

	public WuDangXiaoYaoJian(CombatSkillKey skillKey)
		: base(skillKey, 4201, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(175, EDataModifyType.Custom, -1);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 20, base.IsDirect);
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
			RemoveSelf(context);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 175)
		{
			return dataValue;
		}
		return 0;
	}
}
