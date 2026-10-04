using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ClassSchedule.TagHelpers;

[HtmlTargetElement("my-link-button")]
public class MyLinkButtonTagHelper : TagHelper
{
    private LinkGenerator linkBuilder;
    public MyLinkButtonTagHelper(LinkGenerator lg) => linkBuilder = lg;
    
    [ViewContext] 
    [HtmlAttributeNotBound] 
    public ViewContext ViewCtx { get; set; } = null!;
    public string? Action { get; set; }
    public string? Controller { get; set; }
    public string? Id { get; set; }


    public override void Process(TagHelperContext context,
        TagHelperOutput output)
    {

        // get controller and action method creat paging link
        string action = Action ?? ViewCtx.RouteData.Values["action"]?.ToString() ?? "Index";
        string controller = Controller ?? ViewCtx.RouteData.Values["controller"]?.ToString() ?? "Home";


        var routeValues = new { id = Id };
        string url = linkBuilder.GetPathByAction(action, controller, routeValues) ?? "";

        string css = "";
        string viewId = ViewCtx.RouteData.Values["id"]?.ToString() ?? "";

        if (viewId == Id)
        {
            css = "btn btn-info";
        }
        else
        {
            css = "btn btn-outline-success";
        }
        
        output.BuildLink(url, css);

    }
}