using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CtrlPc_Package_CheckSum
{
    class Program
    {
        public static string _path_Package = @"E:\Visual Studio 2015\Projects\CtrlPc_Gestion_WS\AutoExtractibleServiceCtrlPc_V2";
        public static string _directory_Package_Finale = @"\Package_Final";
        public static string _path_Package_Final = _path_Package + _directory_Package_Finale;
        public static string _name_package_init = @"AutoExtractibleServiceCtrlPc.exe";
        public static string _path_package_init = _path_Package + "\\" + _name_package_init;
        static void Main(string[] args)
        {
            if (!Directory.Exists(_path_Package_Final))
            {
                Directory.CreateDirectory(_path_Package_Final);
            }
            if (Directory.Exists(_path_Package_Final))
            {
                if (File.Exists(_path_package_init))
                {
                    string md5 = Tools.CheckSum.AD_CheckSum_Tools.GetFile_CheckSum("MD5", _path_package_init);
                    string _new_Package_FullName = _path_Package_Final + "\\MEP_CTRLPC_" + md5.ToLower() + ".exe";
                    File.Copy(_path_package_init, _new_Package_FullName);
                    if (Tools.CheckSum.AD_CheckSum_Tools.IsValid_File_CheckSum(_new_Package_FullName))
                    {
                        Console.WriteLine("Package prèt pour diffusion !!!!!!!!");
                    }
                    else
                    {
                        Console.WriteLine("Package non conforme !!!!!!!!!!");
                    }
                }
            }
        }
    }
}
