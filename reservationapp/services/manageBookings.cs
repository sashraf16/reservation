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
            _fullsearch = fullsearch;
            List<string> result = new List<string>();

            int searchYear = Int32.Parse(fullsearch.search.startDate.Substring(0, 3));
            int searchMonth = Int32.Parse(fullsearch.search.startDate.Substring(5, 2));

            int daysinSearchMonth = DateTime.DaysInMonth(searchYear, searchMonth);

            int wantStart = Int32.Parse(fullsearch.search.startDate.Substring(8, 2));
            int wantEnd = Int32.Parse(fullsearch.search.endDate.Substring(8, 2));


            bool[] calendarMonth = new bool[daysinSearchMonth];
            // foreach (bool b in calendarMonth)
            // {

            //     System.Console.WriteLine(b);
            // }

            // foreach (reservation c in fullsearch.reservations)
            // {
            //     System.Console.WriteLine(fullsearch.reservations[1].campsiteId);
            // }
            System.Console.WriteLine("length:" + fullsearch.reservations.Length);
            for (int numReservations = 0; numReservations <= fullsearch.reservations.Length - 1; numReservations++)
            {
                // foreach (reservation c in fullsearch.reservations)
                // {
                // System.Console.WriteLine(fullsearch.reservations[numReservations].campsiteId +  " " + fullsearch.reservations[numReservations].startDate);
                System.Console.WriteLine("starting with" + fullsearch.reservations[numReservations].campsiteId);

                int start = Int32.Parse(fullsearch.reservations[numReservations].startDate.Substring(8, 2));
                int end = Int32.Parse(fullsearch.reservations[numReservations].endDate.Substring(8, 2));

                System.Console.WriteLine(start);
                System.Console.WriteLine(end);

                for (int updateCalendar = start; updateCalendar <= end; updateCalendar++)
                {
                    // System.Console.WriteLine(updateCalendar + "is true now");
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
                        }
                        else
                        {
                            System.Console.WriteLine("invalid reservation");
                            calendarMonth = resetCalendar(calendarMonth);
                        }


                    }
                }
                else
                {
                    // if (fullsearch.reservations[numReservations].campsiteId != fullsearch.reservations[numReservations + 1].campsiteId || numReservations + 1 == 8)
                    // {
                    // bool flag = false;
                    // if (calendarMonth[wantStart - 2] == false && calendarMonth[wantEnd + 2] == false)
                    if ((calendarMonth[wantStart - 2] == calendarMonth[wantStart - 1]) && (calendarMonth[wantEnd + 1] == calendarMonth[wantEnd + 2]))
                    {
                        System.Console.WriteLine("this will be a valid reservation");
                        calendarMonth = resetCalendar(calendarMonth);
                        System.Console.WriteLine(campgroundById(fullsearch.reservations[numReservations].campsiteId));
                        result.Add(campgroundById(fullsearch.reservations[numReservations].campsiteId));

                    }
                    else
                    {
                        System.Console.WriteLine("invalid resreve");
                        calendarMonth = resetCalendar(calendarMonth);
                    }
                    // }
                }

                // System.Console.WriteLine("bool calendar");
                // foreach (bool b in calendarMonth)
                // {
                //     System.Console.WriteLine(b);
                // }
                // for (int finalupdateCalendar = wantStart; finalupdateCalendar <= wantEnd; finalupdateCalendar++)
                // {
                //     calendarMonth[finalupdateCalendar] = true;
                //     //check -2 and +2 for true

                //         if (calendarMonth[finalupdateCalendar - 2] == true && calendarMonth[finalupdateCalendar + 2] == true)
                //         {
                //             System.Console.WriteLine("this will cause a 1 day gap");
                //         }
                //     }

                //     for (int checkCalendar = 0; checkCalendar < calendarMonth.Length; checkCalendar++)
                //     {
                //         if (calendarMonth[checkCalendar] == false && calendarMonth[checkCalendar] != calendarMonth[checkCalendar+1])
                //         {
                //             flag = true;
                //             System.Console.WriteLine("hello in flag");
                //         }

                //         else 
                //         {
                //             flag = false;
                //         }
                //     }

                //     if (flag == true)
                //     {
                //         System.Console.WriteLine((fullsearch.reservations[numReservations].campsiteId));
                //         System.Console.WriteLine("add a result.add here");
                //     }
                // }
                // }
            }
            // System.Console.WriteLine(daysinSearchMonth);
            System.Console.WriteLine(fullsearch.search.startDate);

            string[] arr = { "hello", "hello2" };
            // result.Add("hello)");
            return result;
        }


    }
}