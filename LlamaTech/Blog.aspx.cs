using LlamaTech.BE;
using LlamaTech.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlamaTech
{
    public partial class Blog : System.Web.UI.Page
    {
        PublicacionBL publicacionBL = new PublicacionBL();
        PagedDataSource _PagedDataSource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize;

        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set { ViewState["CurrentPage"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpEntradas();
                llenarCat();
            }
        } 

        private void rpEntradas()
        {
            DataTable dt = new DataTable();

            dt = publicacionBL.allPostAct();


            if (dt.Rows.Count > 0)
            {
                imgError.Visible = false;

                _PagedDataSource.DataSource = dt.DefaultView;
                _PagedDataSource.AllowPaging = true;
                _PagedDataSource.PageSize = 9;
                _PagedDataSource.CurrentPageIndex = CurrentPage;
                ViewState["TotalPages"] = _PagedDataSource.PageCount;

                if (dt.Rows.Count < 10)
                    divPaging.Visible = false;

                lbtnPrevious.Visible = !_PagedDataSource.IsFirstPage;
                lbtnNext.Visible = !_PagedDataSource.IsLastPage;
                lbtnFirst.Visible = !_PagedDataSource.IsFirstPage;
                lbtnLast.Visible = !_PagedDataSource.IsLastPage;

                rptEntradas.DataSource = _PagedDataSource;
                rptEntradas.DataBind();

                doPaging();

            }
            else
            {
                imgError.Visible = true;
            }

        }

        protected void rptEntradas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblM = e.Item.FindControl("lblMes") as Label;
            string mes = lblM.Text.Substring(0, 3);
            lblM.Text = mes;

            Label lblD = e.Item.FindControl("lblDesc") as Label;
            string desc = lblD.Text;

            if (desc.Length > 50)
            {
                lblD.Text = desc.Substring(0, 50) + "...";
            }
            else
            {
                lblD.Text = desc;
            }
        }

        #region -- handle index
        private void doPaging()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PageIndex");
            dt.Columns.Add("PageText");

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            for (int i = _firstIndex; i < _lastIndex; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            dlPaging.DataSource = dt;
            dlPaging.DataBind();

        }



        #endregion

        protected void lbtnFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            rpEntradas();
        }

        protected void lbtnPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            rpEntradas();
        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            rpEntradas();
        }

        protected void lbtnLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            rpEntradas();
        }

        protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("Paging")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            rpEntradas();
            
        }

        protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lbtnPage = (LinkButton)e.Item.FindControl("lbtnPaging");
            if (lbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
            {
                lbtnPage.Enabled = false;
                lbtnPage.Style.Add("font-size", "16");
                lbtnPage.Font.Bold = true;
            }
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = publicacionBL.filter(Convert.ToInt32(ddlCategorias.SelectedValue));

            if(Convert.ToInt32(ddlCategorias.SelectedValue) == 0)
            {
                rpEntradas();
                rptEntradas.Visible = true;
                imgError.Visible = false;
                doPaging();
            }
            else if (dt.Rows.Count > 0)
            {
                _PagedDataSource.DataSource = dt.DefaultView;
                _PagedDataSource.AllowPaging = true;
                _PagedDataSource.PageSize = 9;
                _PagedDataSource.CurrentPageIndex = CurrentPage;
                ViewState["TotalPages"] = _PagedDataSource.PageCount;

                if (dt.Rows.Count < 10)
                    divPaging.Visible = false;

                lbtnPrevious.Visible = !_PagedDataSource.IsFirstPage;
                lbtnNext.Visible = !_PagedDataSource.IsLastPage;
                lbtnFirst.Visible = !_PagedDataSource.IsFirstPage;
                lbtnLast.Visible = !_PagedDataSource.IsLastPage;

                rptEntradas.DataSource = _PagedDataSource;
                rptEntradas.DataBind();

                doPaging();
                imgError.Visible = false;
                rptEntradas.Visible = true;
            }
            else
            {
                imgError.Visible = true;
                rptEntradas.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PublicacionBL publicacionBL = new PublicacionBL();
            DataTable dt = new DataTable();

            dt = publicacionBL.getPostName(txtBuscar.Text);

            if (txtBuscar.Text == "")
            {
                rpEntradas();
                rptEntradas.Visible = true;
                imgError.Visible = false;
                doPaging();
            } else if (dt.Rows.Count > 0)
            {
                _PagedDataSource.DataSource = dt.DefaultView;
                _PagedDataSource.AllowPaging = true;
                _PagedDataSource.PageSize = 9;
                _PagedDataSource.CurrentPageIndex = CurrentPage;
                ViewState["TotalPages"] = _PagedDataSource.PageCount;

                if (dt.Rows.Count < 10)
                    divPaging.Visible = false;

                lbtnPrevious.Visible = !_PagedDataSource.IsFirstPage;
                lbtnNext.Visible = !_PagedDataSource.IsLastPage;
                lbtnFirst.Visible = !_PagedDataSource.IsFirstPage;
                lbtnLast.Visible = !_PagedDataSource.IsLastPage;

                rptEntradas.DataSource = _PagedDataSource;
                rptEntradas.DataBind();

                doPaging();
                imgError.Visible = false;
                rptEntradas.Visible = true;
            }
            else
            {
                imgError.Visible = true;
                rptEntradas.Visible = false;
            }
        }

        private void llenarCat()
        {
            DataSet ds = new DataSet();
            CategoriaBL categoriaBL = new CategoriaBL();

            ds = categoriaBL.categoriaActiva();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCategorias.DataSource = ds.Tables[0];
                ddlCategorias.DataValueField = "ID";
                ddlCategorias.DataTextField = "Categoria";
                ddlCategorias.DataBind();
                ddlCategorias.Items.Insert(0, new ListItem("Select Category", "0"));
                ddlCategorias.Attributes["style"] = "";
            }
            else
            {
                ddlCategorias.DataBind();
                ddlCategorias.Attributes["style"] = "display: none;";
            }
        }

        

    }
}