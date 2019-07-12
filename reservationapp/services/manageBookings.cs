using reservationapp.models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace reservationapp.services
{
    public class manageBookings : iManagebookings
    {
        public List<string> findCampgrounds(fullsearch fullsearch)
        {
            List<string> result = new List<string>();

            int searchYear = Int32.Parse(fullsearch.search.startDate.Substring(0,3));
            int searchMonth = Int32.Parse(fullsearch.search.startDate.Substring(5,2));

            int daysinSearchMonth = DateTime.DaysInMonth(searchYear, searchMonth);

            bool[] calendarMonth = new bool[daysinSearchMonth];
            // foreach (bool b in calendarMonth)
            // {
                
            //     System.Console.WriteLine(b);
            // }

            // foreach (reservation c in fullsearch.reservations)
            // {
            //     System.Console.WriteLine(fullsearch.reservations[1].campsiteId);
            // }

            for (int numReservations = 0; numReservations < fullsearch.reservations.Length; numReservations++)
            {
                int wantStart = Int32.Parse(fullsearch.search.startDate.Substring(8,2));
                int wantEnd = Int32.Parse(fullsearch.search.endDate.Substring(8,2)); 
                // foreach (reservation c in fullsearch.reservations)
                // {
                    // System.Console.WriteLine(fullsearch.reservations[numReservations].campsiteId +  " " + fullsearch.reservations[numReservations].startDate);
                    int start = Int32.Parse(fullsearch.reservations[numReservations].startDate.Substring(8,2));
                    int end = Int32.Parse(fullsearch.reservations[numReservations].endDate.Substring(8,2));

                    System.Console.WriteLine(start);
                    System.Console.WriteLine(end);

                    for (int updateCalendar = start; updateCalendar <= end; updateCalendar++)
                    {
                        calendarMonth[updateCalendar] = true;
                    }

                    if (fullsearch.reservations[numReservations].campsiteId != fullsearch.reservations[numReservations+1].campsiteId)
                    {
                        bool flag = false;
                        for (int finalupdateCalendar = wantStart; finalupdateCalendar <= wantEnd; finalupdateCalendar++)
                        {
                            calendarMonth[finalupdateCalendar] = true;
                            //check -2 and +2 for true
                        }
                        
                        for (int checkCalendar = 0; checkCalendar < calendarMonth.Length; checkCalendar++)
                        {
                            if (calendarMonth[checkCalendar] == false && calendarMonth[checkCalendar] != calendarMonth[checkCalendar+1])
                            {
                                flag = true;
                                System.Console.WriteLine("hello in flag");
                            }

                            else 
                            {
                                flag = false;
                            }
                        }

                        if (flag == true)
                        {
                            System.Console.WriteLine((fullsearch.reservations[numReservations].campsiteId));
                            System.Console.WriteLine("add a result.add here");
                        }
                    }
                // }
            }
            System.Console.WriteLine(daysinSearchMonth);
            System.Console.WriteLine(fullsearch.search.startDate);

            string[] arr = {"hello", "hello2"};
            result.Add("hello)");
            return result;
        }
    }
}