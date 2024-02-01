using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public sealed class MemberDAO
    {
        //Using Singleton Pattern
        private static MemberDAO? instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberDAO();
                }
                return instance;
            }
        }

        public ICollection<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var fStoreDB = new FStoreContext();
                members = fStoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        public Member? GetMemberByID(int memberID)
        {
            Member? member = null;
            try
            {
                var fStoreDB = new FStoreContext();
                member = fStoreDB.Members.SingleOrDefault(Member => Member.MemberId == memberID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member? GetMemberByEmail(string email)
        {
            Member? member = null;
            try
            {
                var fStoreDB = new FStoreContext();
                member = fStoreDB.Members.SingleOrDefault(Member => Member.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void AddNew(Member member)
        {
            try
            {
                Member? _Member = GetMemberByEmail(member.Email);
                if (_Member == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Members.Add(member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Email is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Member member)
        {
            try
            {
                Member? c = GetMemberByID(member.MemberId);
                if (c != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<Member>(member).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Login(string email, string password)
        {
            Member? member = null;
            try
            {
                var fStoreDB = new FStoreContext();
                member = fStoreDB.Members.SingleOrDefault(Member => Member.Email == email);
                if (member == null) return false;
                else if (member.Password == password) return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    }//end class
}
