﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ListViewODSCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region Error Handling
        protected void SelectCheckForException(object Sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        protected void InsertCheckForException(object Sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process Success", "Album has been added");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        protected void UpdateCheckForException(object Sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process Success", "Album has been updated");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        protected void DeleteCheckForException(object Sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Process Success", "Album has been removed");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        #endregion
    }
}