namespace Datapel.BreezeAPI.Sample
{
    partial class frmMain
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
            this.btnGetToken = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtBase64Auth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsAuthorised = new System.Windows.Forms.CheckBox();
            this.txtErrorMsg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReq = new System.Windows.Forms.Button();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.tabServiceGet = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.dgvReturn = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQuery2 = new System.Windows.Forms.TextBox();
            this.txtEndpoint2 = new System.Windows.Forms.TextBox();
            this.btnRequest2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErrorMsg2 = new System.Windows.Forms.TextBox();
            this.tabServiceSave = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSaveValue = new System.Windows.Forms.TextBox();
            this.dgvSaveReturn = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSaveField = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSaveQuery = new System.Windows.Forms.TextBox();
            this.txtSaveEndpoint = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabServiceGet.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
            this.tabServiceSave.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaveReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetToken
            // 
            this.btnGetToken.Location = new System.Drawing.Point(588, 15);
            this.btnGetToken.Name = "btnGetToken";
            this.btnGetToken.Size = new System.Drawing.Size(75, 23);
            this.btnGetToken.TabIndex = 0;
            this.btnGetToken.Text = "Get Token";
            this.btnGetToken.UseVisualStyleBackColor = true;
            this.btnGetToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(89, 17);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(179, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "developer";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(347, 17);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(209, 20);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "passw0rd";
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(347, 43);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(209, 20);
            this.txtToken.TabIndex = 3;
            // 
            // txtBase64Auth
            // 
            this.txtBase64Auth.Location = new System.Drawing.Point(89, 43);
            this.txtBase64Auth.Name = "txtBase64Auth";
            this.txtBase64Auth.Size = new System.Drawing.Size(179, 20);
            this.txtBase64Auth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "password";
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(274, 46);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(34, 13);
            this.lblToken.TabIndex = 7;
            this.lblToken.Text = "token";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Base64 Auth";
            // 
            // chkIsAuthorised
            // 
            this.chkIsAuthorised.AutoSize = true;
            this.chkIsAuthorised.Location = new System.Drawing.Point(89, 69);
            this.chkIsAuthorised.Name = "chkIsAuthorised";
            this.chkIsAuthorised.Size = new System.Drawing.Size(87, 17);
            this.chkIsAuthorised.TabIndex = 9;
            this.chkIsAuthorised.Text = "Is Authorised";
            this.chkIsAuthorised.UseVisualStyleBackColor = true;
            // 
            // txtErrorMsg
            // 
            this.txtErrorMsg.Location = new System.Drawing.Point(89, 101);
            this.txtErrorMsg.Name = "txtErrorMsg";
            this.txtErrorMsg.Size = new System.Drawing.Size(467, 20);
            this.txtErrorMsg.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Error Msg";
            // 
            // btnReq
            // 
            this.btnReq.Location = new System.Drawing.Point(588, 134);
            this.btnReq.Name = "btnReq";
            this.btnReq.Size = new System.Drawing.Size(75, 23);
            this.btnReq.TabIndex = 12;
            this.btnReq.Text = "Get";
            this.btnReq.UseVisualStyleBackColor = true;
            this.btnReq.Click += new System.EventHandler(this.btnReq_Click);
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(89, 136);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(179, 20);
            this.txtEndpoint.TabIndex = 13;
            this.txtEndpoint.Text = "items";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(347, 136);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(209, 20);
            this.txtQuery.TabIndex = 14;
            this.txtQuery.Text = "filter~*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Query String";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Endpoint";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(89, 171);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(467, 173);
            this.txtResult.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Result";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnGetToken);
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtToken);
            this.panel1.Controls.Add(this.txtQuery);
            this.panel1.Controls.Add(this.txtBase64Auth);
            this.panel1.Controls.Add(this.txtEndpoint);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnReq);
            this.panel1.Controls.Add(this.lblToken);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtErrorMsg);
            this.panel1.Controls.Add(this.chkIsAuthorised);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 364);
            this.panel1.TabIndex = 19;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabBasic);
            this.tabCtrl.Controls.Add(this.tabServiceGet);
            this.tabCtrl.Controls.Add(this.tabServiceSave);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(708, 396);
            this.tabCtrl.TabIndex = 19;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.panel1);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(700, 370);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic Request";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // tabServiceGet
            // 
            this.tabServiceGet.Controls.Add(this.panel2);
            this.tabServiceGet.Location = new System.Drawing.Point(4, 22);
            this.tabServiceGet.Name = "tabServiceGet";
            this.tabServiceGet.Padding = new System.Windows.Forms.Padding(3);
            this.tabServiceGet.Size = new System.Drawing.Size(700, 370);
            this.tabServiceGet.TabIndex = 1;
            this.tabServiceGet.Text = "Service Request";
            this.tabServiceGet.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtId2);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtPage);
            this.panel2.Controls.Add(this.txtPageSize);
            this.panel2.Controls.Add(this.dgvReturn);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtQuery2);
            this.panel2.Controls.Add(this.txtEndpoint2);
            this.panel2.Controls.Add(this.btnRequest2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtErrorMsg2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 364);
            this.panel2.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "id2 Value";
            // 
            // txtId2
            // 
            this.txtId2.Location = new System.Drawing.Point(332, 104);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(209, 20);
            this.txtId2.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "id Value";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(74, 101);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(179, 20);
            this.txtID.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Page Size";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(272, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Page No.";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(332, 75);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(209, 20);
            this.txtPage.TabIndex = 25;
            this.txtPage.Text = "0";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(74, 75);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(179, 20);
            this.txtPageSize.TabIndex = 24;
            this.txtPageSize.Text = "100";
            // 
            // dgvReturn
            // 
            this.dgvReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturn.Location = new System.Drawing.Point(74, 130);
            this.dgvReturn.Name = "dgvReturn";
            this.dgvReturn.Size = new System.Drawing.Size(574, 219);
            this.dgvReturn.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Endpoint";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Query String";
            // 
            // txtQuery2
            // 
            this.txtQuery2.Location = new System.Drawing.Point(332, 49);
            this.txtQuery2.Name = "txtQuery2";
            this.txtQuery2.Size = new System.Drawing.Size(209, 20);
            this.txtQuery2.TabIndex = 21;
            this.txtQuery2.Text = "filter~*";
            // 
            // txtEndpoint2
            // 
            this.txtEndpoint2.Location = new System.Drawing.Point(74, 49);
            this.txtEndpoint2.Name = "txtEndpoint2";
            this.txtEndpoint2.Size = new System.Drawing.Size(179, 20);
            this.txtEndpoint2.TabIndex = 20;
            this.txtEndpoint2.Text = "items";
            // 
            // btnRequest2
            // 
            this.btnRequest2.Location = new System.Drawing.Point(573, 47);
            this.btnRequest2.Name = "btnRequest2";
            this.btnRequest2.Size = new System.Drawing.Size(75, 23);
            this.btnRequest2.TabIndex = 19;
            this.btnRequest2.Text = "Get";
            this.btnRequest2.UseVisualStyleBackColor = true;
            this.btnRequest2.Click += new System.EventHandler(this.btnRequest2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Error Msg";
            // 
            // txtErrorMsg2
            // 
            this.txtErrorMsg2.Location = new System.Drawing.Point(74, 14);
            this.txtErrorMsg2.Name = "txtErrorMsg2";
            this.txtErrorMsg2.Size = new System.Drawing.Size(467, 20);
            this.txtErrorMsg2.TabIndex = 17;
            // 
            // tabServiceSave
            // 
            this.tabServiceSave.Controls.Add(this.panel3);
            this.tabServiceSave.Location = new System.Drawing.Point(4, 22);
            this.tabServiceSave.Name = "tabServiceSave";
            this.tabServiceSave.Padding = new System.Windows.Forms.Padding(3);
            this.tabServiceSave.Size = new System.Drawing.Size(700, 370);
            this.tabServiceSave.TabIndex = 2;
            this.tabServiceSave.Text = "Save Request";
            this.tabServiceSave.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddNew);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtSaveValue);
            this.panel3.Controls.Add(this.dgvSaveReturn);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtSaveField);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtSaveQuery);
            this.panel3.Controls.Add(this.txtSaveEndpoint);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 364);
            this.panel3.TabIndex = 0;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(603, 58);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 36;
            this.btnAddNew.Text = "Copy New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(276, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Field Value";
            // 
            // txtSaveValue
            // 
            this.txtSaveValue.Location = new System.Drawing.Point(343, 65);
            this.txtSaveValue.Name = "txtSaveValue";
            this.txtSaveValue.Size = new System.Drawing.Size(179, 20);
            this.txtSaveValue.TabIndex = 34;
            // 
            // dgvSaveReturn
            // 
            this.dgvSaveReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaveReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaveReturn.Location = new System.Drawing.Point(85, 112);
            this.dgvSaveReturn.Name = "dgvSaveReturn";
            this.dgvSaveReturn.Size = new System.Drawing.Size(593, 237);
            this.dgvSaveReturn.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Field Name";
            // 
            // txtSaveField
            // 
            this.txtSaveField.Location = new System.Drawing.Point(85, 65);
            this.txtSaveField.Name = "txtSaveField";
            this.txtSaveField.Size = new System.Drawing.Size(179, 20);
            this.txtSaveField.TabIndex = 31;
            this.txtSaveField.Text = "udf1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Endpoint";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Query String";
            // 
            // txtSaveQuery
            // 
            this.txtSaveQuery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSaveQuery.Location = new System.Drawing.Point(343, 39);
            this.txtSaveQuery.Name = "txtSaveQuery";
            this.txtSaveQuery.Size = new System.Drawing.Size(209, 20);
            this.txtSaveQuery.TabIndex = 28;
            this.txtSaveQuery.Text = "filter~basestockid=";
            this.txtSaveQuery.TextChanged += new System.EventHandler(this.txtSaveQuery_TextChanged);
            // 
            // txtSaveEndpoint
            // 
            this.txtSaveEndpoint.Location = new System.Drawing.Point(85, 39);
            this.txtSaveEndpoint.Name = "txtSaveEndpoint";
            this.txtSaveEndpoint.Size = new System.Drawing.Size(179, 20);
            this.txtSaveEndpoint.TabIndex = 27;
            this.txtSaveEndpoint.Text = "items";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(603, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Post Content";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(467, 20);
            this.textBox3.TabIndex = 24;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 396);
            this.Controls.Add(this.tabCtrl);
            this.Name = "frmMain";
            this.Text = "Breeze API Tester.";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabCtrl.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabServiceGet.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
            this.tabServiceSave.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaveReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetToken;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtBase64Auth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsAuthorised;
        private System.Windows.Forms.TextBox txtErrorMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReq;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabServiceGet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvReturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQuery2;
        private System.Windows.Forms.TextBox txtEndpoint2;
        private System.Windows.Forms.Button btnRequest2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtErrorMsg2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.TabPage tabServiceSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSaveQuery;
        private System.Windows.Forms.TextBox txtSaveEndpoint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dgvSaveReturn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSaveField;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSaveValue;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtID;
    }
}

