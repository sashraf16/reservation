using reservationapp.models;
using System.Collections.Generic;

namespace reservationapp.services
{
    public interface iManagebookings
    {
        List<string> findCampgrounds(fullsearch fullsearch);
    }
}