using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class FengLaiYi : CombatSkillEffectBase
{
	private const short StatePower = 250;

	private const short LuckyPowerPercent = 50;

	private int _addPower;

	public FengLaiYi()
	{
	}

	public FengLaiYi(CombatSkillKey skillKey)
		: base(skillKey, 3302, -1)
	{
	}

	public unsafe override void OnEnable(DataContext context)
	{
		Personalities selfPersonalities = CharObj.GetPersonalities();
		Personalities enemyPersonalities = base.CurrEnemyChar.GetCharacter().GetPersonalities();
		if (selfPersonalities.Items[5] > enemyPersonalities.Items[5])
		{
			_addPower = selfPersonalities.Items[5] * 50 / 100;
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
			if (selfPersonalities.Items[6] > enemyPersonalities.Items[6])
			{
				DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CombatChar : base.CurrEnemyChar, (sbyte)(base.IsDirect ? 1 : 2), (short)(base.IsDirect ? 37 : 38), 250);
			}
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
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
