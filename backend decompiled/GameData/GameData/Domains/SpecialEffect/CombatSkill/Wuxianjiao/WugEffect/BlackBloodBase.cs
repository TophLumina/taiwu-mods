using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodBase : WugEffectBase
{
	private const sbyte ChangeHealEffect = 50;

	private const int DisorderOfQiPerInjury = 200;

	protected BlackBloodBase()
	{
	}

	protected BlackBloodBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 6;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData((ushort)(base.IsGood ? 119 : 120), EDataModifyType.AddPercent, -1);
		CreateAffectedData((ushort)(base.IsGood ? 122 : 123), EDataModifyType.AddPercent, -1);
		CreateAffectedData(260, EDataModifyType.AddPercent, -1);
		if (base.IsGrown)
		{
			CreateAffectedData(268, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(127, EDataModifyType.Add, -1);
			CreateAffectedData(132, EDataModifyType.Add, -1);
		}
		if (base.CanChangeToGrown)
		{
			Events.RegisterHandler_EatingItem(OnEatingItem);
		}
		else
		{
			Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (base.CanChangeToGrown)
		{
			Events.UnRegisterHandler_EatingItem(OnEatingItem);
		}
		else
		{
			Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		base.OnDisable(context);
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		Events.RegisterHandler_HealedInjury(OnHealedInjury);
		Events.RegisterHandler_HealedPoison(OnHealedPoison);
		Events.RegisterHandler_UsedMedicine(OnUsedMedicine);
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		Events.UnRegisterHandler_HealedInjury(OnHealedInjury);
		Events.UnRegisterHandler_HealedPoison(OnHealedPoison);
		Events.UnRegisterHandler_UsedMedicine(OnUsedMedicine);
	}

	private void OnEatingItem(DataContext context, GameData.Domains.Character.Character character, ItemKey itemKey)
	{
		if (character.GetId() == base.CharacterId && itemKey.ItemType == 9 && base.CanAffect && Config.TeaWine.Instance[itemKey.TemplateId].ItemSubType == 900)
		{
			ChangeToGrown(context);
		}
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		if (base.IsElite && base.CanAffect)
		{
			int injuryCount = CharObj.GetInjuries().GetSum();
			int changeValue = injuryCount * 200;
			if (changeValue > 0)
			{
				CharObj.ChangeDisorderOfQi(context, changeValue);
				LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
				AddLifeRecord(lifeRecord.AddWugKingBlackBloodChangeDisorderOfQi);
			}
		}
	}

	private void OnHealedInjury(DataContext context, int doctorId, int patientId, bool isAlly, sbyte healMarkCount)
	{
		if (patientId == base.CharacterId)
		{
			OnAffected(context);
		}
	}

	private void OnHealedPoison(DataContext context, int doctorId, int patientId, bool isAlly, sbyte healMarkCount)
	{
		if (patientId == base.CharacterId)
		{
			OnAffected(context);
		}
	}

	private void OnUsedMedicine(DataContext context, int charId, ItemKey itemKey)
	{
		if (charId == base.CharacterId && itemKey.ItemType == 8)
		{
			EMedicineEffectType instantEffectType = Config.Medicine.Instance[itemKey.TemplateId].EffectType;
			if ((instantEffectType != EMedicineEffectType.Invalid && (uint)(instantEffectType - 5) > 1u) || 1 == 0)
			{
				OnAffected(context);
			}
		}
	}

	private void OnAffected(DataContext context)
	{
		if (base.CanAffect)
		{
			ShowEffectTips(context, 1);
			CostWugInCombat(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int num;
		switch (fieldId)
		{
		case 119:
		case 122:
			num = 50;
			break;
		case 120:
		case 123:
			num = -50;
			break;
		case 260:
			num = (base.IsGood ? 50 : (-50));
			break;
		case 127:
		case 132:
			num = (base.IsElite ? ((!base.IsGood) ? 1 : (-1)) : 0);
			break;
		default:
			num = 0;
			break;
		}
		if (1 == 0)
		{
		}
		int returnValue = num;
		ushort fieldId2 = dataKey.FieldId;
		bool flag = ((fieldId2 == 127 || fieldId2 == 132) ? true : false);
		if (flag && returnValue != 0)
		{
			ShowEffectTips(DomainManager.Combat.Context, 2);
		}
		return returnValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId != 268 && dataValue;
		if (1 == 0)
		{
		}
		return result;
	}
}
