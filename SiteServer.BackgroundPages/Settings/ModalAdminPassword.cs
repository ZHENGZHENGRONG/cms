﻿using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using BaiRong.Core;

namespace SiteServer.BackgroundPages.Settings
{
	public class ModalAdminPassword : BasePage
	{
		public Label LbUserName;
		public TextBox TbPassword;

        private string _userName;

        public static string GetOpenWindowString(string userName)
        {
            return PageUtils.GetOpenLayerString("重设密码", PageUtils.GetSettingsUrl(nameof(ModalAdminPassword), new NameValueCollection
            {
                {"userName", userName}
            }), 480, 300);
        }
        
		public void Page_Load(object sender, EventArgs e)
        {
            if (IsForbidden) return;

            _userName = Body.GetQueryString("userName");

            if (IsPostBack) return;

            if (!string.IsNullOrEmpty(_userName) && BaiRongDataProvider.AdministratorDao.IsUserNameExists(_userName))
            {
                LbUserName.Text = _userName;
            }
            else
            {
                FailMessage("此帐户不存在！");
            }
        }

        public override void Submit_OnClick(object sender, EventArgs e)
        {
            if (!IsPostBack || !IsValid) return;

            try
            {
                string errorMessage;
                if (!BaiRongDataProvider.AdministratorDao.ChangePassword(_userName, TbPassword.Text, out errorMessage))
                {
                    FailMessage(errorMessage);
                    return;
                }

                Body.AddAdminLog("重设管理员密码", $"管理员:{_userName}");

                SuccessMessage("重设密码成功！");

                PageUtils.CloseModalPage(Page);
            }
            catch(Exception ex)
            {
                FailMessage(ex, "重设密码失败！");
            }
        }

	}
}
