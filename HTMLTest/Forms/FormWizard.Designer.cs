namespace SignatureGeneratorProgram
{
    partial class FormWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWizard));
            this.WizardPages = new SignatureGeneratorProgram.WizardPages();
            this.pageContinent = new System.Windows.Forms.TabPage();
            this.labelConstContinentHint = new System.Windows.Forms.Label();
            this.pageCountry = new System.Windows.Forms.TabPage();
            this.labelConstCountryHint = new System.Windows.Forms.Label();
            this.pageCity = new System.Windows.Forms.TabPage();
            this.labelConstCityHint = new System.Windows.Forms.Label();
            this.pageEntity = new System.Windows.Forms.TabPage();
            this.labelConstEntityHint = new System.Windows.Forms.Label();
            this.pageDataSheet = new System.Windows.Forms.TabPage();
            this.textBoxMobile = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxPhone = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxDepartment = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxPosition = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxUsername = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxName = new SignatureGeneratorProgram.TextBoxExtended();
            this.labelConstOptional2 = new System.Windows.Forms.Label();
            this.labelConstOptional1 = new System.Windows.Forms.Label();
            this.labelPhoneCountryCode2 = new System.Windows.Forms.Label();
            this.labelPhoneCountryCode = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelConstDepartment = new System.Windows.Forms.Label();
            this.labelConstPosition = new System.Windows.Forms.Label();
            this.labelConstMobile = new System.Windows.Forms.Label();
            this.labelConstUsername = new System.Windows.Forms.Label();
            this.labelConstPhone = new System.Windows.Forms.Label();
            this.labelConstName = new System.Windows.Forms.Label();
            this.webBrowserSignature = new System.Windows.Forms.WebBrowser();
            this.WizardPages.SuspendLayout();
            this.pageContinent.SuspendLayout();
            this.pageCountry.SuspendLayout();
            this.pageCity.SuspendLayout();
            this.pageEntity.SuspendLayout();
            this.pageDataSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // WizardPages
            // 
            this.WizardPages.Controls.Add(this.pageContinent);
            this.WizardPages.Controls.Add(this.pageCountry);
            this.WizardPages.Controls.Add(this.pageCity);
            this.WizardPages.Controls.Add(this.pageEntity);
            this.WizardPages.Controls.Add(this.pageDataSheet);
            this.WizardPages.Location = new System.Drawing.Point(3, 6);
            this.WizardPages.Name = "WizardPages";
            this.WizardPages.SelectedIndex = 0;
            this.WizardPages.Size = new System.Drawing.Size(776, 486);
            this.WizardPages.TabIndex = 0;
            // 
            // pageContinent
            // 
            this.pageContinent.BackColor = System.Drawing.SystemColors.Control;
            this.pageContinent.Controls.Add(this.labelConstContinentHint);
            this.pageContinent.Location = new System.Drawing.Point(4, 22);
            this.pageContinent.Name = "pageContinent";
            this.pageContinent.Padding = new System.Windows.Forms.Padding(3);
            this.pageContinent.Size = new System.Drawing.Size(768, 460);
            this.pageContinent.TabIndex = 0;
            this.pageContinent.Text = "pageContinent";
            // 
            // labelConstContinentHint
            // 
            this.labelConstContinentHint.AutoSize = true;
            this.labelConstContinentHint.Location = new System.Drawing.Point(3, 0);
            this.labelConstContinentHint.Name = "labelConstContinentHint";
            this.labelConstContinentHint.Size = new System.Drawing.Size(140, 13);
            this.labelConstContinentHint.TabIndex = 1;
            this.labelConstContinentHint.Text = "Please select your continent";
            // 
            // pageCountry
            // 
            this.pageCountry.BackColor = System.Drawing.SystemColors.Control;
            this.pageCountry.Controls.Add(this.labelConstCountryHint);
            this.pageCountry.Location = new System.Drawing.Point(4, 22);
            this.pageCountry.Name = "pageCountry";
            this.pageCountry.Size = new System.Drawing.Size(768, 460);
            this.pageCountry.TabIndex = 4;
            this.pageCountry.Text = "pageCountry";
            // 
            // labelConstCountryHint
            // 
            this.labelConstCountryHint.AutoSize = true;
            this.labelConstCountryHint.Location = new System.Drawing.Point(3, 0);
            this.labelConstCountryHint.Name = "labelConstCountryHint";
            this.labelConstCountryHint.Size = new System.Drawing.Size(131, 13);
            this.labelConstCountryHint.TabIndex = 0;
            this.labelConstCountryHint.Text = "Please select your country";
            // 
            // pageCity
            // 
            this.pageCity.BackColor = System.Drawing.SystemColors.Control;
            this.pageCity.Controls.Add(this.labelConstCityHint);
            this.pageCity.Location = new System.Drawing.Point(4, 22);
            this.pageCity.Name = "pageCity";
            this.pageCity.Size = new System.Drawing.Size(768, 460);
            this.pageCity.TabIndex = 5;
            this.pageCity.Text = "pageCity";
            // 
            // labelConstCityHint
            // 
            this.labelConstCityHint.AutoSize = true;
            this.labelConstCityHint.Location = new System.Drawing.Point(3, 0);
            this.labelConstCityHint.Name = "labelConstCityHint";
            this.labelConstCityHint.Size = new System.Drawing.Size(112, 13);
            this.labelConstCityHint.TabIndex = 1;
            this.labelConstCityHint.Text = "Please select your city";
            // 
            // pageEntity
            // 
            this.pageEntity.BackColor = System.Drawing.SystemColors.Control;
            this.pageEntity.Controls.Add(this.labelConstEntityHint);
            this.pageEntity.Location = new System.Drawing.Point(4, 22);
            this.pageEntity.Name = "pageEntity";
            this.pageEntity.Size = new System.Drawing.Size(768, 460);
            this.pageEntity.TabIndex = 7;
            this.pageEntity.Text = "pageEntity";
            // 
            // labelConstEntityHint
            // 
            this.labelConstEntityHint.AutoSize = true;
            this.labelConstEntityHint.Location = new System.Drawing.Point(3, 0);
            this.labelConstEntityHint.Name = "labelConstEntityHint";
            this.labelConstEntityHint.Size = new System.Drawing.Size(146, 13);
            this.labelConstEntityHint.TabIndex = 2;
            this.labelConstEntityHint.Text = "Please select your legal entity";
            // 
            // pageDataSheet
            // 
            this.pageDataSheet.BackColor = System.Drawing.SystemColors.Control;
            this.pageDataSheet.Controls.Add(this.textBoxMobile);
            this.pageDataSheet.Controls.Add(this.textBoxPhone);
            this.pageDataSheet.Controls.Add(this.textBoxDepartment);
            this.pageDataSheet.Controls.Add(this.textBoxPosition);
            this.pageDataSheet.Controls.Add(this.textBoxUsername);
            this.pageDataSheet.Controls.Add(this.textBoxName);
            this.pageDataSheet.Controls.Add(this.labelConstOptional2);
            this.pageDataSheet.Controls.Add(this.labelConstOptional1);
            this.pageDataSheet.Controls.Add(this.labelPhoneCountryCode2);
            this.pageDataSheet.Controls.Add(this.labelPhoneCountryCode);
            this.pageDataSheet.Controls.Add(this.buttonExport);
            this.pageDataSheet.Controls.Add(this.labelConstDepartment);
            this.pageDataSheet.Controls.Add(this.labelConstPosition);
            this.pageDataSheet.Controls.Add(this.labelConstMobile);
            this.pageDataSheet.Controls.Add(this.labelConstUsername);
            this.pageDataSheet.Controls.Add(this.labelConstPhone);
            this.pageDataSheet.Controls.Add(this.labelConstName);
            this.pageDataSheet.Controls.Add(this.webBrowserSignature);
            this.pageDataSheet.Location = new System.Drawing.Point(4, 22);
            this.pageDataSheet.Name = "pageDataSheet";
            this.pageDataSheet.Size = new System.Drawing.Size(768, 460);
            this.pageDataSheet.TabIndex = 6;
            this.pageDataSheet.Text = "pageDataSheet";
            // 
            // textBoxMobile
            // 
            this.textBoxMobile.Location = new System.Drawing.Point(155, 138);
            this.textBoxMobile.MaxLength = 20;
            this.textBoxMobile.Name = "textBoxMobile";
            this.textBoxMobile.Size = new System.Drawing.Size(205, 20);
            this.textBoxMobile.TabIndex = 40;
            this.textBoxMobile.watermark = null;
            this.textBoxMobile.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(155, 112);
            this.textBoxPhone.MaxLength = 20;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(205, 20);
            this.textBoxPhone.TabIndex = 39;
            this.textBoxPhone.watermark = null;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxDepartment
            // 
            this.textBoxDepartment.Location = new System.Drawing.Point(102, 86);
            this.textBoxDepartment.MaxLength = 60;
            this.textBoxDepartment.Name = "textBoxDepartment";
            this.textBoxDepartment.Size = new System.Drawing.Size(258, 20);
            this.textBoxDepartment.TabIndex = 38;
            this.textBoxDepartment.watermark = null;
            this.textBoxDepartment.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(102, 60);
            this.textBoxPosition.MaxLength = 60;
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(258, 20);
            this.textBoxPosition.TabIndex = 37;
            this.textBoxPosition.watermark = null;
            this.textBoxPosition.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Enabled = false;
            this.textBoxUsername.Location = new System.Drawing.Point(102, 8);
            this.textBoxUsername.MaxLength = 8;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(258, 20);
            this.textBoxUsername.TabIndex = 35;
            this.textBoxUsername.watermark = null;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 34);
            this.textBoxName.MaxLength = 60;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(258, 20);
            this.textBoxName.TabIndex = 36;
            this.textBoxName.watermark = null;
            this.textBoxName.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // labelConstOptional2
            // 
            this.labelConstOptional2.AutoSize = true;
            this.labelConstOptional2.Location = new System.Drawing.Point(366, 140);
            this.labelConstOptional2.Name = "labelConstOptional2";
            this.labelConstOptional2.Size = new System.Drawing.Size(101, 13);
            this.labelConstOptional2.TabIndex = 45;
            this.labelConstOptional2.Text = "labelConstOptional2";
            // 
            // labelConstOptional1
            // 
            this.labelConstOptional1.AutoSize = true;
            this.labelConstOptional1.Location = new System.Drawing.Point(366, 88);
            this.labelConstOptional1.Name = "labelConstOptional1";
            this.labelConstOptional1.Size = new System.Drawing.Size(101, 13);
            this.labelConstOptional1.TabIndex = 44;
            this.labelConstOptional1.Text = "labelConstOptional1";
            // 
            // labelPhoneCountryCode2
            // 
            this.labelPhoneCountryCode2.AutoSize = true;
            this.labelPhoneCountryCode2.Location = new System.Drawing.Point(102, 141);
            this.labelPhoneCountryCode2.Name = "labelPhoneCountryCode2";
            this.labelPhoneCountryCode2.Size = new System.Drawing.Size(127, 13);
            this.labelPhoneCountryCode2.TabIndex = 42;
            this.labelPhoneCountryCode2.Text = "labelPhoneCountryCode2";
            // 
            // labelPhoneCountryCode
            // 
            this.labelPhoneCountryCode.AutoSize = true;
            this.labelPhoneCountryCode.Location = new System.Drawing.Point(102, 115);
            this.labelPhoneCountryCode.Name = "labelPhoneCountryCode";
            this.labelPhoneCountryCode.Size = new System.Drawing.Size(121, 13);
            this.labelPhoneCountryCode.TabIndex = 33;
            this.labelPhoneCountryCode.Text = "labelPhoneCountryCode";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(285, 164);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 41;
            this.buttonExport.Text = "Finish";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelConstDepartment
            // 
            this.labelConstDepartment.Location = new System.Drawing.Point(12, 88);
            this.labelConstDepartment.Name = "labelConstDepartment";
            this.labelConstDepartment.Size = new System.Drawing.Size(84, 13);
            this.labelConstDepartment.TabIndex = 30;
            this.labelConstDepartment.Text = "labelConstDepartment";
            this.labelConstDepartment.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstPosition
            // 
            this.labelConstPosition.Location = new System.Drawing.Point(12, 62);
            this.labelConstPosition.Name = "labelConstPosition";
            this.labelConstPosition.Size = new System.Drawing.Size(84, 13);
            this.labelConstPosition.TabIndex = 29;
            this.labelConstPosition.Text = "labelConstPosition";
            this.labelConstPosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstMobile
            // 
            this.labelConstMobile.Location = new System.Drawing.Point(12, 140);
            this.labelConstMobile.Name = "labelConstMobile";
            this.labelConstMobile.Size = new System.Drawing.Size(84, 13);
            this.labelConstMobile.TabIndex = 28;
            this.labelConstMobile.Text = "labelConstMobile";
            this.labelConstMobile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstUsername
            // 
            this.labelConstUsername.Location = new System.Drawing.Point(12, 10);
            this.labelConstUsername.Name = "labelConstUsername";
            this.labelConstUsername.Size = new System.Drawing.Size(84, 13);
            this.labelConstUsername.TabIndex = 27;
            this.labelConstUsername.Text = "labelConstUsername";
            this.labelConstUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstPhone
            // 
            this.labelConstPhone.Location = new System.Drawing.Point(12, 114);
            this.labelConstPhone.Name = "labelConstPhone";
            this.labelConstPhone.Size = new System.Drawing.Size(84, 13);
            this.labelConstPhone.TabIndex = 26;
            this.labelConstPhone.Text = "labelConstPhone";
            this.labelConstPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstName
            // 
            this.labelConstName.Location = new System.Drawing.Point(12, 36);
            this.labelConstName.Name = "labelConstName";
            this.labelConstName.Size = new System.Drawing.Size(84, 13);
            this.labelConstName.TabIndex = 31;
            this.labelConstName.Text = "labelConstName";
            this.labelConstName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // webBrowserSignature
            // 
            this.webBrowserSignature.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserSignature.Location = new System.Drawing.Point(0, 199);
            this.webBrowserSignature.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSignature.Name = "webBrowserSignature";
            this.webBrowserSignature.ScrollBarsEnabled = false;
            this.webBrowserSignature.Size = new System.Drawing.Size(768, 261);
            this.webBrowserSignature.TabIndex = 25;
            this.webBrowserSignature.TabStop = false;
            this.webBrowserSignature.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // FormWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 495);
            this.Controls.Add(this.WizardPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormWizard";
            this.Text = "Outlook Signature Generator - Hanon Systems";
            this.Load += new System.EventHandler(this.FormWizard_Load);
            this.WizardPages.ResumeLayout(false);
            this.pageContinent.ResumeLayout(false);
            this.pageContinent.PerformLayout();
            this.pageCountry.ResumeLayout(false);
            this.pageCountry.PerformLayout();
            this.pageCity.ResumeLayout(false);
            this.pageCity.PerformLayout();
            this.pageEntity.ResumeLayout(false);
            this.pageEntity.PerformLayout();
            this.pageDataSheet.ResumeLayout(false);
            this.pageDataSheet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages WizardPages;
        private System.Windows.Forms.TabPage pageContinent;
        private System.Windows.Forms.Label labelConstContinentHint;
        private System.Windows.Forms.TabPage pageCountry;
        private System.Windows.Forms.Label labelConstCountryHint;
        private System.Windows.Forms.TabPage pageCity;
        private System.Windows.Forms.Label labelConstCityHint;
        private System.Windows.Forms.TabPage pageDataSheet;
        private TextBoxExtended textBoxMobile;
        private TextBoxExtended textBoxPhone;
        private TextBoxExtended textBoxDepartment;
        private TextBoxExtended textBoxPosition;
        private TextBoxExtended textBoxUsername;
        private TextBoxExtended textBoxName;
        private System.Windows.Forms.Label labelConstOptional2;
        private System.Windows.Forms.Label labelConstOptional1;
        private System.Windows.Forms.Label labelPhoneCountryCode2;
        private System.Windows.Forms.Label labelPhoneCountryCode;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelConstDepartment;
        private System.Windows.Forms.Label labelConstPosition;
        private System.Windows.Forms.Label labelConstMobile;
        private System.Windows.Forms.Label labelConstUsername;
        private System.Windows.Forms.Label labelConstPhone;
        private System.Windows.Forms.Label labelConstName;
        private System.Windows.Forms.WebBrowser webBrowserSignature;
        private System.Windows.Forms.TabPage pageEntity;
        private System.Windows.Forms.Label labelConstEntityHint;
    }
}