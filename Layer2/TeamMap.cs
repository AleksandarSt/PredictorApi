using FluentNHibernate.Mapping;
using PredictorApi.Layer1;

public class TeamMap : ClassMap<Team>
{
    public TeamMap()
    {
        Table("teams");
        Id(x => x.Id);
        Map(x => x.Name).Column("name");
        Map(x => x.DisplayName).Column("display_name");
    }
}