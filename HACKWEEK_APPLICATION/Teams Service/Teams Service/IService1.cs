using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TeamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamsService" in both code and config file together.
    [ServiceContract]
    public interface ITeamsService
    {
        [OperationContract]
        List<SVCTeam> ListTeam();

        [OperationContract]
        bool AddTeam(SVCTeam team);

        [OperationContract]
        bool DeleteTeam(int TeamID);
    }

    [DataContract]
    public partial class SVCTeam
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public string TeamName { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string StadiumName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
