﻿namespace MyFriend.Models
{
    public class FriendModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<ImageModel> Images { get; set; }
    }
}
