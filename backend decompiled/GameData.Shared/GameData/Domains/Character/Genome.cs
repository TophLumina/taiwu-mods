using System;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

public struct Genome : ISerializableGameData
{
	private const int GenesCount = 256;

	private const int GenesBytes = 64;

	public unsafe fixed byte Genes[64];

	private const int SegmentsCount = 16;

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
