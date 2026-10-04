using ClassSchedule.Models;
using Microsoft.AspNetCore.Mvc;
namespace ClassSchedule.Components;

public class DayFilter : ViewComponent
{
    private  IRepository<Day> daysData { get; set; }

    public DayFilter(IRepository<Day> daysData)
    {
        this.daysData = daysData;
    }


    public IViewComponentResult Invoke()
    {
        var dayOptions = new QueryOptions<Day>
        {
            OrderBy = d => d.DayId
        };

        var dayList = daysData.List(dayOptions);
            
        

        return View(dayList);
    }
    
   /*
    *   
                // order classes by day and then time on first load (ie, there's no filter value).
                // Otherwise, filter by day and order by time.
                if (id == 0) {
                    classOptions.OrderBy = c => c.DayId;
                    classOptions.ThenOrderBy = c => c.MilitaryTime;
                }
                else {
                    classOptions.Where = c => c.DayId == id;
                    classOptions.OrderBy = c => c.MilitaryTime;
                }

                // execute queries
                var dayList = days.List(dayOptions);
                var classList = classes.List(classOptions);

                // send data to view
                ViewBag.Id = id;
                ViewBag.Days = dayList;
                return View(classList);
            }
        }
    **/
}