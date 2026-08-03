using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class SanXiaoMiXianQu : CombatSkillEffectBase
{
	private const sbyte CharmAddHitPercent = 20;

	private const sbyte GenderAddPower = 20;

	private const sbyte VirginAddPower = 20;

	private int _addHitMind;

	private int _addPower;

	public SanXiaoMiXianQu()
	{
	}

	public SanXiaoMiXianQu(CombatSkillKey skillKey)
		: base(skillKey, 8305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addHitMind = CharObj.GetAttraction() * 20 / 100;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 35, -1), EDataModifyType.Add);
		ShowSpecialEffectTips(0);
		GameData.Domains.Character.Character enemyChar = base.CurrEnemyChar.GetCharacter();
		if (enemyChar.CheckGenderMeetsRequirement((sbyte)(base.IsDirect ? 1 : 0)))
		{
			_addPower += 20;
			if (!enemyChar.HasVirginity())
			{
				_addPower += 20;
			}
		}
		if (_addPower > 0)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(1);
		}
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

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 35)
		{
			return _addHitMind;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return _addPower;
		}
		return 0;
	}
}
