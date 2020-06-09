using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Eternity
{
	// Token: 0x02000002 RID: 2
	internal class AntiDump
	{
		// Token: 0x06000006 RID: 6
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x06000007 RID: 7 RVA: 0x0000244C File Offset: 0x0000064C
		public unsafe static void Initialize()
		{
			Module module = typeof(AntiDump).Module;
			byte* ptr = (byte*)((void*)Marshal.GetHINSTANCE(module));
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + *(uint*)ptr2;
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + num2;
			byte* ptr3 = stackalloc byte[(UIntPtr)11];
			uint num5;
			if (module.FullyQualifiedName[0] == '<')
			{
				uint num3 = *(uint*)(ptr2 - 16);
				uint num4 = *(uint*)(ptr2 - 120);
				uint[] array = new uint[(int)num];
				uint[] array2 = new uint[(int)num];
				uint[] array3 = new uint[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					AntiDump.VirtualProtect(ptr2, 8, 64U, out num5);
					Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
					array[i] = *(uint*)(ptr2 + 12);
					array2[i] = *(uint*)(ptr2 + 8);
					array3[i] = *(uint*)(ptr2 + 20);
					ptr2 += 40;
				}
				if (num4 != 0U)
				{
					for (int j = 0; j < (int)num; j++)
					{
						if (array[j] <= num4 && num4 < array[j] + array2[j])
						{
							num4 = num4 - array[j] + array3[j];
							IL_164:
							byte* ptr4 = ptr + num4;
							uint num6 = *(uint*)ptr4;
							for (int k = 0; k < (int)num; k++)
							{
								if (array[k] <= num6 && num6 < array[k] + array2[k])
								{
									num6 = num6 - array[k] + array3[k];
									IL_1B3:
									byte* ptr5 = ptr + num6;
									uint num7 = *(uint*)(ptr4 + 12);
									for (int l = 0; l < (int)num; l++)
									{
										if (array[l] <= num7 && num7 < array[l] + array2[l])
										{
											num7 = num7 - array[l] + array3[l];
											IL_208:
											uint num8 = *(uint*)ptr5 + 2U;
											for (int m = 0; m < (int)num; m++)
											{
												if (array[m] <= num8 && num8 < array[m] + array2[m])
												{
													num8 = num8 - array[m] + array3[m];
													IL_256:
													AntiDump.VirtualProtect(ptr + num7, 11, 64U, out num5);
													*(int*)ptr3 = 1818522734;
													*(int*)(ptr3 + 4) = 1818504812;
													*(short*)(ptr3 + (IntPtr)4 * 2) = 108;
													ptr3[10] = 0;
													for (int n = 0; n < 11; n++)
													{
														(ptr + num7)[n] = ptr3[n];
													}
													AntiDump.VirtualProtect(ptr + num8, 11, 64U, out num5);
													*(int*)ptr3 = 1866691662;
													*(int*)(ptr3 + 4) = 1852404846;
													*(short*)(ptr3 + (IntPtr)4 * 2) = 25973;
													ptr3[10] = 0;
													for (int num9 = 0; num9 < 11; num9++)
													{
														(ptr + num8)[num9] = ptr3[num9];
													}
													goto IL_34C;
												}
											}
											goto IL_256;
										}
									}
									goto IL_208;
								}
							}
							goto IL_1B3;
						}
					}
					goto IL_164;
				}
				IL_34C:
				for (int num10 = 0; num10 < (int)num; num10++)
				{
					if (array[num10] <= num3 && num3 < array[num10] + array2[num10])
					{
						num3 = num3 - array[num10] + array3[num10];
						IL_38F:
						byte* ptr6 = ptr + num3;
						AntiDump.VirtualProtect(ptr6, 72, 64U, out num5);
						uint num11 = *(uint*)(ptr6 + 8);
						for (int num12 = 0; num12 < (int)num; num12++)
						{
							if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
							{
								num11 = num11 - array[num12] + array3[num12];
								IL_3F8:
								*(int*)ptr6 = 0;
								*(int*)(ptr6 + 4) = 0;
								*(int*)(ptr6 + (IntPtr)2 * 4) = 0;
								*(int*)(ptr6 + (IntPtr)3 * 4) = 0;
								byte* ptr7 = ptr + num11;
								AntiDump.VirtualProtect(ptr7, 4, 64U, out num5);
								*(int*)ptr7 = 0;
								ptr7 += 12;
								ptr7 += *(uint*)ptr7;
								ptr7 = (ptr7 + 7L & -4L);
								ptr7 += 2;
								ushort num13 = (ushort)(*ptr7);
								ptr7 += 2;
								for (int num14 = 0; num14 < (int)num13; num14++)
								{
									AntiDump.VirtualProtect(ptr7, 8, 64U, out num5);
									ptr7 += 4;
									ptr7 += 4;
									for (int num15 = 0; num15 < 8; num15++)
									{
										AntiDump.VirtualProtect(ptr7, 4, 64U, out num5);
										*ptr7 = 0;
										ptr7++;
										if (*ptr7 == 0)
										{
											ptr7 += 3;
											break;
										}
										*ptr7 = 0;
										ptr7++;
										if (*ptr7 == 0)
										{
											ptr7 += 2;
											break;
										}
										*ptr7 = 0;
										ptr7++;
										if (*ptr7 == 0)
										{
											ptr7++;
											break;
										}
										*ptr7 = 0;
										ptr7++;
									}
								}
								return;
							}
						}
						goto IL_3F8;
					}
				}
				goto IL_38F;
			}
			byte* ptr8 = ptr + *(uint*)(ptr2 - 16);
			if (*(uint*)(ptr2 - 120) != 0U)
			{
				byte* ptr9 = ptr + *(uint*)(ptr2 - 120);
				byte* ptr10 = ptr + *(uint*)ptr9;
				byte* ptr11 = ptr + *(uint*)(ptr9 + 12);
				byte* ptr12 = ptr + *(uint*)ptr10 + 2;
				AntiDump.VirtualProtect(ptr11, 11, 64U, out num5);
				*(int*)ptr3 = 1818522734;
				*(int*)(ptr3 + 4) = 1818504812;
				*(short*)(ptr3 + (IntPtr)4 * 2) = 108;
				ptr3[10] = 0;
				for (int num16 = 0; num16 < 11; num16++)
				{
					ptr11[num16] = ptr3[num16];
				}
				AntiDump.VirtualProtect(ptr12, 11, 64U, out num5);
				*(int*)ptr3 = 1866691662;
				*(int*)(ptr3 + 4) = 1852404846;
				*(short*)(ptr3 + (IntPtr)4 * 2) = 25973;
				ptr3[10] = 0;
				for (int num17 = 0; num17 < 11; num17++)
				{
					ptr12[num17] = ptr3[num17];
				}
			}
			for (int num18 = 0; num18 < (int)num; num18++)
			{
				AntiDump.VirtualProtect(ptr2, 8, 64U, out num5);
				Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
				ptr2 += 40;
			}
			AntiDump.VirtualProtect(ptr8, 72, 64U, out num5);
			byte* ptr13 = ptr + *(uint*)(ptr8 + 8);
			*(int*)ptr8 = 0;
			*(int*)(ptr8 + 4) = 0;
			*(int*)(ptr8 + (IntPtr)2 * 4) = 0;
			*(int*)(ptr8 + (IntPtr)3 * 4) = 0;
			AntiDump.VirtualProtect(ptr13, 4, 64U, out num5);
			*(int*)ptr13 = 0;
			ptr13 += 12;
			ptr13 += *(uint*)ptr13;
			ptr13 = (ptr13 + 7L & -4L);
			ptr13 += 2;
			ushort num19 = (ushort)(*ptr13);
			ptr13 += 2;
			for (int num20 = 0; num20 < (int)num19; num20++)
			{
				AntiDump.VirtualProtect(ptr13, 8, 64U, out num5);
				ptr13 += 4;
				ptr13 += 4;
				for (int num21 = 0; num21 < 8; num21++)
				{
					AntiDump.VirtualProtect(ptr13, 4, 64U, out num5);
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 == 0)
					{
						ptr13 += 3;
						break;
					}
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 == 0)
					{
						ptr13 += 2;
						break;
					}
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 == 0)
					{
						ptr13++;
						break;
					}
					*ptr13 = 0;
					ptr13++;
				}
			}
		}
	}
}
