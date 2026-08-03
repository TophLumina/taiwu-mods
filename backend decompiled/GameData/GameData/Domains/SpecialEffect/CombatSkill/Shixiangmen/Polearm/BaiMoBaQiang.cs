using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class BaiMoBaQiang : CombatSkillEffectBase
{
	private const int AddAttackRange = 20;

	private const int ChangeCdCount = int.MaxValue;

	private bool _castWithTeammate;

	private HitOrAvoidInts _addHits;

	private OuterAndInnerInts _addAttacks;

	public BaiMoBaQiang()
	{
	}

	public BaiMoBaQiang(CombatSkillKey skillKey)
		: base(skillKey, 6308, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		bool targetIsAlly = (base.IsDirect ? base.CombatChar.IsAlly : (!base.CombatChar.IsAlly));
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(targetIsAlly);
		foreach (CombatCharacter character in DomainManager.Combat.GetCharacters(targetIsAlly))
		{
			if (mainChar != character)
			{
				_castWithTeammate = true;
				_addHits += character.GetCharacter().GetHitValues();
				_addAttacks += character.GetCharacter().GetPenetrations();
			}
		}
		if (_castWithTeammate)
		{
			ShowSpecialEffectTips(0);
			CreateAffectedData(44, EDataModifyType.Add, -1);
			CreateAffectedData(45, EDataModifyType.Add, -1);
			for (int i = 0; i < 4; i++)
			{
				CreateAffectedData((ushort)(32 + i), EDataModifyType.Add, -1);
			}
		}
		else
		{
			ShowSpecialEffectTips(2);
			CreateAffectedData(145, EDataModifyType.Add, -1);
			CreateAffectedData(146, EDataModifyType.Add, -1);
			CreateAffectedData(251, EDataModifyType.Custom, -1);
			CreateAffectedData(248, EDataModifyType.Custom, -1);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			if (PowerMatchAffectRequire(power) && _castWithTeammate)
			{
				DoChangeTeammateCommandCd(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoChangeTeammateCommandCd(DataContext context)
	{
		if (!DomainManager.Combat.IsMainCharacter(base.CombatChar))
		{
			return;
		}
		bool targetIsAlly = (base.IsDirect ? base.CombatChar.IsAlly : (!base.CombatChar.IsAlly));
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(targetIsAlly);
		List<(CombatCharacter, int)> pool = new List<(CombatCharacter, int)>();
		bool showTransferInjury = mainChar.GetShowTransferInjuryCommand();
		foreach (CombatCharacter character in DomainManager.Combat.GetCharacters(targetIsAlly))
		{
			if (mainChar == character || base.CombatChar == character)
			{
				continue;
			}
			List<sbyte> cmdTypes = character.GetCurrTeammateCommands();
			List<CountdownData> cdList = character.GetTeammateCommandCd();
			for (int i = 0; i < cmdTypes.Count; i++)
			{
				if (cmdTypes[i] >= 0 && (!showTransferInjury || i <= 0) && i != character.ExecutingTeammateCommandIndex && !(base.IsDirect ? cdList[i].Off : cdList[i].On))
				{
					pool.Add((character, i));
				}
			}
		}
		foreach (var (target, index) in RandomUtils.GetRandomUnrepeated(context.Random, int.MaxValue, pool))
		{
			ShowSpecialEffectTipsOnceInFrame(1);
			if (base.IsDirect)
			{
				target.ClearTeammateCommandCd(context, index);
			}
			else
			{
				target.ResetTeammateCommandCd(context, index);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result;
		switch (fieldId)
		{
		case 32:
			result = _addHits[0];
			break;
		case 33:
			result = _addHits[1];
			break;
		case 34:
			result = _addHits[2];
			break;
		case 35:
			result = _addHits[3];
			break;
		case 44:
			result = _addAttacks.Outer;
			break;
		case 45:
			result = _addAttacks.Inner;
			break;
		case 145:
		case 146:
			result = 20;
			break;
		default:
			result = base.GetModifyValue(dataKey, currModifyValue);
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		bool flag = dataKey.SkillKey == SkillKey;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 248 || fieldId == 251) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
