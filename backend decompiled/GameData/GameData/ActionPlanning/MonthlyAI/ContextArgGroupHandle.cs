using System;
using Config;
using GameData.Domains;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.Map;

namespace GameData.ActionPlanning.MonthlyAI;

public struct ContextArgGroupHandle(IContextArgGroup argGroup)
{
	private IContextArgGroup _argGroup = argGroup;

	public short CombatSkillTemplateId => _argGroup.GetArgOfType(EPlanningParameterType.CombatSkill) ?? ((PlanningContextArg)(-1));

	public short LifeSkillTemplateId => _argGroup.GetArgOfType(EPlanningParameterType.LifeSkill) ?? ((PlanningContextArg)(-1));

	public sbyte CombatSkillType => _argGroup.GetArgOfType(EPlanningParameterType.CombatSkillType) ?? ((PlanningContextArg)(-1));

	public sbyte LifeSkillType => _argGroup.GetArgOfType(EPlanningParameterType.LifeSkillType) ?? ((PlanningContextArg)(-1));

	public sbyte PoisonType => _argGroup.GetArgOfType(EPlanningParameterType.PoisonType) ?? ((PlanningContextArg)(-1));

	public sbyte InjuryType => _argGroup.GetArgOfType(EPlanningParameterType.InjuryType) ?? ((PlanningContextArg)(-1));

	public sbyte WugType => _argGroup.GetArgOfType(EPlanningParameterType.WugType) ?? ((PlanningContextArg)(-1));

	public sbyte MainAttributeType => _argGroup.GetArgOfType(EPlanningParameterType.MainAttributeType) ?? ((PlanningContextArg)(-1));

	public sbyte ResourceType => _argGroup.GetArgOfType(EPlanningParameterType.ResourceType) ?? ((PlanningContextArg)(-1));

	public sbyte ItemType => _argGroup.GetArgOfType(EPlanningParameterType.ItemType) ?? ((PlanningContextArg)(-1));

	public short ItemTemplateId => _argGroup.GetArgOfType(EPlanningParameterType.ItemTemplate) ?? ((PlanningContextArg)(-1));

	public int ItemId => _argGroup.GetArgOfType(EPlanningParameterType.Item) ?? ((PlanningContextArg)(-1));

	public sbyte OrgTemplateId => _argGroup.GetArgOfType(EPlanningParameterType.Organization) ?? ((PlanningContextArg)(-1));

	public int TargetCharId => _argGroup.GetArgOfType(EPlanningParameterType.Character) ?? ((PlanningContextArg)(-1));

	public Location Location => _argGroup.GetArgOfType(EPlanningParameterType.MapBlock) ?? ((PlanningContextArg)Location.Invalid);

	public ushort RelationType => _argGroup.GetArgOfType(EPlanningParameterType.RelationType) ?? ((PlanningContextArg)(ushort)0);

	public int Adventure => _argGroup.GetArgOfType(EPlanningParameterType.Adventure) ?? ((PlanningContextArg)(-1));

	public sbyte BodyPartType => 0;

	public sbyte PersonalityType => _argGroup.GetArgOfType(EPlanningParameterType.PersonalityType) ?? ((PlanningContextArg)(-1));

	public int Amount => _argGroup.GetArgOfType(EPlanningParameterType.Integer) ?? ((PlanningContextArg)0);

	public int GraveId => _argGroup.GetArgOfType(EPlanningParameterType.Grave) ?? ((PlanningContextArg)(-1));

	public PlanningContextArg? this[EPlanningParameterType parameterType]
	{
		get
		{
			return _argGroup.GetArgOfType(parameterType);
		}
		set
		{
			if (value.HasValue)
			{
				_argGroup.SetArgOfType(parameterType, value.Value);
			}
			else
			{
				_argGroup.RemoveArgOfType(parameterType);
			}
		}
	}

	public bool HasArgOfType(EPlanningParameterType parameterType)
	{
		return _argGroup.GetArgOfType(parameterType).HasValue;
	}

	public string ArgToString(EPlanningParameterType parameterType, PlanningContextArg arg)
	{
		if (1 == 0)
		{
		}
		GameData.Domains.Character.Character character;
		AdventureRuntime adventure;
		AdventureMajorEvent majorEvent;
		Grave grave;
		string result = parameterType switch
		{
			EPlanningParameterType.Integer => ((int)arg).ToString(), 
			EPlanningParameterType.MainAttributeType => CharacterPropertyDisplay.Instance[0 + (sbyte)arg].Name, 
			EPlanningParameterType.InjuryType => (InjuryType == 0) ? LocalStringManager.Get(LanguageKey.LK_Out_Injury) : LocalStringManager.Get(LanguageKey.LK_Inner_Injury), 
			EPlanningParameterType.PoisonType => Poison.Instance[PoisonType].Name, 
			EPlanningParameterType.WugType => WugType.ToString(), 
			EPlanningParameterType.ResourceType => Config.ResourceType.Instance[ResourceType].Name, 
			EPlanningParameterType.ItemType => LocalStringManager.Get($"LK_ItemType_{ItemType}"), 
			EPlanningParameterType.CombatSkillType => Config.CombatSkillType.Instance[CombatSkillType].Name, 
			EPlanningParameterType.LifeSkillType => Config.LifeSkillType.Instance[LifeSkillType].Name, 
			EPlanningParameterType.RelationType => GameData.Domains.Character.Relation.RelationType.GetTypeName(RelationType), 
			EPlanningParameterType.ItemTemplate => ItemTemplateHelper.GetName(ItemType, ItemTemplateId), 
			EPlanningParameterType.Item => DomainManager.Item.TryGetBaseItem(ItemType, ItemId)?.GetItemKey().ToString(), 
			EPlanningParameterType.Character => DomainManager.Character.TryGetElement_Objects(TargetCharId, out character) ? character.ToString() : TargetCharId.ToString(), 
			EPlanningParameterType.Organization => Organization.Instance[OrgTemplateId].Name, 
			EPlanningParameterType.MapBlock => Location.ToString(), 
			EPlanningParameterType.Adventure => DomainManager.Adventure.TryGetElement_Adventures(Adventure, out adventure) ? adventure.Core.Name : (DomainManager.Adventure.TryGetElement_AdventureMajorEvents(Adventure, out majorEvent) ? majorEvent.Core.Name : Adventure.ToString()), 
			EPlanningParameterType.CombatSkill => CombatSkill.Instance[CombatSkillTemplateId].Name, 
			EPlanningParameterType.LifeSkill => LifeSkill.Instance[LifeSkillTemplateId].Name, 
			EPlanningParameterType.PersonalityType => PersonalityType.ToString(), 
			EPlanningParameterType.Grave => DomainManager.Character.TryGetElement_Graves(arg, out grave) ? grave.ToString() : GraveId.ToString(), 
			_ => throw new ArgumentOutOfRangeException("parameterType", parameterType, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
