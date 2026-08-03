using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.FistAndPalm;

public class QingJiaoShenZhang : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 4;

	private const sbyte ChangeToOldInjuryCount = 18;

	private int _addPower;

	public QingJiaoShenZhang()
	{
	}

	public QingJiaoShenZhang(CombatSkillKey skillKey)
		: base(skillKey, 10105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DefeatMarkCollection markCollection = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true) : base.CombatChar).GetDefeatMarkCollection();
		_addPower = 4 * (markCollection.OuterInjuryMarkList.Sum() + markCollection.InnerInjuryMarkList.Sum());
		if (_addPower > 0)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			int changeCount = base.CurrEnemyChar.ChangeToOldInjury(context, 18);
			if (changeCount > 0)
			{
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
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
