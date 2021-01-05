
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System.Data
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly ComServer
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 09 43 6F 6D 53 65 72 76 65 72 00 00 )       // ...ComServer..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 09 43 6F 6D 53 65 72 76 65 72 00 00 )       // ...ComServer..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 30 00 00 )                            //  2020..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 39 61 32 30 65 31 36 38 2D 33 63 30 66   // ..$9a20e168-3c0f
                                                                                                  2D 34 37 30 66 2D 38 61 37 31 2D 66 34 35 32 66   // -470f-8a71-f452f
                                                                                                  33 66 66 62 64 34 34 00 00 )                      // 3ffbd44..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 2E 32 01   // ,Version=v4.7.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 37 2E 32 )          // amework 4.7.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module ComServer.dll
// MVID: {CA66CDB2-AF2E-4D44-A765-68545362353E}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x053A0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit ComServer.DBComServer
       extends [mscorlib]System.Object
       implements ComServer.IFunc,
                  ComServer.IDataLayer
{
  .method public hidebysig newslot virtual final 
          instance class [System.Data]System.Data.DataTable 
          GetTable(string ConStr,
                   string Table) cil managed
  {
    // Code size       69 (0x45)
    .maxstack  2
    .locals init ([0] class [System.Data]System.Data.OleDb.OleDbConnection cn,
             [1] class [System.Data]System.Data.OleDb.OleDbCommand cmd,
             [2] class [System.Data]System.Data.OleDb.OleDbDataReader r,
             [3] class [System.Data]System.Data.DataTable dt,
             [4] class [System.Data]System.Data.DataTable V_4)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  newobj     instance void [System.Data]System.Data.OleDb.OleDbConnection::.ctor(string)
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  callvirt   instance void [System.Data]System.Data.Common.DbConnection::Open()
    IL_000e:  nop
    IL_000f:  ldstr      "SELECT * FROM "
    IL_0014:  ldarg.2
    IL_0015:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_001a:  ldloc.0
    IL_001b:  newobj     instance void [System.Data]System.Data.OleDb.OleDbCommand::.ctor(string,
                                                                                          class [System.Data]System.Data.OleDb.OleDbConnection)
    IL_0020:  stloc.1
    IL_0021:  ldloc.1
    IL_0022:  callvirt   instance class [System.Data]System.Data.OleDb.OleDbDataReader [System.Data]System.Data.OleDb.OleDbCommand::ExecuteReader()
    IL_0027:  stloc.2
    IL_0028:  newobj     instance void [System.Data]System.Data.DataTable::.ctor()
    IL_002d:  stloc.3
    IL_002e:  ldloc.3
    IL_002f:  ldloc.2
    IL_0030:  callvirt   instance void [System.Data]System.Data.DataTable::Load(class [System.Data]System.Data.IDataReader)
    IL_0035:  nop
    IL_0036:  ldloc.0
    IL_0037:  callvirt   instance void [System.Data]System.Data.Common.DbConnection::Close()
    IL_003c:  nop
    IL_003d:  ldloc.3
    IL_003e:  stloc.s    V_4
    IL_0040:  br.s       IL_0042

    IL_0042:  ldloc.s    V_4
    IL_0044:  ret
  } // end of method DBComServer::GetTable

  .method public hidebysig newslot virtual final 
          instance class [mscorlib]System.Collections.Generic.List`1<string> 
          GetTables(string ConStr,
                    string db) cil managed
  {
    // Code size       92 (0x5c)
    .maxstack  3
    .locals init ([0] class [mscorlib]System.Collections.Generic.List`1<string> ls,
             [1] class [System.Data]System.Data.OleDb.OleDbConnection cn,
             [2] class [System.Data]System.Data.OleDb.OleDbCommand cmd,
             [3] class [System.Data]System.Data.OleDb.OleDbDataReader r,
             [4] bool V_4,
             [5] class [mscorlib]System.Collections.Generic.List`1<string> V_5)
    IL_0000:  nop
    IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Clear()
    IL_000d:  nop
    IL_000e:  ldarg.1
    IL_000f:  newobj     instance void [System.Data]System.Data.OleDb.OleDbConnection::.ctor(string)
    IL_0014:  stloc.1
    IL_0015:  ldloc.1
    IL_0016:  callvirt   instance void [System.Data]System.Data.Common.DbConnection::Open()
    IL_001b:  nop
    IL_001c:  ldstr      "SELECT * FROM sys.tables"
    IL_0021:  ldloc.1
    IL_0022:  newobj     instance void [System.Data]System.Data.OleDb.OleDbCommand::.ctor(string,
                                                                                          class [System.Data]System.Data.OleDb.OleDbConnection)
    IL_0027:  stloc.2
    IL_0028:  ldloc.2
    IL_0029:  callvirt   instance class [System.Data]System.Data.OleDb.OleDbDataReader [System.Data]System.Data.OleDb.OleDbCommand::ExecuteReader()
    IL_002e:  stloc.3
    IL_002f:  br.s       IL_0041

    IL_0031:  nop
    IL_0032:  ldloc.0
    IL_0033:  ldloc.3
    IL_0034:  ldc.i4.0
    IL_0035:  callvirt   instance string [System.Data]System.Data.Common.DbDataReader::GetString(int32)
    IL_003a:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
    IL_003f:  nop
    IL_0040:  nop
    IL_0041:  ldloc.3
    IL_0042:  callvirt   instance bool [System.Data]System.Data.Common.DbDataReader::Read()
    IL_0047:  stloc.s    V_4
    IL_0049:  ldloc.s    V_4
    IL_004b:  brtrue.s   IL_0031

    IL_004d:  ldloc.1
    IL_004e:  callvirt   instance void [System.Data]System.Data.Common.DbConnection::Close()
    IL_0053:  nop
    IL_0054:  ldloc.0
    IL_0055:  stloc.s    V_5
    IL_0057:  br.s       IL_0059

    IL_0059:  ldloc.s    V_5
    IL_005b:  ret
  } // end of method DBComServer::GetTables

  .method public hidebysig newslot virtual final 
          instance float64  Hypo(float64 a,
                                 float64 b) cil managed
  {
    // Code size       42 (0x2a)
    .maxstack  3
    .locals init ([0] float64 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  ldc.r8     2.
    IL_000b:  call       float64 [mscorlib]System.Math::Pow(float64,
                                                            float64)
    IL_0010:  ldarg.2
    IL_0011:  ldc.r8     2.
    IL_001a:  call       float64 [mscorlib]System.Math::Pow(float64,
                                                            float64)
    IL_001f:  add
    IL_0020:  call       float64 [mscorlib]System.Math::Sqrt(float64)
    IL_0025:  stloc.0
    IL_0026:  br.s       IL_0028

    IL_0028:  ldloc.0
    IL_0029:  ret
  } // end of method DBComServer::Hypo

  .method public hidebysig newslot virtual final 
          instance float64  Sum(float64 a,
                                float64 b) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  2
    .locals init ([0] float64 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  add
    IL_0004:  stloc.0
    IL_0005:  br.s       IL_0007

    IL_0007:  ldloc.0
    IL_0008:  ret
  } // end of method DBComServer::Sum

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method DBComServer::.ctor

} // end of class ComServer.DBComServer

.class interface public abstract auto ansi ComServer.IDataLayer
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 46 35 33 44 44 30 44 33 2D 34 34 38 43   // ..$F53DD0D3-448C
                                                                                                  2D 34 33 43 44 2D 42 33 43 33 2D 43 31 31 35 45   // -43CD-B3C3-C115E
                                                                                                  36 45 46 42 41 43 35 00 00 )                      // 6EFBAC5..
  .method public hidebysig newslot abstract virtual 
          instance class [System.Data]System.Data.DataTable 
          GetTable(string ConStr,
                   string Table) cil managed
  {
  } // end of method IDataLayer::GetTable

  .method public hidebysig newslot abstract virtual 
          instance class [mscorlib]System.Collections.Generic.List`1<string> 
          GetTables(string ConStr,
                    string db) cil managed
  {
  } // end of method IDataLayer::GetTables

} // end of class ComServer.IDataLayer

.class interface public abstract auto ansi ComServer.IFunc
{
  .method public hidebysig newslot abstract virtual 
          instance float64  Hypo(float64 a,
                                 float64 b) cil managed
  {
  } // end of method IFunc::Hypo

  .method public hidebysig newslot abstract virtual 
          instance float64  Sum(float64 a,
                                float64 b) cil managed
  {
  } // end of method IFunc::Sum

} // end of class ComServer.IFunc


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file ComServer.res
