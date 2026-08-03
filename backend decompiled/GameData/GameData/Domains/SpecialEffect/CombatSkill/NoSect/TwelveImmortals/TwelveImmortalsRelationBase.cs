using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Story.MainStory;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public abstract class TwelveImmortalsRelationBase : TwelveImmortalsBase
{
	private const int AddXiangshuInfectionUnit = 5;

	private int _unitValue;

	private int AddOrReduceDamageUnit => base.IsDirect ? 9 : 3;

	protected abstract ushort RelationType { get; }

	protected TwelveImmortalsRelationBase()
	{
	}

	protected TwelveImmortalsRelationBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_unitValue = (base.IsDirect ? CalcUnitValueDirect() : CalcUnitValueReverse());
		CreateAffectedData(69, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(102, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (_unitValue > 0)
		{
			ShowSpecialEffectTips(0);
			if (base.IsDirect)
			{
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (!base.IsDirect && _unitValue > 0)
		{
			CharObj.ChangeXiangshuInfection(context, _unitValue * 5);
		}
	}

	private int CalcUnitValueDirect()
	{
		int count = 0;
		foreach (GameData.Domains.Character.Character character in base.TwelveImmortalsConfig.GetImpactRangeCharacters(CharObj))
		{
			RelatedCharacters relatedCharacters = DomainManager.Character.GetRelatedCharacters(character.GetId());
			CharacterSet characters = relatedCharacters.GetCharacterSet(RelationType);
			if (characters.GetCount() > 0 && characters.GetCollection().Any(DomainManager.Character.IsCharacterAlive))
			{
				count++;
			}
		}
		return count;
	}

	private int CalcUnitValueReverse()
	{
		return DomainManager.Character.GetReversedRelatedCharIdCount(base.CharacterId, RelationType);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || _unitValue <= 0 || (!base.IsDirect && dataKey.FieldId == 102))
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return _unitValue * AddOrReduceDamageUnit;
	}
}
