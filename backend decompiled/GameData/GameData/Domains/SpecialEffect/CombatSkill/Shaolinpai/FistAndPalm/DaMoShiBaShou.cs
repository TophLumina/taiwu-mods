using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class DaMoShiBaShou : CombatSkillEffectBase
{
	private const sbyte AddPower = 20;

	private int _addPenetrate;

	public DaMoShiBaShou()
	{
	}

	public DaMoShiBaShou(CombatSkillKey skillKey)
		: base(skillKey, 1105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		OuterAndInnerInts penetrations = CharObj.GetPenetrations();
		OuterAndInnerInts penetrationResists = CharObj.GetPenetrationResists();
		if (base.IsDirect ? (penetrationResists.Outer > penetrations.Outer) : (penetrationResists.Inner > penetrations.Inner))
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	protected virtual void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			OuterAndInnerInts penetrationResists = CharObj.GetPenetrationResists();
			_addPenetrate = (base.IsDirect ? penetrationResists.Outer : penetrationResists.Inner);
			AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 44 : 45), EDataModifyType.Add, -1);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return 20;
		}
		if (dataKey.FieldId == 44 || dataKey.FieldId == 45)
		{
			return _addPenetrate;
		}
		return 0;
	}
}
