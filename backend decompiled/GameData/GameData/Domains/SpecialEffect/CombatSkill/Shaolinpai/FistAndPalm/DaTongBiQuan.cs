using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class DaTongBiQuan : CombatSkillEffectBase
{
	private const sbyte AddSkillRange = 10;

	private const sbyte AddAttackRange = 10;

	private const sbyte AddPower = 20;

	private int _addPower;

	public DaTongBiQuan()
	{
	}

	public DaTongBiQuan(CombatSkillKey skillKey)
		: base(skillKey, 1102, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, -1), EDataModifyType.Add);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId && base.EffectCount > 0)
		{
			ReduceEffectCount();
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.EffectCount > 0)
		{
			_addPower = 20;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && base.EffectCount > 0 && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			ReduceEffectCount();
		}
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				AddMaxEffectCount();
				ShowSpecialEffectTips(0);
			}
			if (_addPower > 0)
			{
				_addPower = 0;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect && oldCount > 0 != newCount > 0)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 145) <= 1u)
		{
			int addRange = 0;
			if (dataKey.CombatSkillId == base.SkillTemplateId)
			{
				addRange += 10;
			}
			if (base.EffectCount > 0 && dataKey.FieldId == (base.IsDirect ? 146 : 145))
			{
				addRange += 10;
			}
			return addRange;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return _addPower;
		}
		return 0;
	}
}
