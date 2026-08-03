using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class YouShenBaGuaZhang : CombatSkillEffectBase
{
	private const sbyte NeedDistance = 10;

	private const sbyte ReduceCostUnit = -20;

	private const sbyte AddPropertyUnit = 4;

	private int _distanceAccumulator;

	public YouShenBaGuaZhang()
	{
	}

	public YouShenBaGuaZhang(CombatSkillKey skillKey)
		: base(skillKey, 4103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_distanceAccumulator = 0;
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 204, base.SkillTemplateId), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 32 : 38), base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 33 : 39), base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 34 : 40), base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && base.EffectCount < base.MaxEffectCount)
		{
			_distanceAccumulator += Math.Abs(distance);
			while (_distanceAccumulator >= 10 && base.EffectCount < base.MaxEffectCount)
			{
				_distanceAccumulator -= 10;
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 204);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 32 : 38));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 33 : 39));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 34 : 40));
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted) && base.EffectCount > 0)
		{
			ReduceEffectCount();
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 204);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 32 : 38));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 33 : 39));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 34 : 40));
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 204 && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return -20 * base.EffectCount;
		}
		if (dataKey.FieldId == 32 || dataKey.FieldId == 33 || dataKey.FieldId == 34 || dataKey.FieldId == 38 || dataKey.FieldId == 39 || dataKey.FieldId == 40)
		{
			return 4 * base.EffectCount;
		}
		return 0;
	}
}
