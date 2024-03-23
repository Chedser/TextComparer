using System.Windows.Forms;

namespace TextComparer{
    partial class MainForm{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing){
            if (disposing && (components != null)){
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(){
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelTopLeft = new System.Windows.Forms.Panel();
            this.LabelFileRightName = new System.Windows.Forms.Label();
            this.LabelFileLeftName = new System.Windows.Forms.Label();
            this.CompareButton = new System.Windows.Forms.Button();
            this.FileRightButton = new System.Windows.Forms.Button();
            this.FileLeftButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.RichTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.CheckBoxSyncScroll = new System.Windows.Forms.CheckBox();
            this.RichTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.PanelTopRight = new System.Windows.Forms.Panel();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelResult = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PanelTopLeft.SuspendLayout();
            this.PanelTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTopLeft
            // 
            this.PanelTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTopLeft.Controls.Add(this.LabelFileRightName);
            this.PanelTopLeft.Controls.Add(this.LabelFileLeftName);
            this.PanelTopLeft.Controls.Add(this.CompareButton);
            this.PanelTopLeft.Controls.Add(this.FileRightButton);
            this.PanelTopLeft.Controls.Add(this.FileLeftButton);
            this.PanelTopLeft.Location = new System.Drawing.Point(5, 0);
            this.PanelTopLeft.Name = "PanelTopLeft";
            this.PanelTopLeft.Size = new System.Drawing.Size(615, 35);
            this.PanelTopLeft.TabIndex = 0;
            // 
            // LabelFileRightName
            // 
            this.LabelFileRightName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelFileRightName.Location = new System.Drawing.Point(350, 7);
            this.LabelFileRightName.Name = "LabelFileRightName";
            this.LabelFileRightName.Size = new System.Drawing.Size(178, 23);
            this.LabelFileRightName.TabIndex = 4;
            this.LabelFileRightName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFileLeftName
            // 
            this.LabelFileLeftName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelFileLeftName.Location = new System.Drawing.Point(84, 7);
            this.LabelFileLeftName.Name = "LabelFileLeftName";
            this.LabelFileLeftName.Size = new System.Drawing.Size(178, 23);
            this.LabelFileLeftName.TabIndex = 3;
            this.LabelFileLeftName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompareButton
            // 
            this.CompareButton.Enabled = false;
            this.CompareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CompareButton.Location = new System.Drawing.Point(268, 7);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(75, 23);
            this.CompareButton.TabIndex = 2;
            this.CompareButton.Text = "Compare";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // FileRightButton
            // 
            this.FileRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.FileRightButton.Location = new System.Drawing.Point(534, 7);
            this.FileRightButton.Name = "FileRightButton";
            this.FileRightButton.Size = new System.Drawing.Size(75, 23);
            this.FileRightButton.TabIndex = 1;
            this.FileRightButton.Text = "File 2";
            this.FileRightButton.UseVisualStyleBackColor = true;
            this.FileRightButton.Click += new System.EventHandler(this.FileRightButton_Click);
            // 
            // FileLeftButton
            // 
            this.FileLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.FileLeftButton.Location = new System.Drawing.Point(3, 7);
            this.FileLeftButton.Name = "FileLeftButton";
            this.FileLeftButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileLeftButton.Size = new System.Drawing.Size(75, 23);
            this.FileLeftButton.TabIndex = 0;
            this.FileLeftButton.Text = "File 1";
            this.FileLeftButton.UseVisualStyleBackColor = true;
            this.FileLeftButton.Click += new System.EventHandler(this.FileLeftButton_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "txt";
            this.OpenFileDialog.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt|Source files|*.c;*.cpp;*.h;*.cs;*.java" +
    ";*.js;*.py;*.php;*.asm|HTML|*.html;*.htm|CSS|*.css";
            // 
            // RichTextBoxLeft
            // 
            this.RichTextBoxLeft.Location = new System.Drawing.Point(5, 38);
            this.RichTextBoxLeft.Name = "RichTextBoxLeft";
            this.RichTextBoxLeft.ReadOnly = true;
            this.RichTextBoxLeft.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxLeft.Size = new System.Drawing.Size(305, 400);
            this.RichTextBoxLeft.TabIndex = 1;
            this.RichTextBoxLeft.Text = "";
            this.RichTextBoxLeft.VScroll += new System.EventHandler(this.RichTextBoxLeft_VScroll);
            // 
            // RichTextBoxRight
            // 
            this.RichTextBoxRight.Location = new System.Drawing.Point(314, 38);
            this.RichTextBoxRight.Name = "RichTextBoxRight";
            this.RichTextBoxRight.ReadOnly = true;
            this.RichTextBoxRight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxRight.Size = new System.Drawing.Size(305, 400);
            this.RichTextBoxRight.TabIndex = 2;
            this.RichTextBoxRight.Text = "";
            // 
            // CheckBoxSyncScroll
            // 
            this.CheckBoxSyncScroll.AutoSize = true;
            this.CheckBoxSyncScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CheckBoxSyncScroll.Location = new System.Drawing.Point(261, 444);
            this.CheckBoxSyncScroll.Name = "CheckBoxSyncScroll";
            this.CheckBoxSyncScroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBoxSyncScroll.Size = new System.Drawing.Size(88, 17);
            this.CheckBoxSyncScroll.TabIndex = 3;
            this.CheckBoxSyncScroll.Text = "Sync scroll";
            this.CheckBoxSyncScroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxSyncScroll.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxResult
            // 
            this.RichTextBoxResult.Location = new System.Drawing.Point(624, 38);
            this.RichTextBoxResult.Name = "RichTextBoxResult";
            this.RichTextBoxResult.ReadOnly = true;
            this.RichTextBoxResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxResult.Size = new System.Drawing.Size(305, 400);
            this.RichTextBoxResult.TabIndex = 4;
            this.RichTextBoxResult.Text = "";
            // 
            // PanelTopRight
            // 
            this.PanelTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTopRight.Controls.Add(this.ButtonSave);
            this.PanelTopRight.Controls.Add(this.LabelResult);
            this.PanelTopRight.Location = new System.Drawing.Point(625, 0);
            this.PanelTopRight.Name = "PanelTopRight";
            this.PanelTopRight.Size = new System.Drawing.Size(306, 35);
            this.PanelTopRight.TabIndex = 5;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ButtonSave.Location = new System.Drawing.Point(225, 5);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelResult
            // 
            this.LabelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelResult.Location = new System.Drawing.Point(63, 5);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(178, 23);
            this.LabelResult.TabIndex = 5;
            this.LabelResult.Text = "Result";
            this.LabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt|Source files|*.c;*.cpp;.h;*.cs;*.java;" +
    "*.js;*.py;*.php;*.asm|HTML|*.html;*.htm|CSS|*.css";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(938, 471);
            this.Controls.Add(this.PanelTopRight);
            this.Controls.Add(this.RichTextBoxResult);
            this.Controls.Add(this.CheckBoxSyncScroll);
            this.Controls.Add(this.RichTextBoxRight);
            this.Controls.Add(this.RichTextBoxLeft);
            this.Controls.Add(this.PanelTopLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(954, 510);
            this.Name = "MainForm";
            this.Text = "TextComparer";
            this.PanelTopLeft.ResumeLayout(false);
            this.PanelTopRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTopLeft;
        private System.Windows.Forms.Button FileRightButton;
        private System.Windows.Forms.Button FileLeftButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.RichTextBox RichTextBoxLeft;
        private System.Windows.Forms.RichTextBox RichTextBoxRight;
        private Button CompareButton;
        private CheckBox CheckBoxSyncScroll;
        private Label LabelFileLeftName;
        private Label LabelFileRightName;
        private RichTextBox RichTextBoxResult;
        private Panel PanelTopRight;
        private Label LabelResult;
        private Button ButtonSave;
        private SaveFileDialog SaveFileDialog;
    }
}

