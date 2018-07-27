using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;


namespace Hnqnkj.OA.DAL
{
    public class WorkUnit
    {
        private OADBContext db;
        public OADBContext DB { get { return this.db; } }
        public WorkUnit()
        {
            this.db = new OADBContext();
        }
        private CommonRepository<AdminUser> _admin;
        public CommonRepository<AdminUser> Admin
        {
            get
            {
                if (_admin == null)
                {
                    _admin = new CommonRepository<AdminUser>(DB);
                }
                return _admin;
            }
        }

        private CommonRepository<Shcool> _shcool;
        public CommonRepository<Shcool> Shcool { get => _shcool ?? new CommonRepository<Shcool>(DB); }

        private CommonRepository<Specialty> _specialty;
        public CommonRepository<Specialty> Specialty
        {
            get
            {
                if (_specialty == null)
                    _specialty = new CommonRepository<Model.Specialty>(DB);
                return _specialty;
            }
        }

        private CommonRepository<Team> _team;
        public CommonRepository<Team> Team
        {
            get
            {
                if(_team == null)
                {
                    _team = new CommonRepository<Model.Team>(DB);
                }
                return _team;
            }
        }

        private CommonRepository<Student> _student;
        public CommonRepository<Student> Student
        {
            get
            {
                if (_student == null)
                    _student = new CommonRepository<Model.Student>(DB);
                return _student;
            }
        }
        
    }
}