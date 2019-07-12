using reservationapp.models;
using System.Collections.Generic;

namespace reservationapp.services
{
    public interface iManagebookings
    {
        List<string> findCampgrounds(fullsearch fullsearch);
        bool[] resetCalendar(bool[] calendar);
        string campgroundById(int id);
        void campsiteChecklist();
    }
}