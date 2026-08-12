using CompDevLib.Interpreter;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.ValueSelector;

public class ValueConverters
{
	[ValueConverter(typeof(int), typeof(GameData.Domains.Character.Character))]
	public static ValueInfo CharIdToCharacter(Evaluator evaluator, ValueInfo valueInfo)
	{
		int id = evaluator.EvaluationStack.PopUnmanaged<int>();
		DomainManager.Character.TryGetElement_Objects(id, out var character);
		return evaluator.PushEvaluationResult(character);
	}

	[ValueConverter(typeof(int), typeof(Settlement))]
	public static ValueInfo SettlementIdToSettlement(Evaluator evaluator, ValueInfo valueInfo)
	{
		int id = evaluator.EvaluationStack.PopUnmanaged<int>();
		Settlement settlement = DomainManager.Organization.GetSettlement((short)id);
		return evaluator.PushEvaluationResult(settlement);
	}

	[ValueConverter(typeof(int), typeof(MapAreaData))]
	public static ValueInfo AreaTemplateIdToMapAreaData(Evaluator evaluator, ValueInfo valueInfo)
	{
		int id = evaluator.EvaluationStack.PopUnmanaged<int>();
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId((short)id);
		MapAreaData areaData = DomainManager.Map.GetAreaByAreaId(areaId);
		return evaluator.PushEvaluationResult(areaData);
	}

	[ValueConverter(typeof(int), typeof(UnmanagedVariant<TemplateKey>))]
	public static ValueInfo UIntToTemplateKey(Evaluator evaluator, ValueInfo valueInfo)
	{
		int id = evaluator.EvaluationStack.PopUnmanaged<int>();
		if (id < 0)
		{
			return evaluator.PushEvaluationResult(new UnmanagedVariant<TemplateKey>(TemplateKey.Invalid));
		}
		TemplateKey templateKey = (TemplateKey)(uint)id;
		return evaluator.PushEvaluationResult(new UnmanagedVariant<TemplateKey>(templateKey));
	}

	[ValueConverter(typeof(Location), typeof(MapBlockData))]
	public static ValueInfo LocationToMapBlock(Evaluator evaluator, ValueInfo valueInfo)
	{
		Location location = (Location)(object)evaluator.EvaluationStack.PopObject<ISerializableGameData>();
		if (!location.IsValid())
		{
			return evaluator.PushEvaluationResult((object)null);
		}
		MapBlockData mapBlock = DomainManager.Map.GetBlock(location);
		return evaluator.PushEvaluationResult(mapBlock);
	}
}
