using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional NameSpaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this is first time viewing page
                LoadArtistList();
            }
        }
        protected void LoadArtistList()
        {
            //user friendly error handling (aka Try/Catch)

            //use the UserControl MessageUserControl to manage the error handling for the web page when control
            //leaves the web page and goes to the class library

            MessageUserControl.TryRun(() => { 
                //what does inside the coding block?
                //your code that would normally be inside a Try/Catch
                ArtistController sysmgr = new ArtistController();
                List<SelectionList> info = sysmgr.Artists_ddlList();

                //lets assume the data collection needs to be sorted
                info.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //setup the ddl
                ArtistList.DataSource = info;
                ArtistList.DataTextField = nameof(SelectionList.DisplayField);
                ArtistList.DataValueField = nameof(SelectionList.ValueField);
                ArtistList.DataBind();

                //setup of a prompt line
                ArtistList.Items.Insert(0, new ListItem("select...", "0"));



            }, "Success Title Message" ,"The succes title and body messafe are optional");

 
        }
        #region Error handling Methods for ODS

        #endregion

        protected void SelectCheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        
        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if (ArtistList.SelectedIndex == 0)
            {
                //am i on the first physical line (prompt line) of the ddl
                MessageUserControl.ShowInfo("Search Selection Concern!", "select an artist for the search!");
                ArtistAlbumsList.DataSource = null;
                ArtistAlbumsList.DataBind();
            }
            else
            {
                MessageUserControl.TryRun(() =>
                {
                    AlbumController sysmgr = new AlbumController();
                    List<ChinookSystem.ViewModels.ArtistAlbums> info =
                        sysmgr.Albums_GetAlbumsForArtist(int.Parse(ArtistList.SelectedValue));
                    //testing if abort had happened
                    //throw new Exception("This is a test to see an abort from the web page code");
                    ArtistAlbumsList.DataSource = info;
                    ArtistAlbumsList.DataBind();



                }, "Search Results", "The list of albums for the selected artist");
            }    
            
        }
    }
}