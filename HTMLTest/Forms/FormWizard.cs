using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Xml;

namespace SignatureGeneratorProgram
{
    public partial class FormWizard : Form
    {
        enum language
        {
            Czech,
            English,
            French,
            German,
            Hungarian,
            Italian,
            Portugal
        }

        XmlDocument plantsXml = new XmlDocument();
        SignatureGenerator signatureGenerator;

        string[] wizardPages;
        string[] selectedValues;
        int currentPageIndex;

        string nativeLegalText;
        string englishLegalText;

        string doneMessage;
        string doneMessageCaption;
        string errorMessageCaption;
        string errorMessageRequiredFields;
        string errorMessageOutlookAccount;
        string errorMessageOutlookProgram;

        string emailSuffix = "@hanonsystems.com";

        public FormWizard()
        {
            wizardPages = new string[] { "Continent", "Country", "City", "Entity"};
            selectedValues = new string[wizardPages.Length + 1];
            currentPageIndex = 0;

            InitializeComponent();

            nativeLegalText = "";
            englishLegalText = "CONFIDENTIALITY NOTICE: This e-mail message including attachments, if any, is intended only for the person or entity to which"
                + "it is addressed and may contain confidential and /or privileged material. Any unauthorized review, use, disclosure or distribution is prohibited. "
                + "If you are not the intended recipient, please contact the sender by reply e-mail and destroy all copies of the original message. "
                + "If you are the intended recipient but do not wish to receive communications through this medium, please so advise the sender immediately.";

            plantsXml.LoadXml(Properties.Resources.HanonPlants);
            signatureGenerator = new SignatureGenerator();

            signatureGenerator.loadSignatureTemplates(
                Properties.Resources.outlook_signature_template_htm,
                Properties.Resources.outlook_signature_template_txt,
                Properties.Resources.image001);

            textBoxUsername.Text = Environment.UserName.ToLower();
            webBrowserSignature.Document.Write(signatureGenerator.getSignatureHtml());
        }

        private void FormWizard_Load(object sender, EventArgs e)
        {
            addContinentButtons();
        }

        private void addContinentButtons()
        {
            XmlNodeList continentList = plantsXml.DocumentElement.SelectNodes("Plant/Continent");
            SortedSet<string> continentListUnique = new SortedSet<string>();

            foreach (XmlNode node in continentList)
            {
                continentListUnique.Add(node.InnerText);
            }

            int buttonIndex = 1;

            foreach (string continent in continentListUnique)
            {
                Button continentButton = new Button();

                continentButton.Text = continent;
                continentButton.SetBounds(9, buttonIndex * 30, 125, 23);
                continentButton.MinimumSize = new System.Drawing.Size(125, 23);
                continentButton.MaximumSize = new System.Drawing.Size(250, 23);
                continentButton.AutoSize = true;
                continentButton.Click += new System.EventHandler(this.button_Click);

                this.WizardPages.GetControl(0).Controls.Add(continentButton);

                buttonIndex++;
            }
        }

        private bool addButtonList(string selectedValue, int wizardPageIndex)
        {
            XmlNodeList nodeList = plantsXml.DocumentElement.SelectNodes("Plant");
            SortedSet<string> nodeListUnique = new SortedSet<string>();

            foreach (XmlNode node in nodeList)
            {
                if (node[wizardPages[wizardPageIndex - 1]].InnerText == selectedValue)
                {
                    nodeListUnique.Add(node[wizardPages[wizardPageIndex]].InnerText);
                }
            }

            List<Button> buttons = new List<Button>();

            foreach (string uniqueNode in nodeListUnique)
            {
                buttons.Add(new Button());

                buttons[buttons.Count - 1].Text = uniqueNode;
                buttons[buttons.Count - 1].SetBounds(9, buttons.Count * 30, 125, 23);
                buttons[buttons.Count - 1].MinimumSize = new System.Drawing.Size(125, 23);
                buttons[buttons.Count - 1].MaximumSize = new System.Drawing.Size(250, 23);
                buttons[buttons.Count - 1].AutoSize = true;
                buttons[buttons.Count - 1].Click += new System.EventHandler(this.button_Click);

                this.WizardPages.GetControl(wizardPageIndex).Controls.Add(buttons[buttons.Count - 1]);
            }

            // Set the same size for each button
            int maxWidth = 0;

            foreach (Button button in buttons)
            {
                if (button.Width > maxWidth)
                {
                    maxWidth = button.Width;
                }
            }

            foreach (Button button in buttons)
            {
                button.Width = maxWidth;
            }

            if (buttons.Count == 1)
            {
                selectedValues[currentPageIndex] = buttons[0].Text;
                return false;
            }

            return true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            loadPage(button.Text);
        }

        private void loadPage(string locationValue)
        {
            selectedValues[currentPageIndex] = locationValue;
            currentPageIndex++;

            if (currentPageIndex == wizardPages.Length)
            {
                loadDataSheetPage();
                return;
            }
            
            if (addButtonList(locationValue, currentPageIndex))
            {
                WizardPages.SelectTab(currentPageIndex);
            }
            else
            {
                // If there is only one choice than skip it to the next page
                loadPage(selectedValues[currentPageIndex]);
            }
        }

        private void updateHtmlPreviewPage(object sender, EventArgs e)
        {
            // Check field: CDSID
            if (textBoxUsername.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%cdsid%", "________");
            }
            else
            {
                signatureGenerator.updateSignatureValue("%cdsid%", textBoxUsername.Text);
            }

            // Check field: Name
            if (textBoxName.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%name%", "____________________");
            }
            else
            {
                signatureGenerator.updateSignatureValue("%name%", textBoxName.Text);
            }

            // Check field: Position
            if (textBoxPosition.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%position%", "__________");
            }
            else
            {
                signatureGenerator.updateSignatureValue("%position%", textBoxPosition.Text);
            }

            // Check field: Department
            if (textBoxDepartment.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%department%", " ");
            }
            else
            {
                signatureGenerator.updateSignatureValue("%department%", " | " + textBoxDepartment.Text);
            }

            // Check field: Phone
            if (textBoxPhone.TextLength == 0)
            {
                signatureGenerator.updateSignatureValue("%phone%", labelPhoneCountryCode.Text + " ________");
            }
            else
            {
                signatureGenerator.updateSignatureValue("%phone%", labelPhoneCountryCode.Text + " " + textBoxPhone.Text);
            }

            // Check field: Mobile
            if (textBoxMobile.Text.Length == 0)
            {
                // HTML
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", " ");

                // TXT
                signatureGenerator.updateSignatureValue("%mobile%", " ");
            }
            else
            {
                // HTML
                string mobilePhoneNumberText = labelPhoneCountryCode2.Text + " " + textBoxMobile.Text;
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", "<b style='mso-bidi-font-weight:normal'>M </b>" + mobilePhoneNumberText + "<o:p></o:p></span>");

                // TXT
                signatureGenerator.updateSignatureValue("%mobile%", "M " + mobilePhoneNumberText);
            }

            // Legal text

            if (nativeLegalText.Length == 0)
            {
                // HTML
                signatureGenerator.updateSignatureValue("%legaltext_html%", englishLegalText);

                // TXT
                signatureGenerator.updateSignatureValue("%legaltext_txt%", englishLegalText);
            } else
            {
                // HTML
                signatureGenerator.updateSignatureValue("%legaltext_html%", nativeLegalText + " <br> <br> " + englishLegalText);

                // TXT
                signatureGenerator.updateSignatureValue("%legaltext_txt%", nativeLegalText + Environment.NewLine + Environment.NewLine + englishLegalText);
            }

            // Correct the company logo for the preview
            signatureGenerator.updateSignatureValue("%signaturename%/image001.png", signatureGenerator.signatureTempWorkingDir() + "image001.png");

            // Update preview
            webBrowserSignature.DocumentText = signatureGenerator.getSignatureHtml();
        }
        
        private void loadDataSheetPage()
        {
            XmlNodeList plantList = plantsXml.DocumentElement.SelectNodes("Plant");

            foreach (XmlNode node in plantList)
            {
                bool nodeFound = true;

                for (int i = 0; i < wizardPages.Length; i++)
                {
                    if (node[wizardPages[i]].InnerText != selectedValues[i])
                    {
                        nodeFound = false;
                    }
                }

                if (nodeFound)
                {
                    signatureGenerator.updateSignatureValue("%entityname%", node["Entity"].InnerText);
                    signatureGenerator.updateSignatureValue("%companyaddress%", node["Address"].InnerText);

                    if (node["Language"] != null)
                    {
                        updateInterfaceLanguage(node["Language"].InnerText);
                    }
                    else
                    {
                        updateInterfaceLanguage("en");
                    }

                    if (node["NativeLegalText"] != null)
                    {
                        nativeLegalText = node["NativeLegalText"].InnerText;
                    } else
                    {
                        nativeLegalText = "";
                    }

                    labelPhoneCountryCode.Text =  "+" + node["PhoneCountryCode"].InnerText;
                    labelPhoneCountryCode2.Text = "+" + node["PhoneCountryCode"].InnerText;
                }
            }

            WizardPages.SelectTab("pageDataSheet");
            updateHtmlPreviewPage(null, null);
        }

        private void updateInterfaceLanguage(string languageId)
        {
            ResourceManager languageResource;
            languageResource = new ResourceManager("SignatureGeneratorProgram.Resources.Languages." + languageId, Assembly.GetExecutingAssembly());
            
            labelConstUsername.Text = languageResource.GetString("labelusername");
            labelConstName.Text = languageResource.GetString("labelname");
            labelConstPosition.Text = languageResource.GetString("labelposition");
            labelConstDepartment.Text = languageResource.GetString("labeldepartment");
            labelConstPhone.Text = languageResource.GetString("labelphone");
            labelConstMobile.Text = languageResource.GetString("labelmobile");
            labelConstOptional1.Text = languageResource.GetString("labeloptional");
            labelConstOptional2.Text = languageResource.GetString("labeloptional");

            textBoxName.watermark = languageResource.GetString("hintname");
            textBoxPosition.watermark = languageResource.GetString("hintposition");
            textBoxDepartment.watermark = languageResource.GetString("hintdepartment");
            textBoxPhone.watermark = languageResource.GetString("hintphone");
            textBoxMobile.watermark = languageResource.GetString("hintmobile");

            buttonExport.Text = languageResource.GetString("buttonfinish");

            doneMessage = languageResource.GetString("msgdone");
            doneMessageCaption = languageResource.GetString("msgdonecaption");
            errorMessageCaption = languageResource.GetString("msgerrorcaption");
            errorMessageRequiredFields = languageResource.GetString("msgerrorrequiredfields");
            errorMessageOutlookAccount = languageResource.GetString("msgerrornooutlookaccount");
            errorMessageOutlookProgram = languageResource.GetString("msgerrornooutlookprogram");
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (!checkFields())
            {
                return;
            }

            buttonExport.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            // Set the default signature for Outlook in the registry
            // Throw an error if we can't find the Outlook account for the specified username locally
            int registryResult = signatureGenerator.updateRegistry(textBoxUsername.Text + "_generated_signature", textBoxUsername.Text + emailSuffix);

            switch (registryResult)
            {
                case 0:
                    // Everything went correctly
                    signatureGenerator.exportSignature(textBoxUsername.Text + "_generated_signature");

                    MessageBox.Show(doneMessage, doneMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    break;

                case 1:
                    // Outlook account not found
                    MessageBox.Show(errorMessageOutlookAccount, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2:
                    // Outlook not found
                    MessageBox.Show(errorMessageOutlookProgram, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }

            buttonExport.Enabled = true;
            Cursor.Current = Cursors.Arrow;
        }

        private bool checkFields()
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

            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                requiredFieldIsEmpty = true;
                textBoxPhone.highlight();
            }

            if (requiredFieldIsEmpty)
            {
                MessageBox.Show(errorMessageRequiredFields, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        
    }
}
