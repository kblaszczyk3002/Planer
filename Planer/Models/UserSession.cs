using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Models
{
    [Table("dbo.UsersSessions")]
    public class UserSession
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("UserAcronym")]
        public string UserAcronym { get; set; }
        [Column("SessionStart")]
        public DateTime SessionStart { get; set; }
        [Column("SessionEnd")]
        public DateTime SessionEnd { get; set; }

        public UserSession()
        {

        }

        public UserSession(int _Id, int _userId, string _userAcronym, DateTime _sessionStart, DateTime _sessionEnd)
        {
            Id = _Id;
            UserId = _userId;
            UserAcronym = _userAcronym;
            SessionStart = _sessionStart;
            SessionEnd = _sessionEnd;
        }
    }
}
