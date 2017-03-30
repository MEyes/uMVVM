using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Repositories
{
    public class UnitRepository:IUnitRepository
    {
        public void Get()
        {
            Debug.Log("Get----UnitRepository");
        }
    }
}
