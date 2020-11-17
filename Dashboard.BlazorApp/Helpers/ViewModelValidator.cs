using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.Helpers
{
    public static class ViewModelValidator
    {
        public static bool IsValid(ApiResponseViewModel viewModel)
        {
            return viewModel != null && viewModel.Success;
        }
    }
}