using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class AddFiveElementsDamage : CombatSkillEffectBase
{
	private const sbyte DirectDamageAddPercent = 30;

	private const sbyte AddGongMadInjury = 100;

	protected sbyte RequireSelfFiveElementsType;

	protected sbyte AffectFiveElementsType;

	protected AddFiveElementsDamage()
	{
	}

	protected AddFiveElementsDamage(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 117, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.CombatSkillId >= 0 && FiveElementsEquals(dataKey, RequireSelfFiveElementsType))
		{
			sbyte selfNeiliFiveElementsType = (sbyte)NeiliType.Instance[CharObj.GetNeiliType()].FiveElements;
			if (dataKey.FieldId == 117 && selfNeiliFiveElementsType == AffectFiveElementsType)
			{
				return 100;
			}
			GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true).GetCharacter();
			sbyte enemyNeiliFiveElementsType = (sbyte)NeiliType.Instance[enemyChar.GetNeiliType()].FiveElements;
			if (dataKey.FieldId == 69 && enemyNeiliFiveElementsType == AffectFiveElementsType)
			{
				return 30;
			}
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)RequireSelfFiveElementsType;
		pCurrData++;
		*pCurrData = (byte)AffectFiveElementsType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		RequireSelfFiveElementsType = (sbyte)(*pCurrData);
		pCurrData++;
		AffectFiveElementsType = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
