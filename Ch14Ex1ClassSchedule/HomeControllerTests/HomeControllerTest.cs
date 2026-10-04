global using Xunit;
global using Microsoft.AspNetCore.Mvc;
global using ClassSchedule.Models;
global using ClassSchedule.Controllers;
global using Moq;


using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeControllerTests;

public class HomeControllerTest
{
    [Fact]
    public void IndexActionMethod_ReturnsAViewResult()
    {
        // arrange 
        var classRep = new Mock<IRepository<Class>>();
        var dayRep = new Mock<IRepository<Day>>();

        var controller = new HomeController(classRep.Object, dayRep.Object);

        var model = controller.Index(1);

        Assert.IsType<ViewResult>(model);




    }
}