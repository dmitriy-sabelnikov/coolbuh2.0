using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using Entities;
using Dbf;

namespace BLL
{
    public class ExportUST
    {
        private static string _nameUSTTable6 = "e04t06f";
        private static string _nameUSTTable7 = "e04t07f";

        //Экспорт таблицы 6 ЕСВ в dbf
        public static bool ExportUST6ToDbf(string path, List<ExportUST6> export, out string error)
        {
            error = string.Empty;
            if(path == string.Empty)
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
            string pathToTable6 = path + "\\" + _nameUSTTable6 + ".dbf";
            try
            {
                File.Delete(pathToTable6);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }

            Encoding encoding = Encoding.GetEncoding(1251);

            Stream stream = new FileStream(pathToTable6, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            List<DbfFieldDescriptor> columns = GetFieldDbfUST6();

            DbfHeader header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));

            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }

            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (ExportUST6 record in export)
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
                //3 ROWNUM
                temp = new byte[columns.Find(rec => rec.Name == "ROWNUM").Length];
                value = record.ROWNUM.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //4 UKR_GROMAD
                temp = new byte[columns.Find(rec => rec.Name == "UKR_GROMAD").Length];
                value = record.UKR_GROMAD.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //5 ST
                temp = new byte[columns.Find(rec => rec.Name == "ST").Length];
                value = record.ST.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //6 NUMIDENT
                temp = new byte[columns.Find(rec => rec.Name == "NUMIDENT").Length];
                value = record.NUMIDENT;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //7 LN
                temp = new byte[columns.Find(rec => rec.Name == "LN").Length];
                value = record.LN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //8 NM
                temp = new byte[columns.Find(rec => rec.Name == "NM").Length];
                value = record.NM;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //9 NM
                temp = new byte[columns.Find(rec => rec.Name == "FTN").Length];
                value = record.FTN;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //10 ZO
                temp = new byte[columns.Find(rec => rec.Name == "ZO").Length];
                value = record.ZO.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //11 PAY_TP
                temp = new byte[columns.Find(rec => rec.Name == "PAY_TP").Length];
                value = record.PAY_TP.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //12 PAY_TP
                temp = new byte[columns.Find(rec => rec.Name == "PAY_MNTH").Length];
                value = record.PAY_MNTH.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //13 PAY_YEAR
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
                value = record.SUM_TOTAL.ToString().Replace(',','.');
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
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();
            return true;
        }

        //Экспорт таблицы 7 ЕСВ в dbf
        public static bool ExportUST7ToDbf(string path, List<ExportUST7> export, out string error)
        {
            error = string.Empty;
            if (path == string.Empty)
            {
                error = "path == string.Empty";
                return false;
            }
            if(!Directory.Exists(path))
            {
                error = "!Directory.Exists(path)";
                return false;
            }
            if (export == null)
            {
                error = "export == null";
                return false;
            }

            string pathToTable7 = path + "\\" + _nameUSTTable7 + ".dbf";
            try
            {
                File.Delete(pathToTable7);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }
            Encoding encoding = Encoding.GetEncoding(1251);

            Stream stream = new FileStream(pathToTable7, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            List<DbfFieldDescriptor> columns = GetFieldDbfUST7();

            DbfHeader header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));

            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }

            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (ExportUST7 record in export)
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
                //3 ROWNUM
                temp = new byte[columns.Find(rec => rec.Name == "ROWNUM").Length];
                value = record.ROWNUM.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //4 UKR_GROMAD
                temp = new byte[columns.Find(rec => rec.Name == "UKR_GROMAD").Length];
                value = record.UKR_GROMAD.ToString();
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
                //9 C_PID
                temp = new byte[columns.Find(rec => rec.Name == "C_PID").Length];
                value = record.C_PID;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //10 START_DT
                temp = new byte[columns.Find(rec => rec.Name == "START_DT").Length];
                value = record.START_DT.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //11 STOP_DT
                temp = new byte[columns.Find(rec => rec.Name == "STOP_DT").Length];
                value = record.STOP_DT.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //12 DAYS
                temp = new byte[columns.Find(rec => rec.Name == "DAYS").Length];
                value = record.DAYS.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //13 HH
                temp = new byte[columns.Find(rec => rec.Name == "HH").Length];
                value = record.HH.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //14 MM
                temp = new byte[columns.Find(rec => rec.Name == "MM").Length];
                value = record.MM.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //15 NORMA
                temp = new byte[columns.Find(rec => rec.Name == "NORMA").Length];
                value = record.NORMA.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //16 NUM_NAK
                temp = new byte[columns.Find(rec => rec.Name == "NUM_NAK").Length];
                value = record.NUM_NAK;
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //17 DT_NAK
                temp = new byte[columns.Find(rec => rec.Name == "DT_NAK").Length];
                value = record.DT_NAK.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
                //18 SEAZON
                temp = new byte[columns.Find(rec => rec.Name == "SEAZON").Length];
                value = record.SEAZON.ToString();
                encoding.GetBytes(value, 0, value.Length, temp, 0);
                writer.Write(temp);
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();
            return true;
        }
        private static List<DbfFieldDescriptor> GetFieldDbfUST6()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("PERIOD_M", 'N', 2, 0),
                new DbfFieldDescriptor("PERIOD_Y", 'N', 4, 0),
                new DbfFieldDescriptor("ROWNUM", 'N', 6, 0),
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
            };
            return dbfFields;
        }
        private static List<DbfFieldDescriptor> GetFieldDbfUST7()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("PERIOD_M", 'N', 2, 0),
                new DbfFieldDescriptor("PERIOD_Y", 'N', 4, 0),
                new DbfFieldDescriptor("ROWNUM", 'N', 6, 0),
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
                new DbfFieldDescriptor("NORMA", 'N', 6, 0),
                new DbfFieldDescriptor("NUM_NAK", 'C', 8, 0),
                new DbfFieldDescriptor("DT_NAK", 'N', 8, 0),
                new DbfFieldDescriptor("SEAZON", 'N', 1, 0),
            };
            return dbfFields;
        }

        //Получить данные для экспорта таблицы 6
        public static List<ExportUST6> GetExportDataTbl6(List<USTCt> cts, List<UST6> tbl6s)
        {
            int i = 0;
            List<ExportUST6> res = (from ct in cts
                                    join tbl6 in tbl6s on ct.USTCt_Id equals tbl6.UST6_USTCt_Id
                                    select new ExportUST6
                                    {
                                        PERIOD_M = ct.USTCt_Date.Month,
                                        PERIOD_Y = ct.USTCt_Date.Year,
                                        ROWNUM = ++i,
                                        UKR_GROMAD = 1,
                                        ST = tbl6.UST6_SEX,
                                        NUMIDENT = tbl6.UST6_TIN,
                                        LN = tbl6.UST6_LName,
                                        NM = tbl6.UST6_FName,
                                        FTN = tbl6.UST6_MName,
                                        ZO = tbl6.UST6_Category_Cd,
                                        PAY_TP = tbl6.UST6_Accr_Cd,
                                        PAY_MNTH = tbl6.UST6_Month,
                                        PAY_YEAR = tbl6.UST6_Year,
                                        KD_NP = tbl6.UST6_DisabDays,
                                        KD_NZP = tbl6.UST6_NoSalDays,
                                        KD_PTV = tbl6.UST6_EmplDays,
                                        KD_VP = tbl6.UST6_VocDays,
                                        SUM_TOTAL = tbl6.UST6_TotalSm,
                                        SUM_MAX = tbl6.UST6_MaxSm,
                                        SUM_DIFF = tbl6.UST6_DiffSm,
                                        SUM_INS = tbl6.UST6_WithHeldUSTSm,
                                        SUM_NARAH = tbl6.UST6_AccrUSTSm,
                                        OTK = tbl6.UST6_WB,
                                        EXP = tbl6.UST6_SpecExp,
                                        NRC = tbl6.UST6_PWT,
                                        NRM = tbl6.UST6_NWP
                                    }).ToList();
            return res;
        }
        //Получить данные для экспорта таблицы 7
        public static List<ExportUST7> GetExportDataTbl7(List<USTCt> cts, List<UST7> tbl7s)
        {
            int i = 0;
            List<ExportUST7> res = (from ct in cts
                                    join tbl7 in tbl7s on ct.USTCt_Id equals tbl7.UST7_USTCt_Id
                                    select new ExportUST7
                                    {
                                        PERIOD_M = ct.USTCt_Date.Month,
                                        PERIOD_Y = ct.USTCt_Date.Year,
                                        ROWNUM = ++i,
                                        UKR_GROMAD = 1,
                                        NUMIDENT = tbl7.UST7_TIN,
                                        LN = tbl7.UST7_LName,
                                        NM = tbl7.UST7_FName,
                                        FTN = tbl7.UST7_MName,
                                        C_PID = tbl7.UST7_C_Pid,
                                        START_DT = tbl7.UST7_Start_Days,
                                        STOP_DT = tbl7.UST7_Stop_Days,
                                        DAYS = tbl7.UST7_Days,
                                        HH = tbl7.UST7_Hours,
                                        MM = tbl7.UST7_Minutes,
                                        NORMA = tbl7.UST7_Norm,
                                        NUM_NAK = tbl7.UST7_Ord_Num,
                                        DT_NAK = tbl7.UST7_Ord_Dat,
                                        SEAZON = tbl7.UST7_SSN
                                    }).ToList();
            return res;
        }
    }
}

