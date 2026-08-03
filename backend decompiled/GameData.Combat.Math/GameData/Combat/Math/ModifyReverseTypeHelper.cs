namespace GameData.Combat.Math;

public static class ModifyReverseTypeHelper
{
	public static int Apply(this EDataReverseType reverseType, int value)
	{
		return reverseType switch
		{
			EDataReverseType.AddToReduce => (value > 0) ? (-value) : value, 
			EDataReverseType.ReduceToAdd => (value < 0) ? (-value) : value, 
			_ => value, 
		};
	}

	public static (int add, int reduce) Apply(this EDataReverseType reverseType, int add, int reduce)
	{
		return reverseType switch
		{
			EDataReverseType.AddToReduce => (add: 0, reduce: reduce - add), 
			EDataReverseType.ReduceToAdd => (add: add - reduce, reduce: 0), 
			_ => (add: add, reduce: reduce), 
		};
	}
}
