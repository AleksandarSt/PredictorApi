using FluentNHibernate.Mapping;
using PredictorApi.Layer1;

namespace PredictorApi.Layer2 {
    public class UserMap : ClassMap<User> {
        public UserMap () {
            Table("Users");
            Id (x => x.Id);
            Map (x => x.Name);
            Map(x=>x.DateOfBirth);
        }
    }
}