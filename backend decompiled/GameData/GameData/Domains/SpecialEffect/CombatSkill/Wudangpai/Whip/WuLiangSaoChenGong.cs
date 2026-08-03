using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class WuLiangSaoChenGong : CombatSkillEffectBase
{
	private readonly sbyte[] _directAddPowerList = new sbyte[5] { 40, 30, 20, 10, 0 };

	private readonly sbyte[] _directAddDamagePercentList = new sbyte[5] { 40, 20, 0, 0, 0 };

	private readonly sbyte[] _reverseAddPowerList = new sbyte[5] { 0, 20, 40, 60, 80 };

	private readonly sbyte[] _reverseAddDamagePercentList = new sbyte[5] { 0, 0, 20, 40, 60 };

	private int _addPower;

	private int _addDamagePercent;

	public WuLiangSaoChenGong()
	{
	}

	public WuLiangSaoChenGong(CombatSkillKey skillKey)
		: base(skillKey, 4306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int disorderLevel = DisorderLevelOfQi.GetDisorderLevelOfQi((base.IsDirect ? CharObj : base.CurrEnemyChar.GetCharacter()).GetDisorderOfQi());
		_addPower = (base.IsDirect ? _directAddPowerList : _reverseAddPowerList)[disorderLevel];
		if (_addPower > 0)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && index == 2 && CombatCharPowerMatchAffectRequire())
		{
			int disorderLevel = DisorderLevelOfQi.GetDisorderLevelOfQi((base.IsDirect ? CharObj : base.CurrEnemyChar.GetCharacter()).GetDisorderOfQi());
			_addDamagePercent = (base.IsDirect ? _directAddDamagePercentList : _reverseAddDamagePercentList)[disorderLevel];
			if (_addDamagePercent > 0)
			{
				AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
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
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && dataKey.CharId == base.CharacterId)
		{
			return _addPower;
		}
		if (dataKey.FieldId == 69)
		{
			return _addDamagePercent;
		}
		return 0;
	}
}
