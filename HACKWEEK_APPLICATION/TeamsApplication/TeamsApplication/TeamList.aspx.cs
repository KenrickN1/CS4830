using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamsApplication
{
    public partial class TeamList : System.Web.UI.Page
    {
        private static List<TeamService.SVCTeam> m_listTeam;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_listTeam = new List<TeamService.SVCTeam>();
                ShowTeamList();
            }
        }

        void HideAll()
        {
            divAddTeam.Visible = false;
            divTeamList.Visible = false;
        }

        void ShowTeamList()
        {
            HideAll();
            divTeamList.Visible = true;

            var client = new TeamService.TeamsServiceClient();
            var teams = client.ListTeam();

            listTeam.Items.Clear();
            foreach(var team in teams)
            {
                listTeam.Items.Add(team.TeamName + " " + team.StadiumName + " (" + team.Email + ")");
                m_listTeam.Add(team);
            }
            client.Close();
        }

        protected void buttonAddTeam_Click(object sender, EventArgs e)
        {
            HideAll();
            divAddTeam.Visible = true;
        }

        void AddTeam()
        {
            var client = new TeamService.TeamsServiceClient();
            TeamService.SVCTeam team = new TeamService.SVCTeam();
            team.TeamName = textTeamName.Text;
            team.StadiumName = textStadiumName.Text;
            team.City = textCity.Text;
            int Capacity = int.Parse(textCapacity.Text);
            team.Capacity =  Capacity;
            team.Email = textEmail.Text;
            team.Phone = textPhone.Text;
            client.AddTeam(team);
            client.Close();
        }
        
        protected void buttonDoAdd_Click(object sender, EventArgs e)
        {
            AddTeam();
            ShowTeamList();
        }

        protected void buttonDeleteTeam_Click(object sender, EventArgs e)
        {
            int i = listTeam.SelectedIndex;
            if (0 <= i)
            {
                DeleteTeam(i);
            }
            ShowTeamList();
        }

        private void DeleteTeam(int index)
        {
            var client = new TeamService.TeamsServiceClient();
            TeamService.SVCTeam team = m_listTeam[index];
            client.DeleteTeam(team.ID);
            client.Close();
        }
    }
}