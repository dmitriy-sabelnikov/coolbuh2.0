using Dbf;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ExportUnionReport
    {
        //Экспорт таблицы 1 в dbf
        public static bool ExportUnionReportT1ToDbf(string path, List<ExportUnionReportT1> export, string fileNameDbf, out string error)
        {
            error = string.Empty;
            if (path == string.Empty)
            {
                error = "path == string.Empty";
                return false;
            }
            if (!Directory.Exists(path))
            {
                error = "!Directory.Exists(path)";
                return false;
            }
            if (export == null)
            {
                error = "export == null";
                return false;
            }
            string pathToTable = path + "\\" + fileNameDbf + ".dbf";
            try
            {
                File.Delete(pathToTable);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }

            var encoding = Encoding.GetEncoding(1251);
            var stream = new FileStream(pathToTable, FileMode.Create);
            var writer = new BinaryWriter(stream);

            var columns = GetFieldDbfUnionReportT1();
            var header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));
            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }
            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (var record in export)
            {
                // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
                writer.Write(byte.Parse("20", System.Globalization.NumberStyles.HexNumber));

                byte[] temp = null;
                string value = null;
                //1 PERIOD_M
                temp = new byte[columns.Find(rec => rec.Name == "PERIOD_M").Length];
                value = record.PERIOD_M.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //2 PERIOD_M
                temp = new byte[columns.Find(rec => rec.Name == "PERIOD_Y").Length];
                value = record.PERIOD_Y.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //3 UKR_GROMAD
                temp = new byte[columns.Find(rec => rec.Name == "UKR_GROMAD").Length];
                value = record.UKR_GROMAD.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //4 ST
                temp = new byte[columns.Find(rec => rec.Name == "ST").Length];
                value = record.ST.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //5 NUMIDENT
                temp = new byte[columns.Find(rec => rec.Name == "NUMIDENT").Length];
                value = record.NUMIDENT;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //6 LN
                temp = new byte[columns.Find(rec => rec.Name == "LN").Length];
                value = record.LN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //7 NM
                temp = new byte[columns.Find(rec => rec.Name == "NM").Length];
                value = record.NM;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //8 NM
                temp = new byte[columns.Find(rec => rec.Name == "FTN").Length];
                value = record.FTN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //9 ZO
                temp = new byte[columns.Find(rec => rec.Name == "ZO").Length];
                value = record.ZO.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //10 PAY_TP
                temp = new byte[columns.Find(rec => rec.Name == "PAY_TP").Length];
                value = record.PAY_TP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //11 PAY_TP
                temp = new byte[columns.Find(rec => rec.Name == "PAY_MNTH").Length];
                value = record.PAY_MNTH.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //12 PAY_YEAR
                temp = new byte[columns.Find(rec => rec.Name == "PAY_YEAR").Length];
                value = record.PAY_YEAR.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //13 KD_NP
                temp = new byte[columns.Find(rec => rec.Name == "KD_NP").Length];
                value = record.KD_NP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 KD_NZP
                temp = new byte[columns.Find(rec => rec.Name == "KD_NZP").Length];
                value = record.KD_NZP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 KD_PTV
                temp = new byte[columns.Find(rec => rec.Name == "KD_PTV").Length];
                value = record.KD_PTV.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 KD_VP
                temp = new byte[columns.Find(rec => rec.Name == "KD_VP").Length];
                value = record.KD_VP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //15 SUM_TOTAL
                temp = new byte[columns.Find(rec => rec.Name == "SUM_TOTAL").Length];
                value = record.SUM_TOTAL.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //16 SUM_MAX
                temp = new byte[columns.Find(rec => rec.Name == "SUM_MAX").Length];
                value = record.SUM_MAX.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //17 SUM_DIFF
                temp = new byte[columns.Find(rec => rec.Name == "SUM_DIFF").Length];
                value = record.SUM_DIFF.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //18 SUM_INS
                temp = new byte[columns.Find(rec => rec.Name == "SUM_INS").Length];
                value = record.SUM_INS.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //19 SUM_NARAH
                temp = new byte[columns.Find(rec => rec.Name == "SUM_NARAH").Length];
                value = record.SUM_NARAH.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //20 OTK
                temp = new byte[columns.Find(rec => rec.Name == "OTK").Length];
                value = record.OTK.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //21 EXP
                temp = new byte[columns.Find(rec => rec.Name == "EXP").Length];
                value = record.EXP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //22 NRC
                temp = new byte[columns.Find(rec => rec.Name == "NRC").Length];
                value = record.NRC.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //23 NRM
                temp = new byte[columns.Find(rec => rec.Name == "NRM").Length];
                value = record.NRM.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                temp = new byte[columns.Find(rec => rec.Name == "OZN").Length];
                value = record.OZN.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();

            return true;
        }

        //Экспорт таблицы 2 в dbf
        public static bool ExportUnionReportT2ToDbf(string path, List<ExportUnionReportT2> export, string fileNameDbf, out string error)
        {
            error = string.Empty;
            if (path == string.Empty)
            {
                error = "path == string.Empty";
                return false;
            }
            if (!Directory.Exists(path))
            {
                error = "!Directory.Exists(path)";
                return false;
            }
            if (export == null)
            {
                error = "export == null";
                return false;
            }
            string pathToTable = path + "\\" + fileNameDbf + ".dbf";
            try
            {
                File.Delete(pathToTable);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }

            var encoding = Encoding.GetEncoding(1251);
            var stream = new FileStream(pathToTable, FileMode.Create);
            var writer = new BinaryWriter(stream);

            var columns = GetFieldDbfUnionReportT2();
            var header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));
            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }
            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (var record in export)
            {
                writer.Write(byte.Parse("20", System.Globalization.NumberStyles.HexNumber));

                byte[] temp = null;
                string value = null;
                //1 NP
                temp = new byte[columns.Find(rec => rec.Name == "NP").Length];
                value = record.NP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //2 PERIOD
                temp = new byte[columns.Find(rec => rec.Name == "PERIOD").Length];
                value = record.PERIOD.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //3 RIK
                temp = new byte[columns.Find(rec => rec.Name == "RIK").Length];
                value = record.RIK.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //4 KOD
                temp = new byte[columns.Find(rec => rec.Name == "KOD").Length];
                value = record.KOD;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //5 TYP
                temp = new byte[columns.Find(rec => rec.Name == "TYP").Length];
                value = record.TYP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //6 TIN
                temp = new byte[columns.Find(rec => rec.Name == "TIN").Length];
                value = record.TIN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //7 S_NAR
                temp = new byte[columns.Find(rec => rec.Name == "S_NAR").Length];
                value = record.S_NAR.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //8 S_DOX
                temp = new byte[columns.Find(rec => rec.Name == "S_DOX").Length];
                value = record.S_DOX.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //9 S_TAXN 
                temp = new byte[columns.Find(rec => rec.Name == "S_TAXN").Length];
                value = record.S_TAXN.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //10 S_TAXP
                temp = new byte[columns.Find(rec => rec.Name == "S_TAXP").Length];
                value = record.S_TAXP.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //11 OZN_DOX
                temp = new byte[columns.Find(rec => rec.Name == "OZN_DOX").Length];
                value = record.OZN_DOX.ToString().Replace(',', '.');
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //12 D_PRIYN 
                temp = new byte[columns.Find(rec => rec.Name == "D_PRIYN").Length];
                value = record.D_PRIYN.ToString("yyyyMMdd");
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                ////13 D_ZVILN  
                temp = new byte[columns.Find(rec => rec.Name == "D_ZVILN").Length];
                value = record.D_ZVILN.ToString("yyyyMMdd");
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 OZN_PILG 
                temp = new byte[columns.Find(rec => rec.Name == "OZN_PILG").Length];
                value = record.OZN_PILG.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //15 OZNAKA
                temp = new byte[columns.Find(rec => rec.Name == "OZNAKA").Length];
                value = record.OZNAKA.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //16 A051
                temp = new byte[columns.Find(rec => rec.Name == "A051").Length];
                value = record.A051.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //17 A05
                temp = new byte[columns.Find(rec => rec.Name == "A05").Length];
                value = record.A05.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();

            return true;
        }

        //Экспорт таблицы 4 в dbf
        public static bool ExportUnionReportT4ToDbf(string path, List<ExportUnionReportT4> export, string fileNameDbf, out string error)
        {
            error = string.Empty;
            if (path == string.Empty)
            {
                error = "path == string.Empty";
                return false;
            }
            if (!Directory.Exists(path))
            {
                error = "!Directory.Exists(path)";
                return false;
            }
            if (export == null)
            {
                error = "export == null";
                return false;
            }
            string pathToTable = path + "\\" + fileNameDbf + ".dbf";
            try
            {
                File.Delete(pathToTable);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }

            var encoding = Encoding.GetEncoding(1251);
            var stream = new FileStream(pathToTable, FileMode.Create);
            var writer = new BinaryWriter(stream);

            var columns = GetFieldDbfUnionReportT4();
            var header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));
            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }
            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (var record in export)
            {
                // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
                writer.Write(byte.Parse("20", System.Globalization.NumberStyles.HexNumber));

                byte[] temp = null;
                string value = null;
                //1 PERIOD_M
                temp = new byte[columns.Find(rec => rec.Name == "PERIOD_M").Length];
                value = record.PERIOD_M.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //2 PERIOD_M
                temp = new byte[columns.Find(rec => rec.Name == "PERIOD_Y").Length];
                value = record.PERIOD_Y.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //3 UKR_GROMAD
                temp = new byte[columns.Find(rec => rec.Name == "UKR_GROMAD").Length];
                value = record.UKR_GROMAD.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //4 NUMIDENT
                temp = new byte[columns.Find(rec => rec.Name == "NUMIDENT").Length];
                value = record.NUMIDENT;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //5 LN
                temp = new byte[columns.Find(rec => rec.Name == "LN").Length];
                value = record.LN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //6 NM
                temp = new byte[columns.Find(rec => rec.Name == "NM").Length];
                value = record.NM;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //7 FTN
                temp = new byte[columns.Find(rec => rec.Name == "FTN").Length];
                value = record.FTN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //8 C_PID
                temp = new byte[columns.Find(rec => rec.Name == "C_PID").Length];
                value = record.C_PID;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //9 START_DT
                temp = new byte[columns.Find(rec => rec.Name == "START_DT").Length];
                value = record.START_DT.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //10 STOP_DT
                temp = new byte[columns.Find(rec => rec.Name == "STOP_DT").Length];
                value = record.STOP_DT.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //11 DAYS
                temp = new byte[columns.Find(rec => rec.Name == "DAYS").Length];
                value = record.DAYS.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //12 HH
                temp = new byte[columns.Find(rec => rec.Name == "HH").Length];
                value = record.HH.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //13 MM
                temp = new byte[columns.Find(rec => rec.Name == "MM").Length];
                value = record.MM.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 NORMA_1
                temp = new byte[columns.Find(rec => rec.Name == "NORMA_1").Length];
                value = record.NORMA_1.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //15 NORMA_2
                temp = new byte[columns.Find(rec => rec.Name == "NORMA_2").Length];
                value = record.NORMA_2.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //16 NORMA_3
                temp = new byte[columns.Find(rec => rec.Name == "NORMA_3").Length];
                value = record.NORMA_3.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //17 NUM_NAK
                temp = new byte[columns.Find(rec => rec.Name == "NUM_NAK").Length];
                value = record.NUM_NAK;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //18 DT_NAK
                temp = new byte[columns.Find(rec => rec.Name == "DT_NAK").Length];
                value = record.DT_NAK.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //19 SEAZON
                temp = new byte[columns.Find(rec => rec.Name == "SEAZON").Length];
                value = record.SEAZON.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //20 OZN
                temp = new byte[columns.Find(rec => rec.Name == "OZN").Length];
                value = record.OZN.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();

            return true;
        }

        //Получить данные для экспорта таблицы 1
        public static List<ExportUnionReportT1> GetExportUnionReportT1(List<UnionReportT1> unionReportT1s)
        {
            var result = new List<ExportUnionReportT1>();
            foreach (var t1 in unionReportT1s)
            {
                result.Add(new ExportUnionReportT1
                {
                    PERIOD_M = t1.UnionReportT1_Date.Month,
                    PERIOD_Y = t1.UnionReportT1_Date.Year,
                    UKR_GROMAD = 1,
                    ST = t1.UnionReportT1_SEX,
                    NUMIDENT = t1.UnionReportT1_TIN,
                    LN = t1.UnionReportT1_LName,
                    NM = t1.UnionReportT1_FName,
                    FTN = t1.UnionReportT1_MName,
                    ZO = t1.UnionReportT1_Category_Cd,
                    PAY_TP = t1.UnionReportT1_Accr_Cd,
                    PAY_MNTH = t1.UnionReportT1_Month,
                    PAY_YEAR = t1.UnionReportT1_Year,
                    KD_NP = t1.UnionReportT1_DisabDays,
                    KD_NZP = t1.UnionReportT1_NoSalDays,
                    KD_PTV = t1.UnionReportT1_EmplDays,
                    KD_VP = t1.UnionReportT1_VocDays,
                    SUM_TOTAL = t1.UnionReportT1_TotalSm,
                    SUM_MAX = t1.UnionReportT1_MaxSm,
                    SUM_DIFF = t1.UnionReportT1_DiffSm,
                    SUM_INS = t1.UnionReportT1_WithHeldUSTSm,
                    SUM_NARAH = t1.UnionReportT1_AccrUSTSm,
                    OTK = t1.UnionReportT1_WB,
                    EXP = t1.UnionReportT1_SpecExp,
                    NRC = t1.UnionReportT1_PWT,
                    NRM = t1.UnionReportT1_NWP
                });
            }

            return result;
        }

        //Получить данные для экспорта таблицы 2
        public static List<ExportUnionReportT2> GetExportUnionReportT2(UnionReportCt unionReportCt, List<UnionReportT2> unionReportT2s)
        {
            var result = new List<ExportUnionReportT2>();
            var np = 0; 
            foreach (var t2 in unionReportT2s)
            {
                result.Add(new ExportUnionReportT2
                {
                    NP = ++np,
                    PERIOD = unionReportCt.UnionReportCt_Qrt,
                    RIK = unionReportCt.UnionReportCt_Year,
                    KOD = t2.UnionReportT2_USREOU,
                    TYP = t2.UnionReportT2_Type,
                    TIN = t2.UnionReportT2_TIN,
                    S_NAR = t2.UnionReportT2_AccrIncSm,
                    S_DOX = t2.UnionReportT2_PaidIncSm,
                    S_TAXN = t2.UnionReportT2_AccrTaxSm,
                    S_TAXP = t2.UnionReportT2_TransfTaxSm,
                    OZN_DOX = t2.UnionReportT2_IncFlg,
                    D_PRIYN = t2.UnionReportT2_DOR,
                    D_ZVILN = t2.UnionReportT2_DOD,
                    OZN_PILG = t2.UnionReportT2_SocBenefitFlg,
                    OZNAKA = 0,
                    A051 = t2.UnionReportT2_AccrWarTaxSm,
                    A05 = t2.UnionReportT2_TransWarTaxSm
                });
            }

            return result;
        }

        //Получить данные для экспорта таблицы 4
        public static List<ExportUnionReportT4> GetExportUnionReportT4(List<UnionReportT4> unionReportT4s)
        {
            var result = new List<ExportUnionReportT4>();
            foreach (var t4 in unionReportT4s)
            {
                result.Add(new ExportUnionReportT4
                {
                    PERIOD_M = t4.UnionReportT4_Date.Month,
                    PERIOD_Y = t4.UnionReportT4_Date.Year,
                    UKR_GROMAD = 1,
                    NUMIDENT = t4.UnionReportT4_TIN,
                    LN = t4.UnionReportT4_LName,
                    NM = t4.UnionReportT4_FName,
                    FTN = t4.UnionReportT4_MName,
                    C_PID = t4.UnionReportT4_C_Pid,
                    START_DT = t4.UnionReportT4_Start_Days,
                    STOP_DT = t4.UnionReportT4_Stop_Days,
                    DAYS = t4.UnionReportT4_Days,
                    HH = t4.UnionReportT4_Hours,
                    MM = t4.UnionReportT4_Minutes,
                    NORMA_1 = t4.UnionReportT4_DaysNorm,
                    NORMA_2 = t4.UnionReportT4_HoursNorm,
                    NORMA_3 = t4.UnionReportT4_MinutesNorm,
                    NUM_NAK = t4.UnionReportT4_Ord_Num,
                    DT_NAK = t4.UnionReportT4_Ord_Dat,
                    SEAZON = t4.UnionReportT4_SSN,
                    OZN = 0
                });
            }

            return result;
        }

        #region Private methods

        private static List<DbfFieldDescriptor> GetFieldDbfUnionReportT1()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("PERIOD_M", 'N', 2, 0),
                new DbfFieldDescriptor("PERIOD_Y", 'N', 4, 0),
                new DbfFieldDescriptor("UKR_GROMAD", 'N', 1, 0),
                new DbfFieldDescriptor("ST", 'N', 1, 0),
                new DbfFieldDescriptor("NUMIDENT", 'C', 10, 0),
                new DbfFieldDescriptor("LN", 'C', 100, 0),
                new DbfFieldDescriptor("NM", 'C', 100, 0),
                new DbfFieldDescriptor("FTN", 'C', 100, 0),
                new DbfFieldDescriptor("ZO", 'N', 2, 0),
                new DbfFieldDescriptor("PAY_TP", 'N', 3, 0),
                new DbfFieldDescriptor("PAY_MNTH", 'N', 2, 0),
                new DbfFieldDescriptor("PAY_YEAR", 'N', 4, 0),
                new DbfFieldDescriptor("KD_NP", 'N', 3, 0),
                new DbfFieldDescriptor("KD_NZP", 'N', 3, 0),
                new DbfFieldDescriptor("KD_PTV", 'N', 3, 0),
                new DbfFieldDescriptor("KD_VP", 'N', 3, 0),
                new DbfFieldDescriptor("SUM_TOTAL", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("SUM_MAX", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("SUM_DIFF", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("SUM_INS", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("SUM_NARAH", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("OTK", 'N', 1, 0),
                new DbfFieldDescriptor("EXP", 'N', 1, 0),
                new DbfFieldDescriptor("NRC", 'N', 1, 0),
                new DbfFieldDescriptor("NRM", 'N', 1, 0),
                new DbfFieldDescriptor("OZN", 'N', 1, 0),
            };
            return dbfFields;
        }

        private static List<DbfFieldDescriptor> GetFieldDbfUnionReportT2()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("NP", 'N', 6, 0),
                new DbfFieldDescriptor("PERIOD", 'N', 2, 0),
                new DbfFieldDescriptor("RIK", 'N', 5, 0),
                new DbfFieldDescriptor("KOD", 'C', 10, 0),
                new DbfFieldDescriptor("TYP", 'N', 2, 0),
                new DbfFieldDescriptor("TIN", 'C', 10, 0),
                new DbfFieldDescriptor("S_NAR", 'N', 14 + 3, 2),
                new DbfFieldDescriptor("S_DOX", 'N', 14 + 3, 2),
                new DbfFieldDescriptor("S_TAXN", 'N', 14 + 3, 2),
                new DbfFieldDescriptor("S_TAXP", 'N', 14 + 3, 2),
                new DbfFieldDescriptor("OZN_DOX", 'N', 4, 0),
                new DbfFieldDescriptor("D_PRIYN", 'D', 8, 0),
                new DbfFieldDescriptor("D_ZVILN", 'D', 8, 0),
                new DbfFieldDescriptor("OZN_PILG", 'N', 3, 0),
                new DbfFieldDescriptor("OZNAKA", 'N', 2, 0),
                new DbfFieldDescriptor("A051", 'N', 14 + 3, 2),
                new DbfFieldDescriptor("A05", 'N', 14 + 3, 2)
            };
            return dbfFields;
        }

        private static List<DbfFieldDescriptor> GetFieldDbfUnionReportT4()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("PERIOD_M", 'N', 2, 0),
                new DbfFieldDescriptor("PERIOD_Y", 'N', 4, 0),
                new DbfFieldDescriptor("UKR_GROMAD", 'N', 1, 0),
                new DbfFieldDescriptor("NUMIDENT", 'C', 10, 0),
                new DbfFieldDescriptor("LN", 'C', 100, 0),
                new DbfFieldDescriptor("NM", 'C', 100, 0),
                new DbfFieldDescriptor("FTN", 'C', 100, 0),
                new DbfFieldDescriptor("C_PID", 'C', 9, 0),
                new DbfFieldDescriptor("START_DT", 'N', 2, 0),
                new DbfFieldDescriptor("STOP_DT", 'N', 2, 0),
                new DbfFieldDescriptor("DAYS", 'N', 4, 0),
                new DbfFieldDescriptor("HH", 'N', 4, 0),
                new DbfFieldDescriptor("MM", 'N', 2, 0),
                new DbfFieldDescriptor("NORMA_1", 'N', 6, 0),
                new DbfFieldDescriptor("NORMA_2", 'N', 6, 0),
                new DbfFieldDescriptor("NORMA_3", 'N', 6, 0),
                new DbfFieldDescriptor("NUM_NAK", 'C', 8, 0),
                new DbfFieldDescriptor("DT_NAK", 'N', 8, 0),
                new DbfFieldDescriptor("SEAZON", 'N', 1, 0),
                new DbfFieldDescriptor("OZN", 'N', 1, 0)
            };
            return dbfFields;
        }

        #endregion
    }
}
