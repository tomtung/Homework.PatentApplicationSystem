using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Homework.PatentApplicationSystem.Model;
using Homework.PatentApplicationSystem.Model.Data;
using Microsoft.Practices.ServiceLocation;

namespace Homework.PatentApplicationSystem.ClientInfoManage
{
    public partial class 申请人 : System.Web.UI.Page
    {
        private IClientInfoManager _clientInfoManager = ServiceLocator.Current.GetInstance<IClientInfoManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = _clientInfoManager.GetAllApplicants();
            ListView1.DataBind();
        }
        protected void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = ListView1.SelectedValue.ToString();
            _clientInfoManager.RemoveApplicant(new Applicant() { 证件号 = s });
            Response.Redirect(Request.Url.ToString());
        }
        protected void ListView1SelectedIndexChanging(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _clientInfoManager.AddApplicant(new Applicant()
                                                {
                                                    证件号=证件号.Text,
                                                    类型 = 类型.Text,
                                                    中文名 = 中文名.Text,
                                                    英文名 = 英文名.Text,
                                                    简称 = 简称.Text,
                                                    国家 = 国家.Text,
                                                    省 = 省.Text,
                                                    市区县 = 市区县.Text,
                                                    中国地址 = 中国地址.Text,
                                                    外国地址 = 外国地址.Text,
                                                    邮编 = 邮编.Text,
                                                    电话 = 电话.Text,
                                                    传真 = 传真.Text,
                                                    Email = Email.Text
                                                });
            Response.Redirect(Request.Url.ToString());
        }


    }
}