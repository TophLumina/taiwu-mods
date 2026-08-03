using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class ShaoLinJinGangZhang : CombatSkillEffectBase
{
	private const sbyte ChangeInnerRatioUnit = 5;

	private const sbyte AddPower = 40;

	private int _changeInnerRatio;

	private bool _innerRatioMaxChanged;

	public ShaoLinJinGangZhang()
	{
	}

	public ShaoLinJinGangZhang(CombatSkillKey skillKey)
		: base(skillKey, 1101, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int currInnerRatio = base.SkillInstance.GetCurrInnerRatio();
		_changeInnerRatio = 0;
		_innerRatioMaxChanged = currInnerRatio == (base.IsDirect ? 100 : 0);
		if (_innerRatioMaxChanged)
		{
			ShowSpecialEffectTips(1);
		}
		CreateAffectedData(203, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(325, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && power > 0 && !_innerRatioMaxChanged)
		{
			_changeInnerRatio += 5 * power / 10 * (base.IsDirect ? 1 : (-1));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 203);
			ShowSpecialEffectTips(0);
			int currInnerRatio = base.SkillInstance.GetCurrInnerRatio();
			_innerRatioMaxChanged = currInnerRatio == (base.IsDirect ? 100 : 0);
			if (_innerRatioMaxChanged)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 203)
		{
			return _changeInnerRatio;
		}
		if (!_innerRatioMaxChanged)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 40;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 325 && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
