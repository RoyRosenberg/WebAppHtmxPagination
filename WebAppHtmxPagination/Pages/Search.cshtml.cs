using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppHtmxPagination.Services;

namespace WebAppHtmxPagination.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PersonService srv;

        public Models.PersonModel PersonModel { get; set; }
        public List<SelectListItem> Users { get; set; }
        public SearchModel(ILogger<IndexModel> logger, PersonService srv)
        {
            _logger = logger;
            this.srv = srv;
            PersonModel = new Models.PersonModel();
            Users = new List<SelectListItem>()
            {
                new SelectListItem("User 1", "1"),
                new SelectListItem("User 2", "1"),
                new SelectListItem("User 3", "1"),
                new SelectListItem("User 4", "1"),
            };
        }

        public void OnGet(int id)
        {
            ViewData.Add("Users", Users);
            PersonModel.PagingInfo.CurrentPage = id;
            PersonModel.Result = srv.PersonList
                .Skip((PersonModel.PagingInfo.CurrentPage - 1) * PersonModel.PagingInfo.ItemsPerPage)
                .Take(PersonModel.PagingInfo.ItemsPerPage)
                .ToList();
            PersonModel.PagingInfo.TotalItems = srv.PersonList.Count;
        }

        public IActionResult OnGetPartial(int id)
        {
            ViewData.Add("Users", Users);
            PersonModel.PagingInfo.CurrentPage = id;
            PersonModel.Result = srv.PersonList
                .Skip((PersonModel.PagingInfo.CurrentPage - 1) * PersonModel.PagingInfo.ItemsPerPage)
                .Take(PersonModel.PagingInfo.ItemsPerPage)
                .ToList();
            return Partial("_PersonPartial", PersonModel);
        }
        
    }
}