using FluentNHibernate.Mapping;
using PredictorApi.Layer1;

namespace PredictorApi.Layer2 {
    public class UserMap : ClassMap<User> {
        public UserMap () {
            Table("users");
            Id (x => x.Id);
            Map (x => x.FirstName).Column("first_name");
            Map(x=>x.LastName).Column("last_name");
            Map(x=>x.Email).Column("email");
            Map(x=>x.IsActive).Column("active");
            Map(x=>x.IsAdmin).Column("admin");
        }
    }
}