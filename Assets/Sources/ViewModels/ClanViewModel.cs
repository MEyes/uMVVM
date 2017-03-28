using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Sources.Core.DataBinding;
using Assets.Sources.Models;
using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.ViewModels
{
    public class ClanViewModel : ViewModelBase
    {
        public readonly ObservableList<FaceBox> Members = new ObservableList<FaceBox>();

        #region 数据源
        public List<FaceBox> DataSource = new List<FaceBox>
        {
            new FaceBox
            {
                Name = "Eyes",
                Level = 10,
                Face = "Avatar201_Face",
                Badge = new Badge {Icon = "Icon_WeaponRod", ElementColor = "1CB9FFFF"}
            },
            new FaceBox
            {
                Name = "Jack",
                Level = 8,
                Face = "Avatar202_Face",
                Badge = new Badge {Icon = "Icon_WeaponSpear", ElementColor = "FF5821FF"}
            },
            new FaceBox
            {
                Name = "James",
                Level = 11,
                Face = "Avatar203_Face",
                Badge = new Badge {Icon = "Icon_WeaponSword", ElementColor = "09953BFF"}
            },
            new FaceBox
            {
                Name = "Bruce",
                Level = 8,
                Face = "Avatar204_Face",
                Badge = new Badge {Icon = "Icon_WeaponGun", ElementColor = "591E9FFF"}
            }
        }; 
        #endregion

        public override void OnStartReveal()
        {
            base.OnStartReveal();
            Initialization();
        }


        public void Initialization()
        {
            Members.Value = DataSource.ToList();
        }

        public void AddMember()
        {
            if (Members.Count<4)
            {
                var result = DataSource.OrderBy(o => Guid.NewGuid()).First();
                Members.Add(result);
            }
        }

        public void RemoveMember()
        {
            if (Members.Count>0)
            {
                Members.Remove(Members[0]);
            }
        }
    }
}
