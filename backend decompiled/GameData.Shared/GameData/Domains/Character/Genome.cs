using System;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 基因组
/// </summary>
/// <summary>
/// 基因组
/// </summary>
public struct Genome : ISerializableGameData
{
	/// <summary>
	/// 基因组中基因的数量
	/// </summary>
	private const int GenesCount = 256;

	/// <summary>
	/// 基因组中基因的字节数.
	/// 每个基因包含两个等位基因, 共占 2 bits.
	/// </summary>
	private const int GenesBytes = 64;

	/// <summary>
	/// 基因的数组.
	/// 从中间分开此数组, 前半段为所有基因的第一个等位基因, 后半段为第二个等位基因.
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// </summary>
	public unsafe fixed byte Genes[64];

	/// <summary>
	/// 基因组中基因段的个数
	/// </summary>
	private const int SegmentsCount = 16;

	/// <summary>
	/// 隐性等位基因的出现频率.
	/// 目前所有基因都是隐性基因, 所有隐性等位基因的出现频率都相等.
	/// </summary>
	private const int AlleleFrequencyQ = 128;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 64;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (byte* pGenes = Genes)
		{
			for (int i = 0; i < 8; i++)
			{
				((long*)pData)[i] = ((long*)pGenes)[i];
			}
		}
		return 64;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (byte* pGenes = Genes)
		{
			for (int i = 0; i < 8; i++)
			{
				((long*)pGenes)[i] = ((long*)pData)[i];
			}
		}
		return 64;
	}

	/// <summary>
	/// 随机创建基因组.
	/// 每个基因的两个等位基因, 都根据频率随机决定其显隐性.
	/// *** 此实现的隐含前提条件: 隐性等位基因的出现频率为 2 的 N 次幂, 且不超过 256 ***
	/// </summary>
	/// <returns></returns>
	public unsafe static void CreateRandom(IRandomSource randomSource, ref Genome genome)
	{
		byte* buffer = stackalloc byte[512];
		randomSource.NextBytes(new Span<byte>(buffer, 512));
		for (int i = 0; i < 64; i++)
		{
			uint currGenes = 0u;
			for (int j = 0; j < 8; j++)
			{
				uint allele = ((buffer[i * 8 + j] % 128 != 0) ? 1u : 0u);
				currGenes |= allele << j;
			}
			genome.Genes[i] = (byte)currGenes;
		}
	}

	/// <summary>
	/// 清除所有处于影响状态的隐性特征.
	/// 只清除第一个等位基因, 第二个保持不变.
	/// </summary>
	public unsafe static void EraseAffectedRecessiveTraits(ref Genome genome)
	{
		fixed (byte* pGenes = genome.Genes)
		{
			for (int i = 0; i < 4; i++)
			{
				((long*)pGenes)[i] = -1L;
			}
		}
	}

	/// <summary>
	/// 基因的遗传.
	/// 等位基因的顺序固定为先母亲后父亲, 因为就算不固定在计算上也完全和固定一样.
	/// *** 此实现的隐含前提条件: 基因片段数量为 16, 每个基因片段的一半等位基因占 2 字节 ***
	/// </summary>
	/// <param name="randomSource"></param>
	/// <param name="female"></param>
	/// <param name="male"></param>
	/// <param name="offspring"></param>
	/// <returns></returns>
	public unsafe static void Inherit(IRandomSource randomSource, ref Genome female, ref Genome male, ref Genome offspring)
	{
		uint selectionProbabilities = randomSource.NextUInt();
		fixed (byte* pFemaleGenes = female.Genes)
		{
			fixed (byte* pMaleGenes = male.Genes)
			{
				fixed (byte* pOffspringGenes = offspring.Genes)
				{
					for (int i = 0; i < 16; i++)
					{
						uint femaleSelection = (selectionProbabilities >> i * 2) & 1;
						uint num = (selectionProbabilities >> i * 2 + 1) & 1;
						ushort femaleSelectedSegment = ((femaleSelection == 0) ? ((ushort*)pFemaleGenes)[i] : ((ushort*)(pFemaleGenes + 32))[i]);
						ushort maleSelectedSegment = ((num == 0) ? ((ushort*)pMaleGenes)[i] : ((ushort*)(pMaleGenes + 32))[i]);
						((short*)pOffspringGenes)[i] = (short)femaleSelectedSegment;
						((short*)(pOffspringGenes + 32))[i] = (short)maleSelectedSegment;
					}
				}
			}
		}
	}
}
