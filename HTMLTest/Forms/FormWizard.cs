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

        String clickedCountry;
        String clickedCity;
        String clickedEntity;

        List<Button> countryButtons;
        List<Button> cityButtons;
        List<Button> entityButtons;

        string doneMessage;
        string doneMessageCaption;
        string errorMessageCaption;
        string errorMessageRequiredFields;
        string errorMessageOutlookAccount;
        string errorMessageOutlookProgram;

        string emailSuffix = "@hanonsystems.com";

        public FormWizard()
        {
            InitializeComponent();

            plantsXml.LoadXml(Properties.Resources.HanonPlants);
            signatureGenerator = new SignatureGenerator();

            signatureGenerator.loadSignatureTemplates(
                Properties.Resources.outlook_signature_template_htm,
                Properties.Resources.outlook_signature_template_txt,
                Properties.Resources.outlook_signature_template_rtf,
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
            SortedSet<String> continentListUnique = new SortedSet<String>();

            foreach (XmlNode node in continentList)
            {
                continentListUnique.Add(node.InnerText);
            }

            int buttonIndex = 1;

            foreach (String continent in continentListUnique)
            {
                Button continentButton = new Button();

                continentButton.Text = continent;
                continentButton.SetBounds(9, buttonIndex * 30, 125, 23);
                continentButton.Click += new System.EventHandler(this.buttonContinent_Click);

                this.WizardPages.GetControl(0).Controls.Add(continentButton);

                buttonIndex++;
            }
        }

        private bool addCountryButtons(String selectedContinent)
        {
            XmlNodeList countryList = plantsXml.DocumentElement.SelectNodes("Plant");
            SortedSet<String> countryListUnique = new SortedSet<String>();

            foreach (XmlNode node in countryList)
            {
                if (node["Continent"].InnerText == selectedContinent)
                {
                    countryListUnique.Add(node["Country"].InnerText);
                }
            }

            countryButtons = new List<Button>();

            foreach (String country in countryListUnique)
            {
                countryButtons.Add(new Button());    

                countryButtons[countryButtons.Count - 1].Text = country;
                countryButtons[countryButtons.Count - 1].SetBounds(9, countryButtons.Count * 30, 125, 23);
                countryButtons[countryButtons.Count - 1].Click += new System.EventHandler(this.buttonCountry_Click);

                this.WizardPages.GetControl(1).Controls.Add(countryButtons[countryButtons.Count - 1]);
            }

            if (countryButtons.Count == 1)
            {
                clickedCountry = countryButtons[0].Text;
                return false;
            }

            return true;
        }

        private bool addCityButtons(String selectedCountry)
        {
            XmlNodeList cityList = plantsXml.DocumentElement.SelectNodes("Plant");
            SortedSet<String> cityListUnique = new SortedSet<String>();

            foreach (XmlNode node in cityList)
            {
                if (node["Country"].InnerText == selectedCountry)
                {
                    cityListUnique.Add(node["City"].InnerText);
                }
            }

            cityButtons = new List<Button>();

            foreach (String city in cityListUnique)
            {
                cityButtons.Add(new Button());

                cityButtons[cityButtons.Count - 1].Text = city;
                cityButtons[cityButtons.Count - 1].SetBounds(9, cityButtons.Count * 30, 125, 23);
                cityButtons[cityButtons.Count - 1].Click += new System.EventHandler(this.buttonCity_Click);

                this.WizardPages.GetControl(2).Controls.Add(cityButtons[cityButtons.Count - 1]);
            }

            if (cityButtons.Count == 1)
            {
                clickedCity = cityButtons[0].Text;
                return false;
            }

            return true;
        }

        private bool addEntityButtons(String selectedCountry)
        {
            XmlNodeList EntityList = plantsXml.DocumentElement.SelectNodes("Plant");
            SortedSet<String> EntityListUnique = new SortedSet<String>();

            foreach (XmlNode node in EntityList)
            {
                if (node["City"].InnerText == selectedCountry)
                {
                    EntityListUnique.Add(node["Entity"].InnerText);
                }
            }

            entityButtons = new List<Button>();

            foreach (String Entity in EntityListUnique)
            {
                entityButtons.Add(new Button());

                entityButtons[entityButtons.Count - 1].Text = Entity;
                entityButtons[entityButtons.Count - 1].SetBounds(9, entityButtons.Count * 30, 125, 23);
                entityButtons[entityButtons.Count - 1].AutoSize = true;
                entityButtons[entityButtons.Count - 1].Click += new System.EventHandler(this.buttonEntity_Click);

                this.WizardPages.GetControl(3).Controls.Add(entityButtons[entityButtons.Count - 1]);
            }

            if (entityButtons.Count == 1)
            {
                clickedEntity = entityButtons[0].Text;
                return false;
            }

            return true;
        }

        private void buttonContinent_Click(object sender, EventArgs e)
        {
            Button continentButton = (Button)sender;
            loadCountryPage(continentButton.Text);
        }

        private void buttonCountry_Click(object sender, EventArgs e)
        {
            Button countryButton = (Button)sender;
            loadCityPage(countryButton.Text);
        }

        private void buttonCity_Click(object sender, EventArgs e)
        {
            Button cityButton = (Button)sender;
            loadEntityPage(cityButton.Text);
        }

        private void buttonEntity_Click(object sender, EventArgs e)
        {
            Button EntityButton = (Button)sender;
            clickedEntity = EntityButton.Text;

            loadDataSheetPage();
        }

        private void updateHtmlPreviewPage(object sender, EventArgs e)
        {
            /*
            Console.WriteLine(clickedCountry);
            Console.WriteLine(clickedCity);
            Console.WriteLine(clickedEntity);
            */

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

            // Check field: Mobile HTML
            if (textBoxMobile.Text.Length == 0)
            {
                // HTML
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", " ");

                // RTF
                signatureGenerator.updateSignatureValue(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  %mobile%}", " ");

                // TXT
                signatureGenerator.updateSignatureValue("%mobile%", " ");
            }
            else
            {
                // HTML
                string mobilePhoneNumberText = labelPhoneCountryCode2.Text + " " + textBoxMobile.Text;
                signatureGenerator.updateSignatureValue("<b style='mso-bidi-font-weight:normal'>M </b>%mobile%<o:p></o:p></span>", "<b style='mso-bidi-font-weight:normal'>M </b>" + mobilePhoneNumberText + "<o:p></o:p></span>");

                // RTF
                signatureGenerator.updateSignatureValue(@"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  %mobile%}",
                    @"{\rtlch\fcs1 \af1 \ltrch\fcs0 \b\f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1 M}{\rtlch\fcs1 \af1 \ltrch\fcs0 \f1\fs18\cf24\insrsid602171 \hich\af1\dbch\af31505\loch\f1  " + mobilePhoneNumberText + @"}");

                // TXT
                signatureGenerator.updateSignatureValue("%mobile%", "M " + mobilePhoneNumberText);
            }

            /*
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
            */

            // Correct the company logo for the preview
            signatureGenerator.updateSignatureValue("%signaturename%/image001.png", signatureGenerator.signatureTempWorkingDir() + "image001.png");

            // Update preview
            webBrowserSignature.DocumentText = signatureGenerator.getSignatureHtml();
        }

        private void loadCountryPage(String continent)
        {
            // There are more countries in this continent
            if (addCountryButtons(continent))
            {
                WizardPages.SelectTab("pageCountry");
            } else
            {
                loadCityPage(clickedCountry);
            }
        }

        private void loadCityPage(String country)
        {
            clickedCountry = country;

            // There are more cities in this country
            if (addCityButtons(country))
            {
                WizardPages.SelectTab("pageCity");
            }
            else
            {
                loadEntityPage(clickedCity);
            }
        }

        private void loadEntityPage(String city)
        {
            clickedCity = city;

            // There are more entities in this city
            if (addEntityButtons(city))
            {
                WizardPages.SelectTab("pageEntity");
            }
            else
            {
                loadDataSheetPage();
            }
        }

        private void loadDataSheetPage()
        {
            updateInterfaceLanguage(language.English);

            XmlNodeList plantList = plantsXml.DocumentElement.SelectNodes("Plant");

            foreach (XmlNode node in plantList)
            {
                if (node["Country"].InnerText == clickedCountry && node["City"].InnerText == clickedCity && node["Entity"].InnerText == clickedEntity)
                {
                    signatureGenerator.updateSignatureValue("%entityname%", clickedEntity);
                    signatureGenerator.updateSignatureValue("%companyaddress%", node["Address"].InnerText);

                    labelPhoneCountryCode.Text =  "+ " + node["PhoneCountryCode"].InnerText;
                    labelPhoneCountryCode2.Text = "+ " + node["PhoneCountryCode"].InnerText;
                }
            }
            
            WizardPages.SelectTab("pageDataSheet");
            updateHtmlPreviewPage(null, null);
        }

        private void updateInterfaceLanguage(language interfaceLanguage)
        {
            ResourceManager languageResource;

            switch (interfaceLanguage)
            {
                case language.Hungarian:
                case language.English:
                default:
                    // Fallback to English
                    languageResource = new ResourceManager("SignatureGeneratorProgram.Resources.Languages.en", Assembly.GetExecutingAssembly());
                    break;
            }
            
            labelConstUsername.Text = languageResource.GetString("username");
            labelConstName.Text = languageResource.GetString("name");
            labelConstPosition.Text = languageResource.GetString("position");
            labelConstDepartment.Text = languageResource.GetString("department");
            labelConstPhone.Text = languageResource.GetString("phone");
            labelConstMobile.Text = languageResource.GetString("mobile");
            labelConstOptional1.Text = languageResource.GetString("optional");
            labelConstOptional2.Text = languageResource.GetString("optional");

            textBoxName.watermark = languageResource.GetString("hintname");
            textBoxPosition.watermark = languageResource.GetString("hintposition");
            textBoxDepartment.watermark = languageResource.GetString("hintdepartment");
            textBoxPhone.watermark = languageResource.GetString("hintphone");
            textBoxMobile.watermark = languageResource.GetString("hintmobile");

            doneMessage = languageResource.GetString("msgdone");
            doneMessageCaption = languageResource.GetString("msgdonecaption");
            errorMessageCaption = languageResource.GetString("msgerrorcaption");
            errorMessageRequiredFields = languageResource.GetString("msgerrorrequiredfields");
            errorMessageOutlookAccount = languageResource.GetString("msgerrornooutlookaccount");
            errorMessageOutlookProgram = languageResource.GetString("msgerrornooutlookprogram");
        }

        private void buttonExport_Click(object sender, EventArgs e)
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
                MessageBox.Show(errorMessageRequiredFields, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show(doneMessage, doneMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    break;

                case 1:
                    MessageBox.Show(errorMessageOutlookAccount, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2:
                    MessageBox.Show(errorMessageOutlookProgram, errorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }            
        }
    }
}
