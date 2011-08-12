using OpenSurvey.Web.Resources;
using OpenRasta.Web;
namespace OpenSurvey.Web.Handlers
{
    public class NewSurveyHandler
    {
        public NewSurveyResource Get()
        {
            return new NewSurveyResource();
        }

        public OperationResult.SeeOther Post(NewSurveyResource resource)
        {
            var r = new SurveyResource { Title = resource.Title,Description=resource.Description };
            return new OperationResult.SeeOther { RedirectLocation = r.CreateUri() };
        }
    }
}