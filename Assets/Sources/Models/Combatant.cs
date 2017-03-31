using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Assets.Sources.Core.Repository;

namespace uMVVM.Sources.Models
{
    public class Combatant
    {
        [RepositoryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public float SuccessRate { get; set; }
        public State State { get; set; }
    }
    public enum State
    {
        JoinIn,
        Wait
    }

}
