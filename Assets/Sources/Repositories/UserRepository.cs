using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Repositories
{
    public class UserRepository:IUserRepository
    {
        public void Add()
        {
           Debug.Log("UserRepository");
        }
    }
}
