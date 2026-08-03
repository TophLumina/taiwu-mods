using System.Runtime.CompilerServices;

namespace GameData.Combat.Math;

public readonly record struct CValueModifyDelta(EDataModifyType Type, int Value)
{
	public static CValueModifyDelta Zero => default(CValueModifyDelta);

	public readonly EDataModifyType Type = Type;

	public readonly int Value = Value;

	public override string ToString()
	{
		return $"{Type}[{Value}]";
	}

	[CompilerGenerated]
	public void Deconstruct(out EDataModifyType Type, out int Value)
	{
		Type = this.Type;
		Value = this.Value;
	}
}
