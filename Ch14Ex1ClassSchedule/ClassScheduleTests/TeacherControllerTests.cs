global using Xunit;
global using Microsoft.AspNetCore.Mvc;
global using ClassSchedule.Models;
global using ClassSchedule.Controllers;
global using Moq;

using ClassSchedule.Controllers;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClassScheduleTests;

public class TeacherControllerTests
{
    [Fact]
    public void IndexActionMethod_ReturnsAViewResult()
    {
        // arrange 

        var rep = new Mock<IRepository<Teacher>>();
        var controller = new TeacherController(rep.Object);

        // act 

        var result = controller.Index();

        // assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]

    public void IndexActionMethod_ModellsAListOfTeacherObjects()
    {
        // arrange 
        var rep = new Mock<IRepository<Teacher>>();
        rep.Setup(t => t.Get(It.IsAny<QueryOptions<Teacher>>()))
            .Returns(new Teacher());
        var controller = new TeacherController(rep.Object);
        
        //act
        var model = controller.Index();
        
        //assert 
        Assert.IsType<ViewResult>(model);


    }




}