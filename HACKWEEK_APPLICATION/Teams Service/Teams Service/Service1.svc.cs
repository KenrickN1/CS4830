//#define INSANE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Teams_Service;

namespace TeamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ITeamsService
    {
        public List<SVCTeam> ListTeam()
        {
            List<SVCTeam> Team = new List<SVCTeam>();
            using (var db = new CS4380Entities2())
            {
                //.Include("Phone").Include("Email")
                var query = from teams in db.Teams
                            select teams;

                foreach (var team in query)
                {
                    SVCTeam svcteam = new TeamService.SVCTeam();
                    svcteam.ID = team.ID;
                    svcteam.Capacity = (int) team.Capacity;
                    svcteam.TeamName = team.TeamName;
                    svcteam.StadiumName = team.StadiumName;
                    svcteam.City = team.City;
                    
                    if(null != team.Phones && team.Phones.FirstOrDefault() != null)
                    {
                        svcteam.Phone = team.Phones.FirstOrDefault().PhoneNumber;
                    }
                    if(null != team.Emails && team.Emails.FirstOrDefault() != null)
                    {
                        svcteam.Email = team.Emails.FirstOrDefault().Email1;
                    }
                    Team.Add(svcteam);
                }
            }
            return (Team);
        }

        public bool AddTeam(SVCTeam team)
        {
            bool fResult = false;

            Team newteam = new Team();
            newteam.TeamName = team.TeamName;
            newteam.Capacity = team.Capacity;
            newteam.StadiumName = team.StadiumName;
            newteam.City = team.City;

            try
            {
                using (var db = new CS4380Entities2())
                {
                    db.Teams.Add(newteam);
                    db.SaveChanges();
                    newteam.Phones = new List<Phone>();
                    Phone dbTempPhone = new Phone();
                    dbTempPhone.PhoneNumber = team.Phone;
                    dbTempPhone.TeamID = newteam.ID;
                    newteam.Phones.Add(dbTempPhone);
                    newteam.Emails = new List<Email>();
                    Email dbTempEmail = new Email();      
                    dbTempEmail.Email1 = team.Email;
                    dbTempEmail.TeamID = newteam.ID;
                    newteam.Emails.Add(dbTempEmail);
                    db.Phones.Add(dbTempPhone);
                    db.Emails.Add(dbTempEmail);
                    db.SaveChanges();
                    fResult = true;
                }
            }
            catch(Exception err)
            {

            }
            return (fResult);

        }

        public bool DeleteTeam(int TeamID)
        {
            bool fResult = false;
            try
            {
                using (var db = new CS4380Entities2())
                {
#if INSANE
                    Team team = new Team();
                    team.ID = TeamID;
                    db.Team.Remove(team);
#else
                    var query1 = from teams in db.Teams
                                where teams.ID.Equals(TeamID)
                                select teams;
                    db.Teams.Remove(query1.FirstOrDefault());
#endif
                    db.SaveChanges();
                    fResult = true;
                }
            }
            catch(Exception err)
            {

            }
            return (fResult);
        }
    }
}