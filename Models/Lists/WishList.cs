
using MyProject1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models.Lists
{
    public class WishList
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<WishListItem> WishListItems { get; set; }


    }
}
