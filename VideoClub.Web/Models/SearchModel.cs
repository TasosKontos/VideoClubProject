namespace VideoClub.Web.Models
{
    public class SearchModel
    {
        public string titleSearch;
        public string genreFilter;

        public SearchModel(string titleSearch, string genreFilter)
        {
            this.titleSearch = titleSearch;
            this.genreFilter = genreFilter;
        }
    }
}
