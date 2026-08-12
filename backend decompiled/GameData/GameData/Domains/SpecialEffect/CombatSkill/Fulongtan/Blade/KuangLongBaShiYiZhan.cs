using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class KuangLongBaShiYiZhan : CombatSkillEffectBase
{
	private static readonly int[] HitAddDamagePercent = new int[3] { 20, 10, 5 };

	private readonly Dictionary<int, Dictionary<sbyte, int>> _charBodyPartHitCount = new Dictionary<int, Dictionary<sbyte, int>>();

	private static int HitCountToAddDamagePercent(int hitCount)
	{
		if (1 == 0)
		{
		}
		int result = ((hitCount > 0) ? (hitCount switch
		{
			1 => HitAddDamagePercent[0], 
			2 => HitAddDamagePercent[0] + HitAddDamagePercent[1], 
			_ => HitAddDamagePercent[0] + HitAddDamagePercent[1] + (hitCount - 2) * HitAddDamagePercent[2], 
		}) : 0);
		if (1 == 0)
		{
		}
		return result;
	}

	public KuangLongBaShiYiZhan()
	{
	}

	public KuangLongBaShiYiZhan(CombatSkillKey skillKey)
		: base(skillKey, 14204, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDataAdded(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 102, EDataModifyType.AddPercent, base.SkillTemplateId);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && hit && base.EffectCount > 0)
		{
			Dictionary<sbyte, int> hitCounts = _charBodyPartHitCount.GetOrNew(context.DefenderId);
			hitCounts[context.BodyPart] = hitCounts.GetOrDefault(context.BodyPart) + 1;
			ReduceEffectCount();
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			AddMaxEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			sbyte bodyPart = (sbyte)dataKey.CustomParam1;
			Dictionary<sbyte, int> hitCount;
			return _charBodyPartHitCount.TryGetValue(dataKey.CharId, out hitCount) ? HitCountToAddDamagePercent(hitCount.GetOrDefault(bodyPart)) : 0;
		}
		return 0;
	}
}
