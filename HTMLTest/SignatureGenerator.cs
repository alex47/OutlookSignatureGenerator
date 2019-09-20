using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;
//using Microsoft.Office.Interop.Word;

namespace SignatureGeneratorProgram
{
    class SignatureGenerator
    {
        string tempDirectory = Path.GetTempPath();

        string signatureTemplateHtmlOriginal;

        string signatureTemplateHtml;
        string signatureTemplateTxt;

        // id, value
        Dictionary<string, string> signatureValues = new Dictionary<string, string>();

        public void loadSignatureTemplates(string signatureHtml, string signatureTxt, System.Drawing.Bitmap companyLogo)
        {
            signatureTemplateHtmlOriginal = signatureHtml;
            signatureTemplateTxt = signatureTxt;

            // Copy the company logo to a folder where the preview HTML can load it
            System.IO.Directory.CreateDirectory(tempDirectory);
            companyLogo.Save(tempDirectory + "image001.png");
        }

        public void exportSignature(string signatureName)
        {
            applyValues(true);

            string signatureOutputLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Microsoft/Signatures/";
            string signatureFilesOutputLocation = signatureOutputLocation + signatureName + "_files/";

            System.IO.Directory.CreateDirectory(signatureFilesOutputLocation);
            string signatureFileList = Properties.Resources.filelist.Replace("%signaturename%", signatureName);
            File.WriteAllText(signatureFilesOutputLocation + "/filelist.xml", signatureFileList);
            File.WriteAllText(signatureFilesOutputLocation + "/colorschememapping.xml", Properties.Resources.colorschememapping);
            File.WriteAllBytes(signatureFilesOutputLocation + "/themedata.thmx", Properties.Resources.themedata);
            Properties.Resources.image001.Save(signatureFilesOutputLocation + "/image001.png");

            signatureTemplateHtml = signatureTemplateHtml.Replace("%signaturename%", signatureName + "_files/");
            signatureTemplateHtml = signatureTemplateHtml.Replace(tempDirectory, signatureName + "_files/");

            System.IO.Directory.CreateDirectory(signatureOutputLocation);
            File.WriteAllText(signatureOutputLocation + signatureName + ".htm", signatureTemplateHtml, Encoding.Unicode);
            File.WriteAllText(signatureOutputLocation + signatureName + ".txt", signatureTemplateTxt, Encoding.Unicode);

            // Convert from HTML to RTF using MS Office Word
            try
            {
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(signatureOutputLocation + signatureName + ".htm");

                wordDoc.SaveAs2(signatureOutputLocation + signatureName + ".rtf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, true);
                wordDoc.Close();
                wordApp.Quit();
            } finally
            {

            }
        }

        // returns 0 if success
        // returns 1 if account not found
        // returns 2 if outlook not found
        public int updateRegistry(string signatureName, string email)
        {
            string outlookVersionString = "";
            object outlookVersionObj = Registry.GetValue(@"HKEY_CLASSES_ROOT\Outlook.Application\CurVer", "", "0");

            if (outlookVersionObj != null)
            {
                outlookVersionString = outlookVersionObj.ToString();
            }

            if (String.IsNullOrEmpty(outlookVersionString))
            {
                return 2;
            }

            int outlookVersion = Convert.ToInt32(outlookVersionString.Substring(outlookVersionString.LastIndexOf(".") + 1));
            int accountFound = 1;

            string outlookProfilePath;

            // Outlook 2013 and newer
            if (outlookVersion >= 15)
            {
                outlookProfilePath = @"Software\Microsoft\Office\" + outlookVersion + @".0\Outlook\Profiles";
            }
            // Outlook 2010 and older
            else
            {
                outlookProfilePath = @"Software\Microsoft\Windows NT\CurrentVersion\Windows Messaging Subsystem\Profiles";
            }

            RegistryKey outlookProfileKeys = Registry.CurrentUser.OpenSubKey(outlookProfilePath);

            if (outlookProfileKeys == null)
            {
                return 1;
            }

            string[] outlookProfiles = outlookProfileKeys.GetSubKeyNames();

            foreach (string outlookProfile in outlookProfiles)
            {
                string outlookAccountPath =  outlookProfilePath + @"\" + outlookProfile + @"\9375CFF0413111d3B88A00104B2A6676";

                RegistryKey outlookAccountKeys = Registry.CurrentUser.OpenSubKey(outlookAccountPath);

                if (outlookAccountKeys == null)
                {
                    return 1;
                }

                string[] outlookAccounts = outlookAccountKeys.GetSubKeyNames();

                foreach (string outlookAccount in outlookAccounts)
                {
                    string outlookAccountIter = @"HKEY_CURRENT_USER\" + outlookAccountPath + @"\" + outlookAccount;
                    object emailRegistryValue = Registry.GetValue(outlookAccountIter, "Account Name", "");

                    if (emailRegistryValue != null)
                    {
                        if (emailRegistryValue.ToString().ToLower() == email)
                        {
                            Registry.SetValue(outlookAccountIter, "New Signature", signatureName, RegistryValueKind.String);
                            Registry.SetValue(outlookAccountIter, "Reply-Forward Signature", signatureName, RegistryValueKind.String);
                            Registry.SetValue(outlookAccountIter, "Reply-Forward", signatureName, RegistryValueKind.String);

                            accountFound = 0;
                            break;
                        }
                    }
                }
            }

            return accountFound;
        }

        public void updateSignatureValue(string id, string value)
        {
            signatureValues[id] = value;
        }

        private void applyValues(bool finalApply)
        {
            signatureTemplateHtml = signatureTemplateHtmlOriginal;

            foreach (KeyValuePair<string, string> values in signatureValues)
            {
                signatureTemplateHtml = signatureTemplateHtml.Replace(values.Key, values.Value);

                if (finalApply)
                {
                    signatureTemplateTxt = signatureTemplateTxt.Replace(values.Key, values.Value);
                }
            }
        }

        public string getSignatureHtml()
        {
            applyValues(false);
            return signatureTemplateHtml;
        }
        
        public string signatureTempWorkingDir()
        {
            return tempDirectory;
        }
    }
}
