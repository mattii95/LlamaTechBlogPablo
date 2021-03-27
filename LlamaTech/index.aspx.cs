﻿using LlamaTech.BL;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlamaTech
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpEntradas();
                aboutUs();
                verRedSocial();
                verContacto();
            }
        }

        private void aboutUs()
        {
            HomePageBL homePageBL = new HomePageBL();
            DataSet ds = new DataSet();

            ds = homePageBL.getIdAbout(1);
            if(ds.Tables[0].Rows.Count > 0)
            {
                hTitle.InnerText = ds.Tables[0].Rows[0]["Titulo"].ToString();
                pDesc.InnerText = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                imgLogo.Src = ds.Tables[0].Rows[0]["Logo"].ToString();
            }
        }

        private void rpEntradas()
        {
            PublicacionBL publicacionBL = new PublicacionBL();

            DataSet ds = publicacionBL.top9Posts();

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpPost.DataSource = ds.Tables[0];
                rpPost.DataBind();
            }
            else
            {
                blog.Visible = false;
            }

        }
        protected void rpPost_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblM = e.Item.FindControl("lblMes") as Label;
            string mes = lblM.Text.Substring(0, 3);
            lblM.Text = mes;

            Label lblD = e.Item.FindControl("lblDesc") as Label;
            string desc = lblD.Text;

            if(desc.Length > 80)
            {
                lblD.Text = desc.Substring(0, 80) + "...";
            }
            else
            {
                lblD.Text = desc;
            }

            
        }

        private void verRedSocial()
        {
            HomePageBL homePageBL = new HomePageBL();

            DataSet ds = homePageBL.allRSActive();
            rpRs.DataSource = ds.Tables[0];
            rpRs.DataBind();
        }

        private void verContacto()
        {
            HomePageBL homePageBL = new HomePageBL();

            DataSet ds = homePageBL.allContactosRp();
            rpContacto.DataSource = ds.Tables[0];
            rpContacto.DataBind();
        }
    }
}