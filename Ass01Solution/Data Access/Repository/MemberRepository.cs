using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

public class MemberRepository : IMemberRepository
    {
        public Member? GetMemberByID(int MemberId) => MemberDAO.Instance.GetMemberByID(MemberId);
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMemberList();

        public void InsertMember(Member member) => MemberDAO.Instance.AddNew(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.Update(member);
    }
