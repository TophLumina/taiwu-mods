using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AddWug : CombatSkillEffectBase
{
	private const int AddPowerValue = 40;

	protected sbyte WugType;

	private ItemKey _usingWugKing = ItemKey.Invalid;

	protected virtual int AddWugCount => 0;

	protected AddWug()
	{
	}

	protected AddWug(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(235, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (AddWugCount > 0)
		{
			base.CombatChar.ChangeWugCount(context, AddWugCount);
		}
	}

	private void OnCombatCostNeiliConfirm(DataContext context, int charId, short skillId, short effectId)
	{
		if (SkillKey.IsMatch(charId, skillId) && effectId == base.EffectId)
		{
			ItemKey itemKey = CharObj.GetInventory().GetInventoryItemKey(8, GetWugKingTemplateId());
			if (itemKey.IsValid())
			{
				CharObj.RemoveInventoryItem(context, itemKey, 1, deleteItem: false);
				_usingWugKing = itemKey;
				InvalidateCache(context, 199);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter affectChar = (base.IsDirect ? base.CurrEnemyChar : base.CombatChar);
			if (DoAddWug(context, affectChar))
			{
				ShowSpecialEffectTips(0);
				if (base.CombatChar.IsTaiwu)
				{
					DomainManager.Global.InvokeGuidingTrigger(context, 153);
					DomainManager.Taiwu.RecordLifeSummary(context, 24);
				}
				else
				{
					DomainManager.Global.InvokeGuidingTrigger(context, 329);
				}
			}
			if (_usingWugKing.IsValid())
			{
				affectChar.AddWugIrresistibly(context, _usingWugKing);
				DomainManager.Combat.ShowWugKingEffectTips(context, base.CombatChar.GetId(), affectChar.GetId());
				_usingWugKing = ItemKey.Invalid;
			}
		}
		if (_usingWugKing.IsValid())
		{
			CharObj.AddInventoryItem(context, _usingWugKing, 1);
			_usingWugKing = ItemKey.Invalid;
		}
		InvalidateCache(context, 199);
	}

	private bool DoAddWug(DataContext context, CombatCharacter affectChar)
	{
		short power = base.SkillInstance.GetPower();
		CValuePercent powerFactor = CFormula.CalcPowerFactor(power);
		short wugTemplateId = ItemDomain.GetWugTemplateId(WugType, (sbyte)(base.IsDirect ? 2 : 0));
		short duration = Config.Medicine.Instance[wugTemplateId].Duration;
		duration = (short)Math.Clamp(duration * powerFactor, 0, 32767);
		return affectChar.AddWug(context, wugTemplateId, base.CharacterId, EWugReplaceType.CombatOnly, duration);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 199 || !_usingWugKing.IsValid())
		{
			return 0;
		}
		return 40;
	}

	public override List<CastBoostEffectDisplayData> GetModifiedValue(AffectedDataKey dataKey, List<CastBoostEffectDisplayData> dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 235 || _usingWugKing.IsValid())
		{
			return dataValue;
		}
		Inventory inventory = CharObj.GetInventory();
		int count = inventory.GetInventoryItemCount(8, GetWugKingTemplateId());
		if (count > 0)
		{
			dataValue.Add(SkillKey.GetCostWugKingData(GetWugKingTemplateId(), count));
		}
		return dataValue;
	}

	private short GetWugKingTemplateId()
	{
		foreach (WugKingItem wugKing in (IEnumerable<WugKingItem>)WugKing.Instance)
		{
			if (wugKing.WugFinger == base.SkillTemplateId)
			{
				return wugKing.WugMedicine;
			}
		}
		PredefinedLog.Show(7, Id, $"get wug king by unexpected skill {SkillKey}");
		return -1;
	}
}
