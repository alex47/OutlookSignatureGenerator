using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace SignatureGeneratorProgram
{
    class SignatureGenerator
    {
        string tempDirectory = "C:/temp/";

        string signatureTemplateHtmlOriginal;
        string signatureTemplateTxtOriginal;
        string signatureTemplateRtfOriginal;

        string signatureTemplateHtml;
        string signatureTemplateTxt;
        string signatureTemplateRtf;

        // id, value
        Dictionary<string, string> signatureValues = new Dictionary<string, string>();

        public void loadSignatureTemplates(string signatureHtml, string signatureTxt, string signatureRtf, System.Drawing.Bitmap companyLogo)
        {
            signatureTemplateHtmlOriginal = signatureHtml;
            signatureTemplateTxtOriginal = signatureTxt;
            signatureTemplateRtfOriginal = signatureRtf;
            
            // Copy the company logo to a folder where the preview HTML can actually load it
            System.IO.Directory.CreateDirectory(tempDirectory);
            companyLogo.Save(tempDirectory + "image001.png");
        }

        public void exportSignature(string signatureName)
        {
            applyValues();

            string signatureOutputLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Microsoft/Signatures/";
            string signatureFilesOutputLocation = signatureOutputLocation + signatureName + "_files/";

            signatureTemplateHtml = signatureTemplateHtml.Replace("%signaturename%", signatureName + "_files/");
            signatureTemplateHtml = signatureTemplateHtml.Replace(tempDirectory, signatureName + "_files/");

            System.IO.Directory.CreateDirectory(signatureOutputLocation);
            File.WriteAllText(signatureOutputLocation + signatureName + ".htm", signatureTemplateHtml, Encoding.GetEncoding(1250));
            File.WriteAllText(signatureOutputLocation + signatureName + ".txt", signatureTemplateTxt, Encoding.GetEncoding(1250));
            File.WriteAllText(signatureOutputLocation + signatureName + ".rtf", signatureTemplateRtf, Encoding.GetEncoding(1250));

            System.IO.Directory.CreateDirectory(signatureFilesOutputLocation);
            string signatureFileList = Properties.Resources.filelist.Replace("%signaturename%", signatureName);
            File.WriteAllText(signatureFilesOutputLocation + "/filelist.xml", signatureFileList);
            File.WriteAllText(signatureFilesOutputLocation + "/colorschememapping.xml", Properties.Resources.colorschememapping);
            File.WriteAllBytes(signatureFilesOutputLocation + "/themedata.thmx", Properties.Resources.themedata);
            Properties.Resources.image001.Save(signatureFilesOutputLocation + "/image001.png");
        }

        // returns 0 if success
        // returns 1 if account not found
        // returns 2 if outlook not found
        public int updateRegistry(string signatureName, string email)
        {
            string outlookVersionString = Registry.GetValue(@"HKEY_CLASSES_ROOT\Outlook.Application\CurVer", "", "0").ToString();

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

            string[] outlookProfiles = Registry.CurrentUser.OpenSubKey(outlookProfilePath).GetSubKeyNames();

            foreach (string outlookProfile in outlookProfiles)
            {
                string outlookAccountPath =  outlookProfilePath + @"\" + outlookProfile + @"\9375CFF0413111d3B88A00104B2A6676";
                string[] outlookAccounts = Registry.CurrentUser.OpenSubKey(outlookAccountPath).GetSubKeyNames();

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

        private void applyValues()
        {
            signatureTemplateHtml = signatureTemplateHtmlOriginal;
            signatureTemplateTxt = signatureTemplateTxtOriginal;
            signatureTemplateRtf = signatureTemplateRtfOriginal;

            foreach (KeyValuePair<string, string> values in signatureValues)
            {
                signatureTemplateHtml = signatureTemplateHtml.Replace(values.Key, values.Value);
                signatureTemplateTxt = signatureTemplateTxt.Replace(values.Key, values.Value);
                signatureTemplateRtf = signatureTemplateRtf.Replace(values.Key, values.Value);
            }
        }

        public string getSignatureHtml()
        {
            applyValues();
            return signatureTemplateHtml;
        }
        
        public string signatureTempWorkingDir()
        {
            return tempDirectory;
        }
    }
}
