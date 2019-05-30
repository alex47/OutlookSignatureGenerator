using System;
using System.Windows.Forms;

namespace SignatureGeneratorProgram
{
    public partial class SignatureGeneratorForm : Form
    {
        string finishButtonErrorMessage;
        string finishButtonErrorMessageCaption;
        string finishButtonDoneMessage;
        string finishButtonDoneMessageCaption;
        string outlookRegistryUpdateError1;
        string outlookRegistryUpdateErrorCaption1;
        string outlookRegistryUpdateError2;
        string outlookRegistryUpdateErrorCaption2;

        string emailSuffix = "@hanonsystems.com";

        bool comboBoxPhoneNumberBeginningChangedManually;

        SignatureGenerator signatureGenerator = new SignatureGenerator();

        enum displayLanguage
        {
            HUNGARIAN,
            ENGLISH
        };

        public SignatureGeneratorForm()
        {
            InitializeComponent();

            signatureGenerator.loadSignatureTemplates(
                Properties.Resources.outlook_signature_template_htm,
                Properties.Resources.outlook_signature_template_txt,
                Properties.Resources.outlook_signature_template_rtf,
                Properties.Resources.image001);

            // Focus name textbox on load
            ActiveControl = textBoxName;

            comboBoxPhoneNumberBeginning.SelectedIndex = 0;
            comboBoxMobileNumberBeginning.SelectedIndex = 1;

            comboBoxPhoneNumberBeginningChangedManually = false;

            textBoxUsername.Text = Environment.UserName.ToLower();

            setLanguage(displayLanguage.HUNGARIAN);
            //setLanguage(displayLanguage.ENGLISH);

            webBrowserSignature.Document.Write(signatureGenerator.getSignatureHtml());
        }

        private void setLanguage(displayLanguage lang)
        {
            checkBoxGreetingHungarian.Text = "Üdvözlettel";
            checkBoxGreetingEnglish.Text = "Best regards";
            checkBoxGreetingGerman.Text = "Mit freundlichen Grüssen";

            switch (lang)
            {
                case displayLanguage.ENGLISH:

                    // Labels
                    labelConstName.Text = "Name";                    
                    labelConstUsername.Text = "Username";
                    labelConstPosition.Text = "Position";
                    labelConstDepartment.Text = "Department";
                    labelConstPhone.Text = "Phone";
                    labelConstMobile.Text = "Mobile";
                    labelConstGreeting.Text = "Greeting";

                    // Hints
                    textBoxName.watermark =       "                                                          e.g., John Smith";
                    textBoxPosition.watermark =   "                                                         e.g., Accountant";
                    textBoxDepartment.watermark = "                                                              e.g., Finance";
                    textBoxPhone.watermark =      "                                        e.g., 123";
                    textBoxMobile.watermark =    "                                e.g., 1234567";

                    // Example labels
                    labelConstDepartmentHint.Text = "optional";
                    labelConstMobileHint.Text = "optional";
                    
                    // Buttons
                    buttonExport.Text = "Done";

                    // Messages
                    finishButtonErrorMessage = "Please fill out all required fields.";
                    finishButtonErrorMessageCaption = "Error";
                    finishButtonDoneMessage = "Your Outlook signature has been successfully generated.\nPlease restart Outlook.";
                    finishButtonDoneMessageCaption = "Done";
                    outlookRegistryUpdateError1 = "Please log in to Outlook and then try again.";
                    outlookRegistryUpdateErrorCaption1 = "Outlook account not found";
                    outlookRegistryUpdateError2 = "Please make sure Outlook is installed.";
                    outlookRegistryUpdateErrorCaption2 = "Outlook not found";

                    // Default greeting checkboxes
                    checkBoxGreetingHungarian.Checked = false;
                    checkBoxGreetingEnglish.Checked = true;
                    checkBoxGreetingGerman.Checked = false;

                    // Titlebar text
                    this.Text = "Outlook Signature Generator";

                    break;

                case displayLanguage.HUNGARIAN:

                    // Labels
                    labelConstName.Text = "Név";
                    labelConstUsername.Text = "Felhasználónév";
                    labelConstPosition.Text = "Beosztás";
                    labelConstDepartment.Text = "Részleg";
                    labelConstPhone.Text = "Telefon";
                    labelConstMobile.Text = "Mobil";
                    labelConstGreeting.Text = "Elköszönés";

                    // Hints
                    textBoxName.watermark =       "                                                        pl. Kovács János";
                    textBoxPosition.watermark =   "                                                                pl. Könyvelő";
                    textBoxDepartment.watermark = "                                                                 pl. Pénzügy";
                    textBoxPhone.watermark =      "                                           pl. 123";
                    textBoxMobile.watermark =     "                                   pl. 1234567";


                    // Example labels
                    labelConstDepartmentHint.Text = "nem kötelező";
                    labelConstMobileHint.Text = "nem kötelező";

                    // Buttons
                    buttonExport.Text = "Kész";

                    // Messages
                    finishButtonErrorMessage = "Kérlek töltsd ki az összes kötelező mezőt.";
                    finishButtonErrorMessageCaption = "Hiba";
                    finishButtonDoneMessage = "Az Outlook aláírásod sikeresen elkészült.\nKérlek Indítsd újra az Outlookot.";
                    finishButtonDoneMessageCaption = "Kész";
                    outlookRegistryUpdateError1 = "Kérlek jelentkezz be az Outlookba, majd próbálkozz újra.";
                    outlookRegistryUpdateErrorCaption1 = "Az Outlook fiók nem található";
                    outlookRegistryUpdateError2 = "Bizonyosodj meg róla, hogy az Outlook telepítve van.";
                    outlookRegistryUpdateErrorCaption2 = "Az Outlook nem található";

                    // Default greeting checkboxes
                    checkBoxGreetingHungarian.Checked = true;
                    checkBoxGreetingEnglish.Checked = false;
                    checkBoxGreetingGerman.Checked = false;

                    // Titlebar text
                    this.Text = "Outlook Aláírás Készítő";

                    break;

                default:
                    break;
            }
        }

        private void updateHtmlPreviewPage(object sender, EventArgs e)
        {
            // Check field: Name
            if (textBoxName.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%name%", "____________________");
            } else
            {
                signatureGenerator.updateSignatureValue("%name%", textBoxName.Text);
            }

            // Check field: CDSID
            if (textBoxUsername.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%cdsid%", "________");
            } else
            {
                signatureGenerator.updateSignatureValue("%cdsid%", textBoxUsername.Text);
            }
            
            // Check field: Position
            if (textBoxPosition.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%position%", "__________");
            } else
            {
                signatureGenerator.updateSignatureValue("%position%", textBoxPosition.Text);
            }
            
            // Check field: Department
            if (textBoxDepartment.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%department%", " ");
            } else
            {
                signatureGenerator.updateSignatureValue("%department%", " | " + textBoxDepartment.Text);
            }
            
            // Check field: Phone
            if (textBoxPhone.TextLength != 3)
            {
                signatureGenerator.updateSignatureValue("%phone%", comboBoxPhoneNumberBeginning.Text + " ___");
            } else
            {
                int parsedNumber;

                if (int.TryParse(textBoxPhone.Text, out parsedNumber) && !comboBoxPhoneNumberBeginningChangedManually)
                {
                    if (parsedNumber < 500)
                    {
                        comboBoxPhoneNumberBeginning.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxPhoneNumberBeginning.SelectedIndex = 1;
                    }
                }

                signatureGenerator.updateSignatureValue("%phone%", comboBoxPhoneNumberBeginning.Text + " " + textBoxPhone.Text);
            }
            
            // Check field: Mobile HTML
            if (textBoxMobile.Text.Length != 7)
            {
                // HTML
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", " ");
                
                // RTF
                signatureGenerator.updateSignatureValue(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  %mobile%}", " ");

                // TXT
                signatureGenerator.updateSignatureValue("%mobile%", " ");
            } else
            {
                // Format the phone number: +36 00 0000 000

                // HTML
                string mobilePhoneNumberText = "+36 " + comboBoxMobileNumberBeginning.Text + " " + textBoxMobile.Text.Substring(0, 4) + " " + textBoxMobile.Text.Substring(4, 3);
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", "<b style='mso-bidi-font-weight:normal'>M </b>" + mobilePhoneNumberText + "<o:p></o:p></span>");

                // RTF
                signatureGenerator.updateSignatureValue(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  %mobile%}",
                    @"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  " + mobilePhoneNumberText + @"}");

                // TXT
                mobilePhoneNumberText = "M +36 " + comboBoxMobileNumberBeginning.Text + " " + textBoxMobile.Text.Substring(0, 4) + " " + textBoxMobile.Text.Substring(4, 3);
                signatureGenerator.updateSignatureValue("%mobile%", mobilePhoneNumberText);
            }

            string greetingText = "";

            // Check field: Greeting
            if (checkBoxGreetingHungarian.Checked)
            {
                greetingText += checkBoxGreetingHungarian.Text;
            }
            if (checkBoxGreetingEnglish.Checked)
            {
                if (greetingText != "")
                {
                    greetingText += " / ";
                }

                greetingText += checkBoxGreetingEnglish.Text;
            }
            if (checkBoxGreetingGerman.Checked)
            {
                if (greetingText != "")
                {
                    greetingText += " / ";
                }

                greetingText += checkBoxGreetingGerman.Text;
            }

            if (greetingText != "")
            {
                greetingText += ",";
            }

            signatureGenerator.updateSignatureValue("%greeting%", greetingText);

            // Correct the company logo for the preview
            signatureGenerator.updateSignatureValue("%signaturename%/image001.png", signatureGenerator.signatureTempWorkingDir() + "image001.png");

            // Update preview
            webBrowserSignature.DocumentText = signatureGenerator.getSignatureHtml();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            bool requiredFieldIsEmpty = false;
            textBoxName.noHighlight();
            textBoxUsername.noHighlight();
            textBoxPosition.noHighlight();
            textBoxPhone.noHighlight();

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                requiredFieldIsEmpty = true;
                textBoxName.highlight();
            }

            if (string.IsNullOrEmpty(textBoxUsername.Text))
            {
                requiredFieldIsEmpty = true;
                textBoxUsername.highlight();
            }

            if (string.IsNullOrEmpty(textBoxPosition.Text))
            {
                requiredFieldIsEmpty = true;
                textBoxPosition.highlight();
            }

            if (textBoxPhone.Text.Length < 3)
            {
                requiredFieldIsEmpty = true;
                textBoxPhone.highlight();
            }

            if (requiredFieldIsEmpty)
            {
                MessageBox.Show(finishButtonErrorMessage, finishButtonErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set the default signature for Outlook in the registry
            // Throw an error if we can't find the Outlook account for the specified username locally

            int registryResult = signatureGenerator.updateRegistry(textBoxUsername.Text + "_generated_signature", textBoxUsername.Text + emailSuffix);

            switch (registryResult)
            {
                case 0:
                    // Everything went correctly
                    signatureGenerator.exportSignature(textBoxUsername.Text + "_generated_signature");

                    MessageBox.Show(finishButtonDoneMessage, finishButtonDoneMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    break;

                case 1:
                    MessageBox.Show(outlookRegistryUpdateError1, outlookRegistryUpdateErrorCaption1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2:
                    MessageBox.Show(outlookRegistryUpdateError2, outlookRegistryUpdateErrorCaption2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }

        private void ButtonLanguageEnglish_Click(object sender, EventArgs e)
        {
            setLanguage(displayLanguage.ENGLISH);
        }

        private void ButtonLanguageHungarian_Click(object sender, EventArgs e)
        {
            setLanguage(displayLanguage.HUNGARIAN);
        }

        private void ComboBoxPhoneNumberBeginning_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxPhoneNumberBeginningChangedManually = true;
            updateHtmlPreviewPage(null, null);
        }
    }
}
