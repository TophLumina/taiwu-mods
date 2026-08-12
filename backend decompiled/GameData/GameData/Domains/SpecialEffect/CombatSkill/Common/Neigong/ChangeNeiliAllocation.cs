using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class ChangeNeiliAllocation : CombatSkillEffectBase
{
	private const sbyte AddValue = 60;

	private const sbyte ReduceValue = -30;

	private const sbyte DirectChangeAddPercent = 60;

	private const sbyte DirectChangeCostPercent = -30;

	private const sbyte ReverseChangeAddPercent = -30;

	private const sbyte ReverseChangeCostPercent = 60;

	protected byte AffectNeiliAllocationType;

	protected ChangeNeiliAllocation()
	{
	}

	protected ChangeNeiliAllocation(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (base.IsDirect)
		{
			AppendAffectedData(context, base.CharacterId, 135, EDataModifyType.AddPercent, -1);
			AppendAffectedData(context, base.CharacterId, 136, EDataModifyType.AddPercent, -1);
		}
		else
		{
			AppendAffectedAllEnemyData(context, 135, EDataModifyType.AddPercent, -1);
			AppendAffectedAllEnemyData(context, 136, EDataModifyType.AddPercent, -1);
		}
		DoChangeNeiliAllocation(context);
		if (base.IsCurrent)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void DoChangeNeiliAllocation(DataContext context)
	{
		if (base.IsDirect)
		{
			base.CombatChar.ChangeNeiliAllocation(context, AffectNeiliAllocationType, 60, applySpecialEffect: false, raiseEvent: true, applyChallengeModeQiDisorder: false);
		}
		else
		{
			if (!base.IsCurrent)
			{
				return;
			}
			foreach (CombatCharacter enemyChar in DomainManager.Combat.GetCharacters(!base.CombatChar.IsAlly))
			{
				enemyChar.ChangeNeiliAllocation(context, AffectNeiliAllocationType, -30, applySpecialEffect: false, raiseEvent: true, applyChallengeModeQiDisorder: false);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 135) <= 1u;
		if (flag && dataKey.CustomParam0 == AffectNeiliAllocationType)
		{
			return (!base.IsDirect) ? ((dataKey.FieldId == 135) ? (-30) : 60) : ((dataKey.FieldId == 135) ? 60 : (-30));
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1 + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = AffectNeiliAllocationType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		AffectNeiliAllocationType = *pCurrData;
		return GetSubClassSerializedSize();
	}
}
