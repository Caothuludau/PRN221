using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public class MemberDAO
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

        public IEnumerable<Member> GetMemberList()
        {
            List<Member> Members;
            try
            {
                var fStoreDB = new BusinessObject.FStoreContext();
                Members = fStoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Members;
        }
        public Member GetMemberByID(int MemberID)
        {
            Member? Member = null;
            try
            {
                var fStoreDB = new FStoreContext();
                Member = fStoreDB.Members.SingleOrDefault(Member => Member.MemberId == MemberID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Member;
        }
        public void AddNew(Member Member)
        {
            try
            {
                Member _Member = GetMemberByID(Member.MemberId);
                if (_Member == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Members.Add(Member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(Member Member)
        {
            try
            {
                Member c = GetMemberByID(Member.MemberId);
                if (c != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<Member>(Member).State = EntityState.Modified;
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
        public void Remove(Member Member)
        {
            try
            {
                Member _Member = GetMemberByID(Member.MemberId);
                if (_Member != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Members.Remove(Member);
                    fStoreDB.SaveChanges();
                }

                else
                {
                    throw new Exception("The Member does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } // end Remove
    }//end class
}
