
using System;
using Assets.Sources.Infrastructure;
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.Models;
using Debug = UnityEngine.Debug;

namespace uMVVM.Sources.ViewModels
{
    public class SetupViewModel:ViewModel
    {
        public BindableProperty<string> Name = new BindableProperty<string>();
        public BindableProperty<string> Job=new BindableProperty<string>(); 
        public BindableProperty<int> ATK = new BindableProperty<int>();
        public BindableProperty<float> SuccessRate=new BindableProperty<float>(); 
        public BindableProperty<State> State=new BindableProperty<State>();

        public SetupViewModel()
        {
           
        }
       

        public void JoininCurrentTeam()
        {
            EventAggregator<object>.Instance.PublishEvent("Toggle", this,new EventArgs<object>("Red"));
                                               
            Debug.Log(Name.Value + "加入当前Team，职业："+Job.Value+",攻击力："+ATK.Value+"成功率："+SuccessRate.Value);
        }

        public void JoininClan()
        {
            EventAggregator<object>.Instance.PublishEvent("Toggle", this, new EventArgs<object>("Yellow"));
            Debug.Log(Name.Value + "加入当前Clan，职业：" + Job.Value + ",攻击力：" + ATK.Value + "成功率：" + SuccessRate.Value);
        }
    }
}
