using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.Models
{
    public class Pagination
    {
        public int firstPage { get; set; }
        public int lastPage { get; set; }
        public int currentPage { get; set; }
        public int previousPage { get; set; }
        public int nextPage { get; set; }
        public int itemsPerPage { get; set; }
        public int pageIteratorStart { get; set; }
        public int pageIteratorEnd { get; set; }
        public int allItems { get; set; }

        public Pagination(string pageString, string itemsString, int allItems)
        {
            //read url query values
            try
            {
                currentPage = Convert.ToInt32(pageString);
                itemsPerPage = Convert.ToInt32(itemsString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                currentPage = 1;
                itemsPerPage = 5;
            }

            //set first page
            firstPage = 1;

            //make sure items per page value is valid ->> itemsPerPage = 5; should be changed for final version
            if (itemsPerPage <= 0) { itemsPerPage = 5; }

            //calculate last page
            if (allItems % itemsPerPage == 0 && allItems >= itemsPerPage) { lastPage = allItems / itemsPerPage; } else { lastPage = allItems / itemsPerPage + 1; }

            //make sure current page value is valid
            if (currentPage <= 0) { currentPage = 1; }
            if (currentPage > lastPage) { currentPage = lastPage; }

            //set next and previous pages - values greater and lower than first/last page 
            //are allowed due to the way the pagination elements are displayed
            nextPage = currentPage + 1;
            previousPage = currentPage - 1;

            //calculate starting index of elements on current page for allItems array
            pageIteratorStart = (currentPage - 1) * itemsPerPage;

            //calculate ending index of elements on current page for allItems array, beware of not-full last pages and empty arrays

            //ending index for full pages
            pageIteratorEnd = (currentPage - 1) * itemsPerPage + itemsPerPage - 1;

            //ending index for last, non-full page
            if (currentPage == lastPage)
            {
                pageIteratorEnd = allItems - 1;
            }

            //ending index for empty array
            if(allItems == 0) { pageIteratorEnd = -1; }


            //set allItems value
            this.allItems = allItems;


        }
    }
}