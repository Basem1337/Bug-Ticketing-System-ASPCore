﻿using BugTicketingSystem.DAL;
using College.BL;

namespace BugTicketingSystem.BL
{
    public interface IUserBugManager
    {
        Task<List<UserBugReadDTO>> GetAllAsync();
        Task<GeneralResult> AddAsync(Guid bugId, UserBugsAddDTO userBugDTO);
        Task<GeneralResult> DeleteAsync(Guid userId,Guid bugId);
    }
}
