using System.Runtime.InteropServices;

namespace GameData.Domains.Character.TemporaryModification;

[StructLayout(LayoutKind.Explicit)]
public struct RevertibleCharacterPropertyValue
{
	[FieldOffset(0)]
	public object Object;

	[FieldOffset(8)]
	public sbyte Sbyte;

	[FieldOffset(8)]
	public byte Byte;

	[FieldOffset(8)]
	public short Short;

	[FieldOffset(8)]
	public ushort Ushort;

	[FieldOffset(8)]
	public int Int;

	[FieldOffset(8)]
	public uint Uint;

	[FieldOffset(8)]
	public long Long;

	[FieldOffset(8)]
	public ulong Ulong;

	[FieldOffset(8)]
	public MainAttributes MainAttributes;

	[FieldOffset(8)]
	public Injuries Injuries;

	[FieldOffset(8)]
	public LifeSkillShorts LifeSkills;

	[FieldOffset(8)]
	public CombatSkillShorts CombatSkills;

	[FieldOffset(8)]
	public ResourceInts Resources;

	[FieldOffset(8)]
	public PoisonInts Poisons;

	[FieldOffset(8)]
	public NeiliAllocation ExtraNeiliAllocation;
}
