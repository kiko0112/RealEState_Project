

using MyProject.Models.realstates;

namespace MyProject.Models.Lists
{
    public class WishListItem
    {
       public int WishListId { get; set; }
        //public WishList WishList { get; set; }
        public int RealStatesId { get; set; }
        public RealEState RealStates { get; set; }
  }
}