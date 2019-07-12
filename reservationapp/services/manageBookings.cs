using reservationapp.models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace reservationapp.services
{
    public class manageBookings : iManagebookings
    {
        private fullsearch _fullsearch = new fullsearch();
        Dictionary<int,Boolean> _campList = new Dictionary<int, bool>();
        public bool[] resetCalendar(bool[] calendar)
        {
            for (int i = 0; i < calendar.Length; i++)
            {
                calendar[i] = false;
            }
            System.Console.WriteLine("reset calendar");

            return calendar;
        }
        public string campgroundById(int id)
        {
            foreach (campsite c in _fullsearch.campsites)
            {
                if (c.id == id)
                {
                    return c.name;
                }
            }
            return "hello";
        }
        public void campsiteChecklist()
        {
            foreach (campsite c in _fullsearch.campsites)
            {
                _campList.Add(c.id, false);
            }
        }

        public List<string> findCampgrounds(fullsearch fullsearch)
        {
            campsiteChecklist();
            _fullsearch = fullsearch;
            List<string> result = new List<string>();

            int searchYear = Int32.Parse(fullsearch.search.startDate.Substring(0, 3));
            int searchMonth = Int32.Parse(fullsearch.search.startDate.Substring(5, 2));

            int daysinSearchMonth = DateTime.DaysInMonth(searchYear, searchMonth);

            int wantStart = Int32.Parse(fullsearch.search.startDate.Substring(8, 2));
            int wantEnd = Int32.Parse(fullsearch.search.endDate.Substring(8, 2));


            bool[] calendarMonth = new bool[daysinSearchMonth];

            for (int numReservations = 0; numReservations <= fullsearch.reservations.Length - 1; numReservations++)
            {
                
                System.Console.WriteLine("starting with" + fullsearch.reservations[numReservations].campsiteId);

                int start = Int32.Parse(fullsearch.reservations[numReservations].startDate.Substring(8, 2));
                int end = Int32.Parse(fullsearch.reservations[numReservations].endDate.Substring(8, 2));

                for (int updateCalendar = start; updateCalendar <= end; updateCalendar++)
                {
                    calendarMonth[updateCalendar] = true;
                }

                if (numReservations != fullsearch.reservations.Length - 1)
                {
                    if (fullsearch.reservations[numReservations].campsiteId != fullsearch.reservations[numReservations + 1].campsiteId)
                    {
                        System.Console.WriteLine(calendarMonth[wantStart - 2] + " " + calendarMonth[wantStart - 1] + " " + calendarMonth[wantStart] + "starts");
                        System.Console.WriteLine(calendarMonth[wantEnd] + " " + calendarMonth[wantEnd + 1] + " " + calendarMonth[wantEnd + 2] + "end");

                        // bool flag = false;
                        if ((calendarMonth[wantStart - 2] == calendarMonth[wantStart - 1]) && (calendarMonth[wantEnd + 1] == calendarMonth[wantEnd + 2]))
                        {
                            System.Console.WriteLine("this will be a valid reservation");
                            System.Console.WriteLine(fullsearch.reservations[numReservations].campsiteId + "the id");
                            calendarMonth = resetCalendar(calendarMonth);
                            System.Console.WriteLine(campgroundById(fullsearch.reservations[numReservations].campsiteId));
                            result.Add(campgroundById(fullsearch.reservations[numReservations].campsiteId));

                            _campList[fullsearch.reservations[numReservations].campsiteId] = true;
                        }
                        else
                        {
                            System.Console.WriteLine("invalid reservation");
                            calendarMonth = resetCalendar(calendarMonth);

                            _campList[fullsearch.reservations[numReservations].campsiteId] = true;

                        }


                    }
                }
                else
                {
                    if ((calendarMonth[wantStart - 2] == calendarMonth[wantStart - 1]) && (calendarMonth[wantEnd + 1] == calendarMonth[wantEnd + 2]))
                    {
                        System.Console.WriteLine("this will be a valid reservation");
                        calendarMonth = resetCalendar(calendarMonth);
                        System.Console.WriteLine(campgroundById(fullsearch.reservations[numReservations].campsiteId));
                        result.Add(campgroundById(fullsearch.reservations[numReservations].campsiteId));

                            _campList[fullsearch.reservations[numReservations].campsiteId] = true;


                    }
                    else
                    {
                        System.Console.WriteLine("invalid resreve");
                        calendarMonth = resetCalendar(calendarMonth);
                            _campList[fullsearch.reservations[numReservations].campsiteId] = true;

                    }
                }

            }
            System.Console.WriteLine(fullsearch.search.startDate);


            foreach(KeyValuePair<int,Boolean> entry in _campList)
            {
                if (entry.Value == false)
                {
                    result.Add(campgroundById(entry.Key));
                }
            }

            return result;
        }


    }
}