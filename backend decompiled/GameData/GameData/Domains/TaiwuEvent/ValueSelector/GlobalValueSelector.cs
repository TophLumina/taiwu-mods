using System.Collections.Generic;
using CompDevLib.Interpreter;
using Config;
using GameData.Domains.Map;
using GameData.Domains.Organization;

namespace GameData.Domains.TaiwuEvent.ValueSelector;

public class GlobalValueSelector : IValueSelector
{
	private readonly Dictionary<string, int> _name2IdMap;

	public GlobalValueSelector()
	{
		_name2IdMap = new Dictionary<string, int>();
		foreach (EventValueItem valueCfg in (IEnumerable<EventValueItem>)EventValue.Instance)
		{
			if (valueCfg.Type == EEventValueType.Global)
			{
				_name2IdMap.Add(valueCfg.Alias, valueCfg.TemplateId);
			}
		}
	}

	public ValueInfo SelectValue(Evaluator evaluator, string identifier)
	{
		int id;
		return _name2IdMap.TryGetValue(identifier, out id) ? SelectValue(evaluator, id) : ValueInfo.Void;
	}

	private ValueInfo SelectValue(Evaluator evaluator, int templateId)
	{
		if (1 == 0)
		{
		}
		ValueInfo result;
		switch (templateId)
		{
		case 0:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.GetTaiwuCharId());
			break;
		case 1:
			result = evaluator.PushEvaluationResult(DomainManager.World.GetCurrDate());
			break;
		case 2:
			result = evaluator.PushEvaluationResult(DomainManager.World.GetCurrMonthInYear());
			break;
		case 3:
			result = evaluator.PushEvaluationResult(DomainManager.World.GetCurrYear());
			break;
		case 4:
			result = evaluator.PushEvaluationResult(DomainManager.World.GetLeftDaysInCurrMonth());
			break;
		case 5:
			result = evaluator.PushEvaluationResult(DomainManager.World.GetXiangshuLevel());
			break;
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
			result = evaluator.PushEvaluationResult(DomainManager.Organization.GetSettlementIdByOrgTemplateId((sbyte)(templateId - 7 + 1)));
			break;
		case 22:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.TaiwuVillage);
			break;
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
			result = evaluator.PushEvaluationResult(DomainManager.Organization.GetSettlementIdByOrgTemplateId((sbyte)(templateId - 37 + 35)));
			break;
		case 46:
			result = evaluator.PushEvaluationResult(GetAreaSettlement(136).GetId());
			break;
		case 47:
			result = evaluator.PushEvaluationResult(GetAreaSettlement(135).GetId());
			break;
		case 48:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.GetTaiwu().GetValidLocation());
			break;
		case 49:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.GetTaiwuVillageLocation());
			break;
		case 50:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.GetTaiwuVillageStationLocation());
			break;
		case 52:
			result = evaluator.PushEvaluationResult(DomainManager.Taiwu.GetPastTaiwuVillageLocation());
			break;
		case 53:
			result = evaluator.PushEvaluationResult(DomainManager.Map.GetAreaBlockCollection(140).FindByTemplateId(148)?.GetLocation() ?? Location.Invalid);
			break;
		default:
			result = ValueInfo.Void;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
		static Settlement GetAreaSettlement(short areaId)
		{
			MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
			short settlementId = area.SettlementInfos[0].SettlementId;
			if (settlementId < 0)
			{
				return null;
			}
			return DomainManager.Organization.GetSettlement(settlementId);
		}
	}
}
