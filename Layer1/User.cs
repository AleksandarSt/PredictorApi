namespace PredictorApi.Layer1 {
    public class User {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual bool IsPremierLeaguePredictor { get; set; }
        public virtual bool IsChampionsLeaguePredictor { get; set; }
    }
}