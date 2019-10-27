using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dbf;
using Entities;
using System.IO;

namespace BLL
{
    public class ExportDF
    {
        private static string _nameDF = "DA161501";

        //Экспорт таблицы 6 ЕСВ в dbf
        public static bool ExportDFToDbf(string path, int qrt, List<ExportDFRec> export, out string error)
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
            if(qrt <= 0)
            {
                error = "qrt <= 0";
                return false;
            }
            if (qrt > 4)
            {
                error = "qrt > 4";
                return false;
            }

            if (export == null)
            {
                error = "export == null";
                return false;
            }

            string pathToDBF = path + "\\" + _nameDF + "." + qrt;

            try
            {
                File.Delete(pathToDBF);
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }

            Encoding encoding = Encoding.GetEncoding(1251);

            Stream stream = new FileStream(pathToDBF, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            List<DbfFieldDescriptor> columns = GetFieldDbfDF();

            DbfHeader header = new DbfHeader(export.Count, columns.Count, DbfFileFormat.GetRecordLength(columns), encoding);

            writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(header));

            foreach (DbfFieldDescriptor item in columns)
            {
                writer.Write(IRI.Ket.IO.BinaryStream.StructureToByteArray(item));
            }

            //Terminator
            writer.Write(byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));

            foreach (ExportDFRec record in export)
            {
                // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
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
            }
            writer.Write(byte.Parse("1A", System.Globalization.NumberStyles.HexNumber));
            writer.Close();
            stream.Close();
            return true;
        }

        private static List<DbfFieldDescriptor> GetFieldDbfDF()
        {
            List<DbfFieldDescriptor> dbfFields = new List<DbfFieldDescriptor>()
            {
                new DbfFieldDescriptor("NP", 'N', 5, 0),
                new DbfFieldDescriptor("PERIOD", 'N', 1, 0),
                new DbfFieldDescriptor("RIK", 'N', 4, 0),
                new DbfFieldDescriptor("KOD", 'C', 10, 0),
                new DbfFieldDescriptor("TYP", 'N', 1, 0),
                new DbfFieldDescriptor("TIN", 'C', 10, 0),
                new DbfFieldDescriptor("S_NAR", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("S_DOX", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("S_TAXN", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("S_TAXP", 'N', 16 + 3, 2),
                new DbfFieldDescriptor("OZN_DOX", 'N', 3, 0),
                new DbfFieldDescriptor("D_PRIYN", 'D', 8, 0),
                new DbfFieldDescriptor("D_ZVILN", 'D', 8, 0),
                new DbfFieldDescriptor("OZN_PILG", 'N', 2, 0),
                new DbfFieldDescriptor("OZNAKA", 'N', 1, 0)
            };
            return dbfFields;
        }

        //Получить данные для экспорта 1ДФ
        public static List<ExportDFRec> GetExportDataDF(DateTime dateCt, List<DFRec> recs, List<RefAdm> adms)
        {
            int i = 0;
            int qrt = SalaryHelper.GetQrtByDate(dateCt);
            int yr = dateCt.Year;
            List<ExportDFRec> res = (from rec in recs
                                     select new ExportDFRec
                                     {
                                         NP = ++i,
                                         PERIOD = qrt,
                                         RIK = yr,
                                         KOD = SetupProgram.CmpUSREOU,
                                         TYP = rec.DFRec_Type,
                                         TIN = rec.DFRec_TIN,
                                         S_NAR = rec.DFRec_AccrIncSm,
                                         S_DOX = rec.DFRec_PaidIncSm,
                                         S_TAXN = rec.DFRec_AccrTaxSm,
                                         S_TAXP = rec.DFRec_TransfTaxSm,
                                         OZN_DOX = rec.DFRec_IncFlg,
                                         D_PRIYN = rec.DFRec_DOR,
                                         D_ZVILN = rec.DFRec_DOD,
                                         OZN_PILG = rec.DFRec_SocBenefitFlg,
                                         OZNAKA = rec.DFRec_Flg
                                     }).ToList();

            //Итоги
            ExportDFRec recResult = new ExportDFRec
            {
                NP = 99999,
                PERIOD = qrt,
                RIK = yr,
                KOD = SetupProgram.CmpUSREOU,
                TYP = 0,
                TIN = string.Empty,
                S_NAR = res.Sum(rec => rec.S_NAR),
                S_DOX = res.Sum(rec => rec.S_DOX),
                S_TAXN = res.Sum(rec => rec.S_TAXN),
                S_TAXP = res.Sum(rec => rec.S_TAXP)
            };
            //Администрация
            if (adms != null)
            {
                RefAdm admBoss = adms.FirstOrDefault(rec => rec.RefAdm_TypDol == 1);

                ExportDFRec recBoss = new ExportDFRec
                {
                    NP = 99991,
                    PERIOD = qrt,
                    RIK = yr,
                    KOD = SetupProgram.CmpUSREOU,
                    TYP = 0,
                    TIN = admBoss == null ? string.Empty : admBoss.RefAdm_TIN,
                    S_NAR = admBoss == null ? 0 : admBoss.RefAdm_Tel
                };
                res.Add(recBoss);

                RefAdm admBkr = adms.FirstOrDefault(rec => rec.RefAdm_TypDol == 2);
                ExportDFRec recBkr = new ExportDFRec
                {
                    NP = 99992,
                    PERIOD = qrt,
                    RIK = yr,
                    KOD = SetupProgram.CmpUSREOU,
                    TYP = 0,
                    TIN = admBkr == null ? string.Empty : admBoss.RefAdm_TIN,
                    S_NAR = admBkr == null ? 0 : admBoss.RefAdm_Tel
                };
                res.Add(recBkr);
            }
            res.Add(recResult);
            return res;
        }

    }
}
