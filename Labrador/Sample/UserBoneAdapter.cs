using System;

namespace Labrador.Sample
{
    public class UserBoneAdapter : IBoneAdapter<User>
    {
        public User Resolve(System.Data.IDataRecord dataRecord)
        {
            var user = new User();

            user.Id = Convert.ToInt32(dataRecord["id"]);
            user.Username = dataRecord["username"].ToString();
            user.Password = dataRecord["password"].ToString();
            user.Created = DateTime.Parse(dataRecord["created"].ToString());
            user.Active = Convert.ToBoolean(dataRecord["active"]);

            return user;
        }
    }
}
