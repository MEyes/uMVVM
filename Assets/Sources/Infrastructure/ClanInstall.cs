using Assets.Sources.Core.Factory;
using Assets.Sources.Core.Inject;
using Assets.Sources.Repositories;
using Assets.Sources.ViewModels;
using Assets.Sources.Views;
using UnityEngine;

namespace Assets.Sources.Infrastructure
{
    public class ClanInstall:MonoBehaviour
    {
        public ClanView clanView;
        void Start()
        {
            //绑定上下文
            clanView.BindingContext = new ClanViewModel();
            //立刻显示
            clanView.Reveal();

            PoolObjectFactory poolObjectFactory=new PoolObjectFactory(5,true);

            poolObjectFactory.AcquireObject(typeof(UserRepository));
            poolObjectFactory.AcquireObject(typeof(UserRepository));
            poolObjectFactory.AcquireObject(typeof(UserRepository));

            var result=poolObjectFactory.AcquireObject(typeof(UserRepository));
            poolObjectFactory.ReleaseObject(result);

            poolObjectFactory.AcquireObject(typeof(UserRepository));
            poolObjectFactory.AcquireObject(typeof(UserRepository));

            //            ServiceLocator.RegisterSingleton<UserRepository>();

            //
            //            var userRepo = ServiceLocator.Resolve<UserRepository>();
            //            userRepo.Add();
            //
            //            var userRepo1 = ServiceLocator.Resolve<UserRepository>();
            //            userRepo1.Add();

            //            var unitRepo = ServiceLocator.Resolve<IUnitRepository>();
            //            unitRepo.Get();

           ServiceLocator.RegisterSingleton<IUnitRepository,UnitRepository>();
           ServiceLocator.Resolve<IUnitRepository>();
        }
    }
}
