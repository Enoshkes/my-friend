using Microsoft.EntityFrameworkCore;
using MyFriend.Models;
using MyFriend.Repository;

namespace MyFriend.Service
{
    public class FriendsService(ApplicationDbContext context) : IFriendsService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<FriendModel>> GetAll() =>
            await _context.Friends.Include(f => f.Images).ToListAsync();

        public async Task<FriendModel> Add(FriendModel model)
        {
            await _context.Friends.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        } 
    }
}
