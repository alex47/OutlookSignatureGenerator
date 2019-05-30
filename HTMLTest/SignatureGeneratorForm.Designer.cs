namespace SignatureGeneratorProgram
{
    partial class SignatureGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignatureGeneratorForm));
            this.webBrowserSignature = new System.Windows.Forms.WebBrowser();
            this.labelConstName = new System.Windows.Forms.Label();
            this.labelConstPhone = new System.Windows.Forms.Label();
            this.labelConstUsername = new System.Windows.Forms.Label();
            this.labelConstMobile = new System.Windows.Forms.Label();
            this.labelConstPosition = new System.Windows.Forms.Label();
            this.labelConstDepartment = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelConstPhoneNumberBeginning = new System.Windows.Forms.Label();
            this.comboBoxPhoneNumberBeginning = new System.Windows.Forms.ComboBox();
            this.labelConstCountryPreNumber = new System.Windows.Forms.Label();
            this.comboBoxMobileNumberBeginning = new System.Windows.Forms.ComboBox();
            this.buttonLanguageEnglish = new System.Windows.Forms.Button();
            this.buttonLanguageHungarian = new System.Windows.Forms.Button();
            this.labelConstGreeting = new System.Windows.Forms.Label();
            this.labelConstDepartmentHint = new System.Windows.Forms.Label();
            this.labelConstMobileHint = new System.Windows.Forms.Label();
            this.checkBoxGreetingHungarian = new System.Windows.Forms.CheckBox();
            this.checkBoxGreetingEnglish = new System.Windows.Forms.CheckBox();
            this.checkBoxGreetingGerman = new System.Windows.Forms.CheckBox();
            this.textBoxMobile = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxPhone = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxDepartment = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxPosition = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxUsername = new SignatureGeneratorProgram.TextBoxExtended();
            this.textBoxName = new SignatureGeneratorProgram.TextBoxExtended();
            this.SuspendLayout();
            // 
            // webBrowserSignature
            // 
            this.webBrowserSignature.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserSignature.Location = new System.Drawing.Point(0, 205);
            this.webBrowserSignature.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSignature.Name = "webBrowserSignature";
            this.webBrowserSignature.ScrollBarsEnabled = false;
            this.webBrowserSignature.Size = new System.Drawing.Size(884, 261);
            this.webBrowserSignature.TabIndex = 0;
            this.webBrowserSignature.TabStop = false;
            this.webBrowserSignature.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // labelConstName
            // 
            this.labelConstName.Location = new System.Drawing.Point(12, 43);
            this.labelConstName.Name = "labelConstName";
            this.labelConstName.Size = new System.Drawing.Size(84, 13);
            this.labelConstName.TabIndex = 0;
            this.labelConstName.Text = "labelConstName";
            this.labelConstName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstPhone
            // 
            this.labelConstPhone.Location = new System.Drawing.Point(12, 121);
            this.labelConstPhone.Name = "labelConstPhone";
            this.labelConstPhone.Size = new System.Drawing.Size(84, 13);
            this.labelConstPhone.TabIndex = 0;
            this.labelConstPhone.Text = "labelConstPhone";
            this.labelConstPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstUsername
            // 
            this.labelConstUsername.Location = new System.Drawing.Point(12, 17);
            this.labelConstUsername.Name = "labelConstUsername";
            this.labelConstUsername.Size = new System.Drawing.Size(84, 13);
            this.labelConstUsername.TabIndex = 0;
            this.labelConstUsername.Text = "labelConstUsername";
            this.labelConstUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstMobile
            // 
            this.labelConstMobile.Location = new System.Drawing.Point(12, 147);
            this.labelConstMobile.Name = "labelConstMobile";
            this.labelConstMobile.Size = new System.Drawing.Size(84, 13);
            this.labelConstMobile.TabIndex = 0;
            this.labelConstMobile.Text = "labelConstMobile";
            this.labelConstMobile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstPosition
            // 
            this.labelConstPosition.Location = new System.Drawing.Point(12, 69);
            this.labelConstPosition.Name = "labelConstPosition";
            this.labelConstPosition.Size = new System.Drawing.Size(84, 13);
            this.labelConstPosition.TabIndex = 0;
            this.labelConstPosition.Text = "labelConstPosition";
            this.labelConstPosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstDepartment
            // 
            this.labelConstDepartment.Location = new System.Drawing.Point(12, 95);
            this.labelConstDepartment.Name = "labelConstDepartment";
            this.labelConstDepartment.Size = new System.Drawing.Size(84, 13);
            this.labelConstDepartment.TabIndex = 0;
            this.labelConstDepartment.Text = "labelConstDepartment";
            this.labelConstDepartment.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(285, 170);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Finish";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // labelConstPhoneNumberBeginning
            // 
            this.labelConstPhoneNumberBeginning.AutoSize = true;
            this.labelConstPhoneNumberBeginning.Location = new System.Drawing.Point(97, 121);
            this.labelConstPhoneNumberBeginning.Name = "labelConstPhoneNumberBeginning";
            this.labelConstPhoneNumberBeginning.Size = new System.Drawing.Size(43, 13);
            this.labelConstPhoneNumberBeginning.TabIndex = 0;
            this.labelConstPhoneNumberBeginning.Text = "+36 22 ";
            // 
            // comboBoxPhoneNumberBeginning
            // 
            this.comboBoxPhoneNumberBeginning.DisplayMember = "(none)";
            this.comboBoxPhoneNumberBeginning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhoneNumberBeginning.Items.AddRange(new object[] {
            "530",
            "549"});
            this.comboBoxPhoneNumberBeginning.Location = new System.Drawing.Point(140, 118);
            this.comboBoxPhoneNumberBeginning.Name = "comboBoxPhoneNumberBeginning";
            this.comboBoxPhoneNumberBeginning.Size = new System.Drawing.Size(43, 21);
            this.comboBoxPhoneNumberBeginning.TabIndex = 0;
            this.comboBoxPhoneNumberBeginning.TabStop = false;
            this.comboBoxPhoneNumberBeginning.SelectedValueChanged += new System.EventHandler(this.ComboBoxPhoneNumberBeginning_SelectedValueChanged);
            // 
            // labelConstCountryPreNumber
            // 
            this.labelConstCountryPreNumber.AutoSize = true;
            this.labelConstCountryPreNumber.Location = new System.Drawing.Point(112, 147);
            this.labelConstCountryPreNumber.Name = "labelConstCountryPreNumber";
            this.labelConstCountryPreNumber.Size = new System.Drawing.Size(25, 13);
            this.labelConstCountryPreNumber.TabIndex = 10;
            this.labelConstCountryPreNumber.Text = "+36";
            // 
            // comboBoxMobileNumberBeginning
            // 
            this.comboBoxMobileNumberBeginning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMobileNumberBeginning.FormattingEnabled = true;
            this.comboBoxMobileNumberBeginning.Items.AddRange(new object[] {
            "20",
            "30",
            "70"});
            this.comboBoxMobileNumberBeginning.Location = new System.Drawing.Point(140, 144);
            this.comboBoxMobileNumberBeginning.Name = "comboBoxMobileNumberBeginning";
            this.comboBoxMobileNumberBeginning.Size = new System.Drawing.Size(43, 21);
            this.comboBoxMobileNumberBeginning.TabIndex = 0;
            this.comboBoxMobileNumberBeginning.TabStop = false;
            this.comboBoxMobileNumberBeginning.SelectedValueChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // buttonLanguageEnglish
            // 
            this.buttonLanguageEnglish.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLanguageEnglish.Location = new System.Drawing.Point(797, 12);
            this.buttonLanguageEnglish.Name = "buttonLanguageEnglish";
            this.buttonLanguageEnglish.Size = new System.Drawing.Size(75, 23);
            this.buttonLanguageEnglish.TabIndex = 8;
            this.buttonLanguageEnglish.Text = "English";
            this.buttonLanguageEnglish.UseVisualStyleBackColor = true;
            this.buttonLanguageEnglish.Click += new System.EventHandler(this.ButtonLanguageEnglish_Click);
            // 
            // buttonLanguageHungarian
            // 
            this.buttonLanguageHungarian.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLanguageHungarian.Location = new System.Drawing.Point(797, 40);
            this.buttonLanguageHungarian.Name = "buttonLanguageHungarian";
            this.buttonLanguageHungarian.Size = new System.Drawing.Size(75, 23);
            this.buttonLanguageHungarian.TabIndex = 9;
            this.buttonLanguageHungarian.Text = "Magyar";
            this.buttonLanguageHungarian.UseVisualStyleBackColor = true;
            this.buttonLanguageHungarian.Click += new System.EventHandler(this.ButtonLanguageHungarian_Click);
            // 
            // labelConstGreeting
            // 
            this.labelConstGreeting.Location = new System.Drawing.Point(409, 14);
            this.labelConstGreeting.Name = "labelConstGreeting";
            this.labelConstGreeting.Size = new System.Drawing.Size(145, 13);
            this.labelConstGreeting.TabIndex = 14;
            this.labelConstGreeting.Text = "labelConstGreeting";
            this.labelConstGreeting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelConstDepartmentHint
            // 
            this.labelConstDepartmentHint.AutoSize = true;
            this.labelConstDepartmentHint.Location = new System.Drawing.Point(366, 95);
            this.labelConstDepartmentHint.Name = "labelConstDepartmentHint";
            this.labelConstDepartmentHint.Size = new System.Drawing.Size(130, 13);
            this.labelConstDepartmentHint.TabIndex = 19;
            this.labelConstDepartmentHint.Text = "labelConstDepartmentHint";
            // 
            // labelConstMobileHint
            // 
            this.labelConstMobileHint.AutoSize = true;
            this.labelConstMobileHint.Location = new System.Drawing.Point(366, 147);
            this.labelConstMobileHint.Name = "labelConstMobileHint";
            this.labelConstMobileHint.Size = new System.Drawing.Size(106, 13);
            this.labelConstMobileHint.TabIndex = 21;
            this.labelConstMobileHint.Text = "labelConstMobileHint";
            // 
            // checkBoxGreetingHungarian
            // 
            this.checkBoxGreetingHungarian.AutoSize = true;
            this.checkBoxGreetingHungarian.Location = new System.Drawing.Point(560, 13);
            this.checkBoxGreetingHungarian.Name = "checkBoxGreetingHungarian";
            this.checkBoxGreetingHungarian.Size = new System.Drawing.Size(163, 17);
            this.checkBoxGreetingHungarian.TabIndex = 22;
            this.checkBoxGreetingHungarian.TabStop = false;
            this.checkBoxGreetingHungarian.Text = "checkBoxGreetingHungarian";
            this.checkBoxGreetingHungarian.UseVisualStyleBackColor = true;
            this.checkBoxGreetingHungarian.CheckedChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // checkBoxGreetingEnglish
            // 
            this.checkBoxGreetingEnglish.AutoSize = true;
            this.checkBoxGreetingEnglish.Location = new System.Drawing.Point(560, 36);
            this.checkBoxGreetingEnglish.Name = "checkBoxGreetingEnglish";
            this.checkBoxGreetingEnglish.Size = new System.Drawing.Size(148, 17);
            this.checkBoxGreetingEnglish.TabIndex = 23;
            this.checkBoxGreetingEnglish.TabStop = false;
            this.checkBoxGreetingEnglish.Text = "checkBoxGreetingEnglish";
            this.checkBoxGreetingEnglish.UseVisualStyleBackColor = true;
            this.checkBoxGreetingEnglish.CheckedChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // checkBoxGreetingGerman
            // 
            this.checkBoxGreetingGerman.AutoSize = true;
            this.checkBoxGreetingGerman.Location = new System.Drawing.Point(560, 59);
            this.checkBoxGreetingGerman.Name = "checkBoxGreetingGerman";
            this.checkBoxGreetingGerman.Size = new System.Drawing.Size(151, 17);
            this.checkBoxGreetingGerman.TabIndex = 24;
            this.checkBoxGreetingGerman.TabStop = false;
            this.checkBoxGreetingGerman.Text = "checkBoxGreetingGerman";
            this.checkBoxGreetingGerman.UseVisualStyleBackColor = true;
            this.checkBoxGreetingGerman.CheckedChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxMobile
            // 
            this.textBoxMobile.Location = new System.Drawing.Point(189, 144);
            this.textBoxMobile.MaxLength = 7;
            this.textBoxMobile.Name = "textBoxMobile";
            this.textBoxMobile.Size = new System.Drawing.Size(171, 20);
            this.textBoxMobile.TabIndex = 6;
            this.textBoxMobile.watermark = null;
            this.textBoxMobile.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(189, 118);
            this.textBoxPhone.MaxLength = 3;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(171, 20);
            this.textBoxPhone.TabIndex = 5;
            this.textBoxPhone.watermark = null;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxDepartment
            // 
            this.textBoxDepartment.Location = new System.Drawing.Point(102, 92);
            this.textBoxDepartment.MaxLength = 60;
            this.textBoxDepartment.Name = "textBoxDepartment";
            this.textBoxDepartment.Size = new System.Drawing.Size(258, 20);
            this.textBoxDepartment.TabIndex = 4;
            this.textBoxDepartment.watermark = null;
            this.textBoxDepartment.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(102, 66);
            this.textBoxPosition.MaxLength = 60;
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(258, 20);
            this.textBoxPosition.TabIndex = 3;
            this.textBoxPosition.watermark = null;
            this.textBoxPosition.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Enabled = false;
            this.textBoxUsername.Location = new System.Drawing.Point(102, 14);
            this.textBoxUsername.MaxLength = 8;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(258, 20);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.watermark = null;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 40);
            this.textBoxName.MaxLength = 60;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(258, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.watermark = null;
            this.textBoxName.TextChanged += new System.EventHandler(this.updateHtmlPreviewPage);
            // 
            // SignatureGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 466);
            this.Controls.Add(this.textBoxMobile);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxDepartment);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.checkBoxGreetingGerman);
            this.Controls.Add(this.checkBoxGreetingEnglish);
            this.Controls.Add(this.checkBoxGreetingHungarian);
            this.Controls.Add(this.labelConstMobileHint);
            this.Controls.Add(this.labelConstDepartmentHint);
            this.Controls.Add(this.labelConstGreeting);
            this.Controls.Add(this.buttonLanguageHungarian);
            this.Controls.Add(this.buttonLanguageEnglish);
            this.Controls.Add(this.comboBoxMobileNumberBeginning);
            this.Controls.Add(this.labelConstCountryPreNumber);
            this.Controls.Add(this.comboBoxPhoneNumberBeginning);
            this.Controls.Add(this.labelConstPhoneNumberBeginning);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelConstDepartment);
            this.Controls.Add(this.labelConstPosition);
            this.Controls.Add(this.labelConstMobile);
            this.Controls.Add(this.labelConstUsername);
            this.Controls.Add(this.labelConstPhone);
            this.Controls.Add(this.labelConstName);
            this.Controls.Add(this.webBrowserSignature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SignatureGeneratorForm";
            this.Text = "Outlook Signature Generator (placeholder)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserSignature;
        private System.Windows.Forms.Label labelConstName;
        private System.Windows.Forms.Label labelConstPhone;
        private System.Windows.Forms.Label labelConstUsername;
        private System.Windows.Forms.Label labelConstMobile;
        private System.Windows.Forms.Label labelConstPosition;
        private System.Windows.Forms.Label labelConstDepartment;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelConstPhoneNumberBeginning;
        private System.Windows.Forms.ComboBox comboBoxPhoneNumberBeginning;
        private System.Windows.Forms.Label labelConstCountryPreNumber;
        private System.Windows.Forms.ComboBox comboBoxMobileNumberBeginning;
        private System.Windows.Forms.Button buttonLanguageEnglish;
        private System.Windows.Forms.Button buttonLanguageHungarian;
        private System.Windows.Forms.Label labelConstGreeting;
        private System.Windows.Forms.Label labelConstDepartmentHint;
        private System.Windows.Forms.Label labelConstMobileHint;
        private System.Windows.Forms.CheckBox checkBoxGreetingHungarian;
        private System.Windows.Forms.CheckBox checkBoxGreetingEnglish;
        private System.Windows.Forms.CheckBox checkBoxGreetingGerman;
        private TextBoxExtended textBoxName;
        private TextBoxExtended textBoxUsername;
        private TextBoxExtended textBoxPosition;
        private TextBoxExtended textBoxDepartment;
        private TextBoxExtended textBoxPhone;
        private TextBoxExtended textBoxMobile;
    }
}

