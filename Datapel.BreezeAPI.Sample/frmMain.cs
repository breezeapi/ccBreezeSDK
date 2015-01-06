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

            switch(txtEndpoint2.Text.ToLower()){
                case "items":
                    GetItem();
                    break;
                case "inventorylist":
                    GetInventoryList();
                    break;
                case "inventory":
                    GetInventory();
                    break;
                case "contactlist":
                    GetContactList();
                    break;
                case "contact":
                    GetContact();
                    break;
                case "addresslist":
                    GetAddressList();
                    break;
                case "pricelist":
                    GetPriceList();
                    break;
                case "salelist":
                    GetSaleList();
                    break;
                case "sales":
                    GetSale();
                    break;
            }
        }

        private void GetItem ()
        {
            var service = new ItemService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }

        private void GetInventoryList()
        {
            var service = new InventoryListService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }
        private void GetInventory()
        {
            var service = new InventoryService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            dgvReturn.DataSource = service.GetInventoryById(txtID.Text);
        }

        private void GetContactList()
        {
            var service = new ContactListService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }
        private void GetContact()
        {
            var service = new ContactService();
            service.Authorised(txtUser.Text, txtPwd.Text);       
            dgvReturn.DataSource = service.GetContactById(txtID.Text);
        }
        private void GetAddressList()
        {
            var service = new AddressListService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            dgvReturn.DataSource = service.GetAddressById(txtID.Text);
        }
        private void GetPriceList()
        {
            var service = new PriceListService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetPriceList(txtID.Text, txtId2.Text); 
        }

        private void GetSaleList()
        {
            var service = new SaleListService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetSaleListByMYOBCardId(txtID.Text); 
        }
        private void GetSale()
        {
            var service = new SaleService();
            service.Authorised(txtUser.Text, txtPwd.Text);
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetSaleBySaleId(txtID.Text);
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            #region Get an item for update
            var service = new ItemService();
            var item = Get(service, txtSaveQuery.Text).FirstOrDefault();
            if (item != null)
            {
                setProperty(item, txtSaveField.Text, txtSaveValue.Text);
                item.basestockid = 0; 
            }
            #endregion

            if (service.Insert(txtSaveQuery.Text, item))
            {
                var newitem = Get(service, txtSaveQuery.Text).FirstOrDefault();
            }
        }

        private void txtSaveQuery_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
