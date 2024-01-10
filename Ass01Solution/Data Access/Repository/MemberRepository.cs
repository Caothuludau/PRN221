using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class MemberRepository : IMemberRepository
    {
        public Member GetMemberByID(int MemberId) => MemberDAO.Instance.GetMemberByID(MemberId);
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMemberList();

        public void InsertMember(Member Member) => MemberDAO.Instance.AddNew(Member);

        public void DeleteMember(Member Member) => MemberDAO.Instance.Remove(Member);

        public void UpdateMember(Member Member) => MemberDAO.Instance.Update(Member);
    }
}
