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
        public CommonRepository<Shcool> Shcool
        {
            get
            {
                if (_shcool == null)
                {
                    _shcool = new CommonRepository<Shcool>(DB);
                }
                return _shcool;
            }
        }

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
        private CommonRepository<ConsultMajor> _consultMajor;
        public CommonRepository<ConsultMajor> ConsultMajor
        {

            get
            {
                if (_consultMajor == null)
                    _consultMajor = new CommonRepository<Model.ConsultMajor>(DB);
                return _consultMajor;
            }
        }
        private CommonRepository<CustomerState> _customerState;
        public CommonRepository<CustomerState> CustomerState
        {

            get
            {
                if (_customerState == null)
                    _customerState = new CommonRepository<Model.CustomerState>(DB);
                return _customerState;
            }
        }

        private CommonRepository<Team> _team;
        public CommonRepository<Team> Team
        {
            get
            {
                if (_team == null)
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
                    _student = new CommonRepository<Student>(DB);
                return _student;
            }
        }
        private CommonRepository<CommunicationRecord> _CommunicationRecord;
        public CommonRepository<CommunicationRecord> CommunicationRecord
        {
            get
            {
                if (_CommunicationRecord == null)
                {
                    _CommunicationRecord = new CommonRepository<CommunicationRecord>(DB);
                }
                return _CommunicationRecord;
            }
        }
        private CommonRepository<ConsultingType> _ConsultingType;
        public CommonRepository<ConsultingType> ConsultingType
        {
            get
            {
                if (_ConsultingType == null)
                {
                    _ConsultingType = new CommonRepository<ConsultingType>(DB);
                }
                return _ConsultingType;
            }
        }
        private CommonRepository<ConsultingWay> _ConsultingWay;
        public CommonRepository<ConsultingWay> ConsultingWay
        {
            get
            {
                if (_ConsultingWay == null)
                {
                    _ConsultingWay = new CommonRepository<ConsultingWay>(DB);
                }
                return _ConsultingWay;
            }
        }
        private CommonRepository<IntentionDegree> _IntentionDegree;
        public CommonRepository<IntentionDegree> IntentionDegree
        {
            get
            {
                if (_IntentionDegree == null)
                {
                    _IntentionDegree = new CommonRepository<IntentionDegree>(DB);
                }
                return _IntentionDegree;
            }
        }
        private CommonRepository<CustomerSource> _CustomerSource;
        public CommonRepository<CustomerSource> CustomerSource
        {
            get
            {
                if (_CustomerSource == null)
                {
                    _CustomerSource = new CommonRepository<CustomerSource>(DB);
                }
                return _CustomerSource;
            }
        }
        public void Save()
        {
            DB.SaveChanges();
        }

    }
}