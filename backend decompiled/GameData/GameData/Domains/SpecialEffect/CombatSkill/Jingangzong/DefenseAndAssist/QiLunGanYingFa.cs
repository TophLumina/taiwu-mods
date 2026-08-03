using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class QiLunGanYingFa : AssistSkillBase
{
	private static readonly QiLunGanYingFaStateEffect StateEffect;

	private const sbyte ChangePowerPercentTheFirst = 100;

	private const sbyte ChangePowerPercentTheAfter = 50;

	private const sbyte StatePowerUnit = 50;

	static QiLunGanYingFa()
	{
		StateEffect = new QiLunGanYingFaStateEffect();
		SpecialEffectDomain.RegisterResetHandler(StateEffect.Reset);
	}

	public QiLunGanYingFa()
	{
	}

	public QiLunGanYingFa(CombatSkillKey skillKey)
		: base(skillKey, 11703)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		StateEffect.Setup();
	}

	public override void OnDataAdded(DataContext context)
	{
		base.OnDataAdded(context);
		if (base.IsDirect)
		{
			AppendAffectedData(context, base.CharacterId, 167, EDataModifyType.TotalPercent, -1);
		}
		else
		{
			AppendAffectedAllEnemyData(context, 167, EDataModifyType.TotalPercent, -1);
		}
	}

	public override void OnDisable(DataContext context)
	{
		StateEffect.Close();
		base.OnDisable(context);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		if (dataKey.FieldId != 167)
		{
			return 0;
		}
		if (base.IsDirect ? (dataKey.CharId != base.CharacterId) : (dataKey.CharId == base.CharacterId))
		{
			return 0;
		}
		sbyte stateType = (sbyte)dataKey.CustomParam0;
		if (stateType != (base.IsDirect ? 1 : 2))
		{
			return 0;
		}
		BoolArray8 extraParam = (byte)dataKey.CustomParam2;
		bool isReducePower = extraParam[0];
		bool isFirst = extraParam[1];
		if (isReducePower)
		{
			return 0;
		}
		int stateId = dataKey.CustomParam1;
		if ((uint)(stateId - 166) > 1u)
		{
			DataContext context = base.CombatChar.GetDataContext();
			CombatCharacter affectChar = DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId);
			DomainManager.Combat.AddCombatState(context, affectChar, stateType, (short)(base.IsDirect ? 166 : 167), 50);
			ShowEffectTips(context);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return isFirst ? 100 : 50;
	}
}
