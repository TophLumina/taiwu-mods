using System.Runtime.CompilerServices;

namespace GameData.Combat.Chicken;

public readonly record struct ChickenPointInvokeResult(bool Success, EChickenTypeGroup TypeGroup = EChickenTypeGroup.None, EChickenValueGroup ValueGroup = EChickenValueGroup.None)
{
	public readonly bool Success = Success;

	public readonly EChickenTypeGroup TypeGroup = TypeGroup;

	public readonly EChickenValueGroup ValueGroup = ValueGroup;

	public static implicit operator ChickenPointInvokeResult(bool success)
	{
		return new ChickenPointInvokeResult(success);
	}

	[CompilerGenerated]
	public void Deconstruct(out bool Success, out EChickenTypeGroup TypeGroup, out EChickenValueGroup ValueGroup)
	{
		Success = this.Success;
		TypeGroup = this.TypeGroup;
		ValueGroup = this.ValueGroup;
	}
}
