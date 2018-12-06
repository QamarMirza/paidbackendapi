using System;
using System.Collections.Generic;

namespace pictures
{
    public class PictureTemplates
    {
        public string id;
        public int index;
        public string guid;
        public string picture;
        public int likes;
        public int comments;
        public UserProfile user;
        public List<String> tags;
    }

    public class UserProfile
    {
        public string name;
        public string gender;
        public int age;
        public string email;
        public string phone;
        public string address;
        public string registered;
    }
    public class Data
    {
        public List<String> Names;
        public List<PictureTemplates> Content;
    }
}