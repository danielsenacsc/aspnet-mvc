﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioCriptografia
    {
        private static byte[] chave = {};
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };
        private static string chaveCriptografia = "CadeMeuMedico";

        public static string Criptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs;
            byte[] input;

            try
            {
                using (des = new DESCryptoServiceProvider())
                {
                    using (ms = new MemoryStream())
                    {
                        input = Encoding.UTF8.GetBytes(valor);
                        chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                        using (cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write))
                        {
                            cs.Write(input, 0, input.Length);
                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Descriptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));
                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));
                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GeraSenha()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            Random random = new Random();
            string senha = string.Empty;

            for (int i = 0; i <= 5; i++)
            {
                senha += guid.Substring(random.Next(1, guid.Length), 1);
            }

            return senha;
        }

        [Obsolete]
        public static string CriptografaSHA1(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");
        }
    }
}