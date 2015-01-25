using System;
using System.Windows.Forms;
using AndroidProjectManipulator;
using TranslatorInterface;
using System.Collections.Generic;
using TranslatorInterface.MicrosoftTranslator;

namespace AndroidStringResourceTranslator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStatus("");
            GetTranslationProviders();
        }

        private void GetTranslationProviders()
        {
            List<TranslatorDefinition> translators = TranslationService.GetAvailableTranslators();
            cbTranslateService.BeginUpdate();
            cbTranslateService.Items.Clear();
            cbTranslateService.Items.AddRange(translators.ToArray());
            cbTranslateService.EndUpdate();
            // TODO: This is an ugly hack to make the Microsoft Translator the default selection.
            cbTranslateService.SelectedIndex = 1;
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            DoWork();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtRootDirectory.Text = folderDialog.SelectedPath;
            }
        }
        
        public void SetStatus(String message)
        {
            txtStatus.Text = message;
            txtStatus.Invalidate();
            txtStatus.Refresh();
        }

        private bool ValidateProjectDirectory()
        {
            bool valid = AndroidProject.IsProject(txtRootDirectory.Text);
            if (!valid)
            {
                SetStatus("Cannot find AndroidManifest.xml");
            }
            return valid;
        }

        private void txtRootDirectory_TextChanged(object sender, EventArgs e)
        {
            if (ValidateProjectDirectory())
            {
                SetStatus("");
            }
        }

        private void DoWork()
        {
            if (ValidateInputs())
            {
                SetStatus("Starting TranslationServices");
                TranslateProject(GetApiKey(), txtRootDirectory.Text, GetSelectedTranslatorDefinition(), GetSelectedSourceLanguage());
                SetStatus("Completed");
            }
        }

        public static void TranslateProject(string apikey, string project_path, TranslatorDefinition transdef, Language sourceLanguage)
        {
            AndroidProject project = new AndroidProject(project_path);
            ResourceTranslator rt = new ResourceTranslator(project, transdef.CreateInstance(apikey), sourceLanguage);

            rt.TranslateProject();
        }

        private void linkApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(GetSelectedTranslatorDefinition().GetApiKeyUrl);
        }

        private string GetApiKey()
        {
            return txtBingApiKey.Text;
        }

        private void cbTranslateService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidateApiKey())
            {
                TranslatorDefinition transdef = GetSelectedTranslatorDefinition();
                ITranslator translator = transdef.CreateInstance(GetApiKey());
                List<Language> languages = translator.GetSupportedLanguages();

                cbSourceLang.BeginUpdate();
                cbSourceLang.Items.Clear();
                cbSourceLang.Items.AddRange(languages.ToArray());
                cbSourceLang.SelectedIndex = 0;
                cbSourceLang.EndUpdate();
            }
        }

        private TranslatorDefinition GetSelectedTranslatorDefinition()
        {
            return (TranslatorDefinition)cbTranslateService.SelectedItem;
        }
        private Language GetSelectedSourceLanguage()
        {
            return (Language)this.cbSourceLang.SelectedItem;
        }

        private bool ValidateApiKey()
        {
            if(string.IsNullOrEmpty(this.GetApiKey()))
            {
                txtBingApiKey.Focus();
                SetStatus("ApiKey is mandatory.");
                return false;
            }

            return true;
        }

        private bool ValidateInputs()
        {
            return ValidateApiKey() && ValidateProjectDirectory();
        }

        private void txtBingApiKey_Leave(object sender, EventArgs e)
        {
            ValidateApiKey();
            cbTranslateService_SelectedIndexChanged(sender, e);
        }
    }
}
