using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datapel.BreezeAPI.SDK;
using Datapel.BreezeAPI.SDK.Service;
using Datapel.BreezeAPI.SDK.Contract;
using System.Reflection;

namespace Datapel.BreezeAPI.Sample
{
    public partial class frmMain : Form
    {
        BreezeAPI.SDK.Client.AuthorisationState authoriseState;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetToken_Click(object sender, EventArgs e)
        {
            var authoriser = new Datapel.BreezeAPI.SDK.Client.APIAuthorizer();
            authoriseState = authoriser.AuthorizeClient(txtUser.Text, txtPwd.Text);
            txtBase64Auth.Text = authoriseState.AuthorisationCode;
            txtToken.Text = authoriseState.Auth_Token;
            chkIsAuthorised.Checked = authoriseState.isAuthorised;
            txtErrorMsg.Text = authoriseState.ErrorMsg; 
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            if (authoriseState == null || !authoriseState.isAuthorised)
                return; 
            var client = new Datapel.BreezeAPI.SDK.Client.APIClient(authoriseState);
            var tempStr = txtEndpoint.Text + "?" + txtQuery.Text; 
            var result = client.Get(tempStr);
            txtResult.Text = result.ToString();
        }

        private void btnRequest2_Click(object sender, EventArgs e)
        {
            if (authoriseState == null || !authoriseState.isAuthorised)
                return;
            var service = new ItemService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            var itemList = service.GetList(txtQuery2.Text, pageSkip, pagesize);
            dgvReturn.DataSource = itemList; 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Get an item for update 
            var service = new ItemService();
            var item = Get(service, txtSaveQuery.Text).FirstOrDefault();
            if (item != null)
            {
                setProperty(item, txtSaveField.Text, txtSaveValue.Text); 
            }
            #endregion
            

            if(service.Update(txtSaveQuery.Text, item))
            {
                var newitem = Get(service, txtSaveQuery.Text).FirstOrDefault();
            }

            

        }
        private IList <Item> Get (ItemService service,  string query)
        {
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;

            service.Authorised(txtUser.Text, txtPwd.Text);
            var itemList = service.GetList(query, pageSkip, pagesize);
            return itemList; 
        }

        private void setProperty(object obj, string propName, string strValue)
        {
            PropertyInfo prop = obj.GetType().GetProperty(propName, BindingFlags.Public|BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, strValue, null);
            }
        }
    }
}
