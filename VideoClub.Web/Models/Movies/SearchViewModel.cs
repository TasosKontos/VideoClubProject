namespace VideoClub.Web.Models.Movies
{
    public class SearchViewModel
    {
        public string titleSearch;
        public string genreFilter;

        public SearchViewModel(string titleSearch, string genreFilter)
        {
            this.titleSearch = titleSearch;
            this.genreFilter = genreFilter;
        }
    }
}
