using MyFriend.Models;

namespace MyFriend.Service
{
    public interface IFriendsService
    {
        public Task<List<FriendModel>> GetAll();

        public Task<FriendModel> Add(FriendModel model);
    }
}
