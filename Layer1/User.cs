using System;

namespace PredictorApi.Layer1
{
    public class User {
        public virtual int Id {get;set;}
        public virtual string Name {get;set;}
        public virtual DateTime DateOfBirth {get;set;}
    }
}